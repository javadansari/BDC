using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BDC.Classes
{
    public class Case
    {
        public int Id { get;  set; }
        public string Name { get; set; }
        public int order { get; set; }
        public bool run { get; set; }
        public Process process { get; set; }

    }
}
