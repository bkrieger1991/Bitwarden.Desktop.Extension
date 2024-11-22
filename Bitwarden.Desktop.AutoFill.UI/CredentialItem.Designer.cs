namespace Bitwarden.Desktop.AutoFill.UI
{
    partial class CredentialItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _lblCredentialName = new Label();
            _lblUsername = new Label();
            _lblDescription = new Label();
            SuspendLayout();
            // 
            // _lblCredentialName
            // 
            _lblCredentialName.AutoSize = true;
            _lblCredentialName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _lblCredentialName.ForeColor = Color.White;
            _lblCredentialName.Location = new Point(3, 0);
            _lblCredentialName.Name = "_lblCredentialName";
            _lblCredentialName.Size = new Size(206, 21);
            _lblCredentialName.TabIndex = 0;
            _lblCredentialName.Text = "Your super AutoFill Secret";
            // 
            // _lblUsername
            // 
            _lblUsername.AutoSize = true;
            _lblUsername.BackColor = Color.Transparent;
            _lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _lblUsername.ForeColor = Color.FromArgb(195, 188, 194);
            _lblUsername.Location = new Point(3, 24);
            _lblUsername.Name = "_lblUsername";
            _lblUsername.Size = new Size(252, 15);
            _lblUsername.TabIndex = 1;
            _lblUsername.Text = "MyUser - Insert: {Tab}{Tab}{Password}{Enter}";
            // 
            // _lblDescription
            // 
            _lblDescription.AutoSize = true;
            _lblDescription.BackColor = Color.Transparent;
            _lblDescription.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _lblDescription.ForeColor = Color.FromArgb(96, 99, 100);
            _lblDescription.Location = new Point(3, 39);
            _lblDescription.Name = "_lblDescription";
            _lblDescription.Size = new Size(428, 15);
            _lblDescription.TabIndex = 2;
            _lblDescription.Text = "Description of the credential item should not be longer than this string here";
            // 
            // CredentialItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(42, 49, 51);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(_lblDescription);
            Controls.Add(_lblUsername);
            Controls.Add(_lblCredentialName);
            Name = "CredentialItem";
            Size = new Size(440, 60);
            Load += CredentialItem_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label _lblCredentialName;
        private Label _lblUsername;
        private Label _lblDescription;
    }
}
