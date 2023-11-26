Public Class frmLogin
    Dim x, ctr As Integer

    Sub Check()
        If txtUsername.Text = "Admin" And txtPassword.Text = "Admin" Then
            MsgBox("Welcome, Doctor!", vbOKOnly + vbInformation, "Welcome!")
            dashboard.Show()
            Me.Hide()
        Else
            x = MsgBox("User does not exist", vbRetryCancel + vbExclamation, "Wrong credentials")
            If x = vbRetry Then
                txtUsername.Clear()
                txtPassword.Clear()
                txtUsername.Focus()
                ctr = ctr + 1
                If ctr = 3 Then
                    x = MsgBox("Login failed." + Chr(13) + "You have used your three attempts, program will be terminated.", vbOKOnly + vbCritical, "Login Failed")
                    Application.Exit()
                End If
            Else
                Application.Exit()
            End If
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Check()
    End Sub

    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress

        If Asc(e.KeyChar) = 13 Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Check()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        End
    End Sub
End Class
