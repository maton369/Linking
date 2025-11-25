Imports System.Drawing.Drawing2D

Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    Private ReadOnly _prev As System.Windows.Forms.Form

    ' 既存のデフォルトコンストラクタ（デザイナ用）
    Public Sub New()
        InitializeComponent()
        AddHandler Me.Load, AddressOf Form1_Load
        AddHandler Me.Resize, AddressOf Form1_Resize
        _prev = Nothing
    End Sub

    ' 遷移元フォームを受け取るコンストラクタ（実行時遷移用）
    Public Sub New(prev As System.Windows.Forms.Form)
        ' デザイナで必要な初期化を行う
        Me.New()
        ' 遷移元を保持して、閉じたときに戻すハンドラを登録
        Dim fi = Me.GetType().GetField("_prev", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
        If fi IsNot Nothing Then
            fi.SetValue(Me, prev)
        End If
        AddHandler Me.FormClosed, AddressOf Form1_FormClosed
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs)
        If _prev IsNot Nothing Then
            ' 遷移元を再表示して戻れるようにする
            _prev.Show()
        Else
            ' _prev が無ければアプリ全体を終了する場合はここで Application.Exit() を呼ぶ
            ' Application.Exit()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs)
        ' ハンドラを確実に登録
        EnsureHandlers()

        ' 実行時スタイリング（角丸・ナビ位置など）
        ApplyRuntimeStyling()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs)
        ' ウィンドウサイズ変更時に角丸等を再適用
        ApplyRuntimeStyling()
    End Sub

    Private Sub ApplyRuntimeStyling()
        ' btnAdd を丸くする（存在・サイズチェック）
        If btnAdd IsNot Nothing AndAlso btnAdd.Width > 0 AndAlso btnAdd.Height > 0 Then
            Try
                Using gp As New GraphicsPath()
                    gp.AddEllipse(0, 0, btnAdd.Width - 1, btnAdd.Height - 1)
                    btnAdd.Region = New Region(gp)
                End Using
            Catch ex As Exception
                ' 無視：デザイナやランタイム環境で失敗することがある
            End Try
        End If

        ' devicePanel を角丸にする（存在チェック）
        If devicePanel IsNot Nothing AndAlso devicePanel.Width > 0 AndAlso devicePanel.Height > 0 Then
            Try
                Dim r As Integer = Math.Min(24, Math.Min(devicePanel.Width \ 10, devicePanel.Height \ 10))
                Using gp As New GraphicsPath()
                    Dim w = devicePanel.Width
                    Dim h = devicePanel.Height
                    gp.AddArc(0, 0, r * 2, r * 2, 180, 90)
                    gp.AddArc(w - r * 2, 0, r * 2, r * 2, 270, 90)
                    gp.AddArc(w - r * 2, h - r * 2, r * 2, r * 2, 0, 90)
                    gp.AddArc(0, h - r * 2, r * 2, r * 2, 90, 90)
                    gp.CloseFigure()
                    devicePanel.Region = New Region(gp)
                End Using
            Catch ex As Exception
            End Try
        End If

        ' bottomNav を最前面へ出し、flowRooms に下余白を確保
        If bottomNav IsNot Nothing Then
            Try
                bottomNav.BringToFront()
                Dim navHeight As Integer = If(bottomNav.Height > 0, bottomNav.Height, 64)
                If flowRooms IsNot Nothing Then
                    flowRooms.Padding = New Padding(flowRooms.Padding.Left, flowRooms.Padding.Top, flowRooms.Padding.Right, navHeight + 12)
                End If

                ' bottomNav の下部角を丸く（ランタイム）
                If bottomNav.Width > 0 AndAlso bottomNav.Height > 0 Then
                    Dim r2 As Integer = Math.Min(24, Math.Min(bottomNav.Width \ 10, bottomNav.Height \ 2))
                    Using gp2 As New GraphicsPath()
                        Dim w2 = bottomNav.Width
                        Dim h2 = bottomNav.Height

                        ' 描画順を変えて下側の角を丸くする
                        gp2.AddLine(0, 0, w2, 0)                                   ' top edge
                        gp2.AddLine(w2, 0, w2, h2 - r2 * 2)                       ' right edge
                        gp2.AddArc(w2 - r2 * 2, h2 - r2 * 2, r2 * 2, r2 * 2, 0, 90) ' bottom-right corner
                        gp2.AddLine(w2 - r2 * 2, h2, r2, h2)                       ' bottom edge
                        gp2.AddArc(0, h2 - r2 * 2, r2 * 2, r2 * 2, 90, 90)         ' bottom-left corner
                        gp2.AddLine(0, h2 - r2 * 2, 0, 0)                          ' left edge
                        gp2.CloseFigure()
                        bottomNav.Region = New Region(gp2)
                    End Using
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    ' カードを作成して返す（呼び出し元で幅を調整）
    Private Function CreateRoomCard(title As String, count As String, time As String) As Panel
        Dim card As New Panel()
        card.Size = New System.Drawing.Size(520, 120)
        card.Margin = New Padding(6)
        card.BackColor = System.Drawing.Color.FromArgb(204, 247, 253)
        card.Padding = New Padding(12)

        ' シンプルなラベルを追加して見えるようにする
        Dim lbl As New Label()
        lbl.Text = $"{title} — {count} — {time}"
        lbl.AutoSize = False
        lbl.Dock = DockStyle.Fill
        lbl.TextAlign = ContentAlignment.MiddleLeft
        card.Controls.Add(lbl)

        Return card
    End Function

    Private Sub lblScreenTitle_Click(sender As Object, e As EventArgs)
        ' 何もしない
    End Sub

    ' btnAdd のクリックでカード追加：既存をクリアして必ず一枚だけ表示する
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If flowRooms Is Nothing Then
            Return
        End If

        flowRooms.SuspendLayout()
        Try
            ' 既存カードは削除して一枚だけ表示
            flowRooms.Controls.Clear()

            Dim card = CreateRoomCard("テストルーム", "0人", "0:00")
            If card IsNot Nothing Then
                ' flowRooms の内幅に合わせる（padding を考慮）
                Dim innerWidth As Integer = flowRooms.ClientSize.Width - flowRooms.Padding.Left - flowRooms.Padding.Right
                If innerWidth > 0 Then
                    card.Width = Math.Max(0, innerWidth - 4) ' 少し余裕を持たせる
                End If
                card.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

                flowRooms.Controls.Add(card)
                card.BringToFront()
            End If
        Finally
            flowRooms.ResumeLayout()
            flowRooms.Refresh()
        End Try
    End Sub

    Private Sub EnsureHandlers()
        If btnAdd IsNot Nothing Then
            RemoveHandler btnAdd.Click, AddressOf btnAdd_Click
            AddHandler btnAdd.Click, AddressOf btnAdd_Click
        End If

        ' btnNext が存在すれば遷移ハンドラを登録（別の画面に遷移する例）
        If Me.Controls.ContainsKey("btnNext") Then
            Dim btn = TryCast(Me.Controls("btnNext"), System.Windows.Forms.Button)
            If btn IsNot Nothing Then
                RemoveHandler btn.Click, AddressOf btnNext_Click
                AddHandler btn.Click, AddressOf btnNext_Click
            End If
        End If
    End Sub

    ' 次の画面へ遷移するボタン（例）
    Private Sub btnNext_Click(sender As Object, e As EventArgs)
        Dim nextForm As New SecondForm(Me)
        nextForm.Show()
        Me.Hide()
    End Sub

    Private Sub Form1_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    ' headerBar 用の空ハンドラ（安全化）
    Private Sub headerBar_Paint(sender As Object, e As PaintEventArgs)
        ' 必要なら描画コードを追加
    End Sub

    Private Sub bottomNav_Paint(sender As Object, e As PaintEventArgs) Handles bottomNav.Paint

    End Sub
End Class
