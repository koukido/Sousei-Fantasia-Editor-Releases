# Troubleshoot a project

[Guide](README.md) · [简体中文](../zh-CN/troubleshooting.md) · [日本語](../ja/troubleshooting.md)

Start with the failing operation and the first error, not repeated scene reloads. Keep the exact version, project path, scene path, action and log from the same run together.

| Symptom | First check | Next action |
| --- | --- | --- |
| Play does not start and shows a build-log path | The first compiler error in that log. | Fix the named file/line or missing toolchain; a generic launch dialog cannot identify the code error by itself. |
| A second editor refuses to open a project | Whether that same project is already open. | Close the original normally; do not remove a live project's lock to force concurrent writers. |
| Arena stays preparing | `State`, `Current_Work`, pending/failed components and `Error`. | Check paths and register required first-screen objects during initialization. Never force Ready. |
| Enter does nothing | Game focus, `Can_Activate` and the ticket used by this operation. | Wait for Ready and press Enter again; inspect a rejected activation rather than assuming it switched. |
| Hierarchy changes but the editor picture is blank | Camera binding, view direction and renderer suspension. | Compare the game window and editor separately; inspect any project editor bridge. |
| A map appears before its labels and buttons | Deferred UI registration or disabled `UI_Text` components. | Prepare the complete initial UI before revealing the scene; do not depend on inactive Update. |
| A scene named Menu has returned but remains covered | Old ticket/scene ownership and the project's overlay state. | Match this instance to this operation and clear only the project's own finished overlay. |
| Recording is Failed or has only a partial video | `recording.json` and `encoder.log`. | Keep the whole run. Check FFmpeg, size/time limits, first-frame wait and backpressure before re-recording. |
| Most CPU lanes look empty | Coverage gaps, full archive counts and clock alignment. | Load all segments; distinguish preview eviction from real archive loss. |
| Export works only on the development path | Project-relative dependencies and the complete exported folder. | Move the full package and reproduce without the editor. |

## Make a useful issue

Reduce the problem to a small project when possible. State what you did, what you expected and what appeared instead. Include the editor version, language, graphics API, target output size and the first relevant log error. For a stall, provide a short video and the CPU interval covering the same time.

Before sharing, remove credentials, personal data and unrelated files. Runs contain game images, control signals, paths and source names. Share them deliberately; neither capture nor the viewer automatically submits them to a server. A public issue does not require publishing the private game or engine implementation.

If the example works in a new project but fails after adding one component, investigate that component and its resource/lifecycle assumptions. If the minimal case fails too, preserve it as a reproducible engine issue. This separates ownership without assuming that every visible problem belongs to the project developer.
