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
        public FormItemAttribute(List<Element> elements)
        {
            InitializeComponent();
            PopulateVerticalLayout(elements);
        }

        private void PopulateVerticalLayout(List<Element> elements)
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

            foreach (Element element in elements)
            {
                StackPanel verticalStackPanel = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    Margin = new Thickness(10), // Set the margin to 10 units on all sides
                };
                Label label = new Label
                {
                    Content = element.State,
                };
                verticalStackPanel.Children.Add(label);
                for (int k = 0; k < 3; k++)
                {
                    ComboBox comboBox = new ComboBox
                    {
                        Width = 100,
                        Margin = new Thickness(5),
                    };

                    verticalStackPanel.Children.Add(comboBox);
                }

                for (int k = 0; k < 2; k++)
                {
                    TextBox textBox = new TextBox
                    {
                        Width = 100,
                        Margin = new Thickness(5),
                    };

                    verticalStackPanel.Children.Add(textBox);
                }
          
                    horizontalStackPanelOuter.Children.Add(verticalStackPanel);
            }

            verticalStackPanelOuter.Children.Add(horizontalStackPanelOuter);
     

            ScrollViewer scrollViewer = new ScrollViewer
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
            };

            scrollViewer.Content = verticalStackPanelOuter;
            Content = scrollViewer; // Replace the existing content with the scroll viewer.
        }
    }
}
