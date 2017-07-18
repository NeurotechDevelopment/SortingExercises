using System.Collections.Generic;

namespace SortingMethods
{
	public interface ISorter
	{
		/// <summary>
		/// Sorts items in ascending order.
		/// </summary>
		/// <param name="list">Unordered collection of unsigned integers</param>
		/// <returns>New sorted collection of unsigned integers from <param name="list"></param></returns>
		IEnumerable<uint> Sort(IEnumerable<uint> list);
	}
}
