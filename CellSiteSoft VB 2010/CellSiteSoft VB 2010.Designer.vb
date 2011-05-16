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
        Me.imageList = New System.Windows.Forms.ImageList(Me.components)
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
        Me.lstFilesList2 = New System.Windows.Forms.ListBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.COPY = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'DirectoryTreeView
        '
        Me.DirectoryTreeView.Location = New System.Drawing.Point(14, 50)
        Me.DirectoryTreeView.Name = "DirectoryTreeView"
        Me.DirectoryTreeView.Size = New System.Drawing.Size(210, 520)
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
        'imageList
        '
        Me.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit
        Me.imageList.ImageSize = New System.Drawing.Size(32, 32)
        Me.imageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'lstFileNames
        '
        Me.lstFileNames.FormattingEnabled = True
        Me.lstFileNames.Location = New System.Drawing.Point(18, 72)
        Me.lstFileNames.Name = "lstFileNames"
        Me.lstFileNames.Size = New System.Drawing.Size(211, 498)
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
        Me.txtSiteName.Location = New System.Drawing.Point(226, 71)
        Me.txtSiteName.Name = "txtSiteName"
        Me.txtSiteName.Size = New System.Drawing.Size(136, 20)
        Me.txtSiteName.TabIndex = 12
        '
        'txtSiteID
        '
        Me.txtSiteID.Location = New System.Drawing.Point(437, 73)
        Me.txtSiteID.Name = "txtSiteID"
        Me.txtSiteID.Size = New System.Drawing.Size(150, 20)
        Me.txtSiteID.TabIndex = 13
        '
        'lblSiteName
        '
        Me.lblSiteName.AutoSize = True
        Me.lblSiteName.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSiteName.Location = New System.Drawing.Point(144, 71)
        Me.lblSiteName.Name = "lblSiteName"
        Me.lblSiteName.Size = New System.Drawing.Size(76, 20)
        Me.lblSiteName.TabIndex = 15
        Me.lblSiteName.Text = "Site Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(377, 71)
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
        Me.cmdFileSelect.Location = New System.Drawing.Point(918, 66)
        Me.cmdFileSelect.Name = "cmdFileSelect"
        Me.cmdFileSelect.Size = New System.Drawing.Size(76, 25)
        Me.cmdFileSelect.TabIndex = 18
        Me.cmdFileSelect.Text = "SELECT..."
        Me.cmdFileSelect.UseVisualStyleBackColor = False
        '
        'CheckListFile
        '
        Me.CheckListFile.Location = New System.Drawing.Point(753, 71)
        Me.CheckListFile.Name = "CheckListFile"
        Me.CheckListFile.Size = New System.Drawing.Size(163, 20)
        Me.CheckListFile.TabIndex = 19
        '
        'DestinationFolder
        '
        Me.DestinationFolder.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DestinationFolder.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DestinationFolder.Location = New System.Drawing.Point(11, 30)
        Me.DestinationFolder.Name = "DestinationFolder"
        Me.DestinationFolder.Size = New System.Drawing.Size(254, 25)
        Me.DestinationFolder.TabIndex = 20
        Me.DestinationFolder.Text = "SAVE TO..."
        Me.DestinationFolder.UseVisualStyleBackColor = False
        '
        'txtDestinationFolder
        '
        Me.txtDestinationFolder.Location = New System.Drawing.Point(11, 73)
        Me.txtDestinationFolder.Name = "txtDestinationFolder"
        Me.txtDestinationFolder.Size = New System.Drawing.Size(254, 20)
        Me.txtDestinationFolder.TabIndex = 21
        '
        'lstFilesList2
        '
        Me.lstFilesList2.FormattingEnabled = True
        Me.lstFilesList2.Location = New System.Drawing.Point(11, 99)
        Me.lstFilesList2.Name = "lstFilesList2"
        Me.lstFilesList2.Size = New System.Drawing.Size(254, 433)
        Me.lstFilesList2.TabIndex = 22
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'COPY
        '
        Me.COPY.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.COPY.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COPY.Location = New System.Drawing.Point(30, 538)
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
        Me.ListView1.Size = New System.Drawing.Size(389, 544)
        Me.ListView1.TabIndex = 24
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(616, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 20)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Checklist Template:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdCategory)
        Me.GroupBox1.Controls.Add(Me.lstFileNames)
        Me.GroupBox1.Location = New System.Drawing.Point(649, 110)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(242, 592)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Category"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ListView1)
        Me.GroupBox2.Controls.Add(Me.ComboBox_Drives)
        Me.GroupBox2.Controls.Add(Me.DirectoryTreeView)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 110)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(633, 592)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Source"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.COPY)
        Me.GroupBox3.Controls.Add(Me.lstFilesList2)
        Me.GroupBox3.Controls.Add(Me.txtDestinationFolder)
        Me.GroupBox3.Controls.Add(Me.DestinationFolder)
        Me.GroupBox3.Location = New System.Drawing.Point(901, 110)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(276, 592)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Destination"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(442, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(305, 29)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Field Photo Management"
        '
        'CellSiteSoftMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 709)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
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
    Friend WithEvents lstFilesList2 As System.Windows.Forms.ListBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Public WithEvents imageList As System.Windows.Forms.ImageList
    Friend WithEvents COPY As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
