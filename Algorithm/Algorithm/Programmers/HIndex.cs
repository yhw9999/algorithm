using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Programmers
{
	class HIndex : ICommand
	{
		public void Execute()
		{
			Console.WriteLine(solution(new int[] { 3, 0, 6, 1, 5 }));
			Console.WriteLine(solution(new int[] { 12, 11, 10, 9, 8, 1 }));
			Console.WriteLine(solution(new int[] { 6, 6, 6, 6, 6, 1 }));
			Console.WriteLine(solution(new int[] { 4, 4, 4 }));
			Console.WriteLine(solution(new int[] {0,0,1,1 }));
			Console.WriteLine(solution(new int[] {0,1 }));
		}

		public int solution(int[] citations)
		{
			int answer = 0;

			var grouped = citations.GroupBy(x => x);

			var sorted = grouped.OrderByDescending(x=>x.Key);
			var queue = new Queue<IGrouping<int, int>>(sorted);

			var mention = 0;
			for (int i = citations.Length; i > 0; i--)
			{
				while (queue.Peek().Key >= i)
				{
					var citation = queue.Dequeue();

					mention += citation.Count();

					if (!queue.Any())
					{
						answer = mention;
						break;
					}
				}

				if (mention >= i)
				{
					answer = i;
					break;
				}
			}

			return answer;
		}
	}
}
