<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class LoginForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer
    Friend WithEvents headerBar As Panel
    Friend WithEvents footerBar As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnCancel As Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        headerBar = New Panel()
        footerBar = New Panel()
        lblTitle = New Label()
        lblEmail = New Label()
        lblPassword = New Label()
        txtEmail = New TextBox()
        txtPassword = New TextBox()
        btnLogin = New Button()
        btnCancel = New Button()
        SuspendLayout()
        ' 
        ' headerBar
        ' 
        headerBar.BackColor = Color.FromArgb(CByte(10), CByte(102), CByte(204))
        headerBar.Dock = DockStyle.Top
        headerBar.Location = New Point(0, 0)
        headerBar.Name = "headerBar"
        headerBar.Size = New Size(554, 80)
        headerBar.TabIndex = 0
        ' 
        ' footerBar
        ' 
        footerBar.BackColor = Color.FromArgb(CByte(10), CByte(102), CByte(204))
        footerBar.Dock = DockStyle.Bottom
        footerBar.Location = New Point(0, 960)
        footerBar.Name = "footerBar"
        footerBar.Size = New Size(554, 64)
        footerBar.TabIndex = 1
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Yu Gothic UI", 18.0F, FontStyle.Bold)
        lblTitle.Location = New Point(24, 96)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(128, 48)
        lblTitle.TabIndex = 2
        lblTitle.Text = "ログイン"
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Location = New Point(24, 200)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(115, 28)
        lblEmail.TabIndex = 3
        lblEmail.Text = "メールアドレス"
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Location = New Point(24, 288)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(85, 28)
        lblPassword.TabIndex = 4
        lblPassword.Text = "パスワード"
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(24, 228)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(520, 34)
        txtEmail.TabIndex = 0
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(24, 316)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(520, 34)
        txtPassword.TabIndex = 1
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' btnLogin
        ' 
        btnLogin.Location = New Point(360, 368)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(96, 40)
        btnLogin.TabIndex = 2
        btnLogin.Text = "ログイン"
        btnLogin.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(472, 368)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(72, 40)
        btnCancel.TabIndex = 3
        btnCancel.Text = "キャンセル"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' LoginForm
        ' 
        AcceptButton = btnLogin
        CancelButton = btnCancel
        ClientSize = New Size(554, 1024)
        Controls.Add(footerBar)
        Controls.Add(headerBar)
        Controls.Add(lblTitle)
        Controls.Add(lblEmail)
        Controls.Add(txtEmail)
        Controls.Add(lblPassword)
        Controls.Add(txtPassword)
        Controls.Add(btnLogin)
        Controls.Add(btnCancel)
        Font = New Font("Yu Gothic UI", 10.0F)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "LoginForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ログイン"
        ResumeLayout(False)
        PerformLayout()
    End Sub
End Class