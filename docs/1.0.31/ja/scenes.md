# シーンを読み込んで切り替える

[ガイド一覧](README.md) · [English](../en/scenes.md) · [简体中文](../zh-CN/scenes.md)

Scene LabではMenuを操作可能なままArenaを準備し、プレイヤーがEnterを押したら置き換えます。エンジンは読み込み状態を提供します。進捗バーと演出はプロジェクトで作ります。

## 2つのシーンを準備する

1. [はじめに](getting-started.md)で作成した`Menu.sfscene`を使います。
2. プロジェクトを閉じ、[Arena.sfscene](../examples/Arena.sfscene)を`Resources/Scenes`に保存します。開き直してリソース管理でArenaをダブルクリックし、空の`Controller`に`HelloScene.cs`を追加します。`Message`を`Arena is ready`に変更し、保存してからMenuを開きます。起動シーンはMenuのままにします。
3. Menuの`Controller`へ[MenuToArena.cs](../examples/MenuToArena.cs)を追加します。`TargetScene`は`Scenes/Arena.sfscene`のままにします。このAPIのパスは**Resourcesからの相対パス**であり、ドライブやプロジェクト入口ファイルを基準にはしません。
4. Menuを実行します。Arenaの準備中もMenuは表示されます。準備ができたらゲームウィンドウにフォーカスを置いてEnterを押すと、Arenaに置き換わります。この例では準備前のEnterを予約しないため、Ready後にもう一度押してください。

`Begin`は最初の活動中の`SystemUpdate`から呼びます。`Start`自体が非アクティブなプリロード中に呼ばれる場合があり、その段階からのシーンコマンドは拒否されます。

## アクティブ化する前に状態を読む

```csharp
var status = SYSTEM_Game_Scene_Preloading.Get_Status(ticket);
if (status != null && status.Can_Activate)
    SYSTEM_Game_Scene_Preloading.Activate(ticket, SYSTEM_Scene_Activation_Mode.Replace);
```

`Ready`は初期化と必要なリソース準備の完了であり、描画・表示の完了ではありません。`Activate`の`true`は要求の受付を示し、切替確定と最初の表示は後から発生します。計測時は`Ready_Qpc`、`Activation_Committed_Qpc`、`First_Primary_Presented_Qpc`を区別し、`Qpc_Frequency`で換算します。

非アクティブな準備中のArenaでは、通常の`SystemUpdate`、`Up`、`Draw`は呼ばれません。最初のUI、文字、メッシュは初期化時に登録してください。文字を無効化して、非アクティブなフレームで再有効化する方式にはしません。依存関係の発見でリソース総数は増えることがあります。件数はバイト数でも残り秒数でもありません。

`Is_Terminal`はその操作の終了を示します。`Unloaded`、`Cancelled`、`Failed`、`Stopped`を新しく準備されたシーンと混同しないでください。今回返されたチケットを保持し、同名シーンへの再入場に古いチケットを流用しません。

## 読み込み操作を選ぶ

| 必要な動作 | 操作 |
| --- | --- |
| 準備中の旧シーンの操作を継続しない通常切替 | `SYSTEM_Game_Scene_Transition.Request(path)` |
| 準備してから現在のシーンを置き換える | `Begin(path)`、`Can_Activate`を待ち、`Activate(ticket, Replace)` |
| 両シーンを動作させ、出力を合成する | `Begin(path)`、続いて`Activate(ticket, Add)` |
| 非アクティブな準備を中止する | `Cancel(ticket)` |
| 活動中の非プライマリ追加シーンを破棄する | `Unload(ticket)` |

通常切替の既定リソース方針は`Reuse`です。`Reload`は依存リソースの再利用ではなく解放・再読込を要求します。どちらも、他の活動中の利用者が参照しているリソースを削除する根拠にはなりません。非アクティブなReadyには`Unload`ではなく`Cancel`を使います。

## 遷移を合成する

追加シーンは保存画像ではなく、同時に動作するシーンです。それぞれに有効なカメラと出力設定が必要です。`Begin`の`SYSTEM_Scene_Preload_Options.Output`で設定します。`Order`が大きい出力ほど後から合成され、`X`、`Y`、`Width`、`Height`は正規化した出力矩形です。カメラ出力、リソース準備、ウィンドウサイズは別の概念です。

Addで`Active`になった後は、`Set_Output`で不透明度やブレンドを変更できます。1.0.31では非アクティブなReadyへの`Set_Output`は拒否されます。設定オブジェクトを置き換える際は必要な矩形と順序も保持してください。ディゾルブは対応するブレンドで不透明度を変え、独自効果は対応するコンパイル済みピクセルシェーダーの出力経路を使います。Bを読み込むだけでは効果は付きません。

Bが実際にAを覆った後でAを終了します。`Unload_Scene(aPath, bTicket)`は、Addで活動中かつ合成表示済みの後継シーンを昇格させます。最初のプライマリAにプリロードチケットがない場合に使えます。プライマリを`Unload(ticket)`で破棄したり、描画が参照しうるGPUオブジェクトを直接削除したりしないでください。

読み込みシーンCを設けるかはプロジェクトで決めます。Cをアクティブ化してから、その活動中の制御で次の準備と旧シーンの終了を管理します。Cの非アクティブな`Start`からBeginを入れ子で呼び出しません。

次は[読み込み失敗の調査](troubleshooting.md)、または[遷移の録画](recording.md)へ進みます。
