using CSProjeDemo1.AbstractClasses;
using CSProjeDemo1.Enums;
using CSProjeDemo1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Classes
{
    public class Uye : IUye
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int UyeNumarasi { get; set; }
        public List<Kitap> OduncAlinanKitaplar { get; private set; }

        public Uye(string ad, string soyad, int uyeNumarasi)
        {
            Ad = ad;
            Soyad = soyad;
            UyeNumarasi = uyeNumarasi;
            OduncAlinanKitaplar = new List<Kitap>();
        }

        public void KitapOduncAl(Kitap kitap)
        {
            if (kitap.KitapDurumu == Durum.OduncAlabilir)
            {
                OduncAlinanKitaplar.Add(kitap);
                kitap.KitapDurumu = Durum.OduncVerildi;
            }
        }

        public void KitapIadeEt(Kitap kitap)
        {
            if (OduncAlinanKitaplar.Contains(kitap))
            {
                OduncAlinanKitaplar.Remove(kitap);
                kitap.KitapDurumu = Durum.OduncAlabilir;
            }
        }
    }
}
