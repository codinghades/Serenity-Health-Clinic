Public Class dashboard

    Private Sub btnPatientList2_Click(sender As Object, e As EventArgs) Handles btnPatientList2.Click
        btnAppointment2.Visible = True
        btnAppointment.Visible = False
        btnPatient.Visible = False
        btnPatient2.Visible = True
        btnPatientList.Visible = True
        btnPatientList2.Visible = False

        Dim patientList = New patList

        patientList.TopLevel = False
        pnlContent.Controls.Add(patientList)
        patientList.BringToFront()
        patientList.Show()
    End Sub

    Private Sub btnPatient2_Click(sender As Object, e As EventArgs) Handles btnPatient2.Click
        btnPatient.Visible = True
        btnPatient2.Visible = False
        btnAppointment2.Visible = True
        btnAppointment.Visible = False
        btnPatientList2.Visible = True
        btnPatientList.Visible = False

        Dim patient = New frmPatient

        patient.TopLevel = False
        pnlContent.Controls.Add(patient)
        patient.BringToFront()
        patient.Show()
    End Sub

    Private Sub btnAppointment2_Click(sender As Object, e As EventArgs) Handles btnAppointment2.Click
        btnAppointment2.Visible = False
        btnAppointment.Visible = True
        btnPatient.Visible = False
        btnPatient2.Visible = True
        btnPatientList2.Visible = True
        btnPatientList.Visible = False

        Dim appointmentList = New frmAppointment

        appointmentList.TopLevel = False
        pnlContent.Controls.Add(appointmentList)
        appointmentList.BringToFront()
        appointmentList.Show()

    End Sub

    Private Sub dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnPatientList.Visible = True
        btnPatientList.BringToFront()

        Dim patientList = New patList

        patientList.TopLevel = False
        pnlContent.Controls.Add(patientList)
        patientList.BringToFront()
        patientList.Show()
    End Sub

    Private Sub btnExit2_Click(sender As Object, e As EventArgs) Handles btnExit2.Click
        btnExit.Visible = False
        btnExit2.Visible = True

        Dim yes As Integer

        yes = MsgBox("Are you sure you want to logout?", vbYesNo + vbInformation, "Logout")

        If yes = vbYes Then
            frmLogin.Show()
            Me.Hide()
            frmLogin.txtUsername.Clear()
            frmLogin.txtPassword.Clear()
            frmLogin.txtUsername.Focus()
        End If

    End Sub
End Class