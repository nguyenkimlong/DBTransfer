namespace TestFormDB
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdbtnUpdate = new System.Windows.Forms.RadioButton();
            this.rdbtnExport = new System.Windows.Forms.RadioButton();
            this.rdbtnImport = new System.Windows.Forms.RadioButton();
            this.rdbtnTransfer = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnthietlap = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(696, 331);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.rdbtnUpdate);
            this.panel3.Controls.Add(this.rdbtnExport);
            this.panel3.Controls.Add(this.rdbtnImport);
            this.panel3.Controls.Add(this.rdbtnTransfer);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(222, 110);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(422, 216);
            this.panel3.TabIndex = 7;
            // 
            // rdbtnUpdate
            // 
            this.rdbtnUpdate.AutoSize = true;
            this.rdbtnUpdate.Location = new System.Drawing.Point(9, 164);
            this.rdbtnUpdate.Name = "rdbtnUpdate";
            this.rdbtnUpdate.Size = new System.Drawing.Size(145, 19);
            this.rdbtnUpdate.TabIndex = 7;
            this.rdbtnUpdate.TabStop = true;
            this.rdbtnUpdate.Text = "Update Temp Data";
            this.rdbtnUpdate.UseVisualStyleBackColor = true;
            // 
            // rdbtnExport
            // 
            this.rdbtnExport.AutoSize = true;
            this.rdbtnExport.Location = new System.Drawing.Point(9, 65);
            this.rdbtnExport.Name = "rdbtnExport";
            this.rdbtnExport.Size = new System.Drawing.Size(160, 19);
            this.rdbtnExport.TabIndex = 5;
            this.rdbtnExport.TabStop = true;
            this.rdbtnExport.Text = "Export Data To Temp";
            this.rdbtnExport.UseVisualStyleBackColor = true;
            // 
            // rdbtnImport
            // 
            this.rdbtnImport.AutoSize = true;
            this.rdbtnImport.Location = new System.Drawing.Point(9, 114);
            this.rdbtnImport.Name = "rdbtnImport";
            this.rdbtnImport.Size = new System.Drawing.Size(177, 19);
            this.rdbtnImport.TabIndex = 6;
            this.rdbtnImport.TabStop = true;
            this.rdbtnImport.Text = "Import From Temp Data";
            this.rdbtnImport.UseVisualStyleBackColor = true;
            // 
            // rdbtnTransfer
            // 
            this.rdbtnTransfer.AutoSize = true;
            this.rdbtnTransfer.Checked = true;
            this.rdbtnTransfer.Location = new System.Drawing.Point(9, 19);
            this.rdbtnTransfer.Name = "rdbtnTransfer";
            this.rdbtnTransfer.Size = new System.Drawing.Size(160, 19);
            this.rdbtnTransfer.TabIndex = 4;
            this.rdbtnTransfer.TabStop = true;
            this.rdbtnTransfer.Text = "Transfer Master Data";
            this.rdbtnTransfer.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(226, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Function";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel2.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 331);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 328);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(385, 17);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(95, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next >>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnthietlap);
            this.panel2.Controls.Add(this.btnBack);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 353);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(696, 57);
            this.panel2.TabIndex = 2;
            // 
            // btnthietlap
            // 
            this.btnthietlap.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnthietlap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnthietlap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthietlap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnthietlap.Image = ((System.Drawing.Image)(resources.GetObject("btnthietlap.Image")));
            this.btnthietlap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnthietlap.Location = new System.Drawing.Point(10, 17);
            this.btnthietlap.Name = "btnthietlap";
            this.btnthietlap.Size = new System.Drawing.Size(95, 23);
            this.btnthietlap.TabIndex = 5;
            this.btnthietlap.Text = "Setting";
            this.btnthietlap.UseVisualStyleBackColor = false;
            this.btnthietlap.Click += new System.EventHandler(this.btnthietlap_Click);
            // 
            // btnBack
            // 
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(284, 17);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(95, 23);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "<< Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(547, 17);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 410);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Function";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdbtnUpdate;
        private System.Windows.Forms.RadioButton rdbtnExport;
        private System.Windows.Forms.RadioButton rdbtnImport;
        private System.Windows.Forms.RadioButton rdbtnTransfer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnthietlap;
    }
}