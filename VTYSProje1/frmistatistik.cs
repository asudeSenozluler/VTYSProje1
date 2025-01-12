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
    public partial class frmistatistik : Form
    {
        public frmistatistik()
        {
            InitializeComponent();
        }
        DbVTYSProjeEntities db = new DbVTYSProjeEntities();
        private void frmistatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.TBLKATEGORI.Count().ToString();
            label3.Text = db.TBLURUNLER.Count().ToString();
            label5.Text = db.TBLMUSTERI.Count(x=>x.DURUM==true).ToString();
            label7.Text = db.TBLMUSTERI.Count(x => x.DURUM == false).ToString();
            label9.Text = db.TBLURUNLER.Sum(y=>y.STOK).ToString();
            label17.Text = db.TBLSATIS.Sum(z => z.FIYAT).ToString() +"TL";
            label11.Text = (from x in db.TBLURUNLER orderby x.FIYAT
                                descending select x.URUNAD).FirstOrDefault();
            label13.Text = (from x in db.TBLURUNLER
                            orderby x.FIYAT
                                ascending
                            select x.URUNAD).FirstOrDefault();
            label15.Text = db.TBLURUNLER.Count(x => x.KATEGORI == 1).ToString();
            label21.Text = db.TBLURUNLER.Count(x => x.URUNAD == "BUZDOLABI").ToString();
            label23.Text = (from x in db.TBLMUSTERI select x.SEHIR).Distinct().Count().ToString();
            label19.Text = db.MARKAGETIR().FirstOrDefault();
            




            
        }
    }
}
