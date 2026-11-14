# Sousei-Fantasia 开发者指南

适用版本 **1.0.31** · [English](../en/README.md) · [日本語](../ja/README.md)

从一个小项目开始，完成组件挂载、场景加载和独立游戏导出。本指南使用不需要外部美术资源的双场景练习 **Scene Lab**，各章可以按顺序操作，也可以按当前任务查阅。

| 要完成的任务 | 阅读章节 |
| --- | --- |
| 安装编辑器，运行第一个组件 | [开始使用](getting-started.md) |
| 查找对象，区分编辑器相机与游戏相机 | [编辑器操作](editor-workflow.md) |
| 编写 C# 组件，配置原生编译环境 | [组件开发](components.md) |
| 预先准备下一个场景，或合成两个场景 | [场景加载](scenes.md) |
| 创建可读文字，设置对象材质 | [UI 与材质](ui-and-materials.md) |
| 对照卡住的画面检查组件调用 | [录制与诊断](recording.md) |
| 制作不依赖编辑器运行的游戏 | [导出游戏](exporting.md) |
| 排查编译失败、内容缺失和录像不完整 | [问题排查](troubleshooting.md) |

## 下载与示例

从 [1.0.31 发布页](https://github.com/koukido/Sousei-Fantasia-Editor-Releases/releases/tag/v1.0.31) 下载完整 Setup 和 `SHA256SUMS.txt`。维护工具本身不是完整安装包。

[示例脚本](../examples) 是教学用的小例子，不是完整游戏。按教程复制到自己的项目中使用，不依赖私有项目或引擎内部实现。

本指南说明如何操作。发布附件中的 `AI-Handoff` 是历次版本迁移记录，适合更新旧接口时查阅，不作为入门教程。
