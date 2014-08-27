Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Module mdlAllround
	
	
	Public Const GW_OWNER As Short = 4
	Public Const PI As Double = 3.14159
	
	Declare Function GetWindow Lib "user32" (ByVal hWnd As Integer, ByVal wCmd As Integer) As Integer
	Declare Function GetClassName Lib "user32"  Alias "GetClassNameA"(ByVal hWnd As Integer, ByVal lpClassName As String, ByVal nMaxCount As Integer) As Integer
	Declare Function GetDeviceCaps Lib "gdi32" (ByVal hdc As Integer, ByVal nIndex As Integer) As Integer
	
	
	Declare Function GetComputerName Lib "kernel32"  Alias "GetComputerNameA"(ByVal lpBuffer As String, ByRef nSize As Integer) As Integer
	Declare Function GetUserName Lib "advapi32.dll"  Alias "GetUserNameA"(ByRef lpBuffer As String, ByRef nSize As Integer) As Integer
	
	Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)
	
	Public sCRLF As String
	Sub TabPrint(ByRef AusgabeGeraet As Object, ByRef AusgabeText As String, ByRef Position As Single)
		
		'UPGRADE_WARNING: Die Standardeigenschaft des Objekts AusgabeGeraet.CurrentX konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		AusgabeGeraet.CurrentX = Position
		'UPGRADE_WARNING: Die Standardeigenschaft des Objekts AusgabeGeraet.Print konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		AusgabeGeraet.Print(AusgabeText)
		
	End Sub
	
	
	Sub TabPrintR(ByRef AusgabeGeraet As Object, ByRef AusgabeText As String, ByRef maxBreite As Single)
		Dim tmpTextBreite As Single
		
		'UPGRADE_WARNING: Die Standardeigenschaft des Objekts AusgabeGeraet.TextWidth konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		tmpTextBreite = AusgabeGeraet.TextWidth(AusgabeText)
		'UPGRADE_WARNING: Die Standardeigenschaft des Objekts AusgabeGeraet.CurrentX konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		AusgabeGeraet.CurrentX = maxBreite - tmpTextBreite
		'UPGRADE_WARNING: Die Standardeigenschaft des Objekts AusgabeGeraet.Print konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		AusgabeGeraet.Print(AusgabeText)
		
	End Sub
	
	Sub TabPrintRE(ByRef AusgabeGeraet As Object, ByRef AusgabeText As String, ByRef maxBreite As Single)
		Dim tmpTextBreite As Single
		
		'UPGRADE_WARNING: Die Standardeigenschaft des Objekts AusgabeGeraet.TextWidth konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		tmpTextBreite = AusgabeGeraet.TextWidth(AusgabeText)
		'UPGRADE_WARNING: Die Standardeigenschaft des Objekts AusgabeGeraet.CurrentX konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		AusgabeGeraet.CurrentX = maxBreite - tmpTextBreite
		'UPGRADE_WARNING: Die Standardeigenschaft des Objekts AusgabeGeraet.Print konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		AusgabeGeraet.Print(AusgabeText)
		
	End Sub
	
	'
	'Überprüft ob eine Datenbank vorhanden ist oder nicht,
	'1. Parameter: Dateiname
	'2. Parameter: Dialogtitel
	'aus dem Dateinamen wird die Endung herausgefiltert, daraus wir die Filtereinstellung gebildet
	'3. Parameter: Die Form, die den Dialog darstellt.
	'4. Parameter: Das Steuerelement, das die Arbeit macht
	'
	'zurückgegeben wird true, wenn die Datenbank vorhanden ist, False wenn sie nicht da ist bzw nicht eingestellt wurde
	'
	'Achtung: Das Programm muß ein Formular mit dem Namen : frmFile und darin ein Dialog-Steuerelement mit dem Name dlgFile haben!!!!
	'
	Function CheckDatabase(ByRef dateiname As String, ByRef Titel As String) As Boolean
		Dim Typ As String 'den harausgefilterten typ
		
		'prüfen ob die gesuchte Datei vorhanden ist
		If FileExist(dateiname) = False Then
			
			
			'die Endung herausfiltern
			Typ = GetErweiterung(dateiname)
			
			'dem DIalog den Filter mitteilen
			If UCase(Typ) = "MDB" Then
				'UPGRADE_WARNING: Filter hat ein neues Verhalten. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				frmFile.dlgFileOpen.Filter = "Access Datenbank|*.mdb"
			ElseIf UCase(Typ) = "XLS" Then 
				'UPGRADE_WARNING: Filter hat ein neues Verhalten. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				frmFile.dlgFileOpen.Filter = "Excel Arbeitsmappe|*.xls"
			End If
			
			'den ersten Filter verwenden
			frmFile.dlgFileOpen.FilterIndex = 1
			
			'die zu suchende Datei übergeben
			frmFile.dlgFileOpen.FileName = dateiname
			
			'die Flags einstellen
			'UPGRADE_WARNING: MSComDlg.CommonDialog Eigenschaft frmFile.dlgFile.Flags wurde in frmFile.dlgFileColor.AllowFullOpen aktualisiert und hat daher ein neues Verhalten. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
			frmFile.dlgFileColor.AllowFullOpen = False
			'UPGRADE_WARNING: MSComDlg.CommonDialog Eigenschaft frmFile.dlgFile.Flags wurde in frmFile.dlgFileOpen.CheckFileExists aktualisiert und hat daher ein neues Verhalten. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
			'UPGRADE_NOTE: Die frmFile.dlgFile-Variable wurde in frmFile.dlgFileOpen umbenannt. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="94ADAC4D-C65D-414F-A061-8FDC6B83C5EC"'
			'UPGRADE_WARNING: MSComDlg.CommonDialog Eigenschaft frmFile.dlgFile.Flags wurde in frmFile.dlgFileOpen.CheckPathExists aktualisiert und hat daher ein neues Verhalten. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
			frmFile.dlgFileOpen.CheckFileExists = True
			frmFile.dlgFileOpen.CheckPathExists = True
			
			'den Titel einstellen
			frmFile.dlgFileOpen.Title = Titel
			
			'und Action...
			frmFile.dlgFileOpen.ShowDialog()
			
			'die Neue Datei zurückgeben (Der Parameter wurde als Byref übergeben, und ist deshalb in der Aufrufenden Prozedur auch bekannt)
			dateiname = frmFile.dlgFileOpen.FileName
		End If
		
		'prüfen, ob uns der User nicht Ärgern will
		If FileExist(dateiname) = False Then
			MsgBox(Titel & Chr(13) & " Suche blieb erfolglos", MsgBoxStyle.Critical, "Programm wird beendet")
			CheckDatabase = False
		Else
			CheckDatabase = True
		End If
		
	End Function
	
	'
	'Diese Funktion vergleicht zwei Strings miteinander
	'aber ohne die leerzeichen in den beiden strings (die werden herausgefiltert)
	'->Groß/Klein-schreibung wird berücksichtigt
	'
	'die funktion liefert true wenn die beiden strings danach gleich sind,
	'false wenn sie unterschiedlich sind
	'
	Function CompStringWOSpace(ByRef Wert1 As String, ByRef Wert2 As String) As Boolean
		Dim Text1 As String
		Dim Text2 As String
		Dim schleife As Short
		Dim LeftTeil As String
		Dim RightTeil As String
		
		'zuweisen, damit die aufgerufenen variablen nicht zerstört werden
		Text1 = Wert1
		Text2 = Wert2
		
		'alle positionen des ersten Strings durchlaufen und die leerzeichen entfernen
		For schleife = 1 To Len(Text1)
			If Mid(Text1, schleife, 1) = " " Then
				'den teil vor dem space
				LeftTeil = Left(Text1, schleife - 1)
				
				'den teil nach dem space
				RightTeil = Right(Text1, Len(Text1) - schleife)
				
				'den rest wieder zusammenbauen
				Text1 = LeftTeil & RightTeil
				
			End If
			
		Next 
		
		'alle positionen des zweiten Strings durchlaufen und die leerzeichen entfernen
		For schleife = 1 To Len(Text2)
			If Mid(Text2, schleife, 1) = " " Then
				'den teil vor dem space
				LeftTeil = Left(Text2, schleife - 1)
				
				'den teil nach dem space
				RightTeil = Right(Text2, Len(Text2) - schleife)
				
				'den rest wieder zusammenbauen
				Text2 = LeftTeil & RightTeil
				
			End If
			
		Next 
		
		'jetzt prüfen:
		If Text1 = Text2 Then
			CompStringWOSpace = True
		Else
			CompStringWOSpace = False
		End If
		
	End Function
	
	Function RemoveDrive(ByRef Wert As String) As String
    'Dim Drive As String
		Dim Position As Short
		
		Position = ReverseFind(Wert, ":")
		If Position = 0 Then
			RemoveDrive = Wert
		Else
			RemoveDrive = Right(Wert, Len(Wert) - Position)
		End If
		
	End Function
	
	Function RemoveErweiterung(ByRef Wert As String) As String
    'Dim Erweiterung As String
		Dim Position As Short
		
		Position = ReverseFind(Wert, ".")
		If Position = 0 Then
			RemoveErweiterung = Wert
		Else
			RemoveErweiterung = Left(Wert, Position - 1)
		End If
		
	End Function
	
	Function RemoveDateiname(ByRef Wert As String) As String
    'Dim dateiname As String
		Dim Position As Short
		
		Position = ReverseFind(Wert, "\")
		If Position = 0 Then
			RemoveDateiname = Wert
		Else
			RemoveDateiname = Left(Wert, Position)
		End If
		
	End Function
	
	Function GetDrive(ByRef Wert As String) As String
    'Dim Drive As String
		Dim Position As Short
		
		Position = ReverseFind(Wert, ":")
		If Position = 0 Then
			GetDrive = ""
		Else
			GetDrive = Left(Wert, Position)
		End If
		
	End Function
	
	Function GetErweiterung(ByRef Wert As String) As String
    'Dim Erweiterung As String
		Dim Position As Short
		
		Position = ReverseFind(Wert, ".")
		If Position = 0 Then
			GetErweiterung = ""
		Else
			GetErweiterung = Right(Wert, Len(Wert) - Position)
		End If
		
	End Function
	
	Function GetDateiname(ByRef Wert As String) As String
    'Dim dateiname As String
		Dim Position As Short
		
		Position = ReverseFind(Wert, "\")
		If Position = 0 Then
			GetDateiname = ""
		Else
			GetDateiname = Right(Wert, Len(Wert) - Position)
		End If
		
	End Function
	
	
	'
	'diese function prüft eine eingabe auf eine gültige Zeit im folgenden Format:
	' hh:mm:ss
	'
	'sie liefert true, wenn die eingabe als gültige Zeit erkannt wurde
	'sie liefert false, wenn sie nicht gültig ist.
	'
	'UPGRADE_NOTE: TimeValue wurde aktualisiert auf TimeValue_Renamed. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Function CheckTime(ByRef TimeValue_Renamed As String) As Boolean
		Dim mnt As Short
		Dim sec As Short
		
		'wie gesagt, ich bin ein Optimistischer mensch....
		CheckTime = True
		
		'die Eingaben Prüfen....
		If InStr(1, TimeValue_Renamed, "_") = 0 Then 'wenn nicht alles da, dann löschen...
			
			'die minuten sind wichtig
			mnt = CShort(Mid(TimeValue_Renamed, 4, 2))
			If mnt > 59 Then
				CheckTime = False
				Exit Function 'die arbeit ist getan, raus hier....
			Else
				CheckTime = True
			End If
			
			'die sekunden sind wichtig
			sec = CShort(Mid(TimeValue_Renamed, 7, 2))
			If sec > 59 Then
				CheckTime = False
				Exit Function 'die arbeit ist getan, raus hier....
			Else
				CheckTime = True
			End If
		Else
			CheckTime = False
		End If
		
	End Function
	
	
	Function FindMin(ByRef Wert As Double, ByRef Loesch As Boolean) As Double
		Static Variable As Double
		Dim tmp As Double
		
		'testen ob schon ein vergleich stattgefunden hat
		If Variable >= 1E+308 Then
			Variable = 1.1E+308
		End If
		
		'wenn der übergebene wert kleiner ist, dann merken
		If Wert < Variable Then
			Variable = Wert
		End If
		
		'den aktualle tiefststand merken
		tmp = Variable
		
		'wenn das momentane ergebnis nicht mehr benötigt wird, dann rücksetzen
		If Loesch = True Then Variable = 1.1E+308
		
		'das ergebnis zurückgben
		FindMin = tmp
		
	End Function
	'
	'wenn für loesch true übergeben wurde, dann wird die static-variable gelöscht....
	'
	'
	'
	Function FindMax(ByRef Wert As Double, ByRef Loesch As Boolean) As Double
		Static Variable As Double
		Dim tmp As Double
		
		'testen ob schon ein vergleich stattgefunden hat
		If Variable <= 0 Then
			Variable = -1
		End If
		
		'wenn der übergebene wert kleiner ist, dann merken
		If Wert > Variable Then
			Variable = Wert
		End If
		
		'den aktualle tiefststand merken
		tmp = Variable
		
		'wenn das momentane ergebnis nicht mehr benötigt wird, dann rücksetzen
		If Loesch = True Then Variable = 1.1E-308
		
		'das ergebnis zurückgben
		FindMax = tmp
		
	End Function
	
	
	'
	'diese funktion wandelt eine integerzahl in minuten um
	'ausgabe im format hh:mm:ss (ss=00)
	'
	Function Int2Minute(ByRef Value As Short) As String
		Dim tmpMinuten As Double
		Dim tmpStunden As Short
		Dim tmpZeit As String
		
		'wenn nichts übergebn wird, dann gehts schnell...
		If Value = 0 Then
			tmpZeit = "00:00:00"
		Else
			'die stunden herausfinden
			tmpStunden = Int(Value / 60)
			'die minuten herausfinden
			tmpMinuten = Value - (tmpStunden * 60)
			'die Uhrzeit zusammenbauen
			tmpZeit = CStr(tmpStunden) & ":" & CStr(tmpMinuten) & ":00"
		End If
		
		'die neue zeit zurückliefern
		Int2Minute = tmpZeit
		
		
	End Function
	
	Function ReverseFind(ByRef Ausdruck As String, ByRef Zeichen As String) As Short
		'sucht im 'Ausdruck' das vorkommen des 'Zeichen' von hinten her
		Dim schleife As Short
		Dim laenge As Short
		Dim Position As Short
		
		'der startwert, falls nichts gefunden wurde (C++kompatibel)
		Position = 0
		
		'wie lang ist der Ausdruck
		laenge = Len(Ausdruck)
		
		'vom letzten zum ersten zeichen gehen
		For schleife = laenge To 1 Step -1
			'prüfen ob das zeichen gefunden wurde
			If Mid(Ausdruck, schleife, 1) = Zeichen Then
				Position = schleife
				Exit For
			End If
		Next 
		
		'die position zurückliefern
		ReverseFind = Position
		
		
		
	End Function
	
	'
	Function GetAppPfad() As Object
		Dim Pfadname As String
		
		On Error GoTo ErrorGetAppPfad
		
		
		'den pfad der applikation hohlen
		Pfadname = My.Application.Info.DirectoryPath
		If Right(Pfadname, 1) <> "\" Then
			'wenn das letzte zeichen kein \ dann hänge eins dran
			Pfadname = Pfadname & "\"
		End If
		
		'zuweisen des rückgabe wertes
		'UPGRADE_WARNING: Die Standardeigenschaft des Objekts GetAppPfad konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		GetAppPfad = Pfadname
		
		Exit Function
		
ErrorGetAppPfad: 
		Select Case Err.Number
			Case 53
				MsgBox("datei nicht vorhanden", 16, "Error")
				Exit Function
			Case 75
				MsgBox("Pfad ungültig", 16, "Error")
				Exit Function
			Case Else
				MsgBox("Nicht behandelter Fehler", 16, "Error: " & CStr(Err.Number))
				Resume Next
				
		End Select
		
		
	End Function
	
	
	
	
	
	
	
	
	Function GetNextNumeric(ByVal Text As String) As String
		Dim schleife As Short
    Dim tmp As String = ""
		
		'den string von der ersten bis zur letzten position absuchen
		For schleife = 1 To Len(Text)
			'prüfen ob das zeichen momentan eine 0-9 ist
			If Asc(Mid(Text, schleife, 1)) >= 48 And Asc(Mid(Text, schleife, 1)) <= 57 Then
				'ja, also dazukopieren
				tmp = tmp & Mid(Text, schleife, 1)
			Else
				'wenn nicht, dann ist es zu ende, weil die zahlen nicht zusammenhängen
				GoTo Cancel
				
			End If
		Next 
Cancel: 
		
		'den string zurückliefern
		GetNextNumeric = tmp
		
	End Function
	
	Function FirstNumeric(ByVal Text As String) As Short
		Dim schleife As Short
		
		'startwert auf -1 setzen, denn wenn nichts gefunden wird, soll er -1 zurückliefern
		FirstNumeric = -1
		'den string von der ersten bis zur letzten position absuchen
		For schleife = 1 To Len(Text)
			'prüfen ob das zeichen momentan eine 0-9 ist
			If Asc(Mid(Text, schleife, 1)) >= 48 And Asc(Mid(Text, schleife, 1)) <= 57 Then
				'ja, also zurückliefern und funktion beenden
				FirstNumeric = schleife
				Exit Function
			End If
		Next 
		
		
	End Function
	Function FirstAPunkt(ByVal Text As String) As String
    Dim schleife As Short
    Dim ret As String = ""
		
		'den string von der ersten bis zur letzten position absuchen
		For schleife = 1 To Len(Text)
			'prüfen ob das zeichen momentan ein - oder ; ist
			If Asc(Mid(Text, schleife, 1)) = 45 Or Asc(Mid(Text, schleife, 1)) < 59 Then
				'ja, also zurückliefern und funktion beenden
        ret = Mid(Text, schleife, 1)
        Exit For
        'Exit Function
			End If
		Next 
		
    FirstAPunkt = ret
	End Function
	
	
	'
	'Diese Funktion sucht im Angegebenen String das übergebene zeichen und Zählt wie oft es vorhanden ist
	'
	Function CountChar(ByVal Text As String, ByRef Zeichen As Short) As Integer
		Dim schleife As Short
		Dim Menge As Integer
		
		'Stratbedingung
		Menge = 0
		
		
		'den string von der ersten bis zur letzten position absuchen
		For schleife = 1 To Len(Text)
			'prüfen ob das zeichen momentan ein - oder ; ist
			If Asc(Mid(Text, schleife, 1)) = Zeichen Then
				'ja, zähler incrementieren
				Menge = Menge + 1
			End If
		Next 
		
		CountChar = Menge
	End Function
	
	Function GetPfad(ByRef Wert As String) As String
    'Dim Pfad As String
		Dim Position As Short
		
		Position = ReverseFind(Wert, "\")
		If Position = 0 Then
			GetPfad = ""
		Else
			GetPfad = Left(Wert, Position)
		End If
		
	End Function
	
	Function RemovePfad(ByRef Wert As String) As String
    'Dim Pfad As String
		Dim Position As Short
		
		Position = ReverseFind(Wert, "\")
		If Position = 0 Then
			RemovePfad = Wert
		Else
			RemovePfad = Right(Wert, Len(Wert) - Position)
		End If
		
	End Function
	
	Function GetPrinterLines(ByRef SchriftSize As Short) As Integer
        'Dim Printer As New Printer
        ''geht nicht (DLL-Fehler)
        'Exit Function

        'Dim YPixel As Integer 'die höhe in pixeln
        'Dim dc As Integer

        ''UPGRADE_ISSUE: Printer Eigenschaft Printer.hdc wurde nicht aktualisiert. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        'dc = Printer.hdc
        ''die anzahl der pixel in Y richtung
        'YPixel = GetDeviceCaps(CInt(dc), CInt(10))

        ''Pixel / Punktanzahl der Zeichen
        'GetPrinterLines = YPixel / SchriftSize
		
		
	End Function
	
	Sub LinePrint(ByRef Begin As Short, ByRef Lang As Short)
		Dim Printer As New Printer
		Dim schleife As Short
		
		For schleife = Begin To Begin + Lang
			Printer.Write("-")
		Next 
		
		
	End Sub
	
	Sub PrintError(ByRef FehlerNummer As Integer)
		Dim msg As String
		msg = "Der Folgende Fehler Ist Aufgetreten:" & Chr(13)
		msg = msg & "# " & CStr(Err.Number) & Chr(13)
		msg = msg & ErrorToString()
		
		MsgBox(msg, MsgBoxStyle.Exclamation, "Universal-Fehler-Dialog")
	End Sub
	
	Function RunTime() As Short
		Dim i, owner As Integer
		Dim bez As New VB6.FixedLengthString(40)
		
		bez.Value = Space(40) ' Leeren String erzeugen
		' Hauptfenster bestimmen
		owner = GetWindow(frmMain.Handle.ToInt32, GW_OWNER)
		' Klassennamen abfragen
		i = GetClassName(owner, bez.Value, 40)
		' Auswerten
		If Left(bez.Value, 11) = "ThunderMain" Then
			RunTime = True
		Else
			RunTime = False
		End If
	End Function
	
	Function GetKanal(ByRef datastring As String) As String
		'holt aus dem Datenstring die info welcher Kanal gemessen wurde
		GetKanal = Mid(datastring, 2, 1)
	End Function
	
	Function GetWert(ByRef datastring As String) As String
		Dim tmp As String 'kopie der wichtigsten zeichen aus dem Datastring
		Dim pos As Short 'position des dezimalpunktes
		
		On Error GoTo errorGetwert
		
		'die funktion getwert holt sich aus dem Datenstring
		'den teil der den Zahlenwert beinhaltet und wandelt den
		'dezimalpunkt in ein Komma um (für Excel)
		tmp = Mid(datastring, 4, 9)
		pos = InStr(tmp, ".")
		Mid(tmp, pos, 1) = ","
		GetWert = tmp
		Exit Function
		
errorGetwert: 
		MsgBox("Fehler bei Meßwertkonvertierung" & Chr(13) & "evtl. falsche COM-Parametereinstellung!" & Chr(13) & "Programm wird beendet...", 16, "Getwert Fehler:")
		GetWert = "+00000,00" 'Meßwert löschen...
		End
	End Function
	
	Function Komma2Punkt(ByRef datastring As String) As String
		Dim pos As Short 'position des dezimalpunktes
		
		On Error GoTo errorKomma2Punkt
		
		'die funktion Komma2Punkt holt sich aus dem Datenstring
		'die pos des kommas und wandelt ihn um in einen punkt
		
		pos = InStr(datastring, ",")
		Mid(datastring, pos, 1) = "."
		Komma2Punkt = datastring
		
		Exit Function
		
		
		
errorKomma2Punkt: 
		Komma2Punkt = datastring 'Meßwert unverändert zurückgeben...
	End Function
	
	Function Punkt2Komma(ByRef datastring As String) As String
		Dim pos As Short 'position des dezimalpunktes
		
		On Error GoTo errorPunkt2Komma
		
		'die funktion Komma2Punkt holt sich aus dem Datenstring
		'die pos des kommas und wandelt ihn um in einen punkt
		
		pos = InStr(datastring, ".")
		If pos > 0 Then
			Mid(datastring, pos, 1) = ","
			Punkt2Komma = datastring
		Else
			Punkt2Komma = datastring 'Meßwert unverändert zurückgeben...
		End If
		
		Exit Function
		
		
		
errorPunkt2Komma: 
		Punkt2Komma = datastring 'Meßwert unverändert zurückgeben...
	End Function
	
	Function Punkt2Slash(ByVal datastring As String) As String
		Dim pos As Short 'position des dezimalpunktes
		Dim schleife As Short
		On Error GoTo errorPunkt2Slash
		
		'die funktion Punkt2Slash holt sich aus dem Datenstring
		'die pos des punktes und wandelt ihn um in einen slash
		
		For schleife = 1 To Len(datastring)
			If Mid(datastring, schleife, 1) = "." Then
				Mid(datastring, schleife, 1) = "/"
			End If
		Next 
		'zurückliefern des umgewandelten wertes
		Punkt2Slash = datastring
		
		Exit Function
		
errorPunkt2Slash: 
		Punkt2Slash = datastring 'Meßwert unverändert zurückgeben...
	End Function
	Function Date2Jet(ByVal datastring As String) As String
		Dim pos As Short 'der erste slash
		Dim pos2 As Short 'der zweite slash
		
		Dim Tag As String 'der Tag aus dem String
		Dim Monat As String 'der Monat
		Dim jahr As String 'das Jahr
		Dim datetmp As String 'das neu zusammengebaute datum
		
		On Error GoTo errorDate2Jet
		'dies funktion tausch den tag mit dem Monat, damit der wert im richtigen jetformat vorliegt
		pos = InStr(datastring, "/")
		Tag = Left(datastring, pos - 1)
		pos2 = InStr(pos, datastring, "/")
		pos2 = pos2 + pos 'den offset der in der instr funktion angegeben wurde, muß dazuaddiert werden
		Monat = Mid(datastring, pos + 1, (pos2) - (pos + 1))
		jahr = Right(datastring, Len(datastring) - pos2)
		'jetzt bauen wir den neuen wert zusammen
		datetmp = Monat & "/" & Tag & "/" & jahr
		
		
		'zurückliefern des umgewandelten wertes
		Date2Jet = datetmp
		
		Exit Function
		
errorDate2Jet: 
		Date2Jet = datastring 'Meßwert unverändert zurückgeben...
	End Function
	
	'
	'überprüft ob eine angegebene datei auch existiert
	'
	'
	'
	Function FileExist(ByRef dateiname As String) As Short
		Dim tmp As Object
		
		On Error GoTo fehlerfileexist 'falls ein fehler beim zugriff auftritt
		'UPGRADE_WARNING: Dir hat ein neues Verhalten. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		'UPGRADE_WARNING: Die Standardeigenschaft des Objekts tmp konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		tmp = Dir(dateiname) <> "" 'den dateinamen anzeigen
		'UPGRADE_WARNING: Die Standardeigenschaft des Objekts tmp konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If tmp = True Then 'hat die dir-funktion was gefunden?
			FileExist = True 'ja, die datei ist vorhanden
		Else
			FileExist = False 'nein, die datei ist nicht da
		End If
		
		Exit Function
		
fehlerfileexist: 
		FileExist = False 'wenn ein fehler aufgetreten ist, dann stimmt sowieso was nicht...
		Resume Next
		
		
		
	End Function
	
	'
	' wandelt einen übergebenen string in einen reinen ascii string um
	'
	'
	'
	Function ToAscii(ByRef universalstring As String) As String
		Dim laenge As Short 'enthält die länge des übergeben strings (zum schluß)
    Dim tmp As String = "" 'zur zwischenspeicherung
		
		For laenge = 1 To Len(universalstring) 'gehe den string vom ersten bsi zum letzten zeichen durch
			If Asc(Mid(universalstring, laenge, 1)) > 31 And Asc(Mid(universalstring, laenge, 1)) < 253 Then 'ist das zeichen ein Druckbarer ascii-code?
				tmp = tmp & Mid(universalstring, laenge, 1) 'ja, dann temporär speichern
			End If
		Next 
		
		ToAscii = Trim(tmp) 'den neu erzeugten string speichern (keine führenden oder nachgestellten leerzeichen)
		
	End Function
	
	'
	' wandelt einen übergebenen string in einen reinen ascii string um
	' meistens für zugriffe auf ini-dateien benötigt...
	' aber es werden auch leerzeichen herausgefiltert
	'
	Function ToAsciiNoSpace(ByRef universalstring As String) As String
		Dim laenge As Short 'enthält die länge des übergeben strings (zum schluß)
    Dim tmp As String = "" 'zur zwischenspeicherung
		
		For laenge = 1 To Len(universalstring) 'gehe den string vom ersten bsi zum letzten zeichen durch
			If Asc(Mid(universalstring, laenge, 1)) > 32 And Asc(Mid(universalstring, laenge, 1)) < 128 Then 'ist das zeichen ein Druckbarer ascii-code?
				tmp = tmp & Mid(universalstring, laenge, 1) 'ja, dann temporär speichern
			End If
		Next 
		
		ToAsciiNoSpace = tmp 'den neu erzeugten string speichern
		
	End Function
	
	
	Sub WaitSec(ByRef WaitSec As Short)
		Dim Start As Date
		Dim Ende As Date
		Dim ZeitDiff As Date
		Dim Sek As Short
		Dim Min As Short
		Dim Sekunden As Short
		Dim Minuten As Short
		
		'bei mehr als 3600 sekunden auf 3600 sec.begrenzen
		If WaitSec > 3600 Then
			WaitSec = 3600
			Debug.Print("Zu große Zeitangabe!")
			Beep()
		End If
		
		
		'beginnzeit feststellen
		Start = TimeOfDay
		
		'durch 60 teilen und restliche sekunden anzeigen
		Sekunden = WaitSec Mod 60
		Minuten = Int(WaitSec / 60)
		
		'endezeit prüfen
		Do 
			'neue zeit feststellen
			Ende = TimeOfDay
			
			'differenz errechnen
			ZeitDiff = System.Date.FromOADate(Ende.ToOADate - Start.ToOADate)
			
			'minuten & sekunden herausfiltern
			Sek = Second(ZeitDiff)
			Min = Minute(ZeitDiff)
			
			'prüfen ob ziel erreicht
			If Min >= Minuten Then
				If Sek >= Sekunden Then
					'nicht fein aber was solls...
					Exit Sub
				End If
			End If
			
			'prozessorzeit freigeben
			System.Windows.Forms.Application.DoEvents()
			
			'endlos schleife
		Loop While (1 = 1)
		
		
		
		
		
		
		
		
		
	End Sub
	
	
	Sub WaitMiliSec(ByRef MiliSekunden As Integer)
		
		Sleep((MiliSekunden))
		
	End Sub
End Module