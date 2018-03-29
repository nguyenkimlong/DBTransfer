namespace TestFormDB.Update_Data
{
    partial class FrmEditDataImport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnCapNhatGia = new System.Windows.Forms.Button();
            this.btnDanhsoCtu = new System.Windows.Forms.Button();
            this.txtLoChungTu = new System.Windows.Forms.TextBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnCapnhat = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblsodong = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chkngaychungtu = new System.Windows.Forms.CheckBox();
            this.chklo = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chklo);
            this.panel1.Controls.Add(this.chkngaychungtu);
            this.panel1.Controls.Add(this.btnLoc);
            this.panel1.Controls.Add(this.btnCapNhatGia);
            this.panel1.Controls.Add(this.btnDanhsoCtu);
            this.panel1.Controls.Add(this.txtLoChungTu);
            this.panel1.Controls.Add(this.dtpToDate);
            this.panel1.Controls.Add(this.dtpFromDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 141);
            this.panel1.TabIndex = 0;
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoc.Location = new System.Drawing.Point(703, 59);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(100, 25);
            this.btnLoc.TabIndex = 8;
            this.btnLoc.Text = "Lọc dữ liệu";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // btnCapNhatGia
            // 
            this.btnCapNhatGia.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCapNhatGia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCapNhatGia.Location = new System.Drawing.Point(471, 96);
            this.btnCapNhatGia.Name = "btnCapNhatGia";
            this.btnCapNhatGia.Size = new System.Drawing.Size(197, 33);
            this.btnCapNhatGia.TabIndex = 7;
            this.btnCapNhatGia.Text = "Cập nhật giá theo danh mục";
            this.btnCapNhatGia.UseVisualStyleBackColor = false;
            this.btnCapNhatGia.Click += new System.EventHandler(this.btnCapNhatGia_Click);
            // 
            // btnDanhsoCtu
            // 
            this.btnDanhsoCtu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDanhsoCtu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDanhsoCtu.Location = new System.Drawing.Point(268, 96);
            this.btnDanhsoCtu.Name = "btnDanhsoCtu";
            this.btnDanhsoCtu.Size = new System.Drawing.Size(197, 33);
            this.btnDanhsoCtu.TabIndex = 6;
            this.btnDanhsoCtu.Text = "Đánh lại số chứng từ";
            this.btnDanhsoCtu.UseVisualStyleBackColor = false;
            this.btnDanhsoCtu.Click += new System.EventHandler(this.btnDanhsoCtu_Click);
            // 
            // txtLoChungTu
            // 
            this.txtLoChungTu.Enabled = false;
            this.txtLoChungTu.Location = new System.Drawing.Point(268, 61);
            this.txtLoChungTu.Name = "txtLoChungTu";
            this.txtLoChungTu.Size = new System.Drawing.Size(400, 23);
            this.txtLoChungTu.TabIndex = 5;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Enabled = false;
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(542, 35);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(126, 23);
            this.dtpToDate.TabIndex = 4;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Enabled = false;
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(268, 35);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(126, 23);
            this.dtpFromDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đến ngày:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnHuy);
            this.panel3.Controls.Add(this.btnCapnhat);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 484);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1004, 41);
            this.panel3.TabIndex = 2;
            // 
            // btnHuy
            // 
            this.btnHuy.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHuy.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnHuy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnHuy.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnHuy.Location = new System.Drawing.Point(851, 9);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(90, 23);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnCapnhat
            // 
            this.btnCapnhat.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCapnhat.FlatAppearance.BorderSize = 2;
            this.btnCapnhat.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnCapnhat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCapnhat.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnCapnhat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCapnhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapnhat.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCapnhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapnhat.Location = new System.Drawing.Point(759, 9);
            this.btnCapnhat.Name = "btnCapnhat";
            this.btnCapnhat.Size = new System.Drawing.Size(88, 23);
            this.btnCapnhat.TabIndex = 0;
            this.btnCapnhat.Text = "Cập nhật";
            this.btnCapnhat.UseVisualStyleBackColor = true;
            this.btnCapnhat.Click += new System.EventHandler(this.btnCapnhat_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblsodong);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 443);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1004, 41);
            this.panel4.TabIndex = 3;
            // 
            // lblsodong
            // 
            this.lblsodong.AutoSize = true;
            this.lblsodong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsodong.Location = new System.Drawing.Point(92, 15);
            this.lblsodong.Name = "lblsodong";
            this.lblsodong.Size = new System.Drawing.Size(0, 13);
            this.lblsodong.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Số dòng = ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 141);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1004, 302);
            this.panel2.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1004, 302);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(996, 276);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(996, 276);
            this.dataGridView1.TabIndex = 0;
            // 
            // chkngaychungtu
            // 
            this.chkngaychungtu.AutoSize = true;
            this.chkngaychungtu.Location = new System.Drawing.Point(146, 37);
            this.chkngaychungtu.Name = "chkngaychungtu";
            this.chkngaychungtu.Size = new System.Drawing.Size(119, 21);
            this.chkngaychungtu.TabIndex = 9;
            this.chkngaychungtu.Text = "Ngày chứng từ";
            this.chkngaychungtu.UseVisualStyleBackColor = true;
            this.chkngaychungtu.CheckedChanged += new System.EventHandler(this.chkngaychungtu_CheckedChanged);
            // 
            // chklo
            // 
            this.chklo.AutoSize = true;
            this.chklo.Location = new System.Drawing.Point(146, 64);
            this.chklo.Name = "chklo";
            this.chklo.Size = new System.Drawing.Size(102, 21);
            this.chklo.TabIndex = 10;
            this.chklo.Text = "Lô chứng từ";
            this.chklo.UseVisualStyleBackColor = true;
            this.chklo.CheckedChanged += new System.EventHandler(this.chklo_CheckedChanged);
            // 
            // FrmEditDataImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 525);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditDataImport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật dữ liệu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEditDataImport_FormClosing);
            this.Load += new System.EventHandler(this.FrmEditDataImport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtLoChungTu;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnCapNhatGia;
        private System.Windows.Forms.Button btnDanhsoCtu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblsodong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnCapnhat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox chklo;
        private System.Windows.Forms.CheckBox chkngaychungtu;
    }
}