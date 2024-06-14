using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BDC.Classes
{
    public class Process
    {
            private static int _idCounter = 1; // Static counter for generating IDs
            public int id { get; set; }
            public string name { get; set; } = "-";
            public int active { get; set; } = 0;
            public string Site_Atmospheric_Pressure { get; set; } = "-";
            public string Ambien_Temperature { get; set; } = "-";
            public string Relative_Humidity { get; set; } = "-";
            public string GAS1 { get; set; } = "-";
            public string GAS2 { get; set; } = "-";
            public string GAS3 { get; set; } = "-";
            public string GAS4 { get; set; } = "-";
            public string GAS5 { get; set; } = "-";
            public string OIL1 { get; set; } = "-";
            public string OIL2 { get; set; } = "-";
            public string Excess_Air { get; set; } = "-";
            public string Atmozing_Steam_Flow { get; set; } = "-";
            public string Atmozing_Steam_Pressure { get; set; } = "-";
            public string Atmozing_Steam_Temperature { get; set; } = "-";
            public string Fan_efficiency { get; set; } = "-";
            public string Heat_exchange_ducty { get; set; } = "-";
            public string Steam_Pressure_At_T_P { get; set; } = "-";
            public string Main_steam_Pressue_Drop { get; set; } = "-";
            public int Location_of_DESH { get; set; } = 0;
            public string Steam_temperature_set_point_T_P { get; set; } = "-";
            public string Min_SH_degree_at_desperheater_outlet { get; set; } = "-";
            public string Feed_water_Pressure { get; set; } = "-";
            public string Feed_water_Temperature { get; set; } = "-";
            public string B_F_P_temperature_rise { get; set; } = "-";
            public string Feed_water_piping_dp { get; set; } = "-";
            public string Level_control_Valve_dp { get; set; } = "-";
            public string Unburned_Loss { get; set; } = "-";
            public string Radiation_Loss { get; set; } = "-";
            public string Furnace_heat_absorption_Eff { get; set; } = "-";
            public string Blowdown_flow { get; set; } = "-";
        public Process()
        {
            id = _idCounter++; // Assign a new unique ID and increment the counter
        }
    }
}
