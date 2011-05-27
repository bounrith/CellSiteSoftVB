<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CellSiteSoftMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DirectoryTreeView = New System.Windows.Forms.TreeView()
        Me.ComboBox_Drives = New System.Windows.Forms.ComboBox()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.lstFileNames = New System.Windows.Forms.ListBox()
        Me.cmdCategory = New System.Windows.Forms.ComboBox()
        Me.txtSiteName = New System.Windows.Forms.TextBox()
        Me.txtSiteID = New System.Windows.Forms.TextBox()
        Me.lblSiteName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdFileSelect = New System.Windows.Forms.Button()
        Me.CheckListFile = New System.Windows.Forms.TextBox()
        Me.DestinationFolder = New System.Windows.Forms.Button()
        Me.txtDestinationFolder = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.COPY = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Browse = New System.Windows.Forms.Button()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'DirectoryTreeView
        '
        Me.DirectoryTreeView.Location = New System.Drawing.Point(14, 50)
        Me.DirectoryTreeView.Name = "DirectoryTreeView"
        Me.DirectoryTreeView.Size = New System.Drawing.Size(210, 507)
        Me.DirectoryTreeView.TabIndex = 0
        '
        'ComboBox_Drives
        '
        Me.ComboBox_Drives.FormattingEnabled = True
        Me.ComboBox_Drives.Location = New System.Drawing.Point(14, 26)
        Me.ComboBox_Drives.Name = "ComboBox_Drives"
        Me.ComboBox_Drives.Size = New System.Drawing.Size(210, 21)
        Me.ComboBox_Drives.TabIndex = 1
        '
        'imageList1
        '
        Me.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit
        Me.imageList1.ImageSize = New System.Drawing.Size(32, 32)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'lstFileNames
        '
        Me.lstFileNames.FormattingEnabled = True
        Me.lstFileNames.Location = New System.Drawing.Point(18, 72)
        Me.lstFileNames.Name = "lstFileNames"
        Me.lstFileNames.Size = New System.Drawing.Size(246, 485)
        Me.lstFileNames.TabIndex = 10
        '
        'cmdCategory
        '
        Me.cmdCategory.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCategory.FormattingEnabled = True
        Me.cmdCategory.Location = New System.Drawing.Point(18, 27)
        Me.cmdCategory.Name = "cmdCategory"
        Me.cmdCategory.Size = New System.Drawing.Size(211, 28)
        Me.cmdCategory.TabIndex = 11
        Me.cmdCategory.Text = "Select Category"
        '
        'txtSiteName
        '
        Me.txtSiteName.Location = New System.Drawing.Point(203, 59)
        Me.txtSiteName.Name = "txtSiteName"
        Me.txtSiteName.Size = New System.Drawing.Size(146, 20)
        Me.txtSiteName.TabIndex = 12
        '
        'txtSiteID
        '
        Me.txtSiteID.Location = New System.Drawing.Point(437, 61)
        Me.txtSiteID.Name = "txtSiteID"
        Me.txtSiteID.Size = New System.Drawing.Size(135, 20)
        Me.txtSiteID.TabIndex = 13
        '
        'lblSiteName
        '
        Me.lblSiteName.AutoSize = True
        Me.lblSiteName.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSiteName.Location = New System.Drawing.Point(121, 58)
        Me.lblSiteName.Name = "lblSiteName"
        Me.lblSiteName.Size = New System.Drawing.Size(76, 20)
        Me.lblSiteName.TabIndex = 15
        Me.lblSiteName.Text = "Site Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(377, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 20)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Site ID:"
        '
        'cmdFileSelect
        '
        Me.cmdFileSelect.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdFileSelect.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFileSelect.ForeColor = System.Drawing.Color.Black
        Me.cmdFileSelect.Location = New System.Drawing.Point(601, 55)
        Me.cmdFileSelect.Name = "cmdFileSelect"
        Me.cmdFileSelect.Size = New System.Drawing.Size(170, 25)
        Me.cmdFileSelect.TabIndex = 18
        Me.cmdFileSelect.Text = "select Check List file ..."
        Me.cmdFileSelect.UseVisualStyleBackColor = False
        '
        'CheckListFile
        '
        Me.CheckListFile.Location = New System.Drawing.Point(777, 58)
        Me.CheckListFile.Name = "CheckListFile"
        Me.CheckListFile.Size = New System.Drawing.Size(235, 20)
        Me.CheckListFile.TabIndex = 19
        '
        'DestinationFolder
        '
        Me.DestinationFolder.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DestinationFolder.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DestinationFolder.Location = New System.Drawing.Point(0, 30)
        Me.DestinationFolder.Name = "DestinationFolder"
        Me.DestinationFolder.Size = New System.Drawing.Size(222, 25)
        Me.DestinationFolder.TabIndex = 20
        Me.DestinationFolder.Text = "select COPY To folder ..."
        Me.DestinationFolder.UseVisualStyleBackColor = False
        '
        'txtDestinationFolder
        '
        Me.txtDestinationFolder.Location = New System.Drawing.Point(6, 61)
        Me.txtDestinationFolder.Name = "txtDestinationFolder"
        Me.txtDestinationFolder.Size = New System.Drawing.Size(216, 20)
        Me.txtDestinationFolder.TabIndex = 21
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'COPY
        '
        Me.COPY.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.COPY.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COPY.Location = New System.Drawing.Point(11, 526)
        Me.COPY.Name = "COPY"
        Me.COPY.Size = New System.Drawing.Size(211, 32)
        Me.COPY.TabIndex = 23
        Me.COPY.Text = "COPY"
        Me.COPY.UseVisualStyleBackColor = False
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(228, 26)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(2)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(311, 531)
        Me.ListView1.TabIndex = 24
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdCategory)
        Me.GroupBox1.Controls.Add(Me.lstFileNames)
        Me.GroupBox1.Location = New System.Drawing.Point(601, 110)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(270, 564)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ListView1)
        Me.GroupBox2.Controls.Add(Me.ComboBox_Drives)
        Me.GroupBox2.Controls.Add(Me.DirectoryTreeView)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 110)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(568, 564)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ListView2)
        Me.GroupBox3.Controls.Add(Me.COPY)
        Me.GroupBox3.Controls.Add(Me.txtDestinationFolder)
        Me.GroupBox3.Controls.Add(Me.DestinationFolder)
        Me.GroupBox3.Location = New System.Drawing.Point(888, 110)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(255, 564)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        '
        'ListView2
        '
        Me.ListView2.Location = New System.Drawing.Point(5, 98)
        Me.ListView2.Margin = New System.Windows.Forms.Padding(2)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(232, 425)
        Me.ListView2.TabIndex = 31
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(432, -1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(305, 29)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Field Photo Management"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(492, 690)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(205, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "© 2011 TRB Software. All rights reserved."
        '
        'ImageList2
        '
        Me.ImageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit
        Me.ImageList2.ImageSize = New System.Drawing.Size(32, 32)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        '
        'Browse
        '
        Me.Browse.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Browse.Location = New System.Drawing.Point(1029, 3)
        Me.Browse.Name = "Browse"
        Me.Browse.Size = New System.Drawing.Size(124, 29)
        Me.Browse.TabIndex = 31
        Me.Browse.Text = "Modify File/Folder"
        Me.Browse.UseVisualStyleBackColor = True
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog2"
        '
        'CellSiteSoftMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.ClientSize = New System.Drawing.Size(1156, 705)
        Me.Controls.Add(Me.Browse)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CheckListFile)
        Me.Controls.Add(Me.cmdFileSelect)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblSiteName)
        Me.Controls.Add(Me.txtSiteID)
        Me.Controls.Add(Me.txtSiteName)
        Me.Name = "CellSiteSoftMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TRB Software - Field Photo Management v0.1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DirectoryTreeView As System.Windows.Forms.TreeView
    Friend WithEvents ComboBox_Drives As System.Windows.Forms.ComboBox
    Friend WithEvents lstFileNames As System.Windows.Forms.ListBox
    Friend WithEvents cmdCategory As System.Windows.Forms.ComboBox
    Friend WithEvents txtSiteName As System.Windows.Forms.TextBox
    Friend WithEvents txtSiteID As System.Windows.Forms.TextBox
    Friend WithEvents lblSiteName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdFileSelect As System.Windows.Forms.Button
    Friend WithEvents CheckListFile As System.Windows.Forms.TextBox
    Friend WithEvents DestinationFolder As System.Windows.Forms.Button
    Friend WithEvents txtDestinationFolder As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Public WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents COPY As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents Browse As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog

End Class
