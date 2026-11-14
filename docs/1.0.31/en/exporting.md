# Export a game

[Guide](README.md) · [简体中文](../zh-CN/exporting.md) · [日本語](../ja/exporting.md)

Export Scene Lab so that it starts without the editor. The export uses the packaged, precompiled GameRuntime and compiles your project components; it does not build the private engine source on the player's machine.

## Prepare the project

1. Save Menu and Arena, their component bindings and project settings. Confirm the intended startup scene in the project configuration.
2. Keep both scenes available to the runtime, including Arena even though its path appears only in a script. Confirm model, texture, font and shader dependencies; do not assume a resource is included because it once appeared in an editor cache.
3. Stop Play. In **Project**, open **Export**. Choose **Windows x64**, a configuration and the graphics API supported by your project.
4. Choose a new output directory outside the engine installation and outside the source project's data directory. For a first test, keep a debug console so startup errors remain accessible.
5. Export. If the destination already exists, choose deliberately whether to overwrite it, keep a separately named copy or cancel.
6. Run the top-level game EXE from the exported directory. Follow the same Menu → Arena flow without launching the editor.

For anti-aliasing, package the selected fixed method or the supported methods intended for runtime switching. A runtime cannot select a method that was not included in its package.

## Test portability

Copy the **complete exported folder**, not only its EXE, to another location with a different path. Run it with no editor process open. Check scene entry, sound, text, input and return navigation. A move to a different folder checks path assumptions; it does not replace a second-machine hardware test.

The standalone evidence viewer and editor-only test-window borders are tools, not game content. The basic recording API can be used by game code, but that does not embed the editor's capture settings or run library in the game.

Keep the source project separately. Exported runtime files are not an editable source-project backup, and copying a new engine installation over them is not a game update workflow.

If export fails, keep its first error and build log. Resolve a missing component compiler or dependency before retrying; do not add the whole engine source tree to the export as a workaround.
