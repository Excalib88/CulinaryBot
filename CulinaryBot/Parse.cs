using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text;
using AngleSharp.Parser.Html;
using AngleSharp.Extensions;

namespace CulinaryBot
{
	class Parse
	{
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
			
		}

	}
}
