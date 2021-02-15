using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Programmers
{
	class 기능개발 : ICommand
	{
		public int[] solution(int[] progresses, int[] speeds)
		{
			var issues = new Queue<Issue>();

			for (int i = 0; i < progresses.Length; i++)
			{
				issues.Enqueue(new Issue(progresses[i], speeds[i]));
			}
			var days = 1;

			var result = new List<int>();

			do
			{
				var doneCount = 0;

				while (issues.Count != 0)
				{
					var peek = issues.Peek();

					if (peek.IsDone(days))
					{
						doneCount++;
						issues.Dequeue();
					}
					else
					{
						days++;
						
						break;
					}
				}

				if (doneCount != 0)
				{
					result.Add(doneCount);
				}

			} while (issues.Count != 0);

			foreach (var item in result)
			{
				Console.Write(item + " ");
			}

			Console.WriteLine();

			return result.ToArray();
		}

		public void Execute()
		{
			new 기능개발().solution(new int[] { 93, 30, 55 }, new int[] { 1, 30, 5 });
			new 기능개발().solution(new int[] { 95, 90, 99, 99, 80, 99 }, new int[] { 1, 1, 1, 1, 1, 1 });
		}

		class Issue
		{
			public Issue(int progress, int speed)
			{
				Progress = progress;
				Speed = speed;
			}

			public int Progress { get; set; }
			public int Speed { get; set; }

			internal bool IsDone(int days)
			{
				if ((days * Speed + Progress) >= 100)
				{
					return true;
				}

				return false;
			}
		}
	}


}
