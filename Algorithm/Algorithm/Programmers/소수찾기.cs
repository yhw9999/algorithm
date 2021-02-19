using Algorithm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Programmers
{
	class 소수찾기 : ICommand
	{
		public void Execute()
		{
			Console.WriteLine(solution("17"));
			Console.WriteLine(solution("011"));
		}

		public int solution(string numbers)
		{
			var primeNumberSize = string.Empty.PadRight(numbers.Length, '9');

			var primeNumbers = PrimeNumber.GetPrimeNumbers(int.Parse(primeNumberSize));

			var madenNumbers = new HashSet<int>();
			var characters = new List<char>(numbers);

			Genarate(characters, madenNumbers, string.Empty);

			return madenNumbers.Where(x=> primeNumbers.Contains(x)).Count();
		}

		private void Genarate(List<char> characters, HashSet<int> madenNumbers, string frontNumber)
		{
			for (int i = 0; i < characters.Count; i++)
			{
				var currentCharacter = characters[i];
				var tempCharacters = new List<char>(characters);

				tempCharacters.RemoveAt(i);

				var appendedNumber = frontNumber + currentCharacter;

				var newNumber = int.Parse(appendedNumber);

				madenNumbers.Add(newNumber);

				Genarate(tempCharacters, madenNumbers, appendedNumber);
			}
		}
	}
}
