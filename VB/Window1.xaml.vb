Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Input
Imports DevExpress.Data

Namespace DragAndDrop_ReorderAndExternal

	Partial Public Class Window1
		Inherits Window
		Private list As BindingList(Of TestData)
		Private draggedRows As New BindingList(Of TestData)()
		Private dragStarted As Boolean

		Public Sub New()
			InitializeComponent()

'			#Region "Data binding"
			list = New BindingList(Of TestData)()
			For i As Integer = 0 To 99
				list.Add(New TestData() With {.Text = "row " & i, .Number = i})
			Next i
			grid.ItemsSource = list
'			#End Region

			view.AllowDrop = True
			draggedRowsList.AllowDrop = True

			AddHandler view.PreviewMouseDown, AddressOf View_PreviewMouseDown
			AddHandler view.PreviewMouseMove, AddressOf View_PreviewMouseMove
			AddHandler view.DragOver, AddressOf View_DragOver
			AddHandler view.Drop, AddressOf View_Drop

			AddHandler draggedRowsList.DragOver, AddressOf draggedRowsList_DragOver
			AddHandler draggedRowsList.Drop, AddressOf draggedRowsList_Drop
			draggedRowsList.ItemsSource = draggedRows
		End Sub

		Private Sub draggedRowsList_Drop(ByVal sender As Object, ByVal e As DragEventArgs)
			Dim rowHandle As Integer = CInt(Fix(e.Data.GetData(GetType(Integer))))
			Dim obj As TestData = CType(grid.GetRow(rowHandle), TestData)
			If (Not draggedRows.Contains(obj)) Then
				draggedRows.Add(obj)
			End If
		End Sub

		Private Sub draggedRowsList_DragOver(ByVal sender As Object, ByVal e As DragEventArgs)
			Dim rowHandle As Integer = CInt(Fix(e.Data.GetData(GetType(Integer))))
			Dim obj As TestData = CType(grid.GetRow(rowHandle), TestData)
			e.Effects = If(draggedRows.Contains(obj), DragDropEffects.None, DragDropEffects.Move)
			e.Handled = True
		End Sub

		Private Sub View_Drop(ByVal sender As Object, ByVal e As DragEventArgs)
			Dim rowHandle As Integer = CInt(Fix(e.Data.GetData(GetType(Integer))))
			Dim obj As TestData = CType(grid.GetRow(rowHandle), TestData)
			Dim insertRowHandle As Integer = view.GetRowHandleByTreeElement(TryCast(e.OriginalSource, DependencyObject))
			Dim insertListIndex As Integer = grid.GetRowListIndex(insertRowHandle)
			If IsCopyEffect(e) Then
				list.Insert(insertListIndex, New TestData() With {.Text = obj.Text & " (Copy)", .Number = obj.Number})
			Else
				list.Remove(obj)
				list.Insert(insertListIndex, obj)
			End If
		End Sub

		Private Sub View_DragOver(ByVal sender As Object, ByVal e As DragEventArgs)
			If view.GetRowElementByTreeElement(TryCast(e.OriginalSource, DependencyObject)) IsNot Nothing Then
				e.Effects = If(IsCopyEffect(e), DragDropEffects.Copy, DragDropEffects.Move)
			Else
				e.Effects = DragDropEffects.None
			End If
			e.Handled = True
		End Sub

		Private Function IsCopyEffect(ByVal e As DragEventArgs) As Boolean
			Return (e.KeyStates And DragDropKeyStates.ControlKey) = DragDropKeyStates.ControlKey
		End Function

		Private Sub View_PreviewMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim rowHandle As Integer = view.GetRowHandleByMouseEventArgs(e)
			If dragStarted Then
				Dim data As DataObject = CreateDataObject(rowHandle)
				DragDrop.DoDragDrop(view.GetRowElementByMouseEventArgs(e), data, DragDropEffects.Move Or DragDropEffects.Copy)
				dragStarted = False
			End If
		End Sub

		Private Sub View_PreviewMouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			Dim rowHandle As Integer = view.GetRowHandleByMouseEventArgs(e)
			If rowHandle <> GridDataController.InvalidRow Then
				dragStarted = True
			End If
		End Sub

		Private Function CreateDataObject(ByVal rowHandle As Integer) As DataObject
			Dim data As New DataObject()
			data.SetData(GetType(Integer), rowHandle)
			Return data
		End Function
	End Class

	#Region "TestData class"
	Public Class TestData
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
	End Class
	#End Region
End Namespace