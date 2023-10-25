using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDC.Classes
{
    public class ItemAttribute
    {
        public string stage { get; set; } = "-";
        public string loadCase { get; set; } = "-";
        public int TubeArrangement { get; set; } = 0;
        public int Water_Gas_Flow_Pattern { get; set; } = 0;
        public string No_Rows { get; set; } = "-";
        public string SLN { get; set; } = "-";
        public string STN { get; set; } = "-";

        [DisplayName("Tube Rows / Path")]
        public string Tube_Rows_Path { get; set; } = "-";
        public string Path_Wide { get; set; } = "-";
        public string SL { get; set; } = "-";
        public string ST { get; set; } = "-";

       [DisplayName("Tube Length")]
        public string Tube_Length { get; set; } = "-";

        [DisplayName("Tube Outer Diameter")]
        public string Tube_Outer_Diameter { get; set; } = "-";
      
        [DisplayName("Tube Wall Thickness")]
        public string Tube_Wall_Thickness { get; set; } = "-";
        
        [DisplayName("Incidence Angle")]
        public string Incidence_Angle { get; set; } = "-";

        [DisplayName("Tubes Material")]
        public string Tubes_Material { get; set; } = "-";

        [DisplayName("Fin Type")]
        public string Fin_Type { get; set; } = "-";

        [DisplayName("Fin Height")]
        public string Fin_Height { get; set; } = "-";


        [DisplayName("Fin Density")]
        public string Fin_Density { get; set; } = "-";


        [DisplayName("Fin Uncut Height")]
        public string Fin_Uncut_Height { get; set; } = "-";


        [DisplayName("Fin Segment Width")]
        public string Fin_Segment_Width { get; set; } = "-";


        [DisplayName("Fin Material")]
        public string Fin_Material { get; set; } = "-";

        [DisplayName("Water-Side Founling Factor")]
        public string Water_Side_Founling_Factor { get; set; } = "-";

        [DisplayName("Usage Factor")]
        public string Usage_Factor { get; set; } = "-";
    }
}
