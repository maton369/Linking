Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Windows.Forms

Namespace My
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            ' 既定の StartupForm 自動起動を止める
            e.Cancel = True

            ' ログインダイアログを表示（モーダル）
            Using login As New LoginForm()
                If login.ShowDialog() <> DialogResult.OK Then
                    ' ログイン失敗またはキャンセル -> アプリ終了
                    Return
                End If
            End Using

            ' ログイン成功 -> 明示的に Windows Forms の Application.Run を呼ぶ
            System.Windows.Forms.Application.Run(New Form1())
        End Sub
    End Class
End Namespace