' =========================
' HistoryForm.Designer 相当
' =========================
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Drawing.Drawing2D

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class HistoryForm
    Inherits System.Windows.Forms.Form

    Private _prev As System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Private contentPanel As Panel
    Private headerPanel As Panel
    Private btnTitle As Button
    Private infoPanel As Panel
    Private lblTimer As Label
    Private cmbSort As ComboBox
    Friend WithEvents flowRooms As FlowLayoutPanel
    Private backPanel As Panel
    Friend WithEvents btnBack As Button
    Friend WithEvents footerBar As Panel
    Friend WithEvents btnNavHome As Button
    Friend WithEvents btnNavRooms As Button
    Friend WithEvents btnNavFav As Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        contentPanel = New Panel()
        headerPanel = New Panel()
        btnTitle = New Button()
        infoPanel = New Panel()
        lblTimer = New Label()
        cmbSort = New ComboBox()
        flowRooms = New FlowLayoutPanel()
        backPanel = New Panel()
        btnBack = New Button()
        footerBar = New Panel()
        btnNavHome = New Button()
        btnNavRooms = New Button()
        btnNavFav = New Button()
        footerBar.SuspendLayout()
        infoPanel.SuspendLayout()
        headerPanel.SuspendLayout()
        backPanel.SuspendLayout()
        SuspendLayout()
        '
        ' contentPanel
        '
        contentPanel.BackColor = Color.White
        contentPanel.Dock = DockStyle.Fill
        contentPanel.Location = New Point(0, 0)
        contentPanel.Name = "contentPanel"
        contentPanel.Padding = New Padding(12, 0, 12, 0)
        contentPanel.Size = New Size(576, 960)
        contentPanel.TabIndex = 0
        '
        ' headerPanel
        '
        headerPanel.BackColor = Color.FromArgb(CByte(3), CByte(116), CByte(213))
        headerPanel.Dock = DockStyle.Top
        headerPanel.Location = New Point(12, 0)
        headerPanel.Name = "headerPanel"
        headerPanel.Padding = New Padding(12)
        headerPanel.Size = New Size(552, 64)
        headerPanel.TabIndex = 0
        AddHandler headerPanel.Resize, AddressOf HeaderPanel_Resize
        '
        ' btnTitle
        '
        btnTitle.BackColor = Color.FromArgb(CByte(0), CByte(184), CByte(242))
        btnTitle.FlatAppearance.BorderSize = 0
        btnTitle.FlatStyle = FlatStyle.Flat
        btnTitle.Font = New Font("Yu Gothic UI", 12.0F, FontStyle.Bold)
        btnTitle.ForeColor = Color.White
        btnTitle.Location = New Point(156, 12)
        btnTitle.Name = "btnTitle"
        btnTitle.Size = New Size(240, 36)
        btnTitle.TabIndex = 1
        btnTitle.Text = "ルーム履歴"
        btnTitle.UseVisualStyleBackColor = False
        headerPanel.Controls.Add(btnTitle)
        '
        ' infoPanel
        '
        infoPanel.Controls.Add(lblTimer)
        infoPanel.Controls.Add(cmbSort)
        infoPanel.Dock = DockStyle.Top
        infoPanel.Padding = New Padding(12, 12, 12, 8)
        infoPanel.Name = "infoPanel"
        infoPanel.Size = New Size(552, 72)
        infoPanel.TabIndex = 1
        '
        ' lblTimer
        '
        lblTimer.AutoSize = True
        lblTimer.Font = New Font("Yu Gothic UI", 12.0F, FontStyle.Bold)
        lblTimer.Location = New Point(12, 18)
        lblTimer.Name = "lblTimer"
        lblTimer.Size = New Size(93, 32)
        lblTimer.TabIndex = 2
        lblTimer.Text = "05:43:21"
        '
        ' cmbSort
        '
        cmbSort.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSort.Font = New Font("Yu Gothic UI", 10.0F)
        cmbSort.FormattingEnabled = True
        cmbSort.Items.AddRange(New Object() {"新しい順", "古い順"})
        cmbSort.Location = New Point(408, 18)
        cmbSort.Name = "cmbSort"
        cmbSort.Size = New Size(132, 36)
        cmbSort.TabIndex = 3
        cmbSort.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        contentPanel.Controls.Add(flowRooms)
        contentPanel.Controls.Add(backPanel)
        contentPanel.Controls.Add(infoPanel)
        contentPanel.Controls.Add(headerPanel)
        '
        ' flowRooms
        '
        flowRooms.AutoScroll = True
        flowRooms.Dock = DockStyle.Fill
        flowRooms.FlowDirection = FlowDirection.TopDown
        flowRooms.Location = New Point(12, 136)
        flowRooms.Name = "flowRooms"
        flowRooms.Padding = New Padding(12, 144, 12, 24)
        flowRooms.Margin = New Padding(0, 12, 0, 0)
        flowRooms.Size = New Size(552, 728)
        flowRooms.TabIndex = 4
        flowRooms.WrapContents = False
        '
        ' backPanel
        '
        backPanel.Dock = DockStyle.Bottom
        backPanel.Height = 120
        backPanel.Padding = New Padding(0, 16, 0, 24)
        backPanel.Name = "backPanel"
        backPanel.TabIndex = 6
        AddHandler backPanel.Resize, AddressOf BackPanel_Resize
        '
        ' btnBack
        '
        btnBack.BackColor = Color.FromArgb(0, 184, 242)
        btnBack.FlatAppearance.BorderSize = 0
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.Font = New Font("Yu Gothic UI", 10.0F, FontStyle.Bold)
        btnBack.ForeColor = Color.White
        btnBack.Location = New Point(180, 24)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(200, 48)
        btnBack.TabIndex = 10
        btnBack.Text = "戻る"
        btnBack.UseVisualStyleBackColor = False
        backPanel.Controls.Add(btnBack)
        '
        ' control add order for docking
        '
        contentPanel.Controls.Add(flowRooms)
        contentPanel.Controls.Add(backPanel)
        '
        ' footerBar
        '
        footerBar.BackColor = Color.FromArgb(CByte(3), CByte(116), CByte(213))
        footerBar.Controls.Add(btnNavHome)
        footerBar.Controls.Add(btnNavRooms)
        footerBar.Controls.Add(btnNavFav)
        footerBar.Dock = DockStyle.Bottom
        footerBar.Location = New Point(0, 960)
        footerBar.Name = "footerBar"
        footerBar.Size = New Size(576, 64)
        footerBar.TabIndex = 5
        '
        ' btnNavHome
        '
        btnNavHome.BackColor = Color.Transparent
        btnNavHome.FlatAppearance.BorderSize = 0
        btnNavHome.FlatStyle = FlatStyle.Flat
        btnNavHome.ForeColor = Color.White
        btnNavHome.Location = New Point(0, 8)
        btnNavHome.Name = "btnNavHome"
        btnNavHome.Size = New Size(192, 48)
        btnNavHome.TabIndex = 0
        btnNavHome.Text = "ホーム"
        btnNavHome.UseVisualStyleBackColor = False
        '
        ' btnNavRooms
        '
        btnNavRooms.BackColor = Color.Transparent
        btnNavRooms.FlatAppearance.BorderSize = 0
        btnNavRooms.FlatStyle = FlatStyle.Flat
        btnNavRooms.ForeColor = Color.White
        btnNavRooms.Location = New Point(192, 8)
        btnNavRooms.Name = "btnNavRooms"
        btnNavRooms.Size = New Size(192, 48)
        btnNavRooms.TabIndex = 1
        btnNavRooms.Text = "ルーム履歴"
        btnNavRooms.UseVisualStyleBackColor = False
        '
        ' btnNavFav
        '
        btnNavFav.BackColor = Color.Transparent
        btnNavFav.FlatAppearance.BorderSize = 0
        btnNavFav.FlatStyle = FlatStyle.Flat
        btnNavFav.ForeColor = Color.White
        btnNavFav.Location = New Point(384, 8)
        btnNavFav.Name = "btnNavFav"
        btnNavFav.Size = New Size(192, 48)
        btnNavFav.TabIndex = 2
        btnNavFav.Text = "お気に入り"
        btnNavFav.UseVisualStyleBackColor = False
        '
        ' HistoryForm
        '
        AutoScaleDimensions = New SizeF(11.0F, 28.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(576, 1024)
        Controls.Add(contentPanel)
        Controls.Add(footerBar)
        Font = New Font("Yu Gothic UI", 10.0F)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "HistoryForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ルーム履歴"
        footerBar.ResumeLayout(False)
        infoPanel.ResumeLayout(False)
        infoPanel.PerformLayout()
        headerPanel.ResumeLayout(False)
        backPanel.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

End Class

' =========================
' HistoryForm コードビハインド
' =========================
Partial Public Class HistoryForm

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(prev As System.Windows.Forms.Form)
        Me.New()
        _prev = prev
    End Sub

    ' 表示完了後にも一応幅を再調整
    Private Sub HistoryForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LoadHistoryCards()
        AdjustCardsWidth()
        CenterHeaderTitle()
        CenterBackButton()
    End Sub

    Private Sub HistoryForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        AdjustCardsWidth()
        ApplyFooterButtonLayout()
        CenterHeaderTitle()
        CenterBackButton()
    End Sub

    Private Sub HistoryForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If _prev IsNot Nothing Then
            _prev.Show()
        End If
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub

    ' --- footer 3 等分レイアウト ---
    Private Sub ApplyFooterButtonLayout()
        If footerBar Is Nothing Then Return
        Dim w = footerBar.ClientSize.Width
        Dim btnW As Integer = Math.Max(1, w \ 3)
        For i As Integer = 0 To footerBar.Controls.Count - 1
            Dim c = TryCast(footerBar.Controls(i), Button)
            If c Is Nothing Then Continue For
            c.Width = btnW
            c.Height = Math.Max(36, footerBar.ClientSize.Height - 12)
            c.Location = New Point(i * btnW, (footerBar.ClientSize.Height - c.Height) \ 2)
            c.FlatStyle = FlatStyle.Flat
            c.FlatAppearance.BorderSize = 0
        Next
    End Sub

    ' 戻るボタンを中央配置
    Private Sub CenterBackButton()
        If backPanel Is Nothing OrElse btnBack Is Nothing Then Return
        Dim x As Integer = Math.Max(0, (backPanel.ClientSize.Width - btnBack.Width) \ 2)
        Dim y As Integer = Math.Max(0, backPanel.Padding.Top)
        btnBack.Location = New Point(x, y)
    End Sub

    Private Sub BackPanel_Resize(sender As Object, e As EventArgs)
        CenterBackButton()
    End Sub

    ' ヘッダー内タイトルを中央下寄せに配置
    Private Sub CenterHeaderTitle()
        If headerPanel Is Nothing OrElse btnTitle Is Nothing Then Return
        Dim x As Integer = Math.Max(0, (headerPanel.ClientSize.Width - btnTitle.Width) \ 2)
        Dim y As Integer = Math.Max(0, headerPanel.ClientSize.Height - btnTitle.Height - 8)
        btnTitle.Location = New Point(x, y)
    End Sub

    Private Sub HeaderPanel_Resize(sender As Object, e As EventArgs)
        CenterHeaderTitle()
    End Sub

    ' --- 丸角適用 ---
    Private Sub ApplyRoundedRegion(ctrl As Control, radius As Integer)
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

    ' --- カード生成 ---
    Private Function CreateHistoryCard(title As String, innerWidth As Integer) As Panel
        Dim card As New Panel()
        card.Margin = New Padding(8, 8, 8, 12)
        card.BackColor = Color.FromArgb(204, 247, 253) ' Form1 のカード色に合わせる
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
                                   DrawHistoryCardBorder(e.Graphics, card)
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

        AddHandler card.Click, Sub(sender, e) OpenConversation(title)
        AddHandler lbl.Click, Sub(sender, e) OpenConversation(title)

        Debug.WriteLine($"[CreateHistoryCard] title=""{title}"", targetWidth={innerWidth}, finalWidth={card.Width}, height={card.Height}")
        Return card
    End Function

    ' カードの枠線と角丸を描画
    Private Sub DrawHistoryCardBorder(g As Graphics, card As Panel)
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

    ' --- データ投入 ---
    Private Sub LoadHistoryCards()
        If flowRooms Is Nothing Then
            Debug.WriteLine("[LoadHistoryCards] flowRooms is Nothing")
            Return
        End If

        flowRooms.SuspendLayout()
        Try
            flowRooms.Controls.Clear()

            Dim titles As String() = {
                "卒研の悩み部屋"
            }

            Dim baseWidth As Integer = GetInnerCardWidth()
            Debug.WriteLine($"[LoadHistoryCards] start baseWidth={baseWidth}, flowRooms.ClientSize={flowRooms.ClientSize}")

            For Each t In titles
                Dim width As Integer = If(baseWidth > 0, baseWidth, Math.Max(140, Me.ClientSize.Width - 40))
                Dim card = CreateHistoryCard(t, width)
                card.Width = width
                flowRooms.Controls.Add(card)
                Debug.WriteLine($"[LoadHistoryCards] added title=""{t}"" width={width}")
            Next
        Catch ex As Exception
            Debug.WriteLine($"[LoadHistoryCards] failed: {ex.Message}")
        Finally
            flowRooms.ResumeLayout()
            flowRooms.PerformLayout()
            flowRooms.Refresh()
            PrintFlowRoomsContents("LoadHistoryCards")
            Debug.WriteLine($"[LoadHistoryCards] done count={flowRooms.Controls.Count}")
        End Try
    End Sub

    Private Sub OpenConversation(title As String)
        Dim frm As New ConversationForm(Me, title, allowStar:=True)
        Try
            frm.StartPosition = FormStartPosition.Manual
            frm.ClientSize = Me.ClientSize
            frm.Location = Me.Location
        Catch
        End Try
        frm.Show()
        Me.Hide()
    End Sub

    Private Function GetInnerCardWidth() As Integer
        If flowRooms Is Nothing Then Return 0
        Dim innerWidth As Integer = Math.Max(0, flowRooms.ClientSize.Width - flowRooms.Padding.Left - flowRooms.Padding.Right)
        If innerWidth <= 0 Then Return 0
        ' スマホ幅に近づけるため最大幅を抑制
        Return Math.Min(innerWidth - 4, 280)
    End Function

    Private Sub AdjustCardsWidth()
        If flowRooms Is Nothing Then Return
        Dim baseWidth As Integer = GetInnerCardWidth()
        If baseWidth <= 0 Then Return

        For Each ctrl As Control In flowRooms.Controls
            If TypeOf ctrl Is Panel Then
                ctrl.Width = baseWidth
                ApplyRoundedRegion(CType(ctrl, Panel), 12)
                ' 中央寄せ：左右マージンを均等に設定
                Dim leftMargin As Integer = Math.Max(0, (flowRooms.ClientSize.Width - flowRooms.Padding.Left - flowRooms.Padding.Right - baseWidth) \ 2)
                Dim m = ctrl.Margin
                ctrl.Margin = New Padding(leftMargin, m.Top, leftMargin, m.Bottom)
                Debug.WriteLine($"[AdjustCardsWidth] apply width={baseWidth} marginL/R={leftMargin} to {ctrl.GetType().Name}, final={ctrl.Width}")
            End If
        Next

        flowRooms.PerformLayout()
        flowRooms.Refresh()
        Debug.WriteLine($"[AdjustCardsWidth] baseWidth={baseWidth}, Controls.Count={flowRooms.Controls.Count}")
        PrintFlowRoomsContents("AdjustCardsWidth")
    End Sub

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

' =========================
' 共通 UI ヘルパー
' =========================
Public Module CommonUI

    Public Sub ConfigureFooterLayout(footer As Panel,
                                     navHome As Button,
                                     navRooms As Button,
                                     navFav As Button,
                                     Optional flowRooms As FlowLayoutPanel = Nothing)

        If footer Is Nothing Then Return

        Try
            footer.BringToFront()

            Dim navHeight As Integer = If(footer.Height > 0, footer.Height, 64)
            If flowRooms IsNot Nothing Then
                flowRooms.Padding = New Padding(flowRooms.Padding.Left,
                                                flowRooms.Padding.Top,
                                                flowRooms.Padding.Right,
                                                navHeight + 12)
            End If

            If footer.Width > 0 AndAlso footer.Height > 0 Then
                Dim w = footer.ClientSize.Width
                Dim h = footer.ClientSize.Height
                Dim btnW As Integer = Math.Max(1, w \ 3)
                Dim btnH As Integer = Math.Max(24, h - 12)
                Dim topOffset As Integer = Math.Max(0, (h - btnH) \ 2)

                Dim arr As Button() = {navHome, navRooms, navFav}
                For i As Integer = 0 To arr.Length - 1
                    Dim b = arr(i)
                    If b Is Nothing Then Continue For
                    b.Dock = DockStyle.None
                    b.Anchor = AnchorStyles.None
                    b.Size = New Size(btnW, btnH)
                    b.Location = New Point(i * btnW, topOffset)
                    b.FlatStyle = FlatStyle.Flat
                    b.FlatAppearance.BorderSize = 0
                Next
            End If
        Catch
        End Try
    End Sub

    Public Sub RegisterFooterNavigation(current As Form,
                                        navHome As Button,
                                        navRooms As Button,
                                        navFav As Button,
                                        Optional activeTab As String = "Home")

        If navHome IsNot Nothing Then
            navHome.BackColor = Color.Transparent
            navHome.ForeColor = Color.White
        End If
        If navRooms IsNot Nothing Then
            navRooms.BackColor = Color.Transparent
            navRooms.ForeColor = Color.White
        End If
        If navFav IsNot Nothing Then
            navFav.BackColor = Color.Transparent
            navFav.ForeColor = Color.White
        End If

        Select Case activeTab
            Case "Home"
                If navHome IsNot Nothing Then
                    navHome.BackColor = Color.FromArgb(255, 230, 0)
                    navHome.ForeColor = Color.Black
                End If
            Case "Rooms"
                If navRooms IsNot Nothing Then
                    navRooms.BackColor = Color.FromArgb(255, 230, 0)
                    navRooms.ForeColor = Color.Black
                End If
            Case "Fav"
                If navFav IsNot Nothing Then
                    navFav.BackColor = Color.FromArgb(255, 230, 0)
                    navFav.ForeColor = Color.Black
                End If
        End Select

        If navHome IsNot Nothing Then
            AddHandler navHome.Click,
                Sub(sender, e)
                    Dim f As New Form1(current)
                    Try
                        f.StartPosition = FormStartPosition.Manual
                        f.ClientSize = current.ClientSize
                        f.Location = current.Location
                    Catch
                    End Try
                    f.Show()
                    current.Hide()
                End Sub
        End If

        If navRooms IsNot Nothing Then
            AddHandler navRooms.Click,
                Sub(sender, e)
                    If TypeOf current Is HistoryForm Then
                        Exit Sub
                    End If
                    Dim f As New HistoryForm(current)
                    Try
                        f.StartPosition = FormStartPosition.Manual
                        f.ClientSize = current.ClientSize
                        f.Location = current.Location
                    Catch
                    End Try
                    f.Show()
                    current.Hide()
                End Sub
        End If

        If navFav IsNot Nothing Then
            AddHandler navFav.Click,
                Sub(sender, e)
                    If TypeOf current Is FavoritesForm Then
                        Exit Sub
                    End If
                    Dim f As New FavoritesForm(current)
                    Try
                        f.StartPosition = FormStartPosition.Manual
                        f.ClientSize = current.ClientSize
                        f.Location = current.Location
                    Catch
                    End Try
                    f.Show()
                    current.Hide()
                End Sub
        End If
    End Sub

End Module
