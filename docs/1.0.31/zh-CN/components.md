# 编写组件

[指南目录](README.md) · [English](../en/components.md) · [日本語](../ja/components.md)

组件为场景对象增加行为。将脚本挂到 `Controller` 上，才会为这个对象创建组件实例；仅把文件放进 `Resources/Scripts` 不会让它自动运行。

## C# 生命周期

组件继承 `SouseiFantasia.MonoBehaviour`。[HelloScene 示例](../examples/HelloScene.cs)使用 `Start` 一次性创建 UI。

| 回调 | 用途 |
| --- | --- |
| `Awake`、`Start` | 初始化实例，登记初始对象和资源。 |
| `SystemUpdate` | 在逻辑周期读取游戏输入、更新逻辑。 |
| `Up` | 更新与画面帧有关的表现。也支持 `Update` 名称，但不要同时定义并期待两次调用。 |
| `End` | 取消自己的事件订阅，释放组件持有的引用。 |

通过组件的 `scene` 和 `gameObject` 使用当前上下文。不要把一个场景中的对象包装引用，当作下一次进入同名场景时仍属于新实例的对象。

并非每个对象都有 UI 组件，所以 UI 访问器标注为可空。HelloScene 在刚创建对应类型的 UI 后使用 `!`；查找可能不存在的已有对象或组件时，应检查 `null`，不要照搬这个断言。

需要在检视器调整参数时，声明受支持的实例字段，例如 `public float MoveSpeed = 4;`。`static`、`const`、`readonly` 和属性不是可编辑字段。保存的参数会在初始化前应用；修改检视器数值，不代表已经运行的实例一定立即改变。

## 避免逐帧重复准备

初始 UI 放在 `Start` 创建，文字内容变化时才更新。每分钟变化一次的时钟，不需要每个逻辑周期重新设置字符串。文件读取、档案分析与外部编码不应放进帧回调。使用异步 API 时要处理任务结果与异常，不要在游戏回调中调用 `.Wait()` 或 `.Result`。

预算只能在回调之间让出执行，不能抢占正在运行的 `Start`。单次用户操作过重时，将其拆成有界步骤。也不要用 `Task.Run` 直接包住 Manager、场景对象或 GPU 操作；换到后台线程不等于获得并发访问场景状态的权限。

## 原生 C++ 组件

使用引擎的原生组件流程与生成的 `Sousei.hpp` SDK，不引用私有引擎头文件。每台开发设备都应在本机 C++ 工具链设置中查找或选择已安装的 Visual Studio C++ 工具集和 Windows SDK，不能照搬其他设备的绝对路径。

编译失败时一起保留首条编译器错误、选用的工具链与构建日志。打开 Visual Studio 本身不会自动使构建增量化，实际结果取决于编译器配置、输入变化和可复用构建产物。[文档归档](https://github.com/koukido/Sousei-Fantasia-Editor-Releases/releases/download/v1.0.31/Sousei-Fantasia-Docs-1.0.31.zip)中的 `CPP_COMPONENTS.md` 保留底层 SDK 流程，属于历史参考，不是本套教程的三语译本。

修改代码后测试时，分别检查编译成功与实例初始化成功，前者不能替代后者。
