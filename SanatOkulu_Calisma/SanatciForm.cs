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
    public partial class SanatciForm : Form
    {
        public event EventHandler SanatcilarDegisti;

        private readonly SanatOkuluContext db;
        public SanatciForm(SanatOkuluContext db)
        {
            this.db = db;
            InitializeComponent();
            listele();
        }
        private void listele()
        {
            lstSanatcilar.DataSource = db.Sanatcilar.OrderBy(x => x.Ad).ToList();
            lstSanatcilar.DisplayMember = "Ad";
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text.Trim();
            if (ad == "")
            {
                MessageBox.Show("Lütfen Bir Sanatcı Adı Belirtiniz");
                return;
            }
            if (duzenlenenSanatci == null)
            {
                db.Sanatcilar.Add(new Sanatci() { Ad = ad });

            }
            else
            {
                duzenlenenSanatci.Ad = ad;
            }
            db.SaveChanges();
            listele();
            SanatcilarDegistiginde(EventArgs.Empty);
            FormuResetle();
        }

        protected virtual void SanatcilarDegistiginde(EventArgs args)
        {
            if (SanatcilarDegisti != null)
            {
                SanatcilarDegisti(this, args);
            }
        }
        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lstSanatcilar.SelectedIndex == -1) return;

            Sanatci sanatci = (Sanatci)lstSanatcilar.SelectedItem;
            db.Sanatcilar.Remove(sanatci);
            db.SaveChanges();
            listele();
            SanatcilarDegistiginde(EventArgs.Empty);

        }

        Sanatci duzenlenenSanatci;

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (lstSanatcilar.SelectedIndex == -1) return;
            duzenlenenSanatci = (Sanatci)lstSanatcilar.SelectedItem;

            txtAd.Text = duzenlenenSanatci.Ad;
            btnEkle.Text = "KAYDET";
            btnIptal.Show();
            lstSanatcilar.Enabled = false;
            btnDuzenle.Enabled = false;
            btnSil.Enabled = false;
        }
        private void btnIptal_Click(object sender, EventArgs e)
        {
            FormuResetle();
        }

        private void FormuResetle()
        {
            txtAd.Clear();
            duzenlenenSanatci = null;
            btnEkle.Text = "EKLE";
            btnIptal.Hide();
            lstSanatcilar.Enabled = btnDuzenle.Enabled = btnSil.Enabled = true;
        }
    }
}
