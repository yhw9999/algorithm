using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Programmers
{
	class 네트워크 : ICommand
	{
		public void Execute()
		{
			//Console.WriteLine(solution(3, new int[,] { {1, 1, 0 }, { 1, 1, 0}, { 0, 0, 1 } }));
			Console.WriteLine(solution(3, new int[,] { { 1, 1, 0 }, { 1, 1, 1}, { 0, 1, 1 } }));
		}

		public int solution(int n, int[,] computers)
		{
			int answer = 0;
			var size = (int)Math.Sqrt(computers.Length);
			var visited = new bool[size];

			for (int i = 0; i < size; i++)
			{
				if (!visited[i])
				{
					answer++;
					var queue = new Queue<int>(i);
					queue.Enqueue(i);
					Bfs(visited, computers, queue);
				}
			}

			return answer;
		}

		private void Bfs(bool[] visited, int[,] computers , Queue<int> queue)
		{
			while (queue.Count > 0)
			{
				var computer = queue.Dequeue();

				visited[computer] = true;

				for (int j = 0; j < visited.Length; j++)
				{
					if (computers[computer, j] == 1)
					{
						if (!visited[j])
						{
							queue.Enqueue(j);
						}
					}
				}
			}
		}
	}
}
