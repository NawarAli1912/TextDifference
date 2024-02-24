namespace TextDifference.Core;
public class LCS
{
    public static int[,] LcsTable<T>(List<T> a, List<T> b)
    {
        int[,] dp = new int[a.Count + 1, b.Count + 1];

        for (int i = 1; i <= a.Count; i++)
        {
            for (int j = 1; j <= b.Count; j++)
            {
                if (EqualityComparer<T>.Default.Equals(a[i - 1], b[j - 1]))
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }
        return dp;
    }

    public static List<T> ReconstructElements<T>(int[,] dp, List<T> a, List<T> b)
    {
        List<T> elements = [];
        int n = a.Count, m = b.Count;

        while (n > 0 && m > 0)
        {
            if (EqualityComparer<T>.Default.Equals(a[n - 1], b[m - 1]))
            {
                elements.Add(a[n - 1]);
                n--; m--;
            }
            else if (dp[n - 1, m] > dp[n, m - 1])
                n--;
            else
                m--;
        }

        elements.Reverse();
        return elements;
    }
}
