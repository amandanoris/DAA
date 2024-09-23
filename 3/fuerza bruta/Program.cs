using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var strings = new List<string> { "abc", "bca", "cab" };
        var strings2 = new List<string> { "a", "b", "c" };
        var strings3 = new List<string> { "abc", "def" };
        var strings4 = new List<string> { "abcd", "cdef", "efgh" };
        var strings5 = new List<string> { "abc", "cdef", "ef" };
        var strings6 = new List<string> { "single" };
        var strings8 = new List<string> { "repeat", "repeat", "repeat" };


        string result = ShortestCommonSuperstring(strings8);
        Console.WriteLine(result);
    }

    public static string ShortestCommonSuperstring(List<string> strings)
    {
        var permutations = GetPermutations(strings);

        string shortestSuperstring = null;

        foreach (var perm in permutations)
        {
            string currentSCS = BuildSCS(perm);
            if (shortestSuperstring == null || currentSCS.Length < shortestSuperstring.Length)
            {
                shortestSuperstring = currentSCS;
            }
        }

        return shortestSuperstring;
    }

    static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list)
    {
        if (list.Count() == 1)
            return new List<IEnumerable<T>> { list };

        return list.SelectMany((item, index) => 
            GetPermutations(list.Where((_, i) => i != index))
            .Select(perm => new[] { item }.Concat(perm)));
    }
    static string BuildSCS(IEnumerable<string> strings)
    {
        string result = strings.First();

        foreach (var str in strings.Skip(1))
        {
            result = MergeStrings(result, str);
        }

        return result;
    }

    static string MergeStrings(string a, string b)
    {
        int maxOverlap = 0;

        for (int i = 1; i <= Math.Min(a.Length, b.Length); i++)
        {
            if (a.EndsWith(b.Substring(0, i)))
            {
                maxOverlap = i;
            }
        }

        return a + b.Substring(maxOverlap);
    }
}
