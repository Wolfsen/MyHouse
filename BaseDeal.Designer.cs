namespace MyHouse
{
    partial class BaseDeal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butDeal = new System.Windows.Forms.Button();
            this.butFilter = new System.Windows.Forms.Button();
            this.butBack = new System.Windows.Forms.Button();
            this.butPrint = new System.Windows.Forms.Button();
            this.dgvDeal = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeal)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MyHouse.Properties.Resources.doprovojd;
            this.pictureBox1.Location = new System.Drawing.Point(12, 234);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 22F);
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(5, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 116);
            this.label1.TabIndex = 26;
            this.label1.Text = "База заключенных сделок";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butDeal
            // 
            this.butDeal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.butDeal.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.butDeal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDeal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butDeal.ForeColor = System.Drawing.Color.White;
            this.butDeal.Location = new System.Drawing.Point(218, 114);
            this.butDeal.Name = "butDeal";
            this.butDeal.Size = new System.Drawing.Size(150, 36);
            this.butDeal.TabIndex = 28;
            this.butDeal.Text = "Заключить сделку";
            this.butDeal.UseVisualStyleBackColor = false;
            this.butDeal.Click += new System.EventHandler(this.butDeal_Click);
            // 
            // butFilter
            // 
            this.butFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.butFilter.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.butFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butFilter.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butFilter.ForeColor = System.Drawing.Color.White;
            this.butFilter.Location = new System.Drawing.Point(603, 114);
            this.butFilter.Name = "butFilter";
            this.butFilter.Size = new System.Drawing.Size(89, 36);
            this.butFilter.TabIndex = 29;
            this.butFilter.Text = "Фильтр";
            this.butFilter.UseVisualStyleBackColor = false;
            // 
            // butBack
            // 
            this.butBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.butBack.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.butBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butBack.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butBack.ForeColor = System.Drawing.Color.White;
            this.butBack.Location = new System.Drawing.Point(793, 114);
            this.butBack.Name = "butBack";
            this.butBack.Size = new System.Drawing.Size(89, 36);
            this.butBack.TabIndex = 30;
            this.butBack.Text = "Назад";
            this.butBack.UseVisualStyleBackColor = false;
            this.butBack.Click += new System.EventHandler(this.butBack_Click);
            // 
            // butPrint
            // 
            this.butPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.butPrint.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.butPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butPrint.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butPrint.ForeColor = System.Drawing.Color.White;
            this.butPrint.Location = new System.Drawing.Point(698, 114);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(89, 36);
            this.butPrint.TabIndex = 31;
            this.butPrint.Text = "Печать";
            this.butPrint.UseVisualStyleBackColor = false;
            // 
            // dgvDeal
            // 
            this.dgvDeal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDeal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDeal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvDeal.Location = new System.Drawing.Point(218, 170);
            this.dgvDeal.Name = "dgvDeal";
            this.dgvDeal.RowHeadersVisible = false;
            this.dgvDeal.Size = new System.Drawing.Size(664, 230);
            this.dgvDeal.TabIndex = 32;
            // 
            // Column1
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column1.HeaderText = "Вид недвижимости";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column2.HeaderText = "Вид сделки";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Column3.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column3.HeaderText = "Стоимость";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Column4.DefaultCellStyle = dataGridViewCellStyle11;
            this.Column4.HeaderText = "Дата";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Column5.DefaultCellStyle = dataGridViewCellStyle12;
            this.Column5.HeaderText = "Клиент";
            this.Column5.Name = "Column5";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(486, 130);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(111, 20);
            this.dateTimePickerTo.TabIndex = 38;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(374, 130);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(111, 20);
            this.dateTimePickerFrom.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.label4.Font = new System.Drawing.Font("Calibri", 12F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(374, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 19);
            this.label4.TabIndex = 36;
            this.label4.Text = "Дата от";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.label3.Font = new System.Drawing.Font("Calibri", 12F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(486, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 19);
            this.label3.TabIndex = 35;
            this.label3.Text = "Дата до";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BaseDeal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MyHouse.Properties.Resources.Фон;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(899, 412);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvDeal);
            this.Controls.Add(this.butPrint);
            this.Controls.Add(this.butBack);
            this.Controls.Add(this.butFilter);
            this.Controls.Add(this.butDeal);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "BaseDeal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaseDeal";
            this.Load += new System.EventHandler(this.BaseDeal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butDeal;
        private System.Windows.Forms.Button butFilter;
        private System.Windows.Forms.Button butBack;
        private System.Windows.Forms.Button butPrint;
        private System.Windows.Forms.DataGridView dgvDeal;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}