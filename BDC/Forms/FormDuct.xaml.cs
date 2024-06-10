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
           
            
            if (A1.IsChecked == true) Duct.A1 = 1;
            Duct.A2 = A2.Text;
            Duct.A3 = A3.Text;
            Duct.A4 = A4.Text;
            if (A5.IsChecked == true) Duct.A5 = 1;
            Duct.A6 = A6.Text;
            Duct.A7 = A7.Text;
            Duct.A8 = A8.Text;
            Duct.A9 = A9.Text;
            if (A10.IsChecked == true) Duct.A10 = 1;
            Duct.A11 = A11.Text;
            Duct.A12 = A12.Text;
            Duct.A13 = A13.Text;

            if (B1.IsChecked == true) Duct.B1 = 1;
            Duct.B2 = B2.Text;
            Duct.B3 = B3.Text;
            Duct.B4 = B4.Text;
            if (B5.IsChecked == true) Duct.B5 = 1;
            Duct.B6 = B6.Text;
            Duct.B7 = B7.Text;
            Duct.B8 = B8.Text;
            Duct.B9 = B9.Text;
            if (B10.IsChecked == true) Duct.B10 = 1;
            Duct.B11 = B11.Text;
            Duct.B12 = B12.Text;
            Duct.B13 = B13.Text;


            if (C1.IsChecked == true) Duct.C1 = 1;
            Duct.C2 = C2.Text;
            Duct.C3 = C3.Text;
            Duct.C4 = C4.Text;
            if (C5.IsChecked == true) Duct.C5 = 1;
            Duct.C6 = C6.Text;
            Duct.C7 = C7.Text;
            Duct.C8 = C8.Text;
            Duct.C9 = C9.Text;
            if (C10.IsChecked == true) Duct.C10 = 1;
            Duct.C11 = C11.Text;
            Duct.C12 = C12.Text;
            Duct.C13 = C13.Text; 


            if (D1.IsChecked == true) Duct.D1 = 1;
            Duct.D2 = D2.Text;
            Duct.D3 = D3.Text;
            Duct.D4 = D4.Text;
            if (D5.IsChecked == true) Duct.D5 = 1;
            Duct.D6 = D6.Text;
            Duct.D7 = D7.Text;
            Duct.D8 = D8.Text;
            Duct.D9 = D9.Text;
            if (D10.IsChecked == true) Duct.D10 = 1;
            Duct.D11 = D11.Text;
            Duct.D12 = D12.Text;
            Duct.D13 = D13.Text;

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
