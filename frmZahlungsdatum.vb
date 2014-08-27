Option Strict Off
Option Explicit On
Friend Class frmZahlungsdatum
	Inherits System.Windows.Forms.Form
	Sub SetZahlungsdatum()
		Dim dbRechnung As DAO.Database
		Dim qdDatum As DAO.QueryDef
		Dim Menge As Integer
		
		
		
		dbRechnung = DAODBEngine_definst.Workspaces(0).OpenDatabase(Stammdatenbank, False, False)
		qdDatum = dbRechnung.QueryDefs("updateZahlungsDatum")
		
		qdDatum.Parameters("vorgabeRechnungsNr").Value = txtRechnungsNr.Text
		qdDatum.Parameters("vorgabeZahlungsDatum").Value = txtZahlungsDatum.Text
		qdDatum.Parameters("vorgabeZahlungsBetrag").Value = txtZahlungsBetrag.Text
		qdDatum.Execute()
		
		'Feststellen ob das Zahlungsdatum auch gespeichert wurde
		Menge = qdDatum.RecordsAffected
		MsgBox("Es wurde(n) " & CStr(Menge) & " Datensätze gespeichert", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
		
		
		dbRechnung.Close()
		
	End Sub
	
	
	Private Sub cmdEnde_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEnde.Click
		Me.Close()
	End Sub
	
	Private Sub cmdSpeichern_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSpeichern.Click
		Call SetZahlungsdatum()
	End Sub
	
	
	Private Sub txtRechnungsNr_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtRechnungsNr.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'bei return ein tab senden
		If KeyAscii = 13 Then
			System.Windows.Forms.SendKeys.Send("{TAB}")
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	
	Private Sub txtZahlungsBetrag_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtZahlungsBetrag.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'bei return ein tab senden
		If KeyAscii = 13 Then
			System.Windows.Forms.SendKeys.Send("{TAB}")
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtZahlungsBetrag_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtZahlungsBetrag.Leave
		If IsNumeric(txtZahlungsBetrag.Text) = True Then
			txtZahlungsBetrag.Text = CStr(CDec(txtZahlungsBetrag.Text))
		Else
			txtZahlungsBetrag.Text = "0,00"
		End If
	End Sub
	
	
	Private Sub txtZahlungsDatum_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtZahlungsDatum.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'bei return ein tab senden
		If KeyAscii = 13 Then
			System.Windows.Forms.SendKeys.Send("{TAB}")
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtZahlungsDatum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtZahlungsDatum.Leave
		If IsDate(txtZahlungsDatum.Text) = True Then
			txtZahlungsDatum.Text = CStr(CDate(txtZahlungsDatum.Text))
		Else
			txtZahlungsDatum.Text = CStr(Today)
		End If
	End Sub
End Class