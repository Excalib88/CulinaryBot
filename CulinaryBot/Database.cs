using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace CulinaryBot
{
    class Database
    {
		public string login { get; set; }
		public string password { get; set; }
		private SQLiteConnection DB;

		public Database(string login, string password)
		{
			this.login = login;
			this.password = password;
		}
		public void CreateNewUser()
		{
			DB = new SQLiteConnection("Data Source=CulinaryBot.db;");
			DB.Open();
			SQLiteCommand cmd = DB.CreateCommand();
			cmd.CommandText = "insert into Users values (1, 'admin', @Login, 'admin')";
			cmd.Parameters.AddWithValue("@Login", "admin");
			cmd.ExecuteNonQuery();
			DB.Close();
		}
	}
}
