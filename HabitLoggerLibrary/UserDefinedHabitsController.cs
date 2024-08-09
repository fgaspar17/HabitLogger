using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLoggerLibrary
{
    public class UserDefinedHabitsController
    {
        // To create habits for the user we create a new table
        public static void CreateHabit(string habitName, string quantityType)
        {
            try
            {
                using (SqliteConnection connection = new SqliteConnection(Config.ConnectionString))
                {
                    connection.Open();

                    SqliteCommand cmd = connection.CreateCommand();
                    cmd.CommandText = @$"CREATE TABLE IF NOT EXISTS ""{habitName.Trim()}"" (
	                            ""Id""	INTEGER NOT NULL,
	                            ""Day""	INTEGER NOT NULL,
	                            ""Quantity""	{quantityType} NOT NULL,
	                            PRIMARY KEY(""Id"" AUTOINCREMENT)
                                );";
                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"An error ocurred: {ex.Message}");
            }
        }
    }
}
