<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Friend WithEvents lblScreenTitle As Label
    Friend WithEvents devicePanel As Panel
    Friend WithEvents headerBar As Panel
    Friend WithEvents panelSearch As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents flowRooms As FlowLayoutPanel
    Friend WithEvents bottomNav As Panel
    Friend WithEvents btnNavHome As Button
    Friend WithEvents btnNavRooms As Button
    Friend WithEvents btnNavFav As Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        devicePanel = New Panel()
        panelSearch = New Panel()
        txtSearch = New TextBox()
        btnAdd = New Button()
        headerBar = New Panel()
        flowRooms = New FlowLayoutPanel()
        bottomNav = New Panel()
        btnNavFav = New Button()
        btnNavRooms = New Button()
        btnNavHome = New Button()
        devicePanel.SuspendLayout()
        panelSearch.SuspendLayout()
        bottomNav.SuspendLayout()
        SuspendLayout()
        ' 
        ' devicePanel
        ' 
        devicePanel.BackColor = Color.White
        devicePanel.Controls.Add(panelSearch)
        devicePanel.Controls.Add(headerBar)
        devicePanel.Controls.Add(flowRooms)
        devicePanel.Controls.Add(bottomNav)
        devicePanel.Dock = DockStyle.Fill
        devicePanel.Location = New Point(0, 0)
        devicePanel.Name = "devicePanel"
        devicePanel.Size = New Size(576, 1024)
        devicePanel.TabIndex = 1
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
        panelSearch.TabIndex = 1
        ' 
        ' txtSearch
        ' 
        txtSearch.BorderStyle = BorderStyle.None
        txtSearch.Dock = DockStyle.Fill
        txtSearch.Location = New Point(8, 8)
        txtSearch.Margin = New Padding(0)
        txtSearch.Name = "txtSearch"
        txtSearch.PlaceholderText = "検索"
        txtSearch.Size = New Size(504, 27)
        txtSearch.TabIndex = 0
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.FromArgb(CByte(255), CByte(230), CByte(0))
        btnAdd.Dock = DockStyle.Right
        btnAdd.FlatAppearance.BorderSize = 0
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Font = New Font("Yu Gothic UI", 12.0F, FontStyle.Bold)
        btnAdd.Location = New Point(512, 8)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(56, 40)
        btnAdd.TabIndex = 1
        btnAdd.Text = "+"
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
        ' flowRooms
        ' 
        flowRooms.AutoScroll = True
        flowRooms.Dock = DockStyle.Fill
        flowRooms.FlowDirection = FlowDirection.TopDown
        flowRooms.Location = New Point(0, 0)
        flowRooms.Name = "flowRooms"
        flowRooms.Padding = New Padding(8)
        flowRooms.Size = New Size(576, 960)
        flowRooms.TabIndex = 2
        flowRooms.WrapContents = False
        ' 
        ' bottomNav
        ' 
        bottomNav.BackColor = Color.FromArgb(CByte(10), CByte(102), CByte(204))
        bottomNav.Controls.Add(btnNavFav)
        bottomNav.Controls.Add(btnNavRooms)
        bottomNav.Controls.Add(btnNavHome)
        bottomNav.Dock = DockStyle.Bottom
        bottomNav.Location = New Point(0, 960)
        bottomNav.Name = "bottomNav"
        bottomNav.Size = New Size(576, 64)
        bottomNav.TabIndex = 3
        ' 
        ' btnNavFav
        ' 
        btnNavFav.FlatAppearance.BorderSize = 0
        btnNavFav.FlatStyle = FlatStyle.Flat
        btnNavFav.ForeColor = Color.White
        btnNavFav.Location = New Point(388, 8)
        btnNavFav.Name = "btnNavFav"
        btnNavFav.Size = New Size(140, 48)
        btnNavFav.TabIndex = 2
        btnNavFav.Text = "お気に入り"
        ' 
        ' btnNavRooms
        ' 
        btnNavRooms.FlatAppearance.BorderSize = 0
        btnNavRooms.FlatStyle = FlatStyle.Flat
        btnNavRooms.ForeColor = Color.White
        btnNavRooms.Location = New Point(212, 8)
        btnNavRooms.Name = "btnNavRooms"
        btnNavRooms.Size = New Size(140, 48)
        btnNavRooms.TabIndex = 1
        btnNavRooms.Text = "ルーム"
        ' 
        ' btnNavHome
        ' 
        btnNavHome.BackColor = Color.FromArgb(CByte(255), CByte(230), CByte(0))
        btnNavHome.FlatAppearance.BorderSize = 0
        btnNavHome.FlatStyle = FlatStyle.Flat
        btnNavHome.Location = New Point(20, 8)
        btnNavHome.Name = "btnNavHome"
        btnNavHome.Size = New Size(96, 48)
        btnNavHome.TabIndex = 0
        btnNavHome.Text = "ホーム"
        btnNavHome.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(11.0F, 28.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(576, 1024)
        Controls.Add(devicePanel)
        Font = New Font("Yu Gothic UI", 10.0F)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ホーム"
        devicePanel.ResumeLayout(False)
        panelSearch.ResumeLayout(False)
        panelSearch.PerformLayout()
        bottomNav.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

End Class
