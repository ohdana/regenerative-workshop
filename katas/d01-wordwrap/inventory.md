# Day 1 inventory
1. Each line of the output <= width, unless it is a word that is longer than width => then the word takes its own line. -outside-code
EXAMPLE: width = 3, input = "the quick brown fox"
"the
quick
brown
fox"
2. Multiple spaces between words? Collapse them to a single one. -outside-code
EXAMPLE: width = 10, input = "the   quick   brown   fox"
"the quick
brown fox"
3. Spaces at the end of a line? Remove them. -outside-code
EXAMPLE: width = 10, input = "the quick brown fox       "
"the quick
brown fox"
4. Line breaks in the input? Collapse multiple neighbouring line breaks into a single one, remove trailing ones, and treat them as breaking the input into paragraphs, and wrap each paragraph. -outside-code
EXAMPLE: width = 11, input = "the\n\nquick brown\nfox\n"
"the
quick brown
fox"
5. Empty input? Return one empty line. -outside-code
EXAMPLE: width = 11, input = ""
""
6. Width <= 0? Throw an error. The function is not designed for this and shouldn't be silent about it. -outside-code
EXAMPLE: width = -2, input = "the quick brown fox"
<exception>
7. What 'width' counts? Characters, emojis are out of scope. -outside-code
8. What to do with tabs? Out of scope.