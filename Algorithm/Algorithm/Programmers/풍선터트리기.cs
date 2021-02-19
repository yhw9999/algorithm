using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Programmers
{
	class 풍선터트리기 : ICommand
	{
		public void Execute()
		{
			solution(new int[] { 9, -1, -5 });
			solution(new int[] { -16, 27, 65, -2, 58, -92, -71, -68, -61, -33 });
		}

		public int solution(int[] a)
		{
			int answer = 2;

			if (a.Length < 3)
			{
				return a.Length;
			}

			var rightValues = new HashSet<long>();

			for (int i = 1; i < a.Length; i++)
			{
				rightValues.Add(a[i]);
			}

			var sortedRights = new SortedSet<long>(rightValues);

			var leftMin = long.MaxValue;

			for (int i = 1; i < a.Length - 1; i++)
			{
				var value = a[i];

				if (leftMin > a[i-1])
				{
					leftMin = a[i - 1];
				}

				sortedRights.Remove(value);

				if (leftMin > value || sortedRights.Min > value)
				{
					answer++;
				}
			}

			return answer;
		}
	}
}
