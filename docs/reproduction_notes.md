# Reproduction Notes

## Scope

This repository documents a Unity / ML-Agents reproduction study conducted in February–March 2025. The preserved portfolio material describes the scope as **environment integration, agent behavior/training-log verification, and reproduction review/demo**, rather than development of the original UnityPGTA method.

## Recovered Technical Evidence

The preserved artifacts support the following points:

1. **Unity ↔ ML-Agents connection was executed.** Experiment footage shows the Unity Editor running while the Python trainer prints training summaries.
2. **Agent action/observation experiments were performed.** Recovered scripts include a discrete 1D controller and a continuous target-reaching agent.
3. **Observation configuration problems were debugged.** Preserved logs show vector-observation padding/mismatch warnings from ML-Agents 2.0.1.
4. **Unity error events were captured into JSON reports.** A preserved report records a collision-triggered `Debug.LogError` as a unique error and stores its stack trace and step information.
5. **The historical workflow used a Conda environment named `ml21`** and invoked `mlagents-learn` with a UnityPGTA YAML configuration.

## Important Limitation

The recovered archive is incomplete. It does not contain enough material to claim that this repository is the exact final runnable 2025 Unity project. In particular, the complete scene/project configuration and some local test scripts are missing.

A recovered text copy of a modified `UnityPGTA` script exists in the private archive, but it is not published here because:

- it was derived from the upstream project,
- the exact final executed version cannot be established from the surviving artifacts, and
- this portfolio reconstruction should avoid presenting uncertain historical code as a clean runnable release.

## What the Preserved Bug Report Shows

One preserved run (`bug_report2025_02_24_12_26_42.json`) contains:

- `unique_error_count`: 1
- `error_count`: 8
- `warning_count`: 50,255
- unique error message: `에러 메시지 입니다.`
- stack trace pointing to a local `collision.cs` callback

The high warning count largely reflects repeated ML-Agents observation warnings and is one reason the public example is condensed.
