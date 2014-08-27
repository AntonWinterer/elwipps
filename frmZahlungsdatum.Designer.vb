<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmZahlungsdatum
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
	Public WithEvents txtZahlungsBetrag As System.Windows.Forms.TextBox
	Public WithEvents cmdEnde As System.Windows.Forms.Button
	Public WithEvents cmdSpeichern As System.Windows.Forms.Button
	Public WithEvents txtZahlungsDatum As System.Windows.Forms.TextBox
	Public WithEvents txtRechnungsNr As System.Windows.Forms.TextBox
	Public WithEvents lblZahlungsBetrag As System.Windows.Forms.Label
	Public WithEvents lblZahlungsdatum As System.Windows.Forms.Label
	Public WithEvents lblRechnungsnummer As System.Windows.Forms.Label
	'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
	'Das Verändern mit dem Windows Form-Designer ist nicht möglich.
	'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmZahlungsdatum))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.txtZahlungsBetrag = New System.Windows.Forms.TextBox
		Me.cmdEnde = New System.Windows.Forms.Button
		Me.cmdSpeichern = New System.Windows.Forms.Button
		Me.txtZahlungsDatum = New System.Windows.Forms.TextBox
		Me.txtRechnungsNr = New System.Windows.Forms.TextBox
		Me.lblZahlungsBetrag = New System.Windows.Forms.Label
		Me.lblZahlungsdatum = New System.Windows.Forms.Label
		Me.lblRechnungsnummer = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Zahlungsdatum"
		Me.ClientSize = New System.Drawing.Size(434, 158)
		Me.Location = New System.Drawing.Point(260, 150)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmZahlungsdatum"
		Me.txtZahlungsBetrag.AutoSize = False
		Me.txtZahlungsBetrag.Size = New System.Drawing.Size(111, 24)
		Me.txtZahlungsBetrag.Location = New System.Drawing.Point(170, 100)
		Me.txtZahlungsBetrag.TabIndex = 3
		Me.txtZahlungsBetrag.AcceptsReturn = True
		Me.txtZahlungsBetrag.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtZahlungsBetrag.BackColor = System.Drawing.SystemColors.Window
		Me.txtZahlungsBetrag.CausesValidation = True
		Me.txtZahlungsBetrag.Enabled = True
		Me.txtZahlungsBetrag.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtZahlungsBetrag.HideSelection = True
		Me.txtZahlungsBetrag.ReadOnly = False
		Me.txtZahlungsBetrag.Maxlength = 0
		Me.txtZahlungsBetrag.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtZahlungsBetrag.MultiLine = False
		Me.txtZahlungsBetrag.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtZahlungsBetrag.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtZahlungsBetrag.TabStop = True
		Me.txtZahlungsBetrag.Visible = True
		Me.txtZahlungsBetrag.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtZahlungsBetrag.Name = "txtZahlungsBetrag"
		Me.cmdEnde.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEnde.Text = "&Ende"
		Me.cmdEnde.Size = New System.Drawing.Size(81, 31)
		Me.cmdEnde.Location = New System.Drawing.Point(310, 20)
		Me.cmdEnde.TabIndex = 5
		Me.cmdEnde.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEnde.CausesValidation = True
		Me.cmdEnde.Enabled = True
		Me.cmdEnde.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEnde.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEnde.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEnde.TabStop = True
		Me.cmdEnde.Name = "cmdEnde"
		Me.cmdSpeichern.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSpeichern.Text = "&Speichern"
		Me.cmdSpeichern.Size = New System.Drawing.Size(81, 31)
		Me.cmdSpeichern.Location = New System.Drawing.Point(310, 60)
		Me.cmdSpeichern.TabIndex = 4
		Me.cmdSpeichern.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSpeichern.CausesValidation = True
		Me.cmdSpeichern.Enabled = True
		Me.cmdSpeichern.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSpeichern.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSpeichern.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSpeichern.TabStop = True
		Me.cmdSpeichern.Name = "cmdSpeichern"
		Me.txtZahlungsDatum.AutoSize = False
		Me.txtZahlungsDatum.Size = New System.Drawing.Size(111, 24)
		Me.txtZahlungsDatum.Location = New System.Drawing.Point(170, 60)
		Me.txtZahlungsDatum.TabIndex = 2
		Me.txtZahlungsDatum.AcceptsReturn = True
		Me.txtZahlungsDatum.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtZahlungsDatum.BackColor = System.Drawing.SystemColors.Window
		Me.txtZahlungsDatum.CausesValidation = True
		Me.txtZahlungsDatum.Enabled = True
		Me.txtZahlungsDatum.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtZahlungsDatum.HideSelection = True
		Me.txtZahlungsDatum.ReadOnly = False
		Me.txtZahlungsDatum.Maxlength = 0
		Me.txtZahlungsDatum.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtZahlungsDatum.MultiLine = False
		Me.txtZahlungsDatum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtZahlungsDatum.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtZahlungsDatum.TabStop = True
		Me.txtZahlungsDatum.Visible = True
		Me.txtZahlungsDatum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtZahlungsDatum.Name = "txtZahlungsDatum"
		Me.txtRechnungsNr.AutoSize = False
		Me.txtRechnungsNr.Size = New System.Drawing.Size(111, 24)
		Me.txtRechnungsNr.Location = New System.Drawing.Point(170, 20)
		Me.txtRechnungsNr.TabIndex = 1
		Me.txtRechnungsNr.AcceptsReturn = True
		Me.txtRechnungsNr.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtRechnungsNr.BackColor = System.Drawing.SystemColors.Window
		Me.txtRechnungsNr.CausesValidation = True
		Me.txtRechnungsNr.Enabled = True
		Me.txtRechnungsNr.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtRechnungsNr.HideSelection = True
		Me.txtRechnungsNr.ReadOnly = False
		Me.txtRechnungsNr.Maxlength = 0
		Me.txtRechnungsNr.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtRechnungsNr.MultiLine = False
		Me.txtRechnungsNr.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtRechnungsNr.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtRechnungsNr.TabStop = True
		Me.txtRechnungsNr.Visible = True
		Me.txtRechnungsNr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtRechnungsNr.Name = "txtRechnungsNr"
		Me.lblZahlungsBetrag.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblZahlungsBetrag.Text = "Zahlungs Betrag"
		Me.lblZahlungsBetrag.Size = New System.Drawing.Size(118, 26)
		Me.lblZahlungsBetrag.Location = New System.Drawing.Point(33, 100)
		Me.lblZahlungsBetrag.TabIndex = 7
		Me.lblZahlungsBetrag.BackColor = System.Drawing.SystemColors.Control
		Me.lblZahlungsBetrag.Enabled = True
		Me.lblZahlungsBetrag.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblZahlungsBetrag.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblZahlungsBetrag.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblZahlungsBetrag.UseMnemonic = True
		Me.lblZahlungsBetrag.Visible = True
		Me.lblZahlungsBetrag.AutoSize = True
		Me.lblZahlungsBetrag.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblZahlungsBetrag.Name = "lblZahlungsBetrag"
		Me.lblZahlungsdatum.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblZahlungsdatum.Text = "Zahlungs Datum"
		Me.lblZahlungsdatum.Size = New System.Drawing.Size(122, 26)
		Me.lblZahlungsdatum.Location = New System.Drawing.Point(29, 60)
		Me.lblZahlungsdatum.TabIndex = 6
		Me.lblZahlungsdatum.BackColor = System.Drawing.SystemColors.Control
		Me.lblZahlungsdatum.Enabled = True
		Me.lblZahlungsdatum.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblZahlungsdatum.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblZahlungsdatum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblZahlungsdatum.UseMnemonic = True
		Me.lblZahlungsdatum.Visible = True
		Me.lblZahlungsdatum.AutoSize = False
		Me.lblZahlungsdatum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblZahlungsdatum.Name = "lblZahlungsdatum"
		Me.lblRechnungsnummer.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblRechnungsnummer.Text = "Rechnungs Nummer"
		Me.lblRechnungsnummer.Size = New System.Drawing.Size(136, 26)
		Me.lblRechnungsnummer.Location = New System.Drawing.Point(15, 20)
		Me.lblRechnungsnummer.TabIndex = 0
		Me.lblRechnungsnummer.BackColor = System.Drawing.SystemColors.Control
		Me.lblRechnungsnummer.Enabled = True
		Me.lblRechnungsnummer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblRechnungsnummer.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblRechnungsnummer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblRechnungsnummer.UseMnemonic = True
		Me.lblRechnungsnummer.Visible = True
		Me.lblRechnungsnummer.AutoSize = False
		Me.lblRechnungsnummer.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblRechnungsnummer.Name = "lblRechnungsnummer"
		Me.Controls.Add(txtZahlungsBetrag)
		Me.Controls.Add(cmdEnde)
		Me.Controls.Add(cmdSpeichern)
		Me.Controls.Add(txtZahlungsDatum)
		Me.Controls.Add(txtRechnungsNr)
		Me.Controls.Add(lblZahlungsBetrag)
		Me.Controls.Add(lblZahlungsdatum)
		Me.Controls.Add(lblRechnungsnummer)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class