using CSProjeDemo1.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.SubClasses
{
    public class KitapRoman : Kitap
    {
        public KitapRoman(string isbn, string baslik, string yazar, int yayinYili) : base(isbn, baslik, yazar, yayinYili) { }
    }
}
