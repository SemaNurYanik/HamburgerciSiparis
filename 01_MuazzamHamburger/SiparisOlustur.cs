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
    public partial class SiparisOlustur : MetroFramework.Forms.MetroForm
    {
        public SiparisOlustur()
        {
            InitializeComponent();
        }

        public static List<Siparis> siparisler = new List<Siparis>();
        public static List<Siparis> mevcutSiparisler = new List<Siparis>();
        public static List<Menu> menuler = new List<Menu>()
        {
            new Menu {MenuAdi="Steakhouse",Fiyati=29.99m},
            new Menu{MenuAdi="BigKing",Fiyati=19.99m},
            new Menu{MenuAdi="KingChicken",Fiyati=15.99m}
        };

        public static List<Extra> extralar = new List<Extra>()
        {
            new Extra{ExtraAdi="Mayonez",Fiyati=1.00m},
            new Extra{ExtraAdi="Ketçap",Fiyati=0.50m}
        };

        private void SiparisOlustur_Load(object sender, EventArgs e)
        {
           
            rbKucuk.Checked = true;           

            foreach (Menu item in menuler)
            {
                cmbMenu.Items.Add(item);
            }
            cmbMenu.SelectedIndex = 0;

            foreach (Extra item in extralar)
            {
                flpExtraMalzemeler.Controls.Add(new CheckBox()
                {
                    Text = item.ExtraAdi,
                    Tag = item                    
                });
                                    
            }
        }

        private void btnSiparisEkle_Click(object sender, EventArgs e)
        {
            Siparis yeniSiparis = new Siparis();
            yeniSiparis.SeciliMenu = (Menu)cmbMenu.SelectedItem;

            if (rbKucuk.Checked)
            {
                yeniSiparis.Boyutu = Boyut.Kucuk;
            }
            else if (rbOrta.Checked)
            {
                yeniSiparis.Boyutu = Boyut.Orta;
            }
            else
            {
                yeniSiparis.Boyutu = Boyut.Buyuk;
            }

            yeniSiparis.ExtraMalzemesi = new List<Extra>();
            foreach (CheckBox item in flpExtraMalzemeler.Controls)
            {
                if (item.Checked)
                {
                    yeniSiparis.ExtraMalzemesi.Add((Extra)item.Tag);
                }
            }

            yeniSiparis.Adet = Convert.ToInt32(nmrAdet.Value);
            yeniSiparis.Hesapla();
            mevcutSiparisler.Add(yeniSiparis);
            listBox1.Items.Add(yeniSiparis);
            TutarHesapla();
            Fonksiyon.Temizle(groupBox1.Controls);
            Fonksiyon.Temizle(this.Controls);
            rbKucuk.Checked = true;
        }


        private decimal TutarHesapla()
        {
            decimal toplamTutar = 0;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                Siparis gelen = (Siparis)listBox1.Items[i];
                toplamTutar += gelen.ToplamTutar;
               
            }

            lblToplamTutar.Text = toplamTutar.ToString();
            return toplamTutar;
        }

        private void btnSiparisTamamla_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Toplam sipariş ücreti:" + TutarHesapla().ToString() + " Satın almayı tamamlamak istiyor musunuz?", "Sipariş Bilgisi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                listBox1.Items.Clear();
                siparisler.AddRange(mevcutSiparisler);
                mevcutSiparisler.Clear();
                TutarHesapla();
                MessageBox.Show("Sipariş tamamlandı.");
                this.Close();
            }
            else
            {
                MessageBox.Show("İptal edildi.");
                listBox1.Items.Clear();
                lblToplamTutar.Text = "0TL";
                mevcutSiparisler.Clear();
            }
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            mevcutSiparisler.Remove((Siparis)listBox1.SelectedItem);
            listBox1.Items.Remove(listBox1.SelectedItem);
            TutarHesapla();
            
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            btnGuncelle.Enabled = true;
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            btnSil.Enabled = true;
        }
    }
}
