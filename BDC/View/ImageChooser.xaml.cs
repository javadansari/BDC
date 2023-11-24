using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BDC.View
{

    public partial class ImageChooser : Window
    {
        public ImageChooser()
        {
            InitializeComponent();
            Loaded += ImageChooser_Loaded;
        }

        private void ImageChooser_Loaded(object sender, RoutedEventArgs e)
        {
            Point mousePosition = Mouse.caseAttribute.GetPosition(null);
            Left = mousePosition.X - Width / 2;
            Top = mousePosition.Y - Height / 2;
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

    }
}
