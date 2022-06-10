Imports Dirzee_UWP.Activation
Imports Dirzee_UWP.Core.Helpers
Imports Dirzee_UWP.Core.Services

Imports Windows.System
Imports Windows.UI.Core

Namespace Services
    ' For more information on understanding and extending activation flow see
    ' https://github.com/Microsoft/WindowsTemplateStudio/blob/release/docs/UWP/activation.md
    Friend Class ActivationService
        Private ReadOnly _app As App
        Private ReadOnly _defaultNavItem As Type
        Private _shell As Lazy(Of UIElement)

        Private _lastActivationArgs As Object

        Private ReadOnly Property IdentityService As IdentityService
            Get
                Return Singleton(Of IdentityService).Instance
            End Get
        End Property

        Private ReadOnly Property UserDataService As UserDataService
            Get
                Return Singleton(Of UserDataService).Instance
            End Get
        End Property


        Public Sub New(app As App, defaultNavItem As Type, Optional shell As Lazy(Of UIElement) = Nothing)
            _app = app
            _shell = shell
            _defaultNavItem = defaultNavItem
            AddHandler IdentityService.LoggedIn, AddressOf OnLoggedIn
        End Sub

        Public Async Function ActivateAsync(activationArgs As Object) As Task
            If IsInteractive(activationArgs) Then
                ' Initialize services that you need before app activation
                ' take into account that the splash screen is shown while this code runs.
                Await InitializeAsync()
                UserDataService.Initialize()
                IdentityService.InitializeWithAadAndPersonalMsAccounts()
                Dim silentLoginSuccess = Await IdentityService.AcquireTokenSilentAsync()

                If Not silentLoginSuccess OrElse Not IdentityService.IsAuthorized() Then
                    Await RedirectLoginPageAsync()
                End If

                ' Do not repeat app initialization when the Window already has content,
                ' just ensure that the window is active
                If Window.Current.Content Is Nothing Then
                    ' Create a Shell or Frame to act as the navigation context
                    Window.Current.Content = If(_shell?.Value, New Frame())
                End If
            End If

            ' Depending on activationArgs one of ActivationHandlers or DefaultActivationHandler
            ' will navigate to the first page

            If IdentityService.IsLoggedIn() Then
                Await HandleActivationAsync(activationArgs)
            End If

            _lastActivationArgs = activationArgs

            If IsInteractive(activationArgs) Then
                Dim Activation = TryCast(activationArgs, IActivatedEventArgs)
                If Activation IsNot Nothing AndAlso Activation.PreviousExecutionState = ApplicationExecutionState.Terminated Then
                    Await Singleton(Of SuspendAndResumeService).Instance.RestoreSuspendAndResumeData()
                End If

                ' Ensure the current window is active
                Window.Current.Activate()

                ' Tasks after activation
                Await StartupAsync()
            End If
        End Function


        Private Async Sub OnLoggedIn(sender As Object, e As EventArgs)
            If _shell?.Value IsNot Nothing Then
                Window.Current.Content = _shell.Value
            Else
                Dim frame = New Frame()
                Window.Current.Content = frame
                NavigationService.Frame = frame
            End If

            Await ThemeSelectorService.SetRequestedThemeAsync()
            Await HandleActivationAsync(_lastActivationArgs)
        End Sub

        Private Async Function InitializeAsync() As Task
            Await Singleton(Of LiveTileService).Instance.EnableQueueAsync().ConfigureAwait(False)
            Await Singleton(Of BackgroundTaskService).Instance.RegisterBackgroundTasksAsync().ConfigureAwait(False)
            Await ThemeSelectorService.InitializeAsync()
        End Function

        Private Async Function HandleActivationAsync(activationArgs As Object) As Task
            Dim activationHandler = GetActivationHandlers().FirstOrDefault(Function(h) h.CanHandle(activationArgs))

            If activationHandler IsNot Nothing Then
                Await activationHandler.HandleAsync(activationArgs)
            End If

            If IsInteractive(activationArgs) Then
                Dim defaultHandler = New DefaultActivationHandler(_defaultNavItem)

                If defaultHandler.CanHandle(activationArgs) Then
                    Await defaultHandler.HandleAsync(activationArgs)
                End If
            End If
        End Function

        Private Async Function StartupAsync() As Task
            ' TODO WTS: This is a sample to demonstrate how to add a UserActivity. Please adapt and move this method call to where you consider convenient in your app.
            Await UserActivityService.AddSampleUserActivity()
            Await ThemeSelectorService.SetRequestedThemeAsync()
            Await FirstRunDisplayService.ShowIfAppropriateAsync()
            Await WhatsNewDisplayService.ShowIfAppropriateAsync()
            Singleton(Of LiveTileService).Instance.SampleUpdate()
        End Function

        Private Iterator Function GetActivationHandlers() As IEnumerable(Of ActivationHandler)
            yield Singleton(Of LiveTileService).Instance
            yield Singleton(Of ToastNotificationsService).Instance
            yield Singleton(Of BackgroundTaskService).Instance
            Yield Singleton(Of SuspendAndResumeService).Instance
            Yield Singleton(Of SchemeActivationHandler).Instance
        End Function

        Private Function IsInteractive(args As Object) As Boolean
            Return TypeOf args Is IActivatedEventArgs
        End Function

        Public Sub SetShell(shell As Lazy(Of UIElement))
            _shell = shell
        End Sub

        Public Async Function RedirectLoginPageAsync() As Task
            Dim frame = New Frame()
            NavigationService.Frame = frame
            Window.Current.Content = frame
            Await ThemeSelectorService.SetRequestedThemeAsync()
            NavigationService.Navigate(Of Views.LogInPage)()
        End Function
    End Class
End Namespace
