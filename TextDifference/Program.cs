
using TextDifference.Core;

if (args.Length != 2)
{
    Console.WriteLine("Usage: TextDiff <file_a> <file_b>");
    return;
}

List<string> fileA = FileReader.ReadFile(args[0]);
List<string> fileB = FileReader.ReadFile(args[1]);

TextDiff.PrintDifferences(fileA, fileB);