using BDC.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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

        public bool ExportFurnace(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (PropertyInfo prop in properties)
                {
                    object value = prop.GetValue(obj);
                    string line = $"{prop.Name}: {value}";
                    writer.WriteLine(line);
                }
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
        public bool ExportDuct(List<Duct> ducts)
        {
            ExportSpacer("Duct");
            string line = "";
            Type objType = ducts[0].GetType();
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
            foreach (Duct duct in ducts)
            {
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
            }
            return true;
        }

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
