# Linking

VB.NET/Windows Forms で開発されたコミュニケーションデスクトップアプリケーション

## 概要

Linkingは、ルームベースのチャット機能とダイレクトメッセージ（DM）機能を備えたコミュニケーションプラットフォームです。Windows Forms上で動作するネイティブデスクトップアプリケーションとして設計されています。

## 技術スタック

- **言語**: VB.NET
- **フレームワーク**: Windows Forms
- **.NET バージョン**: .NET 10.0 Windows (`net10.0-windows`)
- **IDE**: Visual Studio

### 主要なライブラリ

- `System.Windows.Forms` - UI フレームワーク
- `System.Drawing` - グラフィックス処理（角丸、色管理）
- `System.Drawing.Drawing2D` - 高度なグラフィックス（GraphicsPath等）

## 主な機能

| 機能 | 説明 |
|------|------|
| ログイン | ユーザー認証（メール/パスワード） |
| ホーム画面 | 参加中のルーム一覧表示 |
| 履歴画面 | 参加済みルームの会話履歴表示 |
| お気に入り | ブックマークしたルームの表示 |
| 会話表示 | ルーム内のメッセージ表示（星マーク機能） |
| DM（ダイレクトメッセージ） | 個別メッセージ機能 |

## プロジェクト構造

```
Linking/
├── Linking.slnx                          # ソリューションファイル
├── Linking.vbproj                        # プロジェクト設定
├── Linking/
│   ├── Form1.vb                          # ホーム画面
│   ├── LoginForm.vb                      # ログイン画面
│   ├── HistoryForm.vb                    # 履歴画面（ルーム一覧）
│   ├── FavoritesForm.vb                  # お気に入り画面
│   ├── ConversationForm.vb               # 会話表示画面
│   ├── DmForm.vb                         # DM画面
│   ├── SecondForm.vb                     # テスト/デモ用フォーム
│   ├── ApplicationEvents.vb              # アプリケーションイベント
│   └── My Project/
│       ├── Application.myapp
│       └── Application.Designer.vb
```

## フォーム構成

### フォーム一覧

| フォーム | ファイル | 役割 |
|---------|---------|------|
| ログイン画面 | [LoginForm.vb](Linking/LoginForm.vb) | メール・パスワード入力、認証処理 |
| ホーム画面 | [Form1.vb](Linking/Form1.vb) | ルームカード表示、ナビゲーションハブ |
| 履歴画面 | [HistoryForm.vb](Linking/HistoryForm.vb) | 参加済みルームの一覧表示 |
| お気に入り画面 | [FavoritesForm.vb](Linking/FavoritesForm.vb) | ブックマーク済みルームの表示 |
| 会話画面 | [ConversationForm.vb](Linking/ConversationForm.vb) | ルーム内メッセージ表示、星マーク機能 |
| DM画面 | [DmForm.vb](Linking/DmForm.vb) | ダイレクトメッセージ表示 |

### フォーム遷移フロー

```
LoginForm (ログイン)
    ↓
Form1 (ホーム画面)
    ├→ HistoryForm (履歴/ルーム一覧)
    │   ├→ ConversationForm (会話表示)
    │   │   └→ DmForm (DM)
    │   └→ DmForm (直接DM)
    └→ FavoritesForm (お気に入り)
        └→ ConversationForm (会話表示)
            └→ DmForm (DM)
```

## UI デザイン

### 共通要素

**ヘッダー**
- 背景色: RGB(3, 116, 213) - 青色
- タイトルとロゴ表示
- 戻るボタン（サブ画面）

**フッターナビゲーション**
- 3つのナビゲーションボタン:
  - ホーム（Form1）
  - ルーム（HistoryForm）
  - お気に入り（FavoritesForm）
- アクティブタブ: RGB(255, 230, 0) - 黄色

**カードデザイン**
- FlowLayoutPanel で動的レイアウト
- カード幅: 280px～420px（レスポンシブ）
- 角丸処理: 12px radius
- ホバー効果: 薄いグレー背景

### メッセージバブル（DM画面）

- 固定幅: 420px
- 自分のメッセージ: RGB(0, 184, 242) - 水色背景
- 他人のメッセージ: RGB(238, 238, 238) - グレー背景
- ハイライト時は異なる色で強調表示

## 主要な実装パターン

### 1. 共有UIユーティリティ

共通のUI設定とナビゲーションロジックを提供:

- `ConfigureFooterLayout()` - フッターの配置
- `RegisterFooterNavigation()` - ナビゲーション機能の登録
- `RegisterBackNavigation()` - 戻るボタン機能

### 2. フォーム間遷移パターン

```vb
' 次の画面へ遷移
Dim frm As New NextForm(Me)
frm.Show()
Me.Hide()

' フォームが閉じられた際に前の画面を表示
Private Sub Form_FormClosed(sender As Object, e As FormClosedEventArgs)
    If _prev IsNot Nothing Then
        _prev.Show()
    End If
End Sub
```

### 3. レスポンシブデザイン

- `Resize` イベントでカード幅を動的調整
- `FlowLayoutPanel` でレイアウト管理
- Dock/Anchor プロパティの組み合わせ

## ビルドと実行

### 必要要件

- Visual Studio 2022 以降
- .NET 10.0 SDK
- Windows OS

### ビルド方法

```bash
# ソリューションを開く
start Linking.slnx

# または、コマンドラインからビルド
dotnet build Linking/Linking.vbproj
```

### 実行方法

```bash
dotnet run --project Linking/Linking.vbproj
```

または、Visual Studio から F5 キーでデバッグ実行。

### ビルド構成

- **Debug**: デバッグ情報付きビルド
- **Release**: 最適化された本番ビルド

## 開発状況

### 現在のブランチ

- **現在**: `ホーム画面とログイン画面`
- **メイン**: `master`

### 最近のコミット履歴

| コミット | メッセージ |
|---------|-----------|
| `da2b9b3` | DM実装（仮） |
| `008bc19` | 各ルームごとのの会話の表示 |
| `445b75a` | 各ルームごとの会話を表示 |
| `eaa8d2d` | 履歴画面のヘッダーのレイアウトと、ルームの表示が課題 |
| `0eeb30b` | カードを一枚表示 |

### 現在の実装状態

✅ **完了**
- ログイン画面のUI
- ホーム画面のレイアウト
- 履歴/ルーム一覧表示
- お気に入り画面
- 会話表示画面（基本）
- DM画面（基本）
- ナビゲーション機能
- 共通UIコンポーネント

🚧 **開発中**
- バックエンドAPI接続
- データベース統合
- メッセージの送受信機能
- リアルタイム更新

📋 **今後の予定**
- ユーザー認証の実装
- オフラインキャッシング
- より詳細なエラーハンドリング
- 通知機能
- プロフィール設定

## 既知の課題

- 現在はダミーデータで実装されています（データベース未接続）
- ログイン画面の入力検証は基本的なレベル
- エラーハンドリングが最小限
- ヘッダーレイアウトとルーム表示に改善の余地あり

## 貢献

このプロジェクトへの貢献を歓迎します。

1. このリポジトリをフォーク
2. 機能ブランチを作成 (`git checkout -b feature/AmazingFeature`)
3. 変更をコミット (`git commit -m 'Add some AmazingFeature'`)
4. ブランチにプッシュ (`git push origin feature/AmazingFeature`)
5. プルリクエストを作成

## ライセンス

このプロジェクトのライセンスについては、プロジェクト管理者にお問い合わせください。

## 連絡先

プロジェクトに関する質問や提案がある場合は、Issues セクションで報告してください。

---

**開発環境**: Windows 10/11
**最終更新**: 2026-01-19
