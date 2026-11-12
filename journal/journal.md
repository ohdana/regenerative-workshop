# Day 01
Initially, the agent generated a wrapping function that would break a long word that doesn't fit into specified width.
I was not familiar with wrapping function in general,
and asked Claude to explain how does it usually behave -- so at least I know which rules to write.
It said long words stay in a line, even when they are longer than width.
I rolled with it, but it was bothering me, so i changed it to something that felt more intuitive:
to split a long word. 
If it doesnt fit, then it doesnt fit, okay.
