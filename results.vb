Public Class frmResults
	Private ctxMenu As ContextMenu
	Private ctxMenuCopy As New MenuItem("Copy" & vbTab & "(Ctrl + C)", New EventHandler(AddressOf CopyCells))
	Private ctxMenuOpen As New MenuItem("Open" & vbTab & "(Double Click)", New EventHandler(AddressOf OpenFile))

	Private Sub Form1_Load( _
	ByVal sender As System.Object, _
	ByVal e As System.EventArgs) _
	Handles MyBase.Load
		ctxMenu = New ContextMenu()
		ctxMenu.MenuItems.Add(ctxMenuCopy)
		ctxMenu.MenuItems.Add(ctxMenuOpen)
	End Sub

	Private Sub dgvResults_MouseUp( _
	ByVal sender As Object, _
	ByVal e As MouseEventArgs) _
	Handles dgvResults.MouseUp
		Dim hit As DataGridView.HitTestInfo = dgvResults.HitTest(e.X, e.Y)

		If e.Button = Windows.Forms.MouseButtons.Right Then
			If dgvResults.SelectedCells.Count = 1 Then
				ctxMenuOpen.Enabled = True
				'ctxMenuOpen.Visible = True
			Else
				ctxMenuOpen.Enabled = False
				'ctxMenuOpen.Visible = False
			End If

			ctxMenu.Show(dgvResults, New Point(e.X, e.Y))
		End If
	End Sub

	Private Sub CopyCells()
		Try
			Clipboard.SetDataObject(dgvResults.GetClipboardContent())
		Catch ex As Exception
			MsgBox("Error copying data to the clipboard", MsgBoxStyle.Critical, "Error")
		End Try
	End Sub

	Private Sub dgvResults_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvResults.CellContentDoubleClick
		If dgvResults.Columns(e.ColumnIndex).Name <> "fileName" Then Exit Sub
		OpenFile()
	End Sub

	Private Sub OpenFile()
		If dgvResults.SelectedCells.Count <> 1 Then Exit Sub
		Process.Start(dgvResults.SelectedCells(0).Value)
	End Sub
End Class