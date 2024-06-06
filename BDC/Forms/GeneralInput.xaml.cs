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
    /// Interaction logic for GeneralInput.xaml
    /// </summary>
    public partial class GeneralInput : Window
    {
        Inputs Inputs;
        MainWindow Main;
        public GeneralInput(Inputs inputs, MainWindow main)
        {
            InitializeComponent();
            Inputs = inputs;
            Main = main;
            getValue();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            setValue();
            Main.inputs = Inputs;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void getValue()
        {
            Input_1.SelectedIndex = Inputs.SH;
            Input_2.SelectedIndex = Inputs.Eva;
            Input_3.SelectedIndex = Inputs.Eco;
            Input_4.SelectedIndex = Inputs.Bare;
            Input_5.SelectedIndex = Inputs.Finned;
        }
        private void setValue()
        {
            Inputs.SH = Input_1.SelectedIndex;
            Inputs.Eva = Input_2.SelectedIndex;
            Inputs.Eco = Input_3.SelectedIndex;
            Inputs.Bare = Input_4.SelectedIndex;
            Inputs.Finned = Input_5.SelectedIndex;
        }
    }
}
