using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_MuazzamHamburger
{
    public partial class MDIParent1 : MetroFramework.Forms.MetroForm
    {
       

        public MDIParent1()
        {
            InitializeComponent();
          
        }

        void ChildFormAc(Form childForm)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Text == childForm.Text)
                {
                    frm.Activate();
                }
                else
                {
                    frm.Close();
                }
            }

            childForm.MdiParent = this;
            childForm.Show();

        }

        private void siparisOlusturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 1070;
            this.Height = 1000;
            ChildFormAc(new SiparisOlustur());
        }

        private void siparisleriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildFormAc(new SiparisleriListele());
        }

        private void menuEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildFormAc(new MenuEkle());
        }

        private void extraMalzemeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildFormAc(new ExtraMalzeme());
        }
    }
}
