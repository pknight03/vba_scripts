
Sub InsertCommentImageTwo()

'Below is VBA code for excel to insert an image into a comment box in the cell to the right of the weblink.

'Source:
'www.contextures.com/xlcomments03.html
'http://www.contextures.com/xlcomments03.html#Picture
'Before running this make sure formhub is not down otherwise willl crash

' Message box, do you want the macro to run?
If MsgBox("Have you checked formhub is not down? If it is Excel will crash when completing this macro. Pressing no will stop the macro running", vbYesNo) = vbNo Then Exit Sub

Dim rngList As Range
Dim c As Range
Dim cmt As Comment
Dim strPic As String
'status bar info
Dim lCounter                          As Long
Dim lTotal                            As Long
    
On Error Resume Next

'sets range as CTRL+DownArrow
Set rngList = Range(Selection, Selection.End(xlDown))
'Picture url
strPic = ""

'For each in the Range put comment box to the cell on the right
For Each c In rngList
  With c.Offset(0, 1)
    Set cmt = c.Comment
    If cmt Is Nothing Then
      Set cmt = .AddComment
    End If
    With cmt
      .Text Text:=""
      .Shape.Fill.UserPicture strPic & c.Value
      .Visible = False
      .Text Text:="" & Chr(10) & ""
      .Shape.ScaleWidth 5, msoFalse, msoScaleFromTopLeft
      .Shape.ScaleHeight 5, msoFalse, msoScaleFromTopLeft
    End With
      'status bar Source: http://www.asap-utilities.com/excel-tips-detail.php?categorie=9&m=92
      lTotal = Selection.Cells.Count            ' total amount of cells to walk through
      ' Makes sure that the statusbar is visible.
      Application.DisplayStatusBar = True
            ' show the progress in the statusbar:
            Application.StatusBar = "Processing cells " & rngList.AddressLocal & _
                                 "    Count completed: " & Format((lCounter / lTotal), "")
  End With
Application.Wait (Now + TimeValue("0:00:01"))
'add +1 to the counter status bar
lCounter = lCounter + 1
Next c
Application.StatusBar = False
End Sub
