' Demo Module
' ASSIGN TO: Bounrith Ly
' TODO: this is too weak, secure further with registry integration/deal with Windows Registry and UAC



Module modDemo

    Dim filenumber As Integer 'a variable delcare to get in the value of freefile function / automatically assigns the value which represents the file
    Dim times_used As Integer = 1 'initializing times_used
    Dim max_limit As Integer = 10 'set the maximum number of times

    'http://vbdotnetforum.com/index.php?/topic/31-make-trial-version-of-software/
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



    Public Function DateGood(ByVal NumDays As Integer) As Boolean

        'The purpose of this module is <strong class="highlight">to</strong> allow you <strong class="highlight">to</strong> place a time
        'limit on the unregistered use of your shareware application.
        'This module can not be defeated by rolling back the system clock.
        'Simply call the DateGood function when your application is first
        'loading, passing it the number of days it can be used without
        'registering.
        '
        'Ex: If DateGood(30)=False Then
        ' CrippleApplication
        ' End if
        'Register Parameters:
        ' CRD: Current Run Date
        ' LRD: Last Run Date
        ' FRD: First Run Date

        Dim TmpCRD As Date
        Dim TmpLRD As Date
        Dim TmpFRD As Date

        TmpCRD = Format(Now, "m/d/yy")
        TmpLRD = GetSetting(Application.ExecutablePath, "Param", "LRD", "1/1/2011")
        TmpFRD = GetSetting(Application.ExecutablePath, "Param", "FRD", "1/1/2011")

        DateGood = False

        'If this is the applications first load, write initial settings
        '<strong class="highlight">to</strong> the register
        If TmpLRD = "1/1/2011" Then
            SaveSetting(Application.ExecutablePath, "Param", "LRD", TmpCRD)
            SaveSetting(Application.ExecutablePath, "Param", "FRD", TmpCRD)
        End If
        'Read LRD and FRD from register
        TmpLRD = GetSetting(Application.ExecutablePath, "Param", "LRD", "1/1/2011")
        TmpFRD = GetSetting(Application.ExecutablePath, "Param", "FRD", "1/1/2011")

        If TmpFRD > TmpCRD Then 'System clock rolled back
            DateGood = False
        ElseIf Now > DateAdd("d", NumDays, TmpFRD) Then 'Expiration expired
            DateGood = False
        ElseIf TmpCRD > TmpLRD Then 'Everything OK write New LRD date
            SaveSetting(Application.ExecutablePath, "Param", "LRD", TmpCRD)
            DateGood = True
        ElseIf TmpCRD = Format(TmpLRD, "m/d/yy") Then
            DateGood = True
        Else
            DateGood = False
        End If
    End Function

End Module
