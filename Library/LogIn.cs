using System;
using System.Windows.Forms;
using Common;

namespace Library
{
    public partial class LogIn : Form
    {
        public string ConnectionParameters { get; private set; }
        public SourceType DataType {get;private set;}

        public LogIn()
        {
            InitializeComponent();

            textBox_ConnectionString.Text = @"server=;user id=;password=;persistsecurityinfo=True;database=";
        }

        private void radioButton_MySql_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_MySqlConnection.Enabled = true;
            groupBox_XML.Enabled = false;
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            radioButton_MySql_CheckedChanged(null, null);
            textBox_DataSource.Text = @".\SQLEXPRESS";
            textBox_InitialDialog.Text = @"Library";
        }

        private void radioButton_XML_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_XML.Enabled = true;
            groupBox_MySqlConnection.Enabled = false;
        }

        private void TextBox_DataSource_Leave(object sender, EventArgs e)
        {
            FormConnectionString();
        }

        private void TextBox_InitialDialog_Leave(object sender, EventArgs e)
        {
            FormConnectionString();
        }

        private void CheckBox_WindowsAuthetication_CheckedChanged(object sender, EventArgs e)
        {
            FormConnectionString();
            textBox_UserLogin.Enabled = false;
            textBox_UserPassword.Enabled = false;
        }

        private void TextBox_UserLogin_Leave(object sender, EventArgs e)
        {
            FormConnectionString();
        }

        private void TextBox_UserPassword_Leave(object sender, EventArgs e)
        {
            FormConnectionString();
        }

        private void FormConnectionString()
        {
            ConnectionParameters =
                $"Data Source = {textBox_DataSource.Text.Trim()};Initial Catalog = {textBox_InitialDialog.Text.Trim()};" +
                $"Integrated Security = {checkBox_WindowsAuthetication.Checked};uid = {textBox_UserLogin.Text.Trim()};" +
                $"pwd= {textBox_UserPassword.Text.Trim()}";

            textBox_ConnectionString.Text = ConnectionParameters;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button_lookXMLData_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                FileName = string.Empty,
                Filter = @"File XML (*.xml)|*.xml|All files (*.*)|*.*"
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
                textBox_XMLdataSource.Text = fileDialog.FileName;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (radioButton_XML.Checked)
            {
                ConnectionParameters = textBox_XMLdataSource.Text.Trim();
                DataType = SourceType.Xml;
            }
            else
            {
                if (checkBox_WindowsAuthetication.Checked)
                {
                    if(textBox_DataSource.Text.Trim() == String.Empty || textBox_InitialDialog.Text.Trim() == String.Empty)
                    {
                        MessageBox.Show(@"Заполните все поля");
                        return;
                    }
                }
                else if(textBox_DataSource.Text.Trim() == String.Empty || textBox_InitialDialog.Text.Trim() == String.Empty || 
                    textBox_UserLogin.Text.Trim() == "" || textBox_UserPassword.Text.Trim() == "")
                {
                    MessageBox.Show(@"Заполните все поля");
                    return;
                }
                ConnectionParameters = textBox_ConnectionString.Text.Trim();
                DataType = SourceType.Sql;
            }
            DialogResult = DialogResult.OK;
        }

        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult !=DialogResult.OK)
                Application.Exit();
        }
    }
}