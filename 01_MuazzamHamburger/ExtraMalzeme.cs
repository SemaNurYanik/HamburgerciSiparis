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
    public partial class ExtraMalzeme : MetroFramework.Forms.MetroForm
    {
        public ExtraMalzeme()
        {
            InitializeComponent();
        }        

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SiparisOlustur.extralar.Add(new Extra
            {
                ExtraAdi = txtAd.Text,
                Fiyati = nmrFiyat.Value
            });

            MessageBox.Show("Başarıyla eklendi.");
            Fonksiyon.Temizle(groupBox1.Controls);
        }
    }
}
