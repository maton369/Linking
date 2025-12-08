<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class FavoritesForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Private contentPanel As Panel
    Private headerPanel As Panel
    Private btnTitle As Button
    Friend WithEvents flowRooms As FlowLayoutPanel
    Private backPanel As Panel
    Friend WithEvents btnBack As Button
    Friend WithEvents footerBar As Panel
    Friend WithEvents btnNavHome As Button
    Friend WithEvents btnNavRooms As Button
    Friend WithEvents btnNavFav As Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        contentPanel = New Panel()
        headerPanel = New Panel()
        btnTitle = New Button()
        flowRooms = New FlowLayoutPanel()
        backPanel = New Panel()
        btnBack = New Button()
        footerBar = New Panel()
        btnNavHome = New Button()
        btnNavRooms = New Button()
        btnNavFav = New Button()
        contentPanel.SuspendLayout()
        headerPanel.SuspendLayout()
        backPanel.SuspendLayout()
        footerBar.SuspendLayout()
        SuspendLayout()
        ' 
        ' contentPanel
        ' 
        contentPanel.BackColor = Color.White
        contentPanel.Controls.Add(headerPanel)
        contentPanel.Controls.Add(flowRooms)
        contentPanel.Controls.Add(backPanel)
        contentPanel.Dock = DockStyle.Fill
        contentPanel.Location = New Point(0, 0)
        contentPanel.Name = "contentPanel"
        contentPanel.Padding = New Padding(12, 8, 12, 0)
        contentPanel.Size = New Size(576, 960)
        contentPanel.TabIndex = 0
        ' 
        ' headerPanel
        ' 
        headerPanel.BackColor = Color.FromArgb(CByte(3), CByte(116), CByte(213))
        headerPanel.Controls.Add(btnTitle)
        headerPanel.Dock = DockStyle.Top
        headerPanel.Location = New Point(12, 8)
        headerPanel.Name = "headerPanel"
        headerPanel.Padding = New Padding(12)
        headerPanel.Size = New Size(552, 83)
        headerPanel.TabIndex = 0
        ' 
        ' btnTitle
        ' 
        btnTitle.BackColor = Color.FromArgb(CByte(0), CByte(184), CByte(242))
        btnTitle.FlatAppearance.BorderSize = 0
        btnTitle.FlatStyle = FlatStyle.Flat
        btnTitle.Font = New Font("Yu Gothic UI", 12.0F, FontStyle.Bold)
        btnTitle.ForeColor = Color.White
        btnTitle.Location = New Point(156, 15)
        btnTitle.Name = "btnTitle"
        btnTitle.Size = New Size(240, 36)
        btnTitle.TabIndex = 1
        btnTitle.Text = "お気に入り"
        btnTitle.UseVisualStyleBackColor = False
        ' 
        ' flowRooms
        ' 
        flowRooms.AutoScroll = True
        flowRooms.Dock = DockStyle.Fill
        flowRooms.FlowDirection = FlowDirection.TopDown
        flowRooms.Location = New Point(12, 8)
        flowRooms.Margin = New Padding(0, 12, 0, 0)
        flowRooms.Name = "flowRooms"
        flowRooms.Padding = New Padding(12, 180, 12, 24)
        flowRooms.Size = New Size(552, 832)
        flowRooms.TabIndex = 3
        flowRooms.WrapContents = False
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
        footerBar.TabIndex = 4
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
        btnNavRooms.TabIndex = 0
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
        btnNavFav.TabIndex = 0
        btnNavFav.Text = "お気に入り"
        btnNavFav.UseVisualStyleBackColor = False
        ' 
        ' FavoritesForm
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
        Name = "FavoritesForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "お気に入り"
        contentPanel.ResumeLayout(False)
        headerPanel.ResumeLayout(False)
        backPanel.ResumeLayout(False)
        footerBar.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

End Class