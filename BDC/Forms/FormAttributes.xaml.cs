using BDC.Classes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml.Linq;

namespace BDC.Forms
{
    public partial class FormAttributes : Window
    {
     


        public FormAttributes(List<Element> elements)
        {
            InitializeComponent();





            List<object> propertyList = new List<object>();

            // Create an instance of the ItemAttribute class
            ItemAttribute item = new ItemAttribute();

            // Use reflection to get the property names and values
            PropertyInfo[] properties = item.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                propertyList.Add(new { PropertyName = property.Name, Value = property.GetValue(item) });
            }

            //   propertyList.Add(new { , Value = property.GetValue(item) });


            // Set the DataGrid's ItemsSource to the collection
            dataGrid.ItemsSource = propertyList;



            var column = new DataGridTextColumn
            {
                Header = "stage",
                Binding = new System.Windows.Data.Binding("stage")
            };
            dataGrid.Columns.Add(column);

            foreach (Element element in elements)
            {

                 column = new DataGridTextColumn
                {
                    Header = element.State,
                    Binding = new System.Windows.Data.Binding(element.State)
                };
                dataGrid.Columns.Add(column);

            
                //    dataGrid.Items.Add(new Item() { Num = 1, Start = "2012, 8, 15", Finich = "2012, 9, 15" });

            }


            List<ItemAttribute> attributes = new List<ItemAttribute>();
            foreach (Element element in elements)
            {
                attributes.Add(element.attribute);
            }

            dataGrid.ItemsSource = attributes;
            // Bind the data items to the ListView
           

            //      dataGrid.ItemsSource = propertyList;




            // Set the DataGrid's ItemsSource to the collection


        }
    }
}
