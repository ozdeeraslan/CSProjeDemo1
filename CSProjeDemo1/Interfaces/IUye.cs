using CSProjeDemo1.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Interfaces
{
    public interface IUye
    {
        string Ad { get; set; }
        string Soyad { get; set; }
        int UyeNumarasi { get; set; }
        List<Kitap> OduncAlinanKitaplar { get; }
        void KitapOduncAl(Kitap kitap);
        void KitapIadeEt(Kitap kitap);
        void OduncAlinanKitaplariListele();
        void BilgileriGuncelle(string yeniAd, string yeniSoyad);
    }
}
