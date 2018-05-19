Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Data.Filtering
Imports System.Windows.Forms

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Private spanOpen As String = "<span class='highlight'>"
	Private spanClose As String = "</span>"

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		gv.DataSource = Enumerable.Range(0, 9).Select(Function(i) New With {Key .CategoryID = i, Key .CategoryName = "CategoryName" & (i + 1), Key .Description = "Description" & (i + 2)})
		gv.DataBind()
	End Sub

	Protected Sub gv_HtmlDataCellPrepared(ByVal sender As Object, ByVal e As ASPxGridViewTableDataCellEventArgs)
		e.Cell.Text = GetCellText(e.CellValue.ToString())
		Dim gv As ASPxGridView = TryCast(sender, ASPxGridView)
	End Sub

	Protected Function GetCellText(ByVal cell_text As String) As String
		Dim cb As ASPxComboBox = TryCast(gv.FindFilterRowTemplateControl("cb"), ASPxComboBox)
		Dim serchText As String = cb.Text

		If serchText.Length > cell_text.Length Then
			Return cell_text
		End If

		If (Not String.IsNullOrEmpty(serchText)) Then
			Dim cell_text_lower As String = cell_text.ToLower()
			Dim serchText_lower As String = serchText.ToLower()
			Dim start_pos As Integer = cell_text_lower.IndexOf(serchText_lower)
			Dim span_length As Integer = spanOpen.Length
			If start_pos >= 0 Then
				cell_text = cell_text.Insert(start_pos, spanOpen)
				cell_text = cell_text.Insert(start_pos + span_length + serchText_lower.Length, spanClose)
			End If
		End If

		Return cell_text
	End Function

	Protected Sub gv_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
		Dim cb As ASPxComboBox = TryCast(gv.FindFilterRowTemplateControl("cb"), ASPxComboBox)
		If String.IsNullOrEmpty(cb.Text) OrElse e.Parameters.ToLower() <> "find" Then
			Return
		End If
		PopulateComboBoxDataSource(cb)
		SetGridViewFilterExpression(cb)
	End Sub

	Private Sub SetGridViewFilterExpression(ByVal cb As ASPxComboBox)
		Dim expression As String = String.Empty
		Dim b As New BinaryOperator()
		b.OperatorType = BinaryOperatorType.Like
		Dim op As New GroupOperator() With {.OperatorType = GroupOperatorType.Or}
		For Each column As GridViewDataColumn In gv.DataColumns
			Dim co As New FunctionOperator(FunctionOperatorType.Contains, New OperandProperty(column.FieldName), New OperandValue(cb.Text))
			op.Operands.Add(co)
		Next column
		gv.FilterExpression = op.ToString()
	End Sub

	Private Sub PopulateComboBoxDataSource(ByVal cb As ASPxComboBox)
		Dim values As List(Of String)
		If Session("cbDataSource") Is Nothing Then
			values = New List(Of String)(New String() { cb.Text })
		Else
			values = TryCast(Session("cbDataSource"), List(Of String))
		End If

		If (Not values.Contains(cb.Text)) Then
			values.Add(cb.Text)
		End If

		Session("cbDataSource") = values
	End Sub

	Protected Sub cb_Init(ByVal sender As Object, ByVal e As EventArgs)
		If Session("cbDataSource") IsNot Nothing Then
			Dim cb As ASPxComboBox = TryCast(sender, ASPxComboBox)
			cb.DataSource = TryCast(Session("cbDataSource"), List(Of String))
			cb.DataBind()
		End If
	End Sub
End Class