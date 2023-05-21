namespace DebugLinq;

public class Program
{
    static readonly string[] Words = new string[] { "   KOOKABURRA", "Frogmouth", "kingfisher   ", "loon", "merganser" };
    static void Main(string[] args)
    {
        var newWords = ProcessWordList3(Words);

        foreach (var word in newWords)
        {
            Console.WriteLine(word);
        }
    }

    private static IEnumerable<string> ProcessWordList1(string[] words)
    {
        return words
            .Select(w => w.Trim())
            .Select(w => w.ToLower())
            .Where(w => w.StartsWith("k"))
            .OrderBy(w => w);
    }

    private static IEnumerable<string> ProcessWordList2(string[] words)
    {
        EnumerableDebugger.ShowWhiteSpace = true;

        return words
            .Dump()
            .Select(w => w.Trim())
            .Dump()
            .Select(w => w.ToLower())
            .Dump()
            .Where(w => w.StartsWith("k"))
            .Dump()
            .OrderBy(w => w)
            .Dump();
    }

    private static IEnumerable<string> ProcessWordList3(string[] words)
    {
        EnumerableDebugger.ShowWhiteSpace = true;

        return words
            .Dump(w => "ORIGINAL: " + w, ConsoleColor.Yellow)
            .Select(w => w.Trim())
            .Dump(w => "TRIMMED: " + w, ConsoleColor.Yellow)
            .Select(w => w.ToLower())
            .Dump(w => "LOWERCASE: " + w, ConsoleColor.Green)
            .Where(w => w.StartsWith("k"))
            .Dump(w => "FILTERD: " + w, ConsoleColor.Red)
            .OrderBy(w => w)
            .Dump(w => "SORTED: " + w, ConsoleColor.Blue);
    }
}