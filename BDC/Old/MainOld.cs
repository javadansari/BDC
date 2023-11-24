using BDC.Classes;
using BDC.DataBase;
using BDC.Forms;
using BDC.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace BDC.Old
{
    internal class MainOldClass
    {

      
      //public partial class MainWindow : Window
      //  {
      //      private List<Item> items;
      //      public List<Element> elements { get; set; }

      //      public List<Case> cases { get; set; }

      //      private List<ItemAttribute> itemAttribute;
      //      private Button clickedButton;
      //      private Image imageLevelButton;
      //      private ImageSource draggedImageSource;
      //      private bool isFirstLine = true;
      //      private bool isSelect = true;
      //      private Image firstLineImage;
      //      private Image secondLineImage;
      //      private bool isLine = false;
      //      private bool isMove = false;
      //      private Dictionary<string, int> stateCounters;
      //      private Image draggedImage;
      //      private Image currentDraggedImage;
      //      private Point startPoint;
      //      private int iconSize = 48;
      //      private double currentScale = 1.0;
      //      private string loadCalse = "base";


      //      public MainWindow()
      //      {
      //          InitializeComponent();
      //          startInitialize();

      //      }

      //      #region Start
      //      private void startInitialize()
      //      {



      //          draggedImage = new Image();
      //          items = new List<Item>();

      //          for (int i = 0; i < 11; i++)
      //          {
      //              Item item = new Item { id = i };
      //              items.Add(item);
      //          }
      //          elements = new List<Element>();
      //          cases = new List<Case>();

      //          canvas.LayoutTransform = new ScaleTransform(0.8, 0.8);


      //      }
      //      #endregion



      //      #region Path
      //      private void line_Click(object sender, MouseButtonEventArgs e)
      //      {
      //          toolbarMenu.Visibility = Visibility.Hidden;
      //          reportText.Text = "Choose the first level";
      //          isLine = true;
      //      }


      //      private void DroppedImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
      //      {
      //          if (isSelect)
      //          {
      //              showProperties(returnElement((Image)sender));
      //              return;
      //          }
      //          if (isLine)
      //          {

      //              if (isFirstLine)
      //              {
      //                  firstLineImage = (Image)sender;
      //                  reportText.Text = "Choose the second level";
      //                  isFirstLine = false;
      //              }
      //              else
      //              {
      //                  secondLineImage = (Image)sender;
      //                  if (firstLineImage != secondLineImage)
      //                  {

      //                      //     int i = items[int.Parse(firstLineButton.Tag.ToString())].connection;
      //                      //     int b = int.Parse(secondLineButton.Tag.ToString());
      //                      Element firstImage = returnElement(firstLineImage);
      //                      Element secondImage = returnElement(secondLineImage);
      //                      string pathName = firstImage.caseAttribute.Id.ToString();
      //                      if (secondImage.caseAttribute.Connection == firstImage.caseAttribute.Id)
      //                          pathName = secondImage.caseAttribute.Id.ToString();
      //                      removePath(pathName);
      //                      //       double centerY = 230 + firstLineButton.ActualHeight / 2;
      //                      //       Point clickPoint = Mouse.caseAttribute.GetPosition(clickedButton);

      //                      generateImagePath(firstLineImage, secondLineImage, pathName, true);


      //                      firstImage.caseAttribute.Connection = secondImage.caseAttribute.Id;
      //                      firstImage.caseAttribute.PathName = pathName;
      //                      secondImage.caseAttribute.PathName = firstImage.caseAttribute.Id.ToString();

      //                  }
      //                  escapePath();
      //              }


      //          }
      //          else
      //          {
      //              currentDraggedImage = (Image)sender;
      //              startPoint = e.caseAttribute.GetPosition(canvas);
      //              currentDraggedImage.caseAttribute.CaptureMouse();
      //          }


      //      }


      //      private void generateImagePath(Image firstImage, Image secondImage, string pathName, bool invertY = false)
      //      {
      //          //   Point startPoint = new Point(Canvas.GetLeft(firstImage) + firstImage.caseAttribute.ActualWidth / 2, Canvas.GetTop(firstImage) + firstImage.caseAttribute.ActualHeight / 2);
      //          Point startPoint = new Point(Canvas.GetLeft(firstImage) + firstImage.caseAttribute.ActualWidth, Canvas.GetTop(firstImage) + firstImage.caseAttribute.ActualHeight / 2);
      //          //    Point endPoint = new Point(Canvas.GetLeft(secondImage) + secondImage.caseAttribute.ActualWidth / 2, Canvas.GetTop(secondImage) + secondImage.caseAttribute.ActualHeight / 2);
      //          Point endPoint = new Point(Canvas.GetLeft(secondImage) + secondImage.caseAttribute.ActualWidth, Canvas.GetTop(secondImage) + secondImage.caseAttribute.ActualHeight / 2);

      //          WriteLine(startPoint.X + " - " + endPoint.X + " / " + Canvas.GetLeft(firstImage) + " - " + Canvas.GetLeft(secondImage));

      //          double dx = endPoint.X - startPoint.X;
      //          double dy = endPoint.Y - startPoint.Y;

      //          //   Random random = new Random();
      //          //   int randomHeight = random.Next(20, 50) ; // Generates a random number between 20 and 50
      //          //  int randomHeight = (int)(endPoint.Y);
      //          int randomHeight = (int)((dy)) + 40;
      //          if (dy < 0) randomHeight = 40;
      //          Point midPoint = new Point(startPoint.X + dx / 2, startPoint.Y + dy / 2);

      //          if (invertY)
      //          {
      //              startPoint.Y = startPoint.Y + firstImage.caseAttribute.ActualHeight / 2;
      //              endPoint.Y = endPoint.Y + secondImage.caseAttribute.ActualHeight / 2;
      //              midPoint.Y = midPoint.Y + firstImage.caseAttribute.ActualHeight / 2;
      //              randomHeight = -randomHeight;
      //          }
      //          else
      //          {
      //              startPoint.Y = startPoint.Y - firstImage.caseAttribute.ActualHeight / 2;
      //              endPoint.Y = endPoint.Y - secondImage.caseAttribute.ActualHeight / 2;
      //              midPoint.Y = midPoint.Y - firstImage.caseAttribute.ActualHeight / 2;
      //          }

      //          PathGeometry pathGeometry = new PathGeometry();
      //          PathFigure pathFigure = new PathFigure();
      //          pathFigure.caseAttribute.StartPoint = startPoint;

      //          LineSegment lineSegment1 = new LineSegment(new Point(startPoint.X, startPoint.Y - randomHeight), true);
      //          BezierSegment bezierSegment = new BezierSegment(new Point(midPoint.X, startPoint.Y - randomHeight),
      //                                                          new Point(midPoint.X, startPoint.Y - randomHeight),
      //                                                          new Point(endPoint.X, startPoint.Y - randomHeight), true);
      //          LineSegment lineSegment2 = new LineSegment(endPoint, true);

      //          pathFigure.caseAttribute.Segments.Add(lineSegment1);
      //          pathFigure.caseAttribute.Segments.Add(bezierSegment);

      //          pathFigure.caseAttribute.Segments.Add(lineSegment2);

      //          pathGeometry.Figures.Add(pathFigure);

      //          System.Windows.Shapes.Path path = new System.Windows.Shapes.Path
      //          {
      //              Data = pathGeometry,
      //              Stroke = Brushes.Red,
      //              StrokeThickness = 2,
      //              Tag = pathName // Set the Tag property to the provided path name
      //          };

      //          canvas.Children.Add(path);

      //          // Calculate the angle of the line
      //          double angle = Math.Atan2(dy, dx) / Math.PI;

      //          // Calculate the horizontal position of the arrowhead
      //          double arrowWidth = 10; // Width of the arrowhead
      //          double arrowX = midPoint.X - arrowWidth / 2; // Position centered on the midpoint

      //          int renderTransform = (int)midPoint.Y;
      //          if (invertY) renderTransform = -(int)midPoint.Y;

      //          // Add an arrowhead (triangle) at the midpoint
      //          double arrowEnd = arrowWidth;
      //          if (startPoint.X - endPoint.X < 0) arrowEnd = -arrowWidth;
      //          Polygon arrowhead = new Polygon
      //          {
      //              Points = new PointCollection
      //              {
      //             new Point(arrowX, startPoint.Y - randomHeight ), // Tip of the arrowhead
      //         new Point(arrowX + arrowEnd, startPoint.Y - 5 - randomHeight), // Bottom-right corner of the arrowhead
      //          new Point(arrowX + arrowEnd, startPoint.Y + 5 - randomHeight) // Top-right corner of the arrowhead
      //           },
      //              Fill = Brushes.Red,
      //              //   RenderTransform = new RotateTransform(180 + angle * 180, midPoint.X, renderTransform), // Rotate the arrowhead by 180 degrees
      //              Tag = pathName
      //          };

      //          canvas.Children.Add(arrowhead);
      //      }

      //      private void escapePath()
      //      {
      //          if (isLine)
      //          {
      //              toolbarMenu.Visibility = Visibility.Visible;
      //              isFirstLine = true;
      //              reportText.Text = "";
      //              isLine = false;
      //          }
      //      }
      //      private void removePath(string pathName)
      //      {
      //          string tagToRemove = pathName;

      //          System.Windows.Shapes.Path pathToRemove = null;

      //          foreach (UIElement element in canvas.Children)
      //          {
      //              if (element is System.Windows.Shapes.Path path && path.Tag is string tag && tag == tagToRemove)
      //              {
      //                  pathToRemove = path;
      //                  break; // Assuming you want to remove only the first path with the given tag
      //              }

      //          }
      //          if (pathToRemove != null)
      //          {
      //              canvas.Children.Remove(pathToRemove);
      //          }

      //          foreach (UIElement element in canvas.Children)
      //          {
      //              if (element is Polygon polygon && polygon.Tag != null && polygon.Tag.ToString() == pathName)
      //              {
      //                  // Remove the Polygon from the canvas
      //                  canvas.Children.Remove(polygon);
      //                  break; // Exit the loop once you've found and removed the Polygon
      //              }
      //          }
      //      }

      //      #endregion


      //      #region Drag

      //      #region DragImage

      //      private void SourceoutElementButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
      //      {


      //          if (!isLine)
      //          {

      //              Image image = sender as Image;


      //              // check if exist
      //              if (elementer(image))
      //              {
      //                  Element foundElement = returnName(image.caseAttribute.Tag.ToString());
      //                  if (foundElement != null)
      //                  {
      //                      image.caseAttribute.Cursor = Cursors.No;
      //                      return;

      //                  }
      //              }

      //              // check state
      //              if (checkState(image.caseAttribute.Tag.ToString()))
      //              {
      //                  image.caseAttribute.Cursor = Cursors.No;
      //                  return;

      //              }

      //              // Prepare image for dragging
      //              draggedImage = new Image
      //              {
      //                  Tag = image.caseAttribute.Tag,
      //                  Source = image.caseAttribute.Source,
      //                  Width = image.caseAttribute.Width,
      //                  Height = image.caseAttribute.Height
      //              };

      //              if (draggedImage != null)
      //              {
      //                  DragDrop.DoDragDrop(image, draggedImage, DragDropEffects.Copy);
      //              }

      //          }
      //      }



      //      private void DroppedImage_MouseMove(object sender, MouseEventArgs e)
      //      {

      //          Image image = sender as Image;
      //          if (!isLine)
      //          {
      //              if (currentDraggedImage != null && e.caseAttribute.LeftButton == MouseButtonState.caseAttribute.Pressed)
      //              {

      //                  //    MessageBox.Show("jj");

      //                  Point currentPoint = e.caseAttribute.GetPosition(canvas);
      //                  double offsetX = currentPoint.X - startPoint.X;
      //                  double offsetY = currentPoint.Y - startPoint.Y;

      //                  double newLeft = Canvas.GetLeft(currentDraggedImage) + offsetX;
      //                  double newTop = Canvas.GetTop(currentDraggedImage) + offsetY;

      //                  if (!elementer(draggedImage))
      //                  {
      //                      var result = checkInBox(newLeft, newTop);
      //                      if (!result.IsInside) return;
      //                  }

      //                  Canvas.SetLeft(currentDraggedImage, newLeft);
      //                  Canvas.SetTop(currentDraggedImage, newTop);
      //                  startPoint = currentPoint;

      //                  removePath(returnElement(image).PathName);
      //              }
      //          }

      //      }

      //      private void DroppedImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
      //      {
      //          Image image = sender as Image;
      //          if (currentDraggedImage != null)
      //          {


      //              // Check Postion
      //              double x = e.caseAttribute.GetPosition(canvas).X;
      //              double y = e.caseAttribute.GetPosition(canvas).Y;

      //              if (!elementer(draggedImage))
      //              {
      //                  var result = checkInBox(x, y);
      //                  x = result.X; y = result.Y;
      //                  returnElement(image).Position = result.position;
      //                  returnElement(image).X = x;
      //                  returnElement(image).Y = y;
      //                  if (!result.IsInside) return;
      //              }
      //              Canvas.SetLeft(currentDraggedImage, x - currentDraggedImage.caseAttribute.Width / 2);
      //              Canvas.SetTop(currentDraggedImage, y - currentDraggedImage.caseAttribute.Height / 2);

      //              currentDraggedImage.caseAttribute.ReleaseMouseCapture();
      //              currentDraggedImage = null;


      //              if (returnElement(image).PathName != "-")
      //              {

      //                  if (returnElement(image).Connection == 0)
      //                  {
      //                      string path = returnElement(image).PathName;

      //                      generateImagePath(returnElementPath(returnElement(image).PathName).Image, returnElement(image).Image, returnElement(image).PathName, true);
      //                  }
      //                  else
      //                  {
      //                      generateImagePath(returnElement(image).Image, returnElementID(returnElement(image).Connection).Image, returnElement(image).PathName, true);
      //                  }
      //              }
      //          }
      //      }


      //      private void ItemOutButton_Drop(object sender, DragEventArgs e)
      //      {



      //          if (draggedImage != null)
      //          {
      //              // Check Postion
      //              double x = e.caseAttribute.GetPosition(canvas).X;
      //              double y = e.caseAttribute.GetPosition(canvas).Y;
      //              int position = 0;
      //              if (!elementer(draggedImage))
      //              {
      //                  var result = checkInBox(x, y);
      //                  x = result.X; y = result.Y; position = result.position;
      //                  if (!result.IsInside) return;
      //              }

      //              // Create a new Image and position it on the Canvas
      //              Image droppedImage = new Image
      //              {
      //                  Tag = draggedImage.caseAttribute.Tag,
      //                  Source = draggedImage.caseAttribute.Source,
      //                  Width = draggedImage.caseAttribute.Width,
      //                  Height = draggedImage.caseAttribute.Height
      //              };

      //              CreateElement(droppedImage, x, y);

      //              Element element = new Element();
      //              element.Exist = true;
      //              element.Name = draggedImage.caseAttribute.Tag.ToString();
      //              element.State = draggedImage.caseAttribute.Tag.ToString();
      //              element.Connection = 0;
      //              element.Image = droppedImage;
      //              element.Position = position;
      //              element.X = x;
      //              element.Y = y;
      //              elements.Add(element);
      //              AssignStateNumbers(elements);



      //          }




      //      }




      //      private (bool IsInside, double X, double Y, int position) checkInBox(double leftCanvas, double topCanvas)
      //      {


      //          int x = -20;
      //          int y = 135;
      //          int width = 57;
      //          int height = 103;

      //          for (int i = 1; i < 12; i++)
      //          {
      //              x = x + 58;
      //              if (leftCanvas > x && leftCanvas < x + width && topCanvas > y & topCanvas < y + height) return (true, (2 * x + width) / 2, (2 * y + height) / 2, i);
      //          }
      //          return (false, 0, 0, 0);

      //      }





      //      #endregion


      //      #region ImageChooser

      //      private void CheckBox_Click(object sender, RoutedEventArgs e)
      //      {
      //          CheckBox checkBox = (CheckBox)sender;
      //          Image image = boilerStage_1;
      //          Label label = boilerStage_1_label;
      //          switch (checkBox.Name)
      //          {
      //              case "boilerStage_check_1":
      //                  image = boilerStage_1;
      //                  label = boilerStage_1_label;
      //                  break;
      //              case "boilerStage_check_2":
      //                  image = boilerStage_2;
      //                  label = boilerStage_2_label;
      //                  break;
      //              case "boilerStage_check_3":
      //                  image = boilerStage_3;
      //                  label = boilerStage_3_label;
      //                  break;
      //              case "boilerStage_check_4":
      //                  image = boilerStage_4;
      //                  label = boilerStage_4_label;
      //                  break;
      //              case "boilerStage_check_5":
      //                  image = boilerStage_5;
      //                  label = boilerStage_5_label;
      //                  break;
      //              case "boilerStage_check_6":
      //                  image = boilerStage_6;
      //                  label = boilerStage_6_label;
      //                  break;
      //              case "boilerStage_check_7":
      //                  image = boilerStage_7;
      //                  label = boilerStage_7_label;
      //                  break;
      //              default:
      //                  break;
      //          }
      //          ImageChooser imageChooser = new ImageChooser();
      //          if (checkBox.IsChecked == true)
      //          {
      //              if (imageChooser.ShowDialog() == true)
      //              {
      //                  if (imageChooser.EconomizerRadioButton.IsChecked == true)
      //                  {
      //                      image.caseAttribute.Source = new BitmapImage(new Uri("/Images/Elements/economizer.png", UriKind.Relative));
      //                      image.caseAttribute.Tag = "eco";

      //                  }
      //                  else if (imageChooser.SuperheatRadioButton.IsChecked == true)
      //                  {
      //                      image.caseAttribute.Source = new BitmapImage(new Uri("/Images/Elements/superheater.png", UriKind.Relative));
      //                      image.caseAttribute.Tag = "sh";
      //                  }
      //                  else if (imageChooser.EvaporatorRadioButton.IsChecked == true)
      //                  {
      //                      image.caseAttribute.Source = new BitmapImage(new Uri("/Images/Elements/evaporator.png", UriKind.Relative));
      //                      image.caseAttribute.Tag = "eva";
      //                  }
      //              }

      //              label.Content = setElement(image).Name;
      //          }
      //          else
      //          {
      //              elements.Remove(elements.FirstOrDefault(element => element.Image == image));
      //              AssignStateNumbers(elements);
      //              image.caseAttribute.Source = null;
      //              image.caseAttribute.Tag = "";
      //              label.Content = "";
      //          }
      //      }

      //      private void CheckBoxDuct_Click(object sender, RoutedEventArgs e)
      //      {
      //          CheckBox checkBox = (CheckBox)sender;
      //          Image image = boilerStage_11;
      //          Label label = boilerStage_11_label;

      //          if (checkBox.IsChecked == true)
      //          {
      //              image.caseAttribute.Source = new BitmapImage(new Uri("/Images/Elements/duct.png", UriKind.Relative));
      //              image.caseAttribute.Tag = "du";

      //              label.Content = setElement(image).Name;
      //          }
      //          else
      //          {
      //              elements.Remove(elements.FirstOrDefault(element => element.Image == image));
      //              AssignStateNumbers(elements);
      //              image.caseAttribute.Source = null;
      //              image.caseAttribute.Tag = "";
      //              label.Content = "";
      //          }
      //      }

      //      private void CheckBoxBurner_Click(object sender, RoutedEventArgs e)
      //      {
      //          CheckBox checkBox = (CheckBox)sender;
      //          Image image = boilerStage_8;
      //          Label label = boilerStage_8_label;
      //          switch (checkBox.Name)
      //          {
      //              case "boilerStage_check_8":
      //                  image = boilerStage_8;
      //                  label = boilerStage_8_label;
      //                  break;
      //              case "boilerStage_check_9":
      //                  image = boilerStage_9;
      //                  label = boilerStage_9_label;
      //                  break;
      //              case "boilerStage_check_10":
      //                  image = boilerStage_10;
      //                  label = boilerStage_10_label;
      //                  break;
      //              default:
      //                  break;
      //          }

      //          if (checkBox.IsChecked == true)
      //          {
      //              image.caseAttribute.Source = new BitmapImage(new Uri("/Images/Elements/burner.png", UriKind.Relative));
      //              image.caseAttribute.Tag = "bu";
      //              label.Content = setElement(image).Name;
      //          }
      //          else
      //          {
      //              elements.Remove(elements.FirstOrDefault(element => element.Image == image));
      //              AssignStateNumbers(elements);
      //              image.caseAttribute.Source = null;
      //              image.caseAttribute.Tag = "";
      //              label.Content = "";

      //          }
      //      }
      //      private Element setElement(Image image)
      //      {
      //          Element element = new Element();
      //          element.Exist = true;
      //          element.Name = image.caseAttribute.Tag.ToString();
      //          element.Content = image.caseAttribute.Tag.ToString();
      //          element.State = image.caseAttribute.Tag.ToString();
      //          element.Connection = 0;
      //          element.Image = image;

      //          elements.Add(element);
      //          AssignStateNumbers(elements);
      //          return element;
      //      }





      //      #endregion


      //      #endregion

      //      #region Element
      //      private Image CreateElement(Image droppedImage, double x, double y)
      //      {


      //          //  Point dropPosition = e.caseAttribute.GetPosition(canvas);

      //          Canvas.SetLeft(droppedImage, x - iconSize / 2);
      //          Canvas.SetTop(droppedImage, y - iconSize / 2);

      //          //   Canvas.SetLeft(droppedImage, dropPosition.X - draggedImage.caseAttribute.Width / 2);
      //          //   Canvas.SetTop(droppedImage, dropPosition.Y - draggedImage.caseAttribute.Height / 2);

      //          canvas.Children.Add(droppedImage);

      //          droppedImage.caseAttribute.MouseLeftButtonDown += DroppedImage_MouseLeftButtonDown;
      //          droppedImage.caseAttribute.MouseMove += DroppedImage_MouseMove;
      //          droppedImage.caseAttribute.MouseLeftButtonUp += DroppedImage_MouseLeftButtonUp;
      //          return droppedImage;
      //      }
      //      private void AssignStateNumbers(List<Element> elements)
      //      {
      //          stateCounters = new Dictionary<string, int>();
      //          foreach (var element in elements)
      //          {
      //              element.StateNumber = 0;
      //              AssignItemAttribute(element);
      //          }
      //          foreach (var element in elements)
      //          {
      //              if (element.State == "sh" || element.State == "eva" || element.State == "eco")
      //              {
      //                  if (!stateCounters.ContainsKey(element.State))
      //                  {
      //                      stateCounters[element.State] = 1;
      //                  }
      //                  else
      //                  {
      //                      stateCounters[element.State]++;
      //                      if (stateCounters[element.State] > 3)
      //                      {
      //                          // You can handle the case when you exceed 3 items with the same state here

      //                      }
      //                  }

      //                  element.StateNumber = stateCounters[element.State];
      //                  element.Name = element.State + stateCounters[element.State];

      //                  //    Label label = FindName(element.Image.caseAttribute.Name + "_label") as Label;
      //                  //   label.Content = element.Name;
      //              }
      //          }

      //      }
      //      #endregion



      //      #region Attribute
      //      private void AssignItemAttribute(Element element)
      //      {

      //          ItemAttribute attribute = new ItemAttribute();
      //          attribute.caseAttribute.loadCase = loadCalse;
      //          attribute.caseAttribute.stage = element.State;
      //          element.attribute = attribute;

      //      }
      //      #endregion

      //      #region Tools
      //      #region Other
      //      private void WriteLine(string text)
      //      {
      //          reportText.Text = text;
      //      }
      //      private bool checkButtonExist(Button button)
      //      {

      //          if (items[int.Parse(button.Tag.ToString())].exist) return true;
      //          else return false;
      //      }

      //      private Element returnElement(Image image)
      //      {
      //          Element foundElement = elements.FirstOrDefault(element => element.Image == image); if (foundElement != null)
      //              return foundElement;
      //          return null;

      //      }
      //      private Element returnElement(int connection)
      //      {
      //          Element foundElement = elements.FirstOrDefault(element => element.Connection == connection); if (foundElement != null)
      //              return foundElement;
      //          return null;

      //      }
      //      private Element returnElementID(int id)
      //      {
      //          Element foundElement = elements.FirstOrDefault(element => element.Id == id); if (foundElement != null)
      //              return foundElement;
      //          return null;

      //      }
      //      private Element returnName(string name)
      //      {
      //          Element foundElement = elements.FirstOrDefault(element => element.Name == name); if (foundElement != null)
      //              return foundElement;
      //          return null;

      //      }
      //      private Element returnElementPath(string pathName)
      //      {
      //          Element foundElement = elements.FirstOrDefault(element => element.PathName == pathName && element.Connection != 0); if (foundElement != null)
      //              return foundElement;
      //          return null;

      //      }

      //      private bool checkState(string state)
      //      {
      //          if (elements.Count(element => element.State == state) > 2) return true; return false;
      //      }
      //      private bool elementer(Image image)
      //      {
      //          switch (image.caseAttribute.Tag)
      //          {
      //              case "fr":
      //                  return true;
      //              case "du":
      //                  return true;
      //              case "pu":
      //                  return true;
      //              case "fan":
      //                  return true;
      //              default:
      //                  return false;
      //          }

      //      }
      //      #endregion
      //      #region Save
      //      private void SaveButton_Click(object sender, MouseButtonEventArgs e)
      //      {
      //          DatabaseContext dbContext = new DatabaseContext();
      //          dbContext.DeleteDatabase();
      //          dbContext.CreateTableIfNotExists();

      //          foreach (Element element in elements)
      //          {
      //              dbContext.SaveData(element);
      //          }




      //          foreach (RadioButton item in casesToolBar.Items)
      //          {
      //              cases.Add(new Case { Name = item.Content.ToString() });

      //          }

      //          foreach (Case @case in cases)
      //          {
      //              dbContext.SaveCases(@case);
      //          }

      //      }
      //      #endregion
      //      #region Load
      //      private void OpenButton_Click(object sender, MouseButtonEventArgs e)
      //      {

      //          DatabaseContext dbContext = new DatabaseContext();
      //          elements = dbContext.ReadData();
      //          LoadElements(elements);

      //          cases = dbContext.ReadCase();
      //          LoadCases(cases);



      //      }

      //      private void LoadElements(List<Element> elements)
      //      {
      //          foreach (Element element in elements)
      //          {
      //              Image image = element.Image;
      //              CreateElement(image, element.X, element.Y);
      //          }
      //      }

      //      private void LoadCases(List<Case> cases)
      //      {
      //          foreach (Case @case in cases)
      //          {

      //          }
      //      }

      //      #endregion

      //      #region Select
      //      public class PropertyDisplay
      //      {
      //          public string PropertyName { get; set; }
      //          public string PropertyValue { get; set; }
      //      }
      //      private void SelectButton_Click(object sender, MouseButtonEventArgs e)
      //      {

      //          isSelect = true;
      //          moveImage.caseAttribute.Opacity = 0.2;
      //          selectImage.caseAttribute.Opacity = 1.0;

      //      }
      //      public void showProperties(Element element)
      //      {

      //          List<PropertyDisplay> propertyList = new List<PropertyDisplay>
      //          {
      //                new PropertyDisplay { PropertyName = "content", PropertyValue = element.Content.ToString() },
      //                new PropertyDisplay { PropertyName = "stage", PropertyValue = element.attribute.caseAttribute.stage.caseAttribute.ToString() },
      //                new PropertyDisplay { PropertyName = "loadCase", PropertyValue = element.attribute.caseAttribute.loadCase.caseAttribute.ToString() },
      //                new PropertyDisplay { PropertyName = "TubeArrangement", PropertyValue = element.attribute.caseAttribute.TubeArrangement.ToString() },
      //                new PropertyDisplay { PropertyName = "Water_Gas_Flow_Pattern", PropertyValue = element.attribute.caseAttribute.Water_Gas_Flow_Pattern.ToString() },
      //                new PropertyDisplay { PropertyName = "No_Rows", PropertyValue = element.attribute.caseAttribute.No_Rows },
      //                new PropertyDisplay { PropertyName = "SLN", PropertyValue = element.attribute.caseAttribute.SLN },
      //                new PropertyDisplay { PropertyName = "STN", PropertyValue = element.attribute.caseAttribute.STN.ToString() },
      //          };

      //          propertyListBox.ItemsSource = propertyList;
      //      }


      //      private void GridElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
      //      {
      //          Grid grid = (Grid)sender;
      //          Image image = FindName(grid.Name.caseAttribute.Replace("_grid", "")) as Image;
      //          if (isSelect)
      //          {
      //              showProperties(returnElement(image));
      //              return;
      //          }
      //          if (isLine)
      //          {
      //              if (isFirstLine)
      //              {
      //                  firstLineImage = image;
      //                  reportText.Text = "Choose the second level";
      //                  isFirstLine = false;
      //              }
      //              else
      //              {
      //                  secondLineImage = image;
      //                  if (firstLineImage != secondLineImage)
      //                  {
      //                      Element firstImage = returnElement(firstLineImage);
      //                      Element secondImage = returnElement(secondLineImage);
      //                      Grid grid1 = FindName(firstLineImage.caseAttribute.Name + "_grid") as Grid;
      //                      Grid grid2 = FindName(secondLineImage.caseAttribute.Name + "_grid") as Grid;
      //                      string pathName = firstImage.caseAttribute.Id.ToString();
      //                      if (secondImage.caseAttribute.Connection == firstImage.caseAttribute.Id)
      //                          pathName = secondImage.caseAttribute.Id.ToString();
      //                      removePath(pathName);
      //                      generatePath(grid1, grid2, pathName, true);
      //                      firstImage.caseAttribute.Connection = secondImage.caseAttribute.Id;
      //                      firstImage.caseAttribute.PathName = pathName;
      //                      secondImage.caseAttribute.PathName = firstImage.caseAttribute.Id.ToString();

      //                  }
      //                  escapePath();
      //              }
      //          }
      //          else
      //          {
      //              currentDraggedImage = (Image)sender;
      //              startPoint = e.caseAttribute.GetPosition(canvas);
      //              currentDraggedImage.caseAttribute.CaptureMouse();
      //          }



      //      }
      //      private void generatePath(Grid firstImage, Grid secondImage, string pathName, bool invertY = false)
      //      {
      //          //   Point startPoint = new Point(Canvas.GetLeft(firstImage) + firstImage.caseAttribute.ActualWidth / 2, Canvas.GetTop(firstImage) + firstImage.caseAttribute.ActualHeight / 2);
      //          Point startPoint = new Point(Canvas.GetLeft(firstImage) + firstImage.caseAttribute.ActualWidth, Canvas.GetTop(firstImage) + firstImage.caseAttribute.ActualHeight / 2);
      //          //    Point endPoint = new Point(Canvas.GetLeft(secondImage) + secondImage.caseAttribute.ActualWidth / 2, Canvas.GetTop(secondImage) + secondImage.caseAttribute.ActualHeight / 2);
      //          Point endPoint = new Point(Canvas.GetLeft(secondImage) + secondImage.caseAttribute.ActualWidth, Canvas.GetTop(secondImage) + secondImage.caseAttribute.ActualHeight / 2);

      //          WriteLine(startPoint.X + " - " + endPoint.X + " / " + Canvas.GetLeft(firstImage) + " - " + Canvas.GetLeft(secondImage));

      //          double dx = endPoint.X - startPoint.X;
      //          double dy = endPoint.Y - startPoint.Y;

      //          //   Random random = new Random();
      //          //   int randomHeight = random.Next(20, 50) ; // Generates a random number between 20 and 50
      //          //  int randomHeight = (int)(endPoint.Y);
      //          int randomHeight = (int)((dy)) + 40;
      //          if (dy < 0) randomHeight = 40;
      //          Point midPoint = new Point(startPoint.X + dx / 2, startPoint.Y + dy / 2);

      //          if (invertY)
      //          {
      //              startPoint.Y = startPoint.Y + firstImage.caseAttribute.ActualHeight / 2;
      //              endPoint.Y = endPoint.Y + secondImage.caseAttribute.ActualHeight / 2;
      //              midPoint.Y = midPoint.Y + firstImage.caseAttribute.ActualHeight / 2;
      //              randomHeight = -randomHeight;
      //          }
      //          else
      //          {
      //              startPoint.Y = startPoint.Y - firstImage.caseAttribute.ActualHeight / 2;
      //              endPoint.Y = endPoint.Y - secondImage.caseAttribute.ActualHeight / 2;
      //              midPoint.Y = midPoint.Y - firstImage.caseAttribute.ActualHeight / 2;
      //          }

      //          PathGeometry pathGeometry = new PathGeometry();
      //          PathFigure pathFigure = new PathFigure();
      //          pathFigure.caseAttribute.StartPoint = startPoint;

      //          LineSegment lineSegment1 = new LineSegment(new Point(startPoint.X, startPoint.Y - randomHeight), true);
      //          BezierSegment bezierSegment = new BezierSegment(new Point(midPoint.X, startPoint.Y - randomHeight),
      //                                                          new Point(midPoint.X, startPoint.Y - randomHeight),
      //                                                          new Point(endPoint.X, startPoint.Y - randomHeight), true);
      //          LineSegment lineSegment2 = new LineSegment(endPoint, true);

      //          pathFigure.caseAttribute.Segments.Add(lineSegment1);
      //          pathFigure.caseAttribute.Segments.Add(bezierSegment);

      //          pathFigure.caseAttribute.Segments.Add(lineSegment2);

      //          pathGeometry.Figures.Add(pathFigure);

      //          System.Windows.Shapes.Path path = new System.Windows.Shapes.Path
      //          {
      //              Data = pathGeometry,
      //              Stroke = Brushes.Red,
      //              StrokeThickness = 2,
      //              Tag = pathName // Set the Tag property to the provided path name
      //          };

      //          canvas.Children.Add(path);

      //          // Calculate the angle of the line
      //          double angle = Math.Atan2(dy, dx) / Math.PI;

      //          // Calculate the horizontal position of the arrowhead
      //          double arrowWidth = 10; // Width of the arrowhead
      //          double arrowX = midPoint.X - arrowWidth / 2; // Position centered on the midpoint

      //          int renderTransform = (int)midPoint.Y;
      //          if (invertY) renderTransform = -(int)midPoint.Y;

      //          // Add an arrowhead (triangle) at the midpoint
      //          double arrowEnd = arrowWidth;
      //          if (startPoint.X - endPoint.X < 0) arrowEnd = -arrowWidth;
      //          Polygon arrowhead = new Polygon
      //          {
      //              Points = new PointCollection
      //              {
      //             new Point(arrowX, startPoint.Y - randomHeight ), // Tip of the arrowhead
      //         new Point(arrowX + arrowEnd, startPoint.Y - 5 - randomHeight), // Bottom-right corner of the arrowhead
      //          new Point(arrowX + arrowEnd, startPoint.Y + 5 - randomHeight) // Top-right corner of the arrowhead
      //           },
      //              Fill = Brushes.Red,
      //              //   RenderTransform = new RotateTransform(180 + angle * 180, midPoint.X, renderTransform), // Rotate the arrowhead by 180 degrees
      //              Tag = pathName
      //          };

      //          canvas.Children.Add(arrowhead);
      //      }


      //      #endregion
      //      #region Move
      //      private void MoveButton_Click(object sender, MouseButtonEventArgs e)
      //      {
      //          isSelect = false;
      //          selectImage.caseAttribute.Opacity = 0.1;
      //          moveImage.caseAttribute.Opacity = 1.0;
      //      }
      //      #endregion


      //      #region case
      //      private void CasesMenu_Click(object sender, RoutedEventArgs e)
      //      {
      //          toolbarMenu.Visibility = Visibility.Hidden;
      //          casesMenu.Visibility = Visibility.Visible;
      //      }
      //      private void ToolbarMenu_Click(object sender, RoutedEventArgs e)
      //      {
      //          toolbarMenu.Visibility = Visibility.Visible;
      //          casesMenu.Visibility = Visibility.Hidden;
      //      }
      //      #endregion


      //      #endregion

      //      #region Menu
      //      private void New_Click(object sender, RoutedEventArgs e)
      //      {

      //      }

      //      private void Open_Click(object sender, RoutedEventArgs e)
      //      {

      //      }

      //      private void Exit_Click(object sender, RoutedEventArgs e)
      //      {

      //      }




      //      private void Elements_Click(object sender, RoutedEventArgs e)
      //      {
      //          //   AssignStateNumbers(items);
      //          FormElements formElements = new FormElements(elements);
      //          formElements.Show();
      //      }

      //      private void Attributes_Click(object sender, RoutedEventArgs e)
      //      {
      //          //   AssignStateNumbers(elements);
      //          //    FormAttributes formAttributes = new FormAttributes();
      //          //   formAttributes.Show();
      //          FormItemAttribute formAttributes = new FormItemAttribute(elements, this);
      //          formAttributes.Show();


      //      }




      //      #endregion


      //      #region canvas


      //      #region canvasZoom
      //      private void ZoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
      //      {
      //          double zoomValue = e.caseAttribute.NewValue;
      //          ApplyZoom(zoomValue);
      //      }

      //      private void ApplyZoom(double zoomValue)
      //      {
      //          canvas.LayoutTransform = new ScaleTransform(zoomValue, zoomValue);
      //      }
      //      #endregion

      //      #region canvasAddImageLabel

      //      private void AddLabelsToImages(List<Element> elements)
      //      {
      //          foreach (var element in elements)
      //          {
      //              // Create an Image
      //              Image image = new Image
      //              {
      //                  Source = new BitmapImage(new Uri(element.PathName, UriKind.Relative)),
      //                  Width = 100,
      //                  Height = 100
      //              };

      //              // Create a Label
      //              Label label = new Label
      //              {
      //                  Content = image.caseAttribute.Tag.ToString(),
      //                  HorizontalAlignment = HorizontalAlignment.Center,
      //                  VerticalAlignment = VerticalAlignment.Top,
      //                  Background = Brushes.White,
      //                  Opacity = 0.8
      //              };

      //              // Create a container (e.caseAttribute.g., a Grid) to hold the image and label
      //              Grid container = new Grid();
      //              container.Children.Add(image);
      //              container.Children.Add(label);

      //              // Set the position of the container using Canvas.Left and Canvas.Top
      //              Canvas.SetLeft(container, Canvas.GetLeft(image)); // Match image's X position
      //              Canvas.SetTop(container, Canvas.GetTop(image) - 30); // Position label above the image

      //              // Add the container to the canvas
      //              canvas.Children.Add(container);
      //          }
      //      }

      //      private void label_Click(object sender, MouseButtonEventArgs e)
      //      {


      //          AddLabelsToImages(elements);
      //      }




      //      #endregion

      //      #endregion

      //      #region case

      //      private void AddCase_Click(object sender, RoutedEventArgs e)
      //      {
      //          // Create a new RadioButton for the case
      //          RadioButton radioButton = new RadioButton();
      //          radioButton.Content = "Case " + (casesToolBar.Items.Count + 1);
      //          radioButton.GroupName = "Cases"; // Ensure they are mutually exclusive
      //          radioButton.TabIndex = cases.Count();
      //          // Attach a double-click event handler to the RadioButton
      //          radioButton.MouseDoubleClick += RadioButton_MouseDoubleClick;

      //          // Add the new case to the toolbar
      //          casesToolBar.Items.Add(radioButton);

      //          //   cases.Add(new Case { Name = radioButton.Content.ToString() });
      //      }

      //      private void RadioButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
      //      {
      //          RadioButton radioButton = (RadioButton)sender;
      //          // Create a TextBox to replace the RadioButton
      //          TextBox textBox = new TextBox();
      //          textBox.Text = radioButton.Content.ToString();

      //          // Handle the LostFocus event to save the changes when the TextBox loses focus
      //          textBox.LostFocus += TextBox_LostFocus;

      //          // Replace the RadioButton with the TextBox in the toolbar
      //          int index = casesToolBar.Items.IndexOf(radioButton);
      //          casesToolBar.Items.Insert(index, textBox);
      //          casesToolBar.Items.Remove(radioButton);

      //          // Set focus to the TextBox and select all text
      //          textBox.Focus();
      //          textBox.SelectAll();
      //      }

      //      private void TextBox_LostFocus(object sender, RoutedEventArgs e)
      //      {
      //          TextBox textBox = (TextBox)sender;

      //          // Get the index of the TextBox in the toolbar
      //          int index = casesToolBar.Items.IndexOf(textBox);

      //          // Create a new RadioButton with the updated text
      //          RadioButton newRadioButton = new RadioButton();
      //          newRadioButton.Content = textBox.Text;
      //          newRadioButton.GroupName = "Cases";

      //          // Attach the double-click event handler to the new RadioButton
      //          newRadioButton.MouseDoubleClick += RadioButton_MouseDoubleClick;

      //          // Replace the TextBox with the new RadioButton
      //          casesToolBar.Items.Insert(index, newRadioButton);
      //          casesToolBar.Items.Remove(textBox);
      //      }

      //      private void DeleteCase_Click(object sender, RoutedEventArgs e)
      //      {
      //          // Find the selected RadioButton and remove it
      //          RadioButton selectedRadioButton = casesToolBar.Items.OfType<RadioButton>().FirstOrDefault(rb => rb.IsChecked == true);
      //          if (selectedRadioButton != null)
      //          {
      //              casesToolBar.Items.Remove(selectedRadioButton);
      //          }
      //      }

      //      private void DownCase_Click(object sender, RoutedEventArgs e)
      //      {
      //          RadioButton selectedRadioButton = casesToolBar.Items.OfType<RadioButton>().FirstOrDefault(rb => rb.IsChecked == true);

      //          if (selectedRadioButton != null)
      //          {
      //              int currentIndex = casesToolBar.Items.IndexOf(selectedRadioButton);

      //              if (currentIndex < casesToolBar.Items.Count - 1)
      //              {
      //                  // Swap the positions of the selected RadioButton and the one below it
      //                  casesToolBar.Items.RemoveAt(currentIndex);
      //                  casesToolBar.Items.Insert(currentIndex + 1, selectedRadioButton);
      //                  selectedRadioButton.IsChecked = true; // Re-select the moved RadioButton
      //              }
      //          }
      //      }

      //      private void UpCase_Click(object sender, RoutedEventArgs e)
      //      {
      //          RadioButton selectedRadioButton = casesToolBar.Items.OfType<RadioButton>().FirstOrDefault(rb => rb.IsChecked == true);

      //          if (selectedRadioButton != null)
      //          {
      //              int currentIndex = casesToolBar.Items.IndexOf(selectedRadioButton);

      //              if (currentIndex > 0)
      //              {
      //                  // Swap the positions of the selected RadioButton and the one above it
      //                  casesToolBar.Items.RemoveAt(currentIndex);
      //                  casesToolBar.Items.Insert(currentIndex - 1, selectedRadioButton);
      //                  selectedRadioButton.IsChecked = true; // Re-select the moved RadioButton
      //              }
      //          }
      //      }

      //      private void ToolBar_Loaded(object sender, RoutedEventArgs e)
      //      {
      //          ToolBar toolBar = sender as ToolBar;
      //          var overflowGrid = toolBar.Template.caseAttribute.FindName("OverflowGrid", toolBar) as FrameworkElement;
      //          if (overflowGrid != null)
      //          {
      //              overflowGrid.Visibility = Visibility.Collapsed;
      //          }
      //          var mainPanelBorder = toolBar.Template.caseAttribute.FindName("MainPanelBorder", toolBar) as FrameworkElement;
      //          if (mainPanelBorder != null)
      //          {
      //              mainPanelBorder.Margin = new Thickness();
      //          }
      //      }

      //      private void SelectCase_Click(object sender, RoutedEventArgs e)
      //      {

      //      }


      //  }
      //  #endregion




    }




}
