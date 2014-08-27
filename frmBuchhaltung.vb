Option Strict Off
Option Explicit On
Friend Class frmMain
	Inherits System.Windows.Forms.Form
	
	Private Sub frmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		lblCopyright.Text = My.Application.Info.Copyright
		lblVersion.Text = CStr(My.Application.Info.Version.Major) & "." & CStr(My.Application.Info.Version.Minor)
		
		'Versionsnummernverzeichnis
		
		'V1.0.nn    Urversion bis 31.12.2001
		'V1.1.02    Umgestellt auf Euro, diverse Kleinigkeiten am Druckbild geändert
		
		
		
	End Sub
	
	
	Public Sub mnuArtikel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuArtikel.Click
		Dim Index As Short = mnuArtikel.GetIndex(eventSender)
		'Artikeleingabefenster anzeigen
    'frmDaten.ShowDialog()
		
	End Sub
	
	Public Sub mnuBestellung_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuBestellung.Click
		'Bestell Eingabefenster anzeigen
		Erfassungsart = vbBestellung
		frmRechnung.ShowDialog()
		
	End Sub
	
	Public Sub mnuDrucken_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDrucken.Click
		frmDrucken.ShowDialog()
		
	End Sub
	
	Public Sub mnuEnde_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEnde.Click
    RegistrySchreiben()
    'Programmende
		Me.Close()
		End
	End Sub
	
	
	Public Sub mnuKunden_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuKunden.Click
		Dim Index As Short = mnuKunden.GetIndex(eventSender)
		'Kundeneingabefenster anzeigen
    'frmKunde.ShowDialog()
		
	End Sub
	
	Public Sub mnuOptions_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuOptions.Click
		frmOptions.ShowDialog()
		
	End Sub
	
	Public Sub mnuRechnung_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuRechnung.Click
		Dim Index As Short = mnuRechnung.GetIndex(eventSender)
		'Rechnungseingabefenster anzeigen
		Erfassungsart = vbRechnung
		frmRechnung.ShowDialog()
		
	End Sub
	
	
  Public Sub mnuRechnungsliste_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    Dim frmReport As Object
    On Error GoTo FehlerReport

    'den report auswählen
    'UPGRADE_WARNING: Die Standardeigenschaft des Objekts frmReport.repReport konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    frmReport.repReport.ReportFileName = RechnungslisteReport
    'die größe des bildschirms auf den dialog einstellen
    'UPGRADE_WARNING: Die Standardeigenschaft des Objekts frmReport.repReport konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    frmReport.repReport.WindowTop = 0
    'UPGRADE_WARNING: Die Standardeigenschaft des Objekts frmReport.repReport konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    frmReport.repReport.WindowLeft = 0
    'UPGRADE_WARNING: Die Standardeigenschaft des Objekts frmReport.repReport konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    frmReport.repReport.WindowWidth = (VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - 300)
    'UPGRADE_WARNING: Die Standardeigenschaft des Objekts frmReport.repReport konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    frmReport.repReport.WindowHeight = (VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - 500)
    'UPGRADE_WARNING: Die Standardeigenschaft des Objekts frmReport.repReport konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    frmReport.repReport.DataFiles(0) = Stammdatenbank

    'jetzt den report anzeigen
    'UPGRADE_WARNING: Die Standardeigenschaft des Objekts frmReport.repReport konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    frmReport.repReport.Action = 1
    Exit Sub
FehlerReport:
    If Err.Number = 20504 Then
      MsgBox("Bitte stellen Sie den Pfad der Reportdateien im INI-File richtig ein." & Chr(13) & "Aktion abgebrochen.", MsgBoxStyle.Exclamation)
    Else
      MsgBox("Unbekannter Fehler beim Aufruf des Reports." & Chr(13) & "Aktion abgebrochen. (" & CStr(Err.Number) & ")", MsgBoxStyle.Exclamation)
    End If

  End Sub
	
	Public Sub mnuTest_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTest.Click
		'Static i    ' Variablen deklarieren.
		'Dim OldFont
		
		'    OldFont = FontName  ' Originalschriftart speichern.
		'    Do
		'        Printer.FontName = Printer.Fonts(i)         ' Neue Schriftart aktivieren.
		'        Debug.Print Printer.Fonts(i)    ' Namen der Schriftart ausgeben.
		'        i = i + 1   ' Zähler hochzählen.
		'    Loop Until i = Printer.FontCount
		'    Printer.FontName = OldFont     ' Originalschriftart aktivieren.
		
		
		
		
		
	End Sub
	
	
	Public Sub mnuZahlungsdatum_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuZahlungsdatum.Click
		frmZahlungsdatum.ShowDialog()
		
	End Sub

  Private Sub MainMenu1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MainMenu1.ItemClicked

  End Sub
End Class