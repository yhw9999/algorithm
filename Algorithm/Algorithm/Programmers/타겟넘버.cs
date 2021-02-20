using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Programmers
{
	class 타겟넘버 : ICommand
	{
		public void Execute()
		{
			Console.WriteLine(solution(new int[] { 1,1,1,1,1},3));
		}

		public int solution(int[] numbers, int target)
		{
			int answer = 0;

			Calculate(numbers, 1, numbers[0], ref answer, target);
			Calculate(numbers, 1, -numbers[0], ref answer, target);

			return answer;
		}

		private void Calculate(int[] numbers, int index, int value, ref int count, int target)
		{
			if (index > numbers.Length - 1)
			{
				if (target == value)
				{
					count += 1;
				}
			}
			else
			{
				var number = numbers[index];

				Calculate(numbers, index + 1, value + number, ref count, target);
				Calculate(numbers, index + 1, value - number, ref count, target);
			}
		}
	}
}
