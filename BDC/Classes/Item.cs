using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDC.Classes
{
    internal class Item 
    {
        public int id { get; set; }
        public bool exist { get; set; }
        public string name { get; set; }
        public int connection { get; set; }
        public string pathName { get; set; }
        public string state { get; set; } = "def";
        public int stateNumber { get; set; }


    }

   
}
