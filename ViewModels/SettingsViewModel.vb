Imports Dirzee_UWP.Core.Helpers
Imports Dirzee_UWP.Core.Services
Imports Dirzee_UWP.Helpers
Imports Dirzee_UWP.Services

Imports Microsoft.Toolkit.Mvvm.ComponentModel
Imports Microsoft.Toolkit.Mvvm.Input

Namespace ViewModels
    ' TODO WTS: Add other settings as necessary. For help see https://github.com/Microsoft/WindowsTemplateStudio/blob/release/docs/UWP/pages/settings.md
    Public Class SettingsViewModel
        Inherits ObservableObject

        Private ReadOnly Property UserDataService As UserDataService
            Get
                Return Singleton(Of UserDataService).Instance
            End Get
        End Property

        Private ReadOnly Property IdentityService As IdentityService
            Get
                Return Singleton(Of IdentityService).Instance
            End Get
        End Property


        Private _elementTheme As ElementTheme = ThemeSelectorService.Theme

        Public Property ElementTheme As ElementTheme
            Get
                Return _elementTheme
            End Get

            Set
                [SetProperty](_elementTheme, value)
            End Set
        End Property

        Private _versionDescription As String

        Public Property VersionDescription As String
            Get
                Return _versionDescription
            End Get

            Set
                [SetProperty](_versionDescription, newValue := value)
            End Set
        End Property

        Private _switchThemeCommand As ICommand

        Public ReadOnly Property SwitchThemeCommand As ICommand
            Get
                If _switchThemeCommand Is Nothing Then
                    _switchThemeCommand = New RelayCommand(Of ElementTheme)(Async Sub(param)
                        Await ThemeSelectorService.SetThemeAsync(param)
                    End Sub)
                End If

                Return _switchThemeCommand
            End Get
        End Property

        Private _user As UserViewModel

        Private _logoutCommand As ICommand

        Public ReadOnly Property LogoutCommand As ICommand
            Get
                If _logoutCommand Is Nothing Then
                    _logoutCommand = New RelayCommand(AddressOf OnLogout)
                End If

                Return _logoutCommand
            End Get
        End Property

        Public Property User As UserViewModel
            Get
                Return _user
            End Get
            Set(value As UserViewModel)
                [SetProperty](_user, value)
            End Set
        End Property

        Public Sub New()
        End Sub

        Public Async Function InitializeAsync() As Task
            VersionDescription = GetVersionDescription()
            AddHandler IdentityService.LoggedOut, AddressOf OnLoggedOut
            AddHandler UserDataService.UserDataUpdated, AddressOf OnUserDataUpdated
            User = Await UserDataService.GetUserAsync()
        End Function

        Private Function GetVersionDescription() As String
            Dim appName = "AppDisplayName".GetLocalized()
            Dim package = Windows.ApplicationModel.Package.Current
            Dim packageId = package.Id
            Dim version = packageId.Version

            Return $"{appName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}"
        End Function

        Public Sub UnregisterEvents()
            RemoveHandler IdentityService.LoggedOut, AddressOf OnLoggedOut
            RemoveHandler UserDataService.UserDataUpdated, AddressOf OnUserDataUpdated
        End Sub

        Private Sub OnUserDataUpdated(sender As Object, userData As UserViewModel)
            User = userData
        End Sub

        Private Async Sub OnLogout()
            Await IdentityService.LogoutAsync()
        End Sub

        Private Sub OnLoggedOut(sender As Object, e As EventArgs)
            UnregisterEvents()
        End Sub
    End Class
End Namespace
