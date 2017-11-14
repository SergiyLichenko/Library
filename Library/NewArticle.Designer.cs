namespace Library
{
    partial class NewArticle
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
            this.label_ArticlesCount = new System.Windows.Forms.Label();
            this.button_AddArticle = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_SaveArticle = new System.Windows.Forms.Button();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_PublishedDate = new System.Windows.Forms.DateTimePicker();
            this.textBox_Publisher = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.textBox_Version = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_AuthorName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox_MagazineName = new System.Windows.Forms.ListBox();
            this.listBox_MagazineIssueNumber = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_ArticlesCount
            // 
            this.label_ArticlesCount.AutoSize = true;
            this.label_ArticlesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_ArticlesCount.Location = new System.Drawing.Point(431, 526);
            this.label_ArticlesCount.Name = "label_ArticlesCount";
            this.label_ArticlesCount.Size = new System.Drawing.Size(102, 17);
            this.label_ArticlesCount.TabIndex = 37;
            this.label_ArticlesCount.Text = "Новых статей:";
            // 
            // button_AddArticle
            // 
            this.button_AddArticle.Location = new System.Drawing.Point(280, 522);
            this.button_AddArticle.Name = "button_AddArticle";
            this.button_AddArticle.Size = new System.Drawing.Size(92, 25);
            this.button_AddArticle.TabIndex = 36;
            this.button_AddArticle.Text = "Add Article";
            this.button_AddArticle.UseVisualStyleBackColor = true;
            this.button_AddArticle.Click += new System.EventHandler(this.Button_AddArticle_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Cancel.Location = new System.Drawing.Point(560, 589);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(80, 29);
            this.button_Cancel.TabIndex = 35;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // button_SaveArticle
            // 
            this.button_SaveArticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_SaveArticle.Location = new System.Drawing.Point(413, 582);
            this.button_SaveArticle.Name = "button_SaveArticle";
            this.button_SaveArticle.Size = new System.Drawing.Size(120, 42);
            this.button_SaveArticle.TabIndex = 34;
            this.button_SaveArticle.Text = "Save Articles";
            this.button_SaveArticle.UseVisualStyleBackColor = true;
            this.button_SaveArticle.Click += new System.EventHandler(this.button_SaveArticle_Click);
            // 
            // textBox_Name
            // 
            this.textBox_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Name.Location = new System.Drawing.Point(236, 74);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(311, 23);
            this.textBox_Name.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(98, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "Article Name";
            // 
            // dateTimePicker_PublishedDate
            // 
            this.dateTimePicker_PublishedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker_PublishedDate.Location = new System.Drawing.Point(236, 162);
            this.dateTimePicker_PublishedDate.Name = "dateTimePicker_PublishedDate";
            this.dateTimePicker_PublishedDate.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker_PublishedDate.TabIndex = 29;
            // 
            // textBox_Publisher
            // 
            this.textBox_Publisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Publisher.Location = new System.Drawing.Point(236, 121);
            this.textBox_Publisher.Name = "textBox_Publisher";
            this.textBox_Publisher.Size = new System.Drawing.Size(311, 23);
            this.textBox_Publisher.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(83, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 18);
            this.label6.TabIndex = 27;
            this.label6.Text = "Published Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(121, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 18);
            this.label5.TabIndex = 26;
            this.label5.Text = "Publisher";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(145, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 18);
            this.label4.TabIndex = 25;
            this.label4.Text = "ID";
            // 
            // textBox_ID
            // 
            this.textBox_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_ID.Location = new System.Drawing.Point(195, 12);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.ReadOnly = true;
            this.textBox_ID.Size = new System.Drawing.Size(311, 23);
            this.textBox_ID.TabIndex = 24;
            // 
            // textBox_Version
            // 
            this.textBox_Version.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Version.Location = new System.Drawing.Point(236, 198);
            this.textBox_Version.Name = "textBox_Version";
            this.textBox_Version.Size = new System.Drawing.Size(311, 23);
            this.textBox_Version.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(132, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 18);
            this.label2.TabIndex = 38;
            this.label2.Text = "Version";
            // 
            // textBox_AuthorName
            // 
            this.textBox_AuthorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_AuthorName.Location = new System.Drawing.Point(236, 233);
            this.textBox_AuthorName.Name = "textBox_AuthorName";
            this.textBox_AuthorName.Size = new System.Drawing.Size(311, 23);
            this.textBox_AuthorName.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(95, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 18);
            this.label3.TabIndex = 40;
            this.label3.Text = "Author Name";
            this.label3.UseWaitCursor = true;
            // 
            // listBox_MagazineName
            // 
            this.listBox_MagazineName.FormattingEnabled = true;
            this.listBox_MagazineName.Location = new System.Drawing.Point(236, 277);
            this.listBox_MagazineName.Name = "listBox_MagazineName";
            this.listBox_MagazineName.Size = new System.Drawing.Size(311, 95);
            this.listBox_MagazineName.TabIndex = 42;
            this.listBox_MagazineName.SelectedIndexChanged += new System.EventHandler(this.ListBox_MagazineName_SelectedIndexChanged);
            // 
            // listBox_MagazineIssueNumber
            // 
            this.listBox_MagazineIssueNumber.FormattingEnabled = true;
            this.listBox_MagazineIssueNumber.Location = new System.Drawing.Point(236, 396);
            this.listBox_MagazineIssueNumber.Name = "listBox_MagazineIssueNumber";
            this.listBox_MagazineIssueNumber.Size = new System.Drawing.Size(311, 95);
            this.listBox_MagazineIssueNumber.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(74, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 18);
            this.label7.TabIndex = 44;
            this.label7.Text = "Magazine Name";
            this.label7.UseWaitCursor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(22, 420);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(168, 18);
            this.label8.TabIndex = 45;
            this.label8.Text = "Magazine Issue Number";
            this.label8.UseWaitCursor = true;
            // 
            // NewArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 653);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listBox_MagazineIssueNumber);
            this.Controls.Add(this.listBox_MagazineName);
            this.Controls.Add(this.textBox_AuthorName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Version);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_ArticlesCount);
            this.Controls.Add(this.button_AddArticle);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_SaveArticle);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker_PublishedDate);
            this.Controls.Add(this.textBox_Publisher);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_ID);
            this.Name = "NewArticle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewArticle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ArticlesCount;
        private System.Windows.Forms.Button button_AddArticle;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_SaveArticle;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_PublishedDate;
        private System.Windows.Forms.TextBox textBox_Publisher;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.TextBox textBox_Version;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_AuthorName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox_MagazineName;
        private System.Windows.Forms.ListBox listBox_MagazineIssueNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}