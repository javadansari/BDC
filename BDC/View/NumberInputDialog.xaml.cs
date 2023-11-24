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
    /// <summary>
    /// Interaction logic for NumberInputDialog.xaml
    /// </summary>
    public partial class NumberInputDialog : Window
    {
        public int SelectedNumber { get; private set; }

        public NumberInputDialog()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cmbNumbers.SelectedItem;
            if (selectedItem != null && int.TryParse(selectedItem.Content.ToString(), out int selectedValue))
            {
                SelectedNumber = selectedValue;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please select a number.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.caseAttribute.Warning);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Perform any cancellation logic here if needed
            DialogResult = false;

        }
    }
}
