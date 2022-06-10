Imports Dirzee_UWP.Core.Models
Imports Dirzee_UWP.Core.Services

Imports Microsoft.Toolkit.Mvvm.ComponentModel

Namespace ViewModels
    Public Class ExploreRoomsViewModel
        Inherits ObservableObject

        Public Property Source As ObservableCollection(Of SampleOrder) = New ObservableCollection(Of SampleOrder)

        Public Sub New()
        End Sub

        Public Async Function LoadDataAsync() As Task
            Source.Clear()

            ' Replace this with your actual data
            Dim data = Await SampleDataService.GetGridDataAsync()
            For Each item In data
                Source.Add(item)
            Next
        End Function
    End Class
End Namespace
