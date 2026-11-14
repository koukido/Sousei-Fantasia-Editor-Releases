# Load and switch scenes

[Guide](README.md) · [简体中文](../zh-CN/scenes.md) · [日本語](../ja/scenes.md)

Scene Lab starts in Menu, prepares Arena while Menu remains interactive, then replaces Menu when the player presses Enter. The engine supplies loading state; the progress bar and transition effect belong to your project.

## Prepare the scenes

1. Keep `Menu.sfscene` from [Get started](getting-started.md).
2. With the project closed, download [Arena.sfscene](../examples/Arena.sfscene) to `Resources/Scenes`. Reopen the project and double-click Arena in Resource Manager. Create an empty `Controller` and attach `HelloScene.cs`. Set its `Message` field to `Arena is ready`, save, then open Menu again. Keep Menu as the configured Startup Scene.
3. Add [MenuToArena.cs](../examples/MenuToArena.cs) to Menu's `Controller`. Leave `TargetScene` as `Scenes/Arena.sfscene`. Paths passed to this API are relative to **Resources**, not to the drive or the `.souseiproject` file.
4. Run Menu. It should remain visible while Arena prepares. Once preparation is ready, focus the game window and press Enter. Arena should replace Menu. Pressing Enter before Ready does not queue a later entry in this example; press it again after preparation finishes.

The component calls `Begin` from its first active `SystemUpdate`, not `Start`. `Start` may itself run during an inactive preload; scene commands issued from that phase are rejected.

## Read the state before activation

```csharp
var status = SYSTEM_Game_Scene_Preloading.Get_Status(ticket);
if (status != null && status.Can_Activate)
    SYSTEM_Game_Scene_Preloading.Activate(ticket, SYSTEM_Scene_Activation_Mode.Replace);
```

`Ready` means initialization and required resource preparation have completed. It does not mean the destination has already drawn or appeared on screen. `Activate` returning `true` accepts a request; the commit and first presentation happen later. For timing, compare `Ready_Qpc`, `Activation_Committed_Qpc` and `First_Primary_Presented_Qpc`, using `Qpc_Frequency`.

During inactive preparation, Arena does not receive ordinary `SystemUpdate`, `Up` or `Draw`. Register its first-screen UI, text and meshes during initialization. Do not disable its text and wait for an inactive frame callback to enable it again. Resource counts can grow as dependencies are discovered; they are not bytes or an estimate of seconds remaining.

Treat `Is_Terminal` as the end of that operation. `Unloaded`, `Cancelled`, `Failed` and `Stopped` are not a prepared new scene. Keep the returned ticket for this operation; do not keep using an old ticket when the player enters the same named scene again.

## Choose a loading operation

| Need | Operation |
| --- | --- |
| Change scenes without keeping the old scene interactive during preparation | `SYSTEM_Game_Scene_Transition.Request(path)` |
| Prepare first, then replace the current scene | `Begin(path)`, wait for `Can_Activate`, then `Activate(ticket, Replace)` |
| Keep both scenes running and compose their outputs | `Begin(path)`, then `Activate(ticket, Add)` |
| Abandon an inactive preparation | `Cancel(ticket)` |
| Retire an active non-primary added scene | `Unload(ticket)` |

`Reuse` is the ordinary transition's default resource policy. `Reload` requests release/reload rather than dependency reuse. Neither is a reason to delete resources still referenced by another active consumer. Inactive `Ready` tickets use `Cancel`, not `Unload`.

## Compose a transition

An added scene runs as a scene, not merely a saved image. It needs its own enabled camera and output settings. Configure `SYSTEM_Scene_Preload_Options.Output` when calling `Begin`. Higher `Order` values compose later; `X`, `Y`, `Width` and `Height` describe normalized output rectangles. Resource preparation and a full-screen output are separate from the window's size.

After Add activation reaches `Active`, change its opacity or blend through `Set_Output`. In 1.0.31, `Set_Output` rejects an inactive Ready ticket. Preserve the rectangle/order fields when submitting a replacement settings object. For a dissolve, use a compatible blend and adjust opacity over time; for a custom effect, use the supported compiled pixel-shader output path. Merely loading B does not generate a dissolve.

Only retire A when B has actually covered it. `Unload_Scene(aPath, bTicket)` promotes an already Add-activated successor after it has been composited. Use this when A was the initial primary scene and has no preload ticket. Do not unload the primary with `Unload(ticket)` or free GPU objects manually while draw submissions can still reference them.

A loading scene C is a project choice: activate C, then let its active controller manage the next preparation and the previous scene's retirement. Do not issue nested Begin commands from C's inactive `Start`.

Next: [Read loading failures](troubleshooting.md) or [record the transition](recording.md).
