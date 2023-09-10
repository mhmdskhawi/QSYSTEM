Imports System.Globalization
Imports System.Speech.Synthesis


Public Class Form1

    Dim speaker As New SpeechSynthesizer()
    Dim culture As CultureInfo = CultureInfo.GetCultureInfo("ar-SA")
    Dim voices
    Dim speechComplete As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        voices = speaker.GetInstalledVoices(culture)
        speaker.SelectVoice(voices(0).VoiceInfo.Name)

        Dim Resv As String = Command()
        My.Computer.Audio.Play(My.Resources.ALR, AudioPlayMode.Background)
        Threading.Thread.Sleep(1000)

        'Resv = "عميل رقم | 445 | برجاء استلام التقارير   | "
        For Each txtt As String In Resv.Split("|")
            If voices.Count > 0 Or Resv <> "" Then
                speaker.SpeakAsync(txtt)
                Threading.Thread.Sleep(350)

            Else
                Threading.Thread.Sleep(1500)
            End If
        Next
        Timer1.Start()


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If speaker.State() = SynthesizerState.Speaking Then
        Else
            Application.Exit()
        End If
    End Sub
End Class
