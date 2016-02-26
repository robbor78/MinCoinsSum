using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinCoinsSum;

namespace UnitTestProject1
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {
      int[][] allCoins = new int[][]
      {
        new int [] { 1,3,5},
        new int [] { 5,10,20,50},

      };

      int[] allSums = new int[] { 11, 7 };

      int[] allMinSums = new int[] { 3, -1 };

      Program p = new Program();
      int length = allCoins.Length;
      for (int i = 0; i < length; i++)
      {
        int[] coins = allCoins[i];
        int sum = allSums[i];

        int actual = p.findMinCoinsSum2(coins, sum);

        int expected = allMinSums[i];

        Assert.AreEqual(expected, actual);
      }
    }
  }
}
