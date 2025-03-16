using CSProjeDemo1.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Classes
{
    public class Kutuphane
    {
        private List<Kitap> kitaplar;
        private List<Uye> uyeler;

        public Kutuphane()
        {
            kitaplar = new List<Kitap>();
            uyeler = new List<Uye>();
        }

        public void KitapEkle(Kitap kitap)
        {
            kitaplar.Add(kitap);
            Console.WriteLine($"'{kitap.Baslik}' kitabı kütüphaneye eklendi.");
        }

        public void UyeEkle(Uye uye)
        {
            uyeler.Add(uye);
            Console.WriteLine($"{uye.Ad} {uye.Soyad} kütüphaneye üye oldu.");
        }

        public void KitapOduncVer(Uye uye, Kitap kitap)
        {
            uye.KitapOduncAl(kitap);
        }

        public void KitapIadeAl(Uye uye, Kitap kitap)
        {
            uye.KitapIadeEt(kitap);
        }

        public List<Kitap> MevcutKitaplariGoruntule()
        {
            return kitaplar;
        }

        public List<Uye> UyeleriGoruntule()
        {
            return uyeler;
        }
    }
}
