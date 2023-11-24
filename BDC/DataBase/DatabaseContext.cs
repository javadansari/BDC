using BDC.Classes;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BDC.DataBase
{
    internal class DatabaseContext
    {
        private SQLiteConnection connection;

        public DatabaseContext()
        {
            // Replace "YourDatabaseName.caseAttribute.db" with your SQLite database file name and path.
            string connectionString = "Data Source=Boiler.db;Version=3;";
            connection = new SQLiteConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (connection.State != System.Data.ConnectionState.caseAttribute.Open)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State != System.Data.ConnectionState.caseAttribute.Closed)
            {
                connection.Close();
            }
        }

        public void CreateTableIfNotExists()
        {
            OpenConnection();

            using (SQLiteCommand command = new SQLiteCommand())
            {
                command.Connection = connection;
                command.CommandText = "CREATE TABLE IF NOT EXISTS Items (" +
                                      "Id INTEGER PRIMARY KEY AUTOINCREMENT," +
                                      "Exist INTEGER," +
                                      "Name TEXT," +
                                      "Content TEXT," +
                                      "Connection INTEGER," +
                                      "PathName TEXT DEFAULT '-'," +
                                      "State TEXT DEFAULT '-'," +
                                      "StateNumber INTEGER," +
                                      "Image TEXT," +
                                      "Position INTEGER," +
                                      "X REAL," +
                                      "Y REAL," + 
                                      "Attribute);";
                command.ExecuteNonQuery();
            }

            CloseConnection();


            //OpenConnection();

            //using (SQLiteCommand command = new SQLiteCommand())
            //{
            //    command.CommandText = @"CREATE TABLE IF NOT EXISTS Cases (
            //                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
            //                                Name TEXT,
            //                                Ambient_Condition TEXT DEFAULT '-',
            //                                Site_Atmospheric_Pressure TEXT DEFAULT '-',
            //                                Ambient_Temperature TEXT DEFAULT '-',
            //                                Relative_Humidity TEXT DEFAULT '-',
            //                                Combustion TEXT DEFAULT '-',
            //                                GAS1 TEXT DEFAULT '-',
            //                                GAS2 TEXT DEFAULT '-',
            //                                GAS3 TEXT DEFAULT '-',
            //                                GAS4 TEXT DEFAULT '-',
            //                                GAS5 TEXT DEFAULT '-',
            //                                OIL1 TEXT DEFAULT '-',
            //                                OIL2 TEXT DEFAULT '-',
            //                                Excess_Air TEXT DEFAULT '-',
            //                                Atmozing_Steam_Flow TEXT DEFAULT '-',
            //                                Atmozing_Steam_Pressure TEXT DEFAULT '-',
            //                                Atmozing_Steam_Temperature TEXT DEFAULT '-',
            //                                FDF TEXT DEFAULT '-',
            //                                Fan_efficiency TEXT DEFAULT '-',
            //                                Heat_exchange_ducty TEXT DEFAULT '-',
            //                                Steam_Outlet TEXT DEFAULT '-',
            //                                Steam_Pressure_TP TEXT DEFAULT '-',
            //                                Main_steam_Pressue_Drop TEXT DEFAULT '-',
            //                                Desuperheater TEXT DEFAULT '-',
            //                                Location_of_DESH TEXT DEFAULT '-',
            //                                Steam_temperature_set_point_TP TEXT DEFAULT '-',
            //                                Min_SH_degree_at_desperheater_outlet TEXT DEFAULT '-',
            //                                Feed_water TEXT DEFAULT '-',
            //                                Feed_water_Pressure TEXT DEFAULT '-',
            //                                Feed_water_Temperature TEXT DEFAULT '-',
            //                                BFP_temperature_rise TEXT DEFAULT '-',
            //                                Feed_water_piping_dp TEXT DEFAULT '-',
            //                                Level_control_Valve_dp TEXT DEFAULT '-',
            //                                Losses TEXT DEFAULT '-',
            //                                Unburned_Loss TEXT DEFAULT '-',
            //                                Radiation_Loss TEXT DEFAULT '-',
            //                                Furnace_heat_absorption_Eff TEXT DEFAULT '-',
            //                                Blowdown TEXT DEFAULT '-',
            //                                Blowdown_flow TEXT DEFAULT '-'
            //                                );";

            //    command.ExecuteNonQuery();
            //}

            //connection.Close();


            OpenConnection();

            using (SQLiteCommand command = new SQLiteCommand())
            {
                command.Connection = connection;
                //command.CommandText = "CREATE TABLE IF NOT EXISTS Cases (" +
                //                      "Id INTEGER PRIMARY KEY AUTOINCREMENT," +
                //                      "Name TEXT);";

                command.CommandText = @"CREATE TABLE IF NOT EXISTS Cases (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Name TEXT,
                                            Ambient_Condition TEXT DEFAULT '-',
                                            Site_Atmospheric_Pressure TEXT DEFAULT '-',
                                            Ambient_Temperature TEXT DEFAULT '-',
                                            Relative_Humidity TEXT DEFAULT '-',
                                            Combustion TEXT DEFAULT '-',
                                            GAS1 TEXT DEFAULT '-',
                                            GAS2 TEXT DEFAULT '-',
                                            GAS3 TEXT DEFAULT '-',
                                            GAS4 TEXT DEFAULT '-',
                                            GAS5 TEXT DEFAULT '-',
                                            OIL1 TEXT DEFAULT '-',
                                            OIL2 TEXT DEFAULT '-',
                                            Excess_Air TEXT DEFAULT '-',
                                            Atmozing_Steam_Flow TEXT DEFAULT '-',
                                            Atmozing_Steam_Pressure TEXT DEFAULT '-',
                                            Atmozing_Steam_Temperature TEXT DEFAULT '-',
                                            FDF TEXT DEFAULT '-',
                                            Fan_efficiency TEXT DEFAULT '-',
                                            Heat_exchange_ducty TEXT DEFAULT '-',
                                            Steam_Outlet TEXT DEFAULT '-',
                                            Steam_Pressure_TP TEXT DEFAULT '-',
                                            Main_steam_Pressue_Drop TEXT DEFAULT '-',
                                            Desuperheater TEXT DEFAULT '-',
                                            Location_of_DESH TEXT DEFAULT '-',
                                            Steam_temperature_set_point_TP TEXT DEFAULT '-',
                                            Min_SH_degree_at_desperheater_outlet TEXT DEFAULT '-',
                                            Feed_water TEXT DEFAULT '-',
                                            Feed_water_Pressure TEXT DEFAULT '-',
                                            Feed_water_Temperature TEXT DEFAULT '-',
                                            BFP_temperature_rise TEXT DEFAULT '-',
                                            Feed_water_piping_dp TEXT DEFAULT '-',
                                            Level_control_Valve_dp TEXT DEFAULT '-',
                                            Losses TEXT DEFAULT '-',
                                            Unburned_Loss TEXT DEFAULT '-',
                                            Radiation_Loss TEXT DEFAULT '-',
                                            Furnace_heat_absorption_Eff TEXT DEFAULT '-',
                                            Blowdown TEXT DEFAULT '-',
                                            Blowdown_flow TEXT DEFAULT '-'
                                            );";
                command.ExecuteNonQuery();
            }

            CloseConnection();

        }

       



        public void SaveData(Element element)
        {
            OpenConnection();

            using (SQLiteCommand command = new SQLiteCommand())
            {
                command.Connection = connection;

                command.CommandText = "INSERT INTO Items (Exist, Name, Content, Connection, PathName, State, StateNumber, Image, Position, X, Y , Attribute) " +
                                      "VALUES (@Exist, @Name, @Connection, @PathName, @State, @StateNumber, @Image, @Position, @X, @Y , @Attribute);";

                command.Parameters.AddWithValue("@Exist", element.Exist);
                command.Parameters.AddWithValue("@Name", element.Name);
                command.Parameters.AddWithValue("@Content", element.Content);
                command.Parameters.AddWithValue("@Connection", element.Connection);
                command.Parameters.AddWithValue("@PathName", element.PathName);
                command.Parameters.AddWithValue("@State", element.State);
                command.Parameters.AddWithValue("@StateNumber", element.StateNumber);
                command.Parameters.AddWithValue("@Image", element.Image.caseAttribute.Source);
                command.Parameters.AddWithValue("@Position", element.Position);
                command.Parameters.AddWithValue("@X", element.X);
                command.Parameters.AddWithValue("@Y", element.Y);

                string serializedAttribute = SerializeItemAttributeToJson(element.attribute);
                command.Parameters.AddWithValue("@Attribute", serializedAttribute);


                command.ExecuteNonQuery();
            }

            CloseConnection();
        }


        public void SaveCases(Case @case)
        {
            OpenConnection();

            using (SQLiteCommand command = new SQLiteCommand())
            {
                command.Connection = connection;

                command.CommandText = "INSERT INTO Cases ( Name) " +
                                      "VALUES ( @Name);";
                command.Parameters.AddWithValue("@Name", @case.caseAttribute.Name);

                command.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public ItemAttribute DeserializeJsonToItemAttribute(string json)
        {
            return JsonSerializer.Deserialize<ItemAttribute>(json);
        }
        public string SerializeItemAttributeToJson(ItemAttribute itemAttribute)
        {
            return JsonSerializer.Serialize(itemAttribute);
        }
        public List<Element> ReadData()
        {
            OpenConnection();

            List<Element> elements = new List<Element>();

            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Items", connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Image image = new Image();
                        image.caseAttribute.Tag = reader.GetString(5).ToString();
                        image.caseAttribute.Width =48;
                        image.caseAttribute.Height =48;
                        image.caseAttribute.Source = new BitmapImage(new Uri(reader.GetString(7)));


                        string serializedAttribute = reader.GetString(11); // Assuming Attribute is at column index 11
                        ItemAttribute attribute = DeserializeJsonToItemAttribute(serializedAttribute);


                        Element element = new Element
                        {
                        //   Id = reader.GetInt32(0),
                            Exist = reader.GetBoolean(1),
                            Name = reader.GetString(2),
                            Connection = reader.GetInt32(3),
                            PathName = reader.GetString(4),
                            State = reader.GetString(5),
                            StateNumber = reader.GetInt32(6),
                            Image = image,
                            Position = reader.GetInt32(8),
                            X = reader.GetDouble(9),
                            Y = reader.GetDouble(10),
                            attribute = attribute 

                        };

                        elements.Add(element);
                    }
                }
            }

            CloseConnection();

            return elements;
        }

        public List<Case> ReadCase()
        {
            OpenConnection();

            List<Case> cases = new List<Case>();

            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Cases", connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Case @case = new Case
                        {
                            Name = reader.GetString(2),        
                        };

                        cases.Add(@case);
                    }
                }
            }

            CloseConnection();

            return cases;
        }


        public void DeleteDatabase()
        {
            CloseConnection(); // Close the connection before deleting the file

            string databaseFileName = "Boiler.db"; // Replace with your database file name and path

            if (File.caseAttribute.Exists(databaseFileName))
            {
                try
                {
                    File.caseAttribute.Delete(databaseFileName);
                    Console.caseAttribute.WriteLine("Database deleted successfully.");
                }
                catch (Exception ex)
                {
                    Console.caseAttribute.WriteLine($"Error deleting the database: {ex.Message}");
                }
            }
            else
            {
                Console.caseAttribute.WriteLine("The database file does not exist.");
            }
        }
    }

}
