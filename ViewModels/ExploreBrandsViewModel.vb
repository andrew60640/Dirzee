Imports Dirzee_UWP.Core.Models
Imports Dirzee_UWP.Core.Services
Imports Dirzee_UWP.Services
Imports Dirzee_UWP.Views

Imports Microsoft.Toolkit.Mvvm.ComponentModel
Imports Microsoft.Toolkit.Mvvm.Input
Imports Microsoft.Toolkit.Uwp.UI.Animations

Namespace ViewModels
    Public Class ExploreBrandsViewModel
        Inherits ObservableObject

        Public Property Source As ObservableCollection(Of SampleOrder) = New ObservableCollection(Of SampleOrder)

        Public Sub New()
        End Sub

        Public Async Function LoadDataAsync() As Task
            Source.Clear()

            ' Replace this with your actual data
            Dim data = Await SampleDataService.GetContentGridDataAsync()

            For Each item As SampleOrder In data
                Source.Add(item)
            Next
        End Function

        Public ReadOnly Property ItemClickCommand  As ICommand = New RelayCommand(Of SampleOrder)(Sub(order) OnItemClick(order))

        Private Sub OnItemClick(clickedItem As SampleOrder)
            If clickedItem IsNot Nothing Then
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(clickedItem)
                NavigationService.Navigate(Of ExploreBrandsDetailPage)(clickedItem.OrderID)
            End If
        End Sub
    End Class
End Namespace
