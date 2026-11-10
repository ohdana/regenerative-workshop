namespace WordWrap;

public class WordWrapperTests
{
    [Theory]
    [InlineData(null, 5, "")]
    [InlineData("", 5, "")]
    [InlineData("word", 10, "word")]
    [InlineData("word", 4, "word")]
    [InlineData("word word", 6, "word\nword")]
    [InlineData("word word", 9, "word word")]
    [InlineData("a b c d", 3, "a b\nc d")]
    [InlineData("the quick brown fox", 10, "the quick\nbrown fox")]
    public void Wraps_at_spaces(string? text, int width, string expected) =>
        Assert.Equal(expected, WordWrapper.Wrap(text, width));

    [Theory]
    [InlineData("abcdef", 3, "abc\ndef")]
    [InlineData("abcdefg", 3, "abc\ndef\ng")]
    [InlineData("hi abcdefgh", 4, "hi\nabcd\nefgh")]
    [InlineData("abcdefg hi", 3, "abc\ndef\ng\nhi")]
    [InlineData("abc", 1, "a\nb\nc")]
    public void Splits_words_longer_than_width(string text, int width, string expected) =>
        Assert.Equal(expected, WordWrapper.Wrap(text, width));

    [Theory]
    [InlineData("  word   word  ", 6, "word\nword")]
    [InlineData("one two", 20, "one two")]
    [InlineData("   ", 5, "")]
    public void Collapses_and_trims_spaces(string text, int width, string expected) =>
        Assert.Equal(expected, WordWrapper.Wrap(text, width));

    [Theory]
    [InlineData("one\ntwo", 10, "one\ntwo")]
    [InlineData("one\r\ntwo", 10, "one\ntwo")]
    [InlineData("one two\n\nthree four", 7, "one two\n\nthree\nfour")]
    public void Preserves_existing_line_breaks(string text, int width, string expected) =>
        Assert.Equal(expected, WordWrapper.Wrap(text, width));

    [Fact]
    public void No_line_exceeds_width()
    {
        const string text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy.";
        for (int width = 1; width <= 30; width++)
            Assert.All(WordWrapper.Wrap(text, width).Split('\n'), line => Assert.InRange(line.Length, 0, width));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Rejects_non_positive_width(int width) =>
        Assert.Throws<ArgumentOutOfRangeException>(() => WordWrapper.Wrap("text", width));
}
