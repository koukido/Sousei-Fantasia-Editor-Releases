Sousei-Fantasia 引擎编辑器：公开安装包与文档

语言 / 言語 / Language
安装界面可直接选择中文、日本語或English。离线安装使用完整Setup，不要把维护小工具误当作安装包。
インストーラーで中文・日本語・Englishを選択できます。オフラインでは完全版Setupを使い、保守ツール単体をインストーラーとして使わないでください。
Choose 中文, 日本語 or English in Setup. For offline installation use the full Setup, not the maintenance helper alone.

日本語
この公開リポジトリはインストーラー・更新手順・ライセンス用です。非公開のエンジン開発プロジェクト、ゲーム、個人素材、ソースのバックアップは含みません。
初回はReleasesからSetup EXE、AI-Handoff、SHA256SUMSを取得し、ハッシュと配布元を確認してください。旧PROJECTを上書きせず、エンジンとゲームを別々に保存します。.souseiprojectのダブルクリックで開けます。
インストール版の正式更新はユーザー確認後に取得・検証・適用され、端末ごとのTokenは不要です。配布サイトに接続できない環境では、同一の公式完全版SetupとSHA256SUMSを取得できる端末からオフラインで渡せます。未検証のミラーへ自動切替しません。
既知の制限は該当ReleaseのMaintenanceを参照してください。診断ZIPの提供は任意・手動です。ログの自動送信や遠隔実行サーバーはありません。
未署名ソフトウェアです。SHA256は電子署名の代わりにならず、Windowsの安全機能の回避は推奨しません。難読化や単一EXE配布は完全な解析防止を保証しません。公開バイナリはエンジン全体のオープンソース化を意味しません。SDK・サンプル・Blender等の第三者部分はそれぞれのライセンスに従い、第三者コードの権利は制限しません。

English
This public repository distributes installers, update guidance and licences, not the private engine development project, games, personal assets or source backups.
For first use obtain the Setup EXE, AI-Handoff and SHA256SUMS from Releases. Verify the source and hashes. Keep engine and game separately; never overwrite the old PROJECT folder. Open .souseiproject files by double-clicking.
Installed editors offer stable updates with user confirmation and download verification; per-device tokens are not required. If the release host is unreachable, transfer the same official full Setup and SHA256SUMS from a device that can obtain them, then install offline. There is no automatic fallback to unverified mirrors.
Check the release's Maintenance notes for actual limitations. Diagnostic ZIPs are provided manually and voluntarily; no automatic log upload or remote execution server is included.
The software is unsigned. SHA256 does not replace a digital signature; bypassing Windows security is not recommended. Optimized builds, a single executable and omitted debug symbols do not guarantee resistance to reverse engineering. Public binaries do not imply that private engine source is open-source. SDKs, samples and third-party parts such as Blender retain their respective licences and rights.

中文

这里不托管引擎开发工程、游戏项目、私人资源或源码备份。
安装包/说明在 Releases：https://github.com/koukido/Sousei-Fantasia-Editor-Releases/releases
首次使用下载Setup EXE、AI-Handoff说明和SHA256SUMS；先读说明，不把安装目录覆盖到旧PROJECT。
双击 .souseiproject 打开项目。引擎独立安装与更新，项目单独保存。
仅安装版启动检查一次公开正式发布；手动确认才下载/校验/安装，无需为每台设备配置Token。

版本状态与尚未解决问题以对应Release的 Maintenance 文档为准，不把候选维护版当作所有问题已消失。
反馈由使用者手动提供本地故障ZIP/性能区间；没有自动上传、远程执行或数据收集服务器。
本软件未代码签名。SHA256不代替数字签名；不建议绕过Windows安全策略。
Release优化、单文件分发及不附调试符号不是强反逆向机制，不做不可逆向承诺。

独自引擎实现的许可见安装包中NATIVE_LICENSE及PUBLIC_SCOPE；本仓库公开二进制不等同于引擎源码开源。
必要SDK/示例、工具脚本与第三方部分按各自许可附带；第三方开源许可证、构建资料和对应源码不属于私有引擎源码。
Blender等第三方部分不混淆、不加密，不限制其原许可授予的权利。对应官方源码/许可见Release的第三方资料。
