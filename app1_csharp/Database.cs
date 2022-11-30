using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app1_csharp
{
    class Database
    {
        private SQLiteConnection sqlite;
        public Database()
        {
            string directory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string connectionString = "Data Source=" + directory + @"\Database.db;Version=3";
            sqlite = new SQLiteConnection(connectionString);
        }

        public void Insert(String winner, int time, int attempts)
        {
            string query = "INSERT INTO Statistics(Winner,Time,Attempts) VALUES ($winner,$time,$attempts)";
            SQLiteCommand command = new SQLiteCommand(query, sqlite);
            command.Parameters.AddWithValue("$winner", winner);
            command.Parameters.AddWithValue("$time", time);
            command.Parameters.AddWithValue("$attempts", attempts);
            sqlite.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            sqlite.Close();
        }
    }
}
