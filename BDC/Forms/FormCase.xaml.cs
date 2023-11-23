using BDC.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for FormCase.xaml
    /// </summary>
    public partial class FormCase : Window
    {
        StackPanel childStackPanel;
        MainWindow Main;
        List<Case> Cases = new List<Case>();
        public FormCase(List<Case> cases, MainWindow main)
        {
            InitializeComponent();
            Main = main;
            Cases = cases;
            PopulateVerticalLayout();
        }
        private void PopulateVerticalLayout()
        {

            StackPanel verticalStackPanelOuter = new StackPanel
            {
                Orientation = Orientation.Vertical,
            };

            StackPanel horizontalStackPanelOuter = new StackPanel
            {
                Orientation = Orientation.Horizontal,
            };



            StackPanel verticalStackPanelVertical = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Background = new SolidColorBrush(Colors.White),
            };

            Type caseType = typeof(Case);
            PropertyInfo[] properties = caseType.GetProperties();
            bool isFirstProperty = true;
            foreach (PropertyInfo property in properties)
            {
                if (!isFirstProperty)
                {
                    string displayName = property.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? property.Name;
                    Label label = new Label
                    {
                        Content = displayName,
                        VerticalAlignment = VerticalAlignment.Center,
                        //     Margin = new Thickness(10), // Set the margin to 10 units on all sides

                    };
                    verticalStackPanelVertical.Children.Add(label);
                }
                isFirstProperty = false;

            }
            horizontalStackPanelOuter.Children.Add(verticalStackPanelVertical);

            bool odd = true;
            foreach (Case @case in Cases)
            {
                Color color = Colors.White;
                if (odd) odd = false;
                else
                {
                    odd = true;
                    color = Colors.White;
                }
                childStackPanel = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    Background = new SolidColorBrush(color),
                };
                buildLabel(@case.Name);

            
                buildTextBox(childStackPanel, e => e.Ambient_Condition, @case, (e, value) => e.Ambient_Condition = value);
                // Assuming @case and childStackPanel are defined elsewhere

                buildTextBox(childStackPanel, e => e.Site_Atmospheric_Pressure, @case, (e, value) => e.Site_Atmospheric_Pressure = value);
                buildTextBox(childStackPanel, e => e.Ambient_Temperature, @case, (e, value) => e.Ambient_Temperature = value);
                buildTextBox(childStackPanel, e => e.Relative_Humidity, @case, (e, value) => e.Relative_Humidity = value);
                buildTextBox(childStackPanel, e => e.Combustion, @case, (e, value) => e.Combustion = value);
                buildTextBox(childStackPanel, e => e.GAS1, @case, (e, value) => e.GAS1 = value);
                buildTextBox(childStackPanel, e => e.GAS2, @case, (e, value) => e.GAS2 = value);
                buildTextBox(childStackPanel, e => e.GAS3, @case, (e, value) => e.GAS3 = value);
                buildTextBox(childStackPanel, e => e.GAS4, @case, (e, value) => e.GAS4 = value);
                buildTextBox(childStackPanel, e => e.GAS5, @case, (e, value) => e.GAS5 = value);
                buildTextBox(childStackPanel, e => e.OIL1, @case, (e, value) => e.OIL1 = value);
                buildTextBox(childStackPanel, e => e.OIL2, @case, (e, value) => e.OIL2 = value);
                buildTextBox(childStackPanel, e => e.Excess_Air, @case, (e, value) => e.Excess_Air = value);
                buildTextBox(childStackPanel, e => e.Atmozing_Steam_Flow, @case, (e, value) => e.Atmozing_Steam_Flow = value);
                buildTextBox(childStackPanel, e => e.Atmozing_Steam_Pressure, @case, (e, value) => e.Atmozing_Steam_Pressure = value);
                buildTextBox(childStackPanel, e => e.Atmozing_Steam_Temperature, @case, (e, value) => e.Atmozing_Steam_Temperature = value);
                buildTextBox(childStackPanel, e => e.FDF, @case, (e, value) => e.FDF = value);
                buildTextBox(childStackPanel, e => e.Fan_efficiency, @case, (e, value) => e.Fan_efficiency = value);
                buildTextBox(childStackPanel, e => e.Heat_exchange_ducty, @case, (e, value) => e.Heat_exchange_ducty = value);
                buildTextBox(childStackPanel, e => e.Steam_Outlet, @case, (e, value) => e.Steam_Outlet = value);
                buildTextBox(childStackPanel, e => e.Steam_Pressure_TP, @case, (e, value) => e.Steam_Pressure_TP = value);
                buildTextBox(childStackPanel, e => e.Main_steam_Pressue_Drop, @case, (e, value) => e.Main_steam_Pressue_Drop = value);
                buildTextBox(childStackPanel, e => e.Desuperheater, @case, (e, value) => e.Desuperheater = value);
                buildTextBox(childStackPanel, e => e.Location_of_DESH, @case, (e, value) => e.Location_of_DESH = value);
                buildTextBox(childStackPanel, e => e.Steam_temperature_set_point_TP, @case, (e, value) => e.Steam_temperature_set_point_TP = value);
                buildTextBox(childStackPanel, e => e.Min_SH_degree_at_desperheater_outlet, @case, (e, value) => e.Min_SH_degree_at_desperheater_outlet = value);
                buildTextBox(childStackPanel, e => e.Feed_water, @case, (e, value) => e.Feed_water = value);
                buildTextBox(childStackPanel, e => e.Feed_water_Pressure, @case, (e, value) => e.Feed_water_Pressure = value);
                buildTextBox(childStackPanel, e => e.Feed_water_Temperature, @case, (e, value) => e.Feed_water_Temperature = value);
                buildTextBox(childStackPanel, e => e.BFP_temperature_rise, @case, (e, value) => e.BFP_temperature_rise = value);
                buildTextBox(childStackPanel, e => e.Feed_water_piping_dp, @case, (e, value) => e.Feed_water_piping_dp = value);
                buildTextBox(childStackPanel, e => e.Level_control_Valve_dp, @case, (e, value) => e.Level_control_Valve_dp = value);
                buildTextBox(childStackPanel, e => e.Losses, @case, (e, value) => e.Losses = value);
                buildTextBox(childStackPanel, e => e.Unburned_Loss, @case, (e, value) => e.Unburned_Loss = value);
                buildTextBox(childStackPanel, e => e.Radiation_Loss, @case, (e, value) => e.Radiation_Loss = value);
                buildTextBox(childStackPanel, e => e.Furnace_heat_absorption_Eff, @case, (e, value) => e.Furnace_heat_absorption_Eff = value);
                buildTextBox(childStackPanel, e => e.Blowdown, @case, (e, value) => e.Blowdown = value);
                buildTextBox(childStackPanel, e => e.Blowdown_flow, @case, (e, value) => e.Blowdown_flow = value);




                horizontalStackPanelOuter.Children.Add(childStackPanel);
            }

            verticalStackPanelOuter.Children.Add(horizontalStackPanelOuter);


            ScrollViewer scrollViewer = new ScrollViewer
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
            };

            scrollViewer.Content = verticalStackPanelOuter;
            Content = scrollViewer; // Replace the existing content with the scroll viewer.


            Button saveButton = new Button
            {
                Content = "Save",
                Margin = new Thickness(10),
                Width = 150,
                Height = 50,
            };
            saveButton.Click += SaveButton_Click;
            verticalStackPanelOuter.Children.Add(saveButton);

        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Main.cases = Cases;
            this.Close();
        }
        private void buildLabel(string text)
        {
            Label label = new Label
            {
                //        Width = 100,
                //         Margin = new Thickness(10),
                Content = text,
            };
            childStackPanel.Children.Add(label);
        }
        private void buildTextBox(StackPanel stackPanel, Func<Case, string> getIndexFunc, Case @case, Action<Case, string> setIndexAction)
        {

            TextBox textBox = new TextBox
            {
                //    Width = 100,
                Height = 26,
                //     Margin = new Thickness(0,0,0,0),

            };
            textBox.Text = getIndexFunc(@case);
            textBox.TextChanged += (sender, e) =>
            {
                if (sender is TextBox textBox)
                {
                    // Try to parse the text as a double
                    if (double.TryParse(textBox.Text, out double result))
                    {
                        textBox.Text = result.ToString();
                    }
                    else
                    {
                        if (textBox.Text.Length > 0) textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                        textBox.Select(textBox.Text.Length, 0);
                        textBox.Focus();
                    }


                    Case associatedCase = Cases.Find(e => e.Id == @case.Id);

                    if (associatedCase != null)
                    {
                        setIndexAction(associatedCase, textBox.Text);
                        int index = Cases.FindIndex(e => e.Id == @case.Id);
                        if (index != -1)
                        {
                            Cases[index] = associatedCase;
                        }
                    }

                }

            };
            stackPanel.Children.Add(textBox);


        }

        private void buildCombo(List<string> itemsList, Func<Case, int> getIndexFunc, Case @case, Action<Case, int> setIndexAction)
        {
            ComboBox comboBox = new ComboBox
            {
                //     Width = 100,
                Height = 26,
                //   Margin = new Thickness(0,0,0,0),
            };
            foreach (string item in itemsList)
            {
                comboBox.Items.Add(item);
            }
            comboBox.SelectedIndex = getIndexFunc(@case);
            comboBox.SelectionChanged += (sender, e) =>
            {
                Case associatedCase = Cases.Find(e => e.Id == @case.Id);

                if (associatedCase != null)
                {
                    setIndexAction(associatedCase, comboBox.SelectedIndex);
                    int index = Cases.FindIndex(e => e.Id == @case.Id);
                    if (index != -1)
                    {
                        Cases[index] = associatedCase;
                    }
                }
            };

            childStackPanel.Children.Add(comboBox);
            //   return comboBox;
        }

    }
}

