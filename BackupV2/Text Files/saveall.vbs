'VBS Script to force Minecraft Server to save all
'By Dateranoth - August 28, 2010
'v1.0 - Initial Release
'v1.1 - Added lines to bring window into focus before key strokes.

Set WshShell = WScript.CreateObject("WScript.Shell")

'Enter the name of your Server Window Here bewteen the apostrophies
T1 = "test"

Sub KeyIt(Keystroke, WinTitle)

  WshShell.AppActivate WinTitle

  WScript.Sleep 100

  WshShell.SendKeys Keystroke

End Sub

WshShell.AppActivate WinTitle
Call KeyIt( "LOL", T1)
call KeyIt( " ", T1)
Call KeyIt( "{ENTER}", T1)

Wscript.Quit