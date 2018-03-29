using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFormDB
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            FormMain frm = new FormMain();
            Hide();
            frm.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult tl = MessageBox.Show("Bạn có muốn thoát chương trình", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == tl)
            {
                System.Environment.Exit(1);
            }
            else
            {
                e.Cancel = true;
            }

        }       

        private void Main_Load(object sender, EventArgs e)
        {
            if (!Application.OpenForms.OfType<Main>().Any())
                Application.Exit();         

        }
       

        private void Main_Deactivate(object sender, EventArgs e)
        {

        }
    }
}
