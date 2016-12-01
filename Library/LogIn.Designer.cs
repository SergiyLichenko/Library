namespace Library
{
    partial class LogIn
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
            this.groupBox_ChooseDataSource = new System.Windows.Forms.GroupBox();
            this.radioButton_XML = new System.Windows.Forms.RadioButton();
            this.radioButton_MySql = new System.Windows.Forms.RadioButton();
            this.groupBox_MySqlConnection = new System.Windows.Forms.GroupBox();
            this.checkBox_WindowsAuthetication = new System.Windows.Forms.CheckBox();
            this.textBox_ConnectionString = new System.Windows.Forms.TextBox();
            this.textBox_UserPassword = new System.Windows.Forms.TextBox();
            this.textBox_UserLogin = new System.Windows.Forms.TextBox();
            this.textBox_InitialDialog = new System.Windows.Forms.TextBox();
            this.textBox_DataSource = new System.Windows.Forms.TextBox();
            this.label_ConnectionString = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.label_Login = new System.Windows.Forms.Label();
            this.labale_PersistSecurityInfo = new System.Windows.Forms.Label();
            this.label_Database = new System.Windows.Forms.Label();
            this.label_Server = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox_XML = new System.Windows.Forms.GroupBox();
            this.textBox_XMLdataSource = new System.Windows.Forms.TextBox();
            this.button_lookXMLData = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox_ChooseDataSource.SuspendLayout();
            this.groupBox_MySqlConnection.SuspendLayout();
            this.groupBox_XML.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_ChooseDataSource
            // 
            this.groupBox_ChooseDataSource.Controls.Add(this.radioButton_XML);
            this.groupBox_ChooseDataSource.Controls.Add(this.radioButton_MySql);
            this.groupBox_ChooseDataSource.Location = new System.Drawing.Point(51, 25);
            this.groupBox_ChooseDataSource.Name = "groupBox_ChooseDataSource";
            this.groupBox_ChooseDataSource.Size = new System.Drawing.Size(371, 100);
            this.groupBox_ChooseDataSource.TabIndex = 0;
            this.groupBox_ChooseDataSource.TabStop = false;
            this.groupBox_ChooseDataSource.Text = "ChooseDataSource";
            // 
            // radioButton_XML
            // 
            this.radioButton_XML.AutoSize = true;
            this.radioButton_XML.Location = new System.Drawing.Point(196, 39);
            this.radioButton_XML.Name = "radioButton_XML";
            this.radioButton_XML.Size = new System.Drawing.Size(95, 17);
            this.radioButton_XML.TabIndex = 1;
            this.radioButton_XML.TabStop = true;
            this.radioButton_XML.Text = "Use XML Data";
            this.radioButton_XML.UseVisualStyleBackColor = true;
            this.radioButton_XML.CheckedChanged += new System.EventHandler(this.radioButton_XML_CheckedChanged);
            // 
            // radioButton_MySql
            // 
            this.radioButton_MySql.AutoSize = true;
            this.radioButton_MySql.Location = new System.Drawing.Point(20, 39);
            this.radioButton_MySql.Name = "radioButton_MySql";
            this.radioButton_MySql.Size = new System.Drawing.Size(133, 17);
            this.radioButton_MySql.TabIndex = 0;
            this.radioButton_MySql.TabStop = true;
            this.radioButton_MySql.Text = "Use MySql Connection";
            this.radioButton_MySql.UseVisualStyleBackColor = true;
            this.radioButton_MySql.CheckedChanged += new System.EventHandler(this.radioButton_MySql_CheckedChanged);
            // 
            // groupBox_MySqlConnection
            // 
            this.groupBox_MySqlConnection.Controls.Add(this.checkBox_WindowsAuthetication);
            this.groupBox_MySqlConnection.Controls.Add(this.textBox_ConnectionString);
            this.groupBox_MySqlConnection.Controls.Add(this.textBox_UserPassword);
            this.groupBox_MySqlConnection.Controls.Add(this.textBox_UserLogin);
            this.groupBox_MySqlConnection.Controls.Add(this.textBox_InitialDialog);
            this.groupBox_MySqlConnection.Controls.Add(this.textBox_DataSource);
            this.groupBox_MySqlConnection.Controls.Add(this.label_ConnectionString);
            this.groupBox_MySqlConnection.Controls.Add(this.label_Password);
            this.groupBox_MySqlConnection.Controls.Add(this.label_Login);
            this.groupBox_MySqlConnection.Controls.Add(this.labale_PersistSecurityInfo);
            this.groupBox_MySqlConnection.Controls.Add(this.label_Database);
            this.groupBox_MySqlConnection.Controls.Add(this.label_Server);
            this.groupBox_MySqlConnection.Location = new System.Drawing.Point(141, 155);
            this.groupBox_MySqlConnection.Name = "groupBox_MySqlConnection";
            this.groupBox_MySqlConnection.Size = new System.Drawing.Size(738, 395);
            this.groupBox_MySqlConnection.TabIndex = 1;
            this.groupBox_MySqlConnection.TabStop = false;
            this.groupBox_MySqlConnection.Text = "MySql Connection";
            // 
            // checkBox_WindowsAuthetication
            // 
            this.checkBox_WindowsAuthetication.AutoSize = true;
            this.checkBox_WindowsAuthetication.Location = new System.Drawing.Point(204, 149);
            this.checkBox_WindowsAuthetication.Name = "checkBox_WindowsAuthetication";
            this.checkBox_WindowsAuthetication.Size = new System.Drawing.Size(15, 14);
            this.checkBox_WindowsAuthetication.TabIndex = 11;
            this.checkBox_WindowsAuthetication.UseVisualStyleBackColor = true;
            this.checkBox_WindowsAuthetication.CheckedChanged += new System.EventHandler(this.checkBox_WindowsAuthetication_CheckedChanged);
            // 
            // textBox_ConnectionString
            // 
            this.textBox_ConnectionString.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.textBox_ConnectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_ConnectionString.Location = new System.Drawing.Point(177, 308);
            this.textBox_ConnectionString.Name = "textBox_ConnectionString";
            this.textBox_ConnectionString.ReadOnly = true;
            this.textBox_ConnectionString.Size = new System.Drawing.Size(529, 23);
            this.textBox_ConnectionString.TabIndex = 10;
            // 
            // textBox_UserPassword
            // 
            this.textBox_UserPassword.Location = new System.Drawing.Point(204, 233);
            this.textBox_UserPassword.Name = "textBox_UserPassword";
            this.textBox_UserPassword.Size = new System.Drawing.Size(159, 20);
            this.textBox_UserPassword.TabIndex = 9;
            this.textBox_UserPassword.Leave += new System.EventHandler(this.textBox_UserPassword_Leave);
            // 
            // textBox_UserLogin
            // 
            this.textBox_UserLogin.Location = new System.Drawing.Point(204, 191);
            this.textBox_UserLogin.Name = "textBox_UserLogin";
            this.textBox_UserLogin.Size = new System.Drawing.Size(159, 20);
            this.textBox_UserLogin.TabIndex = 8;
            this.textBox_UserLogin.Leave += new System.EventHandler(this.textBox_UserLogin_Leave);
            // 
            // textBox_InitialDialog
            // 
            this.textBox_InitialDialog.Location = new System.Drawing.Point(204, 105);
            this.textBox_InitialDialog.Name = "textBox_InitialDialog";
            this.textBox_InitialDialog.Size = new System.Drawing.Size(159, 20);
            this.textBox_InitialDialog.TabIndex = 7;
            this.textBox_InitialDialog.Leave += new System.EventHandler(this.textBox_InitialDialog_Leave);
            // 
            // textBox_DataSource
            // 
            this.textBox_DataSource.Location = new System.Drawing.Point(204, 60);
            this.textBox_DataSource.Name = "textBox_DataSource";
            this.textBox_DataSource.Size = new System.Drawing.Size(159, 20);
            this.textBox_DataSource.TabIndex = 6;
            this.textBox_DataSource.Leave += new System.EventHandler(this.textBox_DataSource_Leave);
            // 
            // label_ConnectionString
            // 
            this.label_ConnectionString.AutoSize = true;
            this.label_ConnectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_ConnectionString.Location = new System.Drawing.Point(33, 308);
            this.label_ConnectionString.Name = "label_ConnectionString";
            this.label_ConnectionString.Size = new System.Drawing.Size(120, 17);
            this.label_ConnectionString.TabIndex = 5;
            this.label_ConnectionString.Text = "Connection String";
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Password.Location = new System.Drawing.Point(116, 233);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(69, 17);
            this.label_Password.TabIndex = 4;
            this.label_Password.Text = "Password";
            // 
            // label_Login
            // 
            this.label_Login.AutoSize = true;
            this.label_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Login.Location = new System.Drawing.Point(108, 191);
            this.label_Login.Name = "label_Login";
            this.label_Login.Size = new System.Drawing.Size(77, 17);
            this.label_Login.TabIndex = 3;
            this.label_Login.Text = "User LogIn";
            // 
            // labale_PersistSecurityInfo
            // 
            this.labale_PersistSecurityInfo.AutoSize = true;
            this.labale_PersistSecurityInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labale_PersistSecurityInfo.Location = new System.Drawing.Point(6, 146);
            this.labale_PersistSecurityInfo.Name = "labale_PersistSecurityInfo";
            this.labale_PersistSecurityInfo.Size = new System.Drawing.Size(179, 17);
            this.labale_PersistSecurityInfo.TabIndex = 2;
            this.labale_PersistSecurityInfo.Text = "Use Windows Authetication";
            // 
            // label_Database
            // 
            this.label_Database.AutoSize = true;
            this.label_Database.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Database.Location = new System.Drawing.Point(93, 105);
            this.label_Database.Name = "label_Database";
            this.label_Database.Size = new System.Drawing.Size(92, 17);
            this.label_Database.TabIndex = 1;
            this.label_Database.Text = "Initial Catalog";
            // 
            // label_Server
            // 
            this.label_Server.AutoSize = true;
            this.label_Server.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Server.Location = new System.Drawing.Point(98, 61);
            this.label_Server.Name = "label_Server";
            this.label_Server.Size = new System.Drawing.Size(87, 17);
            this.label_Server.TabIndex = 0;
            this.label_Server.Text = "Data Source";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Choose XML Data Source";
            // 
            // groupBox_XML
            // 
            this.groupBox_XML.Controls.Add(this.textBox_XMLdataSource);
            this.groupBox_XML.Controls.Add(this.button_lookXMLData);
            this.groupBox_XML.Controls.Add(this.label7);
            this.groupBox_XML.Location = new System.Drawing.Point(476, 25);
            this.groupBox_XML.Name = "groupBox_XML";
            this.groupBox_XML.Size = new System.Drawing.Size(425, 124);
            this.groupBox_XML.TabIndex = 7;
            this.groupBox_XML.TabStop = false;
            this.groupBox_XML.Text = "XML Connection";
            // 
            // textBox_XMLdataSource
            // 
            this.textBox_XMLdataSource.Location = new System.Drawing.Point(196, 43);
            this.textBox_XMLdataSource.Name = "textBox_XMLdataSource";
            this.textBox_XMLdataSource.Size = new System.Drawing.Size(159, 20);
            this.textBox_XMLdataSource.TabIndex = 12;
            // 
            // button_lookXMLData
            // 
            this.button_lookXMLData.Location = new System.Drawing.Point(298, 87);
            this.button_lookXMLData.Name = "button_lookXMLData";
            this.button_lookXMLData.Size = new System.Drawing.Size(75, 23);
            this.button_lookXMLData.TabIndex = 7;
            this.button_lookXMLData.Text = "Look XML Data";
            this.button_lookXMLData.UseVisualStyleBackColor = true;
            this.button_lookXMLData.Click += new System.EventHandler(this.button_lookXMLData_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(813, 610);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(656, 605);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 33);
            this.button2.TabIndex = 9;
            this.button2.Text = "Connect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 684);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox_XML);
            this.Controls.Add(this.groupBox_MySqlConnection);
            this.Controls.Add(this.groupBox_ChooseDataSource);
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogIn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogIn_FormClosing);
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.groupBox_ChooseDataSource.ResumeLayout(false);
            this.groupBox_ChooseDataSource.PerformLayout();
            this.groupBox_MySqlConnection.ResumeLayout(false);
            this.groupBox_MySqlConnection.PerformLayout();
            this.groupBox_XML.ResumeLayout(false);
            this.groupBox_XML.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_ChooseDataSource;
        private System.Windows.Forms.RadioButton radioButton_XML;
        private System.Windows.Forms.RadioButton radioButton_MySql;
        private System.Windows.Forms.GroupBox groupBox_MySqlConnection;
        private System.Windows.Forms.CheckBox checkBox_WindowsAuthetication;
        private System.Windows.Forms.TextBox textBox_ConnectionString;
        private System.Windows.Forms.TextBox textBox_UserPassword;
        private System.Windows.Forms.TextBox textBox_UserLogin;
        private System.Windows.Forms.TextBox textBox_InitialDialog;
        private System.Windows.Forms.TextBox textBox_DataSource;
        private System.Windows.Forms.Label label_ConnectionString;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.Label label_Login;
        private System.Windows.Forms.Label labale_PersistSecurityInfo;
        private System.Windows.Forms.Label label_Database;
        private System.Windows.Forms.Label label_Server;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox_XML;
        private System.Windows.Forms.TextBox textBox_XMLdataSource;
        private System.Windows.Forms.Button button_lookXMLData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}