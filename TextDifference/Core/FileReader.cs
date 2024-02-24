namespace TextDifference.Core;
public static class FileReader
{
    public static List<string> ReadFile(string filename)
    {
        List<string> lines = [];

        try
        {
            using StreamReader sr = new(filename);
            string line;
            while ((line = sr.ReadLine()) is not null)
            {
                lines.Add(line);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Error reading file: " + e.Message);
        }

        return lines;
    }
}
