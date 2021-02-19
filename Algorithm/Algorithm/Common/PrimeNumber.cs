using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Common
{
	class PrimeNumber
	{
		public static HashSet<int> GetPrimeNumbers(int size)
		{
			var set = new HashSet<int>();

			if (size < 2)
			{
				return set;
			}

			for (int i = 2; i <= size; i++)
			{
				set.Add(i);
			}

			for (int i = 2; i < Math.Sqrt(size); i++)
			{
				var multiple = 2;
				var value = 0;

				while(value <= size)
				{
					value = i * multiple++;

					if (set.Contains(value))
					{
						set.Remove(value);
					}
				}
			}

			return set;
		}
	}
}
