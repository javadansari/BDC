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

        public MainWindow()
        {
            InitializeComponent();
            startInitialize();

        }
        // Start
        private void startInitialize()
        {
            items = new List<Item>();
            for (int i = 0; i < 11; i++)
            {
                Item item = new Item { id = i };
                items.Add(item);
            }

        }

        // Path
        private void levelButton_Click(object sender, RoutedEventArgs e)
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
                    removePath(pathName);
                    double centerY = 50 + Canvas.GetTop(firstLineButton) + firstLineButton.ActualHeight / 2;
                    Point clickPoint = Mouse.GetPosition(clickedButton);
                 
                    DrawArrowBetweenButtons(firstLineButton, secondLineButton, pathName, clickPoint.Y > centerY);


                    items[int.Parse(firstLineButton.Tag.ToString())].connection = int.Parse(secondLineButton.Tag.ToString());
                    items[int.Parse(firstLineButton.Tag.ToString())].pathName = pathName;

                }
                toolbarMenu.Visibility = Visibility.Visible;
                isFirstLine = true;
                reportText.Text = "";
            }

            //   clickedButton = (Button)sender;

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
        private void DrawArrowBetweenButtons(Button firstButton, Button secondButton, string pathName, bool invertY = false)
        {
            Point startPoint = new Point(Canvas.GetLeft(firstButton) + firstButton.ActualWidth / 2, Canvas.GetTop(firstButton) + firstButton.ActualHeight / 2);
            Point endPoint = new Point(Canvas.GetLeft(secondButton) + secondButton.ActualWidth / 2, Canvas.GetTop(secondButton) + secondButton.ActualHeight / 2);

            double dx = endPoint.X - startPoint.X;
            double dy = endPoint.Y - startPoint.Y;

            Random random = new Random();
            int randomHeight = random.Next(20, 70); // Generates a random number between 20 and 70

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

            //    removePath("MyUniqueTag");
        }


        // Image
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



        // Drag
        private void SourceButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Button button = (Button)sender;
            Image image = (Image)button.Content;
            draggedImageSource = image.Source;
            draggeButtonSource = button;
            DragDrop.DoDragDrop(button, draggedImageSource, DragDropEffects.Copy);
        }
        private void TargetButton_Drop(object sender, DragEventArgs e)
        {
            Button button = (Button)sender;
            Image image = new Image();
            image.Source = draggedImageSource;
            button.Content = image;
            items[int.Parse(button.Tag.ToString())].id = int.Parse(button.Tag.ToString());
            items[int.Parse(button.Tag.ToString())].state = draggeButtonSource.Tag.ToString();
            items[int.Parse(button.Tag.ToString())].exist = true;


        }
     
       
      
    }


}
