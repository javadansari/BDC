using BDC.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                if (gasFuel.active == 0)
                {
                    double total = 0;
                    double calc1 = 0;
                    double calc2 = 0;
                    bool IsNumericAndLessThanEqualTo100(string input)
                    {
                        double number;
                        bool isNumeric = double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out number);
                 //       bool isNumeric = double.TryParse(input, out number);
                        return isNumeric && number <= 100;
                    }

                    string[] components = new string[] { "CH4", "C2H6", "C2H4", "C3H8", "C3H6", "N_C4H10", "ISO_C4H10", "C4H8", "ISO_C5H12", "N_C5H12", "C5H10", "C6H14", "N2", "CO", "CO2", "H2O", "H2S", "H2", "He", "O2", "Ar" };
                    foreach (var component in components)
                    {
                        TextBox textBox = FindName(component + gasFuel.id) as TextBox;
                        if (textBox != null)
                        {
                            if (!IsNumericAndLessThanEqualTo100(textBox.Text))
                            {
                                textBox.Text = "0";
                            }
                          
                            else {
                                double thisCalc = double.Parse(textBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
                                total += thisCalc;
                                if (component.ToString() == "CH4") calc1 += thisCalc * 0.00374;
                                else if (component.ToString() == "C2H6") calc1 += thisCalc * 30.06964;
                                else if (component.ToString() == "C2H4") calc1 += thisCalc * 28.05376;
                                else if (component.ToString() == "C3H8") calc1 += thisCalc * 44.09652;
                                else if (component.ToString() == "C3H6") calc1 += thisCalc * 42.08064;
                                else if (component.ToString() == "N_C4H10") calc1 += thisCalc * 58.1234;
                                else if (component.ToString() == "ISO_C4H10") calc1 += thisCalc * 58.1234;
                                else if (component.ToString() == "C4H8") calc1 += thisCalc * 56.10752;
                                else if (component.ToString() == "ISO_C5H12") calc1 += thisCalc * 72.15028;
                                else if (component.ToString() == "N_C5H12") calc1 += thisCalc * 72.15028;
                                else if (component.ToString() == "C5H10") calc1 += thisCalc * 70.1344;
                                else if (component.ToString() == "C6H14") calc1 += thisCalc * 86.17716;
                                else if (component.ToString() == "N2") calc1 += thisCalc * 28.01348;
                                else if (component.ToString() == "CO") calc1 += thisCalc * 28.0104;
                                else if (component.ToString() == "CO2") calc1 += thisCalc * 44.0098;
                                else if (component.ToString() == "H2O") calc1 += thisCalc * 18.01528;
                                else if (component.ToString() == "H2S") calc1 += thisCalc * 34.08188;
                                else if (component.ToString() == "H2") calc1 += thisCalc * 2.01588;
                                else if (component.ToString() == "He") calc1 += thisCalc * 4.0026;
                                else if (component.ToString() == "O2") calc1 += thisCalc * 31.9988;
                                else if (component.ToString() == "Ar") calc1 += thisCalc * 39.948;

                                if (component.ToString() == "CH4") calc2 += thisCalc * 0.00374 * 50.016;
                                else if (component.ToString() == "C2H6") calc2 += thisCalc * 30.06964 * 47.525;
                                else if (component.ToString() == "C2H4") calc2 += thisCalc * 28.05376 * 47.167;
                                else if (component.ToString() == "C3H8") calc2 += thisCalc * 44.09652 *46.341;
                                else if (component.ToString() == "C3H6") calc2 += thisCalc * 42.08064 *45.771;
                                else if (component.ToString() == "N_C4H10") calc2 += thisCalc * 58.1234 *45.559;
                                else if (component.ToString() == "ISO_C4H10") calc2 += thisCalc * 58.1234 *45.727;
                                else if (component.ToString() == "C4H8") calc2 += thisCalc * 56.10752* 45.241;
                                else if (component.ToString() == "ISO_C5H12") calc2 += thisCalc * 72.15028* 45.255;
                                else if (component.ToString() == "N_C5H12") calc2 += thisCalc * 72.15028* 45.352;
                                else if (component.ToString() == "C5H10") calc2 += thisCalc * 70.1344 *44.957;
                                else if (component.ToString() == "C6H14") calc2 += thisCalc * 86.17716 *45.015;
                                else if (component.ToString() == "N2") calc2 += thisCalc * 28.01348 * 0;
                                else if (component.ToString() == "CO") calc2 += thisCalc * 28.0104 *10.099;
                                else if (component.ToString() == "CO2") calc2 += thisCalc * 44.0098 *0;
                                else if (component.ToString() == "H2O") calc2 += thisCalc * 18.01528 *0 ;
                                else if (component.ToString() == "H2S") calc2 += thisCalc * 34.08188 *15.198;
                                else if (component.ToString() == "H2") calc2 += thisCalc * 2.01588 *119.943;
                                else if (component.ToString() == "He") calc2 += thisCalc * 4.0026 * 0;
                                else if (component.ToString() == "O2") calc2 += thisCalc * 31.9988 * 0;
                                else if (component.ToString() == "Ar") calc2 += thisCalc * 39.948 * 0;





                            }
                            gasFuel.GetType().GetProperty(component).SetValue(gasFuel, textBox.Text);
                        }
                    }

                      (FindName("Total" + gasFuel.id) as TextBox).Text = total.ToString();
                     if (total != 100) (FindName("Total" + gasFuel.id) as TextBox).Background = Brushes.IndianRed;
                    else (FindName("Total" + gasFuel.id) as TextBox).Background = Brushes.Green;

                    calc1 = Math.Round(calc1, 2);
                    calc2 = Math.Round(calc2, 2);
                    (FindName("Molcular" + gasFuel.id) as TextBox).Text = calc1.ToString();
                    (FindName("LHV_kj_kg_Calculated" + gasFuel.id) as TextBox).Text = calc2.ToString();

                    double density = calc1 / 22.414;
                    (FindName("Density" + gasFuel.id) as TextBox).Text = density.ToString();

                }
                else (FindName("Total" + gasFuel.id) as TextBox).Background = null;
                //  all1 = gasFuel.CH4 

            }
        }
    }
}
