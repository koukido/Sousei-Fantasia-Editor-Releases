# 创建第一个项目

[指南目录](README.md) · [English](../en/getting-started.md) · [日本語](../ja/getting-started.md)

创建独立项目 **Scene Lab**，用一个组件在画面中显示文字。本练习使用 Windows x64 的 1.0.31 编辑器。C# 与原生 C++ 的编译要求不同，不必为了完成这个 C# 练习先安装 Visual Studio。

C# 编译需要能构建 `net8.0-windows` 桌面项目的 [Windows x64 .NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet)。编辑器自带的运行环境不是编译器，只安装 .NET Runtime 也不够。在新终端中运行 `dotnet --list-sdks`，确认列出了 SDK。保持 `dotnet` 在 PATH 中；安装期间已打开的编辑器需要重启。Microsoft 的 [SDK 与支持说明](https://learn.microsoft.com/en-us/dotnet/core/releases-and-support)介绍了版本关系：较新 SDK 可以面向较早框架编译，但不会延长目标框架的支持期限。

## 安装并创建项目

1. 从 [1.0.31 发布页](https://github.com/koukido/Sousei-Fantasia-Editor-Releases/releases/tag/v1.0.31) 下载完整 Setup 和 `SHA256SUMS.txt`，运行前核对安装包的 SHA-256 与对应条目。
2. 运行 Setup，在语言列表选择中文，将引擎安装到与项目分开的目录。软件尚未代码签名，散列校验不能代替数字签名。
3. 启动编辑器，在项目入口窗口将项目名称填为 `SceneLab`，选择“新建独立项目…”，再选择空的目标目录。如果已经打开其他项目，重新打开项目入口，不要使用清空当前项目的功能。
4. 保持生成的 `.souseiproject` 与其数据目录一起保存。以后打开这个项目入口文件，不要把资源复制到引擎安装目录中。

开发设备无法访问发布站点时，可以从能够下载的设备传递同一官方完整安装包和校验文件，不需要每台设备配置 Token。不要改用未经核验的镜像。

## 显示一条消息

1. 在外部添加示例前关闭项目。将 [Menu.sfscene](../examples/Menu.sfscene) 下载到 `Resources/Scenes`，将 [HelloScene.cs](../examples/HelloScene.cs) 下载到 `Resources/Scripts`。保留文件名与扩展名，保存原始文件，不是 GitHub 网页。这些是 Scene Lab 的新文件，不要覆盖已有作品。
2. 重新打开项目，在资源管理器中双击 `Menu.sfscene`。文件已为本例的屏幕 UI 配置相机。
3. 在层级中创建名为 `Controller` 的空对象。选择它，在对象检视器中把 `HelloScene.cs` 挂载为 C# 组件，`Message` 保持默认值，然后保存项目。
4. 打开“项目 → 项目设置 → 场景流程”，将“启动场景”设为 `Scenes/Menu.sfscene`，应用设置。试玩使用这个设置，不一定启动当前正在查看的场景。
5. 从测试菜单运行，等待编译和初始化。游戏窗口应在深色面板上显示 **Scene Lab is running**。
6. 停止测试。组件创建的对象属于运行时，不能替代在编辑器中保存的场景内容。

编译失败时打开错误提示给出的构建日志。编译成功却没有画面时，检查组件是否启用，以及当前查看的是游戏测试窗口还是仅编辑器视口。更多情况见[问题排查](troubleshooting.md)。

## 项目文件的用途

`Resources` 保存场景、脚本与导入资源；`Settings` 保存项目设置；`.Sousei` 保存本地缓存、构建和诊断。已生成的文字贴图也可能位于 `Resources/Generated`，不要为了修复加载而删除所有名字带 Generated 的目录。

调整目录前备份完整项目。只保存 `.souseiproject` 文件，不等于备份了它引用的资源。

下一步：[编辑器操作](editor-workflow.md)，然后[准备第二个场景](scenes.md)。
