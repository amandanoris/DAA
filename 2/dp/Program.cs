using System;

class Program
{
    const int MOD = 998244353;
    static int[,,] dp = new int[1005, 2005, 4];

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        dp[1, 1, 0] = 1; // WW
        dp[1, 2, 1] = 1; // WB
        dp[1, 2, 2] = 1; // BW
        dp[1, 1, 3] = 1; // BB

        for (int i = 2; i <= n; ++i)
        {
            for (int j = 1; j <= i * 2; ++j)
            {
                dp[i, j, 0] = (dp[i - 1, j, 0] + dp[i - 1, j, 1] + dp[i - 1, j, 2] + dp[i - 1, j - 1, 3]) % MOD;
                dp[i, j, 1] = (dp[i - 1, j - 1, 0] + dp[i - 1, j, 1] + dp[i - 1, j - 2, 2] + dp[i - 1, j - 1, 3]) % MOD;
                dp[i, j, 2] = (dp[i - 1, j - 1, 0] + dp[i - 1, j - 2, 1] + dp[i - 1, j, 2] + dp[i - 1, j - 1, 3]) % MOD;
                dp[i, j, 3] = (dp[i - 1, j - 1, 0] + dp[i - 1, j, 1] + dp[i - 1, j, 2] + dp[i - 1, j, 3]) % MOD;
            }
        }

        int result = (dp[n, k, 0] + dp[n, k, 1] + dp[n, k, 2] + dp[n, k, 3]) % MOD;
        Console.WriteLine(result);
    }
}
