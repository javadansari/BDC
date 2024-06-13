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
        private double doubleValue;
        private bool boolValue;

        public string filePath { get; set; }

        public Import(string filePath)
        {
            this.filePath = filePath;
        }
        public Inputs ImportInputs()
        {
            string line = File.ReadLines(filePath).Skip(4).Take(1).First();
            string[] items = line.Split(',');
            Inputs inputs = new Inputs();
            inputs.SH =int.Parse(items[1]);
            inputs.Eva =int.Parse(items[2]);
            inputs.Eco =int.Parse(items[3]);
            inputs.Bare =int.Parse(items[4]);
            inputs.Finned =int.Parse(items[5]);

            return inputs;
        }
        public Furnace ImportFurnace()
        {
            string line = File.ReadLines(filePath).Skip(9).Take(1).First();
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
            for (int i = 14; i <= 21; i++)
            {
              string line = File.ReadLines(filePath).Skip(i).Take(1).First();
               string[] items = line.Split(',');
               Element element = new Element();
                element.Id = i -13;
               ItemAttribute itemAttribute = new ItemAttribute();
                itemAttribute.active = bool.TryParse(items[1], out boolValue) ? boolValue : false;
                itemAttribute.sectionName = items[2];
                itemAttribute.section = int.TryParse(items[3], out intValue) ? intValue : 0;
                itemAttribute.sectionNumber = int.TryParse(items[4] ,out intValue) ? intValue : 0;
                itemAttribute.Channel_Height = items[5];
                itemAttribute.Channel_Width = items[6];
                itemAttribute.TubeArrangement = int.TryParse(items[7], out intValue) ? intValue : 0;
                itemAttribute.Water_Gas_Flow_Pattern = int.TryParse(items[8], out intValue) ? intValue : 0;
                itemAttribute.No_Rows = items[9];
                itemAttribute.No_Tubes_Row = items[10];
                itemAttribute.Longitudinal_Pitch = items[11];
                itemAttribute.Transverse_Pitch = items[12];
                itemAttribute.NO_Water_Carrying_Tubes = items[13];
                itemAttribute.Tube_Length = items[14];
                itemAttribute.Tube_Outer_Diameter = items[15];
                itemAttribute.Tube_Wall_Thickness = items[16];
                itemAttribute.Incidence_Angle = items[17];
                itemAttribute.Tubes_Material = int.TryParse(items[18], out intValue) ? intValue : 0;
                itemAttribute.Fin_Type = int.TryParse(items[19], out intValue) ? intValue : 0;
                itemAttribute.Fin_Height = items[20];
                itemAttribute.Fin_Thickness = items[21];
                itemAttribute.Fin_Density = items[22];
                itemAttribute.Fin_Uncut_Height = items[23];
                itemAttribute.Fin_Segment_Width = items[24];
                itemAttribute.Fin_Material = int.TryParse(items[25], out intValue) ? intValue : 0;
                itemAttribute.Water_Side_Founling_Factor = items[26];
                itemAttribute.Gas_Side_Founling_Factor = items[27];
                itemAttribute.Usage_Factor = items[28];
                element.attribute = itemAttribute;
                elements.Add(element);
            }


            return elements;
        }

        
       public Duct ImportDucts()
        {
            Duct duct = new Duct();
            for (int i = 26; i <= 26; i++)
            {
               string line = File.ReadLines(filePath).Skip(i).Take(1).First();
               string[] items = line.Split(',');
                duct.A1 = int.Parse(items[1]) ;
                duct.A2 = items[2] ;
                duct.A3 = items[3] ;
                duct.A4 = items[4] ;
                duct.A5 = int.Parse(items[5]);
                duct.A6 = items[6] ;
                duct.A7 = items[7] ;
                duct.A8 = items[8] ;
                duct.A9 = items[9] ;
                duct.A10 = items[10] ;
                duct.A11 = int.Parse(items[11]);
                duct.A12 =items[12];
                duct.A13 = items[13];
                duct.A14 = items[14];
                duct.A15 = items[15];

                duct.B1 = int.Parse(items[16]);
                duct.B2 = items[17];
                duct.B3 = items[18];
                duct.B4 = items[19];
                duct.B5 = int.Parse(items[20]);
                duct.B6 = items[21];
                duct.B7 = items[22];
                duct.B8 = items[23];
                duct.B9 = items[24];
                duct.B10 = items[25];
                duct.B11 = int.Parse(items[26]);
                duct.B12 =items[27];
                duct.B13 =items[28];
                duct.B14 =items[29];
                duct.B15 =items[30];


                duct.C1 = int.Parse(items[31]);
                duct.C2 = items[32];
                duct.C3 = items[33];
                duct.C4 = items[34];
                duct.C5 = int.Parse(items[35]);
                duct.C6 = items[36];
                duct.C7 = items[37];
                duct.C8 = items[38];
                duct.C9 = items[39];
                duct.C10 = items[40];
                duct.C11 = int.Parse(items[41]);
                duct.C12 =items[42];
                duct.C13 =items[43];
                duct.C14 =items[44];
                duct.C15 =items[45];

                duct.D1 = int.Parse(items[46]);
                duct.D2 = items[47];
                duct.D3 = items[48];
                duct.D4 = items[49];
                duct.D5 = int.Parse(items[50]);
                duct.D6 = items[51];
                duct.D7 = items[52];
                duct.D8 = items[53];
                duct.D9 = items[54];
                duct.D10 = items[55];
                duct.D11 = int.Parse(items[56]);
                duct.D12 =items[57];
                duct.D13 =items[58];
                duct.D14 =items[59];
                duct.D15 =items[60];

            }
            return duct;
        }
        public List<OilFuel> ImportOilFuels()
        {
            List<OilFuel> oilFuels = new List<OilFuel>();
            for (int i = 34; i <= 35; i++)
            {
                string line = File.ReadLines(filePath).Skip(i).Take(1).First();
                string[] items = line.Split(',');
                OilFuel oilFuel = new OilFuel();
                oilFuel.id = i - 33;
                oilFuel.name = items[2];
                oilFuel.active_ = int.Parse(items[3]);
                oilFuel.C = items[4];
                oilFuel.H = items[5];
                oilFuel.H2O_ = items[6];
                oilFuel.S = items[7];
                oilFuel.O = items[8];
                oilFuel.N = items[9];
                oilFuel.Total_ = items[10];
                oilFuel.FuelPressure_ = items[11];
                oilFuel.FuelTemperature_ = items[12];
                oilFuel. LHV_kj_kg_Calculated_ = items[13];


                oilFuels.Add(oilFuel);
            }
            return oilFuels;
        }
        public List<GasFuel> ImportGasFuels()
         {
            List<GasFuel> gasFuels = new List<GasFuel>();
            for (int i = 40; i <= 44; i++)
            {
                string line = File.ReadLines(filePath).Skip(i).Take(1).First();
                string[] items = line.Split(',');
                GasFuel gasFuel = new GasFuel();
                gasFuel.id = i - 39;
                gasFuel.name = items[2];
                gasFuel.active = int.TryParse(items[3], out intValue) ? intValue : 0;
                gasFuel.CH4 = items[4];
                gasFuel.C2H6 = items[5];
                gasFuel.C2H4 = items[6];
                gasFuel.C3H8 = items[7];
                gasFuel.C3H6 = items[8];
                gasFuel.N_C4H10 = items[9];
                gasFuel.ISO_C4H10 = items[10];
                gasFuel.C4H8 = items[11];
                gasFuel.ISO_C5H12 = items[12];
                gasFuel.N_C5H12 = items[13];
                gasFuel.C5H10 = items[14];
                gasFuel.C6H14 = items[15];
                gasFuel.N2 = items[16];
                gasFuel.CO = items[17];
                gasFuel.CO2 = items[18];
                gasFuel.H2O = items[19];
                gasFuel.H2S = items[20];
                gasFuel.H2 = items[21];
                gasFuel.He = items[22];
                gasFuel.O2 = items[23];
                gasFuel.Ar = items[24];
                gasFuel.Total = items[25];
                gasFuel.FuelPressure = items[26];
                gasFuel.FuelTemperature = items[27];
                gasFuel.LHV_kj_kg = items[28];
                gasFuel.LHV_kj_kg_Calculated = items[29];

                gasFuels.Add(gasFuel);
            }
            return gasFuels;
        }

        public List<Case> ImportCases()
        {
            List<Case> cases = new List<Case>();
            for (int i = 49; i <= 49; i++)
            {
               string line = File.ReadLines(filePath).Skip(i).Take(1).First();
               string[] items = line.Split(',');
               Case @case = new Case();
                @case.Id = i - 48;
                @case.Name = items[2];
               Process process =  new Process();
               process.id = i - 48;
               process.name = items[2];
               process.active = int.TryParse(items[3], out intValue) ? intValue : 0;
                process.Site_Atmospheric_Pressure = items[4];
               process.Ambien_Temperature = items[5];
               process.Relative_Humidity = items[6];
               process.GAS1 = items[7];
               process.GAS2 = items[8];
               process.GAS3 = items[9];
               process.GAS4 = items[10];
               process.GAS5 = items[11];
               process.OIL1 = items[12];
               process.OIL2 = items[13];
               process.Excess_Air = items[14];
               process.Atmozing_Steam_Flow = items[15];
               process.Atmozing_Steam_Pressure = items[16];
               process.Atmozing_Steam_Temperature = items[17];
               process.Fan_efficiency = items[18];
               process.Heat_exchange_ducty = items[19];
               process.Steam_Pressure_At_T_P = items[20];
               process.Main_steam_Pressue_Drop = items[21];
               process.Location_of_DESH = items[22];
               process.Steam_temperature_set_point_T_P = items[23];
               process.Min_SH_degree_at_desperheater_outlet = items[24];
               process.Feed_water_Pressure = items[25];
               process.Feed_water_Temperature = items[26];
               process.B_F_P_temperature_rise = items[27];
               process.Feed_water_piping_dp = items[28];
               process.Level_control_Valve_dp = items[29];
               process.Unburned_Loss = items[30];
               process.Radiation_Loss = items[31];
               process.Furnace_heat_absorption_Eff = items[32];
               process.Blowdown_flow = items[33];
               @case.process = process;

                cases.Add(@case);
            }
            return cases;
        }
        
    }
}
