using Microsoft.Data.Sqlite;
using System.Reflection.PortableExecutable;

namespace HabitLoggerLibrary;

public class SetupDatabase
{

    public SetupDatabase()
    {
        
    }

    public void InitializeDatabase()
    {
        try
        {
            using (SqliteConnection connection = new SqliteConnection(Config.ConnectionString))
            {
                connection.Open();

                SqliteCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"CREATE TABLE IF NOT EXISTS ""DrinkWater"" (
	                            ""Id""	INTEGER NOT NULL,
	                            ""Day""	INTEGER NOT NULL,
	                            ""Quantity""	INTEGER NOT NULL,
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
