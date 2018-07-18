using System;
using System.Linq;
using System.Windows.Forms;
using TestFormDB.ExportDataToTemp;
using TestFormDB.ImportFromDataTemp;
using TestFormDB.TransferMasterData;
using TestFormDB.Update_Data;

namespace TestFormDB
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            RadioButton radio = this.panel3.Controls.OfType<RadioButton>()
                                           .Where(x => x.Checked).FirstOrDefault();
            switch (radio.Name)
            {
                case "rdbtnTransfer":
                    ListTable ListTable = new ListTable();
                    this.Hide();
                    ListTable.Show();
                    break;

                case "rdbtnExport":
                    FrmListTableSource FrmListTableSource = new FrmListTableSource();
                    this.Hide();
                    FrmListTableSource.Show();
                    break;

                case "rdbtnImport":
                    FrmListData FrmListData = new FrmListData();
                    this.Hide();
                    FrmListData.Show();break;

                case "rdbtnUpdate":
                    FrmAdjustData srcUpdate = new FrmAdjustData();
                    this.Hide();
                    srcUpdate.Show();
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Visible == true)
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

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            Hide();
            main.Show();
        }

        private void btnthietlap_Click(object sender, EventArgs e)
        {
            FrmConnect frmConnect = new FrmConnect();
            frmConnect.ShowDialog();
        }
    }
}