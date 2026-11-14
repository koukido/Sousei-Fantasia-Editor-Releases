# Sousei-Fantasia Editor

Windows x64 editor, runtime tools and developer documentation. Keep the engine installation separate from your game projects.

## Developer guides

[English](docs/1.0.31/en/README.md) · [简体中文](docs/1.0.31/zh-CN/README.md) · [日本語](docs/1.0.31/ja/README.md)

The guides cover version **1.0.31**. Follow **Scene Lab** to create a project, attach C# components, prepare a second scene, record a test and export a standalone game. Each chapter links to the same topic in the other languages. Example scripts and scene files are included beside the guides.

## Install

1. Download the full Setup EXE and `SHA256SUMS.txt` from [Releases](https://github.com/koukido/Sousei-Fantasia-Editor-Releases/releases/latest).
2. Verify the Setup's SHA-256 against its matching entry. Run Setup and choose English, 中文 or 日本語.
3. Install the engine separately from your project. Open or create a `.souseiproject`; do not install over an old `PROJECT` directory.
4. Follow the [getting-started guide](docs/1.0.31/en/getting-started.md), including the component compiler prerequisites.

The maintenance helper alone is not a full installer. Installed editors offer stable updates with confirmation and download verification; per-device tokens are not required. If the release host is unreachable, transfer the same official full Setup and checksum file from a device that can obtain them. There is no automatic fallback to unverified mirrors.

## Release notes and support

Read the [1.0.31 release notes](https://github.com/koukido/Sousei-Fantasia-Editor-Releases/releases/tag/v1.0.31) for changes and limitations. The release's `AI-Handoff` files retain migration details for older integrations; they are not the main developer manual.

For a reproducible issue, include the version, failing operation and first relevant error. For a stall, video and a matching CPU interval are useful. See [Troubleshooting](docs/1.0.31/en/troubleshooting.md) before sharing. Diagnostic files are supplied manually and voluntarily; the tools do not automatically upload logs or include a remote-execution server.

## Distribution and licences

This repository distributes installers, tools, documentation and teaching examples. It does not publish the private engine development project, user games, personal assets or source backups.

The software is unsigned. SHA-256 is not a digital signature; bypassing Windows security is not recommended. Optimized builds, a single executable and omitted debug symbols do not guarantee resistance to reverse engineering.

Public binaries do not make the private engine source open-source. Engine terms are provided as `NATIVE_LICENSE` and `PUBLIC_SCOPE` in the installation. SDKs, examples and third-party parts retain their applicable licences. Consult the release's `Third-Party-Notices.txt` and corresponding source materials, including Blender's official source where distributed. Third-party rights are not restricted by the private engine's terms.
