' Demo Module
' ASSIGN TO: Bounrith Ly
' TODO: this is too weak, secure further with registry integration/deal with Windows Registry and UAC

Imports System.IO

Module modDemo

    Dim filenumber As Integer 'a variable delcare to get in the value of freefile function / automatically assigns the value which represents the file
    Dim times_used As Integer = 1 'initializing times_used
    Dim max_limit As Integer = 10 'set the maximum number of times


    Public Sub demosoft()
        filenumber = FreeFile() 'We assign the number which represents which file to open
        If IO.File.Exists("DemoMe.xml") Then 'Checking if file exists..
            FileOpen(filenumber, "DemoMe.xml", OpenMode.Random, OpenAccess.ReadWrite) 'If exists,were opening it in readwrite mode.
            FileGet(filenumber, times_used) 'Were reading from the file the value thats stored..ie the number of times he has used
            If times_used >= 8 Then
                MessageBox.Show("You can only run this software " & (max_limit - times_used) & " more times.", "Licensing Warning")
            End If

            FileClose(filenumber)
            If times_used >= max_limit Then 'Were checking if the user has used the software more than the limit specified
                MessageBox.Show("Sorry, Your trial period is over!! Please purchase this software.", "Licensing Error") 'oops,if it has exceeded,then,he cant use it  
                frmFPhotoM.Close() ' QUIT THE ENTIRE PROGRAM
            End If
            times_used = times_used + 1 'if he has used it once before,lets make it 2 now since this is the 2nd time
            FileOpen(filenumber, "DemoMe.xml", OpenMode.Random, OpenAccess.ReadWrite) 'storing the value back here 
            FilePut(filenumber, times_used)
            FileClose(filenumber)
        Else
            'This part is if the user is using the software for the 1st time.The file has to be created
            FileOpen(filenumber, "DemoMe.xml", OpenMode.Random, OpenAccess.ReadWrite)
            FilePut(filenumber, times_used) 'ok,now he has opened and used once,so,lets write it in here.
            FileClose(filenumber)
        End If
    End Sub


    Public Function YearTest(ByVal NumDays As Integer) As Boolean
        Dim txtjSDate As String
        Dim jSDateFileR As StreamReader
        Dim jsDateFileW As StreamWriter


        If File.Exists("jSDate.xml") Then
            jSDateFileR = File.OpenText("jSDate.xml")
            txtjSDate = jSDateFileR.ReadLine()
            jSDateFileR.Close()
        Else
            jsDateFileW = File.CreateText("jSDate.xml")
            jsDateFileW.WriteLine(DateToJDate(System.DateTime.Now()))
            jsDateFileW.Close()
        End If

        Dim jsDatePass = txtjSDate + 365

        If DateToJDate(System.DateTime.Now()) - jsDatePass > 10 Then
            YearTest = False ' program will go into Demo mode after 375 days of usage w/ 10 days grace period
        Else
            YearTest = True ' program is still within 365 days license
        End If

    End Function

End Module
