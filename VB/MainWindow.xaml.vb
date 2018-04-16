Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Input
Imports DevExpress.Data
Imports System.Collections.Generic
Imports DevExpress.Xpf.Grid

Namespace DragAndDrop_ReorderAndExternal

	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
			grid.ItemsSource = TestData.GetData()
			draggedRowsList.ItemsSource = New BindingList(Of TestData)()
		End Sub
	End Class

	#Region "TestData class"
	Public Class TestData
		Public Shared Function GetData(Optional ByVal count As Integer = 100) As BindingList(Of TestData)
			Dim list As New BindingList(Of TestData)()
			For i As Integer = 0 To count - 1
				list.Add(New TestData(i, "row " & i))
			Next i
			Return list
		End Function
		Private privateText As String
		Public Property Text() As String
			Get
				Return privateText
			End Get
			Set(ByVal value As String)
				privateText = value
			End Set
		End Property
		Private privateNumber As Integer
		Public Property Number() As Integer
			Get
				Return privateNumber
			End Get
			Set(ByVal value As Integer)
				privateNumber = value
			End Set
		End Property
		Public Sub New()
		End Sub
		Public Sub New(ByVal number As Integer, ByVal text As String)
			Number = number
			Text = text
		End Sub
		Public Overrides Function ToString() As String
			Return Text
		End Function
	End Class
	#End Region
End Namespace