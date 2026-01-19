Imports System.Drawing.Drawing2D

Partial Public Class ConversationForm
    Inherits System.Windows.Forms.Form

    Private ReadOnly _prev As System.Windows.Forms.Form
    Private ReadOnly _title As String
    Private ReadOnly _allowStar As Boolean

    Public Sub New(prev As System.Windows.Forms.Form, title As String, allowStar As Boolean)
        InitializeComponent()
        _prev = prev
        _title = title
        _allowStar = allowStar
        AddHandler Me.Load, AddressOf ConversationForm_Load
        AddHandler Me.FormClosed, AddressOf ConversationForm_FormClosed
        AddHandler btnBack.Click, AddressOf btnBack_Click
        AddHandler btnStar.Click, AddressOf btnStar_Click
    End Sub

    Private Sub ConversationForm_Load(sender As Object, e As EventArgs)
        btnTitle.Text = _title
        CenterHeaderTitle()
        CenterBackButton()

        btnStar.Visible = _allowStar

        If cmbSort IsNot Nothing Then
            cmbSort.SelectedIndex = 0
        End If

        LoadMessages()
        AdjustMessageCardsWidth()
        CommonUIHistory.ConfigureFooterLayout(footerBar, btnNavHome, btnNavRooms, btnNavFav, flowMessages)
        CommonUIHistory.RegisterFooterNavigation(Me, btnNavHome, btnNavRooms, btnNavFav, activeTab:="Rooms")
    End Sub

    Private Sub LoadMessages()
        If flowMessages Is Nothing Then Return

        flowMessages.SuspendLayout()
        Try
            flowMessages.Controls.Clear()

            ' 履歴画面ではスター表示を許可（_allowStar=True）
            Dim msgs As List(Of Tuple(Of String, Boolean)) = New List(Of Tuple(Of String, Boolean))() From {
                Tuple.Create("最近、連絡が全然出なくて…", True),
                Tuple.Create("何してますか？", False),
                Tuple.Create("次のミーティングはどうしますか？", False)
            }

            Dim baseWidth As Integer = GetInnerMessageWidth()
            Debug.WriteLine($"[LoadMessages] start baseWidth={baseWidth}, flowMessages.ClientSize={flowMessages.ClientSize}")
            For Each m In msgs
                Dim width As Integer = If(baseWidth > 0, baseWidth, Math.Max(140, Me.ClientSize.Width - 40))
                Dim card = CreateMessageCard(m.Item1, If(_allowStar, m.Item2, False), width)
                card.Width = width
                flowMessages.Controls.Add(card)
                Debug.WriteLine($"[LoadMessages] added text=""{m.Item1}"" width={width} allowStar={_allowStar} showStar={If(_allowStar, m.Item2, False)}")
            Next
        Finally
            flowMessages.ResumeLayout()
            flowMessages.PerformLayout()
            flowMessages.Refresh()
            PrintFlowMessagesContents("LoadMessages")
        End Try
    End Sub

    Private Function CreateMessageCard(text As String, showStar As Boolean, innerWidth As Integer) As Panel
        Dim card As New Panel()
        card.Margin = New Padding(8, 8, 8, 12)
        card.BackColor = Color.FromArgb(204, 247, 253)
        card.Padding = New Padding(16)
        card.Height = 80
        card.Width = Math.Max(120, innerWidth)
        card.MinimumSize = New Size(200, 80)

        ' ボタンらしい外観設定
        card.BorderStyle = BorderStyle.None
        card.Cursor = Cursors.Hand

        ' レイアウト：左にスター、右にメッセージ
        Dim star As New Label()
        star.AutoSize = False
        star.Width = 32
        star.Dock = DockStyle.Left
        star.TextAlign = ContentAlignment.MiddleCenter
        star.Font = New Font("Yu Gothic UI", 14.0F, FontStyle.Bold)
        star.Text = If(showStar, "★", "☆")
        star.ForeColor = If(showStar, Color.Gold, Color.Silver)
        star.Cursor = Cursors.Hand

        Dim lbl As New Label()
        lbl.Text = text
        lbl.Dock = DockStyle.Fill
        lbl.TextAlign = ContentAlignment.MiddleCenter
        lbl.Font = New Font("Yu Gothic UI", 11.0F, FontStyle.Regular)
        lbl.ForeColor = Color.Black
        lbl.BackColor = Color.Transparent
        lbl.Cursor = Cursors.Hand

        card.Controls.Add(lbl)
        card.Controls.Add(star)
        card.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
        card.Visible = True
        card.PerformLayout()

        ' カスタム描画で太い枠線を実装
        AddHandler card.Paint, Sub(sender As Object, e As PaintEventArgs)
                                   DrawMessageCardBorder(e.Graphics, card)
                               End Sub

        ' ホバー効果
        AddHandler card.MouseEnter, Sub(sender As Object, e As EventArgs)
                                        card.BackColor = Color.FromArgb(180, 235, 245)
                                        card.Invalidate()
                                    End Sub

        AddHandler card.MouseLeave, Sub(sender As Object, e As EventArgs)
                                        card.BackColor = Color.FromArgb(204, 247, 253)
                                        card.Invalidate()
                                    End Sub

        ' マウスダウン時の視覚的フィードバック
        AddHandler card.MouseDown, Sub(sender As Object, e As MouseEventArgs)
                                       card.BackColor = Color.FromArgb(160, 220, 235)
                                   End Sub

        AddHandler card.MouseUp, Sub(sender As Object, e As MouseEventArgs)
                                     card.BackColor = Color.FromArgb(180, 235, 245)
                                 End Sub

        AddHandler card.Click, Sub(sender, e) OpenDirectMessage(text)
        AddHandler lbl.Click, Sub(sender, e) OpenDirectMessage(text)
        AddHandler star.Click, Sub(sender, e) OpenDirectMessage(text)

        Debug.WriteLine($"[CreateMessageCard] text=""{text}"" targetWidth={innerWidth} finalWidth={card.Width} showStar={showStar}")
        Return card
    End Function

    ' カードの枠線と角丸を描画
    Private Sub DrawMessageCardBorder(g As Graphics, card As Panel)
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim radius As Integer = 12
        Dim borderWidth As Integer = 3
        Dim borderColor As Color = Color.FromArgb(3, 116, 213)

        Using path As New Drawing2D.GraphicsPath()
            Dim rect As New Rectangle(borderWidth \ 2, borderWidth \ 2,
                                     card.Width - borderWidth - 1,
                                     card.Height - borderWidth - 1)

            path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90)
            path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90)
            path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90)
            path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90)
            path.CloseFigure()

            Using pen As New Pen(borderColor, borderWidth)
                pen.Alignment = Drawing2D.PenAlignment.Inset
                g.DrawPath(pen, path)
            End Using
        End Using
    End Sub

    Private Sub OpenDirectMessage(text As String)
        Dim frm As New DmForm(Me, _title & " のDM")
        Try
            frm.StartPosition = FormStartPosition.Manual
            frm.ClientSize = Me.ClientSize
            frm.Location = Me.Location
        Catch
        End Try
        frm.Show()
        Me.Hide()
    End Sub

    Private Function GetInnerMessageWidth() As Integer
        If flowMessages Is Nothing Then Return 0
        Dim innerWidth As Integer = Math.Max(0, flowMessages.ClientSize.Width - flowMessages.Padding.Left - flowMessages.Padding.Right)
        If innerWidth <= 0 Then Return 0
        Return Math.Min(innerWidth - 4, 280)
    End Function

    Private Sub AdjustMessageCardsWidth()
        If flowMessages Is Nothing Then Return
        Dim baseWidth As Integer = GetInnerMessageWidth()
        If baseWidth <= 0 Then Return

        For Each ctrl As Control In flowMessages.Controls
            If TypeOf ctrl Is Panel Then
                ctrl.Width = baseWidth
                ApplyRoundedRegion(CType(ctrl, Panel), 12)
                Dim leftMargin As Integer = Math.Max(0, (flowMessages.ClientSize.Width - flowMessages.Padding.Left - flowMessages.Padding.Right - baseWidth) \ 2)
                Dim m = ctrl.Margin
                ctrl.Margin = New Padding(leftMargin, m.Top, leftMargin, m.Bottom)
            End If
        Next

        flowMessages.PerformLayout()
        flowMessages.Refresh()
        Debug.WriteLine($"[AdjustMessageCardsWidth] baseWidth={baseWidth}, Controls.Count={flowMessages.Controls.Count}")
        PrintFlowMessagesContents("AdjustMessageCardsWidth")
    End Sub

    Private Sub PrintFlowMessagesContents(caller As String)
        Try
            If flowMessages Is Nothing Then
                Debug.WriteLine($"[{caller}] flowMessages is Nothing")
                Return
            End If

            Debug.WriteLine($"[{caller}] flowMessages.ClientSize={flowMessages.ClientSize}, Controls.Count={flowMessages.Controls.Count}")
            For i As Integer = 0 To flowMessages.Controls.Count - 1
                Dim ctrl = flowMessages.Controls(i)
                Debug.WriteLine($"[{caller}] Index={i} Type={ctrl.GetType().Name} Visible={ctrl.Visible} Size={ctrl.Size} Location={ctrl.Location}")
                For Each ch As Control In ctrl.Controls
                    If TypeOf ch Is Label Then
                        Debug.WriteLine($"[{caller}]   Child Label.Text = ""{ch.Text}""")
                    End If
                Next
            Next
        Catch ex As Exception
            Debug.WriteLine($"[PrintFlowMessagesContents] failed: {ex.Message}")
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub ConversationForm_FormClosed(sender As Object, e As FormClosedEventArgs)
        If _prev IsNot Nothing Then
            _prev.Show()
        End If
    End Sub

    Private Sub HeaderPanel_Resize(sender As Object, e As EventArgs)
        CenterHeaderTitle()
    End Sub

    Private Sub BackPanel_Resize(sender As Object, e As EventArgs)
        CenterBackButton()
    End Sub

    Private Sub ConversationForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        AdjustMessageCardsWidth()
        CenterHeaderTitle()
        CenterBackButton()
    End Sub

    Private Sub ConversationForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        AdjustMessageCardsWidth()
        CenterHeaderTitle()
        CenterBackButton()
    End Sub

    Private Sub CenterHeaderTitle()
        If headerPanel Is Nothing OrElse btnTitle Is Nothing Then Return
        Dim x As Integer = Math.Max(0, (headerPanel.ClientSize.Width - btnTitle.Width) \ 2)
        Dim y As Integer = Math.Max(0, headerPanel.ClientSize.Height - btnTitle.Height - 8)
        btnTitle.Location = New Point(x, y)
    End Sub

    Private Sub CenterBackButton()
        If backPanel Is Nothing OrElse btnBack Is Nothing Then Return
        Dim x As Integer = Math.Max(0, (backPanel.ClientSize.Width - btnBack.Width) \ 2)
        Dim y As Integer = Math.Max(0, backPanel.Padding.Top)
        btnBack.Location = New Point(x, y)
    End Sub

    Private Sub ApplyRoundedRegion(ctrl As Control, radius As Integer)
        If ctrl Is Nothing Then Return
        Try
            Dim r As New Rectangle(0, 0, ctrl.Width, ctrl.Height)
            Using gp As New GraphicsPath()
                Dim d As Integer = radius * 2
                gp.AddArc(r.X, r.Y, d, d, 180, 90)
                gp.AddArc(r.Right - d, r.Y, d, d, 270, 90)
                gp.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90)
                gp.AddArc(r.X, r.Bottom - d, d, d, 90, 90)
                gp.CloseAllFigures()
                ctrl.Region = New Region(gp)
            End Using
        Catch
        End Try
    End Sub

    Private Sub btnStar_Click(sender As Object, e As EventArgs)
        ' 簡易トグル
        If btnStar.BackColor = Color.Gold Then
            btnStar.BackColor = Color.LightGray
            btnStar.ForeColor = Color.Black
        Else
            btnStar.BackColor = Color.Gold
            btnStar.ForeColor = Color.Black
        End If
    End Sub

End Class

