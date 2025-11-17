using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityJson.Models
{
    public class cityJson
    {
        private string _name;
        private string _city;
        private string _state;
        private string _country;
        private string _country_iso3166;
        private string _country_name;
        private string _zmw;
        private string _l;

        public string Name { get => _name; set => _name = value; }
        public string City { get => _city; set => _city = value; }
        public string State { get => _state; set => _state = value; }
        public string Country { get => _country; set => _country = value; }
        public string Country_iso3166 { get => _country_iso3166; set => _country_iso3166 = value; }
        public string Country_name { get => _country_name; set => _country_name = value; }
        public string Zmw { get => _zmw; set => _zmw = value; }
        public string L { get => _l; set => _l = value; }
    }

}