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
    public partial class SiparisleriListele : MetroFramework.Forms.MetroForm
    {
        public SiparisleriListele()
        {
            InitializeComponent();
        }

        private void SiparisleriListele_Load(object sender, EventArgs e)
        {
            decimal ciro = 0;
            decimal extraMalzemeGeliri = 0;
            int satilanUrunAdedi = 0;

            foreach (Siparis item in SiparisOlustur.siparisler)
            {
                ciro += item.ToplamTutar;

                foreach (Extra ex in item.ExtraMalzemesi)
                {
                    extraMalzemeGeliri += ex.Fiyati;
                }

                satilanUrunAdedi += item.Adet;
                listBox1.Items.Add(item);
            }

            label2.Text = ciro.ToString();
            label3.Text = extraMalzemeGeliri.ToString();
            label5.Text = satilanUrunAdedi.ToString();
            label4.Text = listBox1.Items.Count.ToString();

        }
    }
}
