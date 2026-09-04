# Project Vision

## Purpose

DaD Sample is a small, runnable ASP.NET Core Text Analysis API used to demonstrate Document-aware Development (DaD) on a concrete software project.

The product behavior is deliberately modest. The important subject is how durable project knowledge governs implementation and how a coding agent can discover the decisions, specifications, tasks, and verification relevant to a change.

## Audience

- Software engineers evaluating DaD.
- Readers of the accompanying DaD article series.
- Humans and coding agents that need a compact reference implementation of the framework's working model.

## Principles

- Keep the product small enough that the full repository can be understood quickly.
- Keep architectural intent explicit rather than asking contributors to infer it from code.
- Separate durable decisions, implementable specifications, bounded tasks, implementation, and verification.
- Prefer one authoritative source for each important fact and link to it elsewhere.
- Make the sample runnable without secrets, paid services, or external AI accounts.
- Introduce complexity only when it demonstrates a DaD concept.

## Scope

The sample provides an HTTP API for text-analysis operations. The first operation is text summarization.

The application owns the HTTP and application-facing contracts. AI/text-analysis providers are adapters behind a provider-neutral interface and are selected through dependency injection/configuration rather than called directly from feature code.

## Non-goals

- Building a production-ready AI gateway.
- Demonstrating every ASP.NET Core architectural pattern.
- Providing production authentication, persistence, rate limiting, observability, or multi-tenant behavior.
- Selecting or endorsing a particular AI vendor.
- Hiding all architectural trade-offs behind abstractions merely for the sake of extensibility.

## Success criteria

The sample succeeds when a reader can inspect the repository and answer, without relying on chat history:

1. Why provider independence exists.
2. What behavior the summarization feature must provide.
3. Which task authorized the current implementation.
4. How the implementation is verified.
5. Where to look when those artifacts disagree.
