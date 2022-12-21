using System;
using System.IO;
using System.Globalization;
using System.Text;

namespace prog9._1
{
	class Program
	{
		public static int readInt()
		{
			do
			{
				int res;
				bool par = int.TryParse(Console.ReadLine(), out res);
				if (par) return res;
				else Console.WriteLine("Введите корректное число:");
			} while (true);
		}
		public static double readDouble()
		{
			do
			{
				double res;
				bool par = double.TryParse(Console.ReadLine(), out res);
				if (par) return res;
				else Console.WriteLine("Введите корректное число:");
			} while (true);
		}
		static void Main(string[] args)
		{
			try
			{
				int n;
				double b;
				n1: Console.Write("Введите последовательность чисел n: ");
				n = readInt();
				if (n <= 1) { Console.WriteLine("n не должно быть меньше 2"); goto n1; }
				Console.Write("Введите число от которого будут вычисляться строки: ");
				b = readDouble();
				FileStream f = new FileStream("t.dat", FileMode.OpenOrCreate);
				BinaryWriter fOut = new BinaryWriter(f);
				for (double i = 0; i < n; i++)
				{
					Console.Write("Число {0}: ", i + 1);
					double temp = double.Parse(Console.ReadLine());
					fOut.Write(temp); ;
				}
				fOut.Close();
				f = new FileStream("t.dat", FileMode.Open);
				BinaryReader fIn = new BinaryReader(f);
				long m = f.Length;
				using(StreamWriter sw = new StreamWriter(File.Open("text.txt", FileMode.Create), Encoding.UTF8))
				{
					for (long i = 0; i < m; i += 16)
					{
						f.Seek(i, SeekOrigin.Begin);
						double a = fIn.ReadDouble();
						if (a > b) Console.Write("{0:f2} ", a);
						if (a > b) sw.Write(a + "\n");

					}
				}
				fIn.Close();
				f.Close();

			}
			catch(FormatException)
			{
				Console.WriteLine("Введите корректное число");
			}
			catch
			{
				Console.WriteLine("Ошибка ввода данных");
			}
		}
	}
}
