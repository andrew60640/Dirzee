Imports Dirzee_UWP.Core.Models
Imports Dirzee_UWP.Core.Services

Imports Microsoft.Toolkit.Mvvm.ComponentModel

Namespace ViewModels
    Public Class ExploreBrandsDetailViewModel
        Inherits ObservableObject

        Private _item As SampleOrder

        Public Property Item As SampleOrder
            Get
                Return _item
            End Get
            Set(value As SampleOrder)
                [SetProperty](_item, value)
            End Set
        End Property

        Public Sub New()
        End Sub

        Public Async Function InitializeAsync(orderID As Long) As Task
            Dim data = Await SampleDataService.GetContentGridDataAsync()
            Item = data.First(Function(i) i.OrderID = orderID)
        End Function

    End Class
End Namespace
