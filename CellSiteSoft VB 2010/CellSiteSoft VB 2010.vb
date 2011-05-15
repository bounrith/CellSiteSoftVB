Imports System
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Text.RegularExpressions ' For string replacement

Public Class CellSiteSoftMain
    Dim AllFiles As String()
    Dim total_files As Integer = 0
    Dim image_loaded As Integer = 0
    Dim initial_load As Boolean = False
    Dim file_full_path As String()
    Dim box1_index As Integer = 0
    Dim box2_index As Integer = 0
    Dim box3_index As Integer = 0
    Dim file_browse_index As Integer = 0
    Dim image_full_path As String

    Dim open_excel As Boolean = False
    Dim Excel_App As Excel.Application
    Dim Excel_Workbook As Excel.Workbook
    Dim Excel_Worksheet As Excel.Worksheet

    
    Private Sub CellSiteSoftMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Drives.Text = "Select a Drive"
        Load_Drives()
        Load_Category()
        FolderBrowserDialog1.SelectedPath = System.IO.Directory.GetCurrentDirectory()
        'SetEnabled()
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

    Private Sub ComboBox_Drives_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_Drives.SelectedIndexChanged
        MsgBox("Selected Drive: " & ComboBox_Drives.SelectedItem.ToString)
        'Threading.Thread.Sleep(5000) ' Wait for 5 seconds to browse the drive
        LoadFolderTree(ComboBox_Drives.SelectedText)
    End Sub

    'Changed from Public to Private
    Private Sub Load_Drives()
        Dim AllDrives() As DriveInfo = DriveInfo.GetDrives()
        Dim d As DriveInfo
        Dim drive_number As Integer = 0
        For Each d In AllDrives
            If My.Computer.FileSystem.Drives(drive_number).IsReady = True Then
                ComboBox_Drives.Items.Add(d.Name)
            End If

            drive_number = drive_number + 1
        Next
    End Sub

    ' Changed from Public to private
    Private Sub DirectoryTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles DirectoryTreeView.AfterSelect
        Dim temp_image As Image
        Dim split1 As String()
        Dim split2 As String()
        Dim clean_path As String
        Dim number_of_split As Integer
        Dim split2_upper_bound As Integer
        Dim number_of_images_built As Integer = 0

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

        imageList.TransparentColor = Color.Blue
        imageList.ColorDepth = ColorDepth.Depth32Bit
        imageList.ImageSize = New Size(190, 110)

        total_files = AllFiles.Count
        ReDim file_full_path(15) 'Keep Track of 15 images file paths

        '======================================================================================

        While ((number_of_images_built < 15) And (file_browse_index <= (total_files - 1)))
            split2 = Split(AllFiles(file_browse_index), ".")
            split2_upper_bound = UBound(split2)
            '````````Building up Image List ```````````````````````````
            If (split2(split2_upper_bound) = "jpg" Or split2(split2_upper_bound) = "JPG") Then
                temp_image = Image.FromFile(AllFiles(file_browse_index))
                file_full_path(number_of_images_built) = AllFiles(file_browse_index).ToString ' Save image's full path
                imageList.Images.Add(temp_image)
                number_of_images_built = number_of_images_built + 1
            End If
            file_browse_index = file_browse_index + 1
        End While


        '=======================================================================================

        'MsgBox("Total Files " & total_files)
        'MsgBox("Total Images " & imageList.Images.Count)
        If (number_of_images_built > 0) Then
            PictureBox1.Image = imageList.Images.Item(0)
        End If

        If (number_of_images_built > 1) Then
            PictureBox2.Image = imageList.Images.Item(1)
        End If

        If (number_of_images_built > 2) Then
            PictureBox3.Image = imageList.Images.Item(2)
        End If
        If (number_of_images_built > 3) Then
            PictureBox4.Image = imageList.Images.Item(3)
        End If

        If (number_of_images_built > 4) Then
            PictureBox5.Image = imageList.Images.Item(4)
        End If
        If (number_of_images_built > 5) Then
            PictureBox6.Image = imageList.Images.Item(5)
        End If

        If (number_of_images_built > 6) Then
            PictureBox7.Image = imageList.Images.Item(6)
        End If

        If (number_of_images_built > 7) Then
            PictureBox8.Image = imageList.Images.Item(7)
        End If
        If (number_of_images_built > 8) Then
            PictureBox9.Image = imageList.Images.Item(8)
        End If

        If (number_of_images_built > 9) Then
            PictureBox10.Image = imageList.Images.Item(9)
        End If

        If (number_of_images_built > 10) Then
            PictureBox11.Image = imageList.Images.Item(10)
        End If
        If (number_of_images_built > 11) Then
            PictureBox12.Image = imageList.Images.Item(11)
        End If

        If (number_of_images_built > 12) Then
            PictureBox13.Image = imageList.Images.Item(12)
        End If
        If (number_of_images_built > 13) Then
            PictureBox14.Image = imageList.Images.Item(13)
        End If

        If (number_of_images_built > 14) Then
            PictureBox15.Image = imageList.Images.Item(14)
        End If

        '========= Reset the number_of_images_built to empty or zero ===================
        number_of_images_built = 0
        imageList.Images.Clear()
        'MsgBox("Total Images " & imageList.Images.Count)
        If file_browse_index >= total_files Then
            file_browse_index = 0
            MsgBox("*** End OF List ***")
        End If

    End Sub


    Private Sub Next_Picture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Next_Picture.Click
        Dim split3 As String()
        Dim split3_upper_bound As Integer
        Dim temp2_image As Image
        Dim number_of_images_built2 As Integer = 0

        '====================================================================================================
        Try
            While ((number_of_images_built2 < 15) And (file_browse_index <= (total_files - 1)))
                split3 = Split(AllFiles(file_browse_index), ".")
                split3_upper_bound = UBound(split3)
                '````````Building up Image List ```````````````````````````
                If (split3(split3_upper_bound) = "jpg" Or split3(split3_upper_bound) = "JPG") Then
                    temp2_image = Image.FromFile(AllFiles(file_browse_index))
                    file_full_path(number_of_images_built2) = AllFiles(file_browse_index).ToString ' Save image's full path
                    imageList.Images.Add(temp2_image)
                    temp2_image.Dispose()
                    number_of_images_built2 = number_of_images_built2 + 1
                End If
                file_browse_index = file_browse_index + 1
            End While
        Catch ex As IndexOutOfRangeException
            MsgBox("Catch File Index = " & file_browse_index)
        End Try

        '=========================================================================================================
        MsgBox("Image List Count = " & imageList.Images.Count)

        If (number_of_images_built2 > 0) Then
            PictureBox1.Image = imageList.Images.Item(0)
        End If

        If (number_of_images_built2 > 1) Then
            PictureBox2.Image = imageList.Images.Item(1)
        End If

        If (number_of_images_built2 > 2) Then
            PictureBox3.Image = imageList.Images.Item(2)
        End If
        If (number_of_images_built2 > 3) Then
            PictureBox4.Image = imageList.Images.Item(3)
        End If

        If (number_of_images_built2 > 4) Then
            PictureBox5.Image = imageList.Images.Item(4)
        End If
        If (number_of_images_built2 > 5) Then
            PictureBox6.Image = imageList.Images.Item(5)
        End If

        If (number_of_images_built2 > 6) Then
            PictureBox7.Image = imageList.Images.Item(6)
        End If

        If (number_of_images_built2 > 7) Then
            PictureBox8.Image = imageList.Images.Item(7)
        End If
        If (number_of_images_built2 > 8) Then
            PictureBox9.Image = imageList.Images.Item(8)
        End If

        If (number_of_images_built2 > 9) Then
            PictureBox10.Image = imageList.Images.Item(9)
        End If

        If (number_of_images_built2 > 10) Then
            PictureBox11.Image = imageList.Images.Item(10)
        End If
        If (number_of_images_built2 > 11) Then
            PictureBox12.Image = imageList.Images.Item(11)
        End If

        If (number_of_images_built2 > 12) Then
            PictureBox13.Image = imageList.Images.Item(12)
        End If
        If (number_of_images_built2 > 13) Then
            PictureBox14.Image = imageList.Images.Item(13)
        End If

        If (number_of_images_built2 > 14) Then
            PictureBox15.Image = imageList.Images.Item(14)
        End If
        '=============== Reset number_of_images_built2 to empty or zero ============================================

        number_of_images_built2 = 0
        imageList.Images.Clear()

        MsgBox("Image List Count = " & imageList.Images.Count)

        If file_browse_index >= total_files Then
            file_browse_index = 0
            MsgBox("*** End Of LIST ***")
        End If

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        MsgBox("Image 1 Selected")
        image_full_path = file_full_path(0)
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        MsgBox("Image 2 Selected")
        image_full_path = file_full_path(1)
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        MsgBox("Image 3 Selected")
        image_full_path = file_full_path(2)
    End Sub
    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        MsgBox("Image 4 Selected")
        image_full_path = file_full_path(3)
    End Sub
    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        MsgBox("Image 5 Selected")
        image_full_path = file_full_path(4)
    End Sub
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        MsgBox("Image 6 Selected")
        image_full_path = file_full_path(5)
    End Sub
    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        MsgBox("Image 7 Selected")
        image_full_path = file_full_path(6)
    End Sub
    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        MsgBox("Image 8 Selected")
        image_full_path = file_full_path(7)
    End Sub
    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.Click
        MsgBox("Image 9 Selected")
        image_full_path = file_full_path(8)
    End Sub
    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.Click
        MsgBox("Image 10 Selected")
        image_full_path = file_full_path(9)
    End Sub
    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.Click
        MsgBox("Image 11 Selected")
        image_full_path = file_full_path(10)
    End Sub
    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox12.Click
        MsgBox("Image 12 Selected")
        image_full_path = file_full_path(11)
    End Sub
    Private Sub PictureBox13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox13.Click
        MsgBox("Image 13 Selected")
        image_full_path = file_full_path(12)
    End Sub
    Private Sub PictureBox14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox14.Click
        MsgBox("Image 14 Selected")
        image_full_path = file_full_path(13)
    End Sub
    Private Sub PictureBox15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox15.Click
        MsgBox("Image 15 Selected")
        image_full_path = file_full_path(14)
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



    Private Sub cmdFileSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFileSelect.Click
        Try
            OpenFileDialog1.ShowDialog()
            CheckListFile.Text = OpenFileDialog1.FileName
        Catch ex As Exception
            MsgBox("Can't locate file")
        End Try
        MsgBox("Check List File = " & CheckListFile.Text)
        MsgBox("Check List File To String = " & CheckListFile.Text.ToString)
    End Sub
    Private Sub DestinationFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DestinationFolder.Click
        Dim AllFiles2 As String()
        Dim split_file2 As String()
        Dim no_path_index As Integer
        Try
            FolderBrowserDialog1.ShowDialog()
            txtDestinationFolder.Text = FolderBrowserDialog1.SelectedPath.ToString
            AllFiles2 = Directory.GetFiles(txtDestinationFolder.Text, "*.*", SearchOption.TopDirectoryOnly)

            lstFilesList2.Items.Clear()
            For Each File In AllFiles2
                split_file2 = Split(File.ToString, "\")
                no_path_index = UBound(split_file2)
                lstFilesList2.Items.Add(split_file2(no_path_index)) 'Ommit the path and Add file name only
            Next
        Catch ex As Exception
            MsgBox("Can not select this folder")
        End Try
    End Sub
    Private Sub lstFilesList2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstFilesList2.SelectedIndexChanged

    End Sub
    Private Sub COPY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COPY.Click

        Dim new_name_no_white_space As String
        Dim destionation_path_and_file As String
        Dim refresh_files As String()
        Dim split_refresh As String()
        Dim strip_path_index As Integer
        Dim total_row As Integer
        Dim data_from_excel As String(,) 'two dimensional array
        Dim check_list_file_name As String
        Dim array_no_white_space As String
        Dim row_index As Integer
        Dim column_index As Integer
        Dim column1_data As String
        Dim column4_data As String

        new_name_no_white_space = Replace(lstFileNames.SelectedItem.ToString, "/", "_Or_") ' Replace "/" with "_Or_"
        new_name_no_white_space = Replace(new_name_no_white_space, "\", "_Or_") ' Replace "\" with "_Or_"
        new_name_no_white_space = Replace(new_name_no_white_space, " ", "") ' Replace SPACE with nothing, delete space

        destionation_path_and_file = txtDestinationFolder.Text & "\" & new_name_no_white_space & ".jpg"

        check_list_file_name = CheckListFile.Text
        FileCopy(image_full_path, destionation_path_and_file)

        refresh_files = Directory.GetFiles(txtDestinationFolder.Text, "*.*", SearchOption.TopDirectoryOnly)

        lstFilesList2.Items.Clear()

        For Each refresh_file In refresh_files
            split_refresh = Split(refresh_file.ToString, "\")
            strip_path_index = UBound(split_refresh)
            lstFilesList2.Items.Add(split_refresh(strip_path_index)) 'Omit the path and Add file name only
        Next

        If (open_excel = False) Then
            Excel_App = New Excel.Application
            Excel_Workbook = Excel_App.Workbooks.Open(check_list_file_name)
            Excel_Worksheet = Excel_Workbook.Sheets("Sheet1")
            open_excel = True
        End If

        Excel_Worksheet.Cells(3, 2) = "SITE NAME:" & Chr(32) & txtSiteName.Text
        Excel_Worksheet.Cells(4, 2) = "SITE NAME:" & Chr(32) & txtSiteID.Text

        total_row = Excel_Worksheet.UsedRange.Rows.Count
        MsgBox("Total Row = " & total_row)

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

        For search_row = 1 To total_row
            array_no_white_space = Replace(data_from_excel(search_row, 2), "/", "_Or_")
            array_no_white_space = Replace(array_no_white_space, "\", "_Or_")
            array_no_white_space = Replace(array_no_white_space, " ", "")
            'MsgBox("Array no white space = " & array_no_white_space)
            'MsgBox("New Name no white space = " & new_name_no_white_space)

            If (new_name_no_white_space = array_no_white_space) Then
                MsgBox("Updating Excel file: Row Number ===> " & search_row)
                Excel_Worksheet.Cells(search_row, 4) = "X"
                Excel_Workbook.Save()
                Exit For
            End If
        Next search_row

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
        lstFileNames.Items.Add("05_" & txtSiteID.Text & "_Alpha_ant_w/connector")
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

    Private Sub CellSiteSoftMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If (open_excel = True) Then
            Excel_Workbook.Close()
            Excel_App.Quit()
            Excel_App = Nothing
        End If
    End Sub

End Class


