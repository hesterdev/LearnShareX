namespace ShareX.HelpersLib
{
    partial class DownloaderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloaderForm));
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblFilename = new System.Windows.Forms.Label();
            this.txtChangelog = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbProgress = new ShareX.HelpersLib.BlackStyleProgressBar();
            this.cbShowChangelog = new ShareX.HelpersLib.BlackStyleCheckBox();
            this.btnAction = new ShareX.HelpersLib.BlackStyleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProgress
            // 
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblProgress, "lblProgress");
            this.lblProgress.ForeColor = System.Drawing.Color.White;
            this.lblProgress.Name = "lblProgress";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Name = "lblStatus";
            // 
            // lblFilename
            // 
            this.lblFilename.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblFilename, "lblFilename");
            this.lblFilename.ForeColor = System.Drawing.Color.White;
            this.lblFilename.Name = "lblFilename";
            // 
            // txtChangelog
            // 
            this.txtChangelog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.txtChangelog.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtChangelog, "txtChangelog");
            this.txtChangelog.Name = "txtChangelog";
            this.txtChangelog.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ShareX.HelpersLib.Properties.Resources.Icon;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // pbProgress
            // 
            this.pbProgress.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pbProgress, "pbProgress");
            this.pbProgress.Maximum = 100;
            this.pbProgress.Minimum = 0;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Value = 0;
            // 
            // cbShowChangelog
            // 
            this.cbShowChangelog.BackColor = System.Drawing.Color.Transparent;
            this.cbShowChangelog.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.cbShowChangelog, "cbShowChangelog");
            this.cbShowChangelog.ForeColor = System.Drawing.Color.White;
            this.cbShowChangelog.Name = "cbShowChangelog";
            this.cbShowChangelog.SpaceAfterCheckBox = 3;
            // 
            // btnAction
            // 
            this.btnAction.BackColor = System.Drawing.Color.Transparent;
            this.btnAction.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnAction, "btnAction");
            this.btnAction.ForeColor = System.Drawing.Color.White;
            this.btnAction.Name = "btnAction";
            // 
            // DownloaderForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.cbShowChangelog);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtChangelog);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblFilename);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.Name = "DownloaderForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblProgress;
        private BlackStyleProgressBar pbProgress;
        private System.Windows.Forms.TextBox txtChangelog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private BlackStyleCheckBox cbShowChangelog;
        private BlackStyleButton btnAction;
    }
}