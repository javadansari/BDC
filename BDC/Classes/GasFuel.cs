using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDC.Classes
{
    public class GasFuel
    {
        public int id { get; set; }
        public string name { get; set; } = "-";
        public int active { get; set; } = 0;
        public string CH4 { get; set; } = "-";
        public string C2H6 { get; set; } = "-";
        public string C3H8 { get; set; } = "-";
        public string C4H10 { get; set; } = "-";
        public string C5H12 { get; set; } = "-";
        public string C2H2 { get; set; } = "-";
        public string C2H4 { get; set; } = "-";
        public string C3H6 { get; set; } = "-";
        public string C4H8 { get; set; } = "-";
        public string C6H6 { get; set; } = "-";
        public string N2 { get; set; } = "-";
        public string CO { get; set; } = "-";
        public string CO2 { get; set; } = "-";
        public string H2O { get; set; } = "-";
        public string H2S { get; set; } = "-";
        public string O2 { get; set; } = "-";
        public string NH3 { get; set; } = "-";
        public string Total { get; set; } = "-";
        public string FuelPressure { get; set; } = "-";
        public string FuelTemperature { get; set; } = "-";
        public string LHV_kj_kg { get; set; } = "-";
        public string LHV_kj_kg_Calculated { get; set; } = "-";

    }
}
