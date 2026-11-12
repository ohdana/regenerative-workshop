using System.Text;

namespace WordWrap;

public static class WordWrapper
{
    /// <summary>
    /// Wraps <paramref name="text"/> so that no line is longer than <paramref name="width"/>
    /// characters (inventory.md items 1-8):
    /// a word longer than the width gets a line of its own; runs of spaces collapse to one;
    /// spaces at line ends are removed; line breaks split the text into paragraphs, with
    /// neighbouring breaks collapsed and leading/trailing ones removed.
    /// </summary>
    public static string Wrap(string text, int width)
    {
        ArgumentNullException.ThrowIfNull(text);
        if (width <= 0)
            throw new ArgumentOutOfRangeException(nameof(width), width, "Width must be greater than 0.");

        var paragraphs = text.Replace("\r\n", "\n")
            .Split('\n')
            .Select(p => p.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .Where(words => words.Length > 0)
            .Select(words => WrapParagraph(words, width));

        return string.Join('\n', paragraphs);
    }

    private static string WrapParagraph(string[] words, int width)
    {
        var output = new StringBuilder(words[0]);
        int lineLength = words[0].Length;

        foreach (var word in words.Skip(1))
        {
            if (lineLength + 1 + word.Length <= width)
            {
                output.Append(' ');
                lineLength += 1 + word.Length;
            }
            else
            {
                output.Append('\n');
                lineLength = word.Length;
            }
            output.Append(word);
        }
        return output.ToString();
    }
}
