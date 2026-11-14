# Create your first project

[Guide](README.md) · [简体中文](../zh-CN/getting-started.md) · [日本語](../ja/getting-started.md)

Create **Scene Lab**, a separate project with one component that displays a message. Use the Windows x64 editor, version 1.0.31. C# and native C++ components have different build requirements; a C# exercise does not require installing Visual Studio just to follow this page.

For C# compilation, install a [Windows x64 .NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet) capable of building `net8.0-windows` desktop projects. The editor's runtime is not a compiler, and installing only a .NET Runtime is insufficient. In a new terminal, run `dotnet --list-sdks` and confirm it lists an SDK. Keep the SDK on PATH and restart an editor that was open during installation. Microsoft documents [SDK targeting and support](https://learn.microsoft.com/en-us/dotnet/core/releases-and-support); a newer SDK can target an earlier framework, but does not extend that framework's support lifetime.

## Install and create a project

1. Download the full Setup and `SHA256SUMS.txt` from [release 1.0.31](https://github.com/koukido/Sousei-Fantasia-Editor-Releases/releases/tag/v1.0.31). Compare the Setup's SHA-256 with its matching line before running it.
2. Run Setup. Select **English** in its language list and choose an engine installation directory, separate from your projects. The software is unsigned; a checksum does not replace a signature.
3. Start the editor. In the project entry window enter `SceneLab` as the project name, choose **Create a project…**, then select an empty destination folder. If another project is already open, open the project entry window rather than clearing that project's contents.
4. Keep the generated `.souseiproject` file and its data folder together. Open that entry file next time; do not copy a project's resources into the engine installation.

If the release host is unreachable on the development machine, transfer the same official Setup and checksum file from another device. A separate token is not required for each machine. Do not substitute an unverified mirror.

## Display a message

1. Close the project before adding the example files externally. Download [Menu.sfscene](../examples/Menu.sfscene) to its `Resources/Scenes` folder and [HelloScene.cs](../examples/HelloScene.cs) to `Resources/Scripts`. Keep the filenames and extensions; save the raw file, not a GitHub HTML page. These are new files for Scene Lab, not replacements for existing work.
2. Reopen the project. In Resource Manager, double-click `Menu.sfscene`. Its camera is already configured for this screen-UI exercise.
3. In Hierarchy, create an empty object named `Controller`. Select it and attach `HelloScene.cs` as a C# component in the object's Inspector. Leave `Message` at its default value, then save the project.
4. Open **Project → Project Settings → Scene Flow**. Set **Startup Scene** to `Scenes/Menu.sfscene` and apply the settings. Test play uses this setting, not whichever scene you last inspected.
5. Run the test from the **Test** menu. Wait for compilation and initialization. The game window should display **Scene Lab is running** on a dark panel.
6. Stop the test. The objects created by the component are runtime objects; they are not a replacement for saving authored content in the editor.

If compilation fails, open the build log shown by the error. If compilation succeeds but nothing appears, check the component's enabled state and whether the test window, rather than only the editor viewport, is visible. See [Troubleshooting](troubleshooting.md).

## Project files

`Resources` contains your scenes, scripts and imported assets. `Settings` contains project configuration. `.Sousei` holds local caches, builds and diagnostics; it is not the only copy of your authored work. Generated text textures may live under `Resources/Generated`, so do not delete everything named Generated to fix a loading problem.

Back up the complete project before changing file organization. A `.souseiproject` entry on its own is not a backup of its referenced resources.

Next: [Work in the editor](editor-workflow.md), then [prepare a second scene](scenes.md).
