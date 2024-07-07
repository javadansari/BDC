using BDC.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BDC.DataBase
{
    public class Export
    {
        public string filePath { get; set; }

        public Export(string filePath)
        {
            this.filePath = filePath;
        }

        public bool run(string path,string caseName)
        {
            string runPath = System.AppDomain.CurrentDomain.BaseDirectory + @"\Run.exe";
         //   Thread newThread = new Thread(new ThreadStart(Work));
        //    newThread.Start();
            var process = System.Diagnostics.Process.Start(runPath, path + " Result-Run-" + caseName + ".txt");
        //    var process = System.Diagnostics.Process.Start(runPath, path );
            process.WaitForExit();
            string resultPath = System.AppDomain.CurrentDomain.BaseDirectory  + @"\Result-Run-" + caseName + ".txt";
       //     newThread.Join();
            System.Diagnostics.Process.Start("notepad.exe", resultPath);
            return true;
        }

    public bool ExportFurnace(Furnace furnace)
        {
            ExportSpacer("Furnace");

            string line = "";
            Type objType = furnace.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                object value = prop.Name;
                line = line + "," + value;
            }
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(line);
            }

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    line = "";
                    foreach (PropertyInfo prop in properties)
                    {
                        object value = prop.GetValue(furnace);
                        line = line + "," + value;

                    }
                    writer.WriteLine(line);
            }
            return true;
        }


        public bool ExportElement(List<Element> elements)
        {
           
            ExportSpacer("Element");
            string line = "";
            Type objType = elements[0].attribute.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                object value = prop.Name;
                line = line + "," + value;
            }
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(line);
            }
            foreach (Element element in elements)
            {
              using (StreamWriter writer = new StreamWriter(filePath,true))
                {
                    line = "";
                    foreach (PropertyInfo prop in properties)
                    {
                        object value = prop.GetValue(element.attribute);
                         line = line + "," +  value;
                     
                    }
                    writer.WriteLine(line);
                }
            }
            return true;
        }
        public bool ExportDuct(Duct duct)
        {
            ExportSpacer("Duct");
            string line = "";
            Type objType = duct.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                object value = prop.Name;
                line = line + "," + value;
            }
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(line);
            }

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                line = "";
                foreach (PropertyInfo prop in properties)
                {
                    object value = prop.GetValue(duct);
                    line = line + "," + value;

                }
                writer.WriteLine(line);
            }
            ExportSpacer("-");
            return true;
        }

        public bool ExportOilFuel(List<OilFuel> oilFuels)
        {
            ExportSpacer("OilFuel");
            string line = "";
            Type objType = oilFuels[0].GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                object value = prop.Name;
                line = line + "," + value;
            }
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(line);
            }
            foreach (OilFuel oilFuel in oilFuels)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    line = "";
                    foreach (PropertyInfo prop in properties)
                    {
                        object value = prop.GetValue(oilFuel);
                        line = line + "," + value;

                    }
                    writer.WriteLine(line);
                }
            }
            return true;
        }

        public bool ExportGasFuel(List<GasFuel> gasFuels)
        {
            ExportSpacer("GasFuel");
            string line = "";
            Type objType = gasFuels[0].GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                object value = prop.Name;
                line = line + "," + value;
            }
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(line);
            }
            foreach (GasFuel gasFuel in gasFuels)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    line = "";
                    foreach (PropertyInfo prop in properties)
                    {
                        object value = prop.GetValue(gasFuel);
                        line = line + "," + value;

                    }
                    writer.WriteLine(line);
                }
            }
            return true;
        }

        public bool ExportInput(Inputs inputs)
        {
            ExportSpacer("Inputs");

            string line = "";
            Type objType = inputs.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                object value = prop.Name;
                line = line + "," + value;
            }
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(line);
            }

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                line = "";
                foreach (PropertyInfo prop in properties)
                {
                    object value = prop.GetValue(inputs);
                    line = line + "," + value;

                }
                writer.WriteLine(line);
            }
            return true;
        }
        public bool ExportProcess(List<Process> processes)
        {
            ExportSpacer("Case");
            string line = "";
            Type objType = processes[0].GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                object value = prop.Name;
                line = line + "," + value;
            }
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(line);
            }
            foreach (Process process in processes)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    line = "";
                    foreach (PropertyInfo prop in properties)
                    {
                        object value = prop.GetValue(process);
                        line = line + "," + value;

                    }
                    writer.WriteLine(line);
                }
            }
            return true;
        }



        //public bool ExportCases(List<Case> cases)
        //{
        //    ExportSpacer("Cases");
        //    string line = "";
        //    Type objType = cases[0].GetType();
        //    PropertyInfo[] properties = objType.GetProperties();
        //    foreach (PropertyInfo prop in properties)
        //    {
        //        object value = prop.Name;
        //        line = line + "," + value;
        //    }
        //    using (StreamWriter writer = new StreamWriter(filePath, true))
        //    {
        //        writer.WriteLine(line);
        //    }
        //    foreach (Case @case in cases)
        //    {
        //        using (StreamWriter writer = new StreamWriter(filePath, true))
        //        {
        //            line = "";
        //            foreach (PropertyInfo prop in properties)
        //            {
        //                object value = prop.GetValue(@case);
        //                line = line + "," + value;

        //            }
        //            writer.WriteLine(line);
        //        }
        //    }
        //    return true;
        //}

        public bool ExportSpacer(string name)
        {
  

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("--------------------------------------");
                writer.WriteLine("*****"+name+"*****");
                writer.WriteLine("--------------------------------------");
            }
            return true;
        }
    }

}
