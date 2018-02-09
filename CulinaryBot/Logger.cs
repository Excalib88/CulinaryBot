using System;
using System.Collections.Generic;
using System.Text;

namespace CulinaryBot
{
	static class Logger
	{
		public static void SendLogToFile(string exceptionText)
		{
			Console.WriteLine(exceptionText);
		}
	}
}
