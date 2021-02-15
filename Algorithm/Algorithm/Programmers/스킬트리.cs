using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Programmers
{
	class 스킬트리 : ICommand
	{
		public void Execute()
		{
			Console.WriteLine(solution("CBD", new string[] { "BACDE", "CBADF", "AECB", "BDA" }));
		}

		public int solution(string skill, string[] skill_trees)
		{
			int answer = 0;

			foreach (var skill_tree in skill_trees)
			{
				var skillQueue = new Queue<char>(skill);
				var treeQueue = new Queue<char>(skill_tree);

				if (CheckValidTree(skillQueue, treeQueue))
				{
					answer++;
				}
			}

			return answer;
		}

		private bool CheckValidTree(Queue<char> skillQueue, Queue<char> treeQueue)
		{
			while (treeQueue.Any())
			{
				var currentSkill = treeQueue.Dequeue();

				if (skillQueue.Contains(currentSkill))
				{
					if (skillQueue.Peek() == currentSkill)
					{
						skillQueue.Dequeue();
					}
					else
					{
						return false;
					}
				}
			}

			return true;
		}
	}
}
