Imports System.IO
Imports System.Net.NetworkInformation


Module modLicense

    Public Function getMacAddress()
        Dim nics() As NetworkInterface = _
            NetworkInterface.GetAllNetworkInterfaces
        Return nics(0).GetPhysicalAddress.ToString
    End Function

    ' convert Gregorian Date to Julian Date
    Public Function DateToJDate(ByVal TheDate As Date) As String ' why can't this be shared function
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

    Public Function localLicenseKey(ByVal getMacAddress As String, ByVal DateToJDate As String) As String
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

End Module
