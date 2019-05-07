using System;
using MySql.Data.MySqlClient;

namespace AnimalShelter.Model
{
  public class DB
  {
    public static MySqlConnection Connection()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      return conn;
    }

    public static void CloseDatabase(MySqlConnection conn)
    {
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
