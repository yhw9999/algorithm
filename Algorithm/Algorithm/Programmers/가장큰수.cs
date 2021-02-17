using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Programmers
{
	class 가장큰수 : ICommand
	{
		public void Execute()
		{
			Console.WriteLine(solution(new int[] { 6, 10, 2 }));
			Console.WriteLine(solution(new int[] { 3, 30, 34, 5, 9 }));
		}

		public string solution(int[] numbers)
        {
            var descended = numbers.OrderBy(x => x, new StringComparer());

            var sb = new StringBuilder();

            foreach (var item in descended)
            {
                if (sb.Length > 0 && sb[0] == '0')
                {
                    continue;
                }

                sb.Append(item);
            }

            return sb.ToString();
        }


    }

    internal class StringComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            var xy = 0;
            var yx = 0;

            if ((int)Math.Log10(x) + 1 != (int)Math.Log10(y) + 1)
            {
                var xString = x.ToString();
                var yString = y.ToString();

                xy = int.Parse(xString + yString);
                yx = int.Parse(yString + xString);
            }
            else
            {
                xy = int.Parse(GetPaddedString(x));
                yx = int.Parse(GetPaddedString(y));
            }

            if (xy > yx)
            {
                return -1;
            }
            else if (yx > xy)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private string GetPaddedString(int x)
        {
            var toString = x.ToString();

            var appendIndex = 0;

            while (toString.Length < 5 - 1)
            {
                toString += toString[appendIndex];
            }

            return toString;
        }
    }

}
