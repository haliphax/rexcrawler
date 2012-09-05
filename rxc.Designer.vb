<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rexCrawler
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rexCrawler))
        Me.pnlForm = New System.Windows.Forms.Panel
        Me.chkNoErrors = New System.Windows.Forms.CheckBox
        Me.chkSaveFile = New System.Windows.Forms.CheckBox
        Me.chkFilterContents = New System.Windows.Forms.CheckBox
        Me.chkFilterFilename = New System.Windows.Forms.CheckBox
        Me.chkOutputScreen = New System.Windows.Forms.CheckBox
        Me.btnOutputFile = New System.Windows.Forms.Button
        Me.txtOutputFile = New System.Windows.Forms.TextBox
        Me.lblRootFolder = New System.Windows.Forms.Label
        Me.btnRootFolder = New System.Windows.Forms.Button
        Me.lblOutputFile = New System.Windows.Forms.Label
        Me.txtRootFolder = New System.Windows.Forms.TextBox
        Me.pnlContentsFilter = New System.Windows.Forms.Panel
        Me.chkContentsCase = New System.Windows.Forms.CheckBox
        Me.chkIgnoreNL = New System.Windows.Forms.CheckBox
        Me.chkLines = New System.Windows.Forms.CheckBox
        Me.chkWholeFile = New System.Windows.Forms.CheckBox
        Me.radContentsPlain = New System.Windows.Forms.RadioButton
        Me.radContentsRegex = New System.Windows.Forms.RadioButton
        Me.txtContentsFilter = New System.Windows.Forms.TextBox
        Me.lblTextFilter = New System.Windows.Forms.Label
        Me.pnlFileFilter = New System.Windows.Forms.Panel
        Me.chkFileCase = New System.Windows.Forms.CheckBox
        Me.radFilePlain = New System.Windows.Forms.RadioButton
        Me.radFileWildcard = New System.Windows.Forms.RadioButton
        Me.radFileExt = New System.Windows.Forms.RadioButton
        Me.radFileRegex = New System.Windows.Forms.RadioButton
        Me.txtFileFilter = New System.Windows.Forms.TextBox
        Me.lblFileFilter = New System.Windows.Forms.Label
        Me.pnlRootFolder = New System.Windows.Forms.Panel
        Me.chkNoSubDirs = New System.Windows.Forms.CheckBox
        Me.btnCrawl = New System.Windows.Forms.Button
        Me.lblStatus = New System.Windows.Forms.Label
        Me.dlgRootFolder = New System.Windows.Forms.FolderBrowserDialog
        Me.dlgSaveFile = New System.Windows.Forms.SaveFileDialog
        Me.mnsMenu = New System.Windows.Forms.MenuStrip
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.barCrawling = New System.Windows.Forms.ProgressBar
        Me.pnlForm.SuspendLayout()
        Me.pnlContentsFilter.SuspendLayout()
        Me.pnlFileFilter.SuspendLayout()
        Me.pnlRootFolder.SuspendLayout()
        Me.mnsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlForm
        '
        Me.pnlForm.AutoSize = True
        Me.pnlForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlForm.Controls.Add(Me.chkNoErrors)
        Me.pnlForm.Controls.Add(Me.chkSaveFile)
        Me.pnlForm.Controls.Add(Me.chkFilterContents)
        Me.pnlForm.Controls.Add(Me.chkFilterFilename)
        Me.pnlForm.Controls.Add(Me.chkOutputScreen)
        Me.pnlForm.Controls.Add(Me.btnOutputFile)
        Me.pnlForm.Controls.Add(Me.txtOutputFile)
        Me.pnlForm.Controls.Add(Me.lblRootFolder)
        Me.pnlForm.Controls.Add(Me.btnRootFolder)
        Me.pnlForm.Controls.Add(Me.lblOutputFile)
        Me.pnlForm.Controls.Add(Me.txtRootFolder)
        Me.pnlForm.Controls.Add(Me.pnlContentsFilter)
        Me.pnlForm.Controls.Add(Me.txtContentsFilter)
        Me.pnlForm.Controls.Add(Me.lblTextFilter)
        Me.pnlForm.Controls.Add(Me.pnlFileFilter)
        Me.pnlForm.Controls.Add(Me.txtFileFilter)
        Me.pnlForm.Controls.Add(Me.lblFileFilter)
        Me.pnlForm.Controls.Add(Me.pnlRootFolder)
        Me.pnlForm.Location = New System.Drawing.Point(9, 24)
        Me.pnlForm.Margin = New System.Windows.Forms.Padding(0, 0, 6, 0)
        Me.pnlForm.Name = "pnlForm"
        Me.pnlForm.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
        Me.pnlForm.Size = New System.Drawing.Size(282, 429)
        Me.pnlForm.TabIndex = 0
        '
        'chkNoErrors
        '
        Me.chkNoErrors.AutoSize = True
        Me.chkNoErrors.Location = New System.Drawing.Point(133, 409)
        Me.chkNoErrors.Name = "chkNoErrors"
        Me.chkNoErrors.Size = New System.Drawing.Size(85, 17)
        Me.chkNoErrors.TabIndex = 0
        Me.chkNoErrors.TabStop = False
        Me.chkNoErrors.Text = "Ignore errors"
        Me.chkNoErrors.UseVisualStyleBackColor = True
        '
        'chkSaveFile
        '
        Me.chkSaveFile.AutoSize = True
        Me.chkSaveFile.Location = New System.Drawing.Point(261, 364)
        Me.chkSaveFile.Name = "chkSaveFile"
        Me.chkSaveFile.Size = New System.Drawing.Size(15, 14)
        Me.chkSaveFile.TabIndex = 12
        Me.chkSaveFile.TabStop = False
        Me.chkSaveFile.UseVisualStyleBackColor = True
        '
        'chkFilterContents
        '
        Me.chkFilterContents.AutoSize = True
        Me.chkFilterContents.Checked = True
        Me.chkFilterContents.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFilterContents.Location = New System.Drawing.Point(261, 222)
        Me.chkFilterContents.Name = "chkFilterContents"
        Me.chkFilterContents.Size = New System.Drawing.Size(15, 14)
        Me.chkFilterContents.TabIndex = 99
        Me.chkFilterContents.TabStop = False
        Me.chkFilterContents.UseVisualStyleBackColor = True
        '
        'chkFilterFilename
        '
        Me.chkFilterFilename.AutoSize = True
        Me.chkFilterFilename.Checked = True
        Me.chkFilterFilename.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFilterFilename.Location = New System.Drawing.Point(261, 80)
        Me.chkFilterFilename.Name = "chkFilterFilename"
        Me.chkFilterFilename.Size = New System.Drawing.Size(15, 14)
        Me.chkFilterFilename.TabIndex = 99
        Me.chkFilterFilename.TabStop = False
        Me.chkFilterFilename.UseVisualStyleBackColor = True
        '
        'chkOutputScreen
        '
        Me.chkOutputScreen.AutoSize = True
        Me.chkOutputScreen.Checked = True
        Me.chkOutputScreen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOutputScreen.Location = New System.Drawing.Point(12, 409)
        Me.chkOutputScreen.Name = "chkOutputScreen"
        Me.chkOutputScreen.Size = New System.Drawing.Size(105, 17)
        Me.chkOutputScreen.TabIndex = 15
        Me.chkOutputScreen.TabStop = False
        Me.chkOutputScreen.Text = "Output to screen"
        Me.chkOutputScreen.UseVisualStyleBackColor = True
        '
        'btnOutputFile
        '
        Me.btnOutputFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnOutputFile.Enabled = False
        Me.btnOutputFile.Location = New System.Drawing.Point(253, 383)
        Me.btnOutputFile.Name = "btnOutputFile"
        Me.btnOutputFile.Size = New System.Drawing.Size(26, 20)
        Me.btnOutputFile.TabIndex = 14
        Me.btnOutputFile.TabStop = False
        Me.btnOutputFile.Text = "..."
        Me.btnOutputFile.UseVisualStyleBackColor = True
        '
        'txtOutputFile
        '
        Me.txtOutputFile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtOutputFile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.txtOutputFile.Enabled = False
        Me.txtOutputFile.Location = New System.Drawing.Point(0, 383)
        Me.txtOutputFile.Name = "txtOutputFile"
        Me.txtOutputFile.Size = New System.Drawing.Size(259, 20)
        Me.txtOutputFile.TabIndex = 3
        '
        'lblRootFolder
        '
        Me.lblRootFolder.AutoSize = True
        Me.lblRootFolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRootFolder.Location = New System.Drawing.Point(3, 8)
        Me.lblRootFolder.Name = "lblRootFolder"
        Me.lblRootFolder.Size = New System.Drawing.Size(89, 16)
        Me.lblRootFolder.TabIndex = 0
        Me.lblRootFolder.Text = "Root folder:"
        '
        'btnRootFolder
        '
        Me.btnRootFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnRootFolder.Location = New System.Drawing.Point(253, 27)
        Me.btnRootFolder.Name = "btnRootFolder"
        Me.btnRootFolder.Size = New System.Drawing.Size(26, 20)
        Me.btnRootFolder.TabIndex = 99
        Me.btnRootFolder.TabStop = False
        Me.btnRootFolder.Text = "..."
        Me.btnRootFolder.UseVisualStyleBackColor = True
        '
        'lblOutputFile
        '
        Me.lblOutputFile.AutoSize = True
        Me.lblOutputFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutputFile.Location = New System.Drawing.Point(3, 364)
        Me.lblOutputFile.Name = "lblOutputFile"
        Me.lblOutputFile.Size = New System.Drawing.Size(56, 16)
        Me.lblOutputFile.TabIndex = 0
        Me.lblOutputFile.Text = "Output:"
        '
        'txtRootFolder
        '
        Me.txtRootFolder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtRootFolder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.txtRootFolder.Location = New System.Drawing.Point(0, 27)
        Me.txtRootFolder.Name = "txtRootFolder"
        Me.txtRootFolder.Size = New System.Drawing.Size(259, 20)
        Me.txtRootFolder.TabIndex = 0
        '
        'pnlContentsFilter
        '
        Me.pnlContentsFilter.AutoSize = True
        Me.pnlContentsFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlContentsFilter.Controls.Add(Me.chkContentsCase)
        Me.pnlContentsFilter.Controls.Add(Me.chkIgnoreNL)
        Me.pnlContentsFilter.Controls.Add(Me.chkLines)
        Me.pnlContentsFilter.Controls.Add(Me.chkWholeFile)
        Me.pnlContentsFilter.Controls.Add(Me.radContentsPlain)
        Me.pnlContentsFilter.Controls.Add(Me.radContentsRegex)
        Me.pnlContentsFilter.Location = New System.Drawing.Point(6, 268)
        Me.pnlContentsFilter.Name = "pnlContentsFilter"
        Me.pnlContentsFilter.Size = New System.Drawing.Size(256, 93)
        Me.pnlContentsFilter.TabIndex = 99
        '
        'chkContentsCase
        '
        Me.chkContentsCase.AutoSize = True
        Me.chkContentsCase.Location = New System.Drawing.Point(127, 4)
        Me.chkContentsCase.Name = "chkContentsCase"
        Me.chkContentsCase.Size = New System.Drawing.Size(94, 17)
        Me.chkContentsCase.TabIndex = 0
        Me.chkContentsCase.TabStop = False
        Me.chkContentsCase.Text = "Case sensitive"
        Me.chkContentsCase.UseVisualStyleBackColor = True
        '
        'chkIgnoreNL
        '
        Me.chkIgnoreNL.AutoSize = True
        Me.chkIgnoreNL.Enabled = False
        Me.chkIgnoreNL.Location = New System.Drawing.Point(127, 73)
        Me.chkIgnoreNL.Name = "chkIgnoreNL"
        Me.chkIgnoreNL.Size = New System.Drawing.Size(98, 17)
        Me.chkIgnoreNL.TabIndex = 0
        Me.chkIgnoreNL.TabStop = False
        Me.chkIgnoreNL.Text = "Ignore new line"
        Me.chkIgnoreNL.UseVisualStyleBackColor = True
        '
        'chkLines
        '
        Me.chkLines.AutoSize = True
        Me.chkLines.Location = New System.Drawing.Point(127, 27)
        Me.chkLines.Name = "chkLines"
        Me.chkLines.Size = New System.Drawing.Size(126, 17)
        Me.chkLines.TabIndex = 0
        Me.chkLines.TabStop = False
        Me.chkLines.Text = "Output matched lines"
        Me.chkLines.UseVisualStyleBackColor = True
        '
        'chkWholeFile
        '
        Me.chkWholeFile.AutoSize = True
        Me.chkWholeFile.Location = New System.Drawing.Point(127, 50)
        Me.chkWholeFile.Name = "chkWholeFile"
        Me.chkWholeFile.Size = New System.Drawing.Size(73, 17)
        Me.chkWholeFile.TabIndex = 0
        Me.chkWholeFile.TabStop = False
        Me.chkWholeFile.Text = "Whole file"
        Me.chkWholeFile.UseVisualStyleBackColor = True
        '
        'radContentsPlain
        '
        Me.radContentsPlain.AutoSize = True
        Me.radContentsPlain.Checked = True
        Me.radContentsPlain.Location = New System.Drawing.Point(6, 4)
        Me.radContentsPlain.Name = "radContentsPlain"
        Me.radContentsPlain.Size = New System.Drawing.Size(68, 17)
        Me.radContentsPlain.TabIndex = 0
        Me.radContentsPlain.TabStop = True
        Me.radContentsPlain.Text = "Plain text"
        Me.radContentsPlain.UseVisualStyleBackColor = True
        '
        'radContentsRegex
        '
        Me.radContentsRegex.AutoSize = True
        Me.radContentsRegex.Location = New System.Drawing.Point(6, 27)
        Me.radContentsRegex.Name = "radContentsRegex"
        Me.radContentsRegex.Size = New System.Drawing.Size(115, 17)
        Me.radContentsRegex.TabIndex = 0
        Me.radContentsRegex.Text = "Regular expression"
        Me.radContentsRegex.UseVisualStyleBackColor = True
        '
        'txtContentsFilter
        '
        Me.txtContentsFilter.Location = New System.Drawing.Point(0, 241)
        Me.txtContentsFilter.Name = "txtContentsFilter"
        Me.txtContentsFilter.Size = New System.Drawing.Size(276, 20)
        Me.txtContentsFilter.TabIndex = 2
        '
        'lblTextFilter
        '
        Me.lblTextFilter.AutoSize = True
        Me.lblTextFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextFilter.Location = New System.Drawing.Point(3, 222)
        Me.lblTextFilter.Name = "lblTextFilter"
        Me.lblTextFilter.Size = New System.Drawing.Size(134, 16)
        Me.lblTextFilter.TabIndex = 0
        Me.lblTextFilter.Text = "File contents filter:"
        '
        'pnlFileFilter
        '
        Me.pnlFileFilter.AutoSize = True
        Me.pnlFileFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlFileFilter.Controls.Add(Me.chkFileCase)
        Me.pnlFileFilter.Controls.Add(Me.radFilePlain)
        Me.pnlFileFilter.Controls.Add(Me.radFileWildcard)
        Me.pnlFileFilter.Controls.Add(Me.radFileExt)
        Me.pnlFileFilter.Controls.Add(Me.radFileRegex)
        Me.pnlFileFilter.Location = New System.Drawing.Point(6, 126)
        Me.pnlFileFilter.Name = "pnlFileFilter"
        Me.pnlFileFilter.Size = New System.Drawing.Size(224, 93)
        Me.pnlFileFilter.TabIndex = 99
        '
        'chkFileCase
        '
        Me.chkFileCase.AutoSize = True
        Me.chkFileCase.Location = New System.Drawing.Point(127, 4)
        Me.chkFileCase.Name = "chkFileCase"
        Me.chkFileCase.Size = New System.Drawing.Size(94, 17)
        Me.chkFileCase.TabIndex = 0
        Me.chkFileCase.TabStop = False
        Me.chkFileCase.Text = "Case sensitive"
        Me.chkFileCase.UseVisualStyleBackColor = True
        '
        'radFilePlain
        '
        Me.radFilePlain.AutoSize = True
        Me.radFilePlain.Location = New System.Drawing.Point(6, 27)
        Me.radFilePlain.Name = "radFilePlain"
        Me.radFilePlain.Size = New System.Drawing.Size(68, 17)
        Me.radFilePlain.TabIndex = 0
        Me.radFilePlain.Text = "Plain text"
        Me.radFilePlain.UseVisualStyleBackColor = True
        '
        'radFileWildcard
        '
        Me.radFileWildcard.AutoSize = True
        Me.radFileWildcard.Checked = True
        Me.radFileWildcard.Location = New System.Drawing.Point(6, 4)
        Me.radFileWildcard.Name = "radFileWildcard"
        Me.radFileWildcard.Size = New System.Drawing.Size(67, 17)
        Me.radFileWildcard.TabIndex = 0
        Me.radFileWildcard.TabStop = True
        Me.radFileWildcard.Text = "Wildcard"
        Me.radFileWildcard.UseVisualStyleBackColor = True
        '
        'radFileExt
        '
        Me.radFileExt.AutoSize = True
        Me.radFileExt.Enabled = False
        Me.radFileExt.Location = New System.Drawing.Point(6, 73)
        Me.radFileExt.Name = "radFileExt"
        Me.radFileExt.Size = New System.Drawing.Size(106, 17)
        Me.radFileExt.TabIndex = 0
        Me.radFileExt.Text = "List of extensions"
        Me.radFileExt.UseVisualStyleBackColor = True
        '
        'radFileRegex
        '
        Me.radFileRegex.AutoSize = True
        Me.radFileRegex.Location = New System.Drawing.Point(6, 50)
        Me.radFileRegex.Name = "radFileRegex"
        Me.radFileRegex.Size = New System.Drawing.Size(115, 17)
        Me.radFileRegex.TabIndex = 0
        Me.radFileRegex.Text = "Regular expression"
        Me.radFileRegex.UseVisualStyleBackColor = True
        '
        'txtFileFilter
        '
        Me.txtFileFilter.Location = New System.Drawing.Point(0, 100)
        Me.txtFileFilter.Name = "txtFileFilter"
        Me.txtFileFilter.Size = New System.Drawing.Size(276, 20)
        Me.txtFileFilter.TabIndex = 1
        '
        'lblFileFilter
        '
        Me.lblFileFilter.AutoSize = True
        Me.lblFileFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileFilter.Location = New System.Drawing.Point(3, 81)
        Me.lblFileFilter.Name = "lblFileFilter"
        Me.lblFileFilter.Size = New System.Drawing.Size(114, 16)
        Me.lblFileFilter.TabIndex = 0
        Me.lblFileFilter.Text = "File name filter:"
        '
        'pnlRootFolder
        '
        Me.pnlRootFolder.AutoSize = True
        Me.pnlRootFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlRootFolder.Controls.Add(Me.chkNoSubDirs)
        Me.pnlRootFolder.Location = New System.Drawing.Point(7, 54)
        Me.pnlRootFolder.Name = "pnlRootFolder"
        Me.pnlRootFolder.Size = New System.Drawing.Size(141, 23)
        Me.pnlRootFolder.TabIndex = 17
        '
        'chkNoSubDirs
        '
        Me.chkNoSubDirs.AutoSize = True
        Me.chkNoSubDirs.Location = New System.Drawing.Point(3, 3)
        Me.chkNoSubDirs.Name = "chkNoSubDirs"
        Me.chkNoSubDirs.Size = New System.Drawing.Size(135, 17)
        Me.chkNoSubDirs.TabIndex = 99
        Me.chkNoSubDirs.TabStop = False
        Me.chkNoSubDirs.Text = "Exclude sub-directories"
        Me.chkNoSubDirs.UseVisualStyleBackColor = True
        '
        'btnCrawl
        '
        Me.btnCrawl.Location = New System.Drawing.Point(9, 460)
        Me.btnCrawl.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.btnCrawl.Name = "btnCrawl"
        Me.btnCrawl.Size = New System.Drawing.Size(75, 23)
        Me.btnCrawl.TabIndex = 0
        Me.btnCrawl.TabStop = False
        Me.btnCrawl.Text = "Crawl"
        Me.btnCrawl.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(90, 460)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(195, 23)
        Me.lblStatus.TabIndex = 0
        Me.lblStatus.Text = "Click ""Crawl"" to begin."
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dlgRootFolder
        '
        Me.dlgRootFolder.Description = "Select the top-most folder to search:"
        Me.dlgRootFolder.RootFolder = System.Environment.SpecialFolder.MyComputer
        Me.dlgRootFolder.ShowNewFolderButton = False
        '
        'dlgSaveFile
        '
        Me.dlgSaveFile.Filter = "Comma-separated values (*.csv)|*.csv|Text files (*.txt)|*.txt|All files (*.*)|*.*" & _
            ""
        Me.dlgSaveFile.Title = "Output file"
        '
        'mnsMenu
        '
        Me.mnsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAbout, Me.HelpToolStripMenuItem})
        Me.mnsMenu.Location = New System.Drawing.Point(0, 0)
        Me.mnsMenu.Name = "mnsMenu"
        Me.mnsMenu.Padding = New System.Windows.Forms.Padding(0)
        Me.mnsMenu.Size = New System.Drawing.Size(561, 24)
        Me.mnsMenu.TabIndex = 3
        Me.mnsMenu.Text = "Menu"
        '
        'mnuAbout
        '
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(48, 24)
        Me.mnuAbout.Text = "About"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 24)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'barCrawling
        '
        Me.barCrawling.Location = New System.Drawing.Point(9, 489)
        Me.barCrawling.MarqueeAnimationSpeed = 0
        Me.barCrawling.Name = "barCrawling"
        Me.barCrawling.Size = New System.Drawing.Size(279, 23)
        Me.barCrawling.TabIndex = 4
        '
        'rexCrawler
        '
        Me.AcceptButton = Me.btnCrawl
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(561, 567)
        Me.Controls.Add(Me.barCrawling)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnCrawl)
        Me.Controls.Add(Me.pnlForm)
        Me.Controls.Add(Me.mnsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnsMenu
        Me.MaximizeBox = False
        Me.Name = "rexCrawler"
        Me.Padding = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "rexCrawler"
        Me.pnlForm.ResumeLayout(False)
        Me.pnlForm.PerformLayout()
        Me.pnlContentsFilter.ResumeLayout(False)
        Me.pnlContentsFilter.PerformLayout()
        Me.pnlFileFilter.ResumeLayout(False)
        Me.pnlFileFilter.PerformLayout()
        Me.pnlRootFolder.ResumeLayout(False)
        Me.pnlRootFolder.PerformLayout()
        Me.mnsMenu.ResumeLayout(False)
        Me.mnsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlForm As System.Windows.Forms.Panel
    Friend WithEvents pnlFileFilter As System.Windows.Forms.Panel
    Friend WithEvents radFileExt As System.Windows.Forms.RadioButton
    Friend WithEvents radFileRegex As System.Windows.Forms.RadioButton
    Friend WithEvents txtFileFilter As System.Windows.Forms.TextBox
    Friend WithEvents lblFileFilter As System.Windows.Forms.Label
    Friend WithEvents btnOutputFile As System.Windows.Forms.Button
    Friend WithEvents btnRootFolder As System.Windows.Forms.Button
    Friend WithEvents txtOutputFile As System.Windows.Forms.TextBox
    Friend WithEvents lblOutputFile As System.Windows.Forms.Label
    Friend WithEvents txtRootFolder As System.Windows.Forms.TextBox
    Friend WithEvents lblRootFolder As System.Windows.Forms.Label
    Friend WithEvents pnlContentsFilter As System.Windows.Forms.Panel
    Friend WithEvents radContentsPlain As System.Windows.Forms.RadioButton
    Friend WithEvents radContentsRegex As System.Windows.Forms.RadioButton
    Friend WithEvents txtContentsFilter As System.Windows.Forms.TextBox
    Friend WithEvents lblTextFilter As System.Windows.Forms.Label
    Friend WithEvents btnCrawl As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents dlgRootFolder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents dlgSaveFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents mnsMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents radFilePlain As System.Windows.Forms.RadioButton
    Friend WithEvents radFileWildcard As System.Windows.Forms.RadioButton
    Friend WithEvents chkLines As System.Windows.Forms.CheckBox
    Friend WithEvents chkWholeFile As System.Windows.Forms.CheckBox
    Friend WithEvents chkIgnoreNL As System.Windows.Forms.CheckBox
    Friend WithEvents chkNoSubDirs As System.Windows.Forms.CheckBox
    Friend WithEvents chkOutputScreen As System.Windows.Forms.CheckBox
    Friend WithEvents chkFilterFilename As System.Windows.Forms.CheckBox
    Friend WithEvents chkFilterContents As System.Windows.Forms.CheckBox
    Friend WithEvents chkContentsCase As System.Windows.Forms.CheckBox
    Friend WithEvents chkFileCase As System.Windows.Forms.CheckBox
    Friend WithEvents chkSaveFile As System.Windows.Forms.CheckBox
    Friend WithEvents pnlRootFolder As System.Windows.Forms.Panel
    Friend WithEvents chkNoErrors As System.Windows.Forms.CheckBox
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents barCrawling As System.Windows.Forms.ProgressBar

End Class
