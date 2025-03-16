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

        public void OduncAlinanKitaplariListele()
        {
            Console.WriteLine($"{Ad} {Soyad} tarafından ödünç alınan kitaplar:");
            if (OduncAlinanKitaplar.Count != 0)
            {
                foreach (var kitap in OduncAlinanKitaplar)
                {
                    Console.WriteLine($"- {kitap.Baslik} ({kitap.Yazar})");
                }
            }
            else
            {
                Console.WriteLine("Ödünç alınan kitap bulunmamaktadır.");
            }
        }

        public void BilgileriGuncelle(string yeniAd, string yeniSoyad)
        {
            if (!string.IsNullOrWhiteSpace(yeniAd) && !string.IsNullOrWhiteSpace(yeniSoyad))
            {
                Ad = yeniAd;
                Soyad = yeniSoyad;
                Console.WriteLine($"Üye bilgileri güncellendi: {Ad} {Soyad}");
            }
            else
            {
                Console.WriteLine("Ad veya soyad boş olamaz!");
            }
        }
    }
}
