using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDC.Classes
{
    public class Duct
    {
        public int id { get; set; } 

        [DisplayName("Duct Name")]
        public string name { get; set; } = "-";


        [DisplayName("Straight Duct")]
        public int active { get; set; } 

        public double a { get; set; }
        public double b { get; set; }
        public double aPrim { get; set; }
        public double bPrim { get; set; }
        public double L { get; set; }
        public int Bend_Joint { get; set; }
        public int ri { get; set; }
        public double C { get; set; }
        public double C_degree { get; set; }
        public int Bend_Hopper { get; set; }
        public int Enlargement { get; set; }
        public int typeEnlargement { get; set; }
        public double Enlargement_Degree { get; set; }

        public int Contraction { get; set; }
        public int typeContraction { get; set; }
        public double Contraction_Degree { get; set; }

        public int Splitter { get; set; }
        public double DUCT_sectional_area { get; set; }


        public int DUCT_open_close { get; set; }

        public double Splitter_Degree { get; set; }
        public int DAMPER_quantity { get; set; }

        public int Width_of_truss { get; set; }


        
    }
}
