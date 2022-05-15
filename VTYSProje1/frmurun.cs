using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTYSProje1
{
    public partial class frmurun : Form
    {
        public frmurun()
        {
            InitializeComponent();
        }
        DbVTYSProjeEntities db = new DbVTYSProjeEntities();
        private void btnliste_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TBLURUNLER
                                        select new
                                            {
                                                x.URUNID,
                                                x.URUNAD,
                                                x.MARKA,
                                                x.TBLKATEGORI.AD,
                                                x.STOK,
                                                x.DURUM,
                                                x.FIYAT

                                            }).ToList();
                
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            TBLURUNLER t = new TBLURUNLER();
            t.URUNAD = txturunad.Text;
            t.MARKA = txturunmarka.Text;
            t.STOK = short.Parse(txtstok.Text);
            t.KATEGORI = int.Parse(cmbktgr.SelectedValue.ToString());
            t.FIYAT =  decimal.Parse(txtfiyat.Text);
            t.DURUM = true;
            db.TBLURUNLER.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Sisteme Eklendi");



        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var urun = db.TBLURUNLER.Find(x);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi...");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var urun = db.TBLURUNLER.Find(x);
            urun.URUNAD = txturunad.Text;
            urun.STOK = short.Parse(txtstok.Text);
            urun.MARKA = txturunmarka.Text;
            urun.FIYAT = decimal.Parse(txtfiyat.Text);
            urun.KATEGORI = int.Parse(cmbktgr.Text);
            db.SaveChanges();
            MessageBox.Show("Ürün Bilgileri Güncellendi...");
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txtdurum.Text = "";
            txtfiyat.Text = "";
            txtid.Text = "";
            txtstok.Text = "";
            txturunad.Text = "";
            txturunmarka.Text = "";
            cmbktgr.Text = "";
        }

        private void frmurun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.TBLKATEGORI
                               select new {
                                   x.ID, x.AD
                               }
                               ).ToList();
            cmbktgr.ValueMember = "ID";
            cmbktgr.DisplayMember = "AD";
            cmbktgr.DataSource = kategoriler;

        }
    }
}
