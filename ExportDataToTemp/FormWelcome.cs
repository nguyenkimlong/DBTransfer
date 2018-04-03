using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFormDB.ExportDataToTemp
{
    public partial class FormWelcome : Form
    {
        public FormWelcome()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            FrmListTableSource frm = new FrmListTableSource();
            this.Hide();
            frm.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            Hide();
            formMain.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormWelcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain frm = new FormMain();
            Hide();
            frm.Show();
        }

        private void FormWelcome_Load(object sender, EventArgs e)
        {

        }
    }
}
