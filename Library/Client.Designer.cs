namespace Library
{
    partial class Client
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Books = new System.Windows.Forms.TabPage();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_BookAuthor = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_BookPublisher = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_BookName = new System.Windows.Forms.TextBox();
            this.dataGridView_Books = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_Books = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showAllCopiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Magazines_Articles = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox_Articles = new System.Windows.Forms.GroupBox();
            this.button_RefreshArticle = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_articleAuthor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_articlePublisher = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_articleName = new System.Windows.Forms.TextBox();
            this.dataGridView_Articles = new System.Windows.Forms.DataGridView();
            this.groupBox_Magazines = new System.Windows.Forms.GroupBox();
            this.button_RefreshMagazine = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_IssueNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Publisher = new System.Windows.Forms.TextBox();
            this.label_Name = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.dataGridView_Magazines = new System.Windows.Forms.DataGridView();
            this.label_Magazines = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeToXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.книгиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьКнигуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateSelectedBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.magazinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewMagazineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_UserName = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.Books.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Books)).BeginInit();
            this.contextMenuStrip_Books.SuspendLayout();
            this.Magazines_Articles.SuspendLayout();
            this.groupBox_Articles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Articles)).BeginInit();
            this.groupBox_Magazines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Magazines)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Books);
            this.tabControl1.Controls.Add(this.Magazines_Articles);
            this.tabControl1.Location = new System.Drawing.Point(15, 33);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1313, 741);
            this.tabControl1.TabIndex = 0;
            // 
            // Books
            // 
            this.Books.BackColor = System.Drawing.SystemColors.Control;
            this.Books.Controls.Add(this.button_Refresh);
            this.Books.Controls.Add(this.label9);
            this.Books.Controls.Add(this.textBox_BookAuthor);
            this.Books.Controls.Add(this.label11);
            this.Books.Controls.Add(this.textBox_BookPublisher);
            this.Books.Controls.Add(this.label12);
            this.Books.Controls.Add(this.textBox_BookName);
            this.Books.Controls.Add(this.dataGridView_Books);
            this.Books.Location = new System.Drawing.Point(4, 25);
            this.Books.Margin = new System.Windows.Forms.Padding(4);
            this.Books.Name = "Books";
            this.Books.Padding = new System.Windows.Forms.Padding(4);
            this.Books.Size = new System.Drawing.Size(1305, 712);
            this.Books.TabIndex = 0;
            this.Books.Text = "Books";
            // 
            // button_Refresh
            // 
            this.button_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Refresh.Location = new System.Drawing.Point(928, 27);
            this.button_Refresh.Margin = new System.Windows.Forms.Padding(4);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(113, 38);
            this.button_Refresh.TabIndex = 19;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.Button_Refresh_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(627, 19);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Author";
            // 
            // textBox_BookAuthor
            // 
            this.textBox_BookAuthor.Location = new System.Drawing.Point(605, 43);
            this.textBox_BookAuthor.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_BookAuthor.Name = "textBox_BookAuthor";
            this.textBox_BookAuthor.Size = new System.Drawing.Size(260, 22);
            this.textBox_BookAuthor.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(336, 18);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 20);
            this.label11.TabIndex = 14;
            this.label11.Text = "Publisher";
            // 
            // textBox_BookPublisher
            // 
            this.textBox_BookPublisher.Location = new System.Drawing.Point(325, 43);
            this.textBox_BookPublisher.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_BookPublisher.Name = "textBox_BookPublisher";
            this.textBox_BookPublisher.Size = new System.Drawing.Size(232, 22);
            this.textBox_BookPublisher.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(23, 18);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 20);
            this.label12.TabIndex = 12;
            this.label12.Text = "Name";
            // 
            // textBox_BookName
            // 
            this.textBox_BookName.Location = new System.Drawing.Point(24, 43);
            this.textBox_BookName.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_BookName.Name = "textBox_BookName";
            this.textBox_BookName.Size = new System.Drawing.Size(283, 22);
            this.textBox_BookName.TabIndex = 11;
            // 
            // dataGridView_Books
            // 
            this.dataGridView_Books.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Books.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Books.ContextMenuStrip = this.contextMenuStrip_Books;
            this.dataGridView_Books.Location = new System.Drawing.Point(19, 80);
            this.dataGridView_Books.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_Books.Name = "dataGridView_Books";
            this.dataGridView_Books.Size = new System.Drawing.Size(1252, 593);
            this.dataGridView_Books.TabIndex = 10;
            this.dataGridView_Books.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Books_CellMouseEnter);
            // 
            // contextMenuStrip_Books
            // 
            this.contextMenuStrip_Books.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip_Books.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllCopiesToolStripMenuItem});
            this.contextMenuStrip_Books.Name = "contextMenuStrip_Books";
            this.contextMenuStrip_Books.Size = new System.Drawing.Size(171, 28);
            // 
            // showAllCopiesToolStripMenuItem
            // 
            this.showAllCopiesToolStripMenuItem.Name = "showAllCopiesToolStripMenuItem";
            this.showAllCopiesToolStripMenuItem.Size = new System.Drawing.Size(170, 24);
            this.showAllCopiesToolStripMenuItem.Text = "&Выдать книгу";
            this.showAllCopiesToolStripMenuItem.Click += new System.EventHandler(this.ShowAllCopiesToolStripMenuItem_Click);
            // 
            // Magazines_Articles
            // 
            this.Magazines_Articles.BackColor = System.Drawing.SystemColors.Control;
            this.Magazines_Articles.Controls.Add(this.label4);
            this.Magazines_Articles.Controls.Add(this.groupBox_Articles);
            this.Magazines_Articles.Controls.Add(this.groupBox_Magazines);
            this.Magazines_Articles.Location = new System.Drawing.Point(4, 25);
            this.Magazines_Articles.Margin = new System.Windows.Forms.Padding(4);
            this.Magazines_Articles.Name = "Magazines_Articles";
            this.Magazines_Articles.Padding = new System.Windows.Forms.Padding(4);
            this.Magazines_Articles.Size = new System.Drawing.Size(1305, 712);
            this.Magazines_Articles.TabIndex = 1;
            this.Magazines_Articles.Text = "Magazines/Articles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 361);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Articles";
            // 
            // groupBox_Articles
            // 
            this.groupBox_Articles.Controls.Add(this.button_RefreshArticle);
            this.groupBox_Articles.Controls.Add(this.label5);
            this.groupBox_Articles.Controls.Add(this.textBox_articleAuthor);
            this.groupBox_Articles.Controls.Add(this.label7);
            this.groupBox_Articles.Controls.Add(this.textBox_articlePublisher);
            this.groupBox_Articles.Controls.Add(this.label8);
            this.groupBox_Articles.Controls.Add(this.textBox_articleName);
            this.groupBox_Articles.Controls.Add(this.dataGridView_Articles);
            this.groupBox_Articles.Location = new System.Drawing.Point(9, 400);
            this.groupBox_Articles.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Articles.Name = "groupBox_Articles";
            this.groupBox_Articles.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Articles.Size = new System.Drawing.Size(1268, 302);
            this.groupBox_Articles.TabIndex = 1;
            this.groupBox_Articles.TabStop = false;
            // 
            // button_RefreshArticle
            // 
            this.button_RefreshArticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_RefreshArticle.Location = new System.Drawing.Point(962, 16);
            this.button_RefreshArticle.Margin = new System.Windows.Forms.Padding(4);
            this.button_RefreshArticle.Name = "button_RefreshArticle";
            this.button_RefreshArticle.Size = new System.Drawing.Size(113, 38);
            this.button_RefreshArticle.TabIndex = 25;
            this.button_RefreshArticle.Text = "Refresh";
            this.button_RefreshArticle.UseVisualStyleBackColor = true;
            this.button_RefreshArticle.Click += new System.EventHandler(this.Button_RefreshArticle_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(619, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Author";
            // 
            // textBox_articleAuthor
            // 
            this.textBox_articleAuthor.Location = new System.Drawing.Point(612, 25);
            this.textBox_articleAuthor.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_articleAuthor.Name = "textBox_articleAuthor";
            this.textBox_articleAuthor.Size = new System.Drawing.Size(260, 22);
            this.textBox_articleAuthor.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(289, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Publisher";
            // 
            // textBox_articlePublisher
            // 
            this.textBox_articlePublisher.Location = new System.Drawing.Point(293, 25);
            this.textBox_articlePublisher.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_articlePublisher.Name = "textBox_articlePublisher";
            this.textBox_articlePublisher.Size = new System.Drawing.Size(236, 22);
            this.textBox_articlePublisher.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(32, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Name";
            // 
            // textBox_articleName
            // 
            this.textBox_articleName.Location = new System.Drawing.Point(33, 25);
            this.textBox_articleName.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_articleName.Name = "textBox_articleName";
            this.textBox_articleName.Size = new System.Drawing.Size(251, 22);
            this.textBox_articleName.TabIndex = 11;
            // 
            // dataGridView_Articles
            // 
            this.dataGridView_Articles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Articles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Articles.Location = new System.Drawing.Point(8, 62);
            this.dataGridView_Articles.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_Articles.Name = "dataGridView_Articles";
            this.dataGridView_Articles.Size = new System.Drawing.Size(1252, 231);
            this.dataGridView_Articles.TabIndex = 10;
            // 
            // groupBox_Magazines
            // 
            this.groupBox_Magazines.Controls.Add(this.button_RefreshMagazine);
            this.groupBox_Magazines.Controls.Add(this.label3);
            this.groupBox_Magazines.Controls.Add(this.textBox_IssueNumber);
            this.groupBox_Magazines.Controls.Add(this.label1);
            this.groupBox_Magazines.Controls.Add(this.textBox_Publisher);
            this.groupBox_Magazines.Controls.Add(this.label_Name);
            this.groupBox_Magazines.Controls.Add(this.textBox_Name);
            this.groupBox_Magazines.Controls.Add(this.dataGridView_Magazines);
            this.groupBox_Magazines.Controls.Add(this.label_Magazines);
            this.groupBox_Magazines.Location = new System.Drawing.Point(9, 9);
            this.groupBox_Magazines.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Magazines.Name = "groupBox_Magazines";
            this.groupBox_Magazines.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Magazines.Size = new System.Drawing.Size(1268, 336);
            this.groupBox_Magazines.TabIndex = 0;
            this.groupBox_Magazines.TabStop = false;
            // 
            // button_RefreshMagazine
            // 
            this.button_RefreshMagazine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_RefreshMagazine.Location = new System.Drawing.Point(962, 49);
            this.button_RefreshMagazine.Margin = new System.Windows.Forms.Padding(4);
            this.button_RefreshMagazine.Name = "button_RefreshMagazine";
            this.button_RefreshMagazine.Size = new System.Drawing.Size(113, 38);
            this.button_RefreshMagazine.TabIndex = 22;
            this.button_RefreshMagazine.Text = "Refresh";
            this.button_RefreshMagazine.UseVisualStyleBackColor = true;
            this.button_RefreshMagazine.Click += new System.EventHandler(this.Button_RefreshMagazine_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(619, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Issue Number";
            // 
            // textBox_IssueNumber
            // 
            this.textBox_IssueNumber.Location = new System.Drawing.Point(603, 62);
            this.textBox_IssueNumber.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_IssueNumber.Name = "textBox_IssueNumber";
            this.textBox_IssueNumber.Size = new System.Drawing.Size(260, 22);
            this.textBox_IssueNumber.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(289, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Publisher";
            // 
            // textBox_Publisher
            // 
            this.textBox_Publisher.Location = new System.Drawing.Point(293, 58);
            this.textBox_Publisher.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Publisher.Name = "textBox_Publisher";
            this.textBox_Publisher.Size = new System.Drawing.Size(236, 22);
            this.textBox_Publisher.TabIndex = 4;
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Name.Location = new System.Drawing.Point(32, 37);
            this.label_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(53, 20);
            this.label_Name.TabIndex = 3;
            this.label_Name.Text = "Name";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(33, 62);
            this.textBox_Name.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(251, 22);
            this.textBox_Name.TabIndex = 2;
            // 
            // dataGridView_Magazines
            // 
            this.dataGridView_Magazines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Magazines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Magazines.Location = new System.Drawing.Point(8, 97);
            this.dataGridView_Magazines.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_Magazines.Name = "dataGridView_Magazines";
            this.dataGridView_Magazines.Size = new System.Drawing.Size(1252, 231);
            this.dataGridView_Magazines.TabIndex = 1;
            // 
            // label_Magazines
            // 
            this.label_Magazines.AutoSize = true;
            this.label_Magazines.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Magazines.Location = new System.Drawing.Point(4, 2);
            this.label_Magazines.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Magazines.Name = "label_Magazines";
            this.label_Magazines.Size = new System.Drawing.Size(108, 25);
            this.label_Magazines.TabIndex = 0;
            this.label_Magazines.Text = "Magazines";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.книгиToolStripMenuItem,
            this.magazinesToolStripMenuItem,
            this.articlesToolStripMenuItem,
            this.usersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1347, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "fads";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeUserToolStripMenuItem,
            this.writeToXMLToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.файлToolStripMenuItem.Text = "&File";
            // 
            // changeUserToolStripMenuItem
            // 
            this.changeUserToolStripMenuItem.Name = "changeUserToolStripMenuItem";
            this.changeUserToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.changeUserToolStripMenuItem.Text = "&Change User";
            this.changeUserToolStripMenuItem.Click += new System.EventHandler(this.ChangeUserToolStripMenuItem_Click);
            // 
            // writeToXMLToolStripMenuItem
            // 
            this.writeToXMLToolStripMenuItem.Name = "writeToXMLToolStripMenuItem";
            this.writeToXMLToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.writeToXMLToolStripMenuItem.Text = "&Write to XML";
            this.writeToXMLToolStripMenuItem.Click += new System.EventHandler(this.WriteToXMLToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // книгиToolStripMenuItem
            // 
            this.книгиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьКнигуToolStripMenuItem,
            this.updateSelectedBookToolStripMenuItem});
            this.книгиToolStripMenuItem.Name = "книгиToolStripMenuItem";
            this.книгиToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.книгиToolStripMenuItem.Text = "&Book";
            // 
            // добавитьКнигуToolStripMenuItem
            // 
            this.добавитьКнигуToolStripMenuItem.Name = "добавитьКнигуToolStripMenuItem";
            this.добавитьКнигуToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.добавитьКнигуToolStripMenuItem.Text = "&Add New Book";
            this.добавитьКнигуToolStripMenuItem.Click += new System.EventHandler(this.добавитьКнигуToolStripMenuItem_Click);
            // 
            // updateSelectedBookToolStripMenuItem
            // 
            this.updateSelectedBookToolStripMenuItem.Name = "updateSelectedBookToolStripMenuItem";
            this.updateSelectedBookToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.updateSelectedBookToolStripMenuItem.Text = "&Update Selected Book";
            this.updateSelectedBookToolStripMenuItem.Click += new System.EventHandler(this.UpdateSelectedBookToolStripMenuItem_Click);
            // 
            // magazinesToolStripMenuItem
            // 
            this.magazinesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewMagazineToolStripMenuItem});
            this.magazinesToolStripMenuItem.Name = "magazinesToolStripMenuItem";
            this.magazinesToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.magazinesToolStripMenuItem.Text = "&Magazines";
            // 
            // addNewMagazineToolStripMenuItem
            // 
            this.addNewMagazineToolStripMenuItem.Name = "addNewMagazineToolStripMenuItem";
            this.addNewMagazineToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.addNewMagazineToolStripMenuItem.Text = "&Add New Magazine";
            this.addNewMagazineToolStripMenuItem.Click += new System.EventHandler(this.AddNewMagazineToolStripMenuItem_Click);
            // 
            // articlesToolStripMenuItem
            // 
            this.articlesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewArticleToolStripMenuItem});
            this.articlesToolStripMenuItem.Name = "articlesToolStripMenuItem";
            this.articlesToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.articlesToolStripMenuItem.Text = "&Articles";
            // 
            // addNewArticleToolStripMenuItem
            // 
            this.addNewArticleToolStripMenuItem.Name = "addNewArticleToolStripMenuItem";
            this.addNewArticleToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.addNewArticleToolStripMenuItem.Text = "&Add New Article";
            this.addNewArticleToolStripMenuItem.Click += new System.EventHandler(this.AddNewArticleToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllUsersToolStripMenuItem,
            this.createNewUserToolStripMenuItem});
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.usersToolStripMenuItem.Text = "&Users";
            // 
            // showAllUsersToolStripMenuItem
            // 
            this.showAllUsersToolStripMenuItem.Name = "showAllUsersToolStripMenuItem";
            this.showAllUsersToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.showAllUsersToolStripMenuItem.Text = "&Show All Users";
            this.showAllUsersToolStripMenuItem.Click += new System.EventHandler(this.ShowAllUsersToolStripMenuItem_Click);
            // 
            // createNewUserToolStripMenuItem
            // 
            this.createNewUserToolStripMenuItem.Name = "createNewUserToolStripMenuItem";
            this.createNewUserToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.createNewUserToolStripMenuItem.Text = "&Create New User";
            this.createNewUserToolStripMenuItem.Click += new System.EventHandler(this.createNewUserToolStripMenuItem_Click);
            // 
            // label_UserName
            // 
            this.label_UserName.AutoSize = true;
            this.label_UserName.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_UserName.Location = new System.Drawing.Point(1170, 28);
            this.label_UserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_UserName.Name = "label_UserName";
            this.label_UserName.Size = new System.Drawing.Size(177, 24);
            this.label_UserName.TabIndex = 2;
            this.label_UserName.Text = "Имя пользователя";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1347, 783);
            this.Controls.Add(this.label_UserName);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Client_Load);
            this.tabControl1.ResumeLayout(false);
            this.Books.ResumeLayout(false);
            this.Books.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Books)).EndInit();
            this.contextMenuStrip_Books.ResumeLayout(false);
            this.Magazines_Articles.ResumeLayout(false);
            this.Magazines_Articles.PerformLayout();
            this.groupBox_Articles.ResumeLayout(false);
            this.groupBox_Articles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Articles)).EndInit();
            this.groupBox_Magazines.ResumeLayout(false);
            this.groupBox_Magazines.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Magazines)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Books;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_BookAuthor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_BookPublisher;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_BookName;
        private System.Windows.Forms.DataGridView dataGridView_Books;
        private System.Windows.Forms.TabPage Magazines_Articles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox_Articles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_articleAuthor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_articlePublisher;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_articleName;
        private System.Windows.Forms.DataGridView dataGridView_Articles;
        private System.Windows.Forms.GroupBox groupBox_Magazines;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_IssueNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Publisher;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.DataGridView dataGridView_Magazines;
        private System.Windows.Forms.Label label_Magazines;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem книгиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьКнигуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateSelectedBookToolStripMenuItem;
        private System.Windows.Forms.Button button_RefreshMagazine;
        private System.Windows.Forms.Button button_RefreshArticle;
        private System.Windows.Forms.ToolStripMenuItem magazinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewMagazineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articlesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewArticleToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Books;
        private System.Windows.Forms.ToolStripMenuItem showAllCopiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewUserToolStripMenuItem;
        private System.Windows.Forms.Label label_UserName;
        private System.Windows.Forms.ToolStripMenuItem changeUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeToXMLToolStripMenuItem;
    }
}

