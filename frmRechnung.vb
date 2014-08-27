Option Strict Off
Option Explicit On
Friend Class frmRechnung
	Inherits System.Windows.Forms.Form
	Private RechnungNr As Integer 'der Primärschlüssel aus der RechnungTabelle (wird in frmRechnung.cmdErzeugen festgelegt)
	Private RechnungsNr As String 'die Rechnungsnummer von mir [nnnTTMMJ] aus der RechnungTabelle (wird in frmRechnung.cmdErzeugen festgelegt)
	
	Sub AktualisiereRechnungsListe()
		Dim dbBuchhaltung As DAO.Database
		'UPGRADE_WARNING: Arrays in Struktur rsRechnung müssen möglicherweise initialisiert werden, bevor sie verwendet werden können. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim rsRechnung As DAO.Recordset
		Dim qdRechnung As DAO.QueryDef
		Dim lstAdd As String
		
		Dim summe As Double
		Dim Menge As Integer
		Dim epreis As Double
		
		
		On Error Resume Next
		
		'daten für Listfeld holen
		dbBuchhaltung = DAODBEngine_definst.Workspaces(0).OpenDatabase(Stammdatenbank, False, False)
		qdRechnung = dbBuchhaltung.QueryDefs("getRechnung")
		
		qdRechnung.Parameters("vorgabeRechnungsNr").Value = RechnungsNr
		
		rsRechnung = qdRechnung.OpenRecordset
		
		'Listfeld mit Artikeldaten füllen
		lstRechnungDaten.Items.Clear()
		'prüfen ob was im recordset steht
		If rsRechnung.EOF Then Exit Sub
		
		summe = 0
		rsRechnung.MoveFirst()
		
		Do 
			'puffer zusammenbauen
			lstAdd = ""
			Menge = rsRechnung.Fields("Menge").Value
			lstAdd = CStr(Menge) & " "
			lstAdd = lstAdd & CStr(rsRechnung.Fields("Einheit").Value) & " "
			lstAdd = lstAdd & CStr(rsRechnung.Fields("ArtikelBezeichnung").Value) & " "
			'UPGRADE_WARNING: Verwendung von Null/IsNull() wurde gefunden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rsRechnung.Fields("ArtikelBeschreibung").Value) = False Then
				lstAdd = lstAdd & CStr(rsRechnung.Fields("ArtikelBeschreibung").Value) & " "
			End If
			epreis = rsRechnung.Fields("BruttoPreis").Value
			lstAdd = lstAdd & CStr(epreis) & " EUR"
			
			lstRechnungDaten.Items.Add(lstAdd) 'Daten in die Combobox schreiben
			summe = summe + (Menge * epreis)
			rsRechnung.MoveNext() 'zum nächsten
		Loop While Not rsRechnung.EOF
		
		
		lblSumme.Text = "Summe: " & VB6.Format(summe, "##,##0.00") & " EUR"
		
		
	End Sub
	
	
	Sub MerkeDaten(ByRef Position As Integer)
		Dim qdRechnung As Object
		Dim Menge As String
		Dim dbBuchhaltung As DAO.Database
		Dim qdRechnungDatenNeu As DAO.QueryDef
		Dim qdRechnungDatenUpdate As DAO.QueryDef
		'UPGRADE_WARNING: Arrays in Struktur rsRechnungDatenNr müssen möglicherweise initialisiert werden, bevor sie verwendet werden können. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim rsRechnungDatenNr As DAO.Recordset
		Dim maxRechnungDatenNr As Integer
		Dim qdRechnungDatenVorhanden As DAO.QueryDef
		'UPGRADE_WARNING: Arrays in Struktur rsRechnungDatenVorhanden müssen möglicherweise initialisiert werden, bevor sie verwendet werden können. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim rsRechnungDatenVorhanden As DAO.Recordset
		Dim DatenSatzNrVorhanden As Integer
		Dim MengeVorhanden As Double
		
		Menge = InputBox("Menge Eingeben", Me.Text)
		
		'wenn keine Eingabe gemacht wurde, dann beenden
		If Menge = "" Then Exit Sub
		
		'die Datenbank anzapfen
		dbBuchhaltung = DAODBEngine_definst.Workspaces(0).OpenDatabase(Stammdatenbank, False, False)
		'liefert die höchste vorhandene rechnungsDATEN nummer
		rsRechnungDatenNr = dbBuchhaltung.OpenRecordset("getMaxRechnungDatenNr")
		'schreibt neue Daten in die Tabelle mit den RechnungsDATEN
		qdRechnungDatenNeu = dbBuchhaltung.QueryDefs("setRechnungDaten")
		'schreibt eine neue Rechnung
		qdRechnung = dbBuchhaltung.QueryDefs("setRechnung")
		
		
		
		'wenn noch keine Daten für die Rechnung vorhanden sind:
		'UPGRADE_WARNING: Verwendung von Null/IsNull() wurde gefunden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(rsRechnungDatenNr.Fields(0).Value) Then
			maxRechnungDatenNr = 0 'dann bei 0 beginnen
		Else
			maxRechnungDatenNr = CInt(rsRechnungDatenNr.Fields(0).Value) 'oder die größte nummer lesen
		End If
		
		'hier prüfen ob schon der gleiche datensatz vorhanden ist.
		'zuerst die Tabelle auslesen mit den vorgaben über daten und rechnung Nr
		qdRechnungDatenVorhanden = dbBuchhaltung.QueryDefs("ZeigeVorhandenenDatensatz")
		qdRechnungDatenVorhanden.Parameters("vorgabeRechnungNr").Value = RechnungNr
		qdRechnungDatenVorhanden.Parameters("vorgabeDatenNr").Value = Position
		rsRechnungDatenVorhanden = qdRechnungDatenVorhanden.OpenRecordset()
		'jetz prüfen ob/was vorhanden ist
		If rsRechnungDatenVorhanden.RecordCount = 0 Then
			MengeVorhanden = 0 'wenn dieser datensatz noch nicht da ist, dann 0 vorgeben, weil der gelesenen datensatz leer ist
		Else
			MengeVorhanden = rsRechnungDatenVorhanden.Fields("Menge").Value 'ansonsten die menge liefern
		End If
		
		If MengeVorhanden = 0 Then
			'nichts da! >> hinzufügen
			
			'neue datennummer berechnen
			maxRechnungDatenNr = maxRechnungDatenNr + 1
			
			'parameter für das hinzufügen eines neuen DATENSATZES in RechnungDATEN
			qdRechnungDatenNeu.Parameters("vorgabeRechnungDatenNr").Value = maxRechnungDatenNr
			qdRechnungDatenNeu.Parameters("vorgabeDatenNr").Value = Position
			
			'nur für debug:
			System.Diagnostics.Debug.Assert((lblDatenNr.Text = CStr(Position)), "")
			lblDatenNr.Text = lblDatenNr.Text & ":" & CStr(Position)
			
			qdRechnungDatenNeu.Parameters("vorgabeMenge").Value = CDbl(Menge)
			qdRechnungDatenNeu.Parameters("vorgabeDatum").Value = CDate(Today)
			qdRechnungDatenNeu.Parameters("vorgabeRechnungNr").Value = RechnungNr
			
			'und in die Tabelle schreiben
			qdRechnungDatenNeu.Execute(DAO.RecordsetOptionEnum.dbFailOnError Or DAO.RecordsetOptionEnum.dbSeeChanges)
			
		Else
			'dieser Datensatz ist schon vorhanden >> aktualisieren
			'vorhandene datensatznummer merken
			DatenSatzNrVorhanden = rsRechnungDatenVorhanden.Fields("RechnungDatenNr").Value
			'neue abfrage bauen
			qdRechnungDatenUpdate = dbBuchhaltung.QueryDefs("updateDatenMenge")
			'parameter speichern
			qdRechnungDatenUpdate.Parameters("vorgabeRechnungDatenNr").Value = DatenSatzNrVorhanden
			qdRechnungDatenUpdate.Parameters("vorgabeMenge").Value = (MengeVorhanden + CDbl(Menge))
			
			'und in die Tabelle schreiben
			qdRechnungDatenUpdate.Execute(DAO.RecordsetOptionEnum.dbFailOnError Or DAO.RecordsetOptionEnum.dbSeeChanges)
			
		End If
		
		
		dbBuchhaltung.Close()
		
		'die untere Liste aktualisieren, damit ich mich auskenne
		Call AktualisiereRechnungsListe()
		
	End Sub
	
	
	'UPGRADE_WARNING: Das Ereignis cboKunden.SelectedIndexChanged kann ausgelöst werden, wenn das Formular initialisiert wird. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cboKunden_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboKunden.SelectedIndexChanged
		Dim dbKunden As DAO.Database
		'UPGRADE_WARNING: Arrays in Struktur rsKunden müssen möglicherweise initialisiert werden, bevor sie verwendet werden können. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim rsKunden As DAO.Recordset
		Dim qdKunden As DAO.QueryDef
		
		
		
		'Die Datenbank anzapfen und den alle Daten des ausgewählten Kunden herausholen
		dbKunden = DAODBEngine_definst.Workspaces(0).OpenDatabase(Stammdatenbank, False, True)
		qdKunden = dbKunden.QueryDefs("getKundeByPrimaryKey")
		
		'Die Primärschlüsselnummer des kunden für das Programm zur Verfügung stellen
    KundenNr = cboKunden.SelectedIndex
    KundenNr = cboKunden.SelectedItem


    KundenNr = VB6.GetItemData(cboKunden, cboKunden.SelectedIndex)
		
		'Kundendaten holen
		qdKunden.Parameters("vorgabePrimaryKey").Value = KundenNr
		rsKunden = qdKunden.OpenRecordset()
    ' loest exception aus: rsKunden.MoveFirst()
		
		'Alle Daten im Dialog anzeigen
		lblAnrede.Text = rsKunden.Fields("Anrede").Value
		lblName.Text = rsKunden.Fields("Vorname").Value + " " + rsKunden.Fields("FamilienName").Value
		lblStrasse.Text = rsKunden.Fields("Strasse").Value
		lblOrt.Text = rsKunden.Fields("Postleitzahl").Value + " " + rsKunden.Fields("Ort").Value
		lblKundenNr.Text = CStr(KundenNr)
		
	End Sub
	
	
	Private Sub cmdEnde_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEnde.Click
		Me.Close()
		
	End Sub
	
	Private Sub cmdErzeugen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdErzeugen.Click
		Dim dbBuchhaltung As DAO.Database
		Dim qdRechnung As DAO.QueryDef
		'UPGRADE_WARNING: Arrays in Struktur rsRechnungNr müssen möglicherweise initialisiert werden, bevor sie verwendet werden können. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim rsRechnungNr As DAO.Recordset
		Dim maxRechnungNr As Integer
		Dim FrageNeueRechnung As Short
		
		On Error GoTo FehlerCmdErzeugen
		
		'zuerst prüfen ob schon ein Kunde ausgewählt wurde
		If KundenNr = 0 Then
			MsgBox("Bitte zuerst den Kunden auswählen", MsgBoxStyle.Information Or MsgBoxResult.OK, "Hinweis")
			Exit Sub
		End If
		
		
		'Die Datenbank anzapfen um die Rechnung anzulegen
		dbBuchhaltung = DAODBEngine_definst.Workspaces(0).OpenDatabase(Stammdatenbank, False, False)
		rsRechnungNr = dbBuchhaltung.OpenRecordset("getMaxRechnungNr")
		qdRechnung = dbBuchhaltung.QueryDefs("setRechnung")
		
		'Den Primärschlüssel für die Rechnungstabelle festlegen
		'UPGRADE_WARNING: Verwendung von Null/IsNull() wurde gefunden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(rsRechnungNr.Fields(0).Value) Then 'Prüfen ob die Tabelle noch leer ist
			maxRechnungNr = 0
		Else
			maxRechnungNr = CInt(rsRechnungNr.Fields(0).Value)
		End If
		'Neue Schlüsselnummer vergeben
		maxRechnungNr = maxRechnungNr + 1
		
		'den primärschlüssel dem ganzen Modul FrmRechnung mitteilen
		RechnungNr = maxRechnungNr
		RechnungsNr = txtRechnungsNr.Text
		
		'die Parameter für die Rechnung in die Tabelle schreiben
		qdRechnung.Parameters("vorgabeRechnungNr").Value = maxRechnungNr 'Primärschlüssel
		qdRechnung.Parameters("vorgabeRechnungsNr").Value = RechnungsNr 'die Rechnungsnummer die der Kunde Angeben soll beim bezahlen
		qdRechnung.Parameters("vorgabeDatum").Value = CDate(Today) 'wann die Rechnung erstellt wurde
		qdRechnung.Parameters("vorgabeKundeNr").Value = KundenNr 'der Primärschlüssel des ausgewählten kunden
		qdRechnung.Parameters("vorgabeSondertext").Value = txtSondertext.Text 'ein Sondertext den man eingeben kann wenn mann will (erschein als erstes auf der Rechnung)
		qdRechnung.Parameters("vorgabeFormularArt").Value = Erfassungsart 'Um welchen Formulartyp es sich handelt
		
		'ausführen....
		qdRechnung.Execute(DAO.RecordsetOptionEnum.dbFailOnError Or DAO.RecordsetOptionEnum.dbSeeChanges)
		
		Exit Sub
FehlerCmdErzeugen: 
		If Err.Number = 3022 Then
			FrageNeueRechnung = MsgBox("Diese Rechnungsnummer ist schon vorhanden!" & Chr(13) & "Möchten Sie an dieser Änderungen vornehmen", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Fehler beimErzeugen der Rechnung")
			If FrageNeueRechnung = MsgBoxResult.Yes Then
				'vergebene Schlüsselnummer wieder wegnehmen
				maxRechnungNr = maxRechnungNr - 1
				RechnungNr = maxRechnungNr
				Call AktualisiereRechnungsListe()
				Resume Next
			Else
				Exit Sub
			End If
			
			
		End If
		
		
	End Sub
	
	Private Sub frmRechnung_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim dbBuchhaltung As DAO.Database
		'UPGRADE_WARNING: Arrays in Struktur rsKunden müssen möglicherweise initialisiert werden, bevor sie verwendet werden können. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim rsKunden As DAO.Recordset
		'UPGRADE_WARNING: Arrays in Struktur rsDaten müssen möglicherweise initialisiert werden, bevor sie verwendet werden können. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim rsDaten As DAO.Recordset
    Dim qdKunden As dao.QueryDef
    Dim qdDaten As dao.QueryDef
		'UPGRADE_WARNING: Arrays in Struktur rsRechnungsNr müssen möglicherweise initialisiert werden, bevor sie verwendet werden können. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim rsRechnungsNr As DAO.Recordset
		Dim cboAdd As String
		Dim lstAdd As String
		
		On Error Resume Next
		
		dbBuchhaltung = DAODBEngine_definst.Workspaces(0).OpenDatabase(Stammdatenbank, False, False)
    qdDaten = dbBuchhaltung.OpenQueryDef("getAllDaten")
    rsDaten = qdDaten.OpenRecordset()
		rsRechnungsNr = dbBuchhaltung.OpenRecordset("getMaxRechnungsNr")
		
		If Erfassungsart = vbRechnung Then
			
			'daten für adress Combobox holen
			rsKunden = dbBuchhaltung.OpenRecordset("getAllKunden")
			'die höchste Rechnungsnummer + div. Überschriften anzeigen
			txtRechnungsNr.Text = rsRechnungsNr.Fields("RechnungsNr").Value
			lblFormularnummer.Text = "Rechnungs Nr:"
			Me.Text = "Rechnung"
			lblAdresstext.Text = "Kunde:"
			
		Else
			'daten für adress Combobox holen
			rsKunden = dbBuchhaltung.OpenRecordset("getAllLieferanten")
			'die höchste Bestellnummer + div. Überschriften anzeigen
			txtRechnungsNr.Text = rsRechnungsNr.Fields("RechnungsNr").Value
			lblFormularnummer.Text = "Bestellung Nr:"
			Me.Text = "Bestellung"
			lblAdresstext.Text = "Lieferant:"
			
		End If
		
		
		
		
		'Combobox mit Kundeninfos laden
		cboKunden.Items.Clear()
		rsKunden.MoveFirst()
		Do 
			'puffer zusammenbauen
			cboAdd = ""
			cboAdd = rsKunden.Fields("Vorname").Value + " "
			cboAdd = cboAdd + rsKunden.Fields("FamilienName").Value + " "
			cboAdd = cboAdd + rsKunden.Fields("Ort").Value
			
			cboKunden.Items.Add(cboAdd) 'Daten in die Combobox schreiben
			'UPGRADE_ISSUE: Die ComboBox-Eigenschaft cboKunden.NewIndex wurde nicht aktualisiert. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
            'VB2008
            'VB6.SetItemData(cboKunden, cboKunden.NewIndex, CInt(rsKunden.Fields("KundeNr").Value)) 'Schlüssel vergeben
			rsKunden.MoveNext() 'zum nächsten
		Loop While Not rsKunden.EOF
		
		'Listfeld mit Artikeldaten füllen
		lstDaten.Items.Clear()
		rsDaten.MoveFirst()
		Do 
			'puffer zusammenbauen
			lstAdd = ""
			lstAdd = CStr(rsDaten.Fields("MatchCode").Value) & " "
			lstAdd = lstAdd & CStr(rsDaten.Fields("ArtikelBezeichnung").Value) & " "
			lstAdd = lstAdd & CStr(rsDaten.Fields("ArtikelBeschreibung").Value) & " "
			lstAdd = lstAdd & CStr(rsDaten.Fields("BruttoPreis").Value) & " "
			lstAdd = lstAdd & CStr(rsDaten.Fields("Einheit").Value)
			lstDaten.Items.Add(lstAdd) 'Daten in die Combobox schreiben
			'UPGRADE_ISSUE: Die ListBox-Eigenschaft lstDaten.NewIndex wurde nicht aktualisiert. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
            'VB2008
            'VB6.SetItemData(lstDaten, lstDaten.NewIndex, CInt(rsDaten.Fields("DatenNr").Value)) 'Schlüssel vergeben
			rsDaten.MoveNext() 'zum nächsten
		Loop While Not rsDaten.EOF
		
		
	End Sub
	
	
	'UPGRADE_WARNING: Das Ereignis lstDaten.SelectedIndexChanged kann ausgelöst werden, wenn das Formular initialisiert wird. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub lstDaten_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstDaten.SelectedIndexChanged
		'nur zu debuginfos
		lblDatenNr.Text = CStr(VB6.GetItemData(lstDaten, lstDaten.SelectedIndex))
	End Sub
	
	Private Sub lstDaten_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstDaten.DoubleClick
		
		Call MerkeDaten(VB6.GetItemData(lstDaten, lstDaten.SelectedIndex))
		Call AktualisiereRechnungsListe()
		
		
		
	End Sub
	
	
	Private Sub lstDaten_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles lstDaten.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'nur zu debuginfos
		lblDatenNr.Text = CStr(VB6.GetItemData(lstDaten, lstDaten.SelectedIndex))
		
	End Sub
	
	Private Sub lstDaten_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles lstDaten.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'test
		If KeyAscii = 13 Then
			Call MerkeDaten(VB6.GetItemData(lstDaten, lstDaten.SelectedIndex))
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub

  Private Sub lblName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblName.Click

  End Sub
End Class