using System;

class Program
{
    const int MOD = 998244353;

    static int[,,] dp = new int[1000, 2 * 1000, 4];

    static int Add(int a, int b)
    {
        return (a + b) % MOD;
    }

    static bool Full(int mask)
    {
        return (mask == 0 || mask == 3);
    }

    static int Get(int mask, int mask2)
    {
        int cnt = BitCount(mask ^ mask2);
        if (cnt == 0) return 0;
        if (cnt == 2) return (Full(mask) ? 1 : 2);
        return (Full(mask) ? 0 : 1);
    }

    static int BitCount(int x)
    {
        int count = 0;
        while (x > 0)
        {
            count += (x & 1);
            x >>= 1;
        }
        return count;
    }

    static void Main()
    {
        int n, k;
        string[] input = Console.ReadLine().Split();
        n = int.Parse(input[0]);
        k = int.Parse(input[1]);
        
        for (int i = 0; i < 4; i++)
            dp[1, 0, i] = 1;

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j <= k; j++)
            {
                for (int mask = 0; mask < 4; mask++)
                {
                    for (int mask2 = 0; mask2 < 4; mask2++)
                    {
                        dp[i + 1, j + Get(mask, mask2), mask2] = Add(dp[i + 1, j + Get(mask, mask2), mask2], dp[i, j, mask]);
                    }
                }
            }
        }

        int ans = 0;
        for (int mask = 0; mask < 4; mask++)
        {
            int nw = Get(mask, mask ^ 3);
            if (k >= nw)
                ans = Add(ans, dp[n, k - nw, mask]);
        }

        Console.WriteLine(ans);
    }
}