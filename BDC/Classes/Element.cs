using System.Collections.Generic;
using System.Windows.Controls;

namespace BDC.Classes
{
    public class Element
    {
        private static int _idCounter = 1; // Static counter for generating IDs

        public int id { get; private set; }
        public bool exist { get; set; }
        public string name { get; set; }
        public int connection { get; set; }
        public string pathName { get; set; } = "-";
        public string state { get; set; } = "-";
        public int stateNumber { get; set; }
        public Image image { get; set; }

        public int position { get; set; } 
        public double x { get; set; } 
        public double y { get; set; } 
        public List<ItemAttribute> Attributes { get; set; }
        public Element()
        {
            id = _idCounter++; // Assign a new unique ID and increment the counter
        }
    }


}
