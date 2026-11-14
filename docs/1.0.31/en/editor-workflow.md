# Work in the editor

[Guide](README.md) · [简体中文](../zh-CN/editor-workflow.md) · [日本語](../ja/editor-workflow.md)

Use **Resource Manager** for files, **Hierarchy** for scene objects and **Object Details** for the selected object's components. A resource file can be shared by many objects; selecting or deleting one object is not the same as removing its resource file.

## Inspect Scene Lab

1. Open `Menu.sfscene` and select `Controller` in Hierarchy. Confirm that `HelloScene.cs` is attached and enabled.
2. Run the test. Runtime objects should become available while the scene is running.
3. Switch the render workspace between **Game editing** and **UI editing**. UI editing exposes canvas selection and arrangement controls. It does not switch the running game to a different scene.
4. Stop the test before opening another authored scene for editing. Stop restores the editor's authored data; it does not save a simulation back into the scene automatically.

## Choose what the camera shows

The editor camera and the game camera are separate. With game-camera linking disabled, moving the editor camera changes your inspection angle, not the game's camera. With linking enabled, inspect the active game camera's framing. A matching scene name does not guarantee a matching image if the two cameras point in different directions.

The docked render panel's size is also separate from the game window's size. Resizing the panel changes the editor viewport. A project may use a fixed UI reference size, such as Scene Lab's `1280 × 720`, and adapt it to the output. Do not hard-code mouse coordinates from a screenshot taken at a different client size.

## Check a scene change

After following [Scene loading](scenes.md), enter Arena and compare both windows. Hierarchy should follow the running scene. The editor's Game/UI workspace remains the one you selected. If Hierarchy follows but the render panel remains blank, check camera linking, the selected camera and renderer status separately instead of loading the scene again repeatedly.

Project scripts can change editor observation behavior. If a project uses an editor bridge, check whether it pauses rendering or forces a workspace; a project hook can make an otherwise running viewport look stuck.
