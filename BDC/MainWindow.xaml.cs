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
using Microsoft.VisualBasic;
using Accessibility;
using System.Xml.Linq;
using System.Reflection;

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
     
        public Furnace furnace { get; set; }

        public List<Duct> ducts { get; set; }
        public List<Case> cases{ get; set; }
        private Case selectedCase;

        private Element element;
       

        private List<ItemAttribute> itemAttribute;
        private Button clickedButton;
        private Image imageLevelButton;
        private ImageSource draggedImageSource;
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
            furnace = new Furnace();

            ducts = new List<Duct>();
            

            elements = new List<Element>();
            for (int i = 1; i <= 11; i++)
            {
                Element element = new Element();
                ItemAttribute itemAttribute = new ItemAttribute();
                element.attribute = itemAttribute;
                elements.Add(element);
            }
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

        public void updateElement()
        {

            foreach (Element element in elements)
            {
                Image image = FindName("boilerStage_" + element.Id) as Image;
                if (image != null )
                {
                    if (!element.attribute.active)
                    {
                        if (element.Id < 8 )
                        {
                            if (element.attribute.section == 0)
                                image.Source = new BitmapImage(new Uri("/Images/Elements/superheater.png", UriKind.Relative));
                            if (element.attribute.section == 1)
                                image.Source = new BitmapImage(new Uri("/Images/Elements/evaporator.png", UriKind.Relative));
                            if (element.attribute.section == 2)
                                image.Source = new BitmapImage(new Uri("/Images/Elements/economizer.png", UriKind.Relative));
                        } else if ( element.Id == 8 || element.Id == 10)
                        {
                            image.Source = new BitmapImage(new Uri("/Images/Elements/duct.png", UriKind.Relative));
                        } else if (element.Id == 9)
                        {
                            image.Source = new BitmapImage(new Uri("/Images/Elements/economizer.png", UriKind.Relative));
                        }
                        else
                        {
                            image.Source = new BitmapImage(new Uri("/Images/Elements/fan.png", UriKind.Relative));
                        }
                       (FindName("boilerStage_" + element.Id + "_label") as Label).Content = element.attribute.sectionName;

                    }
                    else
                    {
                        image.Source = null;
                        (FindName("boilerStage_" + element.Id + "_label") as Label).Content = null;
                    }
                }
               


                    if (element.attribute.section == 0)
                {

                }
            //    (FindName("boilerStage_" + element.Id + "_label") as Label).Content = element.Name;
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
        //    attribute.stage = element.State;
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


            foreach (Case @case in cases)
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


        private void GridElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Grid grid = (Grid)sender;
            Image image = FindName(grid.Name.Replace("_grid", "")) as Image;
            int id = int.Parse(image.Name.Replace("boilerStage_", ""));


            element = elements.Where(element => element.Id == id).FirstOrDefault();
            showProperties(elements.Where(element => element.Id == id).FirstOrDefault());
          
            for(int i = 1; i < 12; i++)
            (FindName("boilerStage_"+i+"_grid") as Grid).Background=  Brushes.White;
            grid.Background = Brushes.Green;


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

        private void Cases_Click(object sender, RoutedEventArgs e)
        {
            FormCase formCase = new FormCase(cases, this);
            formCase.Show();
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

        private void CaseBuiler(int id,int operation,string name = null , int order = 0)
        {


             Case @case = cases.Find(x => x.Id == id);
            @case.Name = name;
            @case.order = order;
            switch (operation)
            {
                //add
                case 1:
                    cases.Add(@case);
                    break;
                //remove
                case 2:
                    cases.Remove(@case);
                    break;
                //rename
                case 3:
                    break;
                //order
                case 4:
                    break;


                default:
                    break;
            }



            foreach (RadioButton item in casesToolBar.Items)
            {
                cases.Add(new Case { Name = item.Content.ToString() });

            }
  
        }

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

          //  CaseBuiler();
        }

        private void RadioButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            RadioButton radioButton = (RadioButton)sender;
            string caseName = "Case";
            CaseDialogBox caseDialogBox = new CaseDialogBox(radioButton.Content.ToString());
            caseDialogBox.ShowDialog();
            caseName = caseDialogBox.InputText;
            radioButton.Content = caseName;

         //   CaseBuiler();
        }

        private void DeleteCase_Click(object sender, RoutedEventArgs e)
        {
            // Find the selected RadioButton and remove it
            RadioButton selectedRadioButton = casesToolBar.Items.OfType<RadioButton>().FirstOrDefault(rb => rb.IsChecked == true);
            if (selectedRadioButton != null)
            {
                casesToolBar.Items.Remove(selectedRadioButton);
            }
         //   CaseBuiler();
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
         //   CaseBuiler();
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
            //    btn.Foreground = Brushes.Black;
                btn.BorderThickness = new System.Windows.Thickness(0);
            }
            if (selectedRadioButton != null)
            {
                // تغییر رنگ متن بر اساس انتخاب کاربر
                selectedRadioButton.BorderBrush = Brushes.Black; // Border color (black in this case)
                selectedRadioButton.BorderThickness = new System.Windows.Thickness(2);
                selectedCase = cases.Find(match: x => x.Name == selectedRadioButton.Content.ToString());
            }
        }

        private void PlayCase_Click(object sender, RoutedEventArgs e)
        {
            RadioButton selectedRadioButton = casesToolBar.Items.OfType<RadioButton>().FirstOrDefault(rb => rb.IsChecked == true);
            if (selectedRadioButton != null && selectedCase != null)
            {
                if (selectedRadioButton.Content.ToString() != selectedCase.Name)
                {
                    MessageBox.Show("Please check correct case");
                    return;
                }
                else
                {
                    selectedRadioButton.Foreground = Brushes.Green;
                }
            }
            else
            {
                MessageBox.Show("Please check correct case");
                return;
            }
        }

        private void formFurnace_Click(object sender, MouseButtonEventArgs e)
        {
            FormFurnace formFurnace = new FormFurnace(furnace,this);
            formFurnace.Show();

        }

        private void formDuct_Click(object sender, MouseButtonEventArgs e)
        {
            FormDuct formDuct = new FormDuct(ducts,this);
            formDuct.Show();

        }

        private void formFuel_Click(object sender, MouseButtonEventArgs e)
        {
            FormFuel formFuel = new FormFuel();
            formFuel.Show();
        }

        private void ExportMenu_Click(object sender, RoutedEventArgs e)
        {

          //  Export export = new Export(@"e:\1.txt");
            Export export = new Export(@"c:\projects\1.txt");
            export.ExportFurnace(furnace);   
            export.ExportElement(elements);
            export.ExportDuct(ducts);

          //  ExportToFile(furnace, @"e:\1.txt");
        }
        public static void ExportToFile(object obj, string filePath)
        {


            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();

            using (StreamWriter writer = new StreamWriter(filePath,true))
            {
                foreach (PropertyInfo prop in properties)
                {
                    object value = prop.GetValue(obj);
                    string line = $"{prop.Name}: {value}";
                    writer.WriteLine(line);
                }
            }
        }
    }
    #endregion




}
