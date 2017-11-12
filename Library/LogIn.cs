using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace Library
{
    public partial class LogIn : Form
    {
        public string ConnectionParameters { get; private set; }
        public SourceType dataType {get;private set;}
        public LogIn()
        {
            InitializeComponent();

            textBox_ConnectionString.Text = "server=;user id=;password=;persistsecurityinfo=True;database=";
        }

        private void radioButton_MySql_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_MySqlConnection.Enabled = true;
            groupBox_XML.Enabled = false;
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            radioButton_MySql_CheckedChanged(null, null);
            textBox_DataSource.Text = ".\\SQLEXPRESS";
            textBox_InitialDialog.Text = "Library";
        }

        private void radioButton_XML_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_XML.Enabled = true;
            groupBox_MySqlConnection.Enabled = false;
        }

        private void textBox_DataSource_Leave(object sender, EventArgs e)
        {
            FormConnectionString();
        }

        private void textBox_InitialDialog_Leave(object sender, EventArgs e)
        {
            FormConnectionString();
        }

        private void checkBox_WindowsAuthetication_CheckedChanged(object sender, EventArgs e)
        {
            FormConnectionString();
            this.textBox_UserLogin.Enabled = false;
            this.textBox_UserPassword.Enabled = false;
        }

        private void textBox_UserLogin_Leave(object sender, EventArgs e)
        {
            FormConnectionString();
        }

        private void textBox_UserPassword_Leave(object sender, EventArgs e)
        {
            FormConnectionString();
        }
        private void FormConnectionString()
        {
            ConnectionParameters = String.Format("Data Source = {0};Initial Catalog = {1};Integrated Security = {2};uid = {3};pwd= {4}",
                textBox_DataSource.Text.Trim(),textBox_InitialDialog.Text.Trim(),checkBox_WindowsAuthetication.Checked, this.textBox_UserLogin.Text.Trim(),this.textBox_UserPassword.Text.Trim());
            textBox_ConnectionString.Text = ConnectionParameters;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_lookXMLData_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.FileName = String.Empty;
            fileDialog.Filter = "File XML (*.xml)|*.xml|All files (*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_XMLdataSource.Text = fileDialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton_XML.Checked)
            {
                this.ConnectionParameters = this.textBox_XMLdataSource.Text.Trim();
                this.dataType = SourceType.XML;
            }
            
            else
            {

                if (this.checkBox_WindowsAuthetication.Checked)
                {
                    if(this.textBox_DataSource.Text.Trim() == String.Empty || this.textBox_InitialDialog.Text.Trim() == String.Empty)
                    {
                        MessageBox.Show("Заполните все поля");
                        return;
                    }
                }
                else if(this.textBox_DataSource.Text.Trim() == String.Empty || this.textBox_InitialDialog.Text.Trim() == String.Empty || 
                    this.textBox_UserLogin.Text.Trim() == "" || this.textBox_UserPassword.Text.Trim() == "")
                {
                    MessageBox.Show("Заполните все поля");
                    return;
                }
                ConnectionParameters = textBox_ConnectionString.Text.Trim();
                dataType = SourceType.SQL;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult !=DialogResult.OK)
                Application.Exit();
        }
    }
}
