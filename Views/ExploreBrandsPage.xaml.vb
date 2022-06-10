Imports Dirzee_UWP.ViewModels

Namespace Views
    Public NotInheritable Partial Class ExploreBrandsPage
        Inherits Page

        property ViewModel as ExploreBrandsViewModel = New ExploreBrandsViewModel

        Public Sub New()
            InitializeComponent()
        End Sub

        Protected Overrides Async Sub OnNavigatedTo(e As NavigationEventArgs)
            MyBase.OnNavigatedTo(e)

            Await ViewModel.LoadDataAsync()
        End Sub
    End Class
End Namespace
