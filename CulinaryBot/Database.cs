using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace CulinaryBot
{
	class Database
	{
		public string ChatId { get; set; }
		public string Login { get; set; }
		public string Id { get; set; }
		private SQLiteConnection DB;

		public Database(string chatId, string login)
		{
			this.ChatId = chatId;
			this.Login = login;
		}

		public void CreateNewUser()
		{
			try
			{
				DB = new SQLiteConnection("Data Source=CulinaryBot.db;");
				DB.Open();
				SQLiteCommand cmd = DB.CreateCommand();
				Id = Guid.NewGuid().ToString();
				Console.WriteLine(Id);
				cmd.CommandText = "INSERT INTO Users VALUES (@id, @chatId, @login)";
				cmd.Parameters.AddWithValue("@id", Id);
				cmd.Parameters.AddWithValue("@chatId", ChatId);
				cmd.Parameters.AddWithValue("@login", Login);
				cmd.ExecuteNonQuery();
				DB.Close();
			}
			catch (Exception ex)
			{
				Logger.SendLogToFile(ex.ToString());
				Console.WriteLine(ex);
				return;
			}
		}
	}
}
