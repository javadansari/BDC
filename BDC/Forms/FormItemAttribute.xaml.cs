using BDC.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace BDC.Forms
{
    public partial class FormItemAttribute : Window
    {

        List<Tuple<CheckBox, StackPanel>> checkBoxStackPanelList = new List<Tuple<CheckBox, StackPanel>>();
        StackPanel childStackPanel;
        MainWindow Main;
        private int height = 26;
        CheckBox activeCheckBox;
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

            // Create a stack panel with horizontal orientation
            StackPanel stackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };

            // Create a save button and add it to the stack panel
            Button saveButton = new Button
            {
                Content = "Apply",
                Margin = new Thickness(10),
                HorizontalAlignment = HorizontalAlignment.Right,
                Style = (Style)FindResource("RoundedButtonStyleG")
            };
            saveButton.Click += SaveButton_Click;
            stackPanel.Children.Add(saveButton);

            // Create a close button and add it to the stack panel
            Button closeButton = new Button
            {
                Content = "Close",
                Margin = new Thickness(10),

                HorizontalAlignment = HorizontalAlignment.Right,
                Style = (Style)FindResource("RoundedButtonStyleG"),

            };
            closeButton.Click += (sender, e) => Close();
            stackPanel.Children.Add(closeButton);

          
            // Create a dock panel and add the stack panel to the top edge

            DockPanel dockPanel = new DockPanel();
            dockPanel.Children.Add(stackPanel);
         //   DockPanel.SetDock(stackPanel, Dock.Top);
            verticalStackPanelOuter.Children.Add(dockPanel);






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

                activeCheckBox =  buildCheckBox(childStackPanel, element.attribute.active, element);


                Label laberSectionName = new Label
                {
                     Content = element.attribute.sectionName,
                };
                childStackPanel.Children.Add(laberSectionName);

                //Section & Section Number
                ComboBox comboBoxSectionName;
                ComboBox comboBoxSectionNumber;
               
                if (element.Id < 8)
                {
                    List<string> sectionNames = new List<string> { "SH", "EVA", "ECO" };
                    comboBoxSectionName = new ComboBox { Height = height, };
                    comboBoxSectionNumber = new ComboBox { Height = height, };
                    foreach (var sectionName in sectionNames) comboBoxSectionName.Items.Add(sectionName);
                    comboBoxSectionName.SelectedIndex = element.attribute.section;
                    comboBoxSectionName.SelectionChanged += (sender, e) =>
                    {
                        element.attribute.section = comboBoxSectionName.SelectedIndex;
                        comboBoxSectionNumber.Items.Clear();
                        if (comboBoxSectionName.SelectedIndex == 1)
                        {
                            List<string> sectionNumbers = new List<string> { "1", "2", "3", "4" };
                            foreach (var sectionNumber in sectionNumbers) comboBoxSectionNumber.Items.Add(sectionNumber);
                        }
                        else
                        {
                            List<string> sectionNumbers = new List<string> { "1", "2", "3", };
                            foreach (var sectionNumber in sectionNumbers) comboBoxSectionNumber.Items.Add(sectionNumber);
                        }
                        comboBoxSectionNumber.SelectionChanged += (sender, e) =>
                        {
                            element.attribute.sectionNumber = comboBoxSectionNumber.SelectedIndex;
                            laberSectionName.Content = comboBoxSectionName.SelectedValue + "-" + comboBoxSectionNumber.SelectedValue;
                            element.attribute.sectionName = laberSectionName.Content.ToString();
                        };
                    };
                    childStackPanel.Children.Add(comboBoxSectionName);

                    //Section Number
                    List<string> sectionNumbers = new List<string> { "1", "2", "3", };
                    if (comboBoxSectionName.SelectedIndex == 1) { sectionNumbers = new List<string> { "1", "2", "3", "4" }; }
                    foreach (var sectionNumber in sectionNumbers) comboBoxSectionNumber.Items.Add(sectionNumber);
                    comboBoxSectionNumber.SelectedIndex = element.attribute.sectionNumber;
                    comboBoxSectionNumber.SelectionChanged += (sender, e) =>
                    {
                        element.attribute.sectionNumber = comboBoxSectionNumber.SelectedIndex;
                        laberSectionName.Content = comboBoxSectionName.SelectedValue + "-" + comboBoxSectionNumber.SelectedValue;
                        element.attribute.sectionName = laberSectionName.Content.ToString();
                    };
                    childStackPanel.Children.Add(comboBoxSectionNumber);
                    laberSectionName.Content = comboBoxSectionName.SelectedValue + "-" + comboBoxSectionNumber.SelectedValue;
                    element.attribute.sectionName = laberSectionName.Content.ToString();
                }
                //else if (element.Id == 8 || element.Id ==10){
                //    comboBoxSectionName = new ComboBox { Height = height, };
                //    comboBoxSectionNumber = new ComboBox { Height = height, };
                //    comboBoxSectionName.Items.Add("Duct");
                //    comboBoxSectionName.SelectedIndex = element.attribute.section;
                //    childStackPanel.Children.Add(comboBoxSectionName);
                //    //Section Number
                //    List<string> sectionNumbers = new List<string> { "1", "2" };
                //    foreach (var sectionNumber in sectionNumbers) comboBoxSectionNumber.Items.Add(sectionNumber);
                //    comboBoxSectionNumber.SelectedIndex = element.attribute.sectionNumber;
                //    comboBoxSectionNumber.SelectionChanged += (sender, e) =>
                //    {
                //        element.attribute.sectionNumber = comboBoxSectionNumber.SelectedIndex;
                //        laberSectionName.Content = comboBoxSectionName.SelectedValue + "-" + comboBoxSectionNumber.SelectedValue;
                //        element.attribute.sectionName = laberSectionName.Content.ToString();
                //    };
                //    childStackPanel.Children.Add(comboBoxSectionNumber);
                //    laberSectionName.Content = comboBoxSectionName.SelectedValue + "-" + comboBoxSectionNumber.SelectedValue;
                //    element.attribute.sectionName = laberSectionName.Content.ToString();
                //}
                else if (element.Id == 8)
                {
                    comboBoxSectionName = new ComboBox { Height = height, };
                    comboBoxSectionNumber = new ComboBox { Height = height, };
                    comboBoxSectionName.Items.Add("ECO");
                    comboBoxSectionName.SelectedIndex = element.attribute.section;
                    childStackPanel.Children.Add(comboBoxSectionName);
                    //Section Number
                    List<string> sectionNumbers = new List<string> { "1", "2", "3" };
                    foreach (var sectionNumber in sectionNumbers) comboBoxSectionNumber.Items.Add(sectionNumber);
                    comboBoxSectionNumber.SelectedIndex = element.attribute.sectionNumber;
                    comboBoxSectionNumber.SelectionChanged += (sender, e) =>
                    {
                        element.attribute.sectionNumber = comboBoxSectionNumber.SelectedIndex;
                        laberSectionName.Content = comboBoxSectionName.SelectedValue + "-" + comboBoxSectionNumber.SelectedValue;
                        element.attribute.sectionName = laberSectionName.Content.ToString();
                    };
                    childStackPanel.Children.Add(comboBoxSectionNumber);
                    laberSectionName.Content = comboBoxSectionName.SelectedValue + "-" + comboBoxSectionNumber.SelectedValue;
                    element.attribute.sectionName = laberSectionName.Content.ToString();
                }
                //else
                //{
                //    comboBoxSectionName = new ComboBox { Height = height, };
                //    comboBoxSectionNumber = new ComboBox { Height = height, };
                //    comboBoxSectionName.Items.Add("AIR");
                //    comboBoxSectionName.SelectedIndex = element.attribute.section;
                //    childStackPanel.Children.Add(comboBoxSectionName);
                //    //Section Number
                //    comboBoxSectionNumber.Items.Add("1");
                //    comboBoxSectionNumber.SelectedIndex = element.attribute.sectionNumber;
                //    comboBoxSectionNumber.SelectionChanged += (sender, e) =>
                //    {
                //        element.attribute.sectionNumber = comboBoxSectionNumber.SelectedIndex;
                //        laberSectionName.Content = comboBoxSectionName.SelectedValue + "-" + comboBoxSectionNumber.SelectedValue;
                //        element.attribute.sectionName = laberSectionName.Content.ToString();
                //    };
                //    childStackPanel.Children.Add(comboBoxSectionNumber);
                //    laberSectionName.Content = comboBoxSectionName.SelectedValue + "-" + comboBoxSectionNumber.SelectedValue;
                //    element.attribute.sectionName = laberSectionName.Content.ToString();

                //}

                if (!element.attribute.active) laberSectionName.Content = "";


                buildTextBox(childStackPanel, e => e.attribute.Channel_Height, element, (e, value) => e.attribute.Channel_Height = value);
                buildTextBox(childStackPanel, e => e.attribute.Channel_Width, element, (e, value) => e.attribute.Channel_Width = value);




                // TubeArrangement
                List<string> itemsList = new List<string> {"Staggered","In-line", };
             
                buildCombo(itemsList, e => e.attribute.TubeArrangement, element, (e, index) => e.attribute.TubeArrangement = index);
               

                // WaterGass
                itemsList = new List<string> { "Counter", "Parallel" };
                buildCombo(itemsList, e => e.attribute.Water_Gas_Flow_Pattern, element, (e, index) => e.attribute.Water_Gas_Flow_Pattern = index);


                buildTextBox(childStackPanel, e => e.attribute.No_Rows, element, (e, value) => e.attribute.No_Rows = value);
                buildTextBox(childStackPanel, e => e.attribute.No_Tubes_Row, element, (e, value) => e.attribute.No_Tubes_Row = value);
                buildTextBox(childStackPanel, e => e.attribute.Longitudinal_Pitch, element, (e, value) => e.attribute.Longitudinal_Pitch = value);
                buildTextBox(childStackPanel, e => e.attribute.Transverse_Pitch, element, (e, value) => e.attribute.Transverse_Pitch = value);
                buildTextBox(childStackPanel, e => e.attribute.NO_Water_Carrying_Tubes, element, (e, value) => e.attribute.NO_Water_Carrying_Tubes = value);
                buildTextBox(childStackPanel, e => e.attribute.Tube_Length, element, (e, value) => e.attribute.Tube_Length = value);
                buildTextBox(childStackPanel, e => e.attribute.Tube_Outer_Diameter, element, (e, value) => e.attribute.Tube_Outer_Diameter = value);
                buildTextBox(childStackPanel, e => e.attribute.Tube_Wall_Thickness, element, (e, value) => e.attribute.Tube_Wall_Thickness = value);
                buildTextBox(childStackPanel, e => e.attribute.Incidence_Angle, element, (e, value) => e.attribute.Incidence_Angle = value);
          
                List<string> materialList = new List<string> { "SA178-A", "SA178-C", "SA210-A1", "SA192", "SA213-T11", "SA213-T22", "SA213-T91", "SA213-T304" };
                buildCombo(materialList, e => e.attribute.Tubes_Material, element, (e, index) => e.attribute.Tubes_Material = index);
             
                List<string> typeList = new List<string> { "Serrated", "In-Solid", "Bare" };
                buildCombo(typeList, e => e.attribute.Fin_Type, element, (e, index) => e.attribute.Fin_Type = index);


                buildTextBox(childStackPanel, e => e.attribute.Fin_Height, element, (e, value) => e.attribute.Fin_Height = value);
                buildTextBox(childStackPanel, e => e.attribute.Fin_Thickness, element, (e, value) => e.attribute.Fin_Thickness = value);
                buildTextBox(childStackPanel, e => e.attribute.Fin_Density, element, (e, value) => e.attribute.Fin_Density = value);
                buildTextBox(childStackPanel, e => e.attribute.Fin_Uncut_Height, element, (e, value) => e.attribute.Fin_Uncut_Height = value);
                buildTextBox(childStackPanel, e => e.attribute.Fin_Segment_Width, element, (e, value) => e.attribute.Fin_Segment_Width = value);
            
                List<string> finMaterialList = new List<string> { "C.S", "A240-TP304", "A240-TP409" };    
                buildCombo(finMaterialList, e => e.attribute.Fin_Material, element, (e, index) => e.attribute.Fin_Material = index);
             
                buildTextBox(childStackPanel, e => e.attribute.Water_Side_Founling_Factor, element, (e, value) => e.attribute.Water_Side_Founling_Factor = value);
                buildTextBox(childStackPanel, e => e.attribute.Gas_Side_Founling_Factor, element, (e, value) => e.attribute.Gas_Side_Founling_Factor = value);
                buildTextBox(childStackPanel, e => e.attribute.Usage_Factor, element, (e, value) => e.attribute.Usage_Factor = value);


                childStackPanel.Background = Brushes.LightYellow;
                //   if (element.Id % 2 == 0) childStackPanel.Background = Brushes.LightGray;




                horizontalStackPanelOuter.Children.Add(childStackPanel);
                if (!element.attribute.active)
                {
                    foreach (var item in childStackPanel.Children)
                    {
                        if (item is UIElement ele)
                        {
                            ele.IsEnabled = false;
                        }
                    }
                }
                activeCheckBox.IsEnabled = true;
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
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Main.elements = Elements;
            Main.updateElement();
            this.Close();
        }
        private void buildLabel( string text )
        {
                    Label label = new Label
                    {
                        Content = text,
                    };
                   childStackPanel.Children.Add(label);
        }

        private CheckBox buildCheckBox(StackPanel stackPanel, bool check, Element element)
        {
            CheckBox checkBox = new CheckBox
            {
                Height = 26,
                HorizontalAlignment = HorizontalAlignment.Center,

            };

            checkBox.IsChecked = check;
            checkBox.Checked += (sender, e) =>
                 {
                     if (sender is CheckBox checkBox)
                     {

                         if (checkBox.IsChecked.Value)
                         {
                             element.attribute.active = checkBox.IsChecked.Value;
                             //   checkCheckBox(checkBox, stackPanel);
                                 foreach (var item in stackPanel.Children)
                                 if (item is UIElement element)
                                     element.IsEnabled = true;
                         }

                     };
                 };
            checkBox.Unchecked += (sender, e) =>
            {
                element.attribute.active = checkBox.IsChecked.Value;
                checkCheckBox(checkBox, stackPanel);
            };
          stackPanel.Children.Add(checkBox);
          checkBoxStackPanelList.Add(Tuple.Create(checkBox,stackPanel));
         return checkBox;
        }
        private void checkCheckBox(CheckBox checkBox , StackPanel stackPanel)
        {
            foreach (var item in stackPanel.Children)
                if (item is UIElement element)
                {
                    if (element is CheckBox check1)
                    {
                        if (check1 == checkBox) { }
                      //      checkBox.IsEnabled = true;
                    }
                    else element.IsEnabled = true;
                }
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
        }
     
    }
}
