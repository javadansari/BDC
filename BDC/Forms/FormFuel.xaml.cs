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
    /// Interaction logic for FormFuel.xaml
    /// </summary>
    public partial class FormFuel : Window
    {
        List<OilFuel> OilFuels;
        List<GasFuel> GasFuels;
        MainWindow Main;
        public FormFuel(List<OilFuel> oilFuels, List<GasFuel> gasFuels, MainWindow main)
        {
            InitializeComponent();
            OilFuels = oilFuels;
            GasFuels = gasFuels;
            Main = main;
            getValue();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            setValue();
            Main.oilFuels = OilFuels;
            Main.gasFuels = GasFuels;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void setValue()
        {

            for (int i = 1; i < 3; i++)
            {
                OilFuel oilFuel = new OilFuel();
                oilFuel.id = i;
                OilFuels.Add(setOilFuel(oilFuel));

            }
            for (int i = 1; i < 6; i++)
            {
                GasFuel gasFuel = new GasFuel();
                gasFuel.id = i;
                GasFuels.Add(setGasFuel(gasFuel));

            }

        }

        private OilFuel setOilFuel(OilFuel oilFuel)
        {
            switch (oilFuel.id)
            {
                case 1:
                    oilFuel.name = "OIL#1";
                    break;
                case 2:
                    oilFuel.name = "OIL#2";
                    break;
                default:
                    break;
            }
            CheckBox check = FindName("active_" + oilFuel.id) as CheckBox;
            if (check.IsChecked == true) oilFuel.active_ = 0; else oilFuel.active_ = 1;
            oilFuel.C = (FindName("C" + oilFuel.id) as TextBox).Text;
            oilFuel.H = (FindName("H" + oilFuel.id) as TextBox).Text;
            oilFuel.H2O_ = (FindName("H2O_" + oilFuel.id) as TextBox).Text;
            oilFuel.S = (FindName("S" + oilFuel.id) as TextBox).Text;
            oilFuel.O = (FindName("O" + oilFuel.id) as TextBox).Text;
            oilFuel.Total_ = (FindName("Total_" + oilFuel.id) as TextBox).Text;
            oilFuel.FuelPressure_ = (FindName("FuelPressure_" + oilFuel.id) as TextBox).Text;
            oilFuel.FuelTemperature_ = (FindName("FuelTemperature_" + oilFuel.id) as TextBox).Text;
            oilFuel.LHV_kj_kg_Calculated_ = (FindName("LHV_kj_kg_Calculated_" + oilFuel.id) as TextBox).Text;
            return oilFuel;
        }
        private GasFuel setGasFuel(GasFuel gasFuel)
        {
            switch (gasFuel.id)
            {
                case 1:
                    gasFuel.name = "GAS#1";
                    break;
                case 2:
                    gasFuel.name = "GAS#2";
                    break;
                case 3:
                    gasFuel.name = "GAS#3";
                    break;
                case 4:
                    gasFuel.name = "GAS#4";
                    break;
                case 5:
                    gasFuel.name = "GAS#5";
                    break;
                default:
                    break;
            }
            CheckBox check = FindName("active" + gasFuel.id) as CheckBox;
            if (check.IsChecked == true) gasFuel.active = 0; else gasFuel.active = 1;
            gasFuel.CH4 = (FindName("CH4" + gasFuel.id) as TextBox).Text;
            gasFuel.C2H6 = (FindName("C2H6" + gasFuel.id) as TextBox).Text;
            gasFuel.C2H4 = (FindName("C2H4" + gasFuel.id) as TextBox).Text;
            gasFuel.C3H8 = (FindName("C3H8" + gasFuel.id) as TextBox).Text;
            gasFuel.C3H6 = (FindName("C3H6" + gasFuel.id) as TextBox).Text;
            gasFuel.N_C4H10 = (FindName("N_C4H10" + gasFuel.id) as TextBox).Text;
            gasFuel.ISO_C4H10 = (FindName("ISO_C4H10" + gasFuel.id) as TextBox).Text;
            gasFuel.C4H8 = (FindName("C4H8" + gasFuel.id) as TextBox).Text;
            gasFuel.ISO_C5H12 = (FindName("ISO_C5H12" + gasFuel.id) as TextBox).Text;
            gasFuel.N_C5H12 = (FindName("N_C5H12" + gasFuel.id) as TextBox).Text;
            gasFuel.C5H10 = (FindName("C5H10" + gasFuel.id) as TextBox).Text;
            gasFuel.C6H14 = (FindName("C6H14" + gasFuel.id) as TextBox).Text;
            gasFuel.N2 = (FindName("N2" + gasFuel.id) as TextBox).Text;
            gasFuel.CO = (FindName("CO" + gasFuel.id) as TextBox).Text;
            gasFuel.CO2 = (FindName("CO2" + gasFuel.id) as TextBox).Text;
            gasFuel.H2O = (FindName("H2O" + gasFuel.id) as TextBox).Text;
            gasFuel.H2S = (FindName("H2S" + gasFuel.id) as TextBox).Text;
            gasFuel.H2 = (FindName("H2" + gasFuel.id) as TextBox).Text;
            gasFuel.He = (FindName("He" + gasFuel.id) as TextBox).Text;
            gasFuel.O2 = (FindName("O2" + gasFuel.id) as TextBox).Text;
            gasFuel.Ar = (FindName("Ar" + gasFuel.id) as TextBox).Text;
            gasFuel.Total = (FindName("Total" + gasFuel.id) as TextBox).Text;
            gasFuel.FuelPressure = (FindName("FuelPressure" + gasFuel.id) as TextBox).Text;
            gasFuel.FuelTemperature = (FindName("FuelTemperature" + gasFuel.id) as TextBox).Text;
            gasFuel.LHV_kj_kg = (FindName("LHV_kj_kg" + gasFuel.id) as TextBox).Text;
            gasFuel.LHV_kj_kg_Calculated = (FindName("LHV_kj_kg_Calculated" + gasFuel.id) as TextBox).Text;
            return gasFuel;
        }
        private void getValue()
        {
            foreach (OilFuel oilFuel in OilFuels)
            {
                if (oilFuel.active_ == 1) (FindName("active_" + oilFuel.id) as CheckBox).IsChecked = false;
                else (FindName("active_" + oilFuel.id) as CheckBox).IsChecked = true;
                (FindName("C" + oilFuel.id) as TextBox).Text = oilFuel.C.ToString();
                (FindName("H" + oilFuel.id) as TextBox).Text = oilFuel.H.ToString();
                (FindName("H2O_" + oilFuel.id) as TextBox).Text = oilFuel.H2O_.ToString();
                (FindName("S" + oilFuel.id) as TextBox).Text = oilFuel.S.ToString();
                (FindName("O" + oilFuel.id) as TextBox).Text = oilFuel.O.ToString();
                (FindName("Total_" + oilFuel.id) as TextBox).Text = oilFuel.Total_.ToString();
                (FindName("FuelPressure_" + oilFuel.id) as TextBox).Text = oilFuel.FuelPressure_.ToString();
                (FindName("FuelTemperature_" + oilFuel.id) as TextBox).Text = oilFuel.FuelTemperature_.ToString();
                (FindName("LHV_kj_kg_Calculated_" + oilFuel.id) as TextBox).Text = oilFuel.LHV_kj_kg_Calculated_.ToString();
            }
            foreach (GasFuel gasFuel in GasFuels)
            {
                if (gasFuel.active == 1) (FindName("active" + gasFuel.id) as CheckBox).IsChecked = false;
                else (FindName("active" + gasFuel.id) as CheckBox).IsChecked = true;
                (FindName("CH4" + gasFuel.id) as TextBox).Text = gasFuel.CH4.ToString();
                (FindName("C2H6" + gasFuel.id) as TextBox).Text = gasFuel.C2H6.ToString();
                (FindName("C2H4" + gasFuel.id) as TextBox).Text = gasFuel.C2H4.ToString();
                (FindName("C3H8" + gasFuel.id) as TextBox).Text = gasFuel.C3H8.ToString();
                (FindName("C3H6" + gasFuel.id) as TextBox).Text = gasFuel.C3H6.ToString();
                (FindName("N_C4H10" + gasFuel.id) as TextBox).Text = gasFuel.N_C4H10.ToString();
                (FindName("ISO_C4H10" + gasFuel.id) as TextBox).Text = gasFuel.ISO_C4H10.ToString();
                (FindName("C4H8" + gasFuel.id) as TextBox).Text = gasFuel.C4H8.ToString();
                (FindName("ISO_C5H12" + gasFuel.id) as TextBox).Text = gasFuel.ISO_C5H12.ToString();
                (FindName("N_C5H12" + gasFuel.id) as TextBox).Text = gasFuel.N_C5H12.ToString();
                (FindName("C5H10" + gasFuel.id) as TextBox).Text = gasFuel.C5H10.ToString();
                (FindName("C6H14" + gasFuel.id) as TextBox).Text = gasFuel.C6H14.ToString();
                (FindName("N2" + gasFuel.id) as TextBox).Text = gasFuel.N2.ToString();
                (FindName("CO" + gasFuel.id) as TextBox).Text = gasFuel.CO.ToString();
                (FindName("CO2" + gasFuel.id) as TextBox).Text = gasFuel.CO2.ToString();
                (FindName("H2O" + gasFuel.id) as TextBox).Text = gasFuel.H2O.ToString();
                (FindName("H2S" + gasFuel.id) as TextBox).Text = gasFuel.H2S.ToString();
                (FindName("H2" + gasFuel.id) as TextBox).Text = gasFuel.H2.ToString();
                (FindName("He" + gasFuel.id) as TextBox).Text = gasFuel.He.ToString();
                (FindName("O2" + gasFuel.id) as TextBox).Text = gasFuel.O2.ToString();
                (FindName("Ar" + gasFuel.id) as TextBox).Text = gasFuel.Ar.ToString();
                (FindName("Total" + gasFuel.id) as TextBox).Text = gasFuel.Total.ToString();
                (FindName("FuelPressure" + gasFuel.id) as TextBox).Text = gasFuel.FuelPressure.ToString();
                (FindName("FuelTemperature" + gasFuel.id) as TextBox).Text = gasFuel.FuelTemperature.ToString();
                (FindName("LHV_kj_kg" + gasFuel.id) as TextBox).Text = gasFuel.LHV_kj_kg.ToString();
                (FindName("LHV_kj_kg_Calculated" + gasFuel.id) as TextBox).Text = gasFuel.LHV_kj_kg_Calculated.ToString();

            }

        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {

            setValue();
            foreach (GasFuel gasFuel in GasFuels)
            {
                if (FindName("CH4" + gasFuel.id) as TextBox).Text == "-" ;
                gasFuel.C2H6 = (FindName("C2H6" + gasFuel.id) as TextBox).Text;
                gasFuel.C2H4 = (FindName("C2H4" + gasFuel.id) as TextBox).Text;
                gasFuel.C3H8 = (FindName("C3H8" + gasFuel.id) as TextBox).Text;
                gasFuel.C3H6 = (FindName("C3H6" + gasFuel.id) as TextBox).Text;
                gasFuel.N_C4H10 = (FindName("N_C4H10" + gasFuel.id) as TextBox).Text;
                gasFuel.ISO_C4H10 = (FindName("ISO_C4H10" + gasFuel.id) as TextBox).Text;
                gasFuel.C4H8 = (FindName("C4H8" + gasFuel.id) as TextBox).Text;
                gasFuel.ISO_C5H12 = (FindName("ISO_C5H12" + gasFuel.id) as TextBox).Text;
                gasFuel.N_C5H12 = (FindName("N_C5H12" + gasFuel.id) as TextBox).Text;
                gasFuel.C5H10 = (FindName("C5H10" + gasFuel.id) as TextBox).Text;
                gasFuel.C6H14 = (FindName("C6H14" + gasFuel.id) as TextBox).Text;
                gasFuel.N2 = (FindName("N2" + gasFuel.id) as TextBox).Text;
                gasFuel.CO = (FindName("CO" + gasFuel.id) as TextBox).Text;
                gasFuel.CO2 = (FindName("CO2" + gasFuel.id) as TextBox).Text;
                gasFuel.H2O = (FindName("H2O" + gasFuel.id) as TextBox).Text;
                gasFuel.H2S = (FindName("H2S" + gasFuel.id) as TextBox).Text;
                gasFuel.H2 = (FindName("H2" + gasFuel.id) as TextBox).Text;
                gasFuel.He = (FindName("He" + gasFuel.id) as TextBox).Text;
                gasFuel.O2 = (FindName("O2" + gasFuel.id) as TextBox).Text;
                gasFuel.Ar = (FindName("Ar" + gasFuel.id) as TextBox).Text;
                gasFuel.Total = (FindName("Total" + gasFuel.id) as TextBox).Text;
                gasFuel.FuelPressure = (FindName("FuelPressure" + gasFuel.id) as TextBox).Text;
                gasFuel.FuelTemperature = (FindName("FuelTemperature" + gasFuel.id) as TextBox).Text;
                gasFuel.LHV_kj_kg = (FindName("LHV_kj_kg" + gasFuel.id) as TextBox).Text;
                gasFuel.LHV_kj_kg_Calculated = (FindName("LHV_kj_kg_Calculated" + gasFuel.id) as TextBox).Text;

                double all1 = 0;
                double all2 = 0;
              //  all1 = gasFuel.CH4 

              }
        }
    }
}
