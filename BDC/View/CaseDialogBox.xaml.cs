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
    /// Interaction logic for CaseDialogBox.xaml
    /// </summary>
    public partial class CaseDialogBox : Window
    {
        public string InputText { get; private set; }

        public CaseDialogBox(string inputText = "Case")
        {
            InitializeComponent();
            InputText = inputText;
            txtInput.Text = InputText;
        }
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            InputText = txtInput.Text;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
