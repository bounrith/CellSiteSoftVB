<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Next_Picture = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lstFileNames = New System.Windows.Forms.ListBox()
        Me.cmdCategory = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtSiteID = New System.Windows.Forms.TextBox()
        Me.lblSiteName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdFileSelect = New System.Windows.Forms.Button()
        Me.CheckListFile = New System.Windows.Forms.TextBox()
        Me.DestinationFolder = New System.Windows.Forms.Button()
        Me.DestinantionFolder = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.lstFilesList2 = New System.Windows.Forms.ListBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DirectoryTreeView
        '
        Me.DirectoryTreeView.Location = New System.Drawing.Point(25, 74)
        Me.DirectoryTreeView.Name = "DirectoryTreeView"
        Me.DirectoryTreeView.Size = New System.Drawing.Size(210, 550)
        Me.DirectoryTreeView.TabIndex = 0
        '
        'ComboBox_Drives
        '
        Me.ComboBox_Drives.FormattingEnabled = True
        Me.ComboBox_Drives.Location = New System.Drawing.Point(25, 47)
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
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(240, 445)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(206, 181)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'Next_Picture
        '
        Me.Next_Picture.Location = New System.Drawing.Point(241, 47)
        Me.Next_Picture.Name = "Next_Picture"
        Me.Next_Picture.Size = New System.Drawing.Size(206, 25)
        Me.Next_Picture.TabIndex = 6
        Me.Next_Picture.Text = "Load Next 3 Pictures"
        Me.Next_Picture.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(241, 258)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(206, 181)
        Me.PictureBox2.TabIndex = 7
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Location = New System.Drawing.Point(241, 74)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(206, 181)
        Me.PictureBox3.TabIndex = 8
        Me.PictureBox3.TabStop = False
        '
        'lstFileNames
        '
        Me.lstFileNames.FormattingEnabled = True
        Me.lstFileNames.Location = New System.Drawing.Point(465, 74)
        Me.lstFileNames.Name = "lstFileNames"
        Me.lstFileNames.Size = New System.Drawing.Size(211, 550)
        Me.lstFileNames.TabIndex = 10
        '
        'cmdCategory
        '
        Me.cmdCategory.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCategory.FormattingEnabled = True
        Me.cmdCategory.Location = New System.Drawing.Point(465, 47)
        Me.cmdCategory.Name = "cmdCategory"
        Me.cmdCategory.Size = New System.Drawing.Size(211, 28)
        Me.cmdCategory.TabIndex = 11
        Me.cmdCategory.Text = "Select Category"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(99, 2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(136, 20)
        Me.TextBox1.TabIndex = 12
        '
        'txtSiteID
        '
        Me.txtSiteID.Location = New System.Drawing.Point(297, 2)
        Me.txtSiteID.Name = "txtSiteID"
        Me.txtSiteID.Size = New System.Drawing.Size(150, 20)
        Me.txtSiteID.TabIndex = 13
        '
        'lblSiteName
        '
        Me.lblSiteName.AutoSize = True
        Me.lblSiteName.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSiteName.Location = New System.Drawing.Point(21, 0)
        Me.lblSiteName.Name = "lblSiteName"
        Me.lblSiteName.Size = New System.Drawing.Size(76, 20)
        Me.lblSiteName.TabIndex = 15
        Me.lblSiteName.Text = "Site Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(237, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 20)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Site ID:"
        '
        'cmdFileSelect
        '
        Me.cmdFileSelect.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFileSelect.Location = New System.Drawing.Point(682, 50)
        Me.cmdFileSelect.Name = "cmdFileSelect"
        Me.cmdFileSelect.Size = New System.Drawing.Size(254, 25)
        Me.cmdFileSelect.TabIndex = 18
        Me.cmdFileSelect.Text = "SELECT check list file"
        Me.cmdFileSelect.UseVisualStyleBackColor = True
        '
        'CheckListFile
        '
        Me.CheckListFile.Location = New System.Drawing.Point(682, 74)
        Me.CheckListFile.Name = "CheckListFile"
        Me.CheckListFile.Size = New System.Drawing.Size(254, 20)
        Me.CheckListFile.TabIndex = 19
        '
        'DestinationFolder
        '
        Me.DestinationFolder.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DestinationFolder.Location = New System.Drawing.Point(682, 135)
        Me.DestinationFolder.Name = "DestinationFolder"
        Me.DestinationFolder.Size = New System.Drawing.Size(254, 25)
        Me.DestinationFolder.TabIndex = 20
        Me.DestinationFolder.Text = "SELECT destination folder"
        Me.DestinationFolder.UseVisualStyleBackColor = True
        '
        'DestinantionFolder
        '
        Me.DestinantionFolder.Location = New System.Drawing.Point(682, 157)
        Me.DestinantionFolder.Name = "DestinantionFolder"
        Me.DestinantionFolder.Size = New System.Drawing.Size(254, 20)
        Me.DestinantionFolder.TabIndex = 21
        '
        'lstFilesList2
        '
        Me.lstFilesList2.FormattingEnabled = True
        Me.lstFilesList2.Location = New System.Drawing.Point(685, 191)
        Me.lstFilesList2.Name = "lstFilesList2"
        Me.lstFilesList2.Size = New System.Drawing.Size(251, 433)
        Me.lstFilesList2.TabIndex = 22
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 648)
        Me.Controls.Add(Me.lstFilesList2)
        Me.Controls.Add(Me.DestinantionFolder)
        Me.Controls.Add(Me.DestinationFolder)
        Me.Controls.Add(Me.CheckListFile)
        Me.Controls.Add(Me.cmdFileSelect)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblSiteName)
        Me.Controls.Add(Me.txtSiteID)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.cmdCategory)
        Me.Controls.Add(Me.lstFileNames)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Next_Picture)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ComboBox_Drives)
        Me.Controls.Add(Me.DirectoryTreeView)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DirectoryTreeView As System.Windows.Forms.TreeView
    Friend WithEvents ComboBox_Drives As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Next_Picture As System.Windows.Forms.Button
    Private WithEvents imageList As System.Windows.Forms.ImageList
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lstFileNames As System.Windows.Forms.ListBox
    Friend WithEvents cmdCategory As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtSiteID As System.Windows.Forms.TextBox
    Friend WithEvents lblSiteName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdFileSelect As System.Windows.Forms.Button
    Friend WithEvents CheckListFile As System.Windows.Forms.TextBox
    Friend WithEvents DestinationFolder As System.Windows.Forms.Button
    Friend WithEvents DestinantionFolder As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lstFilesList2 As System.Windows.Forms.ListBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
