using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
	class Program
	{
		static void Main(string[] args)
		{
			TestDictionary();
			Console.ReadKey();
		}

		static void TestDictionary()
		{
			Console.WriteLine("test dictionary");
			NativeDictionary<int> dictionary = new NativeDictionary<int>(20);
			
			char s = 'a';
			for (int i = 0; i < 10; i++, s++)
				dictionary.Put(new string(s, 10), i + 10);

			foreach (string item in dictionary.slots)
				Console.WriteLine(item + " " + dictionary.Get(item));

			Console.WriteLine(new string('=', 50));

			Console.WriteLine();
			Console.WriteLine("put z string");
			dictionary.Put(new string('z', 10), 1000);

			foreach (string item in dictionary.slots)
				Console.WriteLine(item + " " + dictionary.Get(item));

			Console.WriteLine(new string('=', 50));

			Console.WriteLine();

			string key = new string('g', 10);
			Console.WriteLine("change value, key = " + new string('g', 10));
			Console.WriteLine("value before = " + dictionary.Get(key));
			dictionary.Put(key, 2000);

			foreach (string item in dictionary.slots)
				Console.WriteLine(item + " " + dictionary.Get(item));

			Console.WriteLine("find values test");
			

			Console.WriteLine(new string('=', 50));
		}
	}
}
