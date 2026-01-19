Partial Public Class FavoritesForm
    Inherits System.Windows.Forms.Form

    Private _prev As System.Windows.Forms.Form

    Public Sub New()
        InitializeComponent()
        AddHandler Me.Load, AddressOf FavoritesForm_Load
    End Sub

    Public Sub New(prev As System.Windows.Forms.Form)
        Me.New()
        _prev = prev
        ' ���ʂ̖߂鏈����o�^�iCommonUIHistory ���g�p�j
        CommonUIHistory.RegisterBackNavigation(Me, _prev, btnBack)
    End Sub

    Private Sub FavoritesForm_Load(sender As Object, e As EventArgs)
        ' footer ���C�A�E�g���\�����A�i�r�̋��������ʉ�
        CommonUIHistory.ConfigureFooterLayout(footerBar, btnNavHome, btnNavRooms, btnNavFav, flowRooms)

        ' ���̉�ʂ́u���C�ɓ���v�^�u���A�N�e�B�u�Ƃ��ċ����\��
        CommonUIHistory.RegisterFooterNavigation(Me, btnNavHome, btnNavRooms, btnNavFav, activeTab:="Fav")

        LoadFavoriteCards()
        CenterBackButton()
        CenterHeaderTitle()
    End Sub

    ' シンプルなカード生成（HistoryForm と同等スタイル）
    Private Function CreateFavoriteCard(title As String, innerWidth As Integer) As Panel
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

        Dim lbl As New Label()
        lbl.Text = title
        lbl.Dock = DockStyle.Fill
        lbl.TextAlign = ContentAlignment.MiddleCenter
        lbl.Font = New Font("Yu Gothic UI", 11.0F, FontStyle.Regular)
        lbl.ForeColor = Color.Black
        lbl.BackColor = Color.Transparent
        lbl.Cursor = Cursors.Hand

        card.Controls.Add(lbl)
        card.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
        card.Visible = True
        card.PerformLayout()

        ' カスタム描画で太い枠線を実装
        AddHandler card.Paint, Sub(sender As Object, e As PaintEventArgs)
                                   DrawCardBorder(e.Graphics, card)
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

        AddHandler card.Click, Sub(sender, e) OpenConversation(title, allowStar:=False)
        AddHandler lbl.Click, Sub(sender, e) OpenConversation(title, allowStar:=False)

        Return card
    End Function

    ' カードの枠線と角丸を描画
    Private Sub DrawCardBorder(g As Graphics, card As Panel)
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

    Private Sub LoadFavoriteCards()
        If flowRooms Is Nothing Then Return

        flowRooms.SuspendLayout()
        Try
            flowRooms.Controls.Clear()
            Dim titles As String() = {"卒研の悩み部屋", "暇つぶし"}
            Dim baseWidth As Integer = GetInnerCardWidth()
            For Each t In titles
                Dim width As Integer = If(baseWidth > 0, baseWidth, Math.Max(140, Me.ClientSize.Width - 40))
                Dim card = CreateFavoriteCard(t, width)
                card.Width = width
                flowRooms.Controls.Add(card)
                ' 中央寄せマージン
                Dim leftMargin As Integer = Math.Max(0, (flowRooms.ClientSize.Width - flowRooms.Padding.Left - flowRooms.Padding.Right - width) \ 2)
                Dim m = card.Margin
                card.Margin = New Padding(leftMargin, m.Top, leftMargin, m.Bottom)
            Next
        Finally
            flowRooms.ResumeLayout()
            flowRooms.PerformLayout()
            flowRooms.Refresh()
        End Try
    End Sub

    Private Function GetInnerCardWidth() As Integer
        If flowRooms Is Nothing Then Return 0
        Dim innerWidth As Integer = Math.Max(0, flowRooms.ClientSize.Width - flowRooms.Padding.Left - flowRooms.Padding.Right)
        If innerWidth <= 0 Then Return 0
        Return Math.Min(innerWidth - 4, 280)
    End Function

    Private Sub OpenConversation(title As String, allowStar As Boolean)
        Dim frm As New ConversationForm(Me, title, allowStar)
        Try
            frm.StartPosition = FormStartPosition.Manual
            frm.ClientSize = Me.ClientSize
            frm.Location = Me.Location
        Catch
        End Try
        frm.Show()
        Me.Hide()
    End Sub

    Private Sub CenterBackButton()
        If backPanel Is Nothing OrElse btnBack Is Nothing Then Return
        Dim x As Integer = Math.Max(0, (backPanel.ClientSize.Width - btnBack.Width) \ 2)
        Dim y As Integer = Math.Max(0, backPanel.Padding.Top)
        btnBack.Location = New Point(x, y)
    End Sub

    Private Sub CenterHeaderTitle()
        If headerPanel Is Nothing OrElse btnTitle Is Nothing Then Return
        Dim x As Integer = Math.Max(0, (headerPanel.ClientSize.Width - btnTitle.Width) \ 2)
        Dim y As Integer = Math.Max(0, headerPanel.ClientSize.Height - btnTitle.Height - 8)
        btnTitle.Location = New Point(x, y)
    End Sub

    ' リサイズ時ハンドラ（デザイナで AddHandler 済み）
    Private Sub HeaderPanel_Resize(sender As Object, e As EventArgs)
        CenterHeaderTitle()
    End Sub

    Private Sub BackPanel_Resize(sender As Object, e As EventArgs)
        CenterBackButton()
    End Sub

    ' 角丸適用（HistoryForm と同等）
    Private Sub ApplyRoundedRegion(ctrl As Control, radius As Integer)
        If ctrl Is Nothing Then Return
        Try
            Dim r As New Rectangle(0, 0, ctrl.Width, ctrl.Height)
            Using gp As New Drawing2D.GraphicsPath()
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

End Class
