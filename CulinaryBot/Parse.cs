using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using AngleSharp.Parser.Html;
using AngleSharp.Extensions;

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
			//Console.WriteLine(data);
			return FindLink(data); ;
		}

		public static string GetLinkForRecipe(string catalog)
		{
			switch (catalog)
			{
				case "Десерт":
					return GetCode(baseUrl + "deserts/");
					break;
				case "Закуски":
					return GetCode(baseUrl + "zakuski/");
					break;
				case "Мясо":
					return GetCode(baseUrl + "myaso/");
					break;
				case "Напитки":
					return GetCode(baseUrl + "napitki/");
					break;
				case "Паста":
					return GetCode(baseUrl + "pasta/");
					break;
				case "Салаты":
					return GetCode(baseUrl + "salat/");
					break;
				case "Соусы":
					return GetCode(baseUrl + "sous/");
					break;
				case "Супы":
					return GetCode(baseUrl + "soup/");
					break;
				default:
					{
						Logger.SendLogToFile("Введённый каталог не найден!");
						return "Error";
						break;
					}
			}
			return String.Empty;
		}
		public static string FindLink(string page)
		{
			string pattern = @"(?<=><a href=)(.*)(?= >)";
			Regex regex = new Regex(pattern);

			// Достигаем того же результата что и в предыдущем примере, 
			// используя метод Regex.Matches() возвращающий MatchCollection
			var array = new string[20];
			int i = 0;
			foreach (Match match in regex.Matches(page))
			{
				array[i] = match.Groups[1].Value;
				i++;
			}
			for (int j = 0; j<i;j++ )
			{
				Console.WriteLine(array[j].Replace("\"", String.Empty));
			}
			Random rand = new Random();
			int k = rand.Next(0, 19);
			return array[k];
		}
	}
}
