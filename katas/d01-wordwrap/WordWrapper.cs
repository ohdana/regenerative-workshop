using System.Text;

namespace WordWrap;

public static class WordWrapper
{
    /// <summary>
    /// Wraps <paramref name="text"/> so that no line is longer than <paramref name="width"/>.
    /// Breaks at spaces; a word longer than the width is split across lines.
    /// Existing line breaks (\n or \r\n) are kept, and runs of spaces collapse to one.
    /// </summary>
    public static string Wrap(string? text, int width)
    {
        if (width < 1)
            throw new ArgumentOutOfRangeException(nameof(width), width, "Width must be at least 1.");
        if (string.IsNullOrEmpty(text))
            return string.Empty;

        var output = new StringBuilder();
        var paragraphs = text.Replace("\r\n", "\n").Split('\n');
        for (int p = 0; p < paragraphs.Length; p++)
        {
            if (p > 0) output.Append('\n');
            WrapParagraph(paragraphs[p], width, output);
        }
        return output.ToString();
    }

    private static void WrapParagraph(string paragraph, int width, StringBuilder output)
    {
        int lineLength = 0;
        foreach (var token in paragraph.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            var word = token;
            if (lineLength > 0 && lineLength + 1 + word.Length <= width)
            {
                output.Append(' ').Append(word);
                lineLength += 1 + word.Length;
                continue;
            }
            if (lineLength > 0) output.Append('\n');
            while (word.Length > width)
            {
                output.Append(word, 0, width).Append('\n');
                word = word[width..];
            }
            output.Append(word);
            lineLength = word.Length;
        }
    }
}
