# discovery-testbed-white-label-branches

**This is a StormBoard topology test fixture, NOT a real application.**

This repository is a synthetic codebase designed to be detected as a **White-Label (Branches)** topology by StormBoard's AI-powered topology detection engine. It is public and intended solely for automated testing of the Discovery mode feature.

## Purpose

StormBoard's Discovery mode analyzes repository structure, namespaces, branch patterns, and other signals to determine the architectural topology of a codebase. This repo provides a controlled fixture with clear white-label branch signals.

## Expected Detection: WhiteLabelBranches (~78% confidence)

### Detection Signals

- **Customer-specific branches**: `customer/acme`, `customer/globex`, `customer/initech`, `customer/umbrella` alongside a `master` trunk
- **Single repository** with customer variants maintained as separate branches
- **Unified project structure**: Api, Domain, Infrastructure projects shared across all branches
- **Domain namespaces**: Auth, Payments, Notifications, Catalog, Orders — shared business logic across variants
- **Consistent infrastructure layer**: Email, Gateways — common backend services for all customers

### Branch Structure

| Branch | Purpose |
|--------|---------|
| `master` | Trunk — base product with all shared capabilities |
| `customer/acme` | Acme Corp customization — adds Customer Loyalty, Report Generation |
| `customer/globex` | Globex Inc customization — adds Bulk Product Import, Loyalty Membership |
| `customer/initech` | Initech customization — adds Tenant Configuration |
| `customer/umbrella` | Umbrella Corp customization — adds Compliance Audit Reporting |

### What StormBoard Tests With This Repo

- Topology detection correctly identifies WhiteLabelBranches from branch naming patterns
- Baseline capability analysis runs against `master` branch
- Branch divergence analysis compares each customer branch against baseline
- Feature matrix shows new/diverged/absent capabilities per branch
- Semantic overlap detection identifies similar capabilities across branches (e.g., Acme's "Customer Loyalty" and Globex's "Loyalty Membership")

## Companion Test Repos

This repo is part of StormBoard's topology detection test suite:

| Repo | Expected Topology |
|------|------------------|
| **discovery-testbed-white-label-branches** (this repo) | WhiteLabelBranches |
| [discovery-testbed-monolith](https://github.com/thurley1/discovery-testbed-monolith) | Monolith |
| [discovery-testbed-modular-monolith](https://github.com/thurley1/discovery-testbed-modular-monolith) | ModularMonolith |
| [discovery-testbed-multi-service](https://github.com/thurley1/discovery-testbed-multi-service) | MonorepoMultiService |
| [discovery-testbed-white-label-dirs](https://github.com/thurley1/discovery-testbed-white-label-dirs) | WhiteLabelDirectories |
| [discovery-testbed-micro-orders](https://github.com/thurley1/discovery-testbed-micro-orders) | Microservices (3-repo set) |
| [discovery-testbed-micro-customers](https://github.com/thurley1/discovery-testbed-micro-customers) | Microservices (3-repo set) |
| [discovery-testbed-micro-inventory](https://github.com/thurley1/discovery-testbed-micro-inventory) | Microservices (3-repo set) |

## Codebase Stats

- **19 types** across 3 projects (Api, Domain, Infrastructure)
- **~327 LOC** of C#
- SLM processing: <2 minutes
- Full analysis: <5 minutes
