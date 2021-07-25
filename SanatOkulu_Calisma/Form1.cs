using SanatOkulu_Calisma.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanatOkulu_Calisma
{
    public partial class Form1 : Form
    {
        SanatOkuluContext db = new SanatOkuluContext();
        public Form1()
        {
            InitializeComponent();
            SanatcilariYukle();

        }

        private void SanatcilariYukle()
        {
            cboSanatci.DataSource = db.Sanatcilar.OrderBy(x => x.Ad).ToList();
            cboSanatci.ValueMember = "Id";
            cboSanatci.DisplayMember = "Ad";
        }

        private void pboYeniSanatci_Click(object sender, EventArgs e)
        {
            var frm = new SanatciForm(db);
            if (DialogResult.OK == frm.ShowDialog())
            {
                SanatcilariYukle();
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text.Trim();
            if (ad == "")
            {
                MessageBox.Show("Lütfen Sanat Eserinin Adını Belirtiniz.");
                return;
            }

            if (cboSanatci.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bir Sanatcı Seçiniz.");
                return;
            }





        }
    }
}
