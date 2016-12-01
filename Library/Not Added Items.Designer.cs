namespace Library
{
    partial class NotAddedMagazines
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
            this.dataGridView_notAddedItems = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_notAddedItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_notAddedItems
            // 
            this.dataGridView_notAddedItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_notAddedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_notAddedItems.Location = new System.Drawing.Point(0, 47);
            this.dataGridView_notAddedItems.Name = "dataGridView_notAddedItems";
            this.dataGridView_notAddedItems.Size = new System.Drawing.Size(593, 364);
            this.dataGridView_notAddedItems.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Элементы, которые были сохранены как копии:";
            // 
            // NotAddedMagazines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 411);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_notAddedItems);
            this.Name = "NotAddedMagazines";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Not Added Items";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_notAddedItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_notAddedItems;
        private System.Windows.Forms.Label label1;
    }
}