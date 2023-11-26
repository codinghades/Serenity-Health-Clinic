Public Class splash
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Panel1.Width += 3
        If Panel1.Width >= 550 Then
            Timer1.Stop()
            frmLogin.Show()
            Me.Hide()
        End If

    End Sub

    Private Sub splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub
End Class