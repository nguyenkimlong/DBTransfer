using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFormDB.TransferMasterData
{
    public partial class FrmWelcomeMaster : Form
    {
        public FrmWelcomeMaster()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            Hide();
            formMain.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmWelcomeMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain frm = new FormMain();
            Hide();
            frm.Show();
        }
    }
}
