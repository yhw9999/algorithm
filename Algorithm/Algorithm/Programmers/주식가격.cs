using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Programmers
{
	class 주식가격 : ICommand
	{
		public void Execute()
		{
			var result = solution(new int[] { 1, 2, 3, 2, 3 });
		}

		public int[] solution(int[] prices)
		{
			var checkPrices = new Queue<int>(prices);

			var index = 0;

			int[] answer = new int[prices.Length];

			while (checkPrices.Any())
			{
				var price = checkPrices.Dequeue();

				var stayCount = 0;

				foreach (var item in checkPrices)
				{
					stayCount++;

					if (price > item)
					{
						break;
					}
				}

				answer[index++] = stayCount;
			}

			return answer;
		}
	}
}
