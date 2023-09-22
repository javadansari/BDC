using BDC.Classes;
using System;
using System.Collections.Generic;
using System.Windows;

namespace BDC.Forms
{
    public partial class FormAttributes : Window
    {
        public List<Element> elements { get; set; }
    
        public List<ItemAttribute> gfgfgf { get; set; }
        
        
        public FormAttributes(List<Element> elements)
        {
       
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

           

            InitializeComponent();
         
            gfgfgf = attributes;
            DataContext = this;
        }
    }
}
