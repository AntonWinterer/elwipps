<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmDrucken
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
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents txtSondertext As System.Windows.Forms.TextBox
	Public WithEvents cmdEnde As System.Windows.Forms.Button
	Public WithEvents cmdDrucken As System.Windows.Forms.Button
	Public WithEvents lstRechnungDaten As System.Windows.Forms.ListBox
	Public WithEvents cboRechnung As System.Windows.Forms.ComboBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
	'Das Verändern mit dem Windows Form-Designer ist nicht möglich.
	'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.txtSondertext = New System.Windows.Forms.TextBox()
    Me.cmdEnde = New System.Windows.Forms.Button()
    Me.cmdDrucken = New System.Windows.Forms.Button()
    Me.lstRechnungDaten = New System.Windows.Forms.ListBox()
    Me.cboRechnung = New System.Windows.Forms.ComboBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'txtSondertext
    '
    Me.txtSondertext.AcceptsReturn = True
    Me.txtSondertext.BackColor = System.Drawing.SystemColors.Window
    Me.txtSondertext.Cursor = System.Windows.Forms.Cursors.IBeam
    Me.txtSondertext.ForeColor = System.Drawing.SystemColors.WindowText
    Me.txtSondertext.Location = New System.Drawing.Point(10, 80)
    Me.txtSondertext.MaxLength = 0
    Me.txtSondertext.Multiline = True
    Me.txtSondertext.Name = "txtSondertext"
    Me.txtSondertext.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.txtSondertext.Size = New System.Drawing.Size(311, 61)
    Me.txtSondertext.TabIndex = 7
    '
    'cmdEnde
    '
    Me.cmdEnde.BackColor = System.Drawing.SystemColors.Control
    Me.cmdEnde.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdEnde.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdEnde.Location = New System.Drawing.Point(460, 30)
    Me.cmdEnde.Name = "cmdEnde"
    Me.cmdEnde.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdEnde.Size = New System.Drawing.Size(81, 31)
    Me.cmdEnde.TabIndex = 5
    Me.cmdEnde.Text = "&Ende"
    Me.cmdEnde.UseVisualStyleBackColor = False
    '
    'cmdDrucken
    '
    Me.cmdDrucken.BackColor = System.Drawing.SystemColors.Control
    Me.cmdDrucken.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdDrucken.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdDrucken.Location = New System.Drawing.Point(350, 30)
    Me.cmdDrucken.Name = "cmdDrucken"
    Me.cmdDrucken.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdDrucken.Size = New System.Drawing.Size(101, 31)
    Me.cmdDrucken.TabIndex = 4
    Me.cmdDrucken.Text = "&Drucken"
    Me.cmdDrucken.UseVisualStyleBackColor = False
    '
    'lstRechnungDaten
    '
    Me.lstRechnungDaten.BackColor = System.Drawing.SystemColors.Window
    Me.lstRechnungDaten.Cursor = System.Windows.Forms.Cursors.Default
    Me.lstRechnungDaten.ForeColor = System.Drawing.SystemColors.WindowText
    Me.lstRechnungDaten.ItemHeight = 16
    Me.lstRechnungDaten.Location = New System.Drawing.Point(10, 170)
    Me.lstRechnungDaten.Name = "lstRechnungDaten"
    Me.lstRechnungDaten.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lstRechnungDaten.Size = New System.Drawing.Size(441, 212)
    Me.lstRechnungDaten.TabIndex = 1
    '
    'cboRechnung
    '
    Me.cboRechnung.BackColor = System.Drawing.SystemColors.Window
    Me.cboRechnung.Cursor = System.Windows.Forms.Cursors.Default
    Me.cboRechnung.ForeColor = System.Drawing.SystemColors.WindowText
    Me.cboRechnung.Location = New System.Drawing.Point(10, 30)
    Me.cboRechnung.Name = "cboRechnung"
    Me.cboRechnung.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cboRechnung.Size = New System.Drawing.Size(311, 24)
    Me.cboRechnung.TabIndex = 0
    Me.cboRechnung.Text = "Combo1"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.BackColor = System.Drawing.SystemColors.Control
    Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
    Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label3.Location = New System.Drawing.Point(10, 60)
    Me.Label3.Name = "Label3"
    Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label3.Size = New System.Drawing.Size(80, 17)
    Me.Label3.TabIndex = 6
    Me.Label3.Text = "Sondertext:"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.BackColor = System.Drawing.SystemColors.Control
    Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
    Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label2.Location = New System.Drawing.Point(10, 150)
    Me.Label2.Name = "Label2"
    Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label2.Size = New System.Drawing.Size(126, 17)
    Me.Label2.TabIndex = 3
    Me.Label2.Text = "Rechnungs Daten:"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.BackColor = System.Drawing.SystemColors.Control
    Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label1.Location = New System.Drawing.Point(10, 10)
    Me.Label1.Name = "Label1"
    Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label1.Size = New System.Drawing.Size(148, 17)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "Rechnung auswählen:"
    '
    'frmDrucken
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.Control
    Me.ClientSize = New System.Drawing.Size(576, 628)
    Me.Controls.Add(Me.txtSondertext)
    Me.Controls.Add(Me.cmdEnde)
    Me.Controls.Add(Me.cmdDrucken)
    Me.Controls.Add(Me.lstRechnungDaten)
    Me.Controls.Add(Me.cboRechnung)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Cursor = System.Windows.Forms.Cursors.Default
    Me.Location = New System.Drawing.Point(114, 154)
    Me.Name = "frmDrucken"
    Me.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    Me.Text = "Rechnung Drucken"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
#End Region 
End Class