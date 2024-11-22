namespace Bitwarden.Desktop.AutoFill.UI
{
    partial class SettingsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            _btnChangeKeyStroke = new Button();
            _txtKeyStroke = new TextBox();
            label1 = new Label();
            _lblChangeKeyStrokeInfo = new Label();
            _notifyIcon = new NotifyIcon(components);
            label2 = new Label();
            _txtBitwardenUri = new TextBox();
            _txtBitwardenEmail = new TextBox();
            label3 = new Label();
            _txtBitwardenPassword = new TextBox();
            label4 = new Label();
            _btnSave = new Button();
            label5 = new Label();
            _btnQuit = new Button();
            _btnReload = new Button();
            _checkStoreMasterPassword = new CheckBox();
            SuspendLayout();
            // 
            // _btnChangeKeyStroke
            // 
            _btnChangeKeyStroke.BackColor = Color.FromArgb(53, 58, 58);
            _btnChangeKeyStroke.FlatStyle = FlatStyle.Flat;
            _btnChangeKeyStroke.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _btnChangeKeyStroke.ForeColor = Color.FromArgb(90, 121, 41);
            _btnChangeKeyStroke.Location = new Point(413, 7);
            _btnChangeKeyStroke.Name = "_btnChangeKeyStroke";
            _btnChangeKeyStroke.Size = new Size(75, 23);
            _btnChangeKeyStroke.TabIndex = 0;
            _btnChangeKeyStroke.Text = "Change";
            _btnChangeKeyStroke.UseVisualStyleBackColor = false;
            _btnChangeKeyStroke.Click += HandleKeyStrokeChange;
            // 
            // _txtKeyStroke
            // 
            _txtKeyStroke.BackColor = Color.FromArgb(53, 58, 58);
            _txtKeyStroke.BorderStyle = BorderStyle.FixedSingle;
            _txtKeyStroke.ForeColor = Color.FromArgb(171, 164, 170);
            _txtKeyStroke.Location = new Point(186, 7);
            _txtKeyStroke.Name = "_txtKeyStroke";
            _txtKeyStroke.ReadOnly = true;
            _txtKeyStroke.Size = new Size(218, 23);
            _txtKeyStroke.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(151, 21);
            label1.TabIndex = 2;
            label1.Text = "Autofill Keystroke:";
            // 
            // _lblChangeKeyStrokeInfo
            // 
            _lblChangeKeyStrokeInfo.AutoSize = true;
            _lblChangeKeyStrokeInfo.ForeColor = Color.FromArgb(90, 121, 41);
            _lblChangeKeyStrokeInfo.Location = new Point(186, 33);
            _lblChangeKeyStrokeInfo.Name = "_lblChangeKeyStrokeInfo";
            _lblChangeKeyStrokeInfo.Size = new Size(239, 15);
            _lblChangeKeyStrokeInfo.TabIndex = 3;
            _lblChangeKeyStrokeInfo.Text = "Some info about pressing key combinations";
            // 
            // _notifyIcon
            // 
            _notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            _notifyIcon.BalloonTipText = "Bitwarden Desktop AutoFill is running in the background. Click tray icon to open Settings.";
            _notifyIcon.BalloonTipTitle = "Bitwarden Desktop AutoFill - Running";
            _notifyIcon.Icon = (Icon)resources.GetObject("_notifyIcon.Icon");
            _notifyIcon.Text = "Bitwarden Desktop AutoFill";
            _notifyIcon.Visible = true;
            _notifyIcon.MouseClick += HandleTrayIconClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 58);
            label2.Name = "label2";
            label2.Size = new Size(126, 21);
            label2.TabIndex = 4;
            label2.Text = "Bitwarden URL:";
            // 
            // _txtBitwardenUri
            // 
            _txtBitwardenUri.BackColor = Color.FromArgb(53, 58, 58);
            _txtBitwardenUri.BorderStyle = BorderStyle.FixedSingle;
            _txtBitwardenUri.ForeColor = Color.FromArgb(171, 164, 170);
            _txtBitwardenUri.Location = new Point(186, 56);
            _txtBitwardenUri.Name = "_txtBitwardenUri";
            _txtBitwardenUri.Size = new Size(302, 23);
            _txtBitwardenUri.TabIndex = 5;
            _txtBitwardenUri.TextChanged += HandleTextChange;
            // 
            // _txtBitwardenEmail
            // 
            _txtBitwardenEmail.BackColor = Color.FromArgb(53, 58, 58);
            _txtBitwardenEmail.BorderStyle = BorderStyle.FixedSingle;
            _txtBitwardenEmail.ForeColor = Color.FromArgb(171, 164, 170);
            _txtBitwardenEmail.Location = new Point(186, 85);
            _txtBitwardenEmail.Name = "_txtBitwardenEmail";
            _txtBitwardenEmail.Size = new Size(302, 23);
            _txtBitwardenEmail.TabIndex = 7;
            _txtBitwardenEmail.TextChanged += HandleTextChange;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 87);
            label3.Name = "label3";
            label3.Size = new Size(145, 21);
            label3.TabIndex = 6;
            label3.Text = "Bitwarden E-Mail:";
            // 
            // _txtBitwardenPassword
            // 
            _txtBitwardenPassword.BackColor = Color.FromArgb(53, 58, 58);
            _txtBitwardenPassword.BorderStyle = BorderStyle.FixedSingle;
            _txtBitwardenPassword.ForeColor = Color.FromArgb(171, 164, 170);
            _txtBitwardenPassword.Location = new Point(186, 114);
            _txtBitwardenPassword.Name = "_txtBitwardenPassword";
            _txtBitwardenPassword.PasswordChar = '*';
            _txtBitwardenPassword.Size = new Size(302, 23);
            _txtBitwardenPassword.TabIndex = 9;
            _txtBitwardenPassword.TextChanged += HandleTextChange;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 118);
            label4.Name = "label4";
            label4.Size = new Size(168, 21);
            label4.TabIndex = 8;
            label4.Text = "Bitwarden Password:";
            // 
            // _btnSave
            // 
            _btnSave.FlatStyle = FlatStyle.Flat;
            _btnSave.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _btnSave.ForeColor = Color.FromArgb(90, 121, 41);
            _btnSave.Location = new Point(364, 202);
            _btnSave.Name = "_btnSave";
            _btnSave.Size = new Size(124, 29);
            _btnSave.TabIndex = 10;
            _btnSave.Text = "Save && Close";
            _btnSave.UseVisualStyleBackColor = true;
            _btnSave.Click += HandleSaveSettings;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.FromArgb(90, 121, 41);
            label5.Location = new Point(186, 140);
            label5.Name = "label5";
            label5.Size = new Size(218, 15);
            label5.TabIndex = 13;
            label5.Text = "Leave empty to ask for master password";
            // 
            // _btnQuit
            // 
            _btnQuit.FlatStyle = FlatStyle.Flat;
            _btnQuit.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _btnQuit.ForeColor = Color.OrangeRed;
            _btnQuit.Location = new Point(12, 202);
            _btnQuit.Name = "_btnQuit";
            _btnQuit.Size = new Size(124, 29);
            _btnQuit.TabIndex = 14;
            _btnQuit.Text = "Quit";
            _btnQuit.UseVisualStyleBackColor = true;
            _btnQuit.Click += HandleQuit;
            // 
            // _checkStoreMasterPassword
            // 
            _checkStoreMasterPassword.AutoSize = true;
            _checkStoreMasterPassword.FlatStyle = FlatStyle.Flat;
            _checkStoreMasterPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _checkStoreMasterPassword.ForeColor = Color.FromArgb(171, 164, 170);
            _checkStoreMasterPassword.Location = new Point(186, 158);
            _checkStoreMasterPassword.Name = "_checkStoreMasterPassword";
            _checkStoreMasterPassword.Size = new Size(264, 38);
            _checkStoreMasterPassword.TabIndex = 12;
            _checkStoreMasterPassword.Text = "Save encrypted Master Password on disk\r\n(not recommended)";
            _checkStoreMasterPassword.UseVisualStyleBackColor = true;
            _checkStoreMasterPassword.CheckedChanged += HandleTextChange;
            // 
            // _btnReload
            // 
            _btnReload.FlatStyle = FlatStyle.Flat;
            _btnReload.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _btnReload.ForeColor = Color.Gray;
            _btnReload.Location = new Point(142, 202);
            _btnReload.Name = "_btnReload";
            _btnReload.Size = new Size(124, 29);
            _btnReload.TabIndex = 15;
            _btnReload.Text = "Reload";
            _btnReload.UseVisualStyleBackColor = true;
            _btnReload.Click += HandleReload;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(42, 49, 51);
            ClientSize = new Size(500, 241);
            Controls.Add(_btnReload);
            Controls.Add(_btnQuit);
            Controls.Add(label5);
            Controls.Add(_checkStoreMasterPassword);
            Controls.Add(_btnSave);
            Controls.Add(_txtBitwardenPassword);
            Controls.Add(label4);
            Controls.Add(_txtBitwardenEmail);
            Controls.Add(label3);
            Controls.Add(_txtBitwardenUri);
            Controls.Add(label2);
            Controls.Add(_lblChangeKeyStrokeInfo);
            Controls.Add(label1);
            Controls.Add(_txtKeyStroke);
            Controls.Add(_btnChangeKeyStroke);
            ForeColor = Color.FromArgb(171, 164, 170);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsForm";
            Text = "Bitwarden Desktop AutoFill";
            FormClosing += HandleFormClosing;
            Load += HandleFormLoad;
            Resize += HandleFormMinimize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button _btnChangeKeyStroke;
        private TextBox _txtKeyStroke;
        private Label label1;
        private Label _lblChangeKeyStrokeInfo;
        private NotifyIcon _notifyIcon;
        private Label label2;
        private TextBox _txtBitwardenUri;
        private TextBox _txtBitwardenEmail;
        private Label label3;
        private TextBox _txtBitwardenPassword;
        private Label label4;
        private Button _btnSave;
        private CheckBox _checkStoreMasterPassword;
        private Label label5;
        private Button _btnQuit;
        private Button _btnReload;
    }
}
