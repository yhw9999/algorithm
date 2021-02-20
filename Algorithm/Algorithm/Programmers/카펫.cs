using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Programmers
{
	class 카펫 : ICommand
	{
		public void Execute()
		{
			var result1 = solution(10, 2);
			Console.WriteLine($"{result1[0]}, {result1[1]}");
			var result2 = solution(8, 1);
			Console.WriteLine($"{result2[0]}, {result2[1]}");
			var result3 = solution(24, 24);
			Console.WriteLine($"{result3[0]}, {result3[1]}");
		}

		public int[] solution(int brown, int yellow)
		{
			var total = brown + yellow;

			var vertical = 3;

			while (true)
			{
				if (total % vertical == 0)
				{
					var horizontal = total / vertical;

					if ((vertical - 2) * (horizontal - 2) == yellow
						&& horizontal * vertical - yellow == brown)
					{
						return new int[] {horizontal, vertical };
					}
				}

				vertical++;
			}
		}
	}
}
