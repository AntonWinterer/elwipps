<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMain
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
	Public WithEvents mnuOptions As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuDrucken As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuEnde As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuDatei_1 As System.Windows.Forms.ToolStripMenuItem
  Public WithEvents mnuBestellung As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuRechnung_4 As System.Windows.Forms.ToolStripMenuItem
  Public WithEvents mnuZahlungsdatum As System.Windows.Forms.ToolStripMenuItem
  Public WithEvents _mnuVerwaltung_2 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuTest As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	Public WithEvents lblVersionText As System.Windows.Forms.Label
	Public WithEvents lblVersion As System.Windows.Forms.Label
	Public WithEvents lblCopyright As System.Windows.Forms.Label
	Public WithEvents mnuArtikel As Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray
	Public WithEvents mnuDatei As Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray
	Public WithEvents mnuKunden As Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray
	Public WithEvents mnuRechnung As Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray
	Public WithEvents mnuVerwaltung As Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray
	'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
	'Das Verändern mit dem Windows Form-Designer ist nicht möglich.
	'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
    Me._mnuDatei_1 = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuOptions = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuDrucken = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuEnde = New System.Windows.Forms.ToolStripMenuItem()
    Me._mnuVerwaltung_2 = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuBestellung = New System.Windows.Forms.ToolStripMenuItem()
    Me._mnuRechnung_4 = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuZahlungsdatum = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuTest = New System.Windows.Forms.ToolStripMenuItem()
    Me.lblVersionText = New System.Windows.Forms.Label()
    Me.lblVersion = New System.Windows.Forms.Label()
    Me.lblCopyright = New System.Windows.Forms.Label()
    Me.mnuArtikel = New Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray(Me.components)
    Me.mnuDatei = New Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray(Me.components)
    Me.mnuKunden = New Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray(Me.components)
    Me.mnuRechnung = New Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray(Me.components)
    Me.mnuVerwaltung = New Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray(Me.components)
    Me.MainMenu1.SuspendLayout()
    CType(Me.mnuArtikel, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.mnuDatei, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.mnuKunden, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.mnuRechnung, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.mnuVerwaltung, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'MainMenu1
    '
    Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuDatei_1, Me._mnuVerwaltung_2, Me.mnuTest})
    Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
    Me.MainMenu1.Name = "MainMenu1"
    Me.MainMenu1.Size = New System.Drawing.Size(312, 26)
    Me.MainMenu1.TabIndex = 3
    '
    '_mnuDatei_1
    '
    Me._mnuDatei_1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOptions, Me.mnuDrucken, Me.mnuEnde})
    Me.mnuDatei.SetIndex(Me._mnuDatei_1, CType(1, Short))
    Me._mnuDatei_1.Name = "_mnuDatei_1"
    Me._mnuDatei_1.Size = New System.Drawing.Size(53, 22)
    Me._mnuDatei_1.Text = "&Datei"
    '
    'mnuOptions
    '
    Me.mnuOptions.Name = "mnuOptions"
    Me.mnuOptions.Size = New System.Drawing.Size(152, 22)
    Me.mnuOptions.Text = "&Optionen"
    '
    'mnuDrucken
    '
    Me.mnuDrucken.Name = "mnuDrucken"
    Me.mnuDrucken.Size = New System.Drawing.Size(152, 22)
    Me.mnuDrucken.Text = "&Drucken"
    '
    'mnuEnde
    '
    Me.mnuEnde.Name = "mnuEnde"
    Me.mnuEnde.Size = New System.Drawing.Size(152, 22)
    Me.mnuEnde.Text = "&Ende"
    '
    '_mnuVerwaltung_2
    '
    Me._mnuVerwaltung_2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBestellung, Me._mnuRechnung_4, Me.mnuZahlungsdatum})
    Me.mnuVerwaltung.SetIndex(Me._mnuVerwaltung_2, CType(2, Short))
    Me._mnuVerwaltung_2.Name = "_mnuVerwaltung_2"
    Me._mnuVerwaltung_2.Size = New System.Drawing.Size(91, 22)
    Me._mnuVerwaltung_2.Text = "&Verwaltung"
    '
    'mnuBestellung
    '
    Me.mnuBestellung.Name = "mnuBestellung"
    Me.mnuBestellung.Size = New System.Drawing.Size(190, 22)
    Me.mnuBestellung.Text = "&Bestellung"
    '
    '_mnuRechnung_4
    '
    Me.mnuRechnung.SetIndex(Me._mnuRechnung_4, CType(4, Short))
    Me._mnuRechnung_4.Name = "_mnuRechnung_4"
    Me._mnuRechnung_4.Size = New System.Drawing.Size(190, 22)
    Me._mnuRechnung_4.Text = "&Rechnung"
    '
    'mnuZahlungsdatum
    '
    Me.mnuZahlungsdatum.Name = "mnuZahlungsdatum"
    Me.mnuZahlungsdatum.Size = New System.Drawing.Size(190, 22)
    Me.mnuZahlungsdatum.Text = "&Zahlungsdatum"
    '
    'mnuTest
    '
    Me.mnuTest.Name = "mnuTest"
    Me.mnuTest.Size = New System.Drawing.Size(50, 22)
    Me.mnuTest.Text = "Test"
    Me.mnuTest.Visible = False
    '
    'lblVersionText
    '
    Me.lblVersionText.BackColor = System.Drawing.SystemColors.Control
    Me.lblVersionText.Cursor = System.Windows.Forms.Cursors.Default
    Me.lblVersionText.ForeColor = System.Drawing.SystemColors.ControlText
    Me.lblVersionText.Location = New System.Drawing.Point(10, 190)
    Me.lblVersionText.Name = "lblVersionText"
    Me.lblVersionText.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lblVersionText.Size = New System.Drawing.Size(61, 21)
    Me.lblVersionText.TabIndex = 2
    Me.lblVersionText.Text = "Version:"
    '
    'lblVersion
    '
    Me.lblVersion.BackColor = System.Drawing.SystemColors.Control
    Me.lblVersion.Cursor = System.Windows.Forms.Cursors.Default
    Me.lblVersion.ForeColor = System.Drawing.SystemColors.ControlText
    Me.lblVersion.Location = New System.Drawing.Point(80, 190)
    Me.lblVersion.Name = "lblVersion"
    Me.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lblVersion.Size = New System.Drawing.Size(121, 21)
    Me.lblVersion.TabIndex = 1
    Me.lblVersion.Text = "Label2"
    '
    'lblCopyright
    '
    Me.lblCopyright.BackColor = System.Drawing.SystemColors.Control
    Me.lblCopyright.Cursor = System.Windows.Forms.Cursors.Default
    Me.lblCopyright.ForeColor = System.Drawing.SystemColors.ControlText
    Me.lblCopyright.Location = New System.Drawing.Point(10, 90)
    Me.lblCopyright.Name = "lblCopyright"
    Me.lblCopyright.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lblCopyright.Size = New System.Drawing.Size(191, 91)
    Me.lblCopyright.TabIndex = 0
    '
    'mnuArtikel
    '
    '
    'mnuKunden
    '
    '
    'mnuRechnung
    '
    '
    'frmMain
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.Control
    Me.ClientSize = New System.Drawing.Size(312, 232)
    Me.Controls.Add(Me.lblVersionText)
    Me.Controls.Add(Me.lblVersion)
    Me.Controls.Add(Me.lblCopyright)
    Me.Controls.Add(Me.MainMenu1)
    Me.Cursor = System.Windows.Forms.Cursors.Default
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Location = New System.Drawing.Point(286, 406)
    Me.Name = "frmMain"
    Me.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Text = "Buchhaltung"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.MainMenu1.ResumeLayout(False)
    Me.MainMenu1.PerformLayout()
    CType(Me.mnuArtikel, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.mnuDatei, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.mnuKunden, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.mnuRechnung, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.mnuVerwaltung, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
#End Region 
End Class