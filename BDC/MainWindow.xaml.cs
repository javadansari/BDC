using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using Image = System.Windows.Controls.Image;
using BDC.Classes;
using System.Net;
using System.Security.AccessControl;
using BDC.Forms;
using System.Windows.Media.Media3D;
using Microsoft.Win32;
using System.Xml;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using BDC.DataBase;
using System.Data.SQLite;
using System.Data.Entity;
using System.Windows.Controls.Primitives;
using BDC.View;


namespace BDC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        public List<Element> elements { get; set; }
        
        public List<Case> cases{ get; set; }

        private Element element;

        private List<ItemAttribute> itemAttribute;
        private Button clickedButton;
        private Image imageLevelButton;
        private ImageSource draggedImageSource;
        private bool isFirstLine = true;
        private bool isSelect = true;
        private Image firstLineImage;
        private Image secondLineImage;
        private bool isLine = false;
        private bool isMove = false;
        private Dictionary<string, int> stateCounters;
        private Image draggedImage;
        private Image currentDraggedImage;
        private Point startPoint;
        private int iconSize = 48;
        private double currentScale = 1.0;
        private string loadCalse = "base";


        public MainWindow()
        {
            InitializeComponent();
            startInitialize();

        }

        #region Start
        private void startInitialize()
        {



            draggedImage = new Image();
      

            elements = new List<Element>();
            cases = new List<Case>();

            canvas.LayoutTransform = new ScaleTransform(0.8, 0.8);


        }
        #endregion



        #region Path
        private void line_Click(object sender, MouseButtonEventArgs e)
        {
         
            reportText.Text = "Choose the first level";
            isLine = true;
        }

     
        #endregion
        
        #region ImageChooser

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            Image image = boilerStage_1;
            Label label = boilerStage_1_label;
            int id = 0;
            switch (checkBox.Name)
            {
                case "boilerStage_check_1":
                    image = boilerStage_1;
                    label = boilerStage_1_label;
                    id = 1;
                    break;
                case "boilerStage_check_2":
                    image = boilerStage_2;
                    label = boilerStage_2_label;
                    id = 2;
                    break;
                case "boilerStage_check_3":
                    image = boilerStage_3;
                    label = boilerStage_3_label;
                    id = 3;
                    break;
                case "boilerStage_check_4":
                    image = boilerStage_4;
                    label = boilerStage_4_label;
                    id = 4;
                    break;
                case "boilerStage_check_5":
                    image = boilerStage_5;
                    label = boilerStage_5_label;
                    id = 5;
                    break;
                case "boilerStage_check_6":
                    image = boilerStage_6;
                    label = boilerStage_6_label;
                    id = 6;
                    break;
                case "boilerStage_check_7":
                    image = boilerStage_7;
                    label = boilerStage_7_label;
                    id = 7;
                    break;
                default:
                    break;
            }
            ImageChooser imageChooser = new ImageChooser();
            if (checkBox.IsChecked == true)
            {
                if (imageChooser.ShowDialog() == true)
                {
                    if (imageChooser.EconomizerRadioButton.IsChecked == true)
                    {
                        image.Source = new BitmapImage(new Uri("/Images/Elements/economizer.png", UriKind.Relative));
                        image.Tag = "eco";

                    }
                    else if (imageChooser.SuperheatRadioButton.IsChecked == true)
                    {
                        image.Source = new BitmapImage(new Uri("/Images/Elements/superheater.png", UriKind.Relative));
                        image.Tag = "sh";
                    }
                    else if (imageChooser.EvaporatorRadioButton.IsChecked == true)
                    {
                        image.Source = new BitmapImage(new Uri("/Images/Elements/evaporator.png", UriKind.Relative));
                        image.Tag = "eva";
                    }
                }
    
                label.Content = setElement(image,id).Name;
            }
            else
            {
                elements.Remove(elements.FirstOrDefault(element => element.Image == image));
           
                image.Source = null;
                image.Tag = "";
                label.Content = "";
            }
        }

        private void CheckBoxDuct_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
   
            Image image = boilerStage_11;
            Label label = boilerStage_11_label;
            int id = 11;
            if (checkBox.IsChecked == true)
            {
                image.Source = new BitmapImage(new Uri("/Images/Elements/duct.png", UriKind.Relative));
                image.Tag = "du";

                label.Content = setElement(image,id).Name;
            }
            else
            {
                elements.Remove(elements.FirstOrDefault(element => element.Image == image));
             
                image.Source = null;
                image.Tag = "";
                label.Content = "";
            }
        }

        private void CheckBoxBurner_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            Image image = boilerStage_8;
            Label label = boilerStage_8_label;
            int id = 0;
            switch (checkBox.Name)
            {
                case "boilerStage_check_8":
                    image = boilerStage_8;
                    label = boilerStage_8_label;
                    id = 8;
                    break;
                case "boilerStage_check_9":
                    image = boilerStage_9;
                    label = boilerStage_9_label;
                    id = 9;
                    break;
                case "boilerStage_check_10":
                    image = boilerStage_10;
                    label = boilerStage_10_label;
                    id = 10;
                    break;
                default:
                    break;
            }

            if (checkBox.IsChecked == true)
            {
                image.Source = new BitmapImage(new Uri("/Images/Elements/burner.png", UriKind.Relative));
                image.Tag = "bu";
                label.Content = setElement(image,id).Name;
            }
            else
            {
                elements.Remove(elements.FirstOrDefault(element => element.Image == image));
            
                image.Source = null;
                image.Tag = "";
                label.Content = "";

            }
        }
        private Element setElement(Image image,int id)
        {
            Element element = new Element();
            element.Id = id;
            element.Exist = true;
            element.Name = image.Tag.ToString();
            element.Content = image.Tag.ToString();
            element.State = image.Tag.ToString();
            element.Connection = 0;
            element.Image = image;

            element.attribute = new ItemAttribute();

            elements.Add(element);
        
            return element;
        }


        public void showProperties(Element element)
        {

            List<PropertyDisplay> propertyList = new List<PropertyDisplay>
                  {
                        new PropertyDisplay { PropertyName = "content", PropertyValue = element.Content.ToString() },
                        new PropertyDisplay { PropertyName = "Name", PropertyValue = element.Name.ToString() },
                        new PropertyDisplay { PropertyName = "State", PropertyValue = element.State.ToString() },
                   //     new PropertyDisplay { PropertyName = "stage", PropertyValue = element.attribute.stage.ToString() },
                    //    new PropertyDisplay { PropertyName = "loadCase", PropertyValue = element.attribute.loadCase.ToString() },
                    //    new PropertyDisplay { PropertyName = "TubeArrangement", PropertyValue = element.attribute.TubeArrangement.ToString() },
                   //     new PropertyDisplay { PropertyName = "Water_Gas_Flow_Pattern", PropertyValue = element.attribute.Water_Gas_Flow_Pattern.ToString() },
                   //     new PropertyDisplay { PropertyName = "No_Rows", PropertyValue = element.attribute.No_Rows },
                   //     new PropertyDisplay { PropertyName = "SLN", PropertyValue = element.attribute.SLN },
                    //    new PropertyDisplay { PropertyName = "STN", PropertyValue = element.attribute.STN.ToString() },
                  };

            propertyListBox.ItemsSource = propertyList;
        }


        private void setNumber_Click(object sender, MouseButtonEventArgs e)
        {
            if (element != null) {
     
            NumberInputDialog dialog = new NumberInputDialog();
            if (dialog.ShowDialog() == true)
            {
                int selectedNumber = dialog.SelectedNumber;
                element.Name = element.State + selectedNumber;     
                (FindName("boilerStage_" + element.Id + "_label") as Label).Content = element.Name;
                }
            }


        
        }


        #endregion






        #region Attribute
        private void AssignItemAttribute(Element element)
        {

            ItemAttribute attribute = new ItemAttribute();
            attribute.loadCase = loadCalse;
            attribute.stage = element.State;
            element.attribute = attribute;

        }
        #endregion

        #region Tools
     
        #region Save
        private void SaveButton_Click(object sender, MouseButtonEventArgs e)
        {
            DatabaseContext dbContext = new DatabaseContext();
            dbContext.DeleteDatabase();
            dbContext.CreateTableIfNotExists();

            foreach (Element element in elements)
            {
                dbContext.SaveData(element);
            }




            foreach (RadioButton item in casesToolBar.Items)
            {
                cases.Add(new Case {Name = item.Content.ToString()});

            }

            foreach(Case @case in cases)
            {
                dbContext.SaveCases(@case);
            }

        }
        #endregion
        #region Load
        private void OpenButton_Click(object sender, MouseButtonEventArgs e)
        {

            DatabaseContext dbContext = new DatabaseContext();
            elements = dbContext.ReadData();
            LoadElements(elements);

            cases = dbContext.ReadCase();
            LoadCases(cases);



        }

        private void LoadElements(List<Element> elements)
        {
            foreach (Element element in elements)
            {
                Image image = element.Image;
             
            }
        }

        private void LoadCases(List<Case> cases)
        {
            foreach (Case @case in cases)
            {
              
            }
        }

        #endregion

        #region Select
        public class PropertyDisplay
        {
            public string PropertyName { get; set; }
            public string PropertyValue { get; set; }
        }
        private void SelectButton_Click(object sender, MouseButtonEventArgs e)
        {

            isSelect = true;
            moveImage.Opacity = 0.2;
            selectImage.Opacity = 1.0;

        }
     

        private void GridElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Grid grid = (Grid)sender;
            Image image = FindName(grid.Name.Replace("_grid", "")) as Image;
            int id = int.Parse(image.Name.Replace("boilerStage_", ""));


            element = elements.Where(element => element.Id == id).FirstOrDefault();
            showProperties(elements.Where(element => element.Id == id).FirstOrDefault());
           
        }
      


        #endregion
        #region Move
        private void MoveButton_Click(object sender, MouseButtonEventArgs e)
        {
            isSelect = false;
            selectImage.Opacity = 0.1;
            moveImage.Opacity = 1.0;
        }
        #endregion


        #region case
        private void CasesMenu_Click(object sender, RoutedEventArgs e)
        {

            casesMenu.Visibility = Visibility.Visible;
        }
       
        #endregion


        #endregion

        #region Menu
        private void New_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }




        private void Elements_Click(object sender, RoutedEventArgs e)
        {
            //   AssignStateNumbers(items);
            FormElements formElements = new FormElements(elements);
            formElements.Show();
        }

        private void Attributes_Click(object sender, RoutedEventArgs e)
        {
            //   AssignStateNumbers(elements);
          //    FormAttributes formAttributes = new FormAttributes();
           //   formAttributes.Show();
            FormItemAttribute formAttributes = new FormItemAttribute(elements, this);
            formAttributes.Show();


        }




        #endregion


        #region canvas


        #region canvasZoom
        private void ZoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double zoomValue = e.NewValue;
            ApplyZoom(zoomValue);
        }

        private void ApplyZoom(double zoomValue)
        {
            canvas.LayoutTransform = new ScaleTransform(zoomValue, zoomValue);
        }
        #endregion

        #region canvasAddImageLabel

        private void AddLabelsToImages(List<Element> elements)
        {
            foreach (var element in elements)
            {
                // Create an Image
                Image image = new Image
                {
                    Source = new BitmapImage(new Uri(element.PathName, UriKind.Relative)),
                    Width = 100,
                    Height = 100
                };

                // Create a Label
                Label label = new Label
                {
                    Content = image.Tag.ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    Background = Brushes.White,
                    Opacity = 0.8
                };

                // Create a container (e.g., a Grid) to hold the image and label
                Grid container = new Grid();
                container.Children.Add(image);
                container.Children.Add(label);

                // Set the position of the container using Canvas.Left and Canvas.Top
                Canvas.SetLeft(container, Canvas.GetLeft(image)); // Match image's X position
                Canvas.SetTop(container, Canvas.GetTop(image) - 30); // Position label above the image

                // Add the container to the canvas
                canvas.Children.Add(container);
            }
        }

        private void label_Click(object sender, MouseButtonEventArgs e)
        {


            AddLabelsToImages(elements);
        }




        #endregion

        #endregion

        #region case

        private void AddCase_Click(object sender, RoutedEventArgs e)
        {
            string caseName = "Case";
            CaseDialogBox caseDialogBox = new CaseDialogBox();
            caseDialogBox.ShowDialog();
            caseName = caseDialogBox.InputText;


            // Create a new RadioButton for the case
             RadioButton radioButton = new RadioButton();
        //    radioButton.Content = "Case " + (casesToolBar.Items.Count + 1);
            radioButton.Content = caseName;
            radioButton.GroupName = "Cases"; // Ensure they are mutually exclusive
            radioButton.TabIndex = cases.Count();
            radioButton.MouseDoubleClick += RadioButton_MouseDoubleClick;
            casesToolBar.Items.Add(radioButton);

        }

        private void RadioButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            RadioButton radioButton = (RadioButton)sender;
            string caseName = "Case";
            CaseDialogBox caseDialogBox = new CaseDialogBox(radioButton.Content.ToString());
            caseDialogBox.ShowDialog();
            caseName = caseDialogBox.InputText;
            radioButton.Content = caseName;

        }

        private void DeleteCase_Click(object sender, RoutedEventArgs e)
        {
            // Find the selected RadioButton and remove it
            RadioButton selectedRadioButton = casesToolBar.Items.OfType<RadioButton>().FirstOrDefault(rb => rb.IsChecked == true);
            if (selectedRadioButton != null)
            {
                casesToolBar.Items.Remove(selectedRadioButton);
            }
        }

        private void DownCase_Click(object sender, RoutedEventArgs e)
        {
            RadioButton selectedRadioButton = casesToolBar.Items.OfType<RadioButton>().FirstOrDefault(rb => rb.IsChecked == true);

            if (selectedRadioButton != null)
            {
                int currentIndex = casesToolBar.Items.IndexOf(selectedRadioButton);

                if (currentIndex < casesToolBar.Items.Count - 1)
                {
                    // Swap the positions of the selected RadioButton and the one below it
                    casesToolBar.Items.RemoveAt(currentIndex);
                    casesToolBar.Items.Insert(currentIndex + 1, selectedRadioButton);
                    selectedRadioButton.IsChecked = true; // Re-select the moved RadioButton
                }
            }
        }

        private void UpCase_Click(object sender, RoutedEventArgs e)
        {
            RadioButton selectedRadioButton = casesToolBar.Items.OfType<RadioButton>().FirstOrDefault(rb => rb.IsChecked == true);

            if (selectedRadioButton != null)
            {
                int currentIndex = casesToolBar.Items.IndexOf(selectedRadioButton);

                if (currentIndex > 0)
                {
                    // Swap the positions of the selected RadioButton and the one above it
                    casesToolBar.Items.RemoveAt(currentIndex);
                    casesToolBar.Items.Insert(currentIndex - 1, selectedRadioButton);
                    selectedRadioButton.IsChecked = true; // Re-select the moved RadioButton
                }
            }
        }

        private void ToolBar_Loaded(object sender, RoutedEventArgs e)
        {
            ToolBar toolBar = sender as ToolBar;
            var overflowGrid = toolBar.Template.FindName("OverflowGrid", toolBar) as FrameworkElement;
            if (overflowGrid != null)
            {
                overflowGrid.Visibility = Visibility.Collapsed;
            }
            var mainPanelBorder = toolBar.Template.FindName("MainPanelBorder", toolBar) as FrameworkElement;
            if (mainPanelBorder != null)
            {
                mainPanelBorder.Margin = new Thickness();
            }
        }

        private void SelectCase_Click(object sender, RoutedEventArgs e)
        {
            RadioButton selectedRadioButton = casesToolBar.Items.OfType<RadioButton>().FirstOrDefault(rb => rb.IsChecked == true);
           
            foreach (RadioButton btn  in casesToolBar.Items.OfType<RadioButton>())
            {
                btn.Foreground = Brushes.Black;
                btn.BorderThickness = new System.Windows.Thickness(0);
            }
            if (selectedRadioButton != null)
            {
                // تغییر رنگ متن بر اساس انتخاب کاربر
                selectedRadioButton.Foreground = Brushes.Green; // به عنوان مثال رنگ قرمز را انتخاب کردیم
                selectedRadioButton.BorderBrush = Brushes.Black; // Border color (black in this case)
                selectedRadioButton.BorderThickness = new System.Windows.Thickness(2);
            }
        }

     
    }
    #endregion




}
