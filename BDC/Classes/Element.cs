using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Controls;

namespace BDC.Classes
{
    public class Element
    {
     //   private static int _idCounter = 1; // Static counter for generating IDs

        public int Id { get;  set; }
        public bool Exist { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int Connection { get; set; }
        public string PathName { get; set; } = "-";
        public string State { get; set; } = "-";
        public int StateNumber { get; set; }
        public Image Image { get; set; }
        public int Position { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public ItemAttribute attribute { get; set; }

        public Element()
        {
        //    Id = _idCounter++; // Assign a new unique ID and increment the counter
        }

      
    }
       



}
