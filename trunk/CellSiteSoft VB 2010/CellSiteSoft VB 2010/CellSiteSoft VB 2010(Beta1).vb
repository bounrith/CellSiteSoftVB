Imports System
Imports System.IO

Public Class Form1

    Dim total_images As Integer = 0
    Dim image_loaded As Integer = 0
    Dim initial_load As Boolean = False
    Dim file_full_path As String()
    Dim box1_index As Integer = 0
    Dim box2_index As Integer = 0
    Dim box3_index As Integer = 0

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Drives.Text = "Selct a Drive"
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

    Public Sub LoadDir(ByVal DirPath As String, ByVal Node As Windows.Forms.TreeNode)
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
        MsgBox("Combo Box Selected Text = " & ComboBox_Drives.SelectedItem.ToString)
        LoadFolderTree(ComboBox_Drives.SelectedText)
    End Sub
    Public Sub Load_Drives()
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

    Public Sub DirectoryTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles DirectoryTreeView.AfterSelect
        Dim temp_image As Image
        Dim split1 As String()
        Dim split2 As String()
        Dim clean_path As String
        Dim number_of_split As Integer
        Dim split2_upper_bound As Integer
        'Dim imageList As New ImageList
        Dim AllFiles As String()
        
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
        imageList.ColorDepth = ColorDepth.Depth16Bit
        imageList.ImageSize = New Size(200, 200)

        total_images = 0
        ReDim file_full_path(AllFiles.Count) 'use a 1-D array to keep track of the file path
        For Each this_file In AllFiles
            split2 = Split(this_file, ".")
            split2_upper_bound = UBound(split2)

            '````````Building up Image List ```````````````````````````
            If (split2(split2_upper_bound) = "jpg" Or split2(split2_upper_bound) = "JPG") Then
                temp_image = Image.FromFile(this_file)
                file_full_path(total_images) = this_file.ToString ' Save image's full path
                imageList.Images.Add(temp_image)
                total_images = total_images + 1
            End If
        Next
        MsgBox("Total Images " & total_images)
        If (total_images > 1) Then
            PictureBox1.Image = imageList.Images.Item(0)
            box1_index = 0
            image_loaded = 1
        End If

        If (total_images > 2) Then
            PictureBox2.Image = imageList.Images.Item(1)
            box2_index = 1
            image_loaded = 2
        End If

        If (total_images > 3) Then
            PictureBox3.Image = imageList.Images.Item(2)
            box3_index = 2
            image_loaded = 3
        End If

    End Sub


    Private Sub Next_Picture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Next_Picture.Click
        Static img_number
        If (initial_load = False) Then
            img_number = image_loaded + 3
            initial_load = True
        End If

        
        '``````Add picture to first Box and reset counter if it equal or greater than number of picture
        If (img_number - 2) < total_images Then 'if count is less than MAX, display picture. 
            PictureBox1.Image = imageList.Images.Item(img_number - 2)
            box1_index = img_number - 2
        End If


        ' ````````Add picture to 2nd Box and reset counter if it equal or greater than number of picture
        If (img_number - 1) < total_images Then 'if count is less than MAX, display picture. 
            PictureBox2.Image = imageList.Images.Item(img_number - 1)
            box2_index = img_number - 1
        End If

        '`````Add picture to 3rd Box and reset counter if it equal or greater than number of picture
        If (img_number) < total_images Then
            PictureBox3.Image = imageList.Images.Item(img_number)
            box3_index = img_number
        End If


        '``````Reset the counter to start displaying images from the top of the list
        If (img_number >= total_images) Then 'if count Greater than or equal reset the counter
            img_number = 0
            initial_load = False
            image_loaded = -1 ' display image from position Array(0) ,img_number = image_loaded + 3, - First image
        Else
            img_number = img_number + 3
        End If

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        MsgBox("file_full_path = " & file_full_path(box1_index))
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        MsgBox("file_full_path = " & file_full_path(box2_index))
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        MsgBox("file_full_path = " & file_full_path(box3_index))
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

    Private Sub DestinationFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DestinationFolder.Click
        Dim AllFiles2 As String()
        Dim split_file2 As String()
        Dim no_path_index As Integer
        Try
            FolderBrowserDialog1.ShowDialog()
            DestinantionFolder.Text = FolderBrowserDialog1.SelectedPath.ToString
            AllFiles2 = Directory.GetFiles(DestinantionFolder.Text, "*.*", SearchOption.TopDirectoryOnly)

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

    Private Sub cmdFileSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFileSelect.Click
        Try
            OpenFileDialog1.ShowDialog()
            CheckListFile.Text = OpenFileDialog1.FileName
        Catch ex As Exception
            MsgBox("Can't locate file")
        End Try
    End Sub

    Private Sub lstFilesList2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstFilesList2.SelectedIndexChanged

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
End Class
