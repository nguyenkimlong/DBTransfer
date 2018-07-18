using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFormDB.ShowCommon
{
    public partial class FrmShow : Form
    {
        public FrmShow(string text)
        {
            InitializeComponent();
            richTextBox1.Text = text;
        }

        private void FrmShow_Load(object sender, EventArgs e)
        {

        }

        private void btnok_Click(object sender, EventArgs e)
        {
            Close();}
    }
}
