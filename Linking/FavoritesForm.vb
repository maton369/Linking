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
        ' 共通の戻る処理を登録（CommonUIHistory を使用）
        CommonUIHistory.RegisterBackNavigation(Me, _prev, btnBack)
    End Sub

    Private Sub FavoritesForm_Load(sender As Object, e As EventArgs)
        ' footer レイアウトを構成し、ナビの挙動を共通化
        CommonUIHistory.ConfigureFooterLayout(footerBar, btnNavHome, btnNavRooms, btnNavFav, flowRooms)

        ' この画面は「お気に入り」タブをアクティブとして強調表示
        CommonUIHistory.RegisterFooterNavigation(Me, btnNavHome, btnNavRooms, btnNavFav, activeTab:="Fav")
    End Sub

End Class
