# 加载与切换场景

[指南目录](README.md) · [English](../en/scenes.md) · [日本語](../ja/scenes.md)

Scene Lab 从 Menu 开始，在 Menu 仍可交互时准备 Arena，玩家按 Enter 后再替换场景。引擎提供加载状态，进度条与转场效果由项目自己制作。

## 准备两个场景

1. 保留[开始使用](getting-started.md)中创建的 `Menu.sfscene`。
2. 关闭项目，将 [Arena.sfscene](../examples/Arena.sfscene) 下载到 `Resources/Scenes`。重新打开项目，在资源管理器中双击 Arena，创建空对象 `Controller` 并挂载 `HelloScene.cs`。将其 `Message` 字段改为 `Arena is ready`，保存后重新打开 Menu；项目启动场景仍设为 Menu。
3. 将 [MenuToArena.cs](../examples/MenuToArena.cs) 挂到 Menu 的 `Controller` 上，`TargetScene` 保持 `Scenes/Arena.sfscene`。API 使用相对于 **Resources** 的路径，不是磁盘绝对路径，也不是相对于项目入口文件。
4. 运行 Menu。Arena 准备期间 Menu 应继续显示；准备完成后让游戏窗口获得焦点，再按 Enter，Arena 应替换 Menu。本例不会记住准备完成前按下的 Enter，需要就绪后再按一次。

组件在第一次活动的 `SystemUpdate` 中调用 `Begin`，不在 `Start` 中调用。`Start` 本身可能在未激活预加载阶段执行，这个阶段提交场景命令会被拒绝。

## 激活前读取状态

```csharp
var status = SYSTEM_Game_Scene_Preloading.Get_Status(ticket);
if (status != null && status.Can_Activate)
    SYSTEM_Game_Scene_Preloading.Activate(ticket, SYSTEM_Scene_Activation_Mode.Replace);
```

`Ready` 表示初始化与所需资源准备完成，不代表目标场景已经绘制或显示。`Activate` 返回 `true` 表示请求被接受，提交与首帧呈现仍在之后发生。计时时分别读取 `Ready_Qpc`、`Activation_Committed_Qpc` 和 `First_Primary_Presented_Qpc`，用 `Qpc_Frequency` 换算。

未激活准备期间，Arena 不接收普通 `SystemUpdate`、`Up` 或 `Draw`。首屏 UI、文字和网格应在初始化时登记，不要禁用文字后等待未激活场景的帧回调将其恢复。发现新依赖时，资源总数可能增加；这个数量不是字节数，也不能直接估算剩余秒数。

`Is_Terminal` 表示这一次操作已经结束。`Unloaded`、`Cancelled`、`Failed`、`Stopped` 不能当作新的已准备场景。保存本次操作返回的票据，不要在再次进入同名场景时继续把旧票据当作新实例的凭据。

## 选择加载操作

| 需求 | 操作 |
| --- | --- |
| 普通切换，准备期间不保持旧场景可交互 | `SYSTEM_Game_Scene_Transition.Request(path)` |
| 先准备，再替换当前场景 | `Begin(path)`，等 `Can_Activate`，再 `Activate(ticket, Replace)` |
| 两个场景同时运行并合成输出 | `Begin(path)`，再 `Activate(ticket, Add)` |
| 放弃尚未激活的准备 | `Cancel(ticket)` |
| 卸载已经激活、但不是主场景的追加场景 | `Unload(ticket)` |

普通切换默认使用 `Reuse` 资源策略；`Reload` 请求释放重载而非依赖复用。两种策略都不能作为删除仍被其他活动使用者引用资源的理由。未激活的 Ready 票据使用 `Cancel`，不使用 `Unload`。

## 合成转场

追加场景是同时运行的场景，不只是存下来的画面。它需要自己的启用相机与输出设置。调用 `Begin` 时配置 `SYSTEM_Scene_Preload_Options.Output`；较大的 `Order` 后合成，`X`、`Y`、`Width`、`Height` 使用归一化输出区域。相机输出、资源准备和窗体大小是不同概念。

Add 激活达到 `Active` 后，再通过 `Set_Output` 调整透明度或混合方式。1.0.31 会拒绝对未激活 Ready 票据调用 `Set_Output`。提交新的设置对象时保留需要的区域与层级字段。溶解可以使用合适的混合方式并逐步改变透明度，自定义效果则走受支持的已编译像素着色器输出接口；单纯加载 B 不会自动生成溶解。

等 B 确实覆盖 A 后再退休 A。`Unload_Scene(aPath, bTicket)` 用于提升已经 Add 激活且完成合成呈现的后继场景，适合最初的主场景没有预加载票据的情况。不要用 `Unload(ticket)` 卸载主场景，也不要在绘制仍可能引用资源时手动删除 GPU 对象。

加载场景 C 是项目的选择：先激活 C，再由 C 的活动控制器管理下一次准备与旧场景退休。不要在 C 未激活时的 `Start` 中嵌套调用 Begin。

下一步：[排查加载失败](troubleshooting.md)，或[录制转场](recording.md)。
