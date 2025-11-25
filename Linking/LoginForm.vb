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
        main.Show()
        Me.Hide()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' アプリを終了したい場合は明示的に Application.Exit() を呼ぶと確実です
        Application.Exit()
    End Sub
End Class