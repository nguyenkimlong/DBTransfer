namespace TestFormDB
{
    partial class FrmConnect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConnect));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtUsernameDsc = new System.Windows.Forms.TextBox();
            this.txtserverDsc = new System.Windows.Forms.TextBox();
            this.rbtnuserWindowDsc = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.rbtnuserServerDsc = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPasswordDsc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRefreshDsc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbDatabaseDsc = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtuserSrc = new System.Windows.Forms.TextBox();
            this.txtserverSrc = new System.Windows.Forms.TextBox();
            this.rdbwindowSrc = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbServeSrc = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtpassSrc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRefreshSrc = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbbdataSrc = new System.Windows.Forms.ComboBox();
            this.btnsaveDsc = new System.Windows.Forms.Button();
            this.btnsaveSrc = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(620, 385);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.btnsaveSrc);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(612, 359);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data Source";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.btnsaveDsc);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(612, 359);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Data Destination ";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtUsernameDsc);
            this.panel2.Controls.Add(this.txtserverDsc);
            this.panel2.Controls.Add(this.rbtnuserWindowDsc);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.rbtnuserServerDsc);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtPasswordDsc);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnRefreshDsc);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbbDatabaseDsc);
            this.panel2.Location = new System.Drawing.Point(24, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(538, 203);
            this.panel2.TabIndex = 39;
            // 
            // txtUsernameDsc
            // 
            this.txtUsernameDsc.Location = new System.Drawing.Point(194, 112);
            this.txtUsernameDsc.Name = "txtUsernameDsc";
            this.txtUsernameDsc.Size = new System.Drawing.Size(241, 20);
            this.txtUsernameDsc.TabIndex = 25;
            // 
            // txtserverDsc
            // 
            this.txtserverDsc.Location = new System.Drawing.Point(194, 24);
            this.txtserverDsc.Name = "txtserverDsc";
            this.txtserverDsc.Size = new System.Drawing.Size(240, 20);
            this.txtserverDsc.TabIndex = 21;
            // 
            // rbtnuserWindowDsc
            // 
            this.rbtnuserWindowDsc.AutoSize = true;
            this.rbtnuserWindowDsc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnuserWindowDsc.Location = new System.Drawing.Point(121, 60);
            this.rbtnuserWindowDsc.Name = "rbtnuserWindowDsc";
            this.rbtnuserWindowDsc.Size = new System.Drawing.Size(183, 19);
            this.rbtnuserWindowDsc.TabIndex = 22;
            this.rbtnuserWindowDsc.Text = "Use Windows  Authentication";
            this.rbtnuserWindowDsc.UseVisualStyleBackColor = true;
            this.rbtnuserWindowDsc.CheckedChanged += new System.EventHandler(this.rbtnuserWindowDsc_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(118, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 15);
            this.label5.TabIndex = 31;
            this.label5.Text = "UserName:";
            // 
            // rbtnuserServerDsc
            // 
            this.rbtnuserServerDsc.AutoSize = true;
            this.rbtnuserServerDsc.Checked = true;
            this.rbtnuserServerDsc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnuserServerDsc.Location = new System.Drawing.Point(121, 83);
            this.rbtnuserServerDsc.Name = "rbtnuserServerDsc";
            this.rbtnuserServerDsc.Size = new System.Drawing.Size(192, 19);
            this.rbtnuserServerDsc.TabIndex = 23;
            this.rbtnuserServerDsc.TabStop = true;
            this.rbtnuserServerDsc.Text = "Use SQL Server Authentication";
            this.rbtnuserServerDsc.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(118, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "Password:";
            // 
            // txtPasswordDsc
            // 
            this.txtPasswordDsc.Location = new System.Drawing.Point(193, 138);
            this.txtPasswordDsc.Name = "txtPasswordDsc";
            this.txtPasswordDsc.Size = new System.Drawing.Size(242, 20);
            this.txtPasswordDsc.TabIndex = 24;
            this.txtPasswordDsc.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(118, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 29;
            this.label3.Text = "Database:";
            // 
            // btnRefreshDsc
            // 
            this.btnRefreshDsc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefreshDsc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshDsc.Location = new System.Drawing.Point(359, 164);
            this.btnRefreshDsc.Name = "btnRefreshDsc";
            this.btnRefreshDsc.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshDsc.TabIndex = 26;
            this.btnRefreshDsc.Text = "Refresh";
            this.btnRefreshDsc.UseVisualStyleBackColor = true;
            this.btnRefreshDsc.Click += new System.EventHandler(this.btnRefreshDsc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(118, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 28;
            this.label1.Text = "Server: ";
            // 
            // cbbDatabaseDsc
            // 
            this.cbbDatabaseDsc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDatabaseDsc.FormattingEnabled = true;
            this.cbbDatabaseDsc.Location = new System.Drawing.Point(194, 164);
            this.cbbDatabaseDsc.Name = "cbbDatabaseDsc";
            this.cbbDatabaseDsc.Size = new System.Drawing.Size(159, 21);
            this.cbbDatabaseDsc.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtuserSrc);
            this.panel1.Controls.Add(this.txtserverSrc);
            this.panel1.Controls.Add(this.rdbwindowSrc);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rdbServeSrc);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtpassSrc);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnRefreshSrc);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cbbdataSrc);
            this.panel1.Location = new System.Drawing.Point(24, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 203);
            this.panel1.TabIndex = 40;
            // 
            // txtuserSrc
            // 
            this.txtuserSrc.Location = new System.Drawing.Point(194, 112);
            this.txtuserSrc.Name = "txtuserSrc";
            this.txtuserSrc.Size = new System.Drawing.Size(241, 20);
            this.txtuserSrc.TabIndex = 25;
            // 
            // txtserverSrc
            // 
            this.txtserverSrc.Location = new System.Drawing.Point(194, 24);
            this.txtserverSrc.Name = "txtserverSrc";
            this.txtserverSrc.Size = new System.Drawing.Size(240, 20);
            this.txtserverSrc.TabIndex = 21;
            // 
            // rdbwindowSrc
            // 
            this.rdbwindowSrc.AutoSize = true;
            this.rdbwindowSrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbwindowSrc.Location = new System.Drawing.Point(121, 60);
            this.rdbwindowSrc.Name = "rdbwindowSrc";
            this.rdbwindowSrc.Size = new System.Drawing.Size(183, 19);
            this.rdbwindowSrc.TabIndex = 22;
            this.rdbwindowSrc.Text = "Use Windows  Authentication";
            this.rdbwindowSrc.UseVisualStyleBackColor = true;
            this.rdbwindowSrc.CheckedChanged += new System.EventHandler(this.rdbwindowSrc_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(118, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 31;
            this.label2.Text = "UserName:";
            // 
            // rdbServeSrc
            // 
            this.rdbServeSrc.AutoSize = true;
            this.rdbServeSrc.Checked = true;
            this.rdbServeSrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbServeSrc.Location = new System.Drawing.Point(121, 83);
            this.rdbServeSrc.Name = "rdbServeSrc";
            this.rdbServeSrc.Size = new System.Drawing.Size(192, 19);
            this.rdbServeSrc.TabIndex = 23;
            this.rdbServeSrc.TabStop = true;
            this.rdbServeSrc.Text = "Use SQL Server Authentication";
            this.rdbServeSrc.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(118, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 15);
            this.label6.TabIndex = 30;
            this.label6.Text = "Password:";
            // 
            // txtpassSrc
            // 
            this.txtpassSrc.Location = new System.Drawing.Point(193, 138);
            this.txtpassSrc.Name = "txtpassSrc";
            this.txtpassSrc.Size = new System.Drawing.Size(242, 20);
            this.txtpassSrc.TabIndex = 24;
            this.txtpassSrc.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(118, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 15);
            this.label7.TabIndex = 29;
            this.label7.Text = "Database:";
            // 
            // btnRefreshSrc
            // 
            this.btnRefreshSrc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefreshSrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshSrc.Location = new System.Drawing.Point(359, 164);
            this.btnRefreshSrc.Name = "btnRefreshSrc";
            this.btnRefreshSrc.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshSrc.TabIndex = 26;
            this.btnRefreshSrc.Text = "Refresh";
            this.btnRefreshSrc.UseVisualStyleBackColor = true;
            this.btnRefreshSrc.Click += new System.EventHandler(this.btnRefreshSrc_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(118, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 15);
            this.label8.TabIndex = 28;
            this.label8.Text = "Server: ";
            // 
            // cbbdataSrc
            // 
            this.cbbdataSrc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbdataSrc.FormattingEnabled = true;
            this.cbbdataSrc.Location = new System.Drawing.Point(194, 164);
            this.cbbdataSrc.Name = "cbbdataSrc";
            this.cbbdataSrc.Size = new System.Drawing.Size(159, 21);
            this.cbbdataSrc.TabIndex = 27;
            // 
            // btnsaveDsc
            // 
            this.btnsaveDsc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnsaveDsc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsaveDsc.Location = new System.Drawing.Point(477, 309);
            this.btnsaveDsc.Name = "btnsaveDsc";
            this.btnsaveDsc.Size = new System.Drawing.Size(85, 24);
            this.btnsaveDsc.TabIndex = 40;
            this.btnsaveDsc.Text = "Save";
            this.btnsaveDsc.UseVisualStyleBackColor = true;
            this.btnsaveDsc.Click += new System.EventHandler(this.btnsaveDsc_Click);
            // 
            // btnsaveSrc
            // 
            this.btnsaveSrc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnsaveSrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsaveSrc.Location = new System.Drawing.Point(477, 309);
            this.btnsaveSrc.Name = "btnsaveSrc";
            this.btnsaveSrc.Size = new System.Drawing.Size(85, 24);
            this.btnsaveSrc.TabIndex = 41;
            this.btnsaveSrc.Text = "Save";
            this.btnsaveSrc.UseVisualStyleBackColor = true;
            this.btnsaveSrc.Click += new System.EventHandler(this.btnsaveSrc_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(606, 77);
            this.panel3.TabIndex = 42;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TestFormDB.Properties.Resources.sql;
            this.pictureBox1.Location = new System.Drawing.Point(514, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(52, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(197, 17);
            this.label9.TabIndex = 12;
            this.label9.Text = "Select a Source Database";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(606, 77);
            this.panel4.TabIndex = 43;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TestFormDB.Properties.Resources.sql;
            this.pictureBox2.Location = new System.Drawing.Point(514, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(87, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(52, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(228, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "Select a Destination Database";
            // 
            // FrmConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 385);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConnect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect Database";
            this.Load += new System.EventHandler(this.FrmConnect_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtUsernameDsc;
        private System.Windows.Forms.TextBox txtserverDsc;
        private System.Windows.Forms.RadioButton rbtnuserWindowDsc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbtnuserServerDsc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPasswordDsc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefreshDsc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbDatabaseDsc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtuserSrc;
        private System.Windows.Forms.TextBox txtserverSrc;
        private System.Windows.Forms.RadioButton rdbwindowSrc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdbServeSrc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtpassSrc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRefreshSrc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbbdataSrc;
        private System.Windows.Forms.Button btnsaveDsc;
        private System.Windows.Forms.Button btnsaveSrc;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label10;
    }
}