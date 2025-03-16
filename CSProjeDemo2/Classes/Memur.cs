using CSProjeDemo2.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2.Classes
{
    public class Memur : Personel
    {
        public Memur(string ad, string soyad, decimal saatlikUcret, int calismaSaati)
            : base(ad, soyad, saatlikUcret, calismaSaati)
        {
            if (saatlikUcret < 500)
                throw new ArgumentException("Memur saatlik ücreti en az 500 TL olmalıdır.");
        }

        public override decimal MaasHesapla()
        {
            decimal normalMaas = SaatlikUcret * Math.Min(CalismaSaati, 180);
            decimal fazlaMesai = 0;

            if (CalismaSaati > 180)
            {
                int fazlaSaat = CalismaSaati - 180;
                fazlaMesai = fazlaSaat * (SaatlikUcret * 1.5m);
            }

            return normalMaas + fazlaMesai;
        }
    }
}
