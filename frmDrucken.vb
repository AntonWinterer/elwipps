Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class frmDrucken
	Inherits System.Windows.Forms.Form
	Const DruckSizegross As Short = 10 'die schriftgröße bei größer gedruckten texten
	Const DruckSizeklein As Short = 9 'die schriftgröße bei kleiner gedruckten texten
	Const PositionenProSeite As Short = 13 'Die Anzahl der Positionen die auf eine Druckseite passen
	Const PositionZwischenraum As Short = 3 'der Platz (in Fontsize) zweischen den Positionen
	Const DMEURFaktor As Double = 1.95583
	Sub DruckeDokument()
		Dim Printer As New Printer
		Dim dbRechnung As DAO.Database
		'UPGRADE_WARNING: Arrays in Struktur rsRechnung müssen möglicherweise initialisiert werden, bevor sie verwendet werden können. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim rsRechnung As DAO.Recordset
		Dim qdRechnung As DAO.QueryDef
		Dim qdDatum As DAO.QueryDef
		Dim RechnungsNr As String
		Dim RechnungNr As Integer
		'UPGRADE_NOTE: Text wurde aktualisiert auf Text_Renamed. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim Text_Renamed As String
		Dim Anzahl As Integer
		Dim SeitenAnzahl As Integer
		Dim schleife As Integer
		Dim DruckSchleife As Integer
		Dim Start As Integer
		Dim Ende As Integer
		Dim tmpTextBreite As Single
		Dim BlattBreite As Single
		Dim tmpText As String
		Dim GesamtPreis As Double
		Dim Summe As Double
		Dim SummeMwSt As Double
		Dim ZahlungsDatumNetto As Date
		Dim ZahlungsDatumSkonto As Date
		Dim ZeilenSondertext As Integer 'die anzahl der zeilen die der Sondertext hat
		Dim SondertextGedruckt As Boolean 'wird true wenn der Sondertext gedruckt wurde
		Dim Seite As Short
		Dim tmp As Integer
		
		On Error GoTo FehlerDrucken
		
		dbRechnung = DAODBEngine_definst.Workspaces(0).OpenDatabase(Stammdatenbank, False, False)
		qdRechnung = dbRechnung.QueryDefs("getRechnungByRechnungNr")
		
		qdRechnung.Parameters("vorgabeRechnungNr").Value = VB6.GetItemData(cboRechnung, cboRechnung.SelectedIndex)
		rsRechnung = qdRechnung.OpenRecordset()
		If rsRechnung.EOF Then
			MsgBox("Keine Daten für eine Rechnung")
			dbRechnung.Close()
			Exit Sub
		End If
		rsRechnung.MoveFirst()
		rsRechnung.MoveLast()
		rsRechnung.MoveFirst()
		
		
		
		
		Anzahl = rsRechnung.RecordCount
		RechnungNr = rsRechnung.Fields("RechnungNr").Value
		Printer.Orientation = PrinterObjectConstants.vbPRORPortrait
		Printer.FontName = "Arial"
		Printer.FontSize = DruckSizegross
		Printer.Copies = AnzahlAusdrucke
		Printer.ScaleMode = ScaleModeConstants.vbMillimeters
		BlattBreite = Printer.ScaleWidth
		
		'einen Datensatz mehr vortäuschen, weil sonst der letzte nicht gedruckt werden würde
		'bei mehrseitigen Rechnungen
		If Anzahl > 11 Then
			Anzahl = Anzahl + 1
		End If
		
		'Seitenzahlen berechnen
		If Anzahl <= PositionenProSeite Then
			SeitenAnzahl = 1
		Else
			'Prüfen ob es genau auf eine Seite paßt
			tmp = CInt(Anzahl) Mod PositionenProSeite
			'die Anzahl der Seiten berechnen
			SeitenAnzahl = CInt((Anzahl - tmp) / PositionenProSeite)
			'wenn noch positionen übrig bleiben, dann eine Seite mehr
			If tmp <> 0 Then
				SeitenAnzahl = SeitenAnzahl + 1
			End If
			
		End If
		'mit der 1. Seite gehts los
		Seite = 1
		
		'Die Überschrift, Adressen etc. Drucken & die seitenzahlen übergeben
		DruckeKopfdaten(Seite, SeitenAnzahl)
		
		'UPGRADE_WARNING: Verwendung von Null/IsNull() wurde gefunden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(rsRechnung.Fields("Sondertext").Value) = False Then
			ZeilenSondertext = CountChar(rsRechnung.Fields("Sondertext").Value, 13) + 1
			
			'damit der text nur einmal gedruckt wird
			SondertextGedruckt = False
		End If
		
		
		
		'die Rechnungssumme
		Summe = 0
		
		'Positionsdaten Drucken (11 passen auf eine Seite)
		For DruckSchleife = 1 To SeitenAnzahl
			Start = (DruckSchleife * PositionenProSeite) - PositionenProSeite + 1
			Ende = Start + PositionenProSeite - 1
			
			'Sondertext drucken
			If SondertextGedruckt = False Then
				Printer.FontSize = DruckSizegross
				'UPGRADE_WARNING: Verwendung von Null/IsNull() wurde gefunden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If IsDbNull(rsRechnung.Fields("Sondertext").Value) = False Then
					Printer.Print(TAB(8), rsRechnung.Fields("Sondertext"))
				Else
					Printer.Print(TAB(8), "")
				End If
				SondertextGedruckt = True
				
				'berechnung der zu druckenden zeilen überlisten
				Ende = Ende - ZeilenSondertext
			End If
			
			If Ende > Anzahl Then Ende = Anzahl
			
			For schleife = Start To Ende
				Printer.FontSize = DruckSizegross
				
				Printer.Write(TAB(8), rsRechnung.Fields("Menge").Value & " " & rsRechnung.Fields("Einheit").Value)
				'UPGRADE_WARNING: Verwendung von Null/IsNull() wurde gefunden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If IsDbNull(rsRechnung.Fields("ArtikelHersteller").Value) = False Then
					Printer.Write(TAB(18), rsRechnung.Fields("ArtikelHersteller"))
				End If
				'UPGRADE_WARNING: Verwendung von Null/IsNull() wurde gefunden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If IsDbNull(rsRechnung.Fields("ArtikelBezeichnung").Value) = False Then
					Printer.Write(TAB(40), rsRechnung.Fields("ArtikelBezeichnung"))
				End If
				TabPrintRE(Printer, (VB6.Format(rsRechnung.Fields("BruttoPreis").Value, "##,##0.00")) & "EUR", (BlattBreite - 35))
				GesamtPreis = CDbl(rsRechnung.Fields("BruttoPreis").Value) * CDbl(rsRechnung.Fields("Menge").Value)
				Summe = Summe + GesamtPreis
				TabPrintRE(Printer, (VB6.Format(GesamtPreis, "##,##0.00")) & "EUR", (BlattBreite - 5))
				
				'Die Artikelbeschreibung in eine eigene Zeile
				Printer.FontSize = DruckSizeklein
				'UPGRADE_WARNING: Verwendung von Null/IsNull() wurde gefunden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If IsDbNull(rsRechnung.Fields("ArtikelBeschreibung").Value) = False Then
					Printer.Print(TAB(21), rsRechnung.Fields("ArtikelBeschreibung"))
				Else
					Printer.Print(TAB(21), " ")
				End If
				Printer.FontSize = DruckSizegross
				rsRechnung.MoveNext()
				
				'einen kleinen abstand dazwischen lassen
				Printer.FontSize = PositionZwischenraum
				Printer.Print()
				Printer.FontSize = DruckSizegross
				
			Next 
			'abschlußlinie drucken
			Printer.Line(5, 225, 200, 225)
			
			
			If DruckSchleife < SeitenAnzahl Then
				'neue Seite anfangen
				Printer.NewPage()
				Seite = Seite + 1
				DruckeKopfdaten(Seite, SeitenAnzahl)
			End If
		Next 
		SummeMwSt = Summe / (100 + MwSt) * MwSt
		Printer.Print()
		
		'Positon für Abschlußtext festlegen
		Printer.CurrentY = 230
		
		TabPrintRE(Printer, "Nettowert: ", (BlattBreite - 80))
		TabPrintR(Printer, VB6.Format(Summe - SummeMwSt, "##,##0.00") & "EUR", (BlattBreite - 5))
		
		TabPrintRE(Printer, "Umsatzsteuer [" & VB6.Format(MwSt, "#0.0") & "%]: ", (BlattBreite - 80))
		TabPrintR(Printer, VB6.Format(SummeMwSt, "##,##0.00") & "EUR", (BlattBreite - 5))
		
		
		Printer.FontUnderline = True
		TabPrintRE(Printer, "Bruttowert: ", (BlattBreite - 80))
		TabPrintR(Printer, "(" & (VB6.Format(Summe * DMEURFaktor, "##,##0.00") & "DM) " & VB6.Format(Summe, "##,##0.00")) & "EUR", (BlattBreite - 5))
		Printer.FontUnderline = False
		
		Printer.FontSize = 18
		Printer.Print()
		TabPrint(Printer, "Vielen Dank für Ihren Auftrag !", 15)
		Printer.FontSize = DruckSizegross
		Printer.Print()
		
		Printer.FontSize = DruckSizeklein
		TabPrint(Printer, "Es gelten die Allgemeinen Liefer- und Zahlungsbedingungen für Erzeugnisse und Leistungen der Elektroindustrie !", 15)
		
		Printer.Print()
		Printer.FontSize = DruckSizegross
		ZahlungsDatumNetto = System.Date.FromOADate(Today.ToOADate + TageNetto)
		ZahlungsDatumSkonto = System.Date.FromOADate(Today.ToOADate + TageSkonto)
		
		tmpText = "Zahlbar bis " & VB6.Format(ZahlungsDatumSkonto, "DD.MM.YYYY") & " mit 3%Skonto ( = " & VB6.Format(Summe * 0.03, "##,##0.00") & "EUR ), oder bis " & VB6.Format(ZahlungsDatumNetto, "DD.MM.YYYY") & " ohne Abzug!"
		TabPrint(Printer, tmpText, 15)
		TabPrint(Printer, "Bankverbindung: Raiffeisenbank Schönberg, Konto: 102 334 BLZ: 701 694 74", 15)
		Printer.FontSize = DruckSizeklein
		TabPrint(Printer, "StNr: 141/288/90166  USt-IdNr: DE 156 020 338", 15)
		TabPrint(Printer, "Laut Gesetz ist der Rechnungsempfänger mindestens 2 Jahre zur Aufbewahrung der Rechnung verpflichtet.", 15)
		Printer.EndDoc()
		
		qdDatum = dbRechnung.QueryDefs("updateDruckDatum")
		
		qdDatum.Parameters("vorgabeRechnungNr").Value = RechnungNr
		qdDatum.Parameters("vorgabeDruckDatum").Value = Today
		qdDatum.Execute()
		
		
		dbRechnung.Close()
		Exit Sub
FehlerDrucken: 
		Call PrintError(Err.Number)
		
	End Sub
	
	
	
	
	Sub InitialisiereFormular()
		Dim dbBuchhaltung As DAO.Database
		'UPGRADE_WARNING: Arrays in Struktur rsRechnung müssen möglicherweise initialisiert werden, bevor sie verwendet werden können. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim rsRechnung As DAO.Recordset
		'UPGRADE_WARNING: Arrays in Struktur rsRechnungDaten müssen möglicherweise initialisiert werden, bevor sie verwendet werden können. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim rsRechnungDaten As DAO.Recordset
		Dim cboAdd As String
		
		
		On Error Resume Next
		
		'daten für kundenkombobox holen
		dbBuchhaltung = DAODBEngine_definst.Workspaces(0).OpenDatabase(Stammdatenbank, False, False)
		rsRechnung = dbBuchhaltung.OpenRecordset("getRechnungNichtGedruckt")
		'Set rsRechnungDaten = dbBuchhaltung.OpenRecordset("getAllDaten")
		
		'Combobox mit Kundeninfos laden
		cboRechnung.Items.Clear()
		rsRechnung.MoveFirst()
		Do 
			'puffer zusammenbauen
			cboAdd = ""
			cboAdd = rsRechnung.Fields("RechnungsNr").Value + " "
			cboAdd = cboAdd + rsRechnung.Fields("FamilienName").Value + " "
			cboAdd = cboAdd + rsRechnung.Fields("Ort").Value
			
			cboRechnung.Items.Add(cboAdd) 'Daten in die Combobox schreiben
			'UPGRADE_ISSUE: Die ComboBox-Eigenschaft cboRechnung.NewIndex wurde nicht aktualisiert. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
            'VB2008
            'VB6.SetItemData(cboRechnung, cboRechnung.NewIndex, CInt(rsRechnung.Fields("RechnungNr").Value)) 'Schlüssel vergeben
			rsRechnung.MoveNext() 'zum nächsten
		Loop While Not rsRechnung.EOF
		
	End Sub
	
	Sub DruckeKopfdaten(ByVal Seite As Short, ByVal Seiten As Short)
		Dim Printer As New Printer
		Dim dbRechnung As DAO.Database
		'UPGRADE_WARNING: Arrays in Struktur rsRechnung müssen möglicherweise initialisiert werden, bevor sie verwendet werden können. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim rsRechnung As DAO.Recordset
		Dim qdRechnung As DAO.QueryDef
    'Dim qdDatum As DAO.QueryDef
    'Dim RechnungsNr As String
		Dim RechnungNr As Integer
		'UPGRADE_NOTE: Text wurde aktualisiert auf Text_Renamed. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    'Dim Text_Renamed As String
    'Dim schleife As Integer
    'Dim tmpTextBreite As Single
		Dim BlattBreite As Single
		Dim tmpText As String
    'Dim GesamtPreis As Double
    'Dim Summe As Double
    'Dim MwSt As Double
    'Dim ZahlungsDatum As Date
		
		
		dbRechnung = DAODBEngine_definst.Workspaces(0).OpenDatabase(Stammdatenbank, False, False)
		qdRechnung = dbRechnung.QueryDefs("getRechnungByRechnungNr")
		
		qdRechnung.Parameters("vorgabeRechnungNr").Value = VB6.GetItemData(cboRechnung, cboRechnung.SelectedIndex)
		rsRechnung = qdRechnung.OpenRecordset()
		
		rsRechnung.MoveFirst()
		rsRechnung.MoveLast()
		rsRechnung.MoveFirst()
		
		
		RechnungNr = rsRechnung.Fields("RechnungNr").Value
		
		'Grundeinstellungen
		Printer.ScaleMode = ScaleModeConstants.vbMillimeters
		BlattBreite = Printer.ScaleWidth
		Printer.FontName = "Arial"
		Printer.FontSize = 11
		
		Printer.Print()
		Printer.Print()
		
		TabPrintR(Printer, "Elektro Anton Winterer", (BlattBreite - 10))
		TabPrintR(Printer, "Birkenstraße 11", (BlattBreite - 10))
		TabPrintR(Printer, "84573 Schönberg", (BlattBreite - 10))
		TabPrintR(Printer, "Tel: 08637/985936", (BlattBreite - 10))
		TabPrintR(Printer, "Fax: 08637/7677", (BlattBreite - 10))
		TabPrintR(Printer, "e-Mail: Elektro-Winterer@iivs.de", (BlattBreite - 10))
		
		Printer.Print()
		Printer.Print()
		
		Printer.FontSize = 7
		Printer.FontUnderline = True
		TabPrint(Printer, "Elektro Anton Winterer - Birkenstraße 11 - 84573 Schönberg", 20)
		Printer.FontSize = 11
		Printer.FontUnderline = False
		'Debug.Assert (Printer.FontSize = 11)
		
		Printer.Print()
		TabPrint(Printer, rsRechnung.Fields("Anrede").Value, 20)
		
		tmpText = rsRechnung.Fields("Vorname").Value + " " + rsRechnung.Fields("FamilienName").Value
		TabPrint(Printer, tmpText, 20)
		
		Printer.Print()
		
		TabPrint(Printer, rsRechnung.Fields("Strasse").Value, 20)
		
		Printer.Print()
		Printer.FontSize = 12
		Printer.FontBold = True
		tmpText = rsRechnung.Fields("Postleitzahl").Value + " " + rsRechnung.Fields("Ort").Value
		TabPrint(Printer, tmpText, 20)
		Printer.FontSize = 11
		Printer.FontBold = False
		Printer.Print()
		
		'das aktuelle datum drucken
		tmpText = "Schönberg, den " & VB6.Format(Today, "DD.MM.YYYY")
		TabPrintR(Printer, tmpText, (BlattBreite - 10))
		
		'darunter die seitenzahlen
		tmpText = "Seite " & CStr(Seite) & " von " & CStr(Seiten)
		Printer.FontSize = 8
		TabPrintR(Printer, tmpText, (BlattBreite - 10))
		Printer.FontSize = 11
		Printer.FontSize = 18
		tmpText = "Rechnung Nr: " + rsRechnung.Fields("RechnungsNr").Value
		TabPrint(Printer, tmpText, 15)
		Printer.FontSize = 11
		
		TabPrint(Printer, "_", 0)
		
		
		'Positionenüberschrift
		Printer.Print(TAB(8), "Menge", TAB(18), "Hersteller", TAB(37), "Artikelbezeichnung / Artikelbeschreibung", TAB(85), "Einzelpreis", TAB(100), "Gesamtpreis")
		Printer.Line(5, 108, 200, 108)
		
	End Sub
	
	'UPGRADE_WARNING: Das Ereignis cboRechnung.SelectedIndexChanged kann ausgelöst werden, wenn das Formular initialisiert wird. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cboRechnung_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboRechnung.SelectedIndexChanged
		Dim dbBuchhaltung As DAO.Database
		'UPGRADE_WARNING: Arrays in Struktur rsRechnungDaten müssen möglicherweise initialisiert werden, bevor sie verwendet werden können. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim rsRechnungDaten As DAO.Recordset
		Dim qdRechnungDaten As DAO.QueryDef
		Dim lstAdd As String
		
		
		
		
		'daten für kundenkombobox holen
		dbBuchhaltung = DAODBEngine_definst.Workspaces(0).OpenDatabase(Stammdatenbank, False, False)
		qdRechnungDaten = dbBuchhaltung.QueryDefs("getRechnungByRechnungNr")
		
		qdRechnungDaten.Parameters("vorgabeRechnungNr").Value = VB6.GetItemData(cboRechnung, cboRechnung.SelectedIndex)
		rsRechnungDaten = qdRechnungDaten.OpenRecordset
		
		'Listbox mit Daten füllen
		lstRechnungDaten.Items.Clear()
		If rsRechnungDaten.EOF = True Then
			Exit Sub
		End If
		
		rsRechnungDaten.MoveFirst()
		
		'UPGRADE_WARNING: Verwendung von Null/IsNull() wurde gefunden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(rsRechnungDaten.Fields("Sondertext").Value) = False Then
			'sondertext anzeigen wenn einer gespeichert wurde
			txtSondertext.Text = rsRechnungDaten.Fields("Sondertext").Value
			
		End If
		
		
		Do 
			'puffer zusammenbauen
			lstAdd = ""
			lstAdd = CStr(rsRechnungDaten.Fields("Menge").Value) & " "
			'UPGRADE_WARNING: Verwendung von Null/IsNull() wurde gefunden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rsRechnungDaten.Fields("ArtikelBezeichnung").Value) = False Then
				lstAdd = lstAdd + rsRechnungDaten.Fields("ArtikelBezeichnung").Value + " "
			End If
			'UPGRADE_WARNING: Verwendung von Null/IsNull() wurde gefunden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rsRechnungDaten.Fields("ArtikelBeschreibung").Value) = False Then
				lstAdd = lstAdd + rsRechnungDaten.Fields("ArtikelBeschreibung").Value
			End If
			
			lstRechnungDaten.Items.Add(lstAdd) 'Daten in die listbox schreiben
			rsRechnungDaten.MoveNext() 'zum nächsten
		Loop While Not rsRechnungDaten.EOF
		
		
	End Sub
	
	
	Private Sub cmdDrucken_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDrucken.Click
		Call DruckeDokument()
		Me.Close()
		
	End Sub
	
	Private Sub cmdEnde_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEnde.Click
		Me.Close()
		
	End Sub
	
	'UPGRADE_WARNING: Form Ereignis frmDrucken.Activate hat ein neues Verhalten. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub frmDrucken_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		Call InitialisiereFormular()
	End Sub

  Private Sub frmDrucken_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub
End Class