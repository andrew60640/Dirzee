﻿#ExternalChecksum("C:\Users\Drew\source\repos\Dirzee_UWP\Views\ShellPage.xaml", "{8829d00f-11b8-4213-878b-770e8597ac16}", "2C8CE5E3085452836DD1ACAF62F219CCF9974DBA705E2B99B891D2C04E526341")
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
    Partial Class ShellPage
        Inherits Global.Windows.UI.Xaml.Controls.Page


        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", " 10.0.19041.685")>  _
        private WithEvents navigationView As Global.Microsoft.UI.Xaml.Controls.NavigationView
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", " 10.0.19041.685")>  _
        private WithEvents shellFrame As Global.Windows.UI.Xaml.Controls.Frame

        Private _contentLoaded As Boolean

        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", " 10.0.19041.685")>  _
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub InitializeComponent()
            If _contentLoaded Then
                Return
            End If
            _contentLoaded = true

            Dim resourceLocator As New Global.System.Uri("ms-appx:///Views/ShellPage.xaml")
            Global.Windows.UI.Xaml.Application.LoadComponent(Me, resourceLocator, Global.Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application)
        End Sub

        Partial Private Sub UnloadObject(unloadableObject As Global.Windows.UI.Xaml.DependencyObject)
        End Sub


        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", " 10.0.19041.685")>  _
        Private Interface IShellPage_Bindings
            Sub Initialize()
            Sub Update()
            Sub StopTracking()
            Sub DisconnectUnloadedObject(connectionId As Integer)
        End Interface

        Private Interface IShellPage_BindingsScopeConnector
            Property Parent() As Global.System.WeakReference
            Function ContainsElement(connectionId As Integer) As Boolean
            Sub RegisterForElementConnection(connectionId As Integer, connector As Global.Windows.UI.Xaml.Markup.IComponentConnector)
        End Interface

        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", " 10.0.19041.685")>  _
        Private Bindings As IShellPage_Bindings

    End Class

End Namespace


