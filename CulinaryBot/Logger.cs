using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace CulinaryBot
{
	static class Logger
	{
		public static void SendLogToFile(string exception)
		{
			string path = "Logs.txt";
			DateTime currentTime = DateTime.Now;
			
			try
			{
				using (StreamWriter sw = File.AppendText(path))
				{
					var exceptionText = $"{currentTime}: {exception}";
					sw.WriteLine(exceptionText);
					Console.WriteLine(exceptionText);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}
