Imports System.Drawing
Imports System.Windows.Forms

' =========================
' ���� UI �w���p�[�i������ʗp�j
' =========================
Public Module CommonUIHistory

    ' footerBar �̃��C�A�E�g�i3�����j�� flow �R���e���c�̉��]���𒲐�����
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
                    b.FlatAppearance.BorderSize = 2
                    b.FlatAppearance.BorderColor = Color.FromArgb(3, 116, 213)
                    b.Cursor = Cursors.Hand
                    b.Font = New Font("Yu Gothic UI", 10.0F, FontStyle.Regular)
                Next
            End If
        Catch ex As Exception
            ' ���C�A�E�g�G���[�͈���Ԃ��i�v���I�łȂ����߁j
        End Try
    End Sub

    ' footer �̃i�r�����o�^
    ' activeTab: "Home" / "Rooms" / "Fav" �̂����ꂩ��n���Č��݉�ʂ������\��
    Public Sub RegisterFooterNavigation(current As Form,
                                        navHome As Button,
                                        navRooms As Button,
                                        navFav As Button,
                                        Optional activeTab As String = "Home")

        ' �܂��S�{�^�����f�t�H���g�i���߁{�������j�ɖ߂�
        If navHome IsNot Nothing Then
            navHome.BackColor = Color.Transparent
            navHome.ForeColor = Color.White
            AddNavButtonHoverEffect(navHome, False)
        End If
        If navRooms IsNot Nothing Then
            navRooms.BackColor = Color.Transparent
            navRooms.ForeColor = Color.White
            AddNavButtonHoverEffect(navRooms, False)
        End If
        If navFav IsNot Nothing Then
            navFav.BackColor = Color.Transparent
            navFav.ForeColor = Color.White
            AddNavButtonHoverEffect(navFav, False)
        End If

        ' �A�N�e�B�u�^�u�����F�ŋ���
        Select Case activeTab
            Case "Home"
                If navHome IsNot Nothing Then
                    navHome.BackColor = Color.FromArgb(255, 230, 0)
                    navHome.ForeColor = Color.Black
                    AddNavButtonHoverEffect(navHome, True)
                End If
            Case "Rooms"
                If navRooms IsNot Nothing Then
                    navRooms.BackColor = Color.FromArgb(255, 230, 0)
                    navRooms.ForeColor = Color.Black
                    AddNavButtonHoverEffect(navRooms, True)
                End If
            Case "Fav"
                If navFav IsNot Nothing Then
                    navFav.BackColor = Color.FromArgb(255, 230, 0)
                    navFav.ForeColor = Color.Black
                    AddNavButtonHoverEffect(navFav, True)
                End If
        End Select

        ' ----- �N���b�N���̑J�ڃn���h�� -----

        ' Home �{�^��
        If navHome IsNot Nothing Then
            RemoveHandler navHome.Click, Nothing
            AddHandler navHome.Click,
                Sub(sender, e)
                    Dim f As New Form1(current)
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

        ' Rooms�i�����j�{�^�� - �O��ʎQ�Ƃ�n��
        If navRooms IsNot Nothing Then
            RemoveHandler navRooms.Click, Nothing
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
                    Catch ex As Exception
                    End Try
                    f.Show()
                    current.Hide()
                End Sub
        End If

        ' ���C�ɓ���{�^��
        If navFav IsNot Nothing Then
            RemoveHandler navFav.Click, Nothing
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
                    Catch ex As Exception
                    End Try
                    f.Show()
                    current.Hide()
                End Sub
        End If
    End Sub

    ' �C�ӂ̃t�H�[���Ɂu�߂�v�{�^����o�^���āA������ prev �� Show ���鋤�ʏ���
    Public Sub RegisterBackNavigation(frm As Form, prev As Form, backButton As Button)
        If backButton IsNot Nothing Then
            AddHandler backButton.Click,
                Sub(sender, e)
                    frm.Close()
                End Sub
        End If

        AddHandler frm.FormClosed,
            Sub(sender, e)
                If prev IsNot Nothing Then
                    prev.Show()
                End If
            End Sub
    End Sub

    ' ナビゲーションボタンにホバー効果を追加
    Private Sub AddNavButtonHoverEffect(btn As Button, isActive As Boolean)
        If btn Is Nothing Then Return

        ' 既存のハンドラーを削除
        RemoveHandler btn.MouseEnter, Nothing
        RemoveHandler btn.MouseLeave, Nothing
        RemoveHandler btn.MouseDown, Nothing
        RemoveHandler btn.MouseUp, Nothing

        If isActive Then
            ' アクティブなボタン（黄色）のホバー効果
            Dim normalColor As Color = Color.FromArgb(255, 230, 0)
            Dim hoverColor As Color = Color.FromArgb(255, 210, 0)
            Dim clickColor As Color = Color.FromArgb(240, 195, 0)

            AddHandler btn.MouseEnter, Sub(sender, e)
                                           btn.BackColor = hoverColor
                                       End Sub

            AddHandler btn.MouseLeave, Sub(sender, e)
                                           btn.BackColor = normalColor
                                       End Sub

            AddHandler btn.MouseDown, Sub(sender, e)
                                          btn.BackColor = clickColor
                                      End Sub

            AddHandler btn.MouseUp, Sub(sender, e)
                                        btn.BackColor = hoverColor
                                    End Sub
        Else
            ' 非アクティブなボタン（透明）のホバー効果
            Dim normalColor As Color = Color.Transparent
            Dim hoverColor As Color = Color.FromArgb(50, 255, 255, 255)
            Dim clickColor As Color = Color.FromArgb(80, 255, 255, 255)

            AddHandler btn.MouseEnter, Sub(sender, e)
                                           btn.BackColor = hoverColor
                                       End Sub

            AddHandler btn.MouseLeave, Sub(sender, e)
                                           btn.BackColor = normalColor
                                       End Sub

            AddHandler btn.MouseDown, Sub(sender, e)
                                          btn.BackColor = clickColor
                                      End Sub

            AddHandler btn.MouseUp, Sub(sender, e)
                                        btn.BackColor = hoverColor
                                    End Sub
        End If
    End Sub

End Module

' =========================
' �����t�H�[���{�́i���[�h�����̂݁j
' =========================
Partial Public Class HistoryForm
    Inherits System.Windows.Forms.Form

    ' �t�H�[�����[�h��
    Private Sub HistoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ナビゲーション共通設定
        CommonUIHistory.ConfigureFooterLayout(footerBar, btnNavHome, btnNavRooms, btnNavFav, flowRooms)
        CommonUIHistory.RegisterFooterNavigation(Me, btnNavHome, btnNavRooms, btnNavFav, activeTab:="Rooms")

        ' デザイン初期値
        If cmbSort IsNot Nothing Then
            cmbSort.SelectedIndex = 0
        End If

        LoadHistoryCards()
        ApplyFooterButtonLayout()
        AdjustCardsWidth()
        CenterBackButton()
        CenterHeaderTitle()
    End Sub

End Class
