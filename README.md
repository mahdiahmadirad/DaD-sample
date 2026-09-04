# DaD Sample — Text Analysis API

A small ASP.NET Core project that demonstrates [Document-aware Development (DaD)](https://github.com/mahdiahmadirad/DaD) in practice.

The sample is intentionally small enough to understand in one sitting, but it contains a real architectural constraint: the application must remain independent from any specific AI provider. That decision is represented explicitly in an ADR, refined by a specification, implemented through a bounded task, and verified by tests.

## What the API does

The API currently exposes one endpoint:

```http
POST /api/summaries
Content-Type: application/json

{
  "text": "A long piece of text to summarize."
}
```

The repository uses a deterministic local text-analysis provider so the sample can run without API keys or external services. The provider boundary is the important part of the example; a real vendor adapter can be introduced later without changing application behavior.

## Repository map

```text
.
├── AGENTS.md                         # Working agreement for humans and agents
├── PROJECT-VISION.md                 # Durable purpose, scope, and non-goals
├── TASK-0001.md                      # Active bounded unit of work
├── docs/
│   ├── adr/
│   │   └── ADR-0001.md               # Why AI providers must be replaceable
│   └── specs/
│       └── SPEC-0001.md              # Implementable provider/API contract
├── src/
│   └── DaDSample.Api/
│       ├── Features/Summarization/   # HTTP behavior for summarization
│       └── Providers/                # Provider abstraction + local adapter
├── tests/
│   └── DaDSample.Api.Tests/          # Behavioral verification
└── scripts/                          # Repeatable build/test/run commands
```

## The DaD chain

The important relationship in this repository is:

```text
PROJECT-VISION
      ↓
   ADR-0001
      ↓
   SPEC-0001
      ↓
   TASK-0001
      ↓
     Code
      ↓
     Tests
```

The arrows are not ownership. They are traceability: each layer has a different job and links to the authority that governs it.

## Run locally

Requires the .NET 10 SDK.

```bash
./scripts/build.sh
./scripts/test.sh
./scripts/run.sh
```

Or directly:

```bash
dotnet run --project src/DaDSample.Api/DaDSample.Api.csproj
```

Then send a request to `http://localhost:5080/api/summaries`.

## Why this repository exists

This repository accompanies a series of articles about DaD. It is meant to evolve in visible steps: bootstrap, architectural decision, specification, task, implementation, deliberate drift, and reconciliation. The goal is not to present a perfect project skeleton. It is to make the relationship between project intent, documentation, agent behavior, and code concrete enough to inspect.
