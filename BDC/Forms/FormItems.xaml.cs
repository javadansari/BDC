using BDC.Classes;
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

namespace BDC.Forms
{
    /// <summary>
    /// Interaction logic for FormItems.xaml
    /// </summary>
    public partial class FormItems : Window
    {
        public List<Item> ItemsList { get; set; }

        public FormItems(List<Item> items)
        {
            InitializeComponent();
            ItemsList = items;
            listView.ItemsSource = null;
            listView.ItemsSource = items;
        }

    }
}
