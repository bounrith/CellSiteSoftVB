Imports System
Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Xml
Imports System.Text
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Text.RegularExpressions ' for string replacement
Imports Microsoft.Win32

Public Class frmFPhotoM
    Dim AllFiles As String()
    Dim AllFiles2 As String()
    Dim total_files As Integer = 0
    Dim image_loaded As Integer = 0
    Dim initial_load As Boolean = False
    Dim file_full_path As String()
    Dim box1_index As Integer = 0
    Dim box2_index As Integer = 0
    Dim box3_index As Integer = 0
    Dim file_browse_index As Integer = 0
    Dim image_full_path As String
    Dim thread1 As System.Threading.Thread
    Dim thread2 As System.Threading.Thread
    Dim open_excel As Boolean = False
    Dim Excel_App As Excel.Application
    Dim Excel_Workbook As Excel.Workbook
    Dim Excel_Worksheet As Excel.Worksheet
    Dim template_file_selected As Boolean
    Dim strSerialInput As String

    Private Sub CellSiteSoftMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSaltedMD5LicenseKey As String
        Dim LicenseKeyFile As StreamReader

        strSaltedMD5LicenseKey = localLicenseKey(getMacAddress, DateToJDate(Now()))

        ' test if LIC file exist and if exteranlLIC = internalLIC
        ' if success on both counts then FULL VERSION (for a year/need to be work on)
        ' else the program will enter demo mode for 20 usages
        Try
            LicenseKeyFile = File.OpenText("LicenseKey.txt")
            strSerialInput = LicenseKeyFile.ReadLine()
            LicenseKeyFile.Close()

        Catch ex As Exception
            MessageBox.Show("Please register the software soon. Thank you before hand.", "Licensing Warning")
        End Try

        ' test extLIC input against internal TRB Protection Algorithm
        If strSerialInput = strSaltedMD5LicenseKey Then
            ' FULL VERSION
        Else
            ' DEMO VERSION
            demosoft()
            'regcheck()
        End If

        ComboBox_Drives.Text = "Select a Drive"
        Load_Drives()
        Load_Category()

        FolderBrowserDialog1.SelectedPath = System.IO.Directory.GetCurrentDirectory()
        thread1 = New System.Threading.Thread(AddressOf ImageList_Load1)
        thread2 = New System.Threading.Thread(AddressOf ImageList_Load2)
        Control.CheckForIllegalCrossThreadCalls = False

        '---**To Determin the File Dialog is nothing or has value**-------
        template_file_selected = False
        OpenFileDialog1.FileName = Nothing
        '---**---------------------------------------------------**-------

        image_full_path = Nothing
        CheckListFile.Text = Nothing
        txtDestinationFolder.Text = Nothing
        'SetEnabled()

    End Sub

    Function getMacAddress()
        Dim nics() As NetworkInterface = _
            NetworkInterface.GetAllNetworkInterfaces
        Return nics(0).GetPhysicalAddress.ToString
    End Function

    ' convert Gregorian Date to Julian Date
    Public Shared Function DateToJDate(ByVal TheDate As Date) As String
        Dim TheYear As Integer
        Dim TheDays As Integer
        Dim JDate As String

        TheYear = Year(TheDate)
        TheDays = DateDiff("d", DateSerial(TheYear, 1, 0), TheDate)
        JDate = Format(TheYear, "0000") & Format(TheDays, "000")

        Return JDate
    End Function

    ' http://www.nonhostile.com/howto-calculate-md5-hash-string-vb-net.asp
    ' calculate the MD5 hash of a given string 
    ' the string is first converted to a byte array
    Public Function MD5CalcString(ByVal strData As String) As String

        Dim objMD5 As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim arrData() As Byte
        Dim arrHash() As Byte

        ' first convert the string to bytes (using UTF8 encoding for unicode characters)
        arrData = System.Text.Encoding.UTF8.GetBytes(strData)

        ' hash contents of this byte array
        arrHash = objMD5.ComputeHash(arrData)

        ' thanks objects
        objMD5 = Nothing

        ' return formatted hash
        Return ByteArrayToString(arrHash)

    End Function

    ' utility function to convert a byte array into a hex string
    Private Function ByteArrayToString(ByVal arrInput() As Byte) As String
        Dim strOutput As New System.Text.StringBuilder(arrInput.Length)

        For i As Integer = 0 To arrInput.Length - 1
            strOutput.Append(arrInput(i).ToString("X2"))
        Next
        Return strOutput.ToString().ToLower
    End Function

    Function localLicenseKey(ByVal getMacAddress As String, ByVal DateToJDate As String) As String
        Dim strSalt As String = "ERIKA"
        Dim txtjSDate As String

        ' this is so the internal LIC remain static for a duration
        ' need to enhance against jSDate.xml file deletion/modification
        ' possible register to Registry or get from TRB licensing web server
        Dim jSDateFile As StreamReader
        Try
            jSDateFile = File.OpenText("jSDate.xml")
            txtjSDate = jSDateFile.ReadLine()
            jSDateFile.Close()

        Catch ex As Exception
            ' jSDate.xml will be available after Help > Product Registration
            ' MessageBox.Show("jSDate cannot be opened.", "Warning Error")
        End Try

        Dim strMD5LicenseKey As String = MD5CalcString(getMacAddress & txtjSDate) ' unobfuscate MD5 hash 
        Dim strSaltedMD5LicenseKey = MD5CalcString(strSalt & strMD5LicenseKey) ' obfuscate MD5 hash w/ salt
        Return strSaltedMD5LicenseKey
    End Function


    Dim filenumber As Integer 'a variable delcare to get in the value of freefile function / automatically assigns the value which represents the file
    Dim times_used As Integer = 1 'initializing times_used
    Dim max_limit As Integer = 20 'set the maximum number of times

    'http://vbdotnetforum.com/index.php?/topic/31-make-trial-version-of-software/
    Private Sub demosoft()
        filenumber = FreeFile() 'We assign the number which represents which file to open
        If IO.File.Exists("DemoMe.xml") Then 'Checking if file exists..
            FileOpen(filenumber, "DemoMe.xml", OpenMode.Random, OpenAccess.ReadWrite) 'If exists,were opening it in readwrite mode.
            FileGet(filenumber, times_used) 'Were reading from the file the value thats stored..ie the number of times he has used
            If times_used >= 14 Then
                MessageBox.Show("You can only run this software " & (max_limit - times_used) & " more times.", "Licensing Warning")
            End If

            FileClose(filenumber)
            If times_used >= max_limit Then 'Were checking if the user has used the software more than the limit specified
                MessageBox.Show("Sorry, Your trial period is over!! Please purchase this software.", "Licensing Error") 'oops,if it has exceeded,then,he cant use it  
                Me.Close()
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


    Private Sub ComboBox_Drives_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_Drives.SelectedIndexChanged
        Dim split_drive_letter As String()
        Dim extract_drive_letter As String
        Dim last_split As Integer
        'MsgBox("Selected Drive: " & ComboBox_Drives.SelectedItem.ToString)
        'Threading.Thread.Sleep(5000) ' Wait for 5 seconds to browse the drive
        split_drive_letter = Split(ComboBox_Drives.SelectedItem, Chr(32)) ' Split string with SPACE delimeter
        last_split = UBound(split_drive_letter)
        extract_drive_letter = split_drive_letter(last_split)
        'LoadFolderTree(ComboBox_Drives.SelectedItem)
        LoadFolderTree(extract_drive_letter)
    End Sub

    'Friend WithEvents DirectoryTreeView As System.Windows.Forms.TreeView
    Public Sub LoadFolderTree(ByVal path As String)
        DirectoryTreeView.Nodes.Clear()
        Dim basenode As System.Windows.Forms.TreeNode
        If IO.Directory.Exists(path) Then
            If path.Length <= 3 Then
                basenode = DirectoryTreeView.Nodes.Add(path)
            Else
                basenode = DirectoryTreeView.Nodes.Add(My.Computer.FileSystem.GetName(path))
            End If
            basenode.Tag = path
            LoadDir(path, basenode)
        Else
            Throw New System.IO.DirectoryNotFoundException()
        End If
    End Sub

    'Changed from public to private
    Private Sub LoadDir(ByVal DirPath As String, ByVal Node As Windows.Forms.TreeNode)
        On Error Resume Next
        Dim Dir As String
        Dim Index As Integer
        If Node.Nodes.Count = 0 Then
            For Each Dir In My.Computer.FileSystem.GetDirectories(DirPath)
                Index = Dir.LastIndexOf("\")
                Node.Nodes.Add(Dir.Substring(Index + 1, Dir.Length - Index - 1))
                Node.LastNode.Tag = Dir
                Node.LastNode.ImageIndex = 0
            Next
        End If
    End Sub

    Private Sub DirectoryTreeView_AfterExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles DirectoryTreeView.AfterExpand
        Dim n As System.Windows.Forms.TreeNode
        For Each n In e.Node.Nodes
            LoadDir(n.Tag, n)
        Next
    End Sub

    'Changed from Public to Private
    Private Sub Load_Drives()
        Dim AllDrives() As DriveInfo = DriveInfo.GetDrives()
        Dim d As DriveInfo
        Dim drive_letter_and_type As String
        Dim drive_number As Integer = 0
        Dim volumelabel As String
        For Each d In AllDrives
            If My.Computer.FileSystem.Drives(drive_number).IsReady = True Then
                volumelabel = d.VolumeLabel
                If volumelabel = Nothing Then
                    volumelabel = d.DriveType.ToString()
                End If

                drive_letter_and_type = volumelabel & Chr(32) & d.Name
                'ComboBox_Drives.Items.Add(d.Name)
                ComboBox_Drives.Items.Add(drive_letter_and_type)
            End If
            drive_number = drive_number + 1
        Next
    End Sub

    ' Changed from Public to private
    Private Sub DirectoryTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles DirectoryTreeView.AfterSelect
        Dim split1 As String()
        Dim clean_path As String
        Dim number_of_split As Integer

        'MsgBox("The Orginal Path is: " & DirectoryTreeView.SelectedNode.FullPath.ToString)
        split1 = Split(DirectoryTreeView.SelectedNode.FullPath.ToString, "\\")
        number_of_split = UBound(split1)
        'MsgBox("Number of Split = " & number_of_split)
        If (number_of_split <> 0) Then
            clean_path = Replace(DirectoryTreeView.SelectedNode.FullPath.ToString, "\\", "\")
            'MsgBox("The Clean Path is: " & clean_path)
        Else
            clean_path = DirectoryTreeView.SelectedNode.FullPath.ToString
        End If

        'FileListView.Clear()
        AllFiles = Directory.GetFiles(clean_path, "*.*", SearchOption.TopDirectoryOnly)
        ThumbnailView(1)


    End Sub

    Private Sub cmdCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCategory.SelectedIndexChanged
        Select Case (cmdCategory.SelectedItem.ToString)
            Case "ALPHA SECTOR"
                Populate_Alpha()
            Case "BETA SECTOR"
                Populate_Beta()
            Case "CHARLIE SECTOR"
                Populate_Charlie()
            Case "DELTA SECTOR"
                Populate_Delta()
            Case "TOWER"
                Populate_Tower()
            Case "ICE BRIDGE"
                Populate_IceBridge()
            Case "ROOF TOP"
                Populate_RoofTop()
            Case "SHELTER"
                Populate_Shelter()
            Case "OUTDOOR PAD"
                Populate_OutDoorPad()
            Case "EQUIPMENT"
                Populate_Equipment()
            Case "ACCESS"
                Populate_Access()
            Case "SIGNAGE"
                Populate_Signage()
            Case "Ericsson QA"
                Populate_EricssonQA()
        End Select
    End Sub
    Private Sub Load_Category()
        cmdCategory.Items.Add("ALPHA SECTOR")
        cmdCategory.Items.Add("BETA SECTOR")
        cmdCategory.Items.Add("CHARLIE SECTOR")
        cmdCategory.Items.Add("DELTA SECTOR")
        cmdCategory.Items.Add("TOWER")
        cmdCategory.Items.Add("ICE BRIDGE")
        cmdCategory.Items.Add("ROOF TOP")
        cmdCategory.Items.Add("SHELTER")
        cmdCategory.Items.Add("OUTDOOR PAD")
        cmdCategory.Items.Add("EQUIPMENT")
        cmdCategory.Items.Add("ACCESS")
        cmdCategory.Items.Add("SIGNAGE")
        cmdCategory.Items.Add("Ericsson QA")
    End Sub

    Private Sub lstFileNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstFileNames.SelectedIndexChanged

    End Sub

    Private Sub CheckListFile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckListFile.TextChanged

    End Sub


    Public Sub CheckListFileSelect()

        Dim AllProcesses As Process()
        Dim split_file_name As String()
        Dim index_upper_bound As Integer
        Dim left_3_string As String

        Try
            OpenFileDialog1.ShowDialog()
            If (OpenFileDialog1.FileName = Nothing And template_file_selected = False) Then
                MessageBox.Show("Please select a Check List file")
                Return
            End If

            split_file_name = Split(OpenFileDialog1.FileName, ".")
            index_upper_bound = UBound(split_file_name)
            left_3_string = Microsoft.VisualBasic.Left(split_file_name(index_upper_bound), 3)

            If (left_3_string = "xls" Or left_3_string = "XLS") Then
                CheckListFile.Text = OpenFileDialog1.FileName
                template_file_selected = True

                '-------*** Change Checklist file, close EXCEL, Kill EXCEL Process ***-----------
                If (open_excel = True) Then
                    'MsgBox("Closing Excel File")
                    Excel_Workbook.Close()
                    Excel_App.Quit()
                    Excel_App = Nothing
                    AllProcesses = Process.GetProcesses
                    For Each one_process In AllProcesses
                        If one_process.ProcessName.Contains("EXCEL") Then
                            one_process.Kill()
                        End If
                    Next
                    open_excel = False
                End If
                '-------***---------------------------------------------------------***-------
            Else
                MessageBox.Show("Please select an EXCEL file")
                Return
            End If

        Catch ex As Exception
            MessageBox.Show("Can't locate file")
        End Try
    End Sub

    Private Sub cmdFileSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFileSelect.Click
        CheckListFileSelect()
    End Sub

    Public Sub SelectDestinationFolder()
        'Dim split_file2 As String()
        'Dim no_path_index As Integer
        Try
            FolderBrowserDialog1.ShowDialog()
            txtDestinationFolder.Text = FolderBrowserDialog1.SelectedPath.ToString
            AllFiles2 = Directory.GetFiles(txtDestinationFolder.Text, "*.*", SearchOption.TopDirectoryOnly)
            ThumbnailView(2)
            'lstFilesList2.Items.Clear()
            'For Each File In AllFiles2
            'split_file2 = Split(File.ToString, "\")
            'no_path_index = UBound(split_file2)
            'lstFilesList2.Items.Add(split_file2(no_path_index)) 'Ommit the path and Add file name only
            'Next
        Catch ex As Exception
            MessageBox.Show("Can not select this folder")
            txtDestinationFolder.Text = Nothing
        End Try
    End Sub

    Private Sub DestinationFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DestinationFolder.Click
        SelectDestinationFolder()
    End Sub

    Public Sub SuperCOPY()
        Dim new_name_no_white_space As String
        Dim destionation_path_and_file As String
        'Dim refresh_files As String()
        'Dim split_refresh As String()
        'Dim strip_path_index As Integer
        Dim total_row As Integer
        Dim data_from_excel As String(,) 'two dimensional array
        Dim check_list_file_name As String
        Dim array_no_white_space As String
        Dim row_index As Integer
        Dim column_index As Integer
        Dim column1_data As String
        Dim column4_data As String

        If image_full_path = Nothing Or lstFileNames.SelectedItem = Nothing Or txtDestinationFolder.Text = Nothing Then
            Return
        End If
        new_name_no_white_space = Replace(lstFileNames.SelectedItem.ToString, "/", "_Or_") ' Replace "/" with "_Or_"
        new_name_no_white_space = Replace(new_name_no_white_space, "\", "_Or_") ' Replace "\" with "_Or_"
        new_name_no_white_space = Replace(new_name_no_white_space, " ", "") ' Replace SPACE with nothing, delete space

        destionation_path_and_file = txtDestinationFolder.Text & "\" & new_name_no_white_space & ".jpg"

        FileCopy(image_full_path, destionation_path_and_file)
        check_list_file_name = CheckListFile.Text
        'refresh_files = Directory.GetFiles(txtDestinationFolder.Text, "*.*", SearchOption.TopDirectoryOnly)
        AllFiles2 = Directory.GetFiles(txtDestinationFolder.Text, "*.*", SearchOption.TopDirectoryOnly)
        ThumbnailView(2)
        'lstFilesList2.Items.Clear()

        'For Each refresh_file In refresh_files
        'split_refresh = Split(refresh_file.ToString, "\")
        'strip_path_index = UBound(split_refresh)
        'lstFilesList2.Items.Add(split_refresh(strip_path_index)) 'Omit the path and Add file name only
        'Next

        If check_list_file_name = Nothing Then
            Return
        End If

        If (open_excel = False) Then
            Excel_App = New Excel.Application
            Excel_Workbook = Excel_App.Workbooks.Open(check_list_file_name)
            Excel_Worksheet = Excel_Workbook.Sheets("Sheet1")
            open_excel = True
        End If

        Excel_Worksheet.Cells(3, 2) = "SITE NAME:" & Chr(32) & txtSiteName.Text
        Excel_Worksheet.Cells(4, 2) = "SITE ID:" & Chr(32) & txtSiteID.Text

        total_row = Excel_Worksheet.UsedRange.Rows.Count
        'MsgBox("Total Row = " & total_row)

        ReDim data_from_excel(0 To total_row + 1, 0 To 2) ' Will not use the array (0,0) to match the Excel index that starts at (1,1)

        For row_index = 1 To total_row
            For column_index = 1 To 2

                data_from_excel(row_index, column_index) = Excel_Worksheet.Cells(row_index, column_index).value

                'MsgBox("Excel Worksheet Data = " & Excel_Worksheet.Cells(row_index, column_index).value)
                'MsgBox("Data From Excel = " & data_from_excel(row_index, column_index))
                column1_data = Excel_Worksheet.Cells(row_index, 1).value
                column4_data = Excel_Worksheet.Cells(row_index, 4).value

                If (column1_data <> "" And column4_data <> "X") Then
                    Excel_Worksheet.Cells(row_index, 4) = "NA"
                End If

            Next column_index
        Next row_index

        new_name_no_white_space = Regex.Replace(new_name_no_white_space, txtSiteID.Text, "SiteID")
        new_name_no_white_space = Replace(new_name_no_white_space, "_", "") ' Delete underscore
        new_name_no_white_space = Replace(new_name_no_white_space, "-", "") ' Delete dash

        For search_row = 1 To total_row
            array_no_white_space = Replace(data_from_excel(search_row, 2), "/", "_Or_")
            array_no_white_space = Replace(array_no_white_space, "\", "_Or_")
            array_no_white_space = Replace(array_no_white_space, " ", "")
            array_no_white_space = Replace(array_no_white_space, "_", "") ' Delete underscore
            array_no_white_space = Replace(array_no_white_space, "-", "") ' Delete delete dash
            'MsgBox("Array no white space = " & array_no_white_space)
            'MsgBox("New Name no white space = " & new_name_no_white_space)

            If (new_name_no_white_space = array_no_white_space) Then
                Excel_Worksheet.Cells(search_row, 4) = "X"
                Excel_Workbook.Save()
                MessageBox.Show("Check List File has been updated: " & vbLf & vbLf & " Row Number ---> " & search_row)
                Exit For
            End If
        Next search_row
    End Sub

    Private Sub COPY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COPY.Click
        SuperCOPY()
    End Sub

    Private Sub txtDestinationFolder_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDestinationFolder.TextChanged

    End Sub

    Private Sub txtSiteName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSiteName.TextChanged

    End Sub


    Private Sub Populate_Alpha()
        lstFileNames.Items.Clear()
        lstFileNames.Items.Add("001_" & txtSiteID.Text & "_Alpha_tower ")
        lstFileNames.Items.Add("002_" & txtSiteID.Text & "_Alpha_ant")
        lstFileNames.Items.Add("003_" & txtSiteID.Text & "_Alpha_LOS")
        lstFileNames.Items.Add("004_" & txtSiteID.Text & "_ Alpha_ant_front")
        lstFileNames.Items.Add("005_" & txtSiteID.Text & "_Alpha_ant_w/connector")
        lstFileNames.Items.Add("006_" & txtSiteID.Text & "_Alpha_ant Model/ Serial Number")
        lstFileNames.Items.Add("007_" & txtSiteID.Text & "_Alpha_RCU")
        lstFileNames.Items.Add("008_" & txtSiteID.Text & "_Alpha_RCU Model / Serial Number")
        lstFileNames.Items.Add("009_" & txtSiteID.Text & "_Alpha_mech_DT")
        lstFileNames.Items.Add("010_" & txtSiteID.Text & "_Alpha_top_jumper")
        lstFileNames.Items.Add("011_" & txtSiteID.Text & "_Alpha_TMA")
        lstFileNames.Items.Add("012_" & txtSiteID.Text & "_Alpha_TMA_grounding")
        lstFileNames.Items.Add("013_" & txtSiteID.Text & "_Alpha_top_diplexer")
        lstFileNames.Items.Add("014_" & txtSiteID.Text & "_Alpha_diplexer_ground")
        lstFileNames.Items.Add("015_" & txtSiteID.Text & "_Alpha_hard_line")
        lstFileNames.Items.Add("016_" & txtSiteID.Text & "_Alpha_top_buss_bar")
        lstFileNames.Items.Add("017_" & txtSiteID.Text & "_Alpha_RET_coax_ground")
        lstFileNames.Items.Add("018_" & txtSiteID.Text & "_Alpha_RET_ground lead")
        lstFileNames.Items.Add("019_" & txtSiteID.Text & "_Alpha_top_coax_grounds")
    End Sub
    Private Sub Populate_Beta()
        lstFileNames.Items.Clear()
        lstFileNames.Items.Add("020_" & txtSiteID.Text & "_Beta_tower")
        lstFileNames.Items.Add("021_" & txtSiteID.Text & "_Beta_ant")
        lstFileNames.Items.Add("022_" & txtSiteID.Text & "_Beta_LOS")
        lstFileNames.Items.Add("023_" & txtSiteID.Text & "_ Beta_ant_front")
        lstFileNames.Items.Add("024_" & txtSiteID.Text & "_Beta_ant_w/connector")
        lstFileNames.Items.Add("025_" & txtSiteID.Text & "_Beta_ant Model/ Serial Number")
        lstFileNames.Items.Add("026_" & txtSiteID.Text & "_Beta_RCU")
        lstFileNames.Items.Add("027_" & txtSiteID.Text & "_Beta_RCU Model / Serial Number")
        lstFileNames.Items.Add("028_" & txtSiteID.Text & "_Beta_mech_DT")
        lstFileNames.Items.Add("029_" & txtSiteID.Text & "_Beta_top_jumper")
        lstFileNames.Items.Add("030_" & txtSiteID.Text & "_Beta_TMA")
        lstFileNames.Items.Add("031_" & txtSiteID.Text & "_Beta_TMA_grounding")
        lstFileNames.Items.Add("032_" & txtSiteID.Text & "_Beta_top_diplexer")
        lstFileNames.Items.Add("033_" & txtSiteID.Text & "_Beta_diplexer_ground")
        lstFileNames.Items.Add("034_" & txtSiteID.Text & "_Beta_hard_line")
        lstFileNames.Items.Add("035_" & txtSiteID.Text & "_Beta_top_buss_bar")
        lstFileNames.Items.Add("036_" & txtSiteID.Text & "_Beta_RET_coax_ground")
        lstFileNames.Items.Add("037_" & txtSiteID.Text & "_Beta_RET_ground lead")
        lstFileNames.Items.Add("038_" & txtSiteID.Text & "_Beta_top_coax_grounds")
    End Sub
    Private Sub Populate_Charlie()
        lstFileNames.Items.Clear()
        lstFileNames.Items.Add("039_" & txtSiteID.Text & "_Charlie_tower")
        lstFileNames.Items.Add("040_" & txtSiteID.Text & "_Charlie_ant")
        lstFileNames.Items.Add("041_" & txtSiteID.Text & "_Charlie_LOS")
        lstFileNames.Items.Add("042_" & txtSiteID.Text & "_ Charlie_ant_front")
        lstFileNames.Items.Add("043_" & txtSiteID.Text & "_Charlie_ant_w/connector")
        lstFileNames.Items.Add("044_" & txtSiteID.Text & "_Charlie_ant Model/ Serial Number")
        lstFileNames.Items.Add("045_" & txtSiteID.Text & "_Charlie_RCU")
        lstFileNames.Items.Add("046_" & txtSiteID.Text & "_Charlie_RCU Model / Serial Number")
        lstFileNames.Items.Add("047_" & txtSiteID.Text & "_Charlie_mech_DT")
        lstFileNames.Items.Add("048_" & txtSiteID.Text & "_Charlie_top_jumper")
        lstFileNames.Items.Add("049_" & txtSiteID.Text & "_Charlie_TMA")
        lstFileNames.Items.Add("050_" & txtSiteID.Text & "_Charlie_TMA_grounding")
        lstFileNames.Items.Add("051_" & txtSiteID.Text & "_Charlie_top_diplexer")
        lstFileNames.Items.Add("052_" & txtSiteID.Text & "_Charlie_diplexer_ground")
        lstFileNames.Items.Add("053_" & txtSiteID.Text & "_Charlie_hard_line")
        lstFileNames.Items.Add("054_" & txtSiteID.Text & "_Charlie_top_buss_bar")
        lstFileNames.Items.Add("055_" & txtSiteID.Text & "_Charlie_RET_coax_ground")
        lstFileNames.Items.Add("056_" & txtSiteID.Text & "_Charlie_RET_ground lead")
        lstFileNames.Items.Add("057_" & txtSiteID.Text & "_Charlie_top_coax_grounds")

    End Sub

    Private Sub Populate_Delta()
        lstFileNames.Items.Clear()
        lstFileNames.Items.Add("1001_" & txtSiteID.Text & "_Delta_tower")
        lstFileNames.Items.Add("1002_" & txtSiteID.Text & "_Delta_ant")
        lstFileNames.Items.Add("1003_" & txtSiteID.Text & "_Delta_LOS")
        lstFileNames.Items.Add("1004_" & txtSiteID.Text & "_ Delta_ant_front")
        lstFileNames.Items.Add("1005_" & txtSiteID.Text & "_Delta_ant_w/connector")
        lstFileNames.Items.Add("1006_" & txtSiteID.Text & "_Delta_ant Model/ Serial Number")
        lstFileNames.Items.Add("1007_" & txtSiteID.Text & "_Delta_RCU")
        lstFileNames.Items.Add("1008_" & txtSiteID.Text & "_Delta_RCU Model / Serial Number")
        lstFileNames.Items.Add("1009_" & txtSiteID.Text & "_Delta_mech_DT")
        lstFileNames.Items.Add("1010_" & txtSiteID.Text & "_Delta_top_jumper")
        lstFileNames.Items.Add("1011_" & txtSiteID.Text & "_Delta_TMA")
        lstFileNames.Items.Add("1012_" & txtSiteID.Text & "_Delta_TMA_grounding")
        lstFileNames.Items.Add("1013_" & txtSiteID.Text & "_Delta_top_diplexer")
        lstFileNames.Items.Add("1014_" & txtSiteID.Text & "_Delta_diplexer_ground")
        lstFileNames.Items.Add("1015_" & txtSiteID.Text & "_Delta_hard_line")
        lstFileNames.Items.Add("1016_" & txtSiteID.Text & "_Delta_top_buss_bar")
        lstFileNames.Items.Add("1017_" & txtSiteID.Text & "_Delta_RET_coax_ground")
        lstFileNames.Items.Add("1018_" & txtSiteID.Text & "_Delta_RET_ground lead")
        lstFileNames.Items.Add("1019_" & txtSiteID.Text & "_Delta_top_coax_grounds")

    End Sub

    Private Sub Populate_Tower()
        lstFileNames.Items.Clear()
        lstFileNames.Items.Add("058_" & txtSiteID.Text & "_Top_hard_lines")
        lstFileNames.Items.Add("059_" & txtSiteID.Text & "_Middle_buss_bar")
        lstFileNames.Items.Add("060_" & txtSiteID.Text & "_Middle_coax grounds")
        lstFileNames.Items.Add("061_" & txtSiteID.Text & "_Bottom_buss_bar")
        lstFileNames.Items.Add("062_" & txtSiteID.Text & "_Bottom_coax_grounds")
        lstFileNames.Items.Add("063_" & txtSiteID.Text & "_Bottom_hard_lines")
        lstFileNames.Items.Add("064_" & txtSiteID.Text & "_Bottom_port_hole")

    End Sub

    Private Sub Populate_IceBridge()
        lstFileNames.Items.Clear()
        lstFileNames.Items.Add("065_" & txtSiteID.Text & "_Ice_bridge_from_tower")
        lstFileNames.Items.Add("066_" & txtSiteID.Text & "_GPS_antenna")
        lstFileNames.Items.Add("067_" & txtSiteID.Text & "_GPS_ant_ground_lead")
        lstFileNames.Items.Add("068_" & txtSiteID.Text & "_GPS_ground_lead")
        lstFileNames.Items.Add("069_" & txtSiteID.Text & "_CN00001_Ice_bridge_to_tower")
        lstFileNames.Items.Add("070_" & txtSiteID.Text & "_A_RET_coax_ground")
        lstFileNames.Items.Add("071_" & txtSiteID.Text & "_B_RET_coax_ground")
        lstFileNames.Items.Add("072_" & txtSiteID.Text & "_G_RET_coax_ground")
        lstFileNames.Items.Add("073_" & txtSiteID.Text & "_RET_ ground_leads")
        lstFileNames.Items.Add("074_" & txtSiteID.Text & "_A_LPD")
        lstFileNames.Items.Add("075_" & txtSiteID.Text & "_B_LPD")
        lstFileNames.Items.Add("076_" & txtSiteID.Text & "_G_LPD")
        lstFileNames.Items.Add("077_" & txtSiteID.Text & "_LPD_buss_bar")

    End Sub

    Private Sub Populate_RoofTop()
        lstFileNames.Items.Clear()
        lstFileNames.Items.Add("078_" & txtSiteID.Text & "_ Cable_tray_1")
        lstFileNames.Items.Add("079_" & txtSiteID.Text & "_Cable_tray_2")
        lstFileNames.Items.Add("080_" & txtSiteID.Text & "_ BTS_frame")
        lstFileNames.Items.Add("081_" & txtSiteID.Text & "_Jumpers")
        lstFileNames.Items.Add("082_" & txtSiteID.Text & "_Parapet_port")
        lstFileNames.Items.Add("083_" & txtSiteID.Text & "_Ceiling_1")
        lstFileNames.Items.Add("084_" & txtSiteID.Text & "_Ceiling_2")
        lstFileNames.Items.Add("085_" & txtSiteID.Text & "_Ceiling_3")

    End Sub

    Private Sub Populate_Shelter()
        lstFileNames.Items.Clear()
        lstFileNames.Items.Add("086_" & txtSiteID.Text & "_Ext_port_right_side")
        lstFileNames.Items.Add("087_" & txtSiteID.Text & "_Ext_port_left_side")
        lstFileNames.Items.Add("088_" & txtSiteID.Text & "_Ext_buss_bar")
        lstFileNames.Items.Add("089_" & txtSiteID.Text & "_Int_port_right_side")
        lstFileNames.Items.Add("090_" & txtSiteID.Text & "_Int_port_left_side")
        lstFileNames.Items.Add("091_" & txtSiteID.Text & "_Int_port_grounding")
        lstFileNames.Items.Add("092_" & txtSiteID.Text & "_Main_buss_bar_1")
        lstFileNames.Items.Add("093_" & txtSiteID.Text & "_Main_buss_bar_2")
        lstFileNames.Items.Add("094_" & txtSiteID.Text & "_Cable_rack")
        lstFileNames.Items.Add("095_" & txtSiteID.Text & "_Log_book")
        lstFileNames.Items.Add("096_" & txtSiteID.Text & "_From_door")
        lstFileNames.Items.Add("097_" & txtSiteID.Text & "_To_door")
        lstFileNames.Items.Add("098_" & txtSiteID.Text & "_Trash_can")
        lstFileNames.Items.Add("099_" & txtSiteID.Text & "_Area_under_tower")
        lstFileNames.Items.Add("100_" & txtSiteID.Text & "_Area_around_building")

    End Sub

    Private Sub Populate_OutDoorPad()
        lstFileNames.Items.Clear()
        lstFileNames.Items.Add("101_" & txtSiteID.Text & "_Pad_1")
        lstFileNames.Items.Add("102_" & txtSiteID.Text & "_Pad_2")
        lstFileNames.Items.Add("103_" & txtSiteID.Text & "_Pad_3")
        lstFileNames.Items.Add("104_" & txtSiteID.Text & "_H-Frame")
        lstFileNames.Items.Add("105_" & txtSiteID.Text & "_Elec_Brk")
        lstFileNames.Items.Add("106_" & txtSiteID.Text & " Panel_matrix")
        lstFileNames.Items.Add("107_" & txtSiteID.Text & "_Cable_tray_1")
        lstFileNames.Items.Add("108_" & txtSiteID.Text & "_Cable tray_2")
        lstFileNames.Items.Add("109_" & txtSiteID.Text & "_Buss_bar_1")
        lstFileNames.Items.Add("110_" & txtSiteID.Text & "_Buss_bar_2")

    End Sub

    Private Sub Populate_Equipment()
        lstFileNames.Items.Clear()
        lstFileNames.Items.Add("111_" & txtSiteID.Text & "_Diplexers")
        lstFileNames.Items.Add("112_" & txtSiteID.Text & "_Diplexers_grounding")
        lstFileNames.Items.Add("113_" & txtSiteID.Text & "_Rectifier")
        lstFileNames.Items.Add("114_" & txtSiteID.Text & "_Rectifier_bkts")
        lstFileNames.Items.Add("115_" & txtSiteID.Text & "_Batteries")
        lstFileNames.Items.Add("116_" & txtSiteID.Text & "_UMTS cabinet")
        lstFileNames.Items.Add("117_" & txtSiteID.Text & "_UMTS_jumpers_")
        lstFileNames.Items.Add("118_" & txtSiteID.Text & "_CCU_rack")
        lstFileNames.Items.Add("119_" & txtSiteID.Text & "_CCU_front")
        lstFileNames.Items.Add("120_" & txtSiteID.Text & "_CCU_power")
        lstFileNames.Items.Add("121_" & txtSiteID.Text & "_CCU_back")
        lstFileNames.Items.Add("122_" & txtSiteID.Text & "_CCU_ground_bar")

    End Sub
    Private Sub Populate_Access()
        lstFileNames.Items.Clear()
        lstFileNames.Items.Add("123_" & txtSiteID.Text & "_Access_to_site")
        lstFileNames.Items.Add("124_" & txtSiteID.Text & "_Access_from_site")
        lstFileNames.Items.Add("125_" & txtSiteID.Text & "_Door_Access")

    End Sub
    Private Sub Populate_Signage()
        lstFileNames.Items.Clear()
        lstFileNames.Items.Add("126_" & txtSiteID.Text & "_Site_Sign")
        lstFileNames.Items.Add("127_" & txtSiteID.Text & "_Tower_ID")
        lstFileNames.Items.Add("128_" & txtSiteID.Text & "_ FCC_Sign")

    End Sub
    Private Sub Populate_EricssonQA()
        lstFileNames.Items.Clear()
        lstFileNames.Items.Add("129_" & txtSiteID.Text & "_QC_Checklist")
        lstFileNames.Items.Add("130_" & txtSiteID.Text & "_Cabinet_T1_Label")
        lstFileNames.Items.Add("131_" & txtSiteID.Text & "_NIU_T1_Label")
        lstFileNames.Items.Add("132_" & txtSiteID.Text & "_Cabinet_Base_Plate_Ground_Label")
        lstFileNames.Items.Add("133_" & txtSiteID.Text & "_Cabinet_Sub_Base_Plate_Ground_Label")
        lstFileNames.Items.Add("134_" & txtSiteID.Text & "_Cabinet_C-Tap_To_Main_Ground_Ring")
        lstFileNames.Items.Add("135_" & txtSiteID.Text & "_Cabinet_Battery_Strap")
        lstFileNames.Items.Add("136_" & txtSiteID.Text & "_Power_Breaker_Label")
        lstFileNames.Items.Add("137_" & txtSiteID.Text & "_Cabinet_AC_Power_To_ACCU_Label")
        lstFileNames.Items.Add("138_" & txtSiteID.Text & "_Cabinet_Jumper_To_RRU")
        lstFileNames.Items.Add("139_" & txtSiteID.Text & "_Cabinet_Overview")

    End Sub
    Private Sub ImageList_Load1()
        Dim i, j, k As Integer
        Dim pname As String
        Dim fname As String
        'Dim fname As String
        'Dim files As String() = Directory.GetFiles(File1.Path)
        Dim myImage As Image
        Dim listViewItem(3) As ListViewItem
        ListView1.LargeImageList = imageList1
        'Set the ColorDepth and ImageSize properties of imageList1.
        imageList1.TransparentColor = Color.Blue
        imageList1.ColorDepth = ColorDepth.Depth32Bit
        imageList1.ImageSize = New Size(190, 150)

        j = 0
        k = 0
        'Add images to imageList1.
        For i = 0 To AllFiles.Length - 1
            If AllFiles(i).Contains(".jpg") Or AllFiles(i).Contains(".JPG") Then
                pname = Path.GetFullPath(AllFiles(i))
                fname = Path.GetFileName(AllFiles(i))
                myImage = Image.FromFile(pname)
                imageList1.Images.Add(myImage)
                myImage.Dispose()
                'Dim listViewItem(k) As ListViewItem = New ListViewItem(fname, j)
                'Add listViewItem1 and listViewItem2.
                Dim listViewItemTmp As ListViewItem = New ListViewItem(fname, j)
                listViewItem(k) = listViewItemTmp
                'ListView1.Items.AddRange(New ListViewItem() {listViewItem(0), listViewItem(1), listViewItem(2)})
                j = j + 1
                'listViewItem(k) = Nothing
                k = k + 1
                myImage = Nothing
            End If
            If k = 3 Then
                ListView1.Items.AddRange(New ListViewItem() {listViewItem(0), listViewItem(1), listViewItem(2)})
                listViewItem(0) = Nothing
                listViewItem(1) = Nothing
                listViewItem(2) = Nothing
                k = 0
            End If
        Next
        If k > 0 Then ' Check for the last one or two images.
            For i = 0 To k - 1
                ListView1.Items.AddRange(New ListViewItem() {listViewItem(i)})
                listViewItem(i) = Nothing
            Next
        End If
        'pname = Nothing
    End Sub
    Private Sub ImageList_Load2()
        Dim i, j, k As Integer
        Dim pname As String
        Dim fname As String
        'Dim fname As String
        'Dim files As String() = Directory.GetFiles(File1.Path)
        Dim myImage As Image
        Dim listViewItem(3) As ListViewItem
        ListView2.LargeImageList = ImageList2
        'Set the ColorDepth and ImageSize properties of imageList1.
        ImageList2.TransparentColor = Color.Blue
        ImageList2.ColorDepth = ColorDepth.Depth32Bit
        ImageList2.ImageSize = New Size(100, 80)

        j = 0
        k = 0
        'Add images to imageList1.
        For i = 0 To AllFiles2.Length - 1
            If AllFiles2(i).Contains(".jpg") Or AllFiles2(i).Contains(".JPG") Then
                pname = Path.GetFullPath(AllFiles2(i))
                fname = Path.GetFileName(AllFiles2(i))
                myImage = Image.FromFile(pname)
                ImageList2.Images.Add(myImage)
                myImage.Dispose()
                'Dim listViewItem(k) As ListViewItem = New ListViewItem(fname, j)
                'Add listViewItem1 and listViewItem2.
                Dim listViewItemTmp As ListViewItem = New ListViewItem(fname, j)
                listViewItem(k) = listViewItemTmp
                'ListView1.Items.AddRange(New ListViewItem() {listViewItem(0), listViewItem(1), listViewItem(2)})
                j = j + 1
                'listViewItem(k) = Nothing
                k = k + 1
                myImage = Nothing
            End If
            If k = 3 Then
                ListView2.Items.AddRange(New ListViewItem() {listViewItem(0), listViewItem(1), listViewItem(2)})
                listViewItem(0) = Nothing
                listViewItem(1) = Nothing
                listViewItem(2) = Nothing
                k = 0
            End If
        Next
        If k > 0 Then ' Check for the last one or two images.
            For i = 0 To k - 1
                ListView2.Items.AddRange(New ListViewItem() {listViewItem(i)})
                listViewItem(i) = Nothing
            Next
        End If
        'pname = Nothing
    End Sub
    Private Sub ThumbnailView(ByVal ListView As Integer)
        If ListView = 1 Then
            thread1.Abort()
            imageList1.Images.Clear()
            ListView1.Items.Clear()
            thread1 = New System.Threading.Thread(AddressOf ImageList_Load1)
            thread1.Start()
        ElseIf ListView = 2 Then
            thread2.Abort()
            ImageList2.Images.Clear()
            ListView2.Items.Clear()
            thread2 = New System.Threading.Thread(AddressOf ImageList_Load2)
            thread2.Start()

        End If

    End Sub

    Private Sub CellSiteSoftMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If (open_excel = True) Then
            Excel_Workbook.Close()
            Excel_App.Quit()
            Excel_App = Nothing
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Dim i As Integer
        Dim listViewItem1 As ListViewItem
        Dim fname As String
        'Dim files As String() = Directory.GetFiles(File1.Path)

        fname = Nothing
        For i = 0 To ListView1.Items.Count - 1
            listViewItem1 = ListView1.Items.Item(i)
            If listViewItem1.Selected Then
                fname = listViewItem1.Text
                txtImageSelected.Text = fname
                i = ListView1.Items.Count + 1 'Exit the for loop, what happen to the keyword break?
            End If
        Next

        If fname <> Nothing Then  'If the file was found
            For i = 0 To AllFiles.Length - 1
                If AllFiles(i).Contains(fname) Then
                    image_full_path = Path.GetFullPath(AllFiles(i))
                    i = AllFiles.Length + 1 ' To exit for loop
                End If
            Next
        End If

    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Dim exec_string As String
        Dim windir As String
        windir = Environment.GetEnvironmentVariable("windir")
        exec_string = windir & "\system32\mspaint" & Chr(32) & Chr(34) & image_full_path & Chr(34)
        Shell(exec_string, vbMaximizedFocus)

    End Sub

    Private Sub Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browse.Click
        OpenFileDialog2.FileName = Nothing
        OpenFileDialog2.InitialDirectory = txtDestinationFolder.Text
        OpenFileDialog2.ShowDialog()
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem1.Click
        Dim AboutBoxForm As New frmAboutBox
        AboutBoxForm.Show()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        System.Diagnostics.Process.Start("http://www.trbsoft.com/support")
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        SuperCOPY()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim CustomerKeyForm As New frmCustomerKey
        CustomerKeyForm.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        SelectDestinationFolder()
    End Sub

    Private Sub OpenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem1.Click
        CheckListFileSelect()
    End Sub
End Class


