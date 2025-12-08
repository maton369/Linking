Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ConversationForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Private contentPanel As Panel
    Private headerPanel As Panel
    Private btnTitle As Button
    Private infoPanel As Panel
    Private lblTimer As Label
    Private cmbSort As ComboBox
    Private flowMessages As FlowLayoutPanel
    Private backPanel As Panel
    Private btnBack As Button
    Private footerBar As Panel
    Private btnNavHome As Button
    Private btnNavRooms As Button
    Private btnNavFav As Button
    Private btnStar As Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        contentPanel = New Panel()
        flowMessages = New FlowLayoutPanel()
        backPanel = New Panel()
        btnBack = New Button()
        infoPanel = New Panel()
        btnStar = New Button()
        lblTimer = New Label()
        cmbSort = New ComboBox()
        headerPanel = New Panel()
        btnTitle = New Button()
        footerBar = New Panel()
        btnNavHome = New Button()
        btnNavRooms = New Button()
        btnNavFav = New Button()
        contentPanel.SuspendLayout()
        backPanel.SuspendLayout()
        infoPanel.SuspendLayout()
        headerPanel.SuspendLayout()
        footerBar.SuspendLayout()
        SuspendLayout()
        ' 
        ' contentPanel
        ' 
        contentPanel.BackColor = Color.White
        contentPanel.Controls.Add(flowMessages)
        contentPanel.Controls.Add(backPanel)
        contentPanel.Controls.Add(infoPanel)
        contentPanel.Controls.Add(headerPanel)
        contentPanel.Dock = DockStyle.Fill
        contentPanel.Location = New Point(0, 0)
        contentPanel.Name = "contentPanel"
        contentPanel.Padding = New Padding(12, 0, 12, 0)
        contentPanel.Size = New Size(576, 960)
        contentPanel.TabIndex = 0
        ' 
        ' flowMessages
        ' 
        flowMessages.AutoScroll = True
        flowMessages.Dock = DockStyle.Fill
        flowMessages.FlowDirection = FlowDirection.TopDown
        flowMessages.Location = New Point(12, 166)
        flowMessages.Margin = New Padding(0, 12, 0, 0)
        flowMessages.Name = "flowMessages"
        flowMessages.Padding = New Padding(12, 144, 12, 24)
        flowMessages.Size = New Size(552, 674)
        flowMessages.TabIndex = 4
        flowMessages.WrapContents = False
        ' 
        ' backPanel
        ' 
        backPanel.Controls.Add(btnBack)
        backPanel.Dock = DockStyle.Bottom
        backPanel.Location = New Point(12, 840)
        backPanel.Name = "backPanel"
        backPanel.Padding = New Padding(0, 16, 0, 24)
        backPanel.Size = New Size(552, 120)
        backPanel.TabIndex = 6
        ' 
        ' btnBack
        ' 
        btnBack.BackColor = Color.FromArgb(CByte(0), CByte(184), CByte(242))
        btnBack.FlatAppearance.BorderSize = 0
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.Font = New Font("Yu Gothic UI", 10.0F, FontStyle.Bold)
        btnBack.ForeColor = Color.White
        btnBack.Location = New Point(180, 24)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(200, 48)
        btnBack.TabIndex = 10
        btnBack.Text = "戻る"
        btnBack.UseVisualStyleBackColor = False
        ' 
        ' infoPanel
        ' 
        infoPanel.Controls.Add(btnStar)
        infoPanel.Controls.Add(lblTimer)
        infoPanel.Controls.Add(cmbSort)
        infoPanel.Dock = DockStyle.Top
        infoPanel.Location = New Point(12, 94)
        infoPanel.Name = "infoPanel"
        infoPanel.Padding = New Padding(12, 12, 12, 8)
        infoPanel.Size = New Size(552, 72)
        infoPanel.TabIndex = 1
        ' 
        ' btnStar
        ' 
        btnStar.BackColor = Color.Gold
        btnStar.FlatAppearance.BorderSize = 0
        btnStar.FlatStyle = FlatStyle.Flat
        btnStar.Font = New Font("Yu Gothic UI", 12.0F, FontStyle.Bold)
        btnStar.Location = New Point(12, 16)
        btnStar.Name = "btnStar"
        btnStar.Size = New Size(40, 36)
        btnStar.TabIndex = 4
        btnStar.Text = "★"
        btnStar.UseVisualStyleBackColor = False
        btnStar.Visible = False
        ' 
        ' lblTimer
        ' 
        lblTimer.AutoSize = True
        lblTimer.Font = New Font("Yu Gothic UI", 12.0F, FontStyle.Bold)
        lblTimer.Location = New Point(72, 30)
        lblTimer.Name = "lblTimer"
        lblTimer.Size = New Size(102, 32)
        lblTimer.TabIndex = 2
        lblTimer.Text = "05:43:21"
        ' 
        ' cmbSort
        ' 
        cmbSort.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        cmbSort.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSort.Font = New Font("Yu Gothic UI", 10.0F)
        cmbSort.FormattingEnabled = True
        cmbSort.Items.AddRange(New Object() {"新しい順", "古い順"})
        cmbSort.Location = New Point(748, 30)
        cmbSort.Name = "cmbSort"
        cmbSort.Size = New Size(132, 36)
        cmbSort.TabIndex = 3
        ' 
        ' headerPanel
        ' 
        headerPanel.BackColor = Color.FromArgb(CByte(3), CByte(116), CByte(213))
        headerPanel.Controls.Add(btnTitle)
        headerPanel.Dock = DockStyle.Top
        headerPanel.Location = New Point(12, 0)
        headerPanel.Name = "headerPanel"
        headerPanel.Padding = New Padding(12)
        headerPanel.Size = New Size(552, 94)
        headerPanel.TabIndex = 0
        ' 
        ' btnTitle
        ' 
        btnTitle.BackColor = Color.FromArgb(CByte(0), CByte(184), CByte(242))
        btnTitle.FlatAppearance.BorderSize = 0
        btnTitle.FlatStyle = FlatStyle.Flat
        btnTitle.Font = New Font("Yu Gothic UI", 12.0F, FontStyle.Bold)
        btnTitle.ForeColor = Color.White
        btnTitle.Location = New Point(159, 29)
        btnTitle.Name = "btnTitle"
        btnTitle.Size = New Size(240, 36)
        btnTitle.TabIndex = 1
        btnTitle.Text = "会話"
        btnTitle.UseVisualStyleBackColor = False
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
        ' ConversationForm
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
        Name = "ConversationForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "会話"
        contentPanel.ResumeLayout(False)
        backPanel.ResumeLayout(False)
        infoPanel.ResumeLayout(False)
        infoPanel.PerformLayout()
        headerPanel.ResumeLayout(False)
        footerBar.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
End Class

