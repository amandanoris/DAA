using System;

class Program
{
    const int MOD = 998244353;
    static int CountComponents(int[,] grid, int n)
    {
        bool[,] visited = new bool[2, n];
        int components = 0;

  
        void Dfs(int row, int col)
        {
            if (row < 0 || row >= 2 || col < 0 || col >= n || visited[row, col])
                return;
            visited[row, col] = true;

            if (row > 0 && grid[row, col] == grid[row - 1, col])
                Dfs(row - 1, col); // arriba
            if (row < 1 && grid[row, col] == grid[row + 1, col])
                Dfs(row + 1, col); // abajo
            if (col > 0 && grid[row, col] == grid[row, col - 1])
                Dfs(row, col - 1); // izquierda
            if (col < n - 1 && grid[row, col] == grid[row, col + 1])
                Dfs(row, col + 1); // derecha
        }

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (!visited[i, j])
                {
                    components++;
                    Dfs(i, j);
                }
            }
        }

        return components;
    }

    static int CountBeautifulBicolorings(int n, int k)
    {
        int total = 0;

      
        int totalConfigurations = 1 << (2 * n); 

        for (int mask = 0; mask < totalConfigurations; mask++)
        {

            int[,] grid = new int[2, n];
            for (int i = 0; i < n; i++)
            {
                
                grid[0, i] = (mask >> (2 * i)) & 1;
               
                grid[1, i] = (mask >> (2 * i + 1)) & 1;
            }

      
            int components = CountComponents(grid, n);

    
            if (components == k)
                total = (total + 1) % MOD;
        }

        return total;
    }

    static void Main()
    {
 
        
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int result = CountBeautifulBicolorings(n, k);
        Console.WriteLine(result);
    }
}
