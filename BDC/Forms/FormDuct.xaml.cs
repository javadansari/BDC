using BDC.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace BDC.Forms
{
    /// <summary>
    /// Interaction logic for FormDuct.xaml
    /// </summary>
    public partial class FormDuct : Window
    {
        Duct Duct;
        MainWindow Main;
        public FormDuct(Duct duct, MainWindow main)
        {
            InitializeComponent();

            Duct = duct;
            Main = main;
            getValue();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            setValue();
            Main.duct = Duct;
            this.Close();
        }
        private void setValue()
        {
            bool IsNumericAndLessThanEqualTo100(string input)
            {
                double number;
                bool isNumeric = double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out number);
                //       bool isNumeric = double.TryParse(input, out number);
                return isNumeric && number <= 100;
            }

            for (int i = 1; i < 14; i++)
            {
                TextBox textBox = FindName("A" + i) as TextBox; if (textBox != null)  if (!IsNumericAndLessThanEqualTo100(textBox.Text))    textBox.Text = "0";
                 textBox = FindName("B" + i) as TextBox; if (textBox != null)  if (!IsNumericAndLessThanEqualTo100(textBox.Text))    textBox.Text = "0";
                 textBox = FindName("C" + i) as TextBox; if (textBox != null)  if (!IsNumericAndLessThanEqualTo100(textBox.Text))    textBox.Text = "0";
                 textBox = FindName("D" + i) as TextBox; if (textBox != null)  if (!IsNumericAndLessThanEqualTo100(textBox.Text))    textBox.Text = "0";
   

            }
            
            if (A1.IsChecked == true) Duct.A1 = 1;
            Duct.A2 = double.Parse(A2.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.A3 = double.Parse(A3.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.A4 = double.Parse(A4.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            if (A5.IsChecked == true) Duct.A5 = 1;
            Duct.A6 = double.Parse(A6.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.A7 = double.Parse(A7.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.A8 = double.Parse(A8.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.A9 = double.Parse(A9.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            if (A10.IsChecked == true) Duct.A10 = 1;
            Duct.A11 = double.Parse(A11.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.A12 = double.Parse(A12.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.A13 = double.Parse(A13.Text, NumberStyles.Any, CultureInfo.InvariantCulture);

            if (B1.IsChecked == true) Duct.B1 = 1;
            Duct.B2 = double.Parse(B2.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.B3 = double.Parse(B3.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.B4 = double.Parse(B4.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            if (B5.IsChecked == true) Duct.B5 = 1;
            Duct.B6 = double.Parse(B6.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.B7 = double.Parse(B7.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.B8 = double.Parse(B8.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.B9 = double.Parse(B9.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            if (B10.IsChecked == true) Duct.B10 = 1;
            Duct.B11 = double.Parse(B11.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.B12 = double.Parse(B12.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.B13 = double.Parse(B13.Text, NumberStyles.Any, CultureInfo.InvariantCulture);


            if (C1.IsChecked == true) Duct.C1 = 1;
            Duct.C2 = double.Parse(C2.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.C3 = double.Parse(C3.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.C4 = double.Parse(C4.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            if (C5.IsChecked == true) Duct.C5 = 1;
            Duct.C6 = double.Parse(C6.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.C7 = double.Parse(C7.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.C8 = double.Parse(C8.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.C9 = double.Parse(C9.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            if (C10.IsChecked == true) Duct.C10 = 1;
            Duct.C11 = double.Parse(C11.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.C12 = double.Parse(C12.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.C13 = double.Parse(C13.Text, NumberStyles.Any, CultureInfo.InvariantCulture); 


            if (D1.IsChecked == true) Duct.D1 = 1;
            Duct.D2 = double.Parse(D2.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.D3 = double.Parse(D3.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.D4 = double.Parse(D4.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            if (D5.IsChecked == true) Duct.D5 = 1;
            Duct.D6 = double.Parse(D6.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.D7 = double.Parse(D7.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.D8 = double.Parse(D8.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.D9 = double.Parse(D9.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            if (D10.IsChecked == true) Duct.D10 = 1;
            Duct.D11 = double.Parse(D11.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.D12 = double.Parse(D12.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            Duct.D13 = double.Parse(D13.Text, NumberStyles.Any, CultureInfo.InvariantCulture);

        }
            private void getValue()
        {
            if (Duct.A1 == 1) A1.IsChecked = true;
            A2.Text = Duct.A2.ToString();
            A3.Text = Duct.A3.ToString();
            A4.Text = Duct.A4.ToString();
            if (Duct.A5 == 1) A5.IsChecked = true;
            A6.Text = Duct.A6.ToString();
            A7.Text = Duct.A7.ToString();
            A8.Text = Duct.A8.ToString();
            A9.Text = Duct.A9.ToString();
            if (Duct.A10 == 1) A10.IsChecked = true;
            A11.Text = Duct.A11.ToString();
            A12.Text = Duct.A12.ToString();
            A13.Text = Duct.A13.ToString();

            if (Duct.B1 == 1) B1.IsChecked = true;
            B2.Text = Duct.B2.ToString();
            B3.Text = Duct.B3.ToString();
            B4.Text = Duct.B4.ToString();
            if (Duct.B5 == 1) B5.IsChecked = true;
            B6.Text = Duct.B6.ToString();
            B7.Text = Duct.B7.ToString();
            B8.Text = Duct.B8.ToString();
            B9.Text = Duct.B9.ToString();
            if (Duct.B10 == 1) B10.IsChecked = true;
            B11.Text = Duct.B11.ToString();
            B12.Text = Duct.B12.ToString();
            B13.Text = Duct.B13.ToString();


            if (Duct.C1 == 1) C1.IsChecked = true;
            C2.Text = Duct.C2.ToString();
            C3.Text = Duct.C3.ToString();
            C4.Text = Duct.C4.ToString();
            if (Duct.C5 == 1) C5.IsChecked = true;
            C6.Text = Duct.C6.ToString();
            C7.Text = Duct.C7.ToString();
            C8.Text = Duct.C8.ToString();
            C9.Text = Duct.C9.ToString();
            if (Duct.C10 == 1) C10.IsChecked = true;
            C11.Text = Duct.C11.ToString();
            C12.Text = Duct.C12.ToString();
            C13.Text = Duct.C13.ToString();


            if (Duct.D1 == 1) D1.IsChecked = true;
            D2.Text = Duct.D2.ToString();
            D3.Text = Duct.D3.ToString();
            D4.Text = Duct.D4.ToString();
            if (Duct.D5 == 1) D5.IsChecked = true;
            D6.Text = Duct.D6.ToString();
            D7.Text = Duct.D7.ToString();
            D8.Text = Duct.D8.ToString();
            D9.Text = Duct.D9.ToString();
            if (Duct.D10 == 1) D10.IsChecked = true;
            D11.Text = Duct.D11.ToString();
            D12.Text = Duct.D12.ToString();
            D13.Text = Duct.D13.ToString();

        }


    }
}
