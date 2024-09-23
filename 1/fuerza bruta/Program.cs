using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] array = { 8, 6, 4, 2, 1, 4, 7, 10, 2 }; // 3

        var coverings = FindCoverings(array);

        foreach (var covering in coverings)
        {
            Console.WriteLine("[" + string.Join(", ", covering.Select(sublist => "[" + string.Join(", ", sublist) + "]")) + "]");
        }

        var smallestCovering = coverings.OrderBy(c => c.Count).First();
        Console.WriteLine("\nLa lista de menor tamaño es:");
        Console.WriteLine("[" + string.Join(", ", smallestCovering.Select(sublist => "[" + string.Join(", ", sublist) + "]")) + "]");
        Console.WriteLine("\nLa menor cantidad de progresiones aritméticas que cubren el array son: " + smallestCovering.Count);
    }

     static List<List<List<int>>> FindCoverings(int[] array)
    {
        List<List<List<int>>> result = new List<List<List<int>>>();
        FindCoveringsRecursive(array, 0, new List<List<int>>(), result);
        return result;
    }
    static void FindCoveringsRecursive(int[] array, int startIndex, List<List<int>> currentCovering, List<List<List<int>>> result)
    {
        if (startIndex >= array.Length)
        {
            result.Add(new List<List<int>>(currentCovering));
            return;
        }

        for (int endIndex = startIndex; endIndex < array.Length; endIndex++)
        {
            List<int> subarray = new List<int>();
            for (int i = startIndex; i <= endIndex; i++)
            {
                subarray.Add(array[i]);
            }

            if (IsValidArithmeticProgression(subarray))
            {
                currentCovering.Add(subarray);
                FindCoveringsRecursive(array, endIndex + 1, currentCovering, result);
                currentCovering.RemoveAt(currentCovering.Count - 1); 
            }
        }
    }

    static bool IsValidArithmeticProgression(List<int> progression)
    {
        if (progression.Count < 2) return true;

        int diff = progression[1] - progression[0];

        for (int i = 2; i < progression.Count; i++)
        {
            if (progression[i] - progression[i - 1] != diff)
            {
                return false;
            }
        }

        return true;
    }
}
