# Sousei-Fantasia developer guide

Version **1.0.31** · [简体中文](../zh-CN/README.md) · [日本語](../ja/README.md)

Build a small project, attach a component, load a second scene and export a game. Start with **Scene Lab**, the two-scene exercise used throughout these guides. It needs no external artwork.

| Task | Guide |
| --- | --- |
| Install the editor and run your first component | [Get started](getting-started.md) |
| Find objects and choose the editor or game camera | [Work in the editor](editor-workflow.md) |
| Write C# components and configure native builds | [Components](components.md) |
| Prepare a scene before switching or compose two scenes | [Scene loading](scenes.md) |
| Create readable text and assign materials | [UI and materials](ui-and-materials.md) |
| Match a stalled picture to component activity | [Record and diagnose a test](recording.md) |
| Create a game that runs without the editor | [Export a game](exporting.md) |
| Resolve compilation, missing content and incomplete recordings | [Troubleshooting](troubleshooting.md) |

## Downloads and examples

Use the full Setup and `SHA256SUMS.txt` from [release 1.0.31](https://github.com/koukido/Sousei-Fantasia-Editor-Releases/releases/tag/v1.0.31). The maintenance helper alone cannot install the editor.

The [example scripts](../examples) are small teaching examples, not a complete game. Copy them into your own project as each tutorial describes. They do not depend on a private project or private engine implementation.

The user guide explains what to do. The `AI-Handoff` files in the release are historical migration notes; use them when updating an older integration, not as the starting tutorial.
