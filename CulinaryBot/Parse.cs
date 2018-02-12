using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using AngleSharp.Parser.Html;

namespace CulinaryBot
{
	static class Parse
	{
		static public string baseUrl = "https://andychef.ru/";


		public static String GetCode(string urlAddress)
		{
			string data = "";
			WebClient wc = new WebClient();
			data = wc.DownloadString(urlAddress);
			Console.WriteLine(data);
			FindLink(data);
			return data;
		}

		public static void GetLinkForRecipe(string catalog)
		{
			switch (catalog)
			{
				case "Десерт":
					GetCode(baseUrl + "deserts/");
					break;
				case "Закуски":
					GetCode(baseUrl + "zakuski/");
					break;
				case "Мясо":
					GetCode(baseUrl + "myaso/");
					break;
				case "Напитки":
					GetCode(baseUrl + "napitki/");
					break;
				case "Паста":
					GetCode(baseUrl + "pasta/");
					break;
				case "Салаты":
					GetCode(baseUrl + "salat/");
					break;
				case "Соусы":
					GetCode(baseUrl + "sous/");
					break;
				case "Супы":
					GetCode(baseUrl + "soup/");
					break;
				default:
					{
						Logger.SendLogToFile("Введённый каталог не найден!");
						break;
					}
			}
		}
		public static void FindLink(string page)
		{
			string pattern = @"\b(\d+\W?руб)";
			Regex regex = new Regex(pattern);

			// Достигаем того же результата что и в предыдущем примере, 
			// используя метод Regex.Matches() возвращающий MatchCollection
			foreach (Match match in regex.Matches(page))
			{
				Console.WriteLine(match.Groups[1].Value);
			}
		}
	}
}
