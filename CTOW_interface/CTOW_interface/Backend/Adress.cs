using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTOW_interface.Backend
{
    class Adress
    {
        private string number;
        private string street;
        private int cp;
        private string city;
        private string country;
        public string NumberGet { get => number; }
        public string StreetGet { get => street; }
        public int CpGet { get => cp; }
        public string CityGet { get => city; }
        public string CountryGet { get => country; }
        public Adress(string number, string street, int cp, string city, string country)
        {
            this.number = number;
            this.street = street;
            this.cp = cp;
            this.city = city;
            this.country = country;
        }
    }
}
