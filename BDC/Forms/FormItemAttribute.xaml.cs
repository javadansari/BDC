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
                Background = new SolidColorBrush(Colors.LightBlue),
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
                    Margin = new Thickness(10), // Set the margin to 10 units on all sides

                };
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
             
                buildCombo(itemsList, e => e.attribute.TubeArrangement, element, (e, index) => e.attribute.TubeArrangement = index);
               

                // WaterGass
                itemsList = new List<string> { "Counter", };
                buildCombo(itemsList, e => e.attribute.Water_Gas_Flow_Pattern, element, (e, index) => e.attribute.Water_Gas_Flow_Pattern = index);

                for (int i = 0; i < 10; i++)
                {
                    buildTextBox(childStackPanel);

                }

                // Tube Rows (SLN)
                buildTextBox(childStackPanel);


          
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
        private void buildTextBox( StackPanel stackPanel)
        {

            TextBox textBox = new TextBox
            {
                Width = 100,
                Height = 25,
                Margin = new Thickness(10,11,10,10),
                
            };
            textBox.TextChanged += TextBox_TextChanged;
            stackPanel.Children.Add(textBox);
           

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
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
            }
        }
        private void buildCombo(List<string> itemsList, Func<Element, int> getIndexFunc, Element element, Action<Element, int> setIndexAction)
        {
            ComboBox comboBox = new ComboBox
            {
                Width = 100,
                Height = 25,
                Margin = new Thickness(10,11,10,10),
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
