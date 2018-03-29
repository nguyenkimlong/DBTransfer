using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFormDB.ImportFromDataTemp
{
    public partial class FrmWelcomeImport : Form
    {
        public FrmWelcomeImport()
        {
            InitializeComponent();
        }

        private void FrmWelcomeImport_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            Hide();
            formMain.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            FrmSrcDatabase frm = new FrmSrcDatabase();
            this.Hide();
            frm.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmWelcomeImport_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain frm = new FormMain();
            Hide();
            frm.Show();
        }
    }
}
