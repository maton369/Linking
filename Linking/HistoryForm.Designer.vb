<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class HistoryForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Friend WithEvents headerBar As Panel
    Friend WithEvents lblScreenTitle As Label
    Friend WithEvents flowRooms As FlowLayoutPanel
    Friend WithEvents footerBar As Panel
    Friend WithEvents btnNavHome As Button
    Friend WithEvents btnNavRooms As Button
    Friend WithEvents btnNavFav As Button
    Friend WithEvents btnBack As Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        headerBar = New Panel()
        lblScreenTitle = New Label()
        flowRooms = New FlowLayoutPanel()
        footerBar = New Panel()
        btnNavHome = New Button()
        btnNavRooms = New Button()
        btnNavFav = New Button()
        btnBack = New Button()
        footerBar.SuspendLayout()
        SuspendLayout()
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
        lblScreenTitle.Location = New Point(24, 96)
        lblScreenTitle.Name = "lblScreenTitle"
        lblScreenTitle.Size = New Size(160, 48)
        lblScreenTitle.TabIndex = 1
        lblScreenTitle.Text = "ルーム履歴"
        '
        ' flowRooms
        '
        flowRooms.AutoScroll = True
        flowRooms.Dock = DockStyle.Fill
        flowRooms.FlowDirection = FlowDirection.TopDown
        flowRooms.Location = New Point(0, 144)
        flowRooms.Name = "flowRooms"
        flowRooms.Padding = New Padding(8)
        flowRooms.Size = New Size(576, 816)
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
        ' btnBack
        '
        btnBack.Location = New Point(24, 64)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(120, 40)
        btnBack.TabIndex = 10
        btnBack.Text = "戻る"
        btnBack.UseVisualStyleBackColor = True
        '
        ' HistoryForm
        '
        AutoScaleDimensions = New SizeF(11.0F, 28.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(576, 1024)
        Controls.Add(footerBar)
        Controls.Add(flowRooms)
        Controls.Add(lblScreenTitle)
        Controls.Add(headerBar)
        Controls.Add(btnBack)
        Font = New Font("Yu Gothic UI", 10.0F)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "HistoryForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ルーム履歴"
        footerBar.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

End Class