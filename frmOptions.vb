Option Strict Off
Option Explicit On
Friend Class frmOptions
	Inherits System.Windows.Forms.Form

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

    RegistrySchreiben()
    Me.Close()

  End Sub

  Private Sub btnSelectDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectDatabase.Click
    'Dateiauswahldialog anzeigen
    '
    dlgSelectFile.Filter = "Database Files|*.mdb"
    dlgSelectFile.FilterIndex = 0

    If dlgSelectFile.ShowDialog() = DialogResult.OK Then
      Stammdatenbank = dlgSelectFile.FileName
      txtDatabase.Text = Stammdatenbank
    End If

  End Sub

  Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    txtDatabase.Text = Stammdatenbank
  End Sub
End Class