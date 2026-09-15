# Historical Training Commands

These commands were preserved in the 2025 project notes. They document the environment and training workflow used at the time; they are **not presented as a current one-command reproduction setup**.

```bash
conda activate ml21

mlagents-learn Assets/UnityPGTA-master/UnityPGTA.yaml --run-id=PGTA --train --force

tensorboard --logdir results
```

The preserved notes reference the `ml21` Conda environment and an ML-Agents YAML file inside the historical Unity project. The complete original Unity project structure is no longer available in this archive.
