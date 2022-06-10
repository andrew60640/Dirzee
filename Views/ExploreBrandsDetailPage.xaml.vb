Imports Dirzee_UWP.Services
Imports Dirzee_UWP.ViewModels

Imports Microsoft.Toolkit.Uwp.UI.Animations

Namespace Views
    Public NotInheritable Partial Class ExploreBrandsDetailPage
        Inherits Page

        Public ReadOnly Property ViewModel As ExploreBrandsDetailViewModel = New ExploreBrandsDetailViewModel()

        Public Sub New()
            InitializeComponent()
        End Sub

        Protected Overrides Async Sub OnNavigatedTo(e As NavigationEventArgs)
            MyBase.OnNavigatedTo(e)
            RegisterElementForConnectedAnimation("animationKeyExploreBrands", itemHero)
            Dim orderID As Long
            orderID = CType(e.Parameter, Long)
            Await ViewModel.InitializeAsync(orderID)
        End Sub

        Protected Overrides Sub OnNavigatingFrom(e As NavigatingCancelEventArgs)
            MyBase.OnNavigatingFrom(e)
            If e.NavigationMode = NavigationMode.Back Then
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(ViewModel.Item)
            End If
        End Sub
    End Class
End Namespace
