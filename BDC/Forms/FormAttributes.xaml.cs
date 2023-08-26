using BDC.Classes;
using System;
using System.Collections.Generic;
using System.Windows;

namespace BDC.Forms
{
    public partial class FormAttributes : Window
    {
        public List<Item> ItemsList { get; set; }
        public List<ItemAttribute> gfgfgf { get; set; }

        public FormAttributes()
        {
       

            List<Item> items = new List<Item>
            {
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 0, name = "sj", pathName = "path" },
                new Item { id = 1, name = "bjh", pathName = "pagjhgth" }
            };

            List<ItemAttribute> attributes = new List<ItemAttribute>
            {
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "jkklj" },
                new ItemAttribute { name = "dfgdgf" },
                new ItemAttribute { name = "gfgfd" },
                new ItemAttribute { name = "javad" },
                new ItemAttribute { name = "ali" },
                new ItemAttribute { name = "gfgfd" }
            };

            foreach (var item in items)
            {
                item.Attributes = new List<ItemAttribute>(attributes);
            }

            InitializeComponent();
            ItemsList = items;
            gfgfgf = attributes;
            DataContext = this;
        }
    }
}
