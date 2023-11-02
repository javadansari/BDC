using BDC.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;

namespace BDC.Forms
{
    public partial class FormItemAttribute : Window
    {

        StackPanel childStackPanel;
        MainWindow Main;
        List<Element> Elements = new List<Element>();
        public FormItemAttribute(List<Element> elements, MainWindow main)
        {
            InitializeComponent();
            Main = main;
            Elements = elements;
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

            Type elementType = typeof(ItemAttribute);
            PropertyInfo[] properties = elementType.GetProperties();
            foreach (PropertyInfo property in properties)
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
            horizontalStackPanelOuter.Children.Add(verticalStackPanelVertical);

            bool odd = true;
            foreach (Element element in Elements)
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
                buildLabel(element.attribute.stage);
                buildLabel(element.attribute.loadCase);

              
                // TubeArrangement
                List<string> itemsList = new List<string> {"Staggered","In-line", };
             
                buildCombo(itemsList, e => e.attribute.TubeArrangement, element, (e, index) => e.attribute.TubeArrangement = index);
               

                // WaterGass
                itemsList = new List<string> { "Counter", };
                buildCombo(itemsList, e => e.attribute.Water_Gas_Flow_Pattern, element, (e, index) => e.attribute.Water_Gas_Flow_Pattern = index);


                buildTextBox(childStackPanel, e => e.attribute.SLN, element, (e, value) => e.attribute.SLN = value);
                buildTextBox(childStackPanel, e => e.attribute.STN, element, (e, value) => e.attribute.STN = value);
                buildTextBox(childStackPanel, e => e.attribute.Tube_Rows_Path, element, (e, value) => e.attribute.Tube_Rows_Path = value);
                buildTextBox(childStackPanel, e => e.attribute.Path_Wide, element, (e, value) => e.attribute.Path_Wide = value);
                buildTextBox(childStackPanel, e => e.attribute.SL, element, (e, value) => e.attribute.SL = value);
                buildTextBox(childStackPanel, e => e.attribute.ST, element, (e, value) => e.attribute.ST = value);
                buildTextBox(childStackPanel, e => e.attribute.Tube_Length, element, (e, value) => e.attribute.Tube_Length = value);
                buildTextBox(childStackPanel, e => e.attribute.Tube_Outer_Diameter, element, (e, value) => e.attribute.Tube_Outer_Diameter = value);
                buildTextBox(childStackPanel, e => e.attribute.Tube_Wall_Thickness, element, (e, value) => e.attribute.Tube_Wall_Thickness = value);
                buildTextBox(childStackPanel, e => e.attribute.Incidence_Angle, element, (e, value) => e.attribute.Incidence_Angle = value);
                buildTextBox(childStackPanel, e => e.attribute.Tubes_Material, element, (e, value) => e.attribute.Tubes_Material = value);
                buildTextBox(childStackPanel, e => e.attribute.Fin_Type, element, (e, value) => e.attribute.Fin_Type = value);
                buildTextBox(childStackPanel, e => e.attribute.Fin_Height, element, (e, value) => e.attribute.Fin_Height = value);
                buildTextBox(childStackPanel, e => e.attribute.Fin_Density, element, (e, value) => e.attribute.Fin_Density = value);
                buildTextBox(childStackPanel, e => e.attribute.Fin_Uncut_Height, element, (e, value) => e.attribute.Fin_Uncut_Height = value);
                buildTextBox(childStackPanel, e => e.attribute.Fin_Segment_Width, element, (e, value) => e.attribute.Fin_Segment_Width = value);
                buildTextBox(childStackPanel, e => e.attribute.Fin_Material, element, (e, value) => e.attribute.Fin_Material = value);
                buildTextBox(childStackPanel, e => e.attribute.Water_Side_Founling_Factor, element, (e, value) => e.attribute.Water_Side_Founling_Factor = value);
                buildTextBox(childStackPanel, e => e.attribute.Usage_Factor, element, (e, value) => e.attribute.Usage_Factor = value);


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
            Main.elements = Elements;
        }
        private void buildLabel( string text )
        {
                    Label label = new Label
                    {
                //        Width = 100,
               //         Margin = new Thickness(10),
                        Content = text,
                    };
                   childStackPanel.Children.Add(label);
        }
        private void buildTextBox(StackPanel stackPanel ,  Func<Element, string> getIndexFunc , Element element, Action<Element, string> setIndexAction)
        {

            TextBox textBox = new TextBox
            {
            //    Width = 100,
                Height = 26,
          //     Margin = new Thickness(0,0,0,0),
                
            };
            textBox.Text = getIndexFunc(element);
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


                    Element associatedElement = Elements.Find(e => e.Id == element.Id);

                    if (associatedElement != null)
                    {
                        setIndexAction(associatedElement, textBox.Text);
                        int index = Elements.FindIndex(e => e.Id == element.Id);
                        if (index != -1)
                        {
                            Elements[index] = associatedElement;
                        }
                    }

                }

            };
            stackPanel.Children.Add(textBox);
           

        }

        private void buildCombo(List<string> itemsList, Func<Element, int> getIndexFunc, Element element, Action<Element, int> setIndexAction)
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
            comboBox.SelectedIndex = getIndexFunc(element);
            comboBox.SelectionChanged += (sender, e) =>
            {
                Element associatedElement = Elements.Find(e => e.Id == element.Id);

                if (associatedElement != null)
                {
                    setIndexAction(associatedElement, comboBox.SelectedIndex);
                    int index = Elements.FindIndex(e => e.Id == element.Id);
                    if (index != -1)
                    {
                        Elements[index] = associatedElement;
                    }
                }
            };

            childStackPanel.Children.Add(comboBox);
         //   return comboBox;
        }
     
    }
}
