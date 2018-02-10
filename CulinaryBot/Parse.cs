using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;

namespace CulinaryBot
{
	class Parse
	{
		public IEnumerable<string> AngleSharp()
		{
			List<string> hrefTags = new List<string>();

			var parser = new HtmlParser();
			var document = parser.Parse("http://russianfood.com/");
			foreach (IElement element in document.QuerySelectorAll("a"))
			{
				hrefTags.Add(element.GetAttribute("href"));
			}

			return hrefTags;
		}

	}
}
