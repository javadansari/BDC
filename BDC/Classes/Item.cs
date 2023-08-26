using System.Collections.Generic;

namespace BDC.Classes
{
    public class Item
    {
        public int id { get; set; }
        public bool exist { get; set; }
        public string name { get; set; }
        public int connection { get; set; }
        public string pathName { get; set; } = "-";
        public string state { get; set; } = "-";
        public int stateNumber { get; set; }

        public List<ItemAttribute> Attributes { get; set; }
    }

    public class ItemAttribute
    {
        public string name { get; set; }
    }
}
