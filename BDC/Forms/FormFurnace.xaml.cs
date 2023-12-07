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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace BDC.Forms
{
    /// <summary>
    /// Interaction logic for FormFurnace.xaml
    /// </summary>
    public partial class FormFurnace : Window
    {
        Furnace Furnace ;
        MainWindow Main;
        public FormFurnace(Furnace furnace, MainWindow main)
        {
            InitializeComponent();


            List<string> materials = new List<string> { "SA210-A1", "SA210-A2",  };

            foreach (var material in materials) Material_F.Items.Add(material);
            foreach (var material in materials) Material_R.Items.Add(material);
            foreach (var material in materials) Material_S.Items.Add(material);
            foreach (var material in materials) Material_D.Items.Add(material);


            Furnace = furnace;
            Main = main;
            getValue();
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
          
            setValue();
            Main.furnace = Furnace;
          this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void setValue()
        {
            Furnace.No_Burner = No_Burner.Text;
            Furnace.LL_m = LL_m.Text;
            Furnace.HH_m = HH_m.Text;
            Furnace.WB1_m = WB1_m.Text;
            Furnace.Alpha_deg = Alpha_deg.Text;
            Furnace.WB2_m = WB2_m.Text;
            Furnace.B_deg = B_deg.Text;
            Furnace.LS_m = LS_m.Text;
            Furnace.IX_m = IX_m.Text;
            Furnace.IY_m = IY_m.Text;
            Furnace.DF_m = DF_m.Text;
            Furnace.Lref_m = Lref_m.Text;
            Furnace.ODw_mm_F = ODw_mm_F.Text;
            Furnace.ODw_mm_R = ODw_mm_R.Text;
            Furnace.ODw_mm_S = ODw_mm_S.Text;
            Furnace.ODw_mm_D = ODw_mm_D.Text;
            Furnace.ThkTube_mm_F = ThkTube_mm_F.Text;
            Furnace.ThkTube_mm_R = ThkTube_mm_R.Text;
            Furnace.ThkTube_mm_S = ThkTube_mm_S.Text;
            Furnace.ThkTube_mm_D = ThkTube_mm_D.Text;
            Furnace.ThkMemb_mm_F = ThkMemb_mm_F.Text;
            Furnace.ThkMemb_mm_R = ThkMemb_mm_R.Text;
            Furnace.ThkMemb_mm_S = ThkMemb_mm_S.Text;
            Furnace.ThkMemb_mm_D = ThkMemb_mm_D.Text;
            Furnace.TubeSP_mm_F = TubeSP_mm_F.Text;
            Furnace.TubeSP_mm_R = TubeSP_mm_R.Text;
            Furnace.TubeSP_mm_S = TubeSP_mm_S.Text;
            Furnace.TubeSP_mm_D = TubeSP_mm_D.Text;
            Furnace.Material_F = Material_F.SelectedIndex;
            Furnace.Material_R = Material_R.SelectedIndex;
            Furnace.Material_S = Material_S.SelectedIndex;
            Furnace.Material_D = Material_D.SelectedIndex;
            Furnace.Screen = Screen.IsChecked ?? false;
            Furnace.Floor_Refactory = Floor_Refactory.IsChecked ?? false;
            Furnace.Emissivity_of_Furnace_Walls = Emissivity_of_Furnace_Walls.Text;
            Furnace.Emissivity_of_Refactory_Layer = Emissivity_of_Refactory_Layer.Text;
            Furnace.Convective_Heat_Transfer = Convective_Heat_Transfer.Text;
            Furnace.Usage_Factor = Usage_Factor.Text;
        }
        private void getValue()
        {
            No_Burner.Text = Furnace.No_Burner;
            LL_m.Text = Furnace.LL_m;
            HH_m.Text = Furnace.HH_m;
            WB1_m.Text = Furnace.WB1_m;
            Alpha_deg.Text = Furnace.Alpha_deg;
            WB2_m.Text = Furnace.WB2_m;
            B_deg.Text = Furnace.B_deg;
            LS_m.Text = Furnace.LS_m;
            IX_m.Text = Furnace.IX_m;
            IY_m.Text = Furnace.IY_m;
            DF_m.Text = Furnace.DF_m;
            Lref_m.Text = Furnace.Lref_m;
            ODw_mm_F.Text = Furnace.ODw_mm_F;
            ODw_mm_R.Text = Furnace.ODw_mm_R;
            ODw_mm_S.Text = Furnace.ODw_mm_S;
            ODw_mm_D.Text = Furnace.ODw_mm_D;
            ThkTube_mm_F.Text = Furnace.ThkTube_mm_F;
            ThkTube_mm_R.Text = Furnace.ThkTube_mm_R;
            ThkTube_mm_S.Text = Furnace.ThkTube_mm_S;
            ThkTube_mm_D.Text = Furnace.ThkTube_mm_D;
            ThkMemb_mm_F.Text = Furnace.ThkMemb_mm_F;
            ThkMemb_mm_R.Text = Furnace.ThkMemb_mm_R;
            ThkMemb_mm_S.Text = Furnace.ThkMemb_mm_S;
            ThkMemb_mm_D.Text = Furnace.ThkMemb_mm_D;
            TubeSP_mm_F.Text = Furnace.TubeSP_mm_F;
            TubeSP_mm_R.Text = Furnace.TubeSP_mm_R;
            TubeSP_mm_S.Text = Furnace.TubeSP_mm_S;
            TubeSP_mm_D.Text = Furnace.TubeSP_mm_D;
            Material_F.SelectedIndex = Furnace.Material_F;
            Material_R.SelectedIndex = Furnace.Material_R;
            Material_S.SelectedIndex = Furnace.Material_S;
            Material_D.SelectedIndex = Furnace.Material_D;
            Screen.IsChecked = Furnace.Screen;
            Floor_Refactory.IsChecked = Furnace.Floor_Refactory;
            Emissivity_of_Furnace_Walls.Text = Furnace.Emissivity_of_Furnace_Walls;
            Emissivity_of_Refactory_Layer.Text = Furnace.Emissivity_of_Refactory_Layer;
            Convective_Heat_Transfer.Text = Furnace.Convective_Heat_Transfer;
            Usage_Factor.Text = Furnace.Usage_Factor;
        }

    }
}

