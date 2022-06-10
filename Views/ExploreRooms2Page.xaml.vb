Imports Dirzee_UWP.ViewModels

Namespace Views
    Public NotInheritable Partial Class ExploreRooms2Page
        Inherits Page

        property ViewModel as ExploreRooms2ViewModel = New ExploreRooms2ViewModel

        ' TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on ExploreRooms2Page.xaml.
        ' For help see http://docs.telerik.com/windows-universal/controls/raddatagrid/gettingstarted
        ' You may also want to extend the grid to work with the RadDataForm http://docs.telerik.com/windows-universal/controls/raddataform/dataform-gettingstarted
        Public Sub New()
            InitializeComponent()
        End Sub

        Protected Overrides Async Sub OnNavigatedTo(e As NavigationEventArgs)
            MyBase.OnNavigatedTo(e)

            Await ViewModel.LoadDataAsync()
        End Sub
    End Class
End Namespace
