'===============================================================================
'   Program:    rexCrawler (rxc.exe)
'   By:         Todd Boyd
'
'   Scans matching directories and files for specific strings in file content.
'   Regular Expressions are used to designate search patterns. Currently, the
'   only output format is into a CSV (comma-separated values) file.
'===============================================================================

Imports System.Text.RegularExpressions

#Region "Old disposal code"
		' dispose of thread
		'Try
		'	If crawlerThread.IsAlive Then
		'		crawlerThread.Abort()
		'		crawlerThread.Join()
		'	End If
		'Catch : End Try

		'crawlerThread = Nothing
#End Region

Public Class rexCrawler
	' help file from resource manager
	Private helpFile As String = Nothing

	' # of matches found
	Private matchesFound As Integer
	Private lastMatch As String

	' file to send output to
	Private outFile As System.IO.File
	Private outWrite As System.IO.StreamWriter

	' regex for file contents
	Private stringRegex As Regex
	' regex for file names
	Private filenameRegex As Regex
	' flag to determine button/label states
	Private crawling As Boolean = False

	' thread for crawler
	Private crawlerThread As Threading.Thread
	' event raised when crawling is finished
	Private Event finishedCrawling()
	' necessary for thread to update label
	Delegate Sub threadBare()
	Delegate Sub delegateOutputToFile( _
		ByRef currFile As String, _
		ByRef fileLine As String, _
		ByVal lineNumber As Integer)

	'===========================================================================
	'	load form - restore settings
	'===========================================================================

	Private Sub rxcLoad( _
	ByVal sender As Object, _
	ByVal e As EventArgs) _
	Handles Me.Load
		' restore settings
		txtRootFolder.Text = My.Settings.RootFolder
		chkNoSubDirs.Checked = My.Settings.ExcludeSubDirs
		chkFilterFilename.Checked = My.Settings.FileNameFilterEnabled
		txtFileFilter.Text = My.Settings.FileNameFilter
		chkFileCase.Checked = My.Settings.FileNameFilterCaseSensitive

		If My.Settings.FileNameFilterType = 0 Then
			radFileWildcard.Checked = True
		ElseIf My.Settings.FileNameFilterType = 1 Then
			radFilePlain.Checked = True
		ElseIf My.Settings.FileNameFilterType = 2 Then
			radFileRegex.Checked = True
		ElseIf My.Settings.FileNameFilterType = 3 Then
			radFileExt.Checked = True
		End If

		chkFilterContents.Checked = My.Settings.FileContentsFilterEnabled
		txtContentsFilter.Text = My.Settings.FileContentsFilter
		chkContentsCase.Checked = My.Settings.FileContentsFilterCaseSensitive
		chkLines.Checked = My.Settings.FileContentsFilterOutputLines
		chkWholeFile.Checked = My.Settings.FileContentsFilterWholeFile
		chkIgnoreNL.Checked = My.Settings.FileContentesFilterIgnoreNL

		If My.Settings.FileContentsFilterType = 0 Then
			radContentsPlain.Checked = True
		ElseIf My.Settings.FileContentsFilterType = 1 Then
			radContentsRegex.Checked = True
		End If

		chkSaveFile.Checked = My.Settings.OutputEnabled
		chkOutputScreen.Checked = My.Settings.OutputToScreen
		chkNoErrors.Checked = My.Settings.OutputIgnoreErrors
	End Sub

	'===========================================================================
	'	unload form - kill crawler
	'===========================================================================

	Private Sub rxcUnload( _
	ByVal sender As Object, _
	ByVal e As EventArgs) _
	Handles Me.Disposed
		stopCrawling()
	End Sub

	'===========================================================================
	'   launcher for recursive crawl
	'===========================================================================

	Private Function launchCrawler() As Boolean
		Dim success = crawl()

		If (success) Then
			RaiseEvent finishedCrawling()
		End If

		stopCrawling()

		Return success
	End Function

	'===========================================================================
	'   crawler has finished, stop progress bar and close output file
	'===========================================================================

	Private Function finishedCrawlingHandler() As Boolean _
	Handles Me.finishedCrawling
		MsgBox(matchesFound.ToString + " matches found.", _
			MsgBoxStyle.Information, "Finished")
		stopCrawling()
		Return True
	End Function

	'===========================================================================
	'   scan directory for files + subdirs... regex, recurse
	'===========================================================================

	Private Function crawl( _
	Optional ByVal dirToScan As String = "") _
	As Boolean
		Dim subDirs, files
		Dim noErrors As Boolean = True

		If dirToScan = "" Then
			dirToScan = txtRootFolder.Text
		End If

		If Me.crawling = False Then Return False

		' load subdirs + files
		Try
			subDirs = _
				My.Computer.FileSystem.GetDirectories(dirToScan)
		Catch ex As Exception
			If Not chkNoErrors.Checked Then
				MsgBox("Couldn't access directories list:" + vbCrLf + _
					dirToScan, MsgBoxStyle.Exclamation, "Error")
			End If

			Return False
		End Try

		If Me.crawling = False Then Return False

		Try
			files = _
				My.Computer.FileSystem.GetFiles(dirToScan)
		Catch ex As Exception
			If Not chkNoErrors.Checked Then
				MsgBox("Couldn't access file list:" + vbCrLf + dirToScan, _
					MsgBoxStyle.Exclamation, "Error")
			End If

			Return False
		End Try

		' scan files for filename/contents match
		For Each currFile In files
			If crawling = False Then Return False

			' check for file name match
			If Not currFile.Equals(txtOutputFile.Text) _
				And matchFile(currFile) _
			Then
				' grab file times
				Dim fileInfo As System.IO.FileInfo
				fileInfo = My.Computer.FileSystem.GetFileInfo(currFile)

				Dim fileLine As String = ""
				Dim wholeText As String = ""
				Dim openFile As System.IO.StreamReader = Nothing

				Try
					' read entire contents
					If chkWholeFile.Checked Then
						wholeText = My.Computer.FileSystem.ReadAllText(currFile)
					Else ' open file to read line at a time
						openFile = System.IO.File.OpenText(currFile)
					End If
				Catch ex As Exception
					If Not chkNoErrors.Checked Then
						MsgBox("Error opening file " + currFile, _
							MsgBoxStyle.Exclamation, "Error")
					End If

					Continue For
				End Try

				' try match on entire file at once
				If chkWholeFile.Checked Then
					If matchString(wholeText) Then
						wholeText = ""
						foundMatch()
						outputToFile(currFile)
					End If
				Else ' try match on line at a time
					Dim lineNumber As Integer = 0

					' loop until eof
					While (Not openFile.EndOfStream)
						If Me.crawling = False Then openFile.Close() : Exit While
						lineNumber += 1

						' read line from file
						Try
							fileLine = openFile.ReadLine()
						Catch ex As Exception
							' couldn't read char
							fileLine = ""
						End Try

						' match found
						If (matchString(fileLine)) Then
							foundMatch()

							Try
								' output line in question for CSV
								If (chkLines.Checked) Then
									outputToFile(currFile, fileLine, lineNumber)
								Else ' just output file name
									outputToFile(currFile)

									' search next file
									Exit While
								End If
							Catch ex As Exception
								If Me.crawling Then
									MsgBox("Could not write to output file!", _
										MsgBoxStyle.Exclamation, "Error")
									noErrors = False
									Me.crawling = False
								End If
							End Try
						End If

						' clear text for next line to read
						fileLine = ""
					End While

					openFile.Close()
				End If

				' replace file times
				If (Not fileInfo.IsReadOnly) Then
					Try
						System.IO.File.SetLastAccessTime( _
							currFile, fileInfo.LastAccessTime)
						System.IO.File.SetLastWriteTime( _
							currFile, fileInfo.LastWriteTime)
					Catch ex As Exception
						If Not chkNoErrors.Checked Then
							' file in use or insufficient permissions
							MsgBox("Error updating times for " + currFile, _
								MsgBoxStyle.Exclamation, "Error")
							noErrors = False
						End If
					End Try
				End If
			End If
		Next

		' only keep going if "exclude subdirs" isn't checked
		If (Not chkNoSubDirs.Checked) Then
			' recursively crawl subdirectories
			For Each currDir In subDirs
				If (Not crawl(currDir)) Then
					noErrors = False
				End If
			Next
		End If

		Return noErrors
	End Function

	'===========================================================================
	'   start process
	'===========================================================================

	Private Sub startCrawling()
		' validate root folder chosen
		If (Not My.Computer.FileSystem.DirectoryExists(txtRootFolder.Text)) Then
			MsgBox("Invalid Root folder!", MsgBoxStyle.Exclamation, "Error")
			Return
		End If

		' validate filename filter
		If Trim(txtFileFilter.Text) = "" And chkFilterFilename.Checked Then
			MsgBox("No Filename filter entered!", MsgBoxStyle.Exclamation, "Error")
			Return
		End If

		' validate file contents filter
		If Trim(txtContentsFilter.Text) = "" And chkFilterContents.Checked Then
			MsgBox("No Contents filter entered!", MsgBoxStyle.Exclamation, "Error")
			Return
		End If

		' open/validate save file
		If chkSaveFile.Checked Then
			Try
				outWrite = outFile.CreateText(txtOutputFile.Text)
			Catch ex As Exception
				MsgBox("Error creating output file!", MsgBoxStyle.Exclamation, _
					"Error")
				Return
			End Try
		End If

		' populate filename filter regex
		If chkFilterFilename.Checked And _
			(radFileWildcard.Checked Or radFileRegex.Checked) _
		Then
			Dim regexText As String = txtFileFilter.Text

			' build regex for wildcard
			If radFileWildcard.Checked Then
				regexText = wildcardConvert(regexText)
			End If

			Try
				Dim regexOpts As RegexOptions = RegexOptions.None

				' build based on case sensitivity
				If Not chkFileCase.Checked Then
					regexOpts = regexOpts Or RegexOptions.IgnoreCase
				End If

				filenameRegex = New Regex(regexText, regexOpts)
			Catch ex As Exception
				filenameRegex = Nothing
				MsgBox("Regex Error: Filename filter" + vbCrLf + ex.Message, _
					MsgBoxStyle.Exclamation, "Error")
				Return
			End Try
		End If

		' populate file contents filter regex
		If radContentsRegex.Checked And chkFilterContents.Checked Then
			Try
				' determine options
				Dim regexOpts As RegexOptions = RegexOptions.None

				If Not chkContentsCase.Checked Then
					regexOpts = regexOpts Or RegexOptions.IgnoreCase
				End If

				If chkIgnoreNL.Checked Then
					regexOpts = regexOpts Or RegexOptions.Singleline
				End If

				stringRegex = New Regex(txtContentsFilter.Text, regexOpts)
			Catch ex As Exception
				stringRegex = Nothing
				MsgBox("Regex Error: File contents filter" + vbCrLf + _
					ex.Message, MsgBoxStyle.Exclamation, "Error")
				Return
			End Try
		End If

		' save settings
		My.Settings.RootFolder = txtRootFolder.Text
		My.Settings.ExcludeSubDirs = chkNoSubDirs.Checked
		My.Settings.FileNameFilterEnabled = chkFilterFilename.Checked
		My.Settings.FileNameFilter = txtFileFilter.Text
		My.Settings.FileNameFilterCaseSensitive = chkFileCase.Checked

		If radFileWildcard.Checked Then
			My.Settings.FileNameFilterType = 0
		ElseIf radFilePlain.Checked Then
			My.Settings.FileNameFilterType = 1
		ElseIf radFileRegex.Checked Then
			My.Settings.FileNameFilterType = 2
		ElseIf radFileExt.Checked Then
			My.Settings.FileNameFilterType = 3
		End If

		My.Settings.FileContentsFilterEnabled = chkFilterContents.Checked
		My.Settings.FileContentsFilter = txtContentsFilter.Text
		My.Settings.FileContentsFilterCaseSensitive = chkContentsCase.Checked
		My.Settings.FileContentsFilterOutputLines = chkLines.Checked
		My.Settings.FileContentsFilterWholeFile = chkWholeFile.Checked
		My.Settings.FileContentesFilterIgnoreNL = chkIgnoreNL.Checked

		If radContentsPlain.Checked Then
			My.Settings.FileContentsFilterType = 0
		ElseIf radContentsRegex.Checked Then
			My.Settings.FileContentsFilterType = 1
		End If

		My.Settings.OutputEnabled = chkSaveFile.Checked
		My.Settings.OutputFile = txtOutputFile.Text
		My.Settings.OutputToScreen = chkOutputScreen.Checked
		My.Settings.OutputIgnoreErrors = chkNoErrors.Checked

		' handle UI changes
		barCrawling.Style = ProgressBarStyle.Marquee
		barCrawling.MarqueeAnimationSpeed = 75
		barCrawling.Update()
		crawling = True
		btnCrawl.Text = "Cancel"
		pnlForm.Enabled = False
		Dim vis As Boolean = True
		' hide/show grid view columns

		If Not chkLines.Checked Then
			vis = False
			frmResults.dgvResults.Columns("fileName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
		Else
			frmResults.dgvResults.Columns("fileName").AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
		End If

		frmResults.dgvResults.Columns("lineNumber").Visible = vis
		frmResults.dgvResults.Columns("fileText").Visible = vis
		' launch thread
		crawlerThread = Nothing
		crawlerThread = New Threading.Thread(AddressOf launchCrawler)
		crawlerThread.SetApartmentState(Threading.ApartmentState.STA)
		crawlerThread.Start()
	End Sub

	'===========================================================================
	'   stop process
	'===========================================================================

	Private Function stopCrawling()
		' handle UI changes
		If (Me.lblStatus.InvokeRequired) Then
			Dim d As New threadBare(AddressOf stopCrawling)
			Try : Me.Invoke(d) : Catch : End Try
			Return True
		End If

		crawling = False
		Me.lblStatus.Text = "Click ""Crawl"" to begin."

		' close output file
		If chkSaveFile.Checked Then
			Try
				outWrite.Flush()
				outWrite.Close()
				outFile = Nothing

				If matchesFound = 0 Then
					My.Computer.FileSystem.DeleteFile(txtOutputFile.Text)
				End If
			Catch : End Try
		End If

		matchesFound = 0

		' clean up regexes
		filenameRegex = Nothing
		stringRegex = Nothing

		' REGION "Old disposal code"

		' reset progress bar and button
		barCrawling.Style = ProgressBarStyle.Blocks
		barCrawling.MarqueeAnimationSpeed = 0
		barCrawling.Value = 0
		btnCrawl.Text = "Crawl"
		pnlForm.Enabled = True
		Return True
	End Function

	'===========================================================================
	'   match file name
	'===========================================================================

	Private Function matchFile(ByRef matchMe As String) As Boolean
		If crawling = False Then Return False
		If Not chkFilterFilename.Checked Then Return True

		' regex
		If radFileRegex.Checked Or radFileWildcard.Checked Then
			Return (Not filenameRegex.Match(matchMe).Equals(Match.Empty))
		End If

		' plain
		If (radFilePlain.Checked) Then
			If (chkFileCase.Checked) Then
				Return (InStr(matchMe, txtFileFilter.Text) > 0)
			Else
				Return (InStr(UCase(matchMe), UCase(txtFileFilter.Text)) > 0)
			End If
		End If
	End Function

	'===========================================================================
	'   match contents
	'===========================================================================

	Private Function matchString(ByRef matchMe As String) As Boolean
		If Me.crawling = False Then Return False
		If Not chkFilterContents.Checked Then Return True

		' regex
		If (radContentsRegex.Checked) Then
			Return (Not stringRegex.Match(matchMe).Equals(Match.Empty))
		End If

		' plain
		If (radContentsPlain.Checked) Then
			If (chkContentsCase.Checked) Then
				Return (InStr(matchMe, txtContentsFilter.Text) > 0)
			Else
				Return (InStr(UCase(matchMe), _
					UCase(txtContentsFilter.Text)) > 0)
			End If
		End If

		Return False
	End Function

	'===========================================================================
	'   output match to file
	'===========================================================================

	Private Sub outputToFile( _
	ByRef currFile As String, _
	Optional ByRef fileLine As String = "", _
	Optional ByVal lineNumber As Integer = 0)
		If (Me.InvokeRequired) Then
			Dim d As New delegateOutputToFile(AddressOf outputToFile)
			Try : Me.Invoke(d, currFile, fileLine, lineNumber) : Catch : End Try
			Exit Sub
		End If

		If Me.crawling = False Then Exit Sub
		If fileLine <> "" Then fileLine = Trim(fileLine.Replace(vbTab, " "))

		If chkOutputScreen.Checked Then
			Dim tmpLinenum As String = ""
			If chkLines.Checked Then tmpLinenum = lineNumber.ToString
			frmResults.dgvResults.Rows.Add(currFile, tmpLinenum, fileLine)
			frmResults.Update()
			If frmResults.Visible = False Then frmResults.Show(Me)
			lastMatch = currFile
		End If

		If Not chkSaveFile.Checked Then Exit Sub

		If (lineNumber > 0) Then
			' output - escape double quotes
			outWrite.WriteLine(currFile + "," & lineNumber.ToString + ",""" _
				& Replace(fileLine, """", """""") + """")
		Else
			outWrite.WriteLine(currFile)
		End If

		outWrite.Flush()
	End Sub

	'===========================================================================
	'   helper function for updating UI when match is found
	'===========================================================================

	Private Sub foundMatch()
		' update status
		If (Me.lblStatus.InvokeRequired) Then
			Dim d As New threadBare(AddressOf foundMatch)
			Try : Me.Invoke(d) : Catch : End Try
			Exit Sub
		End If

		matchesFound += 1
		lblStatus.Text = matchesFound.ToString + " matches found..."
	End Sub

	'===========================================================================
	'   "crawl" button clicked
	'===========================================================================

	Private Sub btnCrawl_Click( _
	ByVal sender As System.Object, _
	ByVal e As System.EventArgs) _
	Handles btnCrawl.Click
		' cancel
		If (crawling) Then
			stopCrawling()

			' remove partial output file
			Try
				My.Computer.FileSystem.DeleteFile(txtOutputFile.Text)
			Catch ex As Exception : End Try
		Else ' crawl
			lastMatch = ""
			startCrawling()
		End If
	End Sub

	'===========================================================================
	'   root folder "browse" button clicked
	'===========================================================================

	Private Sub btnRootFolder_Click( _
	ByVal sender As System.Object, _
	ByVal e As System.EventArgs) _
	Handles btnRootFolder.Click
		Dim result = dlgRootFolder.ShowDialog()

		' OK was clicked (not Cancel)
		If (result = Windows.Forms.DialogResult.OK) Then
			txtRootFolder.Text = dlgRootFolder.SelectedPath
		End If
	End Sub

	'===========================================================================
	'   output file "browse" button clicked
	'===========================================================================

	Private Sub btnOutputFile_Click( _
	ByVal sender As System.Object, _
	ByVal e As System.EventArgs) _
	Handles btnOutputFile.Click
		Dim result = dlgSaveFile.ShowDialog()

		' OK was clicked (not Cancel)
		If (result = Windows.Forms.DialogResult.OK) Then
			txtOutputFile.Text = dlgSaveFile.FileName
		End If
	End Sub

	'===========================================================================
	'   "whole file" checkbox - when clicked, disable/enable "output lines"
	'===========================================================================

	Private Sub chkWholeFile_CheckedChanged( _
	ByVal sender As System.Object, _
	ByVal e As System.EventArgs) _
	Handles chkWholeFile.CheckedChanged
		If chkWholeFile.Checked Then
			chkLines.Checked = False
			chkLines.Enabled = False
			chkIgnoreNL.Enabled = True
		Else
			chkIgnoreNL.Checked = False
			chkIgnoreNL.Enabled = False
			chkLines.Enabled = True
		End If
	End Sub

	'===========================================================================
	'   file name filter checked/unchecked
	'===========================================================================

	Private Sub chkFilterFilename_CheckedChanged( _
	ByVal sender As Object, _
	ByVal e As System.EventArgs) _
	Handles chkFilterFilename.CheckedChanged
		If chkFilterFilename.Checked Then
			txtFileFilter.Enabled = True
			pnlFileFilter.Enabled = True
		Else
			txtFileFilter.Enabled = False
			pnlFileFilter.Enabled = False
		End If
	End Sub

	'===========================================================================
	'   file contents filter checked/unchecked
	'===========================================================================

	Private Sub chkFilterContents_CheckedChanged( _
	ByVal sender As Object, _
	ByVal e As System.EventArgs) _
	Handles chkFilterContents.CheckedChanged
		If chkFilterContents.Checked Then
			txtContentsFilter.Enabled = True
			pnlContentsFilter.Enabled = True
		Else
			txtContentsFilter.Enabled = False
			pnlContentsFilter.Enabled = False
		End If
	End Sub

	'===========================================================================
	'   Plain Text contents clicked, lock RegEx-specific stuff
	'===========================================================================

	Private Sub radContentsPlain_CheckedChanged( _
	ByVal sender As System.Object, _
	ByVal e As System.EventArgs) _
	Handles radContentsPlain.CheckedChanged
		If radContentsPlain.Checked Then
			chkWholeFile.Checked = False
			chkWholeFile.Enabled = False
		Else
			chkWholeFile.Enabled = True
		End If
	End Sub

	'===========================================================================
	'   output to file checked/unchecked
	'===========================================================================

	Private Sub chkSaveFile_CheckedChanged( _
	ByVal sender As Object, _
	ByVal e As System.EventArgs) _
	Handles chkSaveFile.CheckedChanged
		If chkSaveFile.Checked Then
			txtOutputFile.Enabled = True
			btnOutputFile.Enabled = True
		Else
			txtOutputFile.Enabled = False
			btnOutputFile.Enabled = False
		End If
	End Sub

	'===========================================================================
	'   "about" menu strip item
	'===========================================================================

	Private Sub mnuAbout_Click( _
	ByVal sender As System.Object, _
	ByVal e As System.EventArgs) _
	Handles mnuAbout.Click
		MsgBox("rexCrawler" + vbCrLf + vbCrLf + "Version:" + vbTab + _
			Application.ProductVersion + vbCrLf + "Author:" + vbTab + _
			"Todd Boyd" + vbCrLf + "Date:" + vbTab + linkDate().Date, _
			MsgBoxStyle.Information, "About")
	End Sub

	'===========================================================================
	'   "help" menu strip item
	'===========================================================================

	Private Sub HelpToolStripMenuItem_Click( _
	ByVal sender As System.Object, _
	ByVal e As System.EventArgs) _
	Handles HelpToolStripMenuItem.Click
		openLink("http://sites.google.com/site/rexCrawler/help/")
	End Sub

	'===========================================================================
	'   convert "wildcard" pattern to regex
	'===========================================================================

	Function wildcardConvert( _
	ByVal text As String) _
	As String
		Dim result As String = ""
		result = Regex.Replace(text, _
			"(\[|\(|\)|\[|\]|\{|\}|\||\.|\+|\$|\^|\=|\!)", "\$1")
		result = result.Replace("*", "[^\\/:]*")
		result = result.Replace("?", ".?")
		result = ".+\\" + result + "$"

		Return result
	End Function

	'===========================================================================
	'   retrieve build date
	'	http://www.codinghorror.com/blog/archives/000264.html
	'===========================================================================

	Function linkDate() As DateTime
		Dim filePath As String = Application.ExecutablePath
		Const PeHeaderOffset As Integer = 60
		Const LinkerTimestampOffset As Integer = 8

		Dim b(2047) As Byte
		Dim s As IO.Stream
		Try
			s = New IO.FileStream(filePath, IO.FileMode.Open, _
				IO.FileAccess.Read)
			s.Read(b, 0, 2048)
		Finally
			If Not s Is Nothing Then s.Close()
		End Try

		Dim i As Integer = BitConverter.ToInt32(b, PeHeaderOffset)

		Dim SecondsSince1970 As Integer = BitConverter.ToInt32(b, i + _
			LinkerTimestampOffset)
		Dim dt As New DateTime(1970, 1, 1, 0, 0, 0)
		dt = dt.AddSeconds(SecondsSince1970)
		dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours)
		Return dt
	End Function

	Public Sub New()
		' This call is required by the Windows Form Designer.
		InitializeComponent()
		' Add any initialization after the InitializeComponent() call.
	End Sub

	'==========================================================================
	'	open URL in default browser
	'	http://devtoolshed.com/content/launch-url-default-browser-using-c
	'==========================================================================

	Private Sub openLink(ByVal url As String)
		Try
			System.Diagnostics.Process.Start(url)
		Catch ex1 As Exception
			If ex1.GetType.ToString <> "System.ComponentModel.Win32Exception" Then
				Try
					Dim startInfo As New System.Diagnostics.ProcessStartInfo("iexplore.exe", url)
					System.Diagnostics.Process.Start(startInfo)
					startInfo = Nothing
				Catch ex2 As Exception
					MsgBox("Error opening URL: " & url, MsgBoxStyle.Exclamation, "Error")
				End Try
			End If
		End Try
	End Sub

End Class