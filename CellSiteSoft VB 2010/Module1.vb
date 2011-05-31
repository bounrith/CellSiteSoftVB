Imports System.Xml

Module Module1

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



    Private Sub WriteXML()
        Dim writer As New XmlTextWriter("Akire.xml", System.Text.Encoding.UTF8)
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

End Module
