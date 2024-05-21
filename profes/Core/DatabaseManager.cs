using System.Text.Json;
using MySql.Data.MySqlClient;


public class DatabaseManager
{
    private readonly string _connectionString;

    public DatabaseManager()
    {
        // Load configuration from appsettings.json
        var json = File.ReadAllText("appsettings.json");
        var config = JsonSerializer.Deserialize<AppSettings>(json);
        
        _connectionString = config.ConnectionStrings.MySqlConnection;
    }

    public void ConnectToDatabase()
    {
        Console.WriteLine(_connectionString);
        using (var connection = new MySqlConnection(_connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connected to MySQL database!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally{
                if(connection != null){
                    connection.Clone();
                }
            }
        }
    }
}

public class AppSettings
{
    public ConnectionStrings ConnectionStrings { get; set; }
}

public class ConnectionStrings
{
    public string MySqlConnection { get; set; }
}
