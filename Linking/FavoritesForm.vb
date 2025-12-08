Partial Public Class FavoritesForm
    Inherits System.Windows.Forms.Form

    Private _prev As System.Windows.Forms.Form

    Public Sub New()
        InitializeComponent()
        AddHandler Me.Load, AddressOf FavoritesForm_Load
    End Sub

    Public Sub New(prev As System.Windows.Forms.Form)
        Me.New()
        _prev = prev
        ' 共通の戻る処理を登録
        CommonUI.RegisterBackNavigation(Me, _prev, btnBack)
    End Sub

    Private Sub FavoritesForm_Load(sender As Object, e As EventArgs)
        ' footer レイアウトを構成し、ナビの挙動を共通化
        CommonUI.ConfigureFooterLayout(footerBar, btnNavHome, btnNavRooms, btnNavFav, flowRooms)
        CommonUI.RegisterFooterNavigation(Me, btnNavHome, btnNavRooms, btnNavFav)
        ' ホーム強調（この画面はお気に入りなので btnNavFav を強調したい場合はここで変更可能）
        btnNavFav.BackColor = Color.FromArgb(255, 230, 0)
        btnNavFav.ForeColor = Color.Black
    End Sub
End Class