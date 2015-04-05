using System;

namespace Dunn_2D
{
	/// <summary>
	/// Description of Log.
	/// </summary>
	public static class Log
	{
		public static void Output(int code, String msg) {
			switch(code) {
				case 0: 
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine(msg); 
					break;
				case 1: 
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("> " + msg); 
					break;
				case 2: 
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("<!Warning>" + msg);
					break;
				case 3: 
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("<!!!Error!!!>" + msg);
					break;
			}
		}
	}
}
