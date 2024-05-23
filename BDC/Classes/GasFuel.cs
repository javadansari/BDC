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
        public string CH4 { get; set; } = "0";
        public string C2H6 { get; set; } = "0";
        public string C2H4 { get; set; } = "0";
        public string C3H8 { get; set; } = "0";
        public string C3H6 { get; set; } = "0";
        public string N_C4H10 { get; set; } = "0";
        public string ISO_C4H10 { get; set; } = "0";
        public string C4H8 { get; set; } = "0";
        public string ISO_C5H12 { get; set; } = "0";
        public string N_C5H12 { get; set; } = "0";
        public string C5H10 { get; set; } = "0";
        public string C6H14 { get; set; } = "0";
        public string N2 { get; set; } = "0";
        public string CO { get; set; } = "0";
        public string CO2 { get; set; } = "0";
        public string H2O { get; set; } = "0";
        public string H2S { get; set; } = "0";
        public string H2 { get; set; } = "0";
        public string He { get; set; } = "0";
        public string O2 { get; set; } = "0";
        public string Ar { get; set; } = "0";

        public string Total { get; set; } = "0";
        public string FuelPressure { get; set; } = "0";
        public string FuelTemperature { get; set; } = "0";
        public string LHV_kj_kg { get; set; } = "0";
        public string LHV_kj_kg_Calculated { get; set; } = "0";

    }
}
