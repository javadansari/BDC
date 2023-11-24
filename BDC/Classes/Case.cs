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
        public int Id { get; private set; }
        public string Name { get; set; }
        public int sort { get; set; }
        public int run { get; set; }
        public CaseAttribute caseAttribute { get; set; }


        




    }
}
