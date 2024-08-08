using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLoggerLibrary
{
    public class HabitController
    {

        public static List<HabitModel> GetRecords()
        {
            try
            {
                List<HabitModel> records = new List<HabitModel>();
                using (SqliteConnection connection = new SqliteConnection(Config.ConnectionString))
                {
                    connection.Open();
                    SqliteCommand cmd = connection.CreateCommand();

                    cmd.CommandText = "SELECT Id, Day, Quantity FROM DrinkWater";

                    SqliteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        records.Add(new HabitModel()
                        {
                            Id = reader.GetFieldValue<int>(0),
                            Day = reader.GetFieldValue<int>(1),
                            Quantity = reader.GetFieldValue<int>(2),
                        });
                    }
                    connection.Close();
                }

                return records;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error ocurred: {ex.Message}");
                return new List<HabitModel>();
            }
        }
        public static bool InsertRecord(HabitModel habit)
        {
            try
            {
                using (SqliteConnection connection = new SqliteConnection(Config.ConnectionString))
                {
                    connection.Open();
                    SqliteCommand cmd = connection.CreateCommand();

                    cmd.CommandText = $@"INSERT INTO DrinkWater (Day, Quantity) 
                                        VALUES ({habit.Day}, {habit.Quantity})";

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error ocurred: {ex.Message}");
                return false;
            }
        }

        public static bool UpdateRecord(HabitModel habit)
        {
            try
            {
                using (SqliteConnection connection = new SqliteConnection(Config.ConnectionString))
                {
                    connection.Open();
                    SqliteCommand cmd = connection.CreateCommand();

                    cmd.CommandText = $@"UPDATE DrinkWater  SET 
                                        Day = {habit.Day}, 
                                        Quantity = {habit.Quantity}
                                        WHERE Id = {habit.Id}";

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error ocurred: {ex.Message}");
                return false;
            }
        }

        public static bool DeleteRecord(HabitModel habit)
        {
            try
            {
                using (SqliteConnection connection = new SqliteConnection(Config.ConnectionString))
                {
                    connection.Open();
                    SqliteCommand cmd = connection.CreateCommand();

                    cmd.CommandText = $@"DELETE FROM DrinkWater
                                        WHERE Id = {habit.Id}";

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error ocurred: {ex.Message}");
                return false;
            }
        }
    }
}
