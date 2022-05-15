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
    public partial class frmgiris : Form
    {
        public frmgiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbVTYSProjeEntities db = new DbVTYSProjeEntities();
            var sorgu = from x in db.TBLADMIN
                        where x.KULLANICI == txtad.Text && x.SİFRE == txtsifre.Text
                        select x;
            if (sorgu.Any())
            {
                frmanaform fr = new frmanaform();
                fr.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı yada Şifre");
            }
            
        }
    }
}
