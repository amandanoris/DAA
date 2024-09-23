using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = ReadVector(n);
        
        int res = 0;
        for (int l = 0; l < n;)
        {
            res++;

            int i1 = l;
            while (i1 < n && a[i1] == -1) i1++;

            if (i1 == n) break; // no hay más elementos fijos

            int i2 = i1 + 1;
            while (i2 < n && a[i2] == -1) i2++;

            if (i2 == n) break; // solo hay un elemento fijo

            int dist = i2 - i1;
            if ((a[i2] - a[i1]) % dist != 0)
            {
                l = i2;
                continue;
            }

            long step = (a[i2] - a[i1]) / dist;
            if (step > 0 && a[i1] - step * (i1 - l) <= 0)
            {
                l = i2;
                continue;
            }

            int r = i2 + 1;
            while (r < n)
            {
                long expectedValue = a[i2] + step * (r - i2);

                if (a[r] != -1 && a[r] != expectedValue) break;
                if (expectedValue <= 0) break;
                r++;
            }
            l = r;
        }
        
        Console.WriteLine(res);
    }

    static List<long> ReadVector(int n)
    {
        var res = new List<long>();
        string[] inputs = Console.ReadLine().Split();
        for (int i = 0; i < n; i++)
        {
            res.Add(long.Parse(inputs[i]));
        }
        return res;
    }
}
