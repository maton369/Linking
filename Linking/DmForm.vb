Imports System.Drawing.Drawing2D

Partial Public Class DmForm
    Inherits System.Windows.Forms.Form

    Private ReadOnly _prev As System.Windows.Forms.Form
    Private ReadOnly _title As String

    ' ★ 固定メッセージ幅（ここをいじれば一括で変えられる）
    Private Const FIXED_MESSAGE_WIDTH As Integer = 420

    Public Sub New(prev As System.Windows.Forms.Form, Optional title As String = "DM画面")
        InitializeComponent()
        _prev = prev
        _title = title
        AddHandler Me.Load, AddressOf DmForm_Load
        AddHandler Me.FormClosed, AddressOf DmForm_FormClosed
        AddHandler btnBack.Click, AddressOf btnBack_Click
    End Sub

    Private Sub DmForm_Load(sender As Object, e As EventArgs)
        lblTitle.Text = _title
        LoadDMs()
        ApplyFooter()
        CenterHeaderTitle()
    End Sub

    Private Sub DmForm_FormClosed(sender As Object, e As FormClosedEventArgs)
        If _prev IsNot Nothing Then
            _prev.Show()
        End If
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub ApplyFooter()
        CommonUIHistory.ConfigureFooterLayout(footerBar, btnNavHome, btnNavRooms, btnNavFav, flowDM)
        CommonUIHistory.RegisterFooterNavigation(Me, btnNavHome, btnNavRooms, btnNavFav, activeTab:="Rooms")
    End Sub

    Private Sub LoadDMs()
        If flowDM Is Nothing Then Return
        flowDM.SuspendLayout()
        Try
            flowDM.Controls.Clear()

            Dim msgs As Tuple(Of String, Boolean, Boolean)() = {
                Tuple.Create("最近、進捗が全然出なくて焦っています", False, True),
                Tuple.Create("自分もまったく同じです…。今日は割り切って文献だけ読む日にします！", False, False),
                Tuple.Create("なるほど…！やることを絞るの、良さそうですね。気持ちが少し楽になりました。", True, True),
                Tuple.Create("無理に全部やろうとすると余計に進まなくなるんですよね。一緒に少しずつ進めましょう！", False, False)
            }

            ' ★ 幅は常に固定値
            Dim width As Integer = FIXED_MESSAGE_WIDTH

            For Each m In msgs
                Dim card = CreateBubble(m.Item1, m.Item2, m.Item3, width)
                card.Width = width
                flowDM.Controls.Add(card)
            Next
        Finally
            flowDM.ResumeLayout()
            flowDM.PerformLayout()
            flowDM.Refresh()
        End Try
    End Sub

    ' ★ もう可変幅は使わないので GetInnerMessageWidth は削除／未使用でOK

    Private Function CreateBubble(text As String, isMe As Boolean, highlight As Boolean, innerWidth As Integer) As Panel
        Dim card As New Panel()
        ' 左右の余白は固定。ここを変えると位置も変えられる
        card.Margin = New Padding(40, 8, 40, 12)
        card.BackColor = If(highlight, Color.FromArgb(0, 184, 242), Color.FromArgb(238, 238, 238))
        card.Padding = New Padding(12)
        card.Height = 80
        card.Width = innerWidth
        card.MinimumSize = New Size(200, 80)
        card.Anchor = AnchorStyles.Top Or AnchorStyles.Left

        Dim lbl As New Label()
        lbl.Text = text
        lbl.Dock = DockStyle.Fill
        lbl.TextAlign = ContentAlignment.MiddleLeft
        lbl.Font = New Font("Yu Gothic UI", 10.5F, FontStyle.Regular)
        lbl.ForeColor = If(highlight, Color.White, Color.Black)
        lbl.BackColor = Color.Transparent

        card.Controls.Add(lbl)
        card.Visible = True
        card.PerformLayout()

        ApplyRoundedRegion(card, 12)

        Return card
    End Function

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

    Private Sub DmForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ApplyFooter()
        CenterHeaderTitle()
    End Sub

    Private Sub DmForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ApplyFooter()
        CenterHeaderTitle()
        ' ★ 幅は固定なのでここでは何もしない
    End Sub

    Private Sub CenterHeaderTitle()
        If headerPanel Is Nothing OrElse lblTitle Is Nothing Then Return
        Dim x As Integer = Math.Max(0, (headerPanel.ClientSize.Width - lblTitle.Width) \ 2)
        Dim y As Integer = Math.Max(0, headerPanel.ClientSize.Height - lblTitle.Height - 8)
        lblTitle.Location = New Point(x, y)
    End Sub

End Class
