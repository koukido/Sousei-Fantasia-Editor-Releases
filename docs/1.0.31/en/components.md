# Write a component

[Guide](README.md) · [简体中文](../zh-CN/components.md) · [日本語](../ja/components.md)

A component adds behavior to a scene object. Attaching a script file to `Controller` connects its instance to that object; keeping a file in `Resources/Scripts` alone does not make it run.

## C# lifecycle

Derive a component from `SouseiFantasia.MonoBehaviour`. The [HelloScene example](../examples/HelloScene.cs) uses `Start` to create its UI once.

| Callback | Use |
| --- | --- |
| `Awake` and `Start` | Initialize the instance and register its initial objects and resources. |
| `SystemUpdate` | Sample game input and update logic on the logic cycle. |
| `Up` | Update frame-driven presentation. `Update` is a supported alternative name; do not define both expecting two calls. |
| `End` | Remove your subscriptions and release component-owned references. |

Use `scene` and `gameObject` from the component's context. Do not cache one scene's object wrapper and reuse it as though it belonged to the next scene.

The UI accessors are nullable because not every object is a UI control. The HelloScene example uses `!` immediately after creating the matching UI kind. When looking up an optional existing object or component, check for `null` instead.

For Inspector parameters, expose a supported instance field, for example `public float MoveSpeed = 4;`. `static`, `const`, `readonly` and properties are not editable fields. Saved parameters are applied before initialization; changing an Inspector value is not a guarantee that an already-running instance will immediately change.

## Avoid doing the same work every frame

Create the initial UI in `Start`; update text only when its value changes. A clock that changes once a minute does not need its string reassigned on every logic cycle. Keep file reading, archive analysis and external encoding out of frame callbacks. When using an asynchronous API, observe its task and handle failure without `.Wait()` or `.Result` in the game callback.

A preparation budget can stop between callbacks, not in the middle of your `Start`. Split a large user operation into bounded steps if one callback takes too long. Do not call `Task.Run` around Manager, scene-object or GPU access: a background thread is not permission to use scene-owned state concurrently.

## Native C++ components

Use the engine's native component workflow and generated `Sousei.hpp` SDK, rather than compiling against private engine headers. On each developer machine, inspect the local C++ toolchain settings and select or discover an installed Visual Studio C++ toolset and Windows SDK. A path valid on a teammate's machine may not exist on yours.

If native compilation fails, keep the first compiler error, selected toolchain and build log together. Opening Visual Studio does not by itself make a build incremental; the configured compiler, unchanged inputs and reusable build outputs determine that behavior. See the release's `CPP_COMPONENTS.md` in the [documentation archive](https://github.com/koukido/Sousei-Fantasia-Editor-Releases/releases/download/v1.0.31/Sousei-Fantasia-Docs-1.0.31.zip) for the lower-level SDK workflow. It is a legacy reference, not a translated tutorial.

When testing code changes, distinguish a build failure from a runtime initialization failure. A successful compiler exit only answers the first question.
