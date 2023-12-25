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
using System.Xml.Linq;

namespace BDC.Forms
{
    /// <summary>
    /// Interaction logic for FormDuct.xaml
    /// </summary>
    public partial class FormDuct : Window
    {
        List<Duct> Ducts;
        MainWindow Main;
        public FormDuct(List<Duct> ducts, MainWindow main)
        {

            InitializeComponent();

            Ducts = ducts;
            Main = main;
            getValue();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            setValue();
            Main.ducts = Ducts;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void setValue()
        {

            for (int i = 1; i < 5; i++)
            {
                Duct duct = new Duct();
                duct.id = i;
                Ducts.Add(setDuct(duct));

            }
        }
        private Duct setDuct(Duct duct)
        {
            switch (duct.id)
            {
                case 1:
                    duct.name = "Air Duct#1";
                    break;
                case 2:
                    duct.name = "Air Duct#2";
                    break;
                case 3:
                    duct.name = "Gas Duct#1";
                    break;
                case 4:
                    duct.name = "Gas Duct#2";
                    break;
                default:
                    break;
            }
                duct.active = (FindName("active" + duct.id) as ComboBox).SelectedIndex;
                duct.a = double.Parse((FindName("a" + duct.id) as TextBox).Text) ;
                duct.b = double.Parse((FindName("b" + duct.id) as TextBox).Text) ;
                duct.aPrim = double.Parse((FindName("aPrim" + duct.id) as TextBox).Text) ;
                duct.bPrim = double.Parse((FindName("bPrim" + duct.id) as TextBox).Text) ;
                duct.L = double.Parse((FindName("L" + duct.id) as TextBox).Text) ;
                duct.Bend_Joint = (FindName("Bend_Joint" + duct.id) as ComboBox).SelectedIndex;
                duct.ri = int.Parse((FindName("ri" + duct.id) as TextBox).Text);
                duct.C = double.Parse((FindName("C" + duct.id) as TextBox).Text);
                duct.C_degree = double.Parse((FindName("C_degree" + duct.id) as TextBox).Text);
                duct.Bend_Hopper = (FindName("Bend_Hopper" + duct.id) as ComboBox).SelectedIndex;
                duct.Enlargement = int.Parse((FindName("Enlargement" + duct.id) as TextBox).Text);
                duct.typeEnlargement = (FindName("typeEnlargement" + duct.id) as ComboBox).SelectedIndex;   
                duct.Enlargement_Degree = double.Parse((FindName("Enlargement_Degree" + duct.id) as TextBox).Text);
                duct.Contraction = int.Parse((FindName("Contraction" + duct.id) as TextBox).Text);
                duct.typeContraction = (FindName("typeContraction" + duct.id) as ComboBox).SelectedIndex;
                duct.Contraction_Degree = double.Parse((FindName("Contraction_Degree" + duct.id) as TextBox).Text);
                duct.Splitter = int.Parse((FindName("Splitter" + duct.id) as TextBox).Text);
                duct.DUCT_sectional_area = double.Parse((FindName("DUCT_sectional_area" + duct.id) as TextBox).Text);
                duct.DUCT_open_close = (FindName("DUCT_open_close" + duct.id) as ComboBox).SelectedIndex;
                duct.Splitter_Degree = double.Parse((FindName("Splitter_Degree" + duct.id) as TextBox).Text);
                duct.DAMPER_quantity = int.Parse((FindName("DAMPER_quantity" + duct.id) as TextBox).Text);
                duct.Width_of_truss = int.Parse((FindName("Width_of_truss" + duct.id) as TextBox).Text);
            return duct;
        }

        private void getValue()
        {
            foreach (Duct duct in Ducts)
            {
                (FindName("active" + duct.id) as ComboBox).SelectedIndex = duct.active;
                (FindName("a" + duct.id) as TextBox).Text= duct.a.ToString();
                (FindName("b" + duct.id) as TextBox).Text= duct.b.ToString();
                (FindName("aPrim" + duct.id) as TextBox).Text= duct.aPrim.ToString();
                (FindName("bPrim" + duct.id) as TextBox).Text= duct.bPrim.ToString();
                (FindName("L" + duct.id) as TextBox).Text = duct.L.ToString();
                (FindName("Bend_Joint" + duct.id) as ComboBox).SelectedIndex = duct.Bend_Joint;
                (FindName("ri" + duct.id) as TextBox).Text = duct.ri.ToString();
                (FindName("C" + duct.id) as TextBox).Text = duct.C.ToString();
                (FindName("C_degree" + duct.id) as TextBox).Text = duct.C_degree.ToString();
                (FindName("Bend_Hopper" + duct.id) as ComboBox).SelectedIndex = duct.Bend_Hopper;
                (FindName("Enlargement" + duct.id) as TextBox).Text = duct.Enlargement.ToString();
                (FindName("typeEnlargement" + duct.id) as ComboBox).SelectedIndex = duct.typeEnlargement;
                (FindName("Enlargement_Degree" + duct.id) as TextBox).Text = duct.Enlargement_Degree.ToString();
                (FindName("Contraction" + duct.id) as TextBox).Text = duct.Contraction.ToString();
                (FindName("typeContraction" + duct.id) as ComboBox).SelectedIndex = duct.typeContraction;
                (FindName("Contraction_Degree" + duct.id) as TextBox).Text = duct.Contraction_Degree.ToString();
                (FindName("Splitter" + duct.id) as TextBox).Text = duct.Splitter.ToString();
                (FindName("DUCT_sectional_area" + duct.id) as TextBox).Text = duct.DUCT_sectional_area.ToString();
                (FindName("DUCT_open_close" + duct.id) as ComboBox).SelectedIndex = duct.DUCT_open_close;
                (FindName("Splitter_Degree" + duct.id) as TextBox).Text = duct.Splitter_Degree.ToString();
                (FindName("DAMPER_quantity" + duct.id) as TextBox).Text = duct.DAMPER_quantity.ToString();
                (FindName("Width_of_truss" + duct.id) as TextBox).Text = duct.Width_of_truss.ToString();


            }

          
        }
    }
}
