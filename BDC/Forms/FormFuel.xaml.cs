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

        private void getValue()
        {
            foreach (OilFuel oilFuel in OilFuels)
            {
              

            }
            foreach (GasFuel gasFuel in GasFuels)
            {
                (FindName("CH4" + gasFuel.id) as TextBox).Text = gasFuel.CH4.ToString();

            }

        }
    }
}
