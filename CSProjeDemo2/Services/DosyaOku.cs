using CSProjeDemo2.AbstractClasses;
using CSProjeDemo2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSProjeDemo2.Services
{
    public static class DosyaOku
    {
        public static List<Personel> JsonDosyasindanPersonelOku(string dosyaYolu)
        {
            try
            {
                if (!File.Exists(dosyaYolu))
                {
                    Console.WriteLine("Hata: JSON dosyası bulunamadı!");
                    return [];
                }

                string json = File.ReadAllText(dosyaYolu);
                List<PersonelVeri> personelListesi = JsonSerializer.Deserialize<List<PersonelVeri>>(json);

                List<Personel> personeller = [];

                foreach (var veri in personelListesi)
                {
                    if (veri.Title == "Yonetici")
                    {
                        personeller.Add(new Yonetici(veri.Name, veri.Surname, veri.HourlyRate, veri.WorkHours, veri.Bonus));
                    }
                    else if (veri.Title == "Memur")
                    {
                        personeller.Add(new Memur(veri.Name, veri.Surname, veri.HourlyRate, veri.WorkHours));
                    }
                }

                return personeller;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: JSON dosyası okunurken bir hata oluştu! {ex.Message}");
                return new List<Personel>();
            }
        }

        private class PersonelVeri
        {
            public string Name { get; set; } = null!;
            public string Surname { get; set; } = null!;
            public string Title { get; set; } = null!;
            public decimal HourlyRate { get; set; }
            public int WorkHours { get; set; }
            public decimal Bonus { get; set; } = 0;
        }
    }
}

