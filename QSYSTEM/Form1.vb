Imports System.Globalization
Imports System.Speech.Synthesis
Imports System.Threading.Tasks

Public Class Form1

    Dim speaker As New SpeechSynthesizer()
    Dim culture As CultureInfo = CultureInfo.GetCultureInfo("ar-SA")
    Dim voices As ICollection(Of InstalledVoice)
    Dim speechComplete As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        voices = speaker.GetInstalledVoices(culture)
        speaker.SelectVoice(voices(0).VoiceInfo.Name)
        Dim Resv As String = Command()
        My.Computer.Audio.Play(My.Resources.ALR, AudioPlayMode.Background)
        Threading.Thread.Sleep(350)

        Resv = "عميل رقم | 445 | برجاء استلام التقارير"
        For Each txtt As String In Resv.Split("|")
            If voices.Count > 0 Then
                speaker.SpeakAsync(txtt)
                Threading.Thread.Sleep(100)
            End If
        Next
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not speechComplete Then
            e.Cancel = True ' إلغاء حدث الإغلاق إذا لم يكتمل النطق بعد.
        End If
    End Sub

#Disable Warning IDE1006 ' Naming Styles
    Private Sub speaker_SpeakCompleted(sender As Object, e As SpeakCompletedEventArgs) Handles speaker.SpeakCompleted
#Enable Warning IDE1006 ' Naming Styles
        ' يتم تنشيط هذا الحدث عند اكتمال النطق.
        speechComplete = True
        Me.Close() ' أغلق التطبيق عند اكتمال النطق.
    End Sub
End Class
