#ExternalChecksum("C:\Users\Drew\source\repos\Dirzee_UWP\Views\FirstRunDialog.xaml", "{8829d00f-11b8-4213-878b-770e8597ac16}", "02585416A63921315D9E485C3440C307C8679560F571519FBB36B9DAAE811092")
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On


Namespace Global.Dirzee_UWP.Views

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
    Partial Class FirstRunDialog
        Inherits Global.Windows.UI.Xaml.Controls.ContentDialog



        Private _contentLoaded As Boolean

        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", " 10.0.19041.685")>  _
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub InitializeComponent()
            If _contentLoaded Then
                Return
            End If
            _contentLoaded = true

            Dim resourceLocator As New Global.System.Uri("ms-appx:///Views/FirstRunDialog.xaml")
            Global.Windows.UI.Xaml.Application.LoadComponent(Me, resourceLocator, Global.Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application)
        End Sub

        Partial Private Sub UnloadObject(unloadableObject As Global.Windows.UI.Xaml.DependencyObject)
        End Sub


        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", " 10.0.19041.685")>  _
        Private Interface IFirstRunDialog_Bindings
            Sub Initialize()
            Sub Update()
            Sub StopTracking()
            Sub DisconnectUnloadedObject(connectionId As Integer)
        End Interface

        Private Interface IFirstRunDialog_BindingsScopeConnector
            Property Parent() As Global.System.WeakReference
            Function ContainsElement(connectionId As Integer) As Boolean
            Sub RegisterForElementConnection(connectionId As Integer, connector As Global.Windows.UI.Xaml.Markup.IComponentConnector)
        End Interface

        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", " 10.0.19041.685")>  _
        Private Bindings As IFirstRunDialog_Bindings

    End Class

End Namespace


