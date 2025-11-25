<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class SecondForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents lblInfo As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        ' SecondForm — 簡易レイアウト
        '
        Me.ClientSize = New System.Drawing.Size(576, 1024)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Name = "SecondForm"
        Me.Text = "Second"
        '
        ' lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Location = New System.Drawing.Point(24, 24)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(200, 28)
        Me.lblInfo.Text = "SecondForm"
        '
        ' btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(24, 64)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(120, 40)
        Me.btnBack.TabIndex = 0
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        ' Controls add
        '
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.btnBack)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class