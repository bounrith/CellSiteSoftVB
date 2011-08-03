Imports System.IO
Imports System.Xml

Imports System.Net.NetworkInformation

Public Class frmCustomerKey

    Private Sub CreatejSDate()
        Dim JSDateFile As StreamWriter

        JSDateFile = File.CreateText("jSDate.xml")
        JSDateFile.WriteLine(DateToJDate(System.DateTime.Now()))
        JSDateFile.Close()
    End Sub

    Function DateToJDate(ByVal TheDate As Date) As String
        Dim TheYear As Integer
        Dim TheDays As Integer
        Dim JDate As String

        TheYear = Year(TheDate)
        TheDays = DateDiff("d", DateSerial(TheYear, 1, 0), TheDate)
        JDate = Format(TheYear, "0000") & Format(TheDays, "000")

        Return JDate
    End Function

    Function getMacAddress()
        ' this code is used to get the mac address of eth0 network card
        Dim nics() As NetworkInterface = _
        NetworkInterface.GetAllNetworkInterfaces
        Return nics(0).GetPhysicalAddress.ToString
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim serialFile As StreamWriter


        If File.Exists("jSDate.xml") Then
            ' MessageBox.Show("jSDate.xml existed.")
        Else
            CreatejSDate()
        End If

        serialFile = File.CreateText("CustomerKey.txt")

        ' display mac address in 4s to user
            Try
                If getMacAddress() <> "" Then

                    serialFile.WriteLine(getMacAddress())

                    Dim s As String = getMacAddress()
                    Dim r As String = String.Empty
                    For i As Integer = 0 To s.Length - 1 Step 4
                        r &= s.Substring(i, 4)
                        If i < (s.Length - 4) Then r &= "-"
                    Next
                    TextBox1.Text = String.Join("-", r)

                End If

                serialFile.Close()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CreatejSDate()
        MessageBox.Show("Unable to connect to Online Registration Server. Please call 562.858.0830. Thank you.", "Connection Error")
    End Sub

End Class
