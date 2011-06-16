Public NotInheritable Class frmAboutBox

    Private Sub frmAboutBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.D1 Then
            Timer1.Enabled = True
        End If
        If e.KeyCode = Keys.D2 And Timer1.Enabled = True Then
            Timer2.Enabled = True
        End If
        If e.KeyCode = Keys.D3 And Timer1.Enabled = True And Timer2.Enabled = True Then
            Timer3.Enabled = True
        End If
        If e.KeyCode = Keys.D4 And Timer1.Enabled = True And Timer2.Enabled = True And Timer3.Enabled = True Then
            'Put what you want to be an easter egg here.
            MessageBox.Show("Tino Ry Bounrith", "Class of 1993")
            Timer1.Enabled = False
            Timer2.Enabled = False
            Timer3.Enabled = False
        End If

    End Sub

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        KeyPreview = True

        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = My.Application.Info.Description
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

End Class
