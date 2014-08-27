Option Strict Off
Option Explicit On

'VB2010 alle Warnungen in dieser Datei beseitigt
Imports Microsoft.Win32

Module mdlFileIO

  Dim ApplicationPath As String
  Public Stammdatenbank As String

  'ab hier sind die variablen in der Registry
  Public Fehler As Integer 'enthält entscheidungskriterium wie auf Fehlerhafte Meßwerte Reagiert werden soll
  Public GeraetKanal As String 'enthält den ausgewählten Meßgerätetyp etc (gerätekennzeichnung)

  'Nicht verwendet
  Sub CheckApplicationPath()
    If ApplicationPath = My.Application.Info.DirectoryPath Then
      'alles ok, so lassen
    Else
      ApplicationPath = My.Application.Info.DirectoryPath
    End If

  End Sub


  Sub CheckDatabases()

    'prüfen ob die datenbank vorhanden ist
    If FileExist(Stammdatenbank) = False Then

      ''diverse einstellungen
      'frmDialog.dlgDialogOpen.Filter = "Access Datenbenbank|*.MDB|Access 2010 Datenbenbank|*.ACCDB"
      'frmDialog.dlgDialogOpen.FilterIndex = 1
      'frmDialog.dlgDialogOpen.FileName = Datenbank
      ''konverter hat folgende Zeile entfernt, weil keine Entsprechung in VB.Net vorhanden ist
      ''frmDialog.dlgDialog.Flags = &H1000 Or &H4 Or &H800
      ''http://msdn.microsoft.com/en-us/library/aa259317%28v=vs.60%29.aspx
      ''cdlOFNHideReadOnly 	&H4 	Hides the Read Only check box.
      ''cdlOFNPathMustExist 	&H800 	Specifies that the user can enter only valid paths. If this flag is set and the user enters an invalid path, a warning message is displayed.
      ''cdlOFNFileMustExist 	&H1000 	Specifies that the user can enter only names of existing files in the File Name text box. If this flag is set and the user enters an invalid filename, a warning is displayed. This flag automatically sets the cdlOFNPathMustExist flag.
      ''VB2010 so sieht es jetzt aus (aber keine Veraenderung am Dialog erkennbar unter Win7)
      'frmDialog.dlgDialogOpen.CheckPathExists = True
      'frmDialog.dlgDialogOpen.CheckFileExists = True
      'frmDialog.dlgDialogOpen.ReadOnlyChecked = False

      'frmDialog.dlgDialogOpen.Title = "Suche nach der Stammdatenbank"
      'frmDialog.dlgDialogOpen.ShowDialog()
      'Datenbank = frmDialog.dlgDialogOpen.FileName

    End If

    If FileExist(Stammdatenbank) = False Then
      MsgBox("Stamm-Datenbank nicht gefunden", MsgBoxStyle.Critical)
      End
    End If


  End Sub

  'Quelle: http://msdn.microsoft.com/de-de/library/bb979300.aspx

  Private Sub RegistryCheck()
    Dim RegKey As RegistryKey

    RegKey = Registry.CurrentUser.OpenSubKey("Software\Elektro-Winterer", True)
    If IsNothing(RegKey) = True Then
      'Anlegen und Löschen von Registryzweigen 
      RegKey = Registry.CurrentUser.OpenSubKey("Software", True)
      ' Einen Unterzweig anlegen 
      RegKey.CreateSubKey("Elektro-Winterer")
    End If

    RegKey = Registry.CurrentUser.OpenSubKey("Software\Elektro-Winterer\ELWIPPS.Net", True)
    If IsNothing(RegKey) = True Then
      'Anlegen und Löschen von Registryzweigen 
      RegKey = Registry.CurrentUser.OpenSubKey("Software\Elektro-Winterer", True)
      ' Einen Unterzweig anlegen 
      RegKey.CreateSubKey("ELWIPPS.Net")
    End If

    RegKey = Registry.CurrentUser.OpenSubKey("Software\Elektro-Winterer\ELWIPPS.Net\Allgemein", True)
    If IsNothing(RegKey) = True Then
      'Anlegen und Löschen von Registryzweigen 
      RegKey = Registry.CurrentUser.OpenSubKey("Software\Elektro-Winterer\ELWIPPS.Net", True)
      ' Einen Unterzweig anlegen 
      RegKey.CreateSubKey("Allgemein")
      ' Zweig Oeffnen
      RegKey = Registry.CurrentUser.OpenSubKey("Software\Elektro-Winterer\ELWIPPS.Net\Allgemein", True)

      ' Schluessel anlegen
      RegKey.SetValue("Stammdatenbank", "elwipps.mdb", RegistryValueKind.String)

    End If



    'RegKey = Registry.CurrentUser.OpenSubKey("Software\Elektro-Winterer\MW-Erfa.Net\Report", True)
    'If IsNothing(RegKey) = True Then
    '  'Anlegen und Löschen von Registryzweigen 
    '  RegKey = Registry.CurrentUser.OpenSubKey("Software\Elektro-Winterer\MW-Erfa.Net", True)
    '  ' Einen Unterzweig anlegen 
    '  RegKey.CreateSubKey("Report")
    '  ' Zweig Oeffnen
    '  RegKey = Registry.CurrentUser.OpenSubKey("Software\Elektro-Winterer\MW-Erfa.Net\Report", True)

    '  ' Schluessel anlegen
    '  RegKey.SetValue("ReportMassGruppe", "C:\MW-ERFA\MassGrp.RPT", RegistryValueKind.String)
    '  RegKey.SetValue("ReportTeilGruppe", "C:\MW-ERFA\TeilGrp.RPT", RegistryValueKind.String)
    '  RegKey.SetValue("ReportDatabase", "C:\MW-ERFA\ecksberg.mdb", RegistryValueKind.String)

    'End If


    ' Den Registryzweig schließen 
    RegKey.Close()

  End Sub
  Private Function ReadRegistryValueLong(ByRef Name As String, ByRef Key As String, ByVal DefaultValue As Long) As Long
    Dim ret As Long = 0

    'Registryzweig öffnen 
    Dim RegKey As RegistryKey
    RegKey = Registry.CurrentUser.OpenSubKey(Name)
    If IsNothing(RegKey) = True Then
      ret = DefaultValue
    Else
      'Werte auslesen
      Dim RegValue As Long
      RegKey = Registry.CurrentUser.OpenSubKey(Name)
      RegValue = RegKey.GetValue(Key, DefaultValue)

      'Registry schliessen
      RegKey.Close()

      ret = RegValue
    End If

    ReadRegistryValueLong = ret

  End Function

  Private Function ReadRegistryValueString(ByRef Name As String, ByRef Key As String, ByRef DefaultValue As String) As String
    Dim ret As String = ""

    'Registryzweig öffnen 
    Dim RegKey As RegistryKey
    RegKey = Registry.CurrentUser.OpenSubKey(Name)
    If IsNothing(RegKey) = True Then
      ret = DefaultValue
    Else
      'Werte auslesen
      Dim RegValue As String
      RegKey = Registry.CurrentUser.OpenSubKey(Name)
      RegValue = RegKey.GetValue(Key, DefaultValue)

      'Registry schliessen
      RegKey.Close()

      ret = RegValue

    End If

    ReadRegistryValueString = ret

  End Function

  Private Sub WriteRegistryValueLong(ByRef Name As String, ByRef Key As String, ByVal Value As Long)
    Dim RegKey As RegistryKey

    ' Einen Registryzweig zum Schreiben öffnen 
    RegKey = Registry.CurrentUser.OpenSubKey(Name, True)
    If IsNothing(RegKey) = False Then
      ' Schlüssel anlegen 
      RegKey.SetValue(Key, Value, RegistryValueKind.DWord)

      'Registry schliessen
      RegKey.Close()
    End If

  End Sub

  Private Sub WriteRegistryValueString(ByRef Name As String, ByRef Key As String, ByRef Value As String)
    Dim RegKey As RegistryKey

    ' Einen Registryzweig zum Schreiben öffnen 
    RegKey = Registry.CurrentUser.OpenSubKey(Name, True)
    If IsNothing(RegKey) = False Then
      ' Schlüssel anlegen 
      RegKey.SetValue(Key, Value, RegistryValueKind.String)

      'Registry schliessen
      RegKey.Close()
    End If

  End Sub


  Sub RegistryLesen()

    RegistryCheck()
    Stammdatenbank = ReadRegistryValueString("Software\Elektro-Winterer\ELWIPPS.Net\Allgemein", "Stammdatenbank", "elwipps.mdb")

  End Sub

  Sub RegistrySchreiben()

    RegistryCheck()
    WriteRegistryValueString("Software\Elektro-Winterer\ELWIPPS.Net\Allgemein", "Stammdatenbank", Stammdatenbank)

  End Sub
End Module