# Day 1 inventory
1. Each line of the output <= width. If word.length > width? Split the word and continue the process from a new line. -outside-code
EXAMPLE: width = 3, input = "the quick brown fox"
"the
qui
ck
bro
wn
fox"
2. Multiple spaces between words? Collapse them to a single one. -outside-code
EXAMPLE: width = 10, input = "the   quick   brown   fox"
"the quick
brown fox"
3. Spaces at the beginning or the end of a line? Remove them. -outside-code
EXAMPLE: width = 10, input = "   the quick brown fox       "
"the quick
brown fox"
4. Line breaks in the input? Collapse multiple neighbouring line breaks into a single one, remove trailing ones, and treat them as breaking the input into paragraphs, and wrap each paragraph. -outside-code
EXAMPLE: width = 11, input = "the\n\nquick brown\nfox\n"
"the
quick brown
fox"
5. Empty input? Return one empty line. -outside-code
EXAMPLE: width = 11, input = "  \n  \n\n   "
""
EXAMPLE: width = 11, input = "         "
""
EXAMPLE: width = 11, input = ""
""
EXAMPLE: width = 11, input = null
""
6. Width <= 0? Throw an error. The function is not designed for this and shouldn't be silent about it. -outside-code
EXAMPLE: width = -2, input = "the quick brown fox"
<exception>
7. What 'width' counts? Characters, emojis are out of scope. -outside-code
8. What to do with tabs? Out of scope. -outside-code

## Lost in the fire
- null, 5 => "" -in-code-only
- "   quick", 3 => "quick" -in-code-only
- "       ", 4 => "" -in-code-only