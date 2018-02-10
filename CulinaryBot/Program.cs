using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using System.Data.SQLite;

namespace CulinaryBot
{
	class Program
	{
		
		const string TOKEN = "484848836:AAGg2EXlGFJTVZC5BZPRJfdMnyGiK17ETrc";
		static void Main(string[] args)
		{

			while (true)
			{
				try
				{
					GetMessages().Wait();
				}
				catch (Exception ex)
				{
					Console.WriteLine("GetMessage ERROR - " + ex);
					Thread.Sleep(30000);
				}
			}
		}
		static async Task GetMessages()
		{
			TelegramBotClient bot = new TelegramBotClient(TOKEN);
			int offset = 0;
			int timeOut = 0;
			try
			{
				await bot.SetWebhookAsync("");

				while (true)
				{
					var updates = await bot.GetUpdatesAsync(offset, timeOut);
					foreach (var update in updates)
					{
						var message = update.Message;
						var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
						{
							Keyboard = new[] {
								new[]
								{
									new Telegram.Bot.Types.KeyboardButton("\U0001F4B0 Деньги \U0001F4B0"),
									new Telegram.Bot.Types.KeyboardButton("\U0001F45B Донат \U0001F45B")
								}
							},
							ResizeKeyboard = true
						};
						if (message.Text == "/reg")
						{
							Database db = new Database("1", "2");
							db.CreateNewUser();
						}
						if (message.Text == "/start")
						{
							await bot.SendTextMessageAsync(message.Chat.Id, "<b>Приветствую " + message.Chat.FirstName + "</b>" +
								"                                                                                    " + "Это кулинарный бот, который поможет тебе приготовить вкусности.",
								Telegram.Bot.Types.Enums.ParseMode.Html, false, false, 0, keyboard);
							
						}
						offset = update.Id + 1;
					}
				}
			}
			catch (Exception ex)
			{
				Logger.SendLogToFile(ex.ToString());
			}
		}
	}
}
