Imports System.Drawing.Drawing2D

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
        End Try

        ' footer レイアウトを構成しナビを登録（共通）
        CommonUI.ConfigureFooterLayout(bottomNav, btnNavHome, btnNavRooms, btnNavFav, flowRooms)
        CommonUI.RegisterFooterNavigation(Me, btnNavHome, btnNavRooms, btnNavFav)

        ApplyRuntimeStyling()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs)
        ApplyRuntimeStyling()
    End Sub

    Private Sub ApplyRuntimeStyling()
        If btnAdd IsNot Nothing AndAlso btnAdd.Width > 0 AndAlso btnAdd.Height > 0 Then
            Try
                Using gp As New GraphicsPath()
                    gp.AddEllipse(0, 0, btnAdd.Width - 1, btnAdd.Height - 1)
                    btnAdd.Region = New Region(gp)
                End Using
            Catch ex As Exception
            End Try
        End If

        Try
            Me.Region = Nothing
        Catch ex As Exception
        End Try

        ' 共通化された footer レイアウト呼び出し（Resize 等で再配置）
        CommonUI.ConfigureFooterLayout(bottomNav, btnNavHome, btnNavRooms, btnNavFav, flowRooms)

        ' footer の角丸処理は維持（必要ならモジュール化済み関数へ移す）
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
            End Try
        End If
    End Sub

    Private Function CreateRoomCard(title As String, count As String, time As String) As Panel
        Dim card As New Panel()
        card.Size = New System.Drawing.Size(520, 120)
        card.Margin = New Padding(6)
        card.BackColor = System.Drawing.Color.FromArgb(204, 247, 253)
        card.Padding = New Padding(12)
        Dim lbl As New Label()
        lbl.Text = $"{title} — {count} — {time}"
        lbl.AutoSize = False
        lbl.Dock = DockStyle.Fill
        lbl.TextAlign = ContentAlignment.MiddleLeft
        card.Controls.Add(lbl)
        Return card
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If flowRooms Is Nothing Then Return
        flowRooms.SuspendLayout()
        Try
            flowRooms.Controls.Clear()
            Dim card = CreateRoomCard("テストルーム", "0人", "0:00")
            If card IsNot Nothing Then
                Dim innerWidth As Integer = flowRooms.ClientSize.Width - flowRooms.Padding.Left - flowRooms.Padding.Right
                If innerWidth > 0 Then
                    card.Width = Math.Max(0, innerWidth - 4)
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

        ' btnNext の登録はそのまま（存在チェック）
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

    Private Sub flowRooms_Paint(sender As Object, e As PaintEventArgs) Handles flowRooms.Paint
    End Sub

    Private Sub footerBar_Paint(sender As Object, e As PaintEventArgs) Handles footerBar.Paint
    End Sub
End Class
