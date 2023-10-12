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

namespace BDC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private List<Item> items;
        private List<Element> elements;
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
            items = new List<Item>();

            for (int i = 0; i < 11; i++)
            {
                Item item = new Item { id = i };
                items.Add(item);
            }
            elements = new List<Element>();
        
            
            canvas.LayoutTransform = new ScaleTransform(0.8, 0.8);
            

        }
        #endregion

        #region Path


        private void escapePath()
        {
            if (isLine)
            {
                toolbarMenu.Visibility = Visibility.Visible;
                isFirstLine = true;
                reportText.Text = "";
                isLine = false;
            }
        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                escapePath();
                e.Handled = true;
            }
        }

        private void removePath(string pathName)
        {
            string tagToRemove = pathName;

            System.Windows.Shapes.Path pathToRemove = null;

            foreach (UIElement element in canvas.Children)
            {
                if (element is System.Windows.Shapes.Path path && path.Tag is string tag && tag == tagToRemove)
                {
                    pathToRemove = path;
                    break; // Assuming you want to remove only the first path with the given tag
                }

            }
            if (pathToRemove != null)
            {
                canvas.Children.Remove(pathToRemove);
            }

            foreach (UIElement element in canvas.Children)
            {
                if (element is Polygon polygon && polygon.Tag != null && polygon.Tag.ToString() == pathName)
                {
                    // Remove the Polygon from the canvas
                    canvas.Children.Remove(polygon);
                    break; // Exit the loop once you've found and removed the Polygon
                }
            }
        }
     
        #endregion

        #region PathPlut
        private void line_Click(object sender, MouseButtonEventArgs e)
        {
            toolbarMenu.Visibility = Visibility.Hidden;
            reportText.Text = "Choose the first level";
            isLine = true;
        }


        private void DroppedImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (isSelect)
            {
                showProperties(returnElement((Image)sender));
                return;
            }
            if (isLine)
            {

                if (isFirstLine)
                {
                    firstLineImage = (Image)sender;
                    reportText.Text = "Choose the second level";
                    isFirstLine = false;
                }
                else
                {
                    secondLineImage = (Image)sender;
                    if (firstLineImage != secondLineImage)
                    {

                        //     int i = items[int.Parse(firstLineButton.Tag.ToString())].connection;
                        //     int b = int.Parse(secondLineButton.Tag.ToString());
                        Element firstImage = returnElement(firstLineImage);
                        Element secondImage = returnElement(secondLineImage);
                        string pathName = firstImage.Id.ToString();
                        if (secondImage.Connection == firstImage.Id)
                            pathName = secondImage.Id.ToString();
                        removePath(pathName);
                        //       double centerY = 230 + firstLineButton.ActualHeight / 2;
                        //       Point clickPoint = Mouse.GetPosition(clickedButton);

                        generateImagePath(firstLineImage, secondLineImage, pathName, true);


                        firstImage.Connection = secondImage.Id;
                        firstImage.PathName = pathName;
                        secondImage.PathName = firstImage.Id.ToString();

                    }
                    escapePath();
                }


            }
            else
            {
                currentDraggedImage = (Image)sender;
                startPoint = e.GetPosition(canvas);
                currentDraggedImage.CaptureMouse();
            }


        }


        private void generateImagePath(Image firstImage, Image secondImage, string pathName, bool invertY = false)
        {
         //   Point startPoint = new Point(Canvas.GetLeft(firstImage) + firstImage.ActualWidth / 2, Canvas.GetTop(firstImage) + firstImage.ActualHeight / 2);
            Point startPoint = new Point(Canvas.GetLeft(firstImage) + firstImage.ActualWidth , Canvas.GetTop(firstImage) + firstImage.ActualHeight / 2);
        //    Point endPoint = new Point(Canvas.GetLeft(secondImage) + secondImage.ActualWidth / 2, Canvas.GetTop(secondImage) + secondImage.ActualHeight / 2);
            Point endPoint = new Point(Canvas.GetLeft(secondImage) + secondImage.ActualWidth , Canvas.GetTop(secondImage) + secondImage.ActualHeight / 2);

            WriteLine(startPoint.X + " - " + endPoint.X + " / " + Canvas.GetLeft(firstImage) + " - " + Canvas.GetLeft(secondImage));

            double dx = endPoint.X - startPoint.X;
            double dy = endPoint.Y - startPoint.Y;

            //   Random random = new Random();
            //   int randomHeight = random.Next(20, 50) ; // Generates a random number between 20 and 50
          //  int randomHeight = (int)(endPoint.Y);
            int randomHeight = (int)((dy)) + 40;
            if (dy <0) randomHeight =  40;
            Point midPoint = new Point(startPoint.X + dx / 2, startPoint.Y + dy / 2);

            if (invertY)
            {
                startPoint.Y = startPoint.Y + firstImage.ActualHeight / 2;
                endPoint.Y = endPoint.Y + secondImage.ActualHeight / 2;
                midPoint.Y = midPoint.Y + firstImage.ActualHeight / 2;
                randomHeight = -randomHeight;
            }
            else
            {
                startPoint.Y = startPoint.Y - firstImage.ActualHeight / 2;
                endPoint.Y = endPoint.Y - secondImage.ActualHeight / 2;
                midPoint.Y = midPoint.Y - firstImage.ActualHeight / 2;
            }

            PathGeometry pathGeometry = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = startPoint;

            LineSegment lineSegment1 = new LineSegment(new Point(startPoint.X, startPoint.Y - randomHeight), true);
            BezierSegment bezierSegment = new BezierSegment(new Point(midPoint.X, startPoint.Y - randomHeight),
                                                            new Point(midPoint.X, startPoint.Y - randomHeight),
                                                            new Point(endPoint.X, startPoint.Y - randomHeight), true);
            LineSegment lineSegment2 = new LineSegment(endPoint, true);

            pathFigure.Segments.Add(lineSegment1);
            pathFigure.Segments.Add(bezierSegment);

            pathFigure.Segments.Add(lineSegment2);

            pathGeometry.Figures.Add(pathFigure);

            System.Windows.Shapes.Path path = new System.Windows.Shapes.Path
            {
                Data = pathGeometry,
                Stroke = Brushes.Red,
                StrokeThickness = 2,
                Tag = pathName // Set the Tag property to the provided path name
            };

            canvas.Children.Add(path);

            // Calculate the angle of the line
            double angle = Math.Atan2(dy, dx) / Math.PI;

            // Calculate the horizontal position of the arrowhead
            double arrowWidth = 10; // Width of the arrowhead
            double arrowX = midPoint.X - arrowWidth / 2; // Position centered on the midpoint

            int renderTransform = (int)midPoint.Y;
            if (invertY) renderTransform = -(int)midPoint.Y;

            // Add an arrowhead (triangle) at the midpoint
            double arrowEnd = arrowWidth;
            if (startPoint.X - endPoint.X < 0) arrowEnd = -arrowWidth;
            Polygon arrowhead = new Polygon
            {
                Points = new PointCollection
                    {
                   new Point(arrowX, startPoint.Y - randomHeight ), // Tip of the arrowhead
               new Point(arrowX + arrowEnd, startPoint.Y - 5 - randomHeight), // Bottom-right corner of the arrowhead
                new Point(arrowX + arrowEnd, startPoint.Y + 5 - randomHeight) // Top-right corner of the arrowhead
                 },
                Fill = Brushes.Red,
                //   RenderTransform = new RotateTransform(180 + angle * 180, midPoint.X, renderTransform), // Rotate the arrowhead by 180 degrees
                Tag = pathName
            };

            canvas.Children.Add(arrowhead);
        }




        #endregion

        #region Image
        private void item_Click(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            if (button.Content is Image sourceImage)
            {
                imageLevelButton = new Image();
                imageLevelButton.Source = sourceImage.Source.Clone();

            }


            clickedButton.Content = imageLevelButton;
            switch (button.Tag)
            {
                case "sh":
                    //   clickedButton.Content = imageLevelButton;
                    break;
                case "eco":
                    //    SetButtonBackground(clickedButton, "/Images/economizer.png");
                    break;
                case "eva":
                    //     SetButtonBackground(clickedButton, "/Images/evaporator.png");
                    break;
            }


        }
        #endregion

        #region Drag

        #region DragImage

        private void SourceoutElementButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {


            if (!isLine)
            {

                Image image = sender as Image;


                // check if exist
                if (elementer(image)) {
                    Element foundElement = returnName(image.Tag.ToString());
                    if (foundElement != null)
                    {
                        image.Cursor = Cursors.No;
                        return;

                    }
                }

                // check state
                if (checkState(image.Tag.ToString()))
                {
                    image.Cursor = Cursors.No;
                    return;

                }

                // Prepare image for dragging
                draggedImage = new Image
                {
                    Tag = image.Tag,
                    Source = image.Source,
                    Width = image.Width,
                    Height = image.Height
                };

                if (draggedImage != null)
                {
                    DragDrop.DoDragDrop(image, draggedImage, DragDropEffects.Copy);
                }

            }
        }



        private void DroppedImage_MouseMove(object sender, MouseEventArgs e)
        {
        
            Image image = sender as Image;
            if (!isLine)
            {
                if (currentDraggedImage != null && e.LeftButton == MouseButtonState.Pressed)
                {

                //    MessageBox.Show("jj");

                    Point currentPoint = e.GetPosition(canvas);
                    double offsetX = currentPoint.X - startPoint.X;
                    double offsetY = currentPoint.Y - startPoint.Y;

                    double newLeft = Canvas.GetLeft(currentDraggedImage) + offsetX;
                    double newTop = Canvas.GetTop(currentDraggedImage) + offsetY;

                    if (!elementer(draggedImage))
                    {
                        var result = checkInBox(newLeft, newTop);
                        if (!result.IsInside) return;
                    }

                    Canvas.SetLeft(currentDraggedImage, newLeft);
                    Canvas.SetTop(currentDraggedImage, newTop);
                    startPoint = currentPoint;

                    removePath(returnElement(image).PathName);
                }
            }
          
        }

        private void DroppedImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
             Image image = sender as Image;
            if (currentDraggedImage != null)
            {


                // Check Postion
                double x = e.GetPosition(canvas).X;
                double y = e.GetPosition(canvas).Y;

                if (!elementer(draggedImage))
                {
                    var result = checkInBox(x, y);
                    x = result.X; y = result.Y;
                    returnElement(image).Position = result.position;
                    returnElement(image).X = x;
                    returnElement(image).Y = y;
                    if (!result.IsInside) return;
                }  
                Canvas.SetLeft(currentDraggedImage, x - currentDraggedImage.Width / 2);
                Canvas.SetTop(currentDraggedImage, y - currentDraggedImage.Height / 2);

                currentDraggedImage.ReleaseMouseCapture();
                currentDraggedImage = null;
            

                if (returnElement(image).PathName != "-") {

                if (returnElement(image).Connection == 0)
                {
                        string path = returnElement(image).PathName;

                    generateImagePath(returnElementPath(returnElement(image).PathName).Image, returnElement(image).Image, returnElement(image).PathName, true);
                }
                else
                {
                    generateImagePath(returnElement(image).Image, returnElementID(returnElement(image).Connection).Image, returnElement(image).PathName, true);
                }
            }
            }
       

        }


        private void ItemOutButton_Drop(object sender, DragEventArgs e)
        {



            if (draggedImage != null)
            {
                // Check Postion
                double x = e.GetPosition(canvas).X;
                double y = e.GetPosition(canvas).Y;
                int position = 0;
                if (!elementer(draggedImage)){
                    var result = checkInBox(x,y);
                    x = result.X; y = result.Y; position = result.position;
                    if (!result.IsInside) return;
                }

                // Create a new Image and position it on the Canvas
                Image droppedImage = new Image
                {
                    Tag = draggedImage.Tag,
                    Source = draggedImage.Source,
                    Width = draggedImage.Width,
                    Height = draggedImage.Height
                };

                CreateElement(droppedImage, x, y);

                Element element = new Element();
                element.Exist = true;
                element.Name = draggedImage.Tag.ToString();
                element.State = draggedImage.Tag.ToString();
                element.Connection = 0;
                element.Image = droppedImage;
                element.Position = position;
                element.X = x;
                element.Y = y;
                elements.Add(element);
                AssignStateNumbers(elements);



            }


           

        }
        private (bool IsInside, double X, double Y, int position) checkInBox(double leftCanvas, double topCanvas )
        {
    

            int x = -20; 
            int y = 135;
            int width = 57;
            int height = 103;

            for (int i = 1; i < 12; i++)
            {
                x = x + 58;
                if (leftCanvas > x && leftCanvas < x + width && topCanvas > y & topCanvas < y + height) return (true, (2 * x + width) / 2, (2 * y + height) / 2 , i);
            }
          return (false, 0, 0,0);

        }

        #endregion



        #endregion

        #region Element
        private Image CreateElement( Image droppedImage, double x , double y)
        {
          

          //  Point dropPosition = e.GetPosition(canvas);

            Canvas.SetLeft(droppedImage, x - iconSize / 2);
            Canvas.SetTop(droppedImage, y - iconSize / 2);

            //   Canvas.SetLeft(droppedImage, dropPosition.X - draggedImage.Width / 2);
            //   Canvas.SetTop(droppedImage, dropPosition.Y - draggedImage.Height / 2);

            canvas.Children.Add(droppedImage);

            droppedImage.MouseLeftButtonDown += DroppedImage_MouseLeftButtonDown;
            droppedImage.MouseMove += DroppedImage_MouseMove;
            droppedImage.MouseLeftButtonUp += DroppedImage_MouseLeftButtonUp;
            return droppedImage;
        }
        #endregion

        #region Item

        private void AssignStateNumbers(List<Element> elements)
        {
            stateCounters = new Dictionary<string, int>();
            foreach (var element in elements)
            {
                element.StateNumber = 0;
                AssignItemAttribute(element);
            }
            foreach (var element in elements)
            {
                if (element.State == "sh" || element.State == "eva" || element.State == "eco")
                {
                    if (!stateCounters.ContainsKey(element.State))
                    {
                        stateCounters[element.State] = 1;
                    }
                    else
                    {
                        stateCounters[element.State]++;
                        if (stateCounters[element.State] > 3)
                        {
                            // You can handle the case when you exceed 3 items with the same state here

                        }
                    }

                    element.StateNumber = stateCounters[element.State];
                    element.Name = element.State + stateCounters[element.State];
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
        #region Other
        private void WriteLine(string text)
        {
            reportText.Text = text ;
        }
        private bool checkButtonExist(Button button)
        {

            if (items[int.Parse(button.Tag.ToString())].exist) return true;
            else return false;
        }

        private Element returnElement(Image image)
        {
            Element foundElement = elements.FirstOrDefault(element => element.Image == image); if (foundElement != null)
                return foundElement;
            return null;

        }
        private Element returnElement(int connection)
        {
            Element foundElement = elements.FirstOrDefault(element => element.Connection == connection); if (foundElement != null)
                return foundElement;
            return null;

        }
        private Element returnElementID(int id)
        {
            Element foundElement = elements.FirstOrDefault(element => element.Id == id); if (foundElement != null)
                return foundElement;
            return null;

        }
        private Element returnName(string name)
        {
            Element foundElement = elements.FirstOrDefault(element => element.Name == name); if (foundElement != null)
                return foundElement;
            return null;

        }
        private Element returnElementPath(string pathName)
        {
            Element foundElement = elements.FirstOrDefault(element => element.PathName == pathName && element.Connection != 0); if (foundElement != null)
                return foundElement;
            return null;

        }

        private bool checkState(string state)
        {
            if (elements.Count(element => element.State == state) > 2) return true; return false;
        }
        private bool elementer(Image image)
        {
            switch (image.Tag)
            {
                case "fr":
                    return true;
                case "du":
                    return true;
                case "pu":
                    return true;
                case "fan":
                    return true;
                default:
                    return false;
            }

        }
        #endregion
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

        }
        #endregion
        #region Load
        private void OpenButton_Click(object sender, MouseButtonEventArgs e)
        {
           
            DatabaseContext dbContext = new DatabaseContext();
            elements = dbContext.ReadData();
            LoadElements(elements);
        }

        private void LoadElements(List<Element> elements)
        {
            foreach (Element element in elements)
            {
                Image image = element.Image;
                //   BitmapImage bitmapImage = new BitmapImage(new Uri("pack://application:,,,/BDC;component/Images/Elements/fan.png"));
                //  image.src = 'img/base.png';

                //       BitmapImage bitmapImage = new BitmapImage(new Uri(@"C:\FullPathToYourProject\YourProjectName\Images\Elemnts\fan.png"));
                //         image.Source = new BitmapImage(new Uri(@"/Images/Elements/fan.png", UriKind.Relative));

                //   image.Source = new BitmapImage(new Uri(@"pack://application:,,,/BDC;component/Images/Elements/superheater.png"));
                //    image.Source = new BitmapImage(new Uri(element.Image.ToString()));
                // Set the image width and height
                //   image.Width = 40; // Set your desired width
                //   image.Height = 40; // Set your desired height

                // Set the Canvas.Left and Canvas.Top properties to position the image on the canvas
                CreateElement(image, element.X, element.Y);






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
        public void showProperties(Element element)
        {
        
            List<PropertyDisplay> propertyList = new List<PropertyDisplay>
                {
                      new PropertyDisplay { PropertyName = "stage", PropertyValue = element.attribute.stage.ToString() },
                      new PropertyDisplay { PropertyName = "loadCase", PropertyValue = element.attribute.loadCase.ToString() },
                      new PropertyDisplay { PropertyName = "TubeArrangement", PropertyValue = element.attribute.TubeArrangement },
                      new PropertyDisplay { PropertyName = "Water_Gas_Flow_Pattern", PropertyValue = element.attribute.Water_Gas_Flow_Pattern.ToString() },
                      new PropertyDisplay { PropertyName = "No_Rows", PropertyValue = element.attribute.No_Rows },
                      new PropertyDisplay { PropertyName = "SLN", PropertyValue = element.attribute.SLN },
                      new PropertyDisplay { PropertyName = "STN", PropertyValue = element.attribute.STN.ToString() },
                };

            propertyListBox.ItemsSource = propertyList;
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
            toolbarMenu.Visibility = Visibility.Hidden;
            casesMenu.Visibility = Visibility.Visible;
        }
        private void ToolbarMenu_Click(object sender, RoutedEventArgs e)
        {
            toolbarMenu.Visibility = Visibility.Visible;
            casesMenu.Visibility = Visibility.Hidden;
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
          //  FormAttributes formAttributes = new FormAttributes(elements);
          //  formAttributes.Show();

            FormItemAttribute formAttributes = new FormItemAttribute(elements);
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

   
        private void AddCase_Click(object sender, RoutedEventArgs e)
        {
            // Create a new RadioButton for the case
            RadioButton radioButton = new RadioButton();
            radioButton.Content = "Case " + (casesToolBar.Items.Count + 1);
            radioButton.GroupName = "Cases"; // Ensure they are mutually exclusive

            // Add the new case to the toolbar
            casesToolBar.Items.Add(radioButton);
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

     
    }

}
