namespace hacbuildGUI
{
    partial class mainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.lblKeyCheck = new System.Windows.Forms.Label();
            this.btnReadXCI = new System.Windows.Forms.Button();
            this.rtbGameInfo = new System.Windows.Forms.RichTextBox();
            this.selectXCIDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnCreateINI = new System.Windows.Forms.Button();
            this.lblFilename = new System.Windows.Forms.Label();
            this.btnBuildHFS0 = new System.Windows.Forms.Button();
            this.inDirDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.outFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnXCI = new System.Windows.Forms.Button();
            this.gbTools = new System.Windows.Forms.GroupBox();
            this.btnAutoXCI = new System.Windows.Forms.Button();
            this.gbTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblKeyCheck
            // 
            this.lblKeyCheck.AutoSize = true;
            this.lblKeyCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyCheck.Location = new System.Drawing.Point(12, 9);
            this.lblKeyCheck.Name = "lblKeyCheck";
            this.lblKeyCheck.Size = new System.Drawing.Size(77, 13);
            this.lblKeyCheck.TabIndex = 0;
            this.lblKeyCheck.Text = "lblKeyCheck";
            // 
            // btnReadXCI
            // 
            this.btnReadXCI.Location = new System.Drawing.Point(6, 19);
            this.btnReadXCI.Name = "btnReadXCI";
            this.btnReadXCI.Size = new System.Drawing.Size(121, 23);
            this.btnReadXCI.TabIndex = 1;
            this.btnReadXCI.Text = "Read XCI Data";
            this.btnReadXCI.UseVisualStyleBackColor = true;
            this.btnReadXCI.Click += new System.EventHandler(this.btnReadXCI_Click);
            // 
            // rtbGameInfo
            // 
            this.rtbGameInfo.Location = new System.Drawing.Point(434, 25);
            this.rtbGameInfo.Name = "rtbGameInfo";
            this.rtbGameInfo.Size = new System.Drawing.Size(434, 278);
            this.rtbGameInfo.TabIndex = 2;
            this.rtbGameInfo.Text = "";
            // 
            // selectXCIDialog
            // 
            this.selectXCIDialog.FileName = "selectXCIDialog";
            this.selectXCIDialog.Title = "Select XCI File";
            // 
            // btnCreateINI
            // 
            this.btnCreateINI.Enabled = false;
            this.btnCreateINI.Location = new System.Drawing.Point(434, 308);
            this.btnCreateINI.Name = "btnCreateINI";
            this.btnCreateINI.Size = new System.Drawing.Size(75, 23);
            this.btnCreateINI.TabIndex = 3;
            this.btnCreateINI.Text = "Create INI";
            this.btnCreateINI.UseVisualStyleBackColor = true;
            this.btnCreateINI.Click += new System.EventHandler(this.btnCreateINI_Click);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilename.Location = new System.Drawing.Point(434, 7);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(59, 15);
            this.lblFilename.TabIndex = 4;
            this.lblFilename.Text = "Filename";
            // 
            // btnBuildHFS0
            // 
            this.btnBuildHFS0.Location = new System.Drawing.Point(6, 48);
            this.btnBuildHFS0.Name = "btnBuildHFS0";
            this.btnBuildHFS0.Size = new System.Drawing.Size(121, 23);
            this.btnBuildHFS0.TabIndex = 5;
            this.btnBuildHFS0.Text = "Build HFS0";
            this.btnBuildHFS0.UseVisualStyleBackColor = true;
            this.btnBuildHFS0.Click += new System.EventHandler(this.btnBuildHFS0_Click);
            // 
            // inDirDialog
            // 
            this.inDirDialog.Description = "Select the input directory";
            // 
            // outFileDialog
            // 
            this.outFileDialog.Filter = "HFS0-FIle|*.hfs0";
            // 
            // btnXCI
            // 
            this.btnXCI.Location = new System.Drawing.Point(6, 77);
            this.btnXCI.Name = "btnXCI";
            this.btnXCI.Size = new System.Drawing.Size(121, 23);
            this.btnXCI.TabIndex = 6;
            this.btnXCI.Text = "Build XCI";
            this.btnXCI.UseVisualStyleBackColor = true;
            this.btnXCI.Click += new System.EventHandler(this.btnXCI_Click);
            // 
            // gbTools
            // 
            this.gbTools.Controls.Add(this.btnAutoXCI);
            this.gbTools.Controls.Add(this.btnReadXCI);
            this.gbTools.Controls.Add(this.btnXCI);
            this.gbTools.Controls.Add(this.btnBuildHFS0);
            this.gbTools.Location = new System.Drawing.Point(15, 45);
            this.gbTools.Name = "gbTools";
            this.gbTools.Size = new System.Drawing.Size(133, 255);
            this.gbTools.TabIndex = 7;
            this.gbTools.TabStop = false;
            this.gbTools.Text = "Tools";
            // 
            // btnAutoXCI
            // 
            this.btnAutoXCI.Location = new System.Drawing.Point(6, 226);
            this.btnAutoXCI.Name = "btnAutoXCI";
            this.btnAutoXCI.Size = new System.Drawing.Size(121, 23);
            this.btnAutoXCI.TabIndex = 7;
            this.btnAutoXCI.Text = "Auto XCI";
            this.btnAutoXCI.UseVisualStyleBackColor = true;
            this.btnAutoXCI.Click += new System.EventHandler(this.btnAutoXCI_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 337);
            this.Controls.Add(this.gbTools);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.btnCreateINI);
            this.Controls.Add(this.rtbGameInfo);
            this.Controls.Add(this.lblKeyCheck);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.Text = "...";
            this.gbTools.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblKeyCheck;
        private System.Windows.Forms.Button btnReadXCI;
        private System.Windows.Forms.RichTextBox rtbGameInfo;
        private System.Windows.Forms.OpenFileDialog selectXCIDialog;
        private System.Windows.Forms.Button btnCreateINI;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.Button btnBuildHFS0;
        private System.Windows.Forms.FolderBrowserDialog inDirDialog;
        private System.Windows.Forms.SaveFileDialog outFileDialog;
        private System.Windows.Forms.Button btnXCI;
        private System.Windows.Forms.GroupBox gbTools;
        private System.Windows.Forms.Button btnAutoXCI;
    }
}

