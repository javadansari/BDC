using BDC.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BDC.Forms
{
    /// <summary>
    /// Interaction logic for FormProcess.xaml
    /// </summary>
    public partial class FormProcess : Window
    {
        List<Case> Cases;
        MainWindow Main;
        public FormProcess(List<Case> cases,  MainWindow main)
        {
            InitializeComponent();
            Cases = cases;
            Main = main;
            getValue();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            Main.cases = setValue();
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private List<Case> setValue()
        {
            List<Case> newCases =  new List<Case>();
            foreach (Case @case in Cases)
            {
   
                @case.process = setProcess(@case.process);
                @case.Name = @case.process.name;
                newCases.Add(@case);

            }
            return newCases;
        }
        private Process setProcess(Process process)
        {

            process.Site_Atmospheric_Pressure = (FindName("Site_Atmospheric_Pressure_" + process.id) as TextBox).Text;
            process.Ambien_Temperature = (FindName("Ambien_Temperature_" + process.id) as TextBox).Text;
            process.Relative_Humidity = (FindName("Relative_Humidity_" + process.id) as TextBox).Text;
            process.GAS1 = (FindName("GAS1_" + process.id) as TextBox).Text;
            process.GAS2 = (FindName("GAS2_" + process.id) as TextBox).Text;
            process.GAS3 = (FindName("GAS3_" + process.id) as TextBox).Text;
            process.GAS4 = (FindName("GAS4_" + process.id) as TextBox).Text;
            process.GAS5 = (FindName("GAS5_" + process.id) as TextBox).Text;
            process.OIL1 = (FindName("OIL1_" + process.id) as TextBox).Text;
            process.OIL2 = (FindName("OIL2_" + process.id) as TextBox).Text;
            process.Excess_Air = (FindName("Excess_Air_" + process.id) as TextBox).Text;
            process.Atmozing_Steam_Flow = (FindName("Atmozing_Steam_Flow_" + process.id) as TextBox).Text;
            process.Atmozing_Steam_Pressure = (FindName("Atmozing_Steam_Pressure_" + process.id) as TextBox).Text;
            process.Atmozing_Steam_Temperature = (FindName("Atmozing_Steam_Temperature_" + process.id) as TextBox).Text;
            process.Fan_efficiency = (FindName("Fan_efficiency_" + process.id) as TextBox).Text;
            process.Heat_exchange_ducty = (FindName("Heat_exchange_ducty_" + process.id) as TextBox).Text;
            process.Steam_Pressure_At_T_P = (FindName("Steam_Pressure_At_T_P_" + process.id) as TextBox).Text;
            process.Main_steam_Pressue_Drop = (FindName("Main_steam_Pressue_Drop_" + process.id) as TextBox).Text;
            process.Location_of_DESH = (FindName("Location_of_DESH_" + process.id) as TextBox).Text;
            process.Steam_temperature_set_point_T_P = (FindName("Steam_temperature_set_point_T_P_" + process.id) as TextBox).Text;
            process.Min_SH_degree_at_desperheater_outlet = (FindName("Min_SH_degree_at_desperheater_outlet_" + process.id) as TextBox).Text;
            process.Feed_water_Pressure = (FindName("Feed_water_Pressure_" + process.id) as TextBox).Text;
            process.Feed_water_Temperature = (FindName("Feed_water_Temperature_" + process.id) as TextBox).Text;
            process.B_F_P_temperature_rise = (FindName("B_F_P_temperature_rise_" + process.id) as TextBox).Text;
            process.Feed_water_piping_dp = (FindName("Feed_water_piping_dp_" + process.id) as TextBox).Text;
            process.Level_control_Valve_dp = (FindName("Level_control_Valve_dp_" + process.id) as TextBox).Text;
            process.Unburned_Loss = (FindName("Unburned_Loss_" + process.id) as TextBox).Text;
            process.Radiation_Loss = (FindName("Radiation_Loss_" + process.id) as TextBox).Text;
            process.Furnace_heat_absorption_Eff = (FindName("Furnace_heat_absorption_Eff_" + process.id) as TextBox).Text;
            process.Blowdown_flow = (FindName("Blowdown_flow_" + process.id) as TextBox).Text;

            return process;

        }
        private void getValue()
        {
            foreach (Case @case in Cases)
            {
                Process process = @case.process;
           //     if (process.active == 1) (FindName("active" + process.id) as CheckBox).IsChecked = false;
                (FindName("stackPanel_" + process.id) as StackPanel).IsEnabled = true;
                (FindName("name_" + process.id) as TextBox).Text = @case.Name.ToString();
                (FindName("Site_Atmospheric_Pressure_" + process.id) as TextBox).Text = process.Site_Atmospheric_Pressure.ToString();
                (FindName("Ambien_Temperature_" + process.id) as TextBox).Text = process.Ambien_Temperature.ToString();
                (FindName("Relative_Humidity_" + process.id) as TextBox).Text = process.Relative_Humidity.ToString();
                (FindName("GAS1_" + process.id) as TextBox).Text = process.GAS1.ToString();
                (FindName("GAS2_" + process.id) as TextBox).Text = process.GAS2.ToString();
                (FindName("GAS3_" + process.id) as TextBox).Text = process.GAS3.ToString();
                (FindName("GAS4_" + process.id) as TextBox).Text = process.GAS4.ToString();
                (FindName("GAS5_" + process.id) as TextBox).Text = process.GAS5.ToString();
                (FindName("OIL1_" + process.id) as TextBox).Text = process.OIL1.ToString();
                (FindName("OIL2_" + process.id) as TextBox).Text = process.OIL2.ToString();
                (FindName("Excess_Air_" + process.id) as TextBox).Text = process.Excess_Air.ToString();
                (FindName("Atmozing_Steam_Flow_" + process.id) as TextBox).Text = process.Atmozing_Steam_Flow.ToString();
                (FindName("Atmozing_Steam_Pressure_" + process.id) as TextBox).Text = process.Atmozing_Steam_Pressure.ToString();
                (FindName("Atmozing_Steam_Temperature_" + process.id) as TextBox).Text = process.Atmozing_Steam_Temperature.ToString();
                (FindName("Fan_efficiency_" + process.id) as TextBox).Text = process.Fan_efficiency.ToString();
                (FindName("Heat_exchange_ducty_" + process.id) as TextBox).Text = process.Heat_exchange_ducty.ToString();
                (FindName("Steam_Pressure_At_T_P_" + process.id) as TextBox).Text = process.Steam_Pressure_At_T_P.ToString();
                (FindName("Main_steam_Pressue_Drop_" + process.id) as TextBox).Text = process.Main_steam_Pressue_Drop.ToString();
                (FindName("Location_of_DESH_" + process.id) as TextBox).Text = process.Location_of_DESH.ToString();
                (FindName("Steam_temperature_set_point_T_P_" + process.id) as TextBox).Text = process.Steam_temperature_set_point_T_P.ToString();
                (FindName("Min_SH_degree_at_desperheater_outlet_" + process.id) as TextBox).Text = process.Min_SH_degree_at_desperheater_outlet.ToString();
                (FindName("Feed_water_Pressure_" + process.id) as TextBox).Text = process.Feed_water_Pressure.ToString();
                (FindName("Feed_water_Temperature_" + process.id) as TextBox).Text = process.Feed_water_Temperature.ToString();
                (FindName("B_F_P_temperature_rise_" + process.id) as TextBox).Text = process.B_F_P_temperature_rise.ToString();
                (FindName("Feed_water_piping_dp_" + process.id) as TextBox).Text = process.Feed_water_piping_dp.ToString();
                (FindName("Level_control_Valve_dp_" + process.id) as TextBox).Text = process.Level_control_Valve_dp.ToString();
                (FindName("Unburned_Loss_" + process.id) as TextBox).Text = process.Unburned_Loss.ToString();
                (FindName("Radiation_Loss_" + process.id) as TextBox).Text = process.Radiation_Loss.ToString();
                (FindName("Furnace_heat_absorption_Eff_" + process.id) as TextBox).Text = process.Furnace_heat_absorption_Eff.ToString();
                (FindName("Blowdown_flow_" + process.id) as TextBox).Text = process.Blowdown_flow.ToString();



            }

        }
    }
}
