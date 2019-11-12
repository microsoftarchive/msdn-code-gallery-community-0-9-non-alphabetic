using System;
using System.Collections.Generic;
using System.Linq;

namespace DividingCollection
{
	public static class Extensions
	{
		/// <summary>
		/// コレクションを指定した数のコレクションに分割します。
		/// </summary>
		/// <typeparam name="T">コレクションの要素の型。</typeparam>
		/// <param name="collection">分割するコレクション。</param>
		/// <param name="divisions">分割数。</param>
		/// <returns>分割した結果の新しい <see cref="IEnumerable{T}"/> 型のコレクションを列挙する列挙子。</returns>
		/// <exception cref="ArgumentNullException"><paramref name="collection"/> が null です。</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="divisions"/> が 0 以下です。</exception>
		public static IEnumerable<IEnumerable<T>> Divide<T>(this ICollection<T> collection, int divisions)
		{
			if (collection == null)
				throw new ArgumentNullException("collection");

			if (divisions <= 0)
				throw new ArgumentOutOfRangeException("divisions");

			int capacity = collection.Count / divisions;
			int remainder = collection.Count % divisions;

			using (var enumerator = collection.GetEnumerator())
			{
				for (int i = 0; i < remainder; i++)
					yield return Take(enumerator, capacity + 1);

				for (int i = remainder; i < divisions; i++)
					yield return Take(enumerator, capacity);
			}
		}

		private static IEnumerable<T> Take<T>(IEnumerator<T> enumerator, int count)
		{
			while (--count >= 0 && enumerator.MoveNext())
				yield return enumerator.Current;
		}
	}

	class Program
	{
		static void Main()
		{
			var mainSet = new HashSet<int>(Enumerable.Range(1, 10));

			Console.Write("Original collection : ");
			Console.WriteLine("{ " + string.Join(", ", mainSet) + " }");
			Console.WriteLine();

			var query = from sub in mainSet.Divide(3) select new HashSet<int>(sub);
			var subsets = query.ToArray();

			Console.WriteLine("Divides the collection into three collections.");
			Console.WriteLine();

			for (int i = 0; i < subsets.Length; i++)
			{
				Console.Write(i + 1);
				Console.Write(" : ");
				Console.WriteLine("{ " + string.Join(", ", subsets[i]) + " }");
			}
			Console.WriteLine();
		}
	}
}