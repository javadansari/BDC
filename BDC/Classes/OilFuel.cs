using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDC.Classes
{
    internal class OilFuel
    {
        public int id { get; set; }
        public string name { get; set; } = "-";
        public string C { get; set; } = "-";
        public string H { get; set; } = "-";
        public string H2O { get; set; } = "-";
        public string S { get; set; } = "-";
        public string O { get; set; } = "-";
        public string N { get; set; } = "-";
        public string Total { get; set; } = "-";
        public string FuelPressure { get; set; } = "-";
        public string FuelTemperature { get; set; } = "-";
        public string LHV_kj_kg_Calculated { get; set; } = "-";
    }
}
