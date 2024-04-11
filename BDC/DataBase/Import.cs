using BDC.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BDC.DataBase
{
    public class Import
    {
        private int intValue;
        private bool boolValue;

        public string filePath { get; set; }

        public Import(string filePath)
        {
            this.filePath = filePath;
        }

        public Furnace ImportFurnace()
        {
            string line = File.ReadLines(filePath).Skip(4).Take(1).First();
            string[] items = line.Split(',');
            Furnace furnace = new Furnace();
             furnace.No_Burner = items[1];
             furnace.LL_m = items[2];
             furnace.HH_m = items[3];
             furnace.WB1_m = items[4];
             furnace.Alpha_deg = items[5];
             furnace.WB2_m = items[6];
             furnace.B_deg = items[7];
             furnace.LS_m = items[8];
             furnace.IX_m = items[9];
             furnace.IY_m = items[1];
             furnace.DF_m = items[11];
             furnace.Lref_m = items[12];
             furnace.ODw_mm_F = items[13];
             furnace.ODw_mm_R = items[14];
             furnace.ODw_mm_S = items[15];
             furnace.ODw_mm_D = items[16];
             furnace.ThkTube_mm_F = items[17];
             furnace.ThkTube_mm_R = items[18];
             furnace.ThkTube_mm_S = items[19];
             furnace.ThkTube_mm_D = items[20];
             furnace.ThkMemb_mm_F = items[21];
             furnace.ThkMemb_mm_R = items[22];
             furnace.ThkMemb_mm_S = items[23];
             furnace.ThkMemb_mm_D = items[24];
             furnace.TubeSP_mm_F = items[25];
             furnace.TubeSP_mm_R = items[26];
             furnace.TubeSP_mm_S = items[27];
             furnace.TubeSP_mm_D = items[28];
             furnace.Material_F = int.TryParse(items[29] ,out intValue) ? intValue : 0;
            furnace.Material_R = int.TryParse(items[30], out intValue) ? intValue : 0;
            furnace.Material_S = int.TryParse(items[31], out intValue) ? intValue : 0;
            furnace.Material_D = int.TryParse(items[32], out intValue) ? intValue : 0;
            furnace.Screen = bool.TryParse(items[33], out boolValue) ? boolValue : false;
            furnace.Floor_Refactory = bool.TryParse(items[34], out boolValue) ? boolValue : false;
            furnace.Emissivity_of_Furnace_Walls = items[35];
             furnace.Emissivity_of_Refactory_Layer = items[36];
             furnace.Convective_Heat_Transfer = items[37];
             furnace.Usage_Factor = items[38];
            return furnace;       
        }

        public List<Element> ImportElements()
        {
           
           
            List<Element> elements = new List<Element>();
            for (int i = 9; i <= 16; i++)
            {
              string line = File.ReadLines(filePath).Skip(i).Take(1).First();
               string[] items = line.Split(',');
               Element element = new Element();
                element.Id = i - 8;
               ItemAttribute itemAttribute = new ItemAttribute();
                itemAttribute.active = bool.TryParse(items[1], out boolValue) ? boolValue : false;
                itemAttribute.sectionName = items[2];
                itemAttribute.section = int.TryParse(items[3], out intValue) ? intValue : 0;
                itemAttribute.sectionNumber = int.TryParse(items[4] ,out intValue) ? intValue : 0;
                itemAttribute.Channel_Height = items[5];
                itemAttribute.Channel_Width = items[6];
                itemAttribute.TubeArrangement = int.Parse(items[7]);
                itemAttribute.Water_Gas_Flow_Pattern = int.Parse(items[8]);
                itemAttribute.No_Rows = items[9];
                itemAttribute.No_Tubes_Row = items[10];
                itemAttribute.Longitudinal_Pitch = items[11];
                itemAttribute.Transverse_Pitch = items[12];
                itemAttribute.NO_Water_Carrying_Tubes = items[13];
                itemAttribute.Tube_Length = items[14];
                itemAttribute.Tube_Outer_Diameter = items[15];
                itemAttribute.Tube_Wall_Thickness = items[16];
                itemAttribute.Incidence_Angle = items[17];
                itemAttribute.Tubes_Material = int.Parse(items[18]);
                itemAttribute.Fin_Type = int.Parse(items[19]);
                itemAttribute.Fin_Height = items[20];
                itemAttribute.Fin_Thickness = items[21];
                itemAttribute.Fin_Density = items[22];
                itemAttribute.Fin_Uncut_Height = items[23];
                itemAttribute.Fin_Segment_Width = items[24];
                itemAttribute.Fin_Material = int.Parse(items[25]);
                itemAttribute.Water_Side_Founling_Factor = items[26];
                itemAttribute.Gas_Side_Founling_Factor = items[27];
                itemAttribute.Usage_Factor = items[28];
                element.attribute = itemAttribute;
               elements.Add(element);
            }


            return elements;
        }
    }
}
