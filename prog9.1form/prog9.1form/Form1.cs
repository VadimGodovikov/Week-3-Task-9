using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prog9._1form
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void ButtonResult_Click(object sender, EventArgs e)
		{
			string[] strs = textBox1.Text.Split(' ');

			List<double> numbers = new List<double>();

			try
			{
				foreach (string s in strs)
					numbers.Add(double.Parse(s));
			}
			catch
			{
				MessageBox.Show("Ожидается ввод вещественных чисел в поле!", "Ошибка");
				return;
			}

			double n = double.Parse(numericUpDown1.Text);

			FileStream f = new FileStream("t.dat", FileMode.OpenOrCreate);
			BinaryWriter fOut = new BinaryWriter(f);

			for (int i = 0; i < strs.Length; i++)
			{
				double temp = double.Parse(strs[i]);
				fOut.Write(temp);
			}
			fOut.Close();
			textBox2.Text = "Результат программы: " + Environment.NewLine;
			f = new FileStream("t.dat", FileMode.Open);
			BinaryReader fIn = new BinaryReader(f);
			long m = f.Length;
			using (StreamWriter sw = new StreamWriter(File.Open("text.txt", FileMode.Create), Encoding.UTF8))
			{
				for (long i = 0; i < m; i += 16)
				{
					f.Seek(i, SeekOrigin.Begin);
					double a = fIn.ReadDouble();
					if (a > n) textBox2.Text += $"{a:f2} " + Environment.NewLine;
					if (a > n) sw.Write(a + "\n");

				}
			}
			fIn.Close();
			f.Close();

		}
	}
}
