Imports Dirzee_UWP.Helpers

Imports Microsoft.Toolkit.Mvvm.ComponentModel

Imports Windows.UI.Xaml.Media.Imaging

Namespace ViewModels
    Public Class UserViewModel
        Inherits ObservableObject

        Private _name As String
        Private _userPrincipalName As String
        Private _photo As BitmapImage

        Public Property Name As String
            Get
                Return _name
            End Get
            Set(value As String)
                SetProperty(_name, value)
            End Set
        End Property

        Public Property UserPrincipalName As String
            Get
                Return _userPrincipalName
            End Get
            Set(value As String)
                SetProperty(_userPrincipalName, value)
            End Set
        End Property

        Public Property Photo As BitmapImage
            Get
                Return _photo
            End Get
            Set(value As BitmapImage)
                SetProperty(_photo, value)
            End Set
        End Property

        Public Sub New()
        End Sub
    End Class
End Namespace
