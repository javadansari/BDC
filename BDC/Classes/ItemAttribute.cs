using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDC.Classes
{
    public class ItemAttribute
    {
        public string stage { get; set; } = "-";
        public string loadCase { get; set; } = "-";
        public int TubeArrangement { get; set; } = 0;
        public int Water_Gas_Flow_Pattern { get; set; } = 0;
        public string No_Rows { get; set; } = "-";
        public string SLN { get; set; } = "-";
        public string STN { get; set; } = "-";
        public string tube_Rows { get; set; } = "-";
        public string SL { get; set; } = "-";
        public string ST { get; set; } = "-";

    }
}
