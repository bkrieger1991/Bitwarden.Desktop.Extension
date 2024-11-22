namespace Bitwarden.Desktop.AutoFill.UI
{
    partial class EnterPasswordControl
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
            _panelEnterPassword = new Panel();
            _btnCancel = new Button();
            _btnContinue = new Button();
            label1 = new Label();
            _txtMasterPassword = new TextBox();
            _panelEnterPassword.SuspendLayout();
            SuspendLayout();
            // 
            // _panelEnterPassword
            // 
            _panelEnterPassword.Controls.Add(_btnCancel);
            _panelEnterPassword.Controls.Add(_btnContinue);
            _panelEnterPassword.Controls.Add(label1);
            _panelEnterPassword.Controls.Add(_txtMasterPassword);
            _panelEnterPassword.Location = new Point(5, 5);
            _panelEnterPassword.Name = "_panelEnterPassword";
            _panelEnterPassword.Size = new Size(430, 120);
            _panelEnterPassword.TabIndex = 2;
            // 
            // _btnCancel
            // 
            _btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCancel.FlatStyle = FlatStyle.Flat;
            _btnCancel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _btnCancel.ForeColor = Color.FromArgb(90, 121, 41);
            _btnCancel.Location = new Point(8, 78);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(124, 29);
            _btnCancel.TabIndex = 12;
            _btnCancel.Text = "Cancel";
            _btnCancel.UseVisualStyleBackColor = true;
            _btnCancel.Click += HandlePasswordCancel;
            // 
            // _btnContinue
            // 
            _btnContinue.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnContinue.FlatStyle = FlatStyle.Flat;
            _btnContinue.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _btnContinue.ForeColor = Color.FromArgb(90, 121, 41);
            _btnContinue.Location = new Point(296, 78);
            _btnContinue.Name = "_btnContinue";
            _btnContinue.Size = new Size(124, 29);
            _btnContinue.TabIndex = 11;
            _btnContinue.Text = "Continue";
            _btnContinue.UseVisualStyleBackColor = true;
            _btnContinue.Click += HandlePasswordContinue;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(171, 164, 170);
            label1.Location = new Point(3, 16);
            label1.Name = "label1";
            label1.Size = new Size(307, 21);
            label1.TabIndex = 9;
            label1.Text = "Enter your Bitwarden master password:";
            // 
            // _txtMasterPassword
            // 
            _txtMasterPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtMasterPassword.BackColor = Color.FromArgb(53, 58, 58);
            _txtMasterPassword.BorderStyle = BorderStyle.FixedSingle;
            _txtMasterPassword.ForeColor = Color.FromArgb(171, 164, 170);
            _txtMasterPassword.Location = new Point(8, 40);
            _txtMasterPassword.Name = "_txtMasterPassword";
            _txtMasterPassword.PasswordChar = '*';
            _txtMasterPassword.Size = new Size(412, 23);
            _txtMasterPassword.TabIndex = 7;
            _txtMasterPassword.KeyDown += HandlePasswordKeyDown;
            // 
            // EnterPasswordControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(42, 49, 51);
            Controls.Add(_panelEnterPassword);
            Name = "EnterPasswordControl";
            Size = new Size(440, 130);
            _panelEnterPassword.ResumeLayout(false);
            _panelEnterPassword.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel _panelEnterPassword;
        private Button _btnCancel;
        private Button _btnContinue;
        private Label label1;
        private TextBox _txtMasterPassword;
    }
}
