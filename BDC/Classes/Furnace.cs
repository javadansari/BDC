using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDC.Classes
{
     public  class Furnace
    {
      
        public string No_Burner { get; set; }
        public string LL_m { get; set; }
        public string HH_m { get; set; }
        public string WB1_m { get; set; }
        public string Alpha_deg { get; set; }
        public string WB2_m { get; set; }
        public string B_deg { get; set; }
        public string LS_m { get; set; }
        public string IX_m { get; set; }
        public string IY_m { get; set; }
        public string DF_m { get; set; }
        public string Lref_m { get; set; }
        public string ODw_mm_F { get; set; }
        public string ODw_mm_R { get; set; }
        public string ODw_mm_S { get; set; }
        public string ODw_mm_D { get; set; }
        public string ThkTube_mm_F { get; set; }
        public string ThkTube_mm_R { get; set; }
        public string ThkTube_mm_S { get; set; }
        public string ThkTube_mm_D { get; set; }
        public string ThkMemb_mm_F { get; set; }
        public string ThkMemb_mm_R { get; set; }
        public string ThkMemb_mm_S { get; set; }
        public string ThkMemb_mm_D { get; set; }
        public string TubeSP_mm_F { get; set; }
        public string TubeSP_mm_R { get; set; }
        public string TubeSP_mm_S { get; set; }
        public string TubeSP_mm_D { get; set; }
        public int Material_F { get; set; }
        public int Material_R { get; set; }
        public int Material_S { get; set; }
        public int Material_D { get; set; }
        public bool Screen { get; set; }
        public bool Floor_Refactory { get; set; }
        public string Emissivity_of_Furnace_Walls { get; set; }
        public string Emissivity_of_Refactory_Layer { get; set; }
        public string Convective_Heat_Transfer { get; set; }
        public string Usage_Factor { get; set; }
        public Furnace() { }
    }
}
