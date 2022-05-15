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
    public partial class frmanaform : Form
    {
        public frmanaform()
        {
            InitializeComponent();
        }

        private void btnktgrisl_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Hide();
        }

        private void btnurunisl_Click(object sender, EventArgs e)
        {
            frmurun fr = new frmurun();
            fr.Show();
            this.Hide();

        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            frmistatistik fr = new frmistatistik();
            fr.Show();
            this.Hide();

        }
    }
}
