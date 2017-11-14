namespace Library
{
    partial class BooksCancelation
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
            this.dataGridView_Users = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button_CancelBook = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView_Copies = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_PublishedDateOrigin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_NameOrigin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_PublisherOrigin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_AuthorOrigin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Users)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Copies)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_Users
            // 
            this.dataGridView_Users.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Users.Location = new System.Drawing.Point(16, 53);
            this.dataGridView_Users.Name = "dataGridView_Users";
            this.dataGridView_Users.ReadOnly = true;
            this.dataGridView_Users.Size = new System.Drawing.Size(914, 181);
            this.dataGridView_Users.TabIndex = 0;
            this.dataGridView_Users.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Users_CellClick);
            this.dataGridView_Users.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Users_CellMouseEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите пользователя:";
            // 
            // button_CancelBook
            // 
            this.button_CancelBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_CancelBook.Location = new System.Drawing.Point(560, 507);
            this.button_CancelBook.Name = "button_CancelBook";
            this.button_CancelBook.Size = new System.Drawing.Size(128, 41);
            this.button_CancelBook.TabIndex = 4;
            this.button_CancelBook.Text = "Списать книгу";
            this.button_CancelBook.UseVisualStyleBackColor = true;
            this.button_CancelBook.Click += new System.EventHandler(this.Button_CancelBook_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView_Users);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(947, 263);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // dataGridView_Copies
            // 
            this.dataGridView_Copies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Copies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Copies.Location = new System.Drawing.Point(494, 315);
            this.dataGridView_Copies.Name = "dataGridView_Copies";
            this.dataGridView_Copies.ReadOnly = true;
            this.dataGridView_Copies.Size = new System.Drawing.Size(454, 178);
            this.dataGridView_Copies.TabIndex = 6;
            this.dataGridView_Copies.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Copies_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(512, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Задолженности:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_PublishedDateOrigin);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox_NameOrigin);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_PublisherOrigin);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_AuthorOrigin);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 281);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 267);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // textBox_PublishedDateOrigin
            // 
            this.textBox_PublishedDateOrigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_PublishedDateOrigin.Location = new System.Drawing.Point(126, 196);
            this.textBox_PublishedDateOrigin.Name = "textBox_PublishedDateOrigin";
            this.textBox_PublishedDateOrigin.ReadOnly = true;
            this.textBox_PublishedDateOrigin.Size = new System.Drawing.Size(311, 23);
            this.textBox_PublishedDateOrigin.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(137, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "Выбранная книга";
            // 
            // textBox_NameOrigin
            // 
            this.textBox_NameOrigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_NameOrigin.Location = new System.Drawing.Point(126, 85);
            this.textBox_NameOrigin.Name = "textBox_NameOrigin";
            this.textBox_NameOrigin.ReadOnly = true;
            this.textBox_NameOrigin.Size = new System.Drawing.Size(311, 23);
            this.textBox_NameOrigin.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(33, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Book Name";
            // 
            // textBox_PublisherOrigin
            // 
            this.textBox_PublisherOrigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_PublisherOrigin.Location = new System.Drawing.Point(126, 159);
            this.textBox_PublisherOrigin.Name = "textBox_PublisherOrigin";
            this.textBox_PublisherOrigin.ReadOnly = true;
            this.textBox_PublisherOrigin.Size = new System.Drawing.Size(311, 23);
            this.textBox_PublisherOrigin.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(56, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "Author";
            // 
            // textBox_AuthorOrigin
            // 
            this.textBox_AuthorOrigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_AuthorOrigin.Location = new System.Drawing.Point(126, 122);
            this.textBox_AuthorOrigin.Name = "textBox_AuthorOrigin";
            this.textBox_AuthorOrigin.ReadOnly = true;
            this.textBox_AuthorOrigin.Size = new System.Drawing.Size(311, 23);
            this.textBox_AuthorOrigin.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(44, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "Publisher";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(15, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 18);
            this.label7.TabIndex = 15;
            this.label7.Text = "Published Date";
            // 
            // BooksCancelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 580);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView_Copies);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_CancelBook);
            this.Name = "BooksCancelation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BooksCancelation";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Users)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Copies)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Users;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_CancelBook;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView_Copies;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_PublishedDateOrigin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_NameOrigin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_PublisherOrigin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_AuthorOrigin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}