using System.Windows;
using System.Windows.Controls;

namespace BDC.Forms
{
    public partial class FormAttributes : Window
    {
        public FormAttributes()
        {
            InitializeComponent();

            // Create and configure the DataGrid
            DataGrid dataGrid = new DataGrid
            {
                Name = "dataGrid",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                AutoGenerateColumns = false
            };

            // Create columns
            DataGridTextColumn propertyNameColumn = new DataGridTextColumn
            {
                Header = "Property Name",
                Binding = new System.Windows.Data.Binding("PropertyName")
            };
            dataGrid.Columns.Add(propertyNameColumn);

            // Add similar DataGridTextColumn elements for other properties

            // Create the New Column
            DataGridTextColumn newColumn = new DataGridTextColumn
            {
                Header = "New Column",
                Binding = new System.Windows.Data.Binding("NewColumn")
            };
            dataGrid.Columns.Add(newColumn);

            // Set the DataGrid as the content of the Grid in the XAML
            Grid grid = (Grid)Content;
            grid.Children.Add(dataGrid);
        }
    }
}
