# Repository Working Agreement

This file governs work in the DaD Sample repository. It applies equally to human contributors and AI coding agents.

## Source of direction

Before changing the repository:

1. Read `PROJECT-VISION.md`.
2. Read the active `TASK-*.md` file.
3. Read every accepted ADR and approved specification referenced by that task.
4. Inspect the implementation and tests affected by the change.

Do not treat chat history, generated plans, or tool-specific instructions as durable project authority. If material project knowledge exists only outside the repository, capture it in the appropriate artifact before relying on it.

If authoritative sources disagree, stop and surface the conflict. Do not silently choose the source that makes implementation easiest.

## Document roles

- `PROJECT-VISION.md` defines durable purpose, scope, principles, and non-goals.
- `docs/adr/` contains durable architectural decisions and their rationale.
- `docs/specs/` contains approved, implementable behavior and interfaces.
- `TASK-*.md` defines a bounded change, governing references, constraints, acceptance conditions, and completion evidence.
- `src/` implements approved behavior.
- `tests/` and repeatable checks provide evidence about the implementation.

Do not use one document type as a substitute for another.

## Implementation rules

- Work only within the active task's scope.
- Prefer the smallest coherent change that satisfies the task.
- Do not introduce vendor-specific AI SDKs into feature/application code.
- Keep provider-specific behavior behind the provider boundary defined by `ADR-0001` and `SPEC-0001`.
- Do not add speculative abstractions or production infrastructure that the sample does not need.
- Keep authoritative information in one place and link to it elsewhere.
- Update governing documentation when implementation makes it inaccurate.
- Add proportionate tests for behavior changes.

## Reconciliation rule

Before completing a task, compare the implemented state with the governing ADRs, specifications, and task. If they disagree, do not hide the mismatch in code or prose. Determine which source should change, make that change explicit, and preserve traceability.

Documentation is authoritative only within its defined role; it is not infallible. Implementation discoveries may require an ADR, specification, or task to be revised through an explicit change.

## Task completion

Before marking a task complete:

1. Verify every acceptance condition.
2. Run the repository checks.
3. Record the actual evidence in the task.
4. Confirm that repository guidance still describes reality.

For this repository, run:

```text
./scripts/build.sh
./scripts/test.sh
```

Never claim a check was run when it was not.
