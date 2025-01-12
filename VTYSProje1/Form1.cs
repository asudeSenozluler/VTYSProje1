﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbVTYSProjeEntities db = new DbVTYSProjeEntities();
        private void btnlistele_Click(object sender, EventArgs e)
        {
            var kategoriler = db.TBLKATEGORI.ToList();
            dataGridView1.DataSource = kategoriler;
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
           TBLKATEGORI t=new TBLKATEGORI();
           t.AD = txtkategoriad.Text;
           db.TBLKATEGORI.Add(t);
           db.SaveChanges();
           MessageBox.Show("Kategori Eklendi...");
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var ktgr = db.TBLKATEGORI.Find(x);
            db.TBLKATEGORI.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Kategori Silindi...");

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {

            int x = Convert.ToInt32(textBox1.Text);
            var ktgr = db.TBLKATEGORI.Find(x);
            ktgr.AD = txtkategoriad.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme Yapıldı...");
        }
    }
}
