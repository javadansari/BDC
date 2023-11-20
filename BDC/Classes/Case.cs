using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BDC.Classes
{
    public class Case
    {
        public int Id { get; private set; }
        public string Name { get; set; }


        [DisplayName("Ambient Condition")]
        public string Ambient_Condition { get; set; } = "-";

        [DisplayName("Site Atmospheric Pressure")]
        public string Site_Atmospheric_Pressure { get; set; } = "-";

        [DisplayName("Ambient Temperature")]
        public string Ambient_Temperature { get; set; } = "-";

        [DisplayName("Relative Humidity")]
        public string Relative_Humidity { get; set; } = "-";

        [DisplayName("Combustion")]
        public string Combustion { get; set; } = "-";

        [DisplayName("GAS#1")]
        public string GAS1 { get; set; } = "-";

        [DisplayName("GAS#2")]
        public string GAS2 { get; set; } = "-";

        [DisplayName("GAS#3")]
        public string GAS3 { get; set; } = "-";

        [DisplayName("GAS#4")]
        public string GAS4 { get; set; } = "-";

        [DisplayName("GAS#5")]
        public string GAS5 { get; set; } = "-";

        [DisplayName("OIL#1")]
        public string OIL1 { get; set; } = "-";

        [DisplayName("OIL#2")]
        public string OIL2 { get; set; } = "-";

        [DisplayName("Excess Air")]
        public string Excess_Air { get; set; } = "-";

        [DisplayName("Atmozing Steam Flow")]
        public string Atmozing_Steam_Flow { get; set; } = "-";

        [DisplayName("Atmozing Steam Pressure")]
        public string Atmozing_Steam_Pressure { get; set; } = "-";

        [DisplayName("Atmozing Steam Temperature")]
        public string Atmozing_Steam_Temperature { get; set; } = "-";

        [DisplayName("F.D.F")]
        public string FDF { get; set; } = "-";

        [DisplayName("Fan efficiency")]
        public string Fan_efficiency { get; set; } = "-";

        [DisplayName("Heat exchange ducty")]
        public string Heat_exchange_ducty { get; set; } = "-";

        [DisplayName("Steam Outlet")]
        public string Steam_Outlet { get; set; } = "-";

        [DisplayName("Steam Pressure @ T.P")]
        public string Steam_Pressure_TP { get; set; } = "-";

        [DisplayName("Main steam Pressue Drop")]
        public string Main_steam_Pressue_Drop { get; set; } = "-";

        [DisplayName("Desuperheater")]
        public string Desuperheater { get; set; } = "-";

        [DisplayName("Location of DESH")]
        public string Location_of_DESH { get; set; } = "-";

        [DisplayName("Steam temperature set point & T.P")]
        public string Steam_temperature_set_point_TP { get; set; } = "-";

        [DisplayName("Min SH degree at desperheater outlet")]
        public string Min_SH_degree_at_desperheater_outlet { get; set; } = "-";

        [DisplayName("Feed water")]
        public string Feed_water { get; set; } = "-";

        [DisplayName("Feed water Pressure")]
        public string Feed_water_Pressure { get; set; } = "-";

        [DisplayName("Feed water Temperature")]
        public string Feed_water_Temperature { get; set; } = "-";

        [DisplayName("B.F.P temperature rise")]
        public string BFP_temperature_rise { get; set; } = "-";

        [DisplayName("Feed water piping dp")]
        public string Feed_water_piping_dp { get; set; } = "-";

        [DisplayName("Level control Valve dp")]
        public string Level_control_Valve_dp { get; set; } = "-";

        [DisplayName("Losses")]
        public string Losses { get; set; } = "-";

        [DisplayName("Unburned Loss")]
        public string Unburned_Loss { get; set; } = "-";

        [DisplayName("Radiation Loss")]
        public string Radiation_Loss { get; set; } = "-";

        [DisplayName("Furnace heat absorption Eff")]
        public string Furnace_heat_absorption_Eff { get; set; } = "-";

        [DisplayName("Blowdown")]
        public string Blowdown { get; set; } = "-";

        [DisplayName("Blowdown flow")]
        public string Blowdown_flow { get; set; } = "-";





    }
}
