Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class DmForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Private contentPanel As Panel
    Private headerPanel As Panel
    Private btnBack As Button
    Private btnStar As Button
    Private lblTitle As Label
    Private flowDM As FlowLayoutPanel
    Private inputPanel As Panel
    Private txtMessage As TextBox
    Private btnSend As Button
    Private footerBar As Panel
    Private btnNavHome As Button
    Private btnNavRooms As Button
    Private btnNavFav As Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        contentPanel = New Panel()
        headerPanel = New Panel()
        btnBack = New Button()
        btnStar = New Button()
        lblTitle = New Label()
        flowDM = New FlowLayoutPanel()
        inputPanel = New Panel()
        txtMessage = New TextBox()
        btnSend = New Button()
        footerBar = New Panel()
        btnNavHome = New Button()
        btnNavRooms = New Button()
        btnNavFav = New Button()
        footerBar.SuspendLayout()
        headerPanel.SuspendLayout()
        inputPanel.SuspendLayout()
        SuspendLayout()
        '
        ' contentPanel
        '
        contentPanel.BackColor = Color.White
        contentPanel.Controls.Add(flowDM)
        contentPanel.Controls.Add(inputPanel)
        contentPanel.Controls.Add(headerPanel)
        contentPanel.Dock = DockStyle.Fill
        contentPanel.Location = New Point(0, 0)
        contentPanel.Name = "contentPanel"
        contentPanel.Padding = New Padding(0)
        contentPanel.Size = New Size(576, 960)
        contentPanel.TabIndex = 0
        '
        ' headerPanel
        '
        headerPanel.BackColor = Color.FromArgb(CByte(3), CByte(116), CByte(213))
        headerPanel.Controls.Add(btnBack)
        headerPanel.Controls.Add(btnStar)
        headerPanel.Controls.Add(lblTitle)
        headerPanel.Dock = DockStyle.Top
        headerPanel.Location = New Point(0, 0)
        headerPanel.Name = "headerPanel"
        headerPanel.Padding = New Padding(12)
        headerPanel.Size = New Size(576, 64)
        headerPanel.TabIndex = 0
        '
        ' btnBack
        '
        btnBack.BackColor = Color.Transparent
        btnBack.FlatAppearance.BorderSize = 0
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.Font = New Font("Yu Gothic UI", 10.0F, FontStyle.Bold)
        btnBack.ForeColor = Color.White
        btnBack.Location = New Point(6, 14)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(48, 32)
        btnBack.TabIndex = 0
        btnBack.Text = "←"
        btnBack.UseVisualStyleBackColor = False
        '
        ' btnStar
        '
        btnStar.BackColor = Color.Transparent
        btnStar.FlatAppearance.BorderSize = 0
        btnStar.FlatStyle = FlatStyle.Flat
        btnStar.Font = New Font("Yu Gothic UI", 12.0F, FontStyle.Bold)
        btnStar.ForeColor = Color.White
        btnStar.Location = New Point(498, 14)
        btnStar.Name = "btnStar"
        btnStar.Size = New Size(36, 32)
        btnStar.TabIndex = 2
        btnStar.Text = "☆"
        btnStar.UseVisualStyleBackColor = False
        '
        ' lblTitle
        '
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Yu Gothic UI", 11.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(72, 18)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(122, 30)
        lblTitle.TabIndex = 1
        lblTitle.Text = "DM画面"
        '
        ' flowDM
        '
        flowDM.AutoScroll = True
        flowDM.Dock = DockStyle.Fill
        flowDM.FlowDirection = FlowDirection.TopDown
        flowDM.Location = New Point(0, 64)
        flowDM.Margin = New Padding(0, 0, 0, 0)
        flowDM.Name = "flowDM"
        flowDM.Padding = New Padding(0, 12, 0, 24)
        flowDM.Size = New Size(576, 744)
        flowDM.TabIndex = 4
        flowDM.WrapContents = False
        '
        ' inputPanel
        '
        inputPanel.BackColor = Color.White
        inputPanel.Controls.Add(txtMessage)
        inputPanel.Controls.Add(btnSend)
        inputPanel.Dock = DockStyle.Bottom
        inputPanel.Location = New Point(0, 808)
        inputPanel.Name = "inputPanel"
        inputPanel.Padding = New Padding(0)
        inputPanel.Size = New Size(576, 152)
        inputPanel.TabIndex = 5
        '
        ' txtMessage
        '
        txtMessage.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtMessage.Font = New Font("Yu Gothic UI", 10.0F)
        txtMessage.Location = New Point(0, 16)
        txtMessage.Multiline = True
        txtMessage.Name = "txtMessage"
        txtMessage.PlaceholderText = "メッセージを入力..."
        txtMessage.Size = New Size(432, 56)
        txtMessage.TabIndex = 0
        '
        ' btnSend
        '
        btnSend.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnSend.BackColor = Color.FromArgb(CByte(0), CByte(184), CByte(242))
        btnSend.FlatAppearance.BorderSize = 0
        btnSend.FlatStyle = FlatStyle.Flat
        btnSend.Font = New Font("Yu Gothic UI", 10.0F, FontStyle.Bold)
        btnSend.ForeColor = Color.White
        btnSend.Location = New Point(432, 16)
        btnSend.Name = "btnSend"
        btnSend.Size = New Size(120, 56)
        btnSend.TabIndex = 1
        btnSend.Text = "送信"
        btnSend.UseVisualStyleBackColor = False
        '
        ' footerBar
        '
        footerBar.BackColor = Color.FromArgb(CByte(3), CByte(116), CByte(213))
        footerBar.Controls.Add(btnNavHome)
        footerBar.Controls.Add(btnNavRooms)
        footerBar.Controls.Add(btnNavFav)
        footerBar.Dock = DockStyle.Bottom
        footerBar.Location = New Point(0, 960)
        footerBar.Name = "footerBar"
        footerBar.Size = New Size(576, 64)
        footerBar.TabIndex = 5
        '
        ' btnNavHome
        '
        btnNavHome.BackColor = Color.Transparent
        btnNavHome.FlatAppearance.BorderSize = 0
        btnNavHome.FlatStyle = FlatStyle.Flat
        btnNavHome.ForeColor = Color.White
        btnNavHome.Location = New Point(0, 8)
        btnNavHome.Name = "btnNavHome"
        btnNavHome.Size = New Size(192, 48)
        btnNavHome.TabIndex = 0
        btnNavHome.Text = "ホーム"
        btnNavHome.UseVisualStyleBackColor = False
        '
        ' btnNavRooms
        '
        btnNavRooms.BackColor = Color.Transparent
        btnNavRooms.FlatAppearance.BorderSize = 0
        btnNavRooms.FlatStyle = FlatStyle.Flat
        btnNavRooms.ForeColor = Color.White
        btnNavRooms.Location = New Point(192, 8)
        btnNavRooms.Name = "btnNavRooms"
        btnNavRooms.Size = New Size(192, 48)
        btnNavRooms.TabIndex = 1
        btnNavRooms.Text = "ルーム履歴"
        btnNavRooms.UseVisualStyleBackColor = False
        '
        ' btnNavFav
        '
        btnNavFav.BackColor = Color.Transparent
        btnNavFav.FlatAppearance.BorderSize = 0
        btnNavFav.FlatStyle = FlatStyle.Flat
        btnNavFav.ForeColor = Color.White
        btnNavFav.Location = New Point(384, 8)
        btnNavFav.Name = "btnNavFav"
        btnNavFav.Size = New Size(192, 48)
        btnNavFav.TabIndex = 2
        btnNavFav.Text = "お気に入り"
        btnNavFav.UseVisualStyleBackColor = False
        '
        ' DmForm
        '
        AutoScaleDimensions = New SizeF(11.0F, 28.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(576, 1024)
        Controls.Add(contentPanel)
        Controls.Add(footerBar)
        Font = New Font("Yu Gothic UI", 10.0F)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "DmForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "DM"
        footerBar.ResumeLayout(False)
        headerPanel.ResumeLayout(False)
        headerPanel.PerformLayout()
        inputPanel.ResumeLayout(False)
        inputPanel.PerformLayout()
        ResumeLayout(False)
    End Sub
End Class


