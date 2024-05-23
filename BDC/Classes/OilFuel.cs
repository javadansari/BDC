using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDC.Classes
{
    public class OilFuel
    {
        public int id { get; set; }
        public string name { get; set; } = "-";
        public int active_ { get; set; } = 0;
        public string C { get; set; } = "0";
        public string H { get; set; } = "0";
        public string H2O_ { get; set; } = "0";
        public string S { get; set; } = "0";
        public string O { get; set; } = "0";
        public string N { get; set; } = "0";
        public string Total_ { get; set; } = "0";
        public string FuelPressure_ { get; set; } = "0";
        public string FuelTemperature_ { get; set; } = "0";
        public string LHV_kj_kg_Calculated_ { get; set; } = "0";
    }
}
