Partial Public Class SecondForm
    Inherits System.Windows.Forms.Form

    Private ReadOnly _prev As System.Windows.Forms.Form

    ' Designer 用のパラメータ無しコンストラクタ（デザイナで必要）
    Public Sub New()
        InitializeComponent()
        _prev = Nothing
        ' フォームが閉じられたら prev を表示するハンドラ（prev が設定されているときのみ）
        AddHandler Me.FormClosed, AddressOf SecondForm_FormClosed
        AddHandler btnBack.Click, AddressOf btnBack_Click
    End Sub

    ' 実行時に遷移元を受け取るコンストラクタ
    Public Sub New(prev As System.Windows.Forms.Form)
        InitializeComponent()
        _prev = prev
        AddHandler Me.FormClosed, AddressOf SecondForm_FormClosed
        AddHandler btnBack.Click, AddressOf btnBack_Click
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        ' 「戻る」動作はこのフォームを閉じるだけで prev が再表示される
        Me.Close()
    End Sub

    Private Sub SecondForm_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs)
        If _prev IsNot Nothing Then
            ' 遷移元を再表示して戻れるようにする
            _prev.Show()
        Else
            ' _prev が無ければアプリを終了しても良い（必要ならここで Application.Exit() を呼ぶ）
            ' Application.Exit()
        End If
    End Sub
End Class