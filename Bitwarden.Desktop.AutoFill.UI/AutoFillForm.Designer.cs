namespace Bitwarden.Desktop.AutoFill.UI
{
    partial class AutoFillForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoFillForm));
            _credentialsPanel = new Panel();
            SuspendLayout();
            // 
            // _credentialsPanel
            // 
            _credentialsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _credentialsPanel.Location = new Point(5, 5);
            _credentialsPanel.Name = "_credentialsPanel";
            _credentialsPanel.Size = new Size(440, 130);
            _credentialsPanel.TabIndex = 1;
            // 
            // AutoFillForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(42, 49, 51);
            ClientSize = new Size(450, 140);
            Controls.Add(_credentialsPanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AutoFillForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bitwarden AutoFill";
            TopMost = true;
            Load += HandleFormLoad;
            ResumeLayout(false);
        }

        #endregion
        private Panel _credentialsPanel;
    }
}