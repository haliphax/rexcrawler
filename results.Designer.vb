<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResults
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
Me.dgvResults = New System.Windows.Forms.DataGridView
Me.fileName = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.lineNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.fileText = New System.Windows.Forms.DataGridViewTextBoxColumn
CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'dgvResults
'
Me.dgvResults.AllowUserToAddRows = False
Me.dgvResults.AllowUserToDeleteRows = False
Me.dgvResults.AllowUserToOrderColumns = True
Me.dgvResults.AllowUserToResizeRows = False
Me.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.dgvResults.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fileName, Me.lineNumber, Me.fileText})
Me.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill
Me.dgvResults.Location = New System.Drawing.Point(0, 0)
Me.dgvResults.Margin = New System.Windows.Forms.Padding(0)
Me.dgvResults.Name = "dgvResults"
Me.dgvResults.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
Me.dgvResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.dgvResults.Size = New System.Drawing.Size(624, 442)
Me.dgvResults.TabIndex = 0
'
'fileName
'
Me.fileName.HeaderText = "File Name"
Me.fileName.Name = "fileName"
Me.fileName.ReadOnly = True
Me.fileName.Width = 150
'
'lineNumber
'
Me.lineNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
Me.lineNumber.HeaderText = "Line"
Me.lineNumber.Name = "lineNumber"
Me.lineNumber.ReadOnly = True
Me.lineNumber.Width = 52
'
'fileText
'
Me.fileText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
Me.fileText.HeaderText = "File Text"
Me.fileText.Name = "fileText"
Me.fileText.ReadOnly = True
'
'frmResults
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.AutoScroll = True
Me.AutoSize = True
Me.ClientSize = New System.Drawing.Size(624, 442)
Me.Controls.Add(Me.dgvResults)
Me.Name = "frmResults"
Me.ShowIcon = False
Me.Text = "Results"
CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

End Sub
	Friend WithEvents dgvResults As System.Windows.Forms.DataGridView
 Friend WithEvents fileName As System.Windows.Forms.DataGridViewTextBoxColumn
 Friend WithEvents lineNumber As System.Windows.Forms.DataGridViewTextBoxColumn
 Friend WithEvents fileText As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
