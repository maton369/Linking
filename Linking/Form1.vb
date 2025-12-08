Imports System.Drawing.Drawing2D
Imports System.Diagnostics

Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    Private ReadOnly _prev As System.Windows.Forms.Form

    Private ReadOnly Property bottomNav As Panel
        Get
            Return footerBar
        End Get
    End Property

    Public Sub New()
        InitializeComponent()
        AddHandler Me.Load, AddressOf Form1_Load
        AddHandler Me.Resize, AddressOf Form1_Resize
        AddHandler Me.Shown, AddressOf Form1_Shown

        If bottomNav IsNot Nothing Then
            AddHandler bottomNav.Paint, AddressOf bottomNav_Paint
        End If

        _prev = Nothing
    End Sub

    Public Sub New(prev As System.Windows.Forms.Form)
        Me.New()
        Dim fi = Me.GetType().GetField("_prev", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
        If fi IsNot Nothing Then
            fi.SetValue(Me, prev)
        End If
        AddHandler Me.FormClosed, AddressOf Form1_FormClosed
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs)
        If _prev IsNot Nothing Then
            _prev.Show()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs)
        EnsureHandlers()

        Try
            If _prev IsNot Nothing Then
                Me.StartPosition = FormStartPosition.Manual
                Me.ClientSize = _prev.ClientSize
                Me.Location = _prev.Location
            End If
        Catch ex As Exception
            Debug.WriteLine($"[Form1_Load] prev sizing failed: {ex.Message}")
        End Try

        ' ---- レイアウトの安定化（Dock のみ明示・Z オーダーはデザイナの設定を尊重）----
        Me.SuspendLayout()
        Try
            If headerBar IsNot Nothing Then
                headerBar.Dock = DockStyle.Top
                headerBar.Location = New Point(0, 0)
            End If

            If Me.Controls.ContainsKey("panelSearch") AndAlso panelSearch IsNot Nothing Then
                panelSearch.Dock = DockStyle.Top
            End If

            If footerBar IsNot Nothing Then
                footerBar.Dock = DockStyle.Bottom
            End If

            If flowRooms IsNot Nothing Then
                flowRooms.Dock = DockStyle.Fill
            End If
        Catch ex As Exception
            Debug.WriteLine($"[Form1_Load] layout stabilization failed: {ex.Message}")
        Finally
            Me.ResumeLayout()
        End Try

        ' footer レイアウトを構成（位置のみ）とナビ登録（Load 時に一度だけ）
        CommonUI.ConfigureFooterLayout(bottomNav, btnNavHome, btnNavRooms, btnNavFav, flowRooms)
        CommonUI.RegisterFooterNavigation(Me, btnNavHome, btnNavRooms, btnNavFav)

        ApplyRuntimeStyling()
        ' カード追加は Shown で実行（表示確定後）
    End Sub

    ' フォーム表示直後に確実にカードを一つ表示する
    Private Sub Form1_Shown(sender As Object, e As EventArgs)
        ' Shown の時点で最終サイズが確定しているので再配置してカード表示
        CommonUI.ConfigureFooterLayout(bottomNav, btnNavHome, btnNavRooms, btnNavFav, flowRooms)
        EnsureInitialCard()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs)
        ApplyRuntimeStyling()
        AdjustCardsWidth()
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
                Debug.WriteLine($"[ApplyRuntimeStyling] btnAdd round failed: {ex.Message}")
            End Try
        End If

        ' フォーム本体の角丸は無効化（矩形に戻す）
        Try
            Me.Region = Nothing
        Catch ex As Exception
        End Try

        ' footer レイアウトの再構成（Resize 等で再配置）
        CommonUI.ConfigureFooterLayout(bottomNav, btnNavHome, btnNavRooms, btnNavFav, flowRooms)

        ' footer の下部角丸（既存挙動を維持）
        If bottomNav IsNot Nothing AndAlso bottomNav.Width > 0 AndAlso bottomNav.Height > 0 Then
            Try
                Dim r2 As Integer = Math.Min(24, Math.Min(bottomNav.Width \ 10, bottomNav.Height \ 2))
                Using gp2 As New GraphicsPath()
                    Dim w3 = bottomNav.Width
                    Dim h3 = bottomNav.Height
                    gp2.AddLine(0, 0, w3, 0)
                    gp2.AddLine(w3, 0, w3, h3 - r2 * 2)
                    gp2.AddArc(w3 - r2 * 2, h3 - r2 * 2, r2 * 2, r2 * 2, 0, 90)
                    gp2.AddLine(w3 - r2 * 2, h3, r2, h3)
                    gp2.AddArc(0, h3 - r2 * 2, r2 * 2, r2 * 2, 90, 90)
                    gp2.AddLine(0, h3 - r2 * 2, 0, 0)
                    gp2.CloseFigure()
                    bottomNav.Region = New Region(gp2)
                End Using
            Catch ex As Exception
                Debug.WriteLine($"[ApplyRuntimeStyling] footer rounding failed: {ex.Message}")
            End Try
        End If
    End Sub

    Private Function CreateRoomCard(title As String, count As String, time As String) As Panel
        Dim card As New Panel()
        card.Margin = New Padding(6)
        card.BackColor = System.Drawing.Color.FromArgb(204, 247, 253)
        card.Padding = New Padding(12)

        ' 高さ固定、幅は追加時に調整する
        card.Height = 120
        card.Width = 520

        Dim lbl As New Label()
        lbl.Text = String.Format("{0} — {1} — {2}", title, count, time)
        lbl.AutoSize = False
        lbl.Dock = DockStyle.Fill
        lbl.TextAlign = ContentAlignment.MiddleLeft
        lbl.ForeColor = Color.Black
        lbl.BackColor = Color.Transparent

        lbl.Font = Me.Font
        card.Controls.Add(lbl)
        lbl.BringToFront()

        card.Visible = True
        card.PerformLayout()
        Return card
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If flowRooms Is Nothing Then Return

        flowRooms.SuspendLayout()
        Try
            flowRooms.Controls.Clear()

            Dim card = CreateRoomCard("満員電車", "32人", "1:00:00")
            If card IsNot Nothing Then
                Dim innerWidth As Integer = Math.Max(0, flowRooms.ClientSize.Width - flowRooms.Padding.Left - flowRooms.Padding.Right)
                If innerWidth > 0 Then
                    card.Width = Math.Max(0, innerWidth - 4)
                Else
                    card.Width = Math.Max(520, Me.ClientSize.Width - 40)
                End If
                flowRooms.Controls.Add(card)
                ' FlowLayoutPanel 管理につき Anchor は不要だが安全化しておく
                card.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                card.BringToFront()
            End If
        Finally
            flowRooms.ResumeLayout()
            flowRooms.PerformLayout()
            flowRooms.Refresh()
            PrintFlowRoomsContents("btnAdd_Click")
        End Try
    End Sub

    Private Sub EnsureHandlers()
        If btnAdd IsNot Nothing Then
            RemoveHandler btnAdd.Click, AddressOf btnAdd_Click
            AddHandler btnAdd.Click, AddressOf btnAdd_Click
        End If

        If Me.Controls.ContainsKey("btnNext") Then
            Dim btn = TryCast(Me.Controls("btnNext"), System.Windows.Forms.Button)
            If btn IsNot Nothing Then
                RemoveHandler btn.Click, AddressOf btnNext_Click
                AddHandler btn.Click, AddressOf btnNext_Click
            End If
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs)
        Dim nextForm As New SecondForm(Me)
        nextForm.Show()
        Me.Hide()
    End Sub

    Private Sub headerBar_Paint(sender As Object, e As PaintEventArgs)
    End Sub

    Private Sub bottomNav_Paint(sender As Object, e As PaintEventArgs)
    End Sub

    ' カードが出ている状態で Paint が呼ばれたらデバッグ出力
    Private Sub flowRooms_Paint(sender As Object, e As PaintEventArgs) Handles flowRooms.Paint
        Try
            If flowRooms IsNot Nothing AndAlso flowRooms.Controls.Count > 0 Then
                PrintFlowRoomsContents("flowRooms_Paint")
            Else
                Debug.WriteLine("[flowRooms_Paint] No cards in flowRooms.")
            End If
        Catch ex As Exception
            Debug.WriteLine($"[flowRooms_Paint] Exception: {ex.Message}")
        End Try
    End Sub

    Private Sub footerBar_Paint(sender As Object, e As PaintEventArgs) Handles footerBar.Paint
    End Sub

    ' 起動時にカードを必ず複数表示する（デバッグ用途）
    Private Sub EnsureInitialCard()
        Try
            If flowRooms Is Nothing Then
                Debug.WriteLine("[EnsureInitialCard] flowRooms is Nothing")
                Return
            End If

            flowRooms.SuspendLayout()
            flowRooms.Controls.Clear()

            Dim card = CreateRoomCard("満員電車", "32人", "1:00:00")
            Dim innerWidth As Integer = Math.Max(0, flowRooms.ClientSize.Width - flowRooms.Padding.Left - flowRooms.Padding.Right)
            If innerWidth > 0 Then
                card.Width = Math.Max(0, innerWidth - 4)
            Else
                card.Width = Math.Max(520, Me.ClientSize.Width - 40)
            End If

            flowRooms.Controls.Add(card)
            card.BringToFront()
            flowRooms.ResumeLayout()
            flowRooms.PerformLayout()
            flowRooms.Refresh()

            PrintFlowRoomsContents("EnsureInitialCard")
        Catch ex As Exception
            Debug.WriteLine($"[EnsureInitialCard] failed: {ex.Message}")
        End Try
    End Sub

    Private Sub AdjustCardsWidth()
        If flowRooms Is Nothing Then Return
        Dim innerWidth As Integer = Math.Max(0, flowRooms.ClientSize.Width - flowRooms.Padding.Left - flowRooms.Padding.Right)
        For Each ctrl As Control In flowRooms.Controls
            If TypeOf ctrl Is Panel Then
                If innerWidth > 0 Then
                    ctrl.Width = Math.Max(0, innerWidth - 4)
                End If
            End If
        Next
        flowRooms.PerformLayout()
        flowRooms.Refresh()
        Debug.WriteLine($"[AdjustCardsWidth] flowRooms.ClientSize={flowRooms.ClientSize}, Controls.Count={flowRooms.Controls.Count}")
    End Sub

    ' flowRooms の内容を出力（デバッグ用）
    Private Sub PrintFlowRoomsContents(caller As String)
        Try
            If flowRooms Is Nothing Then
                Debug.WriteLine($"[{caller}] flowRooms is Nothing")
                Return
            End If

            Debug.WriteLine($"[{caller}] flowRooms.ClientSize={flowRooms.ClientSize}, Controls.Count={flowRooms.Controls.Count}")
            For i As Integer = 0 To flowRooms.Controls.Count - 1
                Dim ctrl = flowRooms.Controls(i)
                Debug.WriteLine($"[{caller}] Index={i} Type={ctrl.GetType().Name} Visible={ctrl.Visible} Size={ctrl.Size} Location={ctrl.Location}")
                For Each ch As Control In ctrl.Controls
                    If TypeOf ch Is Label Then
                        Debug.WriteLine($"[{caller}]   Child Label.Text = ""{ch.Text}""")
                    End If
                Next
            Next
        Catch ex As Exception
            Debug.WriteLine($"[PrintFlowRoomsContents] failed: {ex.Message}")
        End Try
    End Sub
End Class
