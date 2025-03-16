using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2.AbstractClasses
{
    public abstract class Personel(string ad, string soyad, decimal saatlikUcret, int calismaSaati)
    {
        public string Ad { get; } = ad;
        public string Soyad { get; } = soyad;
        public decimal SaatlikUcret { get; protected set; } = saatlikUcret;
        public int CalismaSaati { get; protected set; } = calismaSaati;

        public abstract decimal MaasHesapla();

        public override string ToString()
        {
            return $"{Ad} {Soyad} - Saatlik Ücret: {SaatlikUcret} - Çalışma Saati: {CalismaSaati}";
        }
    }
}
