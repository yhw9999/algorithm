using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Programmers
{
	class 다리를지나는트럭 : ICommand
	{
		public void Execute()
		{
			Console.WriteLine(solution(2, 10, new int[] { 7, 4, 5, 6 }));
			Console.WriteLine(solution(100, 100, new int[] { 10}));
			Console.WriteLine(solution(100, 100, new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }));
		}

		public int solution(int bridge_length, int weight, int[] truck_weights)
		{
			var trucks = new Queue<Truck>();

			for (int i = 0; i < truck_weights.Length; i++)
			{
				trucks.Enqueue(new Truck(bridge_length, truck_weights[i]));
			}

			var passingTrucks = new Queue<Truck>();

			var currentWeight = 0;
			var pastTime = 0;

			while (trucks.Count != 0 || passingTrucks.Count != 0)
			{
				while (trucks.Count != 0 && currentWeight + trucks.Peek().Weight <= weight)
				{
					var startedTruck = trucks.Dequeue();
					currentWeight += startedTruck.Weight;

					passingTrucks.Enqueue(startedTruck);

					foreach (var truck in passingTrucks)
					{
						truck.RemainLength -= 1;
					}

					pastTime++;
					Log("Enqueue", pastTime, currentWeight, passingTrucks, trucks);
				}

				while (passingTrucks.Count != 0)
				{
					var head = passingTrucks.Peek();

					if (head.RemainLength <= 0)
					{
						passingTrucks.Dequeue();
						currentWeight -= head.Weight;
						break;
					}

					pastTime++;
					Log("Dequeue", pastTime, currentWeight, passingTrucks, trucks);

					foreach (var truck in passingTrucks)
					{
						truck.RemainLength -= 1;
					}
				}
			}

			pastTime++;

			return pastTime;
		}

		private void Log(string v, int pastTime, int currentWeight, Queue<Truck> passingTrucks, Queue<Truck> trucks)
		{
			Console.WriteLine($"--------------------{v}---------------------------");
			Console.WriteLine($"TimeInfo : {pastTime} : {currentWeight}");

			Console.WriteLine("Passing!!!");
			foreach (var truck in passingTrucks)
			{
				truck.ShowInfo();
			}

			Console.WriteLine("Waiting!!!");
			foreach (var truck in trucks)
			{
				truck.ShowInfo();
			}
		}

		class Truck
		{
			public Truck(int remainLength, int weight)
			{
				RemainLength = remainLength;
				Weight = weight;
			}

			public int RemainLength { get; set; }
			public int Weight { get; set; }

			internal void ShowInfo()
			{
				Console.WriteLine($"{Weight} - {RemainLength}");
			}
		}
	}
}
