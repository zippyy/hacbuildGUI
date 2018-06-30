using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;


namespace hacbuildGUI
{
    public partial class mainForm : Form
    {
        public static Random Rand = new Random();
        public static SHA256 SHA256 = SHA256CryptoServiceProvider.Create();
        public static Aes AES128CBC = Aes.Create();


        private XCIManager.xci_header header;
        private XCIManager.gamecard_info gcInfo;


        public mainForm()
        {
            InitializeComponent();


            this.Text = "HACbuild - "+Assembly.GetExecutingAssembly().GetName().Version.ToString();
            keyCheck();
            configure();
        }



        public void keyCheck()
        {
            lblKeyCheck.Text = "";
            lblKeyCheck.BackColor = Color.White;
            if (LoadKeys())
            {

                lblKeyCheck.Text = "Key: " + BitConverter.ToString(XCIManager.XCI_GAMECARDINFO_KEY);


                byte[] keyHash = mainForm.SHA256.ComputeHash(XCIManager.XCI_GAMECARDINFO_KEY);

                if (Enumerable.SequenceEqual<byte>(keyHash, XCIManager.XCI_GAMECARD_KEY_SHA256))
                {

                    lblKeyCheck.ForeColor = Color.Green;
                    lblKeyCheck.Text += "\nThe Key is Correct!";
                }
                else
                {
                    lblKeyCheck.ForeColor = Color.Red;
                    lblKeyCheck.Text += "\tInvalid Key!";

                }

            }
            else
            {
                lblKeyCheck.ForeColor = Color.Red;
                lblKeyCheck.Text += "\tCould not load the Key!";
 
            }
        }
        public void configure()
        {
            // Configure AES
            AES128CBC.BlockSize = 128;
            AES128CBC.Mode = CipherMode.CBC;
            AES128CBC.Padding = PaddingMode.Zeros;

    
        }


        static bool LoadKeys()
        {
            bool ret = false;
            try
            {
                StreamReader file = new StreamReader("keys.txt");

                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split('=');
                    if (parts.Length < 2) continue;

                    string name = parts[0].Trim(" \0\n\r\t".ToCharArray());
                    string key = parts[1].Trim(" \0\n\r\t".ToCharArray());

                    //Console.WriteLine("{0} = {1}", name, key);

                    if (name == "xci_header_key")
                    {
                        XCIManager.XCI_GAMECARDINFO_KEY = Utils.StringToByteArray(key);
                        ret = true;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERR] keys.txt is either missing or unaccessible.");
                ret = false;
            }
            return ret;

        }
        public string decBytesToHex(byte[] byteArray)
        {
            var sb = new StringBuilder("");
            for (var i = 0; i < byteArray.Length; i++)
            {
                var b = byteArray[i].ToString("X");
                sb.Append(b);
                if (i < byteArray.Length - 1)
                {
                    sb.Append("-");
                }
            }
            
            return sb.ToString();
        }


        private void btnReadXCI_Click(object sender, EventArgs e)
        {
            clearReadData();
            if (selectXCIDialog.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    setFilenameLabel();
                    writeXCIToTextbox();
                    btnCreateINI.Enabled = true;
                }
                catch(Exception ex)
                {
                    btnCreateINI.Enabled = false;
                    MessageBox.Show(ex.ToString());
                }

            }
            else
            {
                btnCreateINI.Enabled = false;
                MessageBox.Show("Error when opening the XCI File, please try to select another file!");
            }
        }
        public void setFilenameLabel()
        {
            lblFilename.Text = selectXCIDialog.SafeFileName;
        }
        public void writeXCIToTextbox()
        {
            header = XCIManager.GetXCIHeader(selectXCIDialog.FileName);
            gcInfo = XCIManager.DecryptGamecardInfo(header);

            rtbGameInfo.Text += "["+selectXCIDialog.SafeFileName + "]\n";
            rtbGameInfo.Text += "Header: " + header.ToString() + "\n";
            rtbGameInfo.Text += "Game Card Info: " + gcInfo.ToString() + "\n";
        }

        public void createINIFile()
        {

            FileStream iniStream = new FileStream(("game_info_" + DateTime.Now.ToFileTimeUtc() + ".ini"), FileMode.OpenOrCreate);
            StreamWriter ini = new StreamWriter(iniStream);


            //Write XCI Header
            ini.WriteLine("[XCI_Header]");
            ini.WriteLine("PackageID=" + header.PackageID.ToString());
            ini.WriteLine("GamecardIV=" + decBytesToHex(header.GamecardIV));
            ini.WriteLine("KEKIndex=" + header.KEK.ToString());
            ini.WriteLine("InitialDataHash=" + decBytesToHex(header.InitialDataHash));


            //Write GameCard Info
            ini.WriteLine("[GameCard_Info]");
            ini.WriteLine("Version=" + gcInfo.Version.ToString());
            ini.WriteLine("AccessControlFlags=" + gcInfo.AccessControlFlags.ToString());
            ini.WriteLine("ReadWaitTime=" + gcInfo.ReadWaitTime.ToString());
            ini.WriteLine("ReadWaitTime2=" + gcInfo.ReadWaitTime2.ToString());
            ini.WriteLine("WriteWriteTime=" + gcInfo.WriteWriteTime.ToString());
            ini.WriteLine("WriteWriteTime2=" + gcInfo.WriteWriteTime2.ToString());
            ini.WriteLine("FirmwareMode=" + gcInfo.FirmwareMode.ToString());
            ini.WriteLine("CUPVersion=" + gcInfo.CUPVersion.ToString());
            ini.WriteLine("CUPID=" + gcInfo.CUPID.ToString());


            ini.Close();
            iniStream.Close();
        }
        private void btnCreateINI_Click(object sender, EventArgs e)
        {
            createINIFile();

        }







        // Entrypoint
       
        public bool prepareInOutDialogs()
        {
            inDirDialog.SelectedPath = null;
            outFileDialog.FileName = null;

            outFileDialog.Filter = "HFS0-File|*.hfs0";

            bool checkIfError = true;
            if(inDirDialog.ShowDialog()==DialogResult.OK)
            {
                if(outFileDialog.ShowDialog()==DialogResult.OK)
                {
                        checkIfError = false;
                }
                else
                {
                    MessageBox.Show("Error with the selected Save Path");
                }
            }
            else
            {
                MessageBox.Show("Error with the selected Directory!");
            }
            return checkIfError;
        }
        public bool prepareInOutDialogs(string path,string filter)
        {


            inDirDialog.SelectedPath = path;
            outFileDialog.FileName = path;

            outFileDialog.Filter = filter;


            bool checkIfError = true;
            if (inDirDialog.ShowDialog() == DialogResult.OK)
            {
                if (outFileDialog.ShowDialog() == DialogResult.OK)
                {
                    checkIfError = false;
                }
                else
                {
                    MessageBox.Show("Error with the selected Save Path");
                }
            }
            else
            {
                MessageBox.Show("Error with the selected Directory!");
            }
            return checkIfError;
        }

        private void btnBuildHFS0_Click(object sender, EventArgs e)
        {
            clearReadData();
            if (!prepareInOutDialogs())
            {
                try
                {
                    HFS0Manager.BuildHFS0(inDirDialog.SelectedPath,outFileDialog.FileName);
                    MessageBox.Show("Sucessfully build the file!");
                    System.Diagnostics.Process.Start("explorer.exe", "/select, \"" + outFileDialog.FileName + "\"");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
                MessageBox.Show("Error when setting the paths!");


        }

        private void btnXCI_Click(object sender, EventArgs e)
        {
            clearReadData();
            if (!prepareInOutDialogs("","XCI-File|*.xci"))
            {
                try
                {
                    XCIManager.BuildXCI(inDirDialog.SelectedPath, outFileDialog.FileName);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
                MessageBox.Show("Error when setting the paths!");
        }

        private void btnAutoXCI_Click(object sender, EventArgs e)
        {
            clearReadData();
            if (!prepareInOutDialogs(Environment.CurrentDirectory,"XCI-File|*.xci"))
            {
                try
                {
                    string inPath = Path.Combine(inDirDialog.SelectedPath);
                    string outPath = Path.Combine(outFileDialog.FileName);
                    string tmpPath = Path.Combine(inPath, "root_tmp");
                    Directory.CreateDirectory(tmpPath);

                    HFS0Manager.BuildHFS0(Path.Combine(inPath, "secure"), Path.Combine(tmpPath, "secure"));
                    HFS0Manager.BuildHFS0(Path.Combine(inPath, "normal"), Path.Combine(tmpPath, "normal"));
                    HFS0Manager.BuildHFS0(Path.Combine(inPath, "update"), Path.Combine(tmpPath, "update"));
                    if (Directory.Exists(Path.Combine(inPath, "logo")))
                        HFS0Manager.BuildHFS0(Path.Combine(inPath, "logo"), Path.Combine(tmpPath, "logo"));
                    HFS0Manager.BuildHFS0(tmpPath, Path.Combine(inPath, "root.hfs0"));

                    XCIManager.BuildXCI(inPath, outPath);

                    File.Delete(Path.Combine(inPath, "root.hfs0"));
                    Directory.Delete(tmpPath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
                MessageBox.Show("Error when setting the paths!");
        }

        public void clearReadData()
        {
            rtbGameInfo.Clear();
            btnCreateINI.Enabled = false;
            lblFilename.Text = "Filename";
        }
    }
}
