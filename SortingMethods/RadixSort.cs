using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingMethods
{
	public class RadixSort : ISorter
	{
		public IEnumerable<uint> Sort(IEnumerable<uint> list)
		{
			if (list == null)
			{
				throw new ArgumentNullException(nameof(list));
			}

			if (!list.Any())
			{
				return new uint[] {};
			}

			uint k = (uint)Math.Floor(Math.Log10(list.Max()) + 1); // Determine max number of digits k

			IEnumerable<uint> currentRadixNumbers = list;
			List<uint>[] pockets = new List<uint>[10];  // Simplified to 10 reserved digits 0-9; instead on each pass we could compute number of distinct digits within current radix
			uint powerOfTen = 1; // 10^0
			for (uint i = 1; i <= k; i++)
			{
				foreach (var number in currentRadixNumbers)
				{
					long radixDigit = (long)Math.Floor((decimal) number / powerOfTen) % 10;
					if (pockets[(int)radixDigit] == null)
					{
						pockets[(int)radixDigit] = new List<uint>();
					}
					pockets[(int)radixDigit].Add(number);
				}

				powerOfTen *= 10;

				currentRadixNumbers = Flatten(pockets).ToList();

				// Cleanup list
				foreach (var pocket in pockets)
				{
					if (pocket != null)
					{
						pocket.Clear();
					}
				}
			}

			return currentRadixNumbers;
		}

		private IEnumerable<uint> Flatten(List<uint>[] pockets)
		{
			foreach (var pocket in pockets)
			{
				if (pocket != null)
				{
					foreach (var val in pocket)
					{
						yield return val;
					}
				}
			}
		}
	}
}
