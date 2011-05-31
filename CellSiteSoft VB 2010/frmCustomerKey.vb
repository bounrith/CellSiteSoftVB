﻿Imports System.IO
Imports System.Xml

Imports System.Net.NetworkInformation

Public Class frmCustomerKey

    Function getMacAddress()
        ' this code is used to get the mac address of eth0 network card
        Dim nics() As NetworkInterface = _
        NetworkInterface.GetAllNetworkInterfaces
        Return nics(0).GetPhysicalAddress.ToString
    End Function

    Public Sub CheckRegistration(ByVal xmlText As [String])
        '--------START REGISTRATION CHECK to see how many times has the program ran / if less than 15 then EVERYTHING is OK
        '--------if this run is >= 15 then must register or the program will terminate / call us at 10th run

        'Dim _doc As New XmlDocument
        'alternately, _doc.LoadXml(xmlText); to load from input

        '_doc.LoadXml("\obj\x86\Debug\FPhotoM.xml")

        'Dim _elasDate As XmlNodeList = _doc.GetElementsByTagName("elasDate")
        'Dim _elasRun As XmlNodeList = _doc.GetElementsByTagName("elasRun")
        'Dim elasDate As Date = _elasDate

    End Sub ' END REGISTRATION CHECK



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim serialFile As StreamWriter
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
        WriteXML()
    End Sub

    Private Sub WriteXML()
        Dim writer As New XmlTextWriter("akire.xml", System.Text.Encoding.UTF8)
        writer.WriteStartDocument(True)
        writer.Formatting = Formatting.Indented
        writer.Indentation = 2
        writer.WriteStartElement("Table")
        createNode(System.DateTime.Now, System.DateTime.Now, System.DateTime.Now, writer)
        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Close()
    End Sub

    Private Sub createNode(ByVal pID As String, ByVal pName As String, ByVal pPrice As String, ByVal writer As XmlTextWriter)
        writer.WriteStartElement("TRB Software")
        writer.WriteStartElement("StartDate")
        writer.WriteString(pID)
        writer.WriteEndElement()
        writer.WriteStartElement("TodayDate")
        writer.WriteString(pName)
        writer.WriteEndElement()
        writer.WriteStartElement("EndDate")
        writer.WriteString(pPrice)
        writer.WriteEndElement()
        writer.WriteEndElement()
    End Sub

End Class
