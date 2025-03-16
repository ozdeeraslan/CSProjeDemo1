

using CSProjeDemo2.AbstractClasses;
using CSProjeDemo2.Services;

Console.OutputEncoding = System.Text.Encoding.Unicode; // TL sembolünün gözükmesi için

string baseDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
string dosyaYolu = Path.Combine(baseDirectory, "personeller.json");

List<Personel> personeller = DosyaOku.JsonDosyasindanPersonelOku(dosyaYolu);

Console.WriteLine("\n Personel Listesi:");
foreach (var personel in personeller)
{
    Console.WriteLine(personel);
    Console.WriteLine($"Maaş: ₺{personel.MaasHesapla()}");
    MaasBordro.MaaslariKaydet(personeller, "maas_bordro.json");
    MaasBordro.AzCalisanlariRaporla(personeller);
}
