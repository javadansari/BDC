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
using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Globalization;


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
        public Element activeElement;
        public Inputs inputs;

        public Furnace furnace { get; set; }

        public List<Duct> ducts { get; set; }

        public List<GasFuel> gasFuels { get; set; }
        public List<OilFuel> oilFuels { get; set; }
        public List<Case> cases { get; set; }
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


            inputs = new Inputs();
            draggedImage = new Image();
            furnace = new Furnace();
            element = new Element();
            ducts = new List<Duct>();
            Duct duct = new Duct();
            duct.id = 1;
            ducts.Add(duct);
            gasFuels = new List<GasFuel>();
            GasFuel gasFuel = new GasFuel();
            gasFuel.id = 1;
            gasFuels.Add(gasFuel);
            oilFuels = new List<OilFuel>();
            OilFuel oilFuel = new OilFuel();
            oilFuel.id = 1;
            oilFuels.Add(oilFuel);

            elements = new List<Element>();
            for (int i = 1; i <= 8; i++)
            {
                Element element = new Element();
                element.Id = i;
                ItemAttribute itemAttribute = new ItemAttribute();
                element.attribute = itemAttribute;
                elements.Add(element);
            }
            cases = new List<Case>();
            Objects = new ObservableCollection<CustomCase>();
            ObjectListBox.ItemsSource = Objects;
            activeElement = new Element();



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
                if (image != null)
                {
                    if (element.attribute.active)
                    {
                        if (element.Id < 8)
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

        private Element setElement(Image image, int id)
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
            //   propertyDisplays.Add(new PropertyDisplay { PropertyName = "Section Name", PropertyValue = element.attribute.sectionName.ToString() });
            propertyDisplays.Add(new PropertyDisplay { PropertyRealName = "Channel_Height", PropertyName = "Channel Height (m)", PropertyValue = element.attribute.Channel_Height });
            propertyDisplays.Add(new PropertyDisplay { PropertyRealName = "attribute", PropertyName = "Channel Width (m)", PropertyValue = element.attribute.Channel_Width });
            propertyDisplays.Add(new PropertyDisplay { PropertyRealName = "No_Rows", PropertyName = "NO# Rows", PropertyValue = element.attribute.No_Rows });
            propertyDisplays.Add(new PropertyDisplay { PropertyRealName = "No_Tubes_Row", PropertyName = "NO# Tubes/Row", PropertyValue = element.attribute.No_Tubes_Row });
            propertyDisplays.Add(new PropertyDisplay { PropertyRealName = "Longitudinal_Pitch", PropertyName = "Longitudinal Pitch (mm)", PropertyValue = element.attribute.Longitudinal_Pitch });
            propertyDisplays.Add(new PropertyDisplay { PropertyRealName = "Transverse_Pitch", PropertyName = "Transverse Pitch (mm)", PropertyValue = element.attribute.Transverse_Pitch });
            propertyDisplays.Add(new PropertyDisplay { PropertyRealName = "NO_Water_Carrying_Tubes", PropertyName = "NO# Water Carrying Tubes", PropertyValue = element.attribute.NO_Water_Carrying_Tubes });
            propertyDisplays.Add(new PropertyDisplay { PropertyRealName = "Tube_Length", PropertyName = "Tube Length/Water Flow (m)", PropertyValue = element.attribute.Tube_Length });
            propertyDisplays.Add(new PropertyDisplay { PropertyRealName = "Tube_Outer_Diameter", PropertyName = "Tube Outer Diameter (mm)", PropertyValue = element.attribute.Tube_Outer_Diameter });
            propertyDisplays.Add(new PropertyDisplay { PropertyRealName = "Tube_Wall_Thickness", PropertyName = "Tube Wall Thickness (mm)", PropertyValue = element.attribute.Tube_Wall_Thickness });
            propertyDisplays.Add(new PropertyDisplay { PropertyRealName = "Incidence_Angle", PropertyName = "Incidence Angle (deg)", PropertyValue = element.attribute.Incidence_Angle });
            propertyDisplays.Add(new PropertyDisplay { PropertyRealName = "Fin_Height", PropertyName = "Fin Height (mm)", PropertyValue = element.attribute.Fin_Height });
            propertyDisplays.Add(new PropertyDisplay { PropertyRealName = "Fin_Thickness", PropertyName = "Fin Thickness (mm)", PropertyValue = element.attribute.Fin_Thickness });
            propertyDisplays.Add(new PropertyDisplay { PropertyRealName = "Fin_Density", PropertyName = "Fin Density (fin/m)", PropertyValue = element.attribute.Fin_Density });
            propertyDisplays.Add(new PropertyDisplay { PropertyRealName = "Fin_Uncut_Height", PropertyName = "Fin Uncut Height (mm)", PropertyValue = element.attribute.Fin_Uncut_Height });
            propertyDisplays.Add(new PropertyDisplay { PropertyRealName = "Fin_Segment_Width", PropertyName = "Fin Segment Width (mm)", PropertyValue = element.attribute.Fin_Segment_Width });
            //   propertyDisplays.Add(new PropertyDisplayPropertyRealName ="Channel_Height" ,{ PropertyName = "Fin Material", PropertyValue = element.attribute.Fin_Material });
            propertyDisplays.Add(new PropertyDisplay { PropertyRealName = "Water_Side_Founling_Factor", PropertyName = "Water-Side Founling Factor (m2K/W)", PropertyValue = element.attribute.Water_Side_Founling_Factor });
            propertyDisplays.Add(new PropertyDisplay { PropertyRealName = "Gas_Side_Founling_Factor", PropertyName = "Gas-Side Founling Factor (m2K/W)", PropertyValue = element.attribute.Gas_Side_Founling_Factor });
            propertyDisplays.Add(new PropertyDisplay { PropertyRealName = "Usage_Factor", PropertyName = "Usage Factor (0,1)", PropertyValue = element.attribute.Usage_Factor });

            propertyListBox.ItemsSource = propertyDisplays;
        }


        private void generalInput_Click(object sender, RoutedEventArgs e)
        {

            GeneralInput generalInput = new GeneralInput(inputs,this);
            generalInput.Show();
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
            public string PropertyRealName { get; set; }
            public string PropertyValue { get; set; }
        }


        private void GridElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Grid grid = (Grid)sender;
            Image image = FindName(grid.Name.Replace("_grid", "")) as Image;
            int id = int.Parse(image.Name.Replace("boilerStage_", ""));


            element = elements.Where(element => element.Id == id).FirstOrDefault();
            if (!element.attribute.active) return;
            showProperties(elements.Where(element => element.Id == id).FirstOrDefault());

            for (int i = 1; i < 9; i++)
                (FindName("boilerStage_" + i + "_grid") as Grid).Background = Brushes.White;
            grid.Background = Brushes.Green;
            activeElement = element;

        }

        private void apply_Click(object sender, RoutedEventArgs e)
        {
            if (activeElement == null) return;
            foreach (PropertyDisplay item in propertyListBox.Items)
            {

                Type elementType = activeElement.attribute.GetType();
                // Find the property with the desired name
                PropertyInfo propertyInfo = elementType.GetProperty(item.PropertyRealName);

                if (propertyInfo != null)
                {
                    // Set the value for the property

                    propertyInfo.SetValue(elements.Where(element => element.Id == activeElement.Id).FirstOrDefault().attribute, item.PropertyValue);
                }



            }



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
            NewButton_Click(sender, e);
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenButton_Click(sender, e);
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveButton_Click(sender, e);
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

                        //if (_isSelected)
                        //{
                        //    foreach (var otherCase in ((MainWindow)Application.Current.MainWindow).Objects.Where(c => c != this && c.IsSelected))
                        //    {
                        //        otherCase.IsSelected = false;
                        //    }
                        //}
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
            private string _tag;
            public string Tag
            {
                get { return _tag; }
                set
                {
                    if (_tag != value)
                    {
                        _tag = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tag)));
                    }
                }
            }
        }
        private void ClasesCases()
        {
            var itemsToRemove = new List<CustomCase>();
            foreach (var item in Objects)
            {
                itemsToRemove.Add(item);

            }
            Objects.Clear();
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

            int count = 0;
            // Remove selected items from the Objects collection
            foreach (var item in itemsToRemove)
            {
                Objects.Remove(item);
                cases.RemoveAll(c => c.Name == item.Tag);
                count++;
            }
            Objects.Clear();
            List<Case> newCases = new List<Case>(cases);
            cases.Clear();
            foreach (Case @case in newCases)
            {
                addCase(@case.Name);
                @case.process.id = cases.Count() + 1;
                cases.Add(@case);
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
            addCase(caseName);
            cases.Add(new Case { Name = caseName, run = false, process = new Process { name = caseName } });
            //AddCase(new Case { Id = cases.Count() + 1, Name = caseName, run = false });
            //return;
        }

        private void addCase(string caseName)
        {
            Objects.Add(new CustomCase
            {
                IsSelected = false,
                ImageSource = new BitmapImage(new Uri("Images/Other/denied.png", System.UriKind.Relative)),
                Label = (cases.Count() + 1) + " : " + caseName,
                Tag = caseName
            });

        }
        private void RemoveCase_Click(object sender, RoutedEventArgs e)
        {

            RemoveSelectedItems();

        }
        private void PlayCase_Click(object sender, RoutedEventArgs e)
        {
            var saweItems = saveWork();
            if (saweItems.Item1)
            {

                foreach (var item in Objects)
                {
                    if (item.IsSelected)
                    {
                        /// RUN
                        //  Export();
                        string path = saweItems.Item2 + @"Run-" + item.Tag + ".txt";
                  //      string path = System.AppDomain.CurrentDomain.BaseDirectory + @"Export-" + item.Tag + ".txt";
                        Case thisCase = cases.FirstOrDefault(c => c.Name == item.Tag);
                        Export export = new Export(path);
                        Export(path, new List<Process> { thisCase.process });
                        export.run(path, item.Tag);
                    }
                }
            }
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
            FormFurnace formFurnace = new FormFurnace(furnace, this);
            formFurnace.Show();

        }

        private void formDuct_Click(object sender, RoutedEventArgs e)
        {
            FormDuct formDuct = new FormDuct(ducts, this);
            formDuct.Show();

        }

        private void formFuel_Click(object sender, RoutedEventArgs e)
        {

            FormFuel formFuel = new FormFuel(oilFuels, gasFuels, this);
            formFuel.Show();
        }

        private void ExportMenu_Click(object sender, RoutedEventArgs e)
        {
            List<Process> processes = new List<Process>();
            foreach (Case @case in cases)
                processes.Add(@case.process);
            string exportPath = System.AppDomain.CurrentDomain.BaseDirectory + @"Export.txt";
            Export(exportPath,processes);
        }

        private void Export(string exportPath,List<Process> processes)
        {
            if (cases.Count == 0)
            {
                MessageBox.Show("First define Case");
                return ;
            }
          
            Export export = new Export(exportPath);
            if (File.Exists(exportPath)) File.Delete(exportPath);
            /// check time  
            if (DateTime.Now.Year < 2026)
            {

                export.ExportInput(inputs);
                export.ExportFurnace(furnace);
                export.ExportElement(elements);
                export.ExportDuct(ducts);
            }
            export.ExportOilFuel(oilFuels);
            export.ExportGasFuel(gasFuels);
            export.ExportProcess(processes);
            MessageBox.Show("Project saved in : " + exportPath);

        }
        public static void ExportToFile(object obj, string filePath)
        {


            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();

            using (StreamWriter writer = new StreamWriter(filePath, true))
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
            FormProcess formProcess = new FormProcess(cases, this);
            formProcess.Show();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            saveWork();

        }

        private (bool,string) saveWork()
        {
            List<Process> processes = new List<Process>();
            foreach (Case @case in cases)
                processes.Add(@case.process);

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "Export"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension
            string exportPath = "";
            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                exportPath = dlg.FileName;
                //    string exportPath = System.AppDomain.CurrentDomain.BaseDirectory + @"Export.txt";
                Export(exportPath, processes);
            }

            return (result.Value, exportPath);

        }


        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            OpenFileDialog dlg = new OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".txt";
            dlg.Filter = "BDC File (*.txt)|*.txt";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            string filename = "";
            if (result == true)
            {
                // Open document 
                filename = dlg.FileName;

            
            Import import = new Import(filename);
            inputs = import.ImportInputs();
            furnace = import.ImportFurnace();
            elements = import.ImportElements();
            ducts = import.ImportDucts();
            gasFuels = import.ImportGasFuels();
            oilFuels = import.ImportOilFuels();
            ClasesCases();
            cases = import.ImportCases();  
            foreach (Case @case in cases)
            {
                addCase(@case.Name);
            }
            this.updateElement();
            }

        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {


            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();


        }


    }


    #endregion


   
}
