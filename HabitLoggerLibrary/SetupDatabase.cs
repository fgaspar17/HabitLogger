using Microsoft.Data.Sqlite;
using System.Reflection.PortableExecutable;

namespace HabitLoggerLibrary;

public class SetupDatabase
{
    private const string ConnectionString = "Data Source=habit.db";
    
    public SetupDatabase()
    {
        
    }

    public void InitializeDatabase()
    {
        using (SqliteConnection connection = new SqliteConnection(ConnectionString))
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
}
