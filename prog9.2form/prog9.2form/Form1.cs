using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prog9._2form
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				textBox1.Text = "Результат работы программы: \r\n";
				string[] lines = File.ReadAllLines("text.txt", Encoding.GetEncoding(1251));
				int n = 0;
				while (n < lines.Length)
				{
					textBox1.Text += lines[n] + "\r\n";
					n += 2;
				}
			}
			catch
			{
				Console.WriteLine("Вероятно не правильно введены данные в файл");
				return;
			}
		}
	}
}
