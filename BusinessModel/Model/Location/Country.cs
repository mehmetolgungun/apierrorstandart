using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model.Location
{
    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class SampleData
    {
        public static List<Country> CountryList = new List<Country>() {
            new Country() { Code="TR",Name="Turkey"} ,
            new Country() { Code="US",Name="United States"},
            new Country() { Code="UK",Name="United Kingdom"}
        };
    }
}
