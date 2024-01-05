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
        public string C { get; set; } = "-";
        public string H { get; set; } = "-";
        public string H2O_ { get; set; } = "-";
        public string S { get; set; } = "-";
        public string O { get; set; } = "-";
        public string N { get; set; } = "-";
        public string Total_ { get; set; } = "-";
        public string FuelPressure_ { get; set; } = "-";
        public string FuelTemperature_ { get; set; } = "-";
        public string LHV_kj_kg_Calculated_ { get; set; } = "-";
    }
}
