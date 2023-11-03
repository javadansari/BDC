using BDC.Classes;
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
            // Replace "YourDatabaseName.db" with your SQLite database file name and path.
            string connectionString = "Data Source=Boiler.db;Version=3;";
            connection = new SQLiteConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
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



            OpenConnection();

            using (SQLiteCommand command = new SQLiteCommand())
            {
                command.Connection = connection;
                command.CommandText = "CREATE TABLE IF NOT EXISTS Cases (" +
                                      "Id INTEGER PRIMARY KEY AUTOINCREMENT," +
                                      "Name TEXT);";
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

                command.CommandText = "INSERT INTO Items (Exist, Name, Connection, PathName, State, StateNumber, Image, Position, X, Y , Attribute) " +
                                      "VALUES (@Exist, @Name, @Connection, @PathName, @State, @StateNumber, @Image, @Position, @X, @Y , @Attribute);";

                command.Parameters.AddWithValue("@Exist", element.Exist);
                command.Parameters.AddWithValue("@Name", element.Name);
                command.Parameters.AddWithValue("@Connection", element.Connection);
                command.Parameters.AddWithValue("@PathName", element.PathName);
                command.Parameters.AddWithValue("@State", element.State);
                command.Parameters.AddWithValue("@StateNumber", element.StateNumber);
                command.Parameters.AddWithValue("@Image", element.Image.Source);
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
                command.Parameters.AddWithValue("@Name", @case.Name);

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
                        image.Tag = reader.GetString(5).ToString();
                        image.Width =48;
                        image.Height =48;
                        image.Source = new BitmapImage(new Uri(reader.GetString(7)));


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

            if (File.Exists(databaseFileName))
            {
                try
                {
                    File.Delete(databaseFileName);
                    Console.WriteLine("Database deleted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting the database: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("The database file does not exist.");
            }
        }
    }

}
