namespace TextDifference.Core;
public class TextDiff
{
    public static void PrintDifferences(List<string> fileA, List<string> fileB)
    {
        List<string> lcs = LCS.ReconstructElements(LCS.LcsTable(fileA, fileB), fileA, fileB);

        int lineA = 0, lineB = 0;
        foreach (var line in lcs)
        {
            while (!fileA[lineA].Equals(line))
            {
                Console.WriteLine("- " + fileA[lineA]);
                lineA++;
            }
            while (!fileB[lineB].Equals(line))
            {
                Console.WriteLine("+ " + fileB[lineB]);
                lineB++;
            }

            Console.WriteLine("  " + fileA[lineA]);
            lineA++;
            lineB++;
        }

        while (lineA < fileA.Count)
        {
            Console.WriteLine("- " + fileA[lineA]);
            lineA++;
        }

        while (lineB < fileB.Count)
        {
            Console.WriteLine("+ " + fileB[lineB]);
            lineB++;
        }
    }

}