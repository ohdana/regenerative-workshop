1. Write only under toolshed/impl/, toolshed/host/ and toolshed/provenance/runs/<current-run>/.
2. Never modify toolshed/spec/, contracts/, evals*/, data/ or provenance/nodes/. If any seems wrong, write a proposal in runs/<run>/proposals.md.
3. Before writing code, write plan.md: the chosen strategy, the rejected alternatives with reasons, and the spec IDs and constraints that forced the choice.
4. Every new type or abstraction cites the spec ID that requires it. An uncited abstraction is a defect.
5. Domain code does no I/O and never reads the system clock; use the ports in contracts/.
6. A component changes only the data it owns (spec/ownership.md).
7. Never simplify, clean up or delete a conditional, retry, default or magic number in code you did not generate in this session without first listing it and the constraint it might protect.
8. Done means evals, architecture evals and transcripts all pass and the compaction report exists.
