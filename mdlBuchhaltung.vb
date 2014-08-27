Option Strict Off
Option Explicit On
Module mdlBuchhaltung

	Public RechnungslisteReport As String
	
	Public KundenNr As Integer 'Der Prim�rschl�ssel aus der kundennummertabelle
	Public TageNetto As Short
	Public TageSkonto As Short
	Public AnzahlAusdrucke As Short
  Public MwSt As Single
	
	Public Erfassungsart As Short
	'konstanten f�r Erfassungsart
	Public Const vbRechnung As Short = 1
	Public Const vbBestellung As Short = 2
	Public Const vbLieferschein As Short = 3
	'UPGRADE_WARNING: Die Anwendung wird beendet, wenn Sub Main() vollst�ndig ausgef�hrt wurde. Klicken Sie hier f�r weitere Informationen: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E08DDC71-66BA-424F-A612-80AF11498FF8"'
	Public Sub Main()

    RegistryLesen()

    'Stammdatenbank = "c:\Eigene Dateien\Projects\Rechnungsprogramm\Rechnung.mdb"
		RechnungslisteReport = "c:\Eigene Dateien\Projects\Rechnungsprogramm\Rechnungsliste.rpt"
		TageNetto = 14
		TageSkonto = 8
		AnzahlAusdrucke = 2
    MwSt = 19
    frmMain.ShowDialog()



		
	End Sub
End Module