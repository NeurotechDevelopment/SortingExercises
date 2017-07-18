using System;
using System.Collections.Generic;
using SortingMethods;

namespace SortingExercises
{
	class Program
	{
		static void Main(string[] args)
		{
			RadixSort radixSorter = new RadixSort();

			uint[] list = {1, 100,328, 3,76,499,0,14,12, 4294967295, 12, 54, 21};
			Console.Write("Initial list: ");
			WriteList(list);

			var sortedList = radixSorter.Sort(list);
			Console.Write("Ordered list: ");
			WriteList(sortedList);

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}

		private static void WriteList(IEnumerable<uint> list)
		{
			Console.WriteLine(string.Join(",", list));
		}
	}
}
