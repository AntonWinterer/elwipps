<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmRechnung
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
	Public WithEvents cboMatchCode As System.Windows.Forms.ComboBox
	Public WithEvents cmdEnde As System.Windows.Forms.Button
	Public WithEvents lstRechnungDaten As System.Windows.Forms.ListBox
	Public WithEvents cmdErzeugen As System.Windows.Forms.Button
	Public WithEvents txtRechnungsNr As System.Windows.Forms.TextBox
	Public WithEvents lstDaten As System.Windows.Forms.ListBox
	Public WithEvents txtSonderText As System.Windows.Forms.TextBox
	Public WithEvents cboKunden As System.Windows.Forms.ComboBox
	Public WithEvents lblSumme As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents lblFormularnummer As System.Windows.Forms.Label
	Public WithEvents lblDatenNr As System.Windows.Forms.Label
	Public WithEvents lblAdresstext As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lblKundenNr As System.Windows.Forms.Label
	Public WithEvents lblOrt As System.Windows.Forms.Label
	Public WithEvents lblStrasse As System.Windows.Forms.Label
	Public WithEvents lblName As System.Windows.Forms.Label
	Public WithEvents lblAnrede As System.Windows.Forms.Label
	'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
	'Das Verändern mit dem Windows Form-Designer ist nicht möglich.
	'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.cboMatchCode = New System.Windows.Forms.ComboBox()
    Me.cmdEnde = New System.Windows.Forms.Button()
    Me.lstRechnungDaten = New System.Windows.Forms.ListBox()
    Me.cmdErzeugen = New System.Windows.Forms.Button()
    Me.txtRechnungsNr = New System.Windows.Forms.TextBox()
    Me.lstDaten = New System.Windows.Forms.ListBox()
    Me.txtSonderText = New System.Windows.Forms.TextBox()
    Me.cboKunden = New System.Windows.Forms.ComboBox()
    Me.lblSumme = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.lblFormularnummer = New System.Windows.Forms.Label()
    Me.lblDatenNr = New System.Windows.Forms.Label()
    Me.lblAdresstext = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.lblKundenNr = New System.Windows.Forms.Label()
    Me.lblOrt = New System.Windows.Forms.Label()
    Me.lblStrasse = New System.Windows.Forms.Label()
    Me.lblName = New System.Windows.Forms.Label()
    Me.lblAnrede = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'cboMatchCode
    '
    Me.cboMatchCode.BackColor = System.Drawing.SystemColors.Window
    Me.cboMatchCode.Cursor = System.Windows.Forms.Cursors.Default
    Me.cboMatchCode.ForeColor = System.Drawing.SystemColors.WindowText
    Me.cboMatchCode.Location = New System.Drawing.Point(440, 150)
    Me.cboMatchCode.Name = "cboMatchCode"
    Me.cboMatchCode.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cboMatchCode.Size = New System.Drawing.Size(101, 24)
    Me.cboMatchCode.TabIndex = 15
    Me.cboMatchCode.Text = "Combo1"
    '
    'cmdEnde
    '
    Me.cmdEnde.BackColor = System.Drawing.SystemColors.Control
    Me.cmdEnde.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdEnde.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdEnde.Location = New System.Drawing.Point(640, 150)
    Me.cmdEnde.Name = "cmdEnde"
    Me.cmdEnde.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdEnde.Size = New System.Drawing.Size(81, 27)
    Me.cmdEnde.TabIndex = 14
    Me.cmdEnde.Text = "E&nde"
    Me.cmdEnde.UseVisualStyleBackColor = False
    '
    'lstRechnungDaten
    '
    Me.lstRechnungDaten.BackColor = System.Drawing.SystemColors.Window
    Me.lstRechnungDaten.Cursor = System.Windows.Forms.Cursors.Default
    Me.lstRechnungDaten.ForeColor = System.Drawing.SystemColors.WindowText
    Me.lstRechnungDaten.ItemHeight = 16
    Me.lstRechnungDaten.Location = New System.Drawing.Point(10, 460)
    Me.lstRechnungDaten.Name = "lstRechnungDaten"
    Me.lstRechnungDaten.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lstRechnungDaten.Size = New System.Drawing.Size(701, 132)
    Me.lstRechnungDaten.TabIndex = 11
    '
    'cmdErzeugen
    '
    Me.cmdErzeugen.BackColor = System.Drawing.SystemColors.Control
    Me.cmdErzeugen.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdErzeugen.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdErzeugen.Location = New System.Drawing.Point(550, 150)
    Me.cmdErzeugen.Name = "cmdErzeugen"
    Me.cmdErzeugen.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdErzeugen.Size = New System.Drawing.Size(81, 27)
    Me.cmdErzeugen.TabIndex = 10
    Me.cmdErzeugen.Text = "&Erzeugen"
    Me.cmdErzeugen.UseVisualStyleBackColor = False
    '
    'txtRechnungsNr
    '
    Me.txtRechnungsNr.AcceptsReturn = True
    Me.txtRechnungsNr.BackColor = System.Drawing.SystemColors.Window
    Me.txtRechnungsNr.Cursor = System.Windows.Forms.Cursors.IBeam
    Me.txtRechnungsNr.ForeColor = System.Drawing.SystemColors.WindowText
    Me.txtRechnungsNr.Location = New System.Drawing.Point(300, 150)
    Me.txtRechnungsNr.MaxLength = 0
    Me.txtRechnungsNr.Name = "txtRechnungsNr"
    Me.txtRechnungsNr.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.txtRechnungsNr.Size = New System.Drawing.Size(131, 24)
    Me.txtRechnungsNr.TabIndex = 9
    Me.txtRechnungsNr.Text = "Re-Nr [nnnTTMMJJ]"
    '
    'lstDaten
    '
    Me.lstDaten.BackColor = System.Drawing.SystemColors.Window
    Me.lstDaten.Cursor = System.Windows.Forms.Cursors.Default
    Me.lstDaten.ForeColor = System.Drawing.SystemColors.WindowText
    Me.lstDaten.ItemHeight = 16
    Me.lstDaten.Location = New System.Drawing.Point(10, 180)
    Me.lstDaten.Name = "lstDaten"
    Me.lstDaten.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lstDaten.Size = New System.Drawing.Size(701, 276)
    Me.lstDaten.TabIndex = 8
    '
    'txtSonderText
    '
    Me.txtSonderText.AcceptsReturn = True
    Me.txtSonderText.BackColor = System.Drawing.SystemColors.Window
    Me.txtSonderText.Cursor = System.Windows.Forms.Cursors.IBeam
    Me.txtSonderText.ForeColor = System.Drawing.SystemColors.WindowText
    Me.txtSonderText.Location = New System.Drawing.Point(10, 80)
    Me.txtSonderText.MaxLength = 0
    Me.txtSonderText.Multiline = True
    Me.txtSonderText.Name = "txtSonderText"
    Me.txtSonderText.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.txtSonderText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtSonderText.Size = New System.Drawing.Size(281, 91)
    Me.txtSonderText.TabIndex = 7
    '
    'cboKunden
    '
    Me.cboKunden.BackColor = System.Drawing.SystemColors.Window
    Me.cboKunden.Cursor = System.Windows.Forms.Cursors.Default
    Me.cboKunden.ForeColor = System.Drawing.SystemColors.WindowText
    Me.cboKunden.Location = New System.Drawing.Point(10, 20)
    Me.cboKunden.Name = "cboKunden"
    Me.cboKunden.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cboKunden.Size = New System.Drawing.Size(281, 24)
    Me.cboKunden.TabIndex = 0
    Me.cboKunden.Text = "Kunden"
    '
    'lblSumme
    '
    Me.lblSumme.BackColor = System.Drawing.SystemColors.Control
    Me.lblSumme.Cursor = System.Windows.Forms.Cursors.Default
    Me.lblSumme.ForeColor = System.Drawing.SystemColors.ControlText
    Me.lblSumme.Location = New System.Drawing.Point(20, 610)
    Me.lblSumme.Name = "lblSumme"
    Me.lblSumme.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lblSumme.Size = New System.Drawing.Size(181, 21)
    Me.lblSumme.TabIndex = 18
    Me.lblSumme.Text = "Summe:"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.BackColor = System.Drawing.SystemColors.Control
    Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
    Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label4.Location = New System.Drawing.Point(440, 130)
    Me.Label4.Name = "Label4"
    Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label4.Size = New System.Drawing.Size(83, 17)
    Me.Label4.TabIndex = 17
    Me.Label4.Text = "Match Code"
    '
    'lblFormularnummer
    '
    Me.lblFormularnummer.AutoSize = True
    Me.lblFormularnummer.BackColor = System.Drawing.SystemColors.Control
    Me.lblFormularnummer.Cursor = System.Windows.Forms.Cursors.Default
    Me.lblFormularnummer.ForeColor = System.Drawing.SystemColors.ControlText
    Me.lblFormularnummer.Location = New System.Drawing.Point(300, 130)
    Me.lblFormularnummer.Name = "lblFormularnummer"
    Me.lblFormularnummer.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lblFormularnummer.Size = New System.Drawing.Size(93, 17)
    Me.lblFormularnummer.TabIndex = 16
    Me.lblFormularnummer.Text = "Rechnungsnr"
    '
    'lblDatenNr
    '
    Me.lblDatenNr.BackColor = System.Drawing.SystemColors.Control
    Me.lblDatenNr.Cursor = System.Windows.Forms.Cursors.Default
    Me.lblDatenNr.ForeColor = System.Drawing.SystemColors.ControlText
    Me.lblDatenNr.Location = New System.Drawing.Point(660, 10)
    Me.lblDatenNr.Name = "lblDatenNr"
    Me.lblDatenNr.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lblDatenNr.Size = New System.Drawing.Size(51, 21)
    Me.lblDatenNr.TabIndex = 13
    '
    'lblAdresstext
    '
    Me.lblAdresstext.BackColor = System.Drawing.SystemColors.Control
    Me.lblAdresstext.Cursor = System.Windows.Forms.Cursors.Default
    Me.lblAdresstext.ForeColor = System.Drawing.SystemColors.ControlText
    Me.lblAdresstext.Location = New System.Drawing.Point(10, 0)
    Me.lblAdresstext.Name = "lblAdresstext"
    Me.lblAdresstext.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lblAdresstext.Size = New System.Drawing.Size(131, 21)
    Me.lblAdresstext.TabIndex = 12
    Me.lblAdresstext.Text = "Kunde:"
    '
    'Label1
    '
    Me.Label1.BackColor = System.Drawing.SystemColors.Control
    Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label1.Location = New System.Drawing.Point(10, 50)
    Me.Label1.Name = "Label1"
    Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label1.Size = New System.Drawing.Size(281, 21)
    Me.Label1.TabIndex = 6
    Me.Label1.Text = "Sondertext auf dem Dokument:"
    '
    'lblKundenNr
    '
    Me.lblKundenNr.BackColor = System.Drawing.SystemColors.Control
    Me.lblKundenNr.Cursor = System.Windows.Forms.Cursors.Default
    Me.lblKundenNr.ForeColor = System.Drawing.SystemColors.ControlText
    Me.lblKundenNr.Location = New System.Drawing.Point(580, 10)
    Me.lblKundenNr.Name = "lblKundenNr"
    Me.lblKundenNr.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lblKundenNr.Size = New System.Drawing.Size(71, 21)
    Me.lblKundenNr.TabIndex = 5
    '
    'lblOrt
    '
    Me.lblOrt.BackColor = System.Drawing.SystemColors.Control
    Me.lblOrt.Cursor = System.Windows.Forms.Cursors.Default
    Me.lblOrt.ForeColor = System.Drawing.SystemColors.ControlText
    Me.lblOrt.Location = New System.Drawing.Point(480, 80)
    Me.lblOrt.Name = "lblOrt"
    Me.lblOrt.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lblOrt.Size = New System.Drawing.Size(231, 21)
    Me.lblOrt.TabIndex = 4
    '
    'lblStrasse
    '
    Me.lblStrasse.BackColor = System.Drawing.SystemColors.Control
    Me.lblStrasse.Cursor = System.Windows.Forms.Cursors.Default
    Me.lblStrasse.ForeColor = System.Drawing.SystemColors.ControlText
    Me.lblStrasse.Location = New System.Drawing.Point(480, 50)
    Me.lblStrasse.Name = "lblStrasse"
    Me.lblStrasse.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lblStrasse.Size = New System.Drawing.Size(231, 31)
    Me.lblStrasse.TabIndex = 3
    '
    'lblName
    '
    Me.lblName.BackColor = System.Drawing.SystemColors.Control
    Me.lblName.Cursor = System.Windows.Forms.Cursors.Default
    Me.lblName.ForeColor = System.Drawing.SystemColors.ControlText
    Me.lblName.Location = New System.Drawing.Point(480, 30)
    Me.lblName.Name = "lblName"
    Me.lblName.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lblName.Size = New System.Drawing.Size(231, 21)
    Me.lblName.TabIndex = 2
    '
    'lblAnrede
    '
    Me.lblAnrede.BackColor = System.Drawing.SystemColors.Control
    Me.lblAnrede.Cursor = System.Windows.Forms.Cursors.Default
    Me.lblAnrede.ForeColor = System.Drawing.SystemColors.ControlText
    Me.lblAnrede.Location = New System.Drawing.Point(480, 10)
    Me.lblAnrede.Name = "lblAnrede"
    Me.lblAnrede.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lblAnrede.Size = New System.Drawing.Size(91, 21)
    Me.lblAnrede.TabIndex = 1
    '
    'frmRechnung
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.Control
    Me.ClientSize = New System.Drawing.Size(723, 658)
    Me.Controls.Add(Me.cboMatchCode)
    Me.Controls.Add(Me.cmdEnde)
    Me.Controls.Add(Me.lstRechnungDaten)
    Me.Controls.Add(Me.cmdErzeugen)
    Me.Controls.Add(Me.txtRechnungsNr)
    Me.Controls.Add(Me.lstDaten)
    Me.Controls.Add(Me.txtSonderText)
    Me.Controls.Add(Me.cboKunden)
    Me.Controls.Add(Me.lblSumme)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.lblFormularnummer)
    Me.Controls.Add(Me.lblDatenNr)
    Me.Controls.Add(Me.lblAdresstext)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.lblKundenNr)
    Me.Controls.Add(Me.lblOrt)
    Me.Controls.Add(Me.lblStrasse)
    Me.Controls.Add(Me.lblName)
    Me.Controls.Add(Me.lblAnrede)
    Me.Cursor = System.Windows.Forms.Cursors.Default
    Me.Location = New System.Drawing.Point(121, 115)
    Me.Name = "frmRechnung"
    Me.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    Me.Text = "Rechnung"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
#End Region 
End Class