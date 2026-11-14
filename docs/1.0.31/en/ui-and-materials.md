# Create UI and assign materials

[Guide](README.md) · [简体中文](../zh-CN/ui-and-materials.md) · [日本語](../ja/ui-and-materials.md)

Use Scene Lab's [HelloScene.cs](../examples/HelloScene.cs) to create a canvas, dark panel and text. Each object has one job: the Canvas establishes the reference size, the Panel supplies contrast, and the Text supplies the message.

## Keep text readable

Set the text color and its background deliberately. Test normal, disabled, selected and hovered states when a control supports them. A readable hover state does not fix an invisible unchecked box or unreadable resting text.

`UI_Text` generates a texture asynchronously. Changing the string or layout can require new text preparation; assigning an unchanged string every frame does not make a counter smoother. The engine can retain an old drawable result while preparing the new one, so “a texture exists” is not the same as “the latest requested text is ready.” Check `Is_Preparing` and `Last_Error` when diagnosing a missing update.

Keep generated text resources with the project when moving it. Use fonts available on the target machine or the bundled fallback fonts, then check your actual language's glyphs. Rendering basic Latin characters ahead of time does not prove that Japanese shaping or Chinese text is ready.

## Layout the destination before revealing it

For a district selector, prepare the title, region buttons, selected-region details and start button together with the map. Keep the first screen's components registered and enabled for resource preparation. Reveal the scene only after its genuine resource gate, rather than starting a second “one label per frame” queue after the map is already visible.

Scene Lab uses a `1280 × 720` reference canvas. Test a narrow and a wide output, and check that the pointer hits the same control that the player sees. Use the current client size to convert input coordinates; do not use the editor panel's dimensions for the separate game window.

## Assign a material

Import a model and its textures under `Resources`, place the model in the scene, then select its material settings in Object Details. Keep mesh, texture and shader paths project-relative. A copied material with an absolute path to another developer's drive will not become portable merely because the mesh was copied too.

A Blender material is not an automatic guarantee of the same result in the runtime. Reproduce its intended surface using the supported shader inputs and compare the game output, particularly for transparency, culling and depth writes. A glass object that writes depth incorrectly can hide another surface; increasing opacity will not correct that ordering problem.

When checking jagged thin lines, distinguish geometry edges, texture minification and shader-generated detail. Select the anti-aliasing method available in the project and include the intended methods in the export. Anti-aliasing cannot repair a missing texture or unsupported material feature. See the release archive's `AntiAliasing-1.0.23.txt` for the existing method/package contract.
