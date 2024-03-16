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
using System.Windows.Media.Animation;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BDC
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public ObservableCollection<CustomCase> Objects { get; set; }


        public List<Element> elements { get; set; }
     
        public Furnace furnace { get; set; }

        public List<Duct> ducts { get; set; }
 
        public List<GasFuel> gasFuels { get; set; }
        public List<OilFuel> oilFuels { get; set; }
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
            gasFuels = new List<GasFuel>();
            oilFuels = new List<OilFuel>();

        elements = new List<Element>();
            for (int i = 1; i <= 8; i++)
            {
                Element element = new Element();
                ItemAttribute itemAttribute = new ItemAttribute();
                element.attribute = itemAttribute;
                elements.Add(element);
            }
            cases = new List<Case>();

 
            Objects = new ObservableCollection<CustomCase>();
            ObjectListBox.ItemsSource = Objects;


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
                    if (element.attribute.active)
                    {
                        if (element.Id < 8 )
                        {
                            if (element.attribute.section == 0)
                                image.Source = new BitmapImage(new Uri("/Images/Elements/superheater.png", UriKind.Relative));
                            if (element.attribute.section == 1)
                                image.Source = new BitmapImage(new Uri("/Images/Elements/evaporator.png", UriKind.Relative));
                            if (element.attribute.section == 2)
                                image.Source = new BitmapImage(new Uri("/Images/Elements/economizer.png", UriKind.Relative));
                        } 
                        //else if ( element.Id == 8 || element.Id == 10)
                        //{
                        //    image.Source = new BitmapImage(new Uri("/Images/Elements/duct.png", UriKind.Relative));
                        //} 
                        else if (element.Id == 8)
                        {
                            image.Source = new BitmapImage(new Uri("/Images/Elements/economizer.png", UriKind.Relative));
                        }
                        //else
                        //{
                        //    image.Source = new BitmapImage(new Uri("/Images/Elements/fan.png", UriKind.Relative));
                        //}
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
            // Assuming you have an object called element that has the attribute property
            var propertyDisplays = new List<PropertyDisplay>();
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "Section Name", PropertyValue = element.attribute.sectionName.ToString() });
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "Channel Height (m)", PropertyValue = element.attribute.Channel_Height });
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "Channel Width (m)", PropertyValue = element.attribute.Channel_Width });
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "NO# Rows", PropertyValue = element.attribute.No_Rows });
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "NO# Tubes/Row", PropertyValue = element.attribute.No_Tubes_Row });
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "Longitudinal Pitch (mm)", PropertyValue = element.attribute.Longitudinal_Pitch });
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "Transverse Pitch (mm)", PropertyValue = element.attribute.Transverse_Pitch });
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "NO# Water Carrying Tubes", PropertyValue = element.attribute.NO_Water_Carrying_Tubes });
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "Tube Length/Water Flow (m)", PropertyValue = element.attribute.Tube_Length });
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "Tube Outer Diameter (mm)", PropertyValue = element.attribute.Tube_Outer_Diameter });
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "Tube Wall Thickness (mm)", PropertyValue = element.attribute.Tube_Wall_Thickness });
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "Incidence Angle (deg)", PropertyValue = element.attribute.Incidence_Angle });
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "Fin Height (mm)", PropertyValue = element.attribute.Fin_Height });
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "Fin Thickness (mm)", PropertyValue = element.attribute.Fin_Thickness });
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "Fin Density (fin/m)", PropertyValue = element.attribute.Fin_Density });
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "Fin Uncut Height (mm)", PropertyValue = element.attribute.Fin_Uncut_Height });
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "Fin Segment Width (mm)", PropertyValue = element.attribute.Fin_Segment_Width });
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "Fin Material", PropertyValue = element.attribute.Fin_Material });
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "Water-Side Founling Factor (m2K/W)", PropertyValue = element.attribute.Water_Side_Founling_Factor });
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "Gas-Side Founling Factor (m2K/W)", PropertyValue = element.attribute.Gas_Side_Founling_Factor });
            propertyDisplays.Add(new PropertyDisplay { PropertyName = "Usage Factor (0,1)", PropertyValue = element.attribute.Usage_Factor });

            propertyListBox.ItemsSource = propertyDisplays;
        }


        private void setNumber_Click(object sender, RoutedEventArgs e)
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
       //     attribute.loadCase = loadCalse;
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
          
            for(int i = 1; i < 9; i++)
            (FindName("boilerStage_"+i+"_grid") as Grid).Background=  Brushes.White;
            grid.Background = Brushes.Green;


        }



        #endregion
     

        #region case
        private void CasesMenu_Click(object sender, RoutedEventArgs e)
        {

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
           
            }
        }

        private void label_Click(object sender, MouseButtonEventArgs e)
        {


            AddLabelsToImages(elements);
        }




        #endregion

        #endregion

        #region case

    
        

        public class CustomCase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private bool _isSelected;
            public bool IsSelected
            {
                get { return _isSelected; }
                set
                {
                    if (_isSelected != value)
                    {
                        _isSelected = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));

                        if (_isSelected)
                        {
                            foreach (var otherCase in ((MainWindow)Application.Current.MainWindow).Objects.Where(c => c != this && c.IsSelected))
                            {
                                otherCase.IsSelected = false;
                            }
                        }
                    }
                }
            }

            private BitmapImage _imageSource;
            public BitmapImage ImageSource
            {
                get { return _imageSource; }
                set
                {
                    if (_imageSource != value)
                    {
                        _imageSource = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImageSource)));
                    }
                }
            }

            private string _label;
            public string Label
            {
                get { return _label; }
                set
                {
                    if (_label != value)
                    {
                        _label = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Label)));
                    }
                }
            }
        }

        private void RemoveSelectedItems()
        {
            // Create a list to hold the items to remove
            var itemsToRemove = new List<CustomCase>();

            // Iterate through the Objects collection and add selected items to the list
            foreach (var item in Objects)
            {
                if (item.IsSelected)
                {
                    itemsToRemove.Add(item);
                  
                }
            }

            // Remove selected items from the Objects collection
            foreach (var item in itemsToRemove)
            {
                Objects.Remove(item);
                cases.RemoveAll(c => c.Name == item.Label);
            }

        }


        private void AddCase_Click(object sender, RoutedEventArgs e)
        {

            string caseName = "Case";
            CaseDialogBox caseDialogBox = new CaseDialogBox();
            caseDialogBox.ShowDialog();
            if (!caseDialogBox.DialogResult.Value) return;
            caseName = caseDialogBox.InputText;
            if (cases.Any(c => c.Name == caseName))
            {
                MessageBox.Show("Case name must be unique. Please enter a different name.");
                return; 
            }

            Objects.Add(new CustomCase
            {
                IsSelected = false,
                ImageSource = new BitmapImage(new Uri("Images/Other/denied.png", System.UriKind.Relative)),
                Label = caseName
            });
            cases.Add(new Case { Name = caseName, run = false , process = new Process()  });
            //AddCase(new Case { Id = cases.Count() + 1, Name = caseName, run = false });
            //return;
        }
   
        private void RemoveCase_Click(object sender, RoutedEventArgs e)
        {

            RemoveSelectedItems();

        }

        private void PlayCase_Click(object sender, RoutedEventArgs e)
        {

        }


        #endregion
        #region menuMiddle
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


    
        private void formFurnace_Click(object sender, RoutedEventArgs e)
        {
            FormFurnace formFurnace = new FormFurnace(furnace,this);
            formFurnace.Show();

        }

        private void formDuct_Click(object sender, RoutedEventArgs e)
        {
            FormDuct formDuct = new FormDuct(ducts,this);
            formDuct.Show();

        }

        private void formFuel_Click(object sender, RoutedEventArgs e)
        { 

        FormFuel formFuel = new FormFuel(oilFuels,gasFuels ,this);
            formFuel.Show();
        }

        private void ExportMenu_Click(object sender, RoutedEventArgs e)
        {

            Export export = new Export(System.AppDomain.CurrentDomain.BaseDirectory + @"Export.txt");
            export.ExportFurnace(furnace);   
            export.ExportElement(elements);
            export.ExportDuct(ducts);
            export.ExportOilFuel(oilFuels);
            export.ExportGasFuel(gasFuels);
            List<Process> processes = new List<Process>();
            foreach (Case @case in cases)
            processes.Add(@case.process);
            export.ExportProcess(processes);
            export.ExportCases(cases);

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

        private void formProcess_Click(object sender, RoutedEventArgs e)
        {
         //   CaseBuiler();
            FormProcess formProcess = new FormProcess(cases,this);
            formProcess.Show();
        }

       
    }
    #endregion




}
