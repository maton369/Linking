<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Friend WithEvents lblScreenTitle As Label
    Friend WithEvents headerBar As Panel
    Friend WithEvents panelSearch As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents flowRooms As FlowLayoutPanel
    Friend WithEvents footerBar As Panel
    Friend WithEvents btnNavHome As Button
    Friend WithEvents btnNavRooms As Button
    Friend WithEvents btnNavFav As Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        panelSearch = New Panel()
        txtSearch = New TextBox()
        btnAdd = New Button()
        headerBar = New Panel()
        lblScreenTitle = New Label()
        flowRooms = New FlowLayoutPanel()
        footerBar = New Panel()
        btnNavHome = New Button()
        btnNavRooms = New Button()
        btnNavFav = New Button()
        panelSearch.SuspendLayout()
        footerBar.SuspendLayout()
        SuspendLayout()
        ' 
        ' panelSearch
        ' 
        panelSearch.BackColor = Color.FromArgb(CByte(245), CByte(242), CByte(246))
        panelSearch.Controls.Add(txtSearch)
        panelSearch.Controls.Add(btnAdd)
        panelSearch.Dock = DockStyle.Top
        panelSearch.Location = New Point(0, 80)
        panelSearch.Name = "panelSearch"
        panelSearch.Padding = New Padding(8)
        panelSearch.Size = New Size(576, 56)
        panelSearch.TabIndex = 2
        '
        ' txtSearch
        '
        txtSearch.BorderStyle = BorderStyle.FixedSingle
        txtSearch.Dock = DockStyle.Fill
        txtSearch.Font = New Font("Yu Gothic UI", 11.0F, FontStyle.Regular)
        txtSearch.Location = New Point(8, 8)
        txtSearch.Margin = New Padding(0)
        txtSearch.Name = "txtSearch"
        txtSearch.PlaceholderText = "🔍 ルームを検索..."
        txtSearch.Size = New Size(504, 27)
        txtSearch.TabIndex = 0
        '
        ' btnAdd
        '
        btnAdd.BackColor = Color.FromArgb(CByte(3), CByte(116), CByte(213))
        btnAdd.Cursor = Cursors.Hand
        btnAdd.Dock = DockStyle.Right
        btnAdd.FlatAppearance.BorderSize = 0
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Font = New Font("Yu Gothic UI", 10.0F, FontStyle.Bold)
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(512, 8)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(56, 40)
        btnAdd.TabIndex = 1
        btnAdd.Text = "🔍"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' headerBar
        ' 
        headerBar.BackColor = Color.FromArgb(CByte(10), CByte(102), CByte(204))
        headerBar.Dock = DockStyle.Top
        headerBar.Location = New Point(0, 0)
        headerBar.Name = "headerBar"
        headerBar.Size = New Size(576, 80)
        headerBar.TabIndex = 0
        ' 
        ' lblScreenTitle
        ' 
        lblScreenTitle.AutoSize = True
        lblScreenTitle.Font = New Font("Yu Gothic UI", 18.0F, FontStyle.Bold)
        lblScreenTitle.Location = New Point(24, 152)
        lblScreenTitle.Name = "lblScreenTitle"
        lblScreenTitle.Size = New Size(103, 48)
        lblScreenTitle.TabIndex = 1
        lblScreenTitle.Text = "ホーム"
        ' 
        ' flowRooms
        ' 
        flowRooms.AutoScroll = True
        flowRooms.Dock = DockStyle.Fill
        flowRooms.FlowDirection = FlowDirection.TopDown
        flowRooms.Location = New Point(0, 136)
        flowRooms.Name = "flowRooms"
        flowRooms.Padding = New Padding(8)
        flowRooms.Size = New Size(576, 888)
        flowRooms.TabIndex = 3
        flowRooms.WrapContents = False
        ' 
        ' footerBar
        ' 
        footerBar.BackColor = Color.FromArgb(CByte(10), CByte(102), CByte(204))
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
        btnNavHome.Location = New Point(40, 12)
        btnNavHome.Name = "btnNavHome"
        btnNavHome.Size = New Size(120, 40)
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
        btnNavRooms.Location = New Point(228, 12)
        btnNavRooms.Name = "btnNavRooms"
        btnNavRooms.Size = New Size(120, 40)
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
        btnNavFav.Location = New Point(416, 12)
        btnNavFav.Name = "btnNavFav"
        btnNavFav.Size = New Size(120, 40)
        btnNavFav.TabIndex = 0
        btnNavFav.Text = "お気に入り"
        btnNavFav.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(11.0F, 28.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(576, 1024)
        Controls.Add(footerBar)
        Controls.Add(flowRooms)
        Controls.Add(lblScreenTitle)
        Controls.Add(panelSearch)
        Controls.Add(headerBar)
        Font = New Font("Yu Gothic UI", 10.0F)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ホーム"
        panelSearch.ResumeLayout(False)
        panelSearch.PerformLayout()
        footerBar.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

End Class
