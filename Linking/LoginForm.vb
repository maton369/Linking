Partial Public Class LoginForm
    Inherits System.Windows.Forms.Form

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If String.IsNullOrWhiteSpace(txtEmail.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("メールアドレスとパスワードを入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 認証成功（簡易）
        ' Me.Close() にすると LoginForm がアプリのメインフォームの場合にメッセージループが終了してしまうため、
        ' 遷移元を Hide して遷移先に this を渡して Show する方式にする。
        Dim main As New Form1(Me)

        ' LoginForm と同じウィンドウ外形サイズ／位置に合わせる
        Try
            main.StartPosition = FormStartPosition.Manual
            main.Size = Me.Size            ' ウィンドウ全体のサイズをコピー（枠を含む）
            main.Location = Me.Location    ' 位置も揃える場合
            ' 必要ならクライアントサイズを揃える（枠差に注意）
            ' main.ClientSize = Me.ClientSize
        Catch ex As Exception
            ' 念のため失敗しても表示は続ける
        End Try

        main.Show()
        Me.Hide()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' アプリを終了したい場合は明示的に Application.Exit() を呼ぶと確実です
        Application.Exit()
    End Sub
End Class