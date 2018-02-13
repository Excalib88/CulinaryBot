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
	class Parse
	{
<<<<<<< HEAD
		readonly HttpClient client;
		readonly string url = "http://russianfood.com/";

		public Parse()
		{
			client = new HttpClient();
		}

		public async Task<string> GetSourceByPage()
		{
			var response = await client.GetAsync(url);
			string source = null;

			if (response != null && response.StatusCode == HttpStatusCode.OK)
			{
				source = await response.Content.ReadAsStringAsync();
			}
			GetLink(source);
			return source;
		}

		public static void GetLink(string source)
		{
			var parser = new HtmlParser();
			var document = parser.Parse(source);
			var emphasize = document.QuerySelector("a");

			Console.WriteLine(emphasize.ToHtml());   //<em> bold <u>and</u> italic </em>
			Console.WriteLine(emphasize.Text());   //boldanditalic
			Console.WriteLine(emphasize.InnerHtml);  // bold <u>and</u> italic
			Console.WriteLine(emphasize.OuterHtml);  //<em> bold <u>and</u> italic </em>
			Console.WriteLine(emphasize.TextContent);// bold and italic 
			
=======
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
>>>>>>> c622df67c4b5985f9729c27f5c4c38f8a2ee008f
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
