Imports Dirzee_UWP.ViewModels

Namespace Views
    Public NotInheritable Partial Class BrowseMewePage
        Inherits Page

        property ViewModel as BrowseMeweViewModel = New BrowseMeweViewModel

        Public Sub New()
            InitializeComponent()
            ViewModel.Initialize(webView)
        End Sub
    End Class
End Namespace
