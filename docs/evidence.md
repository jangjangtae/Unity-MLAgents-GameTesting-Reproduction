# Preserved Experiment Evidence

The original 2025 study is no longer available as a complete Unity project, but several experiment videos and logs were preserved. These artifacts were used to reconstruct the scope of the work documented in this repository.

## Training execution

A preserved video titled `강화학습 베이스라인 학습성공.mp4` shows the Unity Editor running together with the Python `mlagents-learn` trainer. The trainer output progresses through multiple training summaries and the visible mean reward increases during the run.

This supports the claim that the Unity environment and the ML-Agents trainer were successfully connected and that training was executed.

## Baseline environment

A preserved video titled `PGTA 베이스라인 구축.mp4` shows the Unity test environment together with ML-Agents configuration/trainer output. It documents the reproduced baseline setup used while testing the Unity–RL integration.

Another preserved video, `PGTA 베이스라인.mp4`, provides a longer demonstration of the same reproduction-study environment.

## Python / Unity training workflow

A separate preserved video titled `파이썬 코드로 학습하는 예제.mp4` documents additional Unity–Python training execution used while validating the ML-Agents workflow.

## Log evidence

Preserved JSON reports record Unity errors, repeated warnings, unique-error counts, and stack traces during agent execution. A condensed public example is available at [`../examples/bug_report_sample.json`](../examples/bug_report_sample.json).

The raw videos and large repetitive logs are kept outside this public repository; this repository includes only the source excerpts and documentation needed to show the scope of the reproduction/integration study.
