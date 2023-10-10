﻿using BDC.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BDC.Forms
{
    public partial class FormAttributes : Window
    {



        public FormAttributes(List<Element> elements)
        {


            InitializeComponent();
            
            c_dataGrid.ItemsSource = elements;
            int columnsToRemove = 2;

            // Loop through and remove the first three columns
            for (int i = 0; i < columnsToRemove && i < c_dataGrid.Columns.Count; i++)
            {
                c_dataGrid.Columns.RemoveAt(0);
            }

        }
        private void c_dataGridScrollViewer_Loaded(object sender, RoutedEventArgs e)
        {
            // Add MouseWheel support for the datagrid scrollviewer.
            c_dataGrid.AddHandler(MouseWheelEvent, new RoutedEventHandler(DataGridMouseWheelHorizontal), true);
        }

        private void DataGridMouseWheelHorizontal(object sender, RoutedEventArgs e)
        {
            MouseWheelEventArgs eargs = (MouseWheelEventArgs)e;
            double x = (double)eargs.Delta;
            double y = c_dataGridScrollViewer.VerticalOffset;
            c_dataGridScrollViewer.ScrollToVerticalOffset(y - x);
        }

        private void c_dataGrid_AutoGeneratedColumns(object sender, EventArgs e)
        {
            TransformGroup transformGroup = new TransformGroup();
            transformGroup.Children.Add(new RotateTransform(90));
            foreach (DataGridColumn dataGridColumn in c_dataGrid.Columns)
            {
                if (dataGridColumn is DataGridTextColumn)
                {
                    DataGridTextColumn dataGridTextColumn = dataGridColumn as DataGridTextColumn;

                    Style style = new Style(dataGridTextColumn.ElementStyle.TargetType, dataGridTextColumn.ElementStyle.BasedOn);
                    style.Setters.Add(new Setter(TextBlock.MarginProperty, new Thickness(0, 2, 0, 2)));
                    style.Setters.Add(new Setter(TextBlock.LayoutTransformProperty, transformGroup));
                    style.Setters.Add(new Setter(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Center));

                    Style editingStyle = new Style(dataGridTextColumn.EditingElementStyle.TargetType, dataGridTextColumn.EditingElementStyle.BasedOn);
                    editingStyle.Setters.Add(new Setter(TextBox.MarginProperty, new Thickness(0, 2, 0, 2)));
                    editingStyle.Setters.Add(new Setter(TextBox.LayoutTransformProperty, transformGroup));
                    editingStyle.Setters.Add(new Setter(TextBox.HorizontalAlignmentProperty, HorizontalAlignment.Center));

                    dataGridTextColumn.ElementStyle = style;
                    dataGridTextColumn.EditingElementStyle = editingStyle;
                }
            }
            List<DataGridColumn> dataGridColumns = new List<DataGridColumn>();
            foreach (DataGridColumn dataGridColumn in c_dataGrid.Columns)
            {
                dataGridColumns.Add(dataGridColumn);
            }
            c_dataGrid.Columns.Clear();
            dataGridColumns.Reverse();
            foreach (DataGridColumn dataGridColumn in dataGridColumns)
            {
                c_dataGrid.Columns.Add(dataGridColumn);
            }
        }
    }
}
