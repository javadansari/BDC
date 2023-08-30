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
        private Button clickedButton;
        private Image imageLevelButton;
        private ImageSource draggedImageSource;
        private Button draggeButtonSource;
        private bool isFirstLine = true;
        private Image firstLineImage;
        private Image secondLineImage;
        private Button firstLineButton;
        private Button secondLineButton;
        private bool isLine = false;
        private bool isMove = false;
        private Dictionary<string, int> stateCounters;
        private Image draggedImage;
        private Image currentDraggedImage;
        private Point startPoint;
        private double currentScale = 1.0;

        public MainWindow()
        {
            InitializeComponent();
            startInitialize();
          
        }

        #region Start
        private void startInitialize()
        {
            items = new List<Item>();
           
            for (int i = 0; i < 11; i++)
            {
                Item item = new Item { id = i };
                items.Add(item);
            }
            elements = new List<Element>();
        }
        #endregion

        #region Path


        private void levelButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int tagNumber = int.Parse(button.Tag.ToString());
            if (checkButtonExist(button) && isLine)
            {

                if (isFirstLine)
                 {

                            firstLineButton = (Button)sender;
                            reportText.Text = "Choose the second level";
                             isFirstLine = false;
                } else
                {

                         secondLineButton = (Button)sender;
                         if (firstLineButton != secondLineButton) {
                             string pathName = firstLineButton.Tag.ToString();
                             int i = items[int.Parse(firstLineButton.Tag.ToString())].connection;
                             int b = int.Parse(secondLineButton.Tag.ToString());
                             if (items[int.Parse(secondLineButton.Tag.ToString())].connection == int.Parse(firstLineButton.Tag.ToString()))
                             pathName = secondLineButton.Tag.ToString();
                             removePath(pathName);
                             double centerY = 230  + firstLineButton.ActualHeight / 2;
                             Point clickPoint = Mouse.GetPosition(clickedButton);

                            generatePath(firstLineButton, secondLineButton, pathName, clickPoint.Y > centerY);


                             items[int.Parse(firstLineButton.Tag.ToString())].connection = int.Parse(secondLineButton.Tag.ToString());
                             items[int.Parse(firstLineButton.Tag.ToString())].pathName = pathName;
                             items[int.Parse(secondLineButton.Tag.ToString())].pathName = firstLineButton.Tag.ToString();

                     }
               escapePath();
                }
            }

            //   clickedButton = (Button)sender;

        }
     
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

            Path pathToRemove = null;

            foreach (UIElement element in canvas.Children)
            {
                if (element is Path path && path.Tag is string tag && tag == tagToRemove)
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
        private void generatePath(Button firstButton, Button secondButton, string pathName, bool invertY = false)
        {
            Point startPoint = new Point(Canvas.GetLeft(firstButton) + firstButton.ActualWidth / 2, Canvas.GetTop(firstButton) + firstButton.ActualHeight / 2);
            Point endPoint = new Point(Canvas.GetLeft(secondButton) + secondButton.ActualWidth / 2, Canvas.GetTop(secondButton) + secondButton.ActualHeight / 2);

            double dx = endPoint.X - startPoint.X;
            double dy = endPoint.Y - startPoint.Y;

            Random random = new Random();
            int randomHeight = random.Next(20, 50); // Generates a random number between 20 and 50

            Point midPoint = new Point(startPoint.X + dx / 2, startPoint.Y + dy / 2);

            if (invertY)
            {
                startPoint.Y = startPoint.Y + firstButton.ActualHeight / 2;
                endPoint.Y = endPoint.Y + secondButton.ActualHeight / 2;
                midPoint.Y = midPoint.Y + firstButton.ActualHeight / 2;
                randomHeight = - randomHeight;
            }
            else
            {
                startPoint.Y = startPoint.Y - firstButton.ActualHeight / 2;
                endPoint.Y = endPoint.Y - secondButton.ActualHeight / 2;
                midPoint.Y = midPoint.Y - firstButton.ActualHeight / 2;
            }

            PathGeometry pathGeometry = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = startPoint;

            LineSegment lineSegment1 = new LineSegment(new Point(startPoint.X, startPoint.Y - randomHeight), true);
            BezierSegment bezierSegment = new BezierSegment(new Point(midPoint.X, startPoint.Y - randomHeight),
                                                            new Point(midPoint.X, endPoint.Y - randomHeight),
                                                            new Point(endPoint.X, endPoint.Y - randomHeight), true);
            LineSegment lineSegment2 = new LineSegment(endPoint, true);

            pathFigure.Segments.Add(lineSegment1);
            pathFigure.Segments.Add(bezierSegment);
            pathFigure.Segments.Add(lineSegment2);

            pathGeometry.Figures.Add(pathFigure);

            Path path = new Path
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
                   new Point(arrowX, midPoint.Y - randomHeight ), // Tip of the arrowhead
               new Point(arrowX + arrowEnd, midPoint.Y - 5 - randomHeight), // Bottom-right corner of the arrowhead
                new Point(arrowX + arrowEnd, midPoint.Y + 5 - randomHeight) // Top-right corner of the arrowhead
                 },
                Fill = Brushes.Red,
                //   RenderTransform = new RotateTransform(180 + angle * 180, midPoint.X, renderTransform), // Rotate the arrowhead by 180 degrees
                Tag = pathName
            };

            canvas.Children.Add(arrowhead);
        }
        private void lineButton_Click(object sender, RoutedEventArgs e)
        {
            toolbarMenu.Visibility = Visibility.Hidden;
            reportText.Text = "Choose the first level";
            isLine = true;
            //    removePath("MyUniqueTag");
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
                        string pathName = firstImage.id.ToString();
                        if (secondImage.connection == firstImage.id)
                               pathName = secondImage.id.ToString();
                               removePath(pathName);
                        //       double centerY = 230 + firstLineButton.ActualHeight / 2;
                        //       Point clickPoint = Mouse.GetPosition(clickedButton);

                        generateImagePath(firstLineImage, secondLineImage, pathName, true);


                        firstImage.connection = secondImage.id;
                        firstImage.pathName = pathName;
                        secondImage.pathName = firstImage.id.ToString();

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
            Point startPoint = new Point(Canvas.GetLeft(firstImage) + firstImage.ActualWidth / 2, Canvas.GetTop(firstImage) + firstImage.ActualHeight / 2);
            Point endPoint = new Point(Canvas.GetLeft(secondImage) + secondImage.ActualWidth / 2, Canvas.GetTop(secondImage) + secondImage.ActualHeight / 2);

            double dx = endPoint.X - startPoint.X;
            double dy = endPoint.Y - startPoint.Y;

         //   Random random = new Random();
         //   int randomHeight = random.Next(20, 50) ; // Generates a random number between 20 and 50
            int randomHeight = (int)(endPoint.Y); 
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

            Path path = new Path
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
                if (elementer(image)){
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
                    Point currentPoint = e.GetPosition(canvas);
                    double offsetX = currentPoint.X - startPoint.X;
                    double offsetY = currentPoint.Y - startPoint.Y;

                    double newLeft = Canvas.GetLeft(currentDraggedImage) + offsetX;
                    double newTop = Canvas.GetTop(currentDraggedImage) + offsetY;

                    Canvas.SetLeft(currentDraggedImage, newLeft);
                    Canvas.SetTop(currentDraggedImage, newTop);

                    startPoint = currentPoint;

                    removePath(returnElement(image).pathName);
                }
            }
        }

        private void DroppedImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            if (currentDraggedImage != null)
            {
                currentDraggedImage.ReleaseMouseCapture();
                currentDraggedImage = null;
            }

             if(returnElement(image).pathName != "-"){
              
                if (returnElement(image).connection == 0)
                {
                   
                generateImagePath(returnElement(returnElement(image).pathName).image,returnElement(image).image , returnElement(image).pathName, true);
                }
                else
                {
                generateImagePath( returnElement(image).image, returnElementID(returnElement(image).connection).image, returnElement(image).pathName, true);
                }
            }
        }
       

        private void ItemOutButton_Drop(object sender, DragEventArgs e)
        {
            if (draggedImage != null)
            {
                // Create a new Image and position it on the Canvas
                Image droppedImage = new Image
                {
                    Tag = draggedImage.Tag,
                    Source = draggedImage.Source,
                    Width = draggedImage.Width,
                    Height = draggedImage.Height
                };

                Point dropPosition = e.GetPosition(canvas);

                Canvas.SetLeft(droppedImage, dropPosition.X - draggedImage.Width / 2);
                Canvas.SetTop(droppedImage, dropPosition.Y - draggedImage.Height / 2);

                canvas.Children.Add(droppedImage);

                droppedImage.MouseLeftButtonDown += DroppedImage_MouseLeftButtonDown;
                droppedImage.MouseMove += DroppedImage_MouseMove;
                droppedImage.MouseLeftButtonUp += DroppedImage_MouseLeftButtonUp;


                Element  element = new Element();
                element.exist = true;
                element.name = draggedImage.Tag.ToString();
                element.state = draggedImage.Tag.ToString();
                element.connection = 0;
                element.image = droppedImage;
                elements.Add(element);

                AssignStateNumbers(elements);
            }

        }
        #endregion

        private void outElementButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SourceButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {     
   
            Button button = (Button)sender;
            int tagNumber = int.Parse(button.Tag.ToString());
            if (!isLine && items[tagNumber].state !=  "-")
            {
                isMove = true;
                Image image = (Image)button.Content;
                draggedImageSource = image.Source;
                draggeButtonSource = button;
                DragDrop.DoDragDrop(button, draggedImageSource, DragDropEffects.Copy);
             //   clreaButton(button);
                
            }        
        }
        private void SourceToolsButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (!isLine)
            {
                Button button = (Button)sender;
                Image image = (Image)button.Content;
                draggedImageSource = image.Source;
                draggeButtonSource = button;
                DragDrop.DoDragDrop(button, draggedImageSource, DragDropEffects.Copy);
                
            }
        }
    
        private void TargetButton_Drop(object sender, DragEventArgs e)
        {
            Button button = (Button)sender;
            Image image = new Image();
            image.Source = draggedImageSource;
            button.Content = image;

            if (button== draggeButtonSource) return;

            if (isMove)
            {

               

                items[int.Parse(button.Tag.ToString())].id = int.Parse(button.Tag.ToString());
                items[int.Parse(button.Tag.ToString())].state = items[int.Parse(draggeButtonSource.Tag.ToString())].state;
                items[int.Parse(button.Tag.ToString())].exist = true;
                if  (items[int.Parse(draggeButtonSource.Tag.ToString())].connection != 0)
                {
                    removePath(draggeButtonSource.Tag.ToString());
                    generatePath(button, FindButtonByTag(items[int.Parse(draggeButtonSource.Tag.ToString())].connection.ToString()), button.Tag.ToString(), new Random().Next(2) == 0);
                    items[int.Parse(button.Tag.ToString())].connection = items[int.Parse(draggeButtonSource.Tag.ToString())].connection;
                    items[int.Parse(button.Tag.ToString())].pathName = items[int.Parse(draggeButtonSource.Tag.ToString())].pathName;
                    items[int.Parse(draggeButtonSource.Tag.ToString())].connection = 0;
                    items[int.Parse(draggeButtonSource.Tag.ToString())].pathName = "";
                    items[items[int.Parse(button.Tag.ToString())].connection].pathName = button.Tag.ToString();
                }
                else
                {
                    if (items[int.Parse(draggeButtonSource.Tag.ToString())].pathName != "-")
                    {
                     
                        removePath(items[int.Parse(draggeButtonSource.Tag.ToString())].pathName);
                        items[int.Parse(button.Tag.ToString())].pathName = items[int.Parse(draggeButtonSource.Tag.ToString())].pathName.ToString();
                        items[int.Parse(draggeButtonSource.Tag.ToString())].pathName = "-";
                        items[int.Parse(items[int.Parse(button.Tag.ToString())].pathName.ToString())].connection = int.Parse(button.Tag.ToString());
                        generatePath(FindButtonByTag(items[int.Parse(button.Tag.ToString())].pathName.ToString()), button, items[int.Parse(button.Tag.ToString())].pathName, new Random().Next(2) == 0);

                    }
                }

                isMove = false;
                clreaButton(draggeButtonSource);

            }
            else
            {
                items[int.Parse(button.Tag.ToString())].id = int.Parse(button.Tag.ToString());
                items[int.Parse(button.Tag.ToString())].state = draggeButtonSource.Tag.ToString();
                items[int.Parse(button.Tag.ToString())].exist = true;

            }
           
          

        }
        private Button FindButtonByTag(string tagValue)
        {
            foreach (UIElement element in canvas.Children)
            {
                if (element is Button button && button.Tag != null && button.Tag.ToString() == tagValue)
                {
                    return button;
                }
            }
            return null; // Button not found
        }
     
        private void clreaButton(Button button)
        {
            button.Content = null;
            items[int.Parse(button.Tag.ToString())].state = "-";
            items[int.Parse(button.Tag.ToString())].exist = false;
            items[int.Parse(button.Tag.ToString())].connection = 0;

        }
        #endregion

        #region Item
        private void AssignStateNumbers(List<Item> items)
        {
            stateCounters = new Dictionary<string, int>();
            foreach (var item in items)
            {
                item.stateNumber = 0;

            }
                foreach (var item in items)
            {
                if (item.state == "sh" || item.state == "eva" || item.state == "eco")
                {
                    if (!stateCounters.ContainsKey(item.state))
                    {
                        stateCounters[item.state] = 1;
                    }
                    else
                    {
                        stateCounters[item.state]++;
                        if (stateCounters[item.state] > 3)
                        {
                            // You can handle the case when you exceed 3 items with the same state here
                        }
                    }

                    item.stateNumber = stateCounters[item.state];
                }
            }
        }
        private void AssignStateNumbers(List<Element> elements)
        {
            stateCounters = new Dictionary<string, int>();
            foreach (var element in elements)
            {
                element.stateNumber = 0;

            }
            foreach (var element in elements)
            {
                if (element.state == "sh" || element.state == "eva" || element.state == "eco")
                {
                    if (!stateCounters.ContainsKey(element.state))
                    {
                        stateCounters[element.state] = 1;
                    }
                    else
                    {
                        stateCounters[element.state]++;
                        if (stateCounters[element.state] > 3)
                        {
                            // You can handle the case when you exceed 3 items with the same state here
                         
                        }
                    }

                    element.stateNumber = stateCounters[element.state];
                    element.name = element.state + stateCounters[element.state];
                }
            }
        }
        #endregion 

        #region Attribute
        private void SourceButton_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Button button = (Button)sender;
            if (checkButtonExist(button))
            {

            }

        }
        #endregion

        #region Tools
        private bool checkButtonExist(Button button)
        {
            
            if (items[int.Parse(button.Tag.ToString())].exist) return true;
            else return false;
        }

        private Element returnElement(Image image)
        {
            Element foundElement = elements.FirstOrDefault(element => element.image == image); if (foundElement != null) 
            return foundElement; 
            return null;

        }
        private Element returnElement(int connection)
        {
            Element foundElement = elements.FirstOrDefault(element => element.connection == connection); if (foundElement != null)
                return foundElement;
            return null;

        }
        private Element returnElementID(int id)
        {
            Element foundElement = elements.FirstOrDefault(element => element.id == id); if (foundElement != null)
                return foundElement;
            return null;

        }
        private Element returnName(string name)
            {
                Element foundElement = elements.FirstOrDefault(element => element.name == name); if (foundElement != null)
                    return foundElement;
                return null;

            }
        private Element returnElement(string pathName)
        {
            Element foundElement = elements.FirstOrDefault(element => element.pathName == pathName); if (foundElement != null)
                return foundElement;
            return null;

        }

        private bool checkState(string state)
        {
            if ( elements.Count(element => element.state == state) > 2) return true;return false;
        }
        private bool elementer(Image image)
        {
            switch (image.Tag)
            {
                case "fr":
                    return true;
                case "du":
                    return true;
                default:
                    return false;
            }

        }
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

      

        private void Items_Click(object sender, RoutedEventArgs e)
        {
            AssignStateNumbers(items);
            FormItems formItems = new FormItems(items);
            formItems.Show();

        }


        private void Elements_Click(object sender, RoutedEventArgs e)
        {
         //   AssignStateNumbers(items);
            FormElements formElements = new FormElements(elements);
            formElements.Show();
        }

        private void Attributes_Click(object sender, RoutedEventArgs e)
        {
            AssignStateNumbers(items);
            FormAttributes formAttributes = new FormAttributes();
            formAttributes.Show();
        }




        #endregion


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
    }

}
