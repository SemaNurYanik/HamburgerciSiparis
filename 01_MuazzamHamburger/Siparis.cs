using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_MuazzamHamburger
{
     public class Siparis
    {
        public Menu SeciliMenu { get; set; }
        public Boyut Boyutu { get; set; }
        public List<Extra> ExtraMalzemesi { get; set; }
        public int Adet { get; set; }
        public decimal ToplamTutar { get; set; }
        public void Hesapla()
        {
            ToplamTutar = 0;
            ToplamTutar += SeciliMenu.Fiyati;

            switch (Boyutu)
            {
                case Boyut.Kucuk:
                    ToplamTutar += 0;
                    break;
                case Boyut.Orta:
                    ToplamTutar += ToplamTutar * 0.6m;
                    break;
                case Boyut.Buyuk:
                    ToplamTutar += ToplamTutar * 0.9m;
                    break;                
            }

            foreach (Extra item in ExtraMalzemesi)
            {

                ToplamTutar += item.Fiyati;
            }           

            ToplamTutar = ToplamTutar * Adet;

        }

        public override string ToString()
        {
            if (ExtraMalzemesi.Count < 1)
            {
                return ($"{SeciliMenu.MenuAdi} {Adet} Adet, {Boyutu} Boy, Toplam Tutar: {ToplamTutar}");
            }
            else
            {
                string exMalzemeler = null;
                foreach (Extra item in ExtraMalzemesi)
                {
                    exMalzemeler += item.ExtraAdi + ",";
                }
                exMalzemeler = exMalzemeler.TrimEnd(',');

                return ($"{SeciliMenu.MenuAdi} {Adet} Adet, {Boyutu} Boy, Extra Malzemeler: {exMalzemeler}, Toplam Tutar: {ToplamTutar}");
            }
        }

    }
}
