Imports System.Drawing
Imports System.Windows.Forms

Public Module CommonUI
    ' footerBar のレイアウト（3等分）と flow コンテンツの下余白を調整する
    Public Sub ConfigureFooterLayout(footer As Panel, navHome As Button, navRooms As Button, navFav As Button, Optional flowRooms As FlowLayoutPanel = Nothing)
        If footer Is Nothing Then Return
        Try
            footer.BringToFront()
            Dim navHeight As Integer = If(footer.Height > 0, footer.Height, 64)
            If flowRooms IsNot Nothing Then
                flowRooms.Padding = New Padding(flowRooms.Padding.Left, flowRooms.Padding.Top, flowRooms.Padding.Right, navHeight + 12)
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
        Catch ex As Exception
            ' 念のため例外は吸収（レイアウトの再試行等は呼び出し側で）
        End Try
    End Sub

    ' footer のナビ動作を登録（ホーム強調、履歴/お気に入りの遷移）
    Public Sub RegisterFooterNavigation(current As Form, navHome As Button, navRooms As Button, navFav As Button)
        If navHome IsNot Nothing Then
            AddHandler navHome.Click, Sub(sender, e)
                                          navHome.BackColor = Color.FromArgb(255, 230, 0)
                                          navHome.ForeColor = Color.Black
                                          If navRooms IsNot Nothing Then
                                              navRooms.BackColor = Color.Transparent
                                              navRooms.ForeColor = Color.White
                                          End If
                                          If navFav IsNot Nothing Then
                                              navFav.BackColor = Color.Transparent
                                              navFav.ForeColor = Color.White
                                          End If
                                      End Sub
        End If

        If navRooms IsNot Nothing Then
            AddHandler navRooms.Click, Sub(sender, e)
                                           Dim f As New HistoryForm(current)
                                           Try
                                               f.StartPosition = FormStartPosition.Manual
                                               f.ClientSize = current.ClientSize
                                               f.Location = current.Location
                                           Catch ex As Exception
                                           End Try
                                           f.Show()
                                           current.Hide()
                                       End Sub
        End If

        If navFav IsNot Nothing Then
            AddHandler navFav.Click, Sub(sender, e)
                                         Dim f As New FavoritesForm(current)
                                         Try
                                             f.StartPosition = FormStartPosition.Manual
                                             f.ClientSize = current.ClientSize
                                             f.Location = current.Location
                                         Catch ex As Exception
                                         End Try
                                         f.Show()
                                         current.Hide()
                                     End Sub
        End If
    End Sub

    ' 任意のフォームに「戻る」ボタンを登録して、閉じたら prev を Show する共通処理
    Public Sub RegisterBackNavigation(frm As Form, prev As Form, backButton As Button)
        If backButton IsNot Nothing Then
            AddHandler backButton.Click, Sub(sender, e) frm.Close()
        End If
        AddHandler frm.FormClosed, Sub(sender, e)
                                       If prev IsNot Nothing Then
                                           prev.Show()
                                       End If
                                   End Sub
    End Sub
End Module

Partial Public Class HistoryForm
    Inherits System.Windows.Forms.Form

    Private _prev As System.Windows.Forms.Form

    Public Sub New()
        InitializeComponent()
        AddHandler Me.Load, AddressOf HistoryForm_Load
    End Sub

    Public Sub New(prev As System.Windows.Forms.Form)
        Me.New()
        _prev = prev
        ' 共通の戻る処理を登録
        CommonUI.RegisterBackNavigation(Me, _prev, btnBack)
    End Sub

    Private Sub HistoryForm_Load(sender As Object, e As EventArgs)
        ' footer レイアウトを構成しナビを登録
        CommonUI.ConfigureFooterLayout(footerBar, btnNavHome, btnNavRooms, btnNavFav, flowRooms)
        CommonUI.RegisterFooterNavigation(Me, btnNavHome, btnNavRooms, btnNavFav)
        ' この画面は履歴なので強調する場合:
        btnNavRooms.BackColor = Color.FromArgb(255, 230, 0)
        btnNavRooms.ForeColor = Color.Black
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub HistoryForm_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs)
        If _prev IsNot Nothing Then
            _prev.Show()
        End If
    End Sub
End Class