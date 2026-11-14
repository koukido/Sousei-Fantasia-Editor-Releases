# Record and diagnose a test

[Guide](README.md) · [简体中文](../zh-CN/recording.md) · [日本語](../ja/recording.md)

Record the picture to see what the player saw. Record component CPU activity to find which calls overlapped a stall. Neither substitutes for the other.

## Capture a scene change

1. Start a test game and open the game-run evidence capture settings from **Tools**.
2. Choose an output directory and a label that identifies the test, such as `Menu-Arena-return`. Select video and CPU capture when you need both.
3. For video, select a working `ffmpeg.exe`. The bundled media-decoding DLLs are not the FFmpeg CLI. CPU-only capture does not require FFmpeg.
4. Select game audio, input captions and cursor capture as needed. Cursor capture only adds the system pointer while the game target is active and the pointer is within its unobscured client area; it is not desktop recording.
5. Start capture, perform the transition, then end and save. Wait for `Completed` before treating the MP4 as final. Closing the settings window alone does not stop capture.

The recorder waits for the first real game frame, normally up to 120 seconds. Waiting does not create black frames or consume the video-duration budget. It cannot record Windows window creation or compilation before a game output context exists. A failed capture remains failed; `gameplay.partial.mp4` is a possible video-only recovery, not a complete audio/video recording.

The optional [CaptureExample API helper](../examples/CaptureExample.cs) returns the startup task to its caller. Observe completion or exceptions; do not call `.Wait()` or `.Result` from a game callback. `Stop` is nonblocking; poll `SYSTEM_Game_Recording.Status` while it finalizes. FFmpeg can be found through configured settings, `SOUSEI_FFMPEG` or PATH.

## Open a run in the viewer

Open the game-run library after a test and double-click the recording, or open **Sousei.EvidenceViewer.exe** directly and drop in the run folder or ZIP. Keep the run index, video, CPU session index and its `.profile` directory together. Moving only the `.trace-session.json` file loses its compressed segments.

Use the shared clock to align video and CPU data. If the viewer reports that alignment is unavailable, do not assume a matching timestamp; supply an explicit offset only when you have an external reference.

For a frozen image, select the interval in which playback continues but the picture does not change. Expand the engine or user component lanes, inspect calls and unfinished spans, then check what those calls were waiting for. Use the current video interval, not just the old source image's capture time: repeated images can be encoded while logic continues running.

## Interpret the numbers

| Field or display | Meaning |
| --- | --- |
| Thread ID | A lane for work; not the number of components in the game. |
| Call count | Instrumented calls retained in the selected interval. |
| Elapsed time | Wall-clock span, including waits; overlapping and nested spans must not be summed as CPU percentage. |
| `events` and `dropped` from `profiler.stop` | Bounded preview entries and preview eviction, retained for API compatibility. |
| `archiveEvents`, `archiveDroppedEvents`, `archivePath` | Counts and location for the full archive. Check these before diagnosing missing capture. |

An empty lane can mean capture was not enabled, records were lost, the range is outside coverage or no instrumented call was retained. It does not prove the component did no work. The viewer is a CPU diagnostic tool, not a GPU timing or VRAM profiler.

Capture has overhead even though encoding and archival work use separate workers. For performance comparisons, keep capture settings, resources and the tested operation the same, and compare several runs rather than a single best frame.
