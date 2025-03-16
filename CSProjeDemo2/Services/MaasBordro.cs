using CSProjeDemo2.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSProjeDemo2.Services
{
    public static class MaasBordro
    {
        public static void MaaslariKaydet(List<Personel> personeller, string dosyaAdi)
        {
            try
            {
                string baseDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                string klasorYolu = Path.Combine(baseDirectory, "Bordrolar");
                if (!Directory.Exists(klasorYolu))
                {
                    Directory.CreateDirectory(klasorYolu);
                }

                string dosyaYolu = Path.Combine(klasorYolu, dosyaAdi);

                var bordroListesi = new List<object>();

                foreach (var personel in personeller)
                {
                    var bordro = new
                    {
                        PersonelIsmi = $"{personel.Ad} {personel.Soyad}",
                        personel.CalismaSaati,
                        AnaOdeme = personel.SaatlikUcret * Math.Min(personel.CalismaSaati, 180),
                        Mesai = personel.CalismaSaati > 180 ? (personel.CalismaSaati - 180) * (personel.SaatlikUcret * 1.5m) : 0,
                        ToplamOdeme = personel.MaasHesapla()
                    };

                    bordroListesi.Add(bordro);
                }

                string json = JsonSerializer.Serialize(bordroListesi, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(dosyaYolu, json);

                Console.WriteLine($" Bordro başarıyla kaydedildi: {dosyaYolu}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Hata: Bordro kaydedilirken bir hata oluştu! {ex.Message}");
            }
        }

        public static void AzCalisanlariRaporla(List<Personel> personeller)
        {
            try
            {
                string baseDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                string raporKlasoru = Path.Combine(baseDirectory, "Bordrolar");
                string raporDosyaYolu = Path.Combine(raporKlasoru, "az_calisanlar_raporu.json");

                if (!Directory.Exists(raporKlasoru))
                {
                    Directory.CreateDirectory(raporKlasoru);
                }

                var azCalisanlarListesi = new List<object>();

                foreach (var personel in personeller)
                {
                    if (personel.CalismaSaati < 150)
                    {
                        var rapor = new
                        {
                            PersonelIsmi = $"{personel.Ad} {personel.Soyad}",
                            personel.CalismaSaati,
                            Maas = personel.MaasHesapla()
                        };

                        azCalisanlarListesi.Add(rapor);
                    }
                }

                if (azCalisanlarListesi.Count > 0)
                {
                    string json = JsonSerializer.Serialize(azCalisanlarListesi, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(raporDosyaYolu, json);
                    Console.WriteLine($"150 Saatten Az Çalışanların Raporu Kaydedildi: {raporDosyaYolu}");
                }
                else
                {
                    Console.WriteLine("Tüm personel 150 saat veya daha fazla çalışmış. Rapor oluşturulmadı.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: Az çalışanları raporlarken bir hata oluştu! {ex.Message}");
            }
        }

    }
}

