using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Programmers
{
	class 삼각달팽이 : ICommand
	{
		enum Direction
		{
			Down = 1,
			Right,
			LeftUp
		}

		public void Execute()
		{
			foreach (var item in solution(4))
			{
				Console.Write($"{item} ");
			}
			Console.WriteLine();
			foreach (var item in solution(5))
			{
				Console.Write($"{item} ");
			}
			Console.WriteLine();
			foreach (var item in solution(6))
			{
				Console.Write($"{item} ");
			}
			Console.WriteLine();
		}

		public int[] solution(int n)
		{
			var jaggedArray = new int[n][];
			var directionQueue = new Queue<Direction>();
			directionQueue.Enqueue(Direction.Down);
			directionQueue.Enqueue(Direction.Right);
			directionQueue.Enqueue(Direction.LeftUp);

			for (int i = 1; i <= jaggedArray.Length; i++)
			{
				jaggedArray[i - 1] = new int[i];
			}

			var number = 1;
			var nextLocation = new Point(0, 0);
			var currentDirection = directionQueue.Peek();
			var currentStep = 0;
			while (n > 0)
			{
				jaggedArray[nextLocation.Y][nextLocation.X] = number++;

				currentStep++;

				if (currentStep >= n)
				{
					n--;
					currentStep = 0;

					directionQueue.Enqueue(directionQueue.Dequeue());

					currentDirection = directionQueue.Peek();
				}

				nextLocation = nextLocation.GetNext(currentDirection);
			}

			var result = new List<int>();
			foreach (var array in jaggedArray)
			{
				foreach (var item in array)
				{
					result.Add(item);
				}
			}

			return result.ToArray();
		}

		struct Point
		{
			public Point(int x, int y)
			{
				X = x;
				Y = y;
			}

			public int X { get; set; }
			public int Y { get; set; }

			internal Point GetNext(Direction diretion)
			{
				switch (diretion)
				{
					case Direction.Down:
						this.Y += 1;
						break;
					case Direction.Right:
						this.X += 1;
						break;
					case Direction.LeftUp:
						this.X -= 1;
						this.Y -= 1;
						break;
				}

				return this;
			}
		}
	}
}
