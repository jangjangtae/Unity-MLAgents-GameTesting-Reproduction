# Unity ML-Agents Game-Testing Reproduction Study

A portfolio reconstruction of a **2025 Unity / ML-Agents reproduction study** based on the public [UnityPGTA](https://github.com/amkorousagi/UnityPGTA) project.

The goal of the original study was not to claim a new UnityPGTA implementation. I reproduced the Unity–ML-Agents training connection, tested agent observation/action definitions, investigated integration errors, and verified that Unity error events could be recorded during RL execution.

> **Archive status:** this repository is reconstructed from preserved source files, notes, bug reports, and experiment videos. The original complete Unity project (scene, `Packages`, `ProjectSettings`, and the exact final executed script set) is no longer available, so this repository should be treated as **portfolio evidence of the reproduction/integration work**, not as a guaranteed runnable snapshot of the 2025 environment.

## What I Worked On

- Connected a Unity environment to the Python `mlagents-learn` trainer and verified PPO training execution.
- Tested **discrete and continuous action spaces** with small ML-Agents agents.
- Implemented and debugged **vector observations**, including position, target-relative information, and velocity-based observations.
- Investigated observation-size mismatches, heuristic/action configuration errors, and trainer connection issues.
- Evaluated an error-event logging flow in which Unity errors/exceptions were collected during agent execution.
- Preserved JSON bug reports containing error types, stack traces, step information, and unique-error counts.

## Evidence from the 2025 Study

The preserved archive contains experiment videos showing:

- Unity running together with the Python `mlagents-learn` trainer.
- Training summaries progressing while mean reward increases during a recorded run.
- The reproduced baseline Unity test environment and ML-Agents configuration/output.
- Additional Unity–Python training tests used while validating the workflow.

### Recorded Experiment Videos

- [Unity / ML-Agents experiment recording 1](https://youtu.be/Coj5pLiVt6M)
- [Unity / ML-Agents experiment recording 2](https://youtu.be/uP0psmzjMY4)
- [Unity / ML-Agents experiment recording 3](https://youtu.be/M7ACJHdS7tI)

These recordings are included as visual evidence of the Unity–trainer integration, reproduced test environment, and training/debugging workflow documented in this repository.

See [`docs/evidence.md`](docs/evidence.md) for the preserved evidence inventory and what the archived artifacts support.

## Preserved Source Files

The `preserved/` directory contains small agent scripts recovered from the 2025 archive:

- `BasicController.cs` — a simple discrete-action 1D navigation agent used to validate ML-Agents action/reward flow.
- `MyAgent.cs` — a continuous-action target-reaching agent used to test vector observations and movement.

These files are preserved as portfolio artifacts and may require scene/package configuration that is not included here.

## Error-Logging Evidence

`examples/bug_report_sample.json` is a condensed version of one preserved run log. The original log recorded a Unity error from a collision callback and tracked it as a unique error together with repeated errors and ML-Agents warnings.

The sample is intentionally condensed because the raw run contained tens of thousands of repeated warning entries.

## Historical Training Workflow

The preserved command note used the following workflow:

```bash
conda activate ml21
mlagents-learn Assets/UnityPGTA-master/UnityPGTA.yaml --run-id=PGTA --train --force
tensorboard --logdir results
```

See [`docs/historical_commands.md`](docs/historical_commands.md) for context.

## Repository Structure

```text
.
├── README.md
├── preserved/
│   ├── BasicController.cs
│   └── MyAgent.cs
├── examples/
│   └── bug_report_sample.json
└── docs/
    ├── evidence.md
    ├── historical_commands.md
    ├── reproduction_notes.md
    └── provenance.md
```

## Reproduction Notes

This study used **Unity ML-Agents 2.0.1** in the preserved logs/project material. The recovered artifacts also document issues such as observation-size warnings and trainer communication/debugging. See [`docs/reproduction_notes.md`](docs/reproduction_notes.md).

## Attribution and Scope

This work was performed as a reproduction/integration study based on the public **UnityPGTA** project by `amkorousagi`.

- Upstream project: https://github.com/amkorousagi/UnityPGTA
- I do **not** claim authorship of UnityPGTA itself.
- The upstream `UnityPGTA.cs` source is **not redistributed here**. This portfolio repository focuses on my preserved auxiliary agents, experiment evidence, notes, and logs.

## Why This Repository Exists

My main research focuses on reinforcement learning and game AI. This repository documents additional hands-on experience connecting an RL trainer to a Unity game environment, debugging the agent interface, and validating experiment execution inside a game engine.
