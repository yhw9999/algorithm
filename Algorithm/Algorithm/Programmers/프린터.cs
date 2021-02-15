using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Programmers
{
	class 프린터 : ICommand
	{
		public void Execute()
		{
			Console.WriteLine(solution(new int[] { 2, 1, 3, 2 }, 2));
			Console.WriteLine(solution(new int[] { 1, 1, 9, 1, 1, 1 }, 0));
		}

		public int solution(int[] priorities, int location)
		{
			var printJobs = new Queue<Printing>();

			for (int i = 0; i < priorities.Length; i++)
			{
				var printing = default(Printing);

				if (i == location)
				{
					printing = new Printing(true, priorities[i]);
				}
				else
				{
					printing = new Printing(false, priorities[i]);
				}

				printJobs.Enqueue(printing);
			}

			var printCount = 1;

			while (true)
			{
				var currentJob = printJobs.Dequeue();

				if (printJobs.Any(x=> currentJob.Priority < x.Priority))
				{
					printJobs.Enqueue(currentJob);
					continue;
				}
				else
				{
					if (currentJob.IsOrdered)
					{
						return printCount;
					}

					printCount++;
				}
			}
		}

		class Printing
		{
			public Printing(bool isOrdered, int priority)
			{
				this.IsOrdered = isOrdered;
				this.Priority = priority;
			}

			public bool IsOrdered { get; private set; }
			public int Priority { get; private set; }
		}
	}
}
