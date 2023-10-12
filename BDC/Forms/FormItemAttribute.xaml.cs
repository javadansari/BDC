using BDC.Classes;
using System;
using System.Collections.Generic;
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
                Background = new SolidColorBrush(Colors.LightBlue),
            };

            Type elementType = typeof(ItemAttribute);
            PropertyInfo[] properties = elementType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                // Create a label with the content set to the property name
                Label label = new Label
                {
                    Content = property.Name,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(10), // Set the margin to 10 units on all sides

                };

                // Add the label to your layout (e.g., a StackPanel or Grid)
                // For example, you can add it to a StackPanel named verticalStackPanelOuter
                verticalStackPanelVertical.Children.Add(label);
            }
            horizontalStackPanelOuter.Children.Add(verticalStackPanelVertical);

            bool odd = true;
            foreach (Element element in Elements)
            {
                Color color = Colors.AliceBlue;
                if (odd) odd = false;
                else
                {
                    odd = true;
                    color = Colors.AntiqueWhite;
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
                ComboBox comboBoxTubeArrangement = buildCombo(itemsList);
                comboBoxTubeArrangement.SelectedIndex = element.attribute.TubeArrangement;
                //     comboBox.SelectionChanged += (sender, e) => Elements.Find(element => element.Id == element.Id).attribute.TubeArrangement = comboBox.SelectedIndex;
                comboBoxTubeArrangement.SelectionChanged += (sender, e) =>
                {
                    // Find the associated element (assuming you have a reference to the 'element')
                    Element associatedElement = Elements.Find(e => e.Id == element.Id);

                    if (associatedElement != null)
                    {
                        associatedElement.attribute.TubeArrangement = comboBoxTubeArrangement.SelectedIndex;
                        int index = Elements.FindIndex(e => e.Id == element.Id);
                        if (index != -1)
                        {
                            Elements[index] = associatedElement;
                        }
                    }
                };

                // WaterGass
                itemsList = new List<string> { "Counter", };
                ComboBox comboBoxWaterGass = buildCombo(itemsList);
                comboBoxWaterGass.SelectedIndex = element.attribute.TubeArrangement;
                comboBoxWaterGass.SelectionChanged += (sender, e) =>Elements.Find(element => element.Id == element.Id).attribute.TubeArrangement = comboBoxWaterGass.SelectedIndex;


                for (int k = 0; k < 3; k++)
                {

                    buildComponent(1, childStackPanel);
                }

                for (int k = 0; k < 2; k++)
                {
                    buildComponent(2, childStackPanel);
                }
          
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
                        Width = 100,
                        Margin = new Thickness(10),
                        Content = text,
                    };
                   childStackPanel.Children.Add(label);
        }
        private ComboBox buildCombo(List<string> itemsList)
        {
            ComboBox comboBox = new ComboBox
            {
                Width = 100,
                Margin = new Thickness(10),
            };
            foreach (string item in itemsList)
            {
                comboBox.Items.Add(item);
            }
            childStackPanel.Children.Add(comboBox);
            return comboBox;
        }
        private void buildComponent(int type, StackPanel stackPanel, string text = "")
        {
            switch (type)
            {
                case 1:
                    ComboBox comboBox = new ComboBox
                    {
                        Width = 100,
                        Margin = new Thickness(10),
                    };
                    stackPanel.Children.Add(comboBox);
                    break;
                case 2:
                    TextBox textBox = new TextBox
                    {
                        Width = 100,
                        Margin = new Thickness(10),     
                    };
                    stackPanel.Children.Add(textBox);
                    break;
                case 3:
                    Label label = new Label
                    {
                        Width = 100,
                        Margin = new Thickness(10),
                        Content = text,
                    };
                    stackPanel.Children.Add(label);
                    break;

                default:
                    break;
            }
        }
    }
}
