using System;

using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

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
									new Telegram.Bot.Types.KeyboardButton("\U0001F4B0 Получить рецепт \U0001F4B0"),
									new Telegram.Bot.Types.KeyboardButton("\U0001F45B Отправить доработку \U0001F45B")
								}
							},
							ResizeKeyboard = true
						};
						
						if (message.Text == "/start")
						{
							await bot.SendTextMessageAsync(message.Chat.Id, "<b>Приветствую " + message.Chat.FirstName + "</b>" +
								"                                                                                    " + "Это кулинарный бот, который поможет тебе приготовить вкусности.",
								Telegram.Bot.Types.Enums.ParseMode.Html, false, false, 0, keyboard);
<<<<<<< HEAD
							var parse = new Parse(); 
							await parse.GetSourceByPage();
=======
							Parse.GetLinkForRecipe("Десерт");
>>>>>>> c622df67c4b5985f9729c27f5c4c38f8a2ee008f
							Database db = new Database(message.Chat.Id.ToString(), message.Chat.Username);
							db.CreateNewUser();
						}
						
						offset = update.Id + 1;
					}
				}
			}
			catch (Exception ex)
			{
				Logger.SendLogToFile(ex.ToString());
				return;
			}
		}
	}
}
