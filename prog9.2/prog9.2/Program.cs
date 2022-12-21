using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog9._2
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				string[] lines = File.ReadAllLines("text.txt", Encoding.GetEncoding(1251));
				int n = 0;
				while (n < lines.Length)
				{
					Console.WriteLine(lines[n]);
					n += 2;
				}
				Console.ReadKey();
			}
			catch
			{
				Console.WriteLine("Неверно заполнен файл");
			}

		}
	}
}
