using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCoinsSum
{
  /*
  https://www.topcoder.com/community/data-science/data-science-tutorials/dynamic-programming-from-novice-to-advanced/
    Given a list of N coins, their values (V1, V2, … , VN), and the total sum S.
  Find the minimum number of coins the sum of which is S 
  (we can use as many coins of one type as we want),
  or report that it’s not possible to select coins in such a way that they sum up to S.*/
  public class Program
  {
    static void Main(string[] args)
    {
    }

    /// <summary>
    /// Start with lowest state (0) and increment to desired state (sum).
    /// </summary>
    /// <param name="coins"></param>
    /// <param name="sum"></param>
    /// <returns></returns>
    public int findMinCoinsSum1(int[] coins, int sum)
    {
      /*Set Min[i] equal to Infinity for all of i
Min[0]=0

For i = 1 to S
For j = 0 to N - 1
   If (Vj<=i AND Min[i-Vj]+1<Min[i])
Then Min[i]=Min[i-Vj]+1

Output Min[S]*/

      long[] min = Enumerable.Repeat((long)int.MaxValue, sum + 1).ToArray();
      min[0] = 0;

      int numCoins = coins.Length;
      for (int i = 1; i <= sum; i++)
      {
        for (int j = 0; j < numCoins; j++)
        {
          int valuej = coins[j];
          if (valuej <= i && min[i - valuej] + 1 < min[i])
          {
            min[i] = min[i - valuej] + 1;
          }
        }
      }

      return min[sum] == int.MaxValue ? -1 : (int)min[sum];
    }

    /// <summary>
    /// Iteratively improve on existing solutions
    /// </summary>
    /// <returns></returns>
    public int findMinCoinsSum2(int[] coins, int sum)
    {
      long[] min = Enumerable.Repeat((long)int.MaxValue, sum + 1).ToArray();
      min[0] = 0; //first solution
      long maxValue = 0;

      bool isValueTooLarge = false;
      while (maxValue < sum && !isValueTooLarge)
      {
        long tmpMaxValue = maxValue;
        for (int c = 0; c < coins.Length; c++)
        {
          for (int m = 0; m <= tmpMaxValue; m++)
          {

            long value = coins[c] + m;
            if (value > sum)
            {
              isValueTooLarge = true;
              continue;
            }
            long currentMin = min[value];
            long possibleNewMin = min[m] + 1;
            if (currentMin > possibleNewMin)
            {
              min[value] = possibleNewMin;
              if (value > maxValue)
              {
                isValueTooLarge = false;
                maxValue = value;
              }
            }
          }
        }
      }

      return min[sum] == int.MaxValue ? -1 : (int)min[sum];
    }


  }
}
