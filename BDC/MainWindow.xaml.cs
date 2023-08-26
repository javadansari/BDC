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
        private Button clickedButton;
        private Image imageLevelButton;
        private ImageSource draggedImageSource;
        private Button draggeButtonSource;
        private bool isFirstLine = true;
        private Button firstLineButton;
        private Button secondLineButton;
        private bool isLine = false;
        private bool isMove = false;
        private Dictionary<string, int> stateCounters;

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
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            AssignStateNumbers(items);
            listView.ItemsSource = null;
            listView.ItemsSource = items;
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

      
        

        private void Attributes_Click(object sender, RoutedEventArgs e)
        {
            AssignStateNumbers(items);
            FormAttributes formAttributes = new FormAttributes();
            formAttributes.Show();
        }
        #endregion
    }

}
