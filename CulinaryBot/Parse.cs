using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text;
using AngleSharp.Parser.Html;

namespace CulinaryBot
{
	static class Parse
	{
		public static String GetCode(string urlAddress)
		{
			string data = "";
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			if (response.StatusCode == HttpStatusCode.OK)
			{
				Stream receiveStream = response.GetResponseStream();
				StreamReader readStream = null;
				if (response.CharacterSet == null)
				{
					readStream = new StreamReader(receiveStream);
				}
				else
				{
					readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
				}
				data = readStream.ReadToEnd();
				response.Close();
				readStream.Close();
			}
			return data;
		}

		public static void GetLink()
		{
			var parser = new HtmlParser();
			var document = parser.Parse(GetCode("http://russianfood.com/"));

			var blueListItemsCssSelector = document.QuerySelectorAll("a.detail");

			foreach (var item in blueListItemsCssSelector)
				Console.WriteLine(item.ToString());
		}

	}
}
