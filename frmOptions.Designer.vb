<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmOptions
#Region "Vom Windows Form-Designer generierter Code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'Dieser Aufruf ist für den Windows Form-Designer erforderlich.
		InitializeComponent()
	End Sub
	'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Wird vom Windows Form-Designer benötigt.
	Private components As System.ComponentModel.IContainer
  'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
  'Das Verändern mit dem Windows Form-Designer ist nicht möglich.
  'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.btnOK = New System.Windows.Forms.Button()
    Me.lblDatabase = New System.Windows.Forms.Label()
    Me.txtDatabase = New System.Windows.Forms.TextBox()
    Me.btnSelectDatabase = New System.Windows.Forms.Button()
    Me.dlgSelectFile = New System.Windows.Forms.OpenFileDialog()
    Me.SuspendLayout()
    '
    'btnOK
    '
    Me.btnOK.Location = New System.Drawing.Point(383, 23)
    Me.btnOK.Name = "btnOK"
    Me.btnOK.Size = New System.Drawing.Size(114, 33)
    Me.btnOK.TabIndex = 0
    Me.btnOK.Text = "OK"
    Me.btnOK.UseVisualStyleBackColor = True
    '
    'lblDatabase
    '
    Me.lblDatabase.Location = New System.Drawing.Point(12, 65)
    Me.lblDatabase.Name = "lblDatabase"
    Me.lblDatabase.Size = New System.Drawing.Size(94, 22)
    Me.lblDatabase.TabIndex = 1
    Me.lblDatabase.Text = "Database:"
    Me.lblDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtDatabase
    '
    Me.txtDatabase.Location = New System.Drawing.Point(112, 65)
    Me.txtDatabase.Name = "txtDatabase"
    Me.txtDatabase.Size = New System.Drawing.Size(346, 22)
    Me.txtDatabase.TabIndex = 2
    '
    'btnSelectDatabase
    '
    Me.btnSelectDatabase.Location = New System.Drawing.Point(464, 65)
    Me.btnSelectDatabase.Name = "btnSelectDatabase"
    Me.btnSelectDatabase.Size = New System.Drawing.Size(33, 22)
    Me.btnSelectDatabase.TabIndex = 3
    Me.btnSelectDatabase.Text = "..."
    Me.btnSelectDatabase.UseVisualStyleBackColor = True
    '
    'dlgSelectFile
    '
    Me.dlgSelectFile.FileName = "OpenFileDialog1"
    '
    'frmOptions
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.Control
    Me.ClientSize = New System.Drawing.Size(532, 465)
    Me.Controls.Add(Me.btnSelectDatabase)
    Me.Controls.Add(Me.txtDatabase)
    Me.Controls.Add(Me.lblDatabase)
    Me.Controls.Add(Me.btnOK)
    Me.Cursor = System.Windows.Forms.Cursors.Default
    Me.Location = New System.Drawing.Point(110, 142)
    Me.Name = "frmOptions"
    Me.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    Me.Text = "Optionen"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents btnOK As System.Windows.Forms.Button
  Friend WithEvents lblDatabase As System.Windows.Forms.Label
  Friend WithEvents txtDatabase As System.Windows.Forms.TextBox
  Friend WithEvents btnSelectDatabase As System.Windows.Forms.Button
  Friend WithEvents dlgSelectFile As System.Windows.Forms.OpenFileDialog
#End Region 
End Class