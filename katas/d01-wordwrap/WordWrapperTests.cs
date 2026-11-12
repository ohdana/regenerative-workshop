namespace WordWrap;

public class WordWrapperTests
{
    // Examples taken verbatim from inventory.md.
    [Theory]
    [InlineData("the quick brown fox", 3, "the\nquick\nbrown\nfox")]            // 1
    [InlineData("the   quick   brown   fox", 10, "the quick\nbrown fox")]       // 2
    [InlineData("the quick brown fox       ", 10, "the quick\nbrown fox")]      // 3
    [InlineData("the\n\nquick brown\nfox\n", 11, "the\nquick brown\nfox")]      // 4
    [InlineData("", 11, "")]                                                    // 5
    public void Inventory_examples(string text, int width, string expected) =>
        Assert.Equal(expected, WordWrapper.Wrap(text, width));

    [Fact] // 6
    public void Inventory_example_negative_width_throws() =>
        Assert.Throws<ArgumentOutOfRangeException>(() => WordWrapper.Wrap("the quick brown fox", -2));

    // Item 1: lines fill up to the width, and long words stand alone.
    [Theory]
    [InlineData("word word", 9, "word word")]
    [InlineData("word word", 8, "word\nword")]
    [InlineData("a b c d", 3, "a b\nc d")]
    [InlineData("a verylongword b", 4, "a\nverylongword\nb")]
    [InlineData("verylongword", 4, "verylongword")]
    public void Fills_lines_and_keeps_long_words_whole(string text, int width, string expected) =>
        Assert.Equal(expected, WordWrapper.Wrap(text, width));

    [Fact] // Item 1 as a property
    public void Every_line_fits_or_is_a_single_long_word()
    {
        const string text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy.";
        for (int width = 1; width <= 30; width++)
            Assert.All(WordWrapper.Wrap(text, width).Split('\n'),
                line => Assert.True(line.Length <= width || !line.Contains(' '), $"width {width}: '{line}'"));
    }

    // Items 2-5: whitespace and line-break edge cases.
    [Theory]
    [InlineData("   ", 5, "")]
    [InlineData("\n\n", 5, "")]
    [InlineData("one\n   \ntwo", 10, "one\ntwo")]
    [InlineData("one two\nthree four", 7, "one two\nthree\nfour")]
    [InlineData("one\r\n\r\ntwo\r\n", 10, "one\ntwo")]
    public void Handles_whitespace_and_line_breaks(string text, int width, string expected) =>
        Assert.Equal(expected, WordWrapper.Wrap(text, width));

    [Fact] // Item 6
    public void Zero_width_throws() =>
        Assert.Throws<ArgumentOutOfRangeException>(() => WordWrapper.Wrap("text", 0));
}
