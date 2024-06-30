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
        [DisplayName("Blank activation")]
        public bool active { get; set; } = false;

        [DisplayName("Section Name")]
        public string sectionName { get; set; } = "";


        [DisplayName("Section")]
        public int section { get; set; } = 0;

        [DisplayName("Section Number")]
        public int sectionNumber { get; set; } = 0;

        [DisplayName("Channel Height (m)")]
        public string Channel_Height { get; set; } = "";

        [DisplayName("Channel Width (m)")]
        public string Channel_Width { get; set; } = "";

        public int TubeArrangement { get; set; } = 0;
     
        [DisplayName("Water/Gas Flow Pattern")]
        public int Water_Gas_Flow_Pattern { get; set; } = 0;
      
        [DisplayName("NO# Rows")]
        public string No_Rows { get; set; } = "";

        [DisplayName("NO# Tubes/Row")]
        public string No_Tubes_Row { get; set; } = "";

        [DisplayName("Longitudinal Pitch (mm)")]
        public string Longitudinal_Pitch { get; set; } = "";

        [DisplayName("Transverse Pitch (mm)")]
        public string Transverse_Pitch { get; set; } = "";

        [DisplayName("NO# Water Carrying Tubes")]
        public string NO_Water_Carrying_Tubes { get; set; } = "";

       [DisplayName("Tube Length/Water Flow (m)")]
        public string Tube_Length { get; set; } = "";

        [DisplayName("Tube Outer Diameter (mm)")]
        public string Tube_Outer_Diameter { get; set; } = "";
      
        [DisplayName("Tube Wall Thickness (mm)")]
        public string Tube_Wall_Thickness { get; set; } = "";
        
        [DisplayName("Incidence Angle (deg)")]
        public string Incidence_Angle { get; set; } = "";

        [DisplayName("Tubes Material")]
        public int Tubes_Material { get; set; } = 0;

        [DisplayName("Fin Type")]
        public int Fin_Type { get; set; } = 0;

        [DisplayName("Fin Height (mm)")]
        public string Fin_Height { get; set; } = "";

        [DisplayName("Fin Thickness (mm)")]
        public string Fin_Thickness { get; set; } = "";

        [DisplayName("Fin Density (fin/m)")]
        public string Fin_Density { get; set; } = "";


        [DisplayName("Fin Uncut Height (mm)")]
        public string Fin_Uncut_Height { get; set; } = "";


        [DisplayName("Fin Segment Width (mm)")]
        public string Fin_Segment_Width { get; set; } = "";


        [DisplayName("Fin Material")]
        public int Fin_Material { get; set; } = 0;

        [DisplayName("Water-Side Founling Factor (m2K/W)")]
        public string Water_Side_Founling_Factor { get; set; } = "";


        [DisplayName("Gas-Side Founling Factor (m2K/W)")]
        public string Gas_Side_Founling_Factor { get; set; } = "";


        [DisplayName("Usage Factor (0,1)")]
        public string Usage_Factor { get; set; } = "";
    }
}
