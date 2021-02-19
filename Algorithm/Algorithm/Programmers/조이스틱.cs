using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Programmers
{
	//72.7점....
	class 조이스틱 : ICommand
	{
		public void Execute()
		{
			//Console.WriteLine(solution("JAZ"));
			//Console.WriteLine(solution("JEROEN"));
			//Console.WriteLine(solution("JAN"));
			//Console.WriteLine(solution("AAAAA"));
			//Console.WriteLine(solution("ZZZZ"));
			//Console.WriteLine(solution("AZZAAAAAAAZ"));

		}

		public int solution(string name)
		{
			var costs = name.Select(x => x-'A').ToArray();
			var totalCost = costs.Sum();
			var answer = 0;
			var cursor = 0;

			while (totalCost != 0)
			{ 
				var currentCost = costs[cursor];
				if (currentCost != 0)
				{
					answer += GetMinimumCharacterMove(currentCost);
					totalCost -= currentCost;
					costs[cursor] = 0;
				}

				if (totalCost == 0)
				{
					break;
				}

				var cursorGap = 0;
				var nextCursor = GetNextCursor(costs, cursor, ref cursorGap);

				if (cursor != nextCursor)
				{
					answer += cursorGap;
					cursor = nextCursor;
				}
			}
			return answer;
		}

		private int GetMinimumCharacterMove(int currentCost)
		{
			//A = 0, Z = 25

			if (currentCost < 12)
			{
				return currentCost;
			}
			else
			{
				return 26 - currentCost;
			}
		}

		private int GetNextCursor(int[] costs, int cursor, ref int cursorGap)
		{
			var left = 0;
			var leftGap = 0;
			var right = 0;
			var rightGap = 0;

			var moveCount = 0;

			while (moveCount < costs.Length)
			{
				var nextLeft = (costs.Length + cursor - ++moveCount) % costs.Length;

				if (costs[nextLeft] != 0)
				{
					left = nextLeft;
					leftGap = moveCount;
					break;
				}
			}

			moveCount = 0;

			while (moveCount < costs.Length)
			{
				var nextRight = (costs.Length + cursor + ++moveCount) % costs.Length;

				if (costs[nextRight] != 0)
				{
					right = nextRight;
					rightGap = moveCount;
					break;
				}
			}

			if (leftGap > rightGap)
			{
				cursorGap = rightGap;
				return right;
			}
			else
			{
				cursorGap = leftGap;
				return left;
			}
		}
	}
}
