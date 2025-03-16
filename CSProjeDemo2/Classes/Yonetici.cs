using CSProjeDemo2.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2.Classes
{
    public class Yonetici : Personel
    {
        public decimal Bonus { get; }

        public Yonetici(string ad, string soyad, decimal saatlikUcret, int calismaSaati, decimal bonus) : base(ad, soyad, saatlikUcret, calismaSaati)
        {
            if (saatlikUcret < 500)
                throw new ArgumentException("Yönetici saatlik ücreti 500 TL’den az olamaz.");

            Bonus = bonus;
        }

        public override decimal MaasHesapla()
        {
            return (SaatlikUcret * CalismaSaati) + Bonus;
        }
    }
}
