using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Produkt
{
    public class Produktnew
    {
        public string KassenNummer { get; set; }
        //artikelnr
        public string Produktname { get; set; }
        public int Menge { get; set; }
        public string Einheit { get; set; }
        public decimal VKStueckpreis { get; set; }
        public decimal Preis { get; set; }
        //vk stückpreis *menge gleich totasl total
        public decimal MWST { get; set; }
        public  void SetStueckpreis()
        {
            Preis = this.Menge* this.VKStueckpreis ;
        }
    }
}
