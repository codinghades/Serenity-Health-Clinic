Imports MySql.Data.MySqlClient

Public Class frmAppointment

    Dim conn As MySqlConnection = New MySqlConnection("server=localhost;username=root;password=;database=serenity_db")
    Dim cmd As New MySqlCommand
    Dim adapter As New MySqlDataAdapter
    Dim tbl As New DataTable
    Dim dr As MySqlDataReader

    Sub loadData()
        Try
            conn.Open()
            cmd.Connection = conn
            cmd.CommandText = "SELECT * FROM tbl_appointment"
            adapter.SelectCommand = cmd
            tbl.Clear()
            adapter.Fill(tbl)
            appointmentList.DataSource = tbl
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub fillPatients()
        Try
            conn.Open()
            Dim sql = "SELECT * FROM tbl_patient"
            Dim cmd As New MySqlCommand(sql, conn)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim tbl As New DataTable
            adapter.Fill(tbl)

            cboPatient.DataSource = tbl
            cboPatient.DisplayMember = "PatName"
            cboPatient.ValueMember = "PatName"
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub reset()
        cboPatient.SelectedIndex = -1
        txtService.Clear()
    End Sub
    Private Sub frmAppointment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
        fillPatients()
        cboPatient.SelectedIndex = -1
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim Yes As Integer
        If cboPatient.SelectedIndex = -1 Or txtService.Text = "" Then
            MsgBox("Please fill out the missing credentials", vbOKOnly + vbExclamation, "Save")
            Exit Sub
        End If

        Yes = MsgBox("Do you want to save this?", vbYesNo + vbInformation, "Save")
        If Yes = vbYes Then
            Try
                conn.Open()
                Dim query As String
                query = "insert into tbl_appointment(ApPatient,ApService,ApDate,ApTime)values(@Patient,@Service,@Date,@Time)"
                cmd = New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Patient", cboPatient.SelectedValue.ToString())
                cmd.Parameters.AddWithValue("@Service", txtService.Text)
                cmd.Parameters.AddWithValue("@Date", dtDate.Value.Date)
                cmd.Parameters.AddWithValue("@Time", dtTime.Text)
                cmd.ExecuteNonQuery()
                MsgBox("Successfully Save!", vbOKOnly + vbInformation, "Success!")
                reset()
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                conn.Close()
                Call loadData()
            End Try
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim Yes As Integer
        If cboPatient.SelectedIndex = -1 Or txtService.Text = "" Then
            MsgBox("Please select a patient in patient list before editing", vbOKOnly + vbExclamation, "Update")
            Exit Sub
        End If

        Yes = MsgBox("Do you want to edit this?", vbYesNo + vbInformation, "update")
        If Yes = vbYes Then
            Try
                conn.Open()
                Dim query As String
                query = "UPDATE tbl_appointment set ApPatient = @Patient, ApService = @Service, ApDate = @Date, ApTime = @Time WHERE ApID = @ID"
                cmd = New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Patient", cboPatient.SelectedValue.ToString())
                cmd.Parameters.AddWithValue("@Service", txtService.Text)
                cmd.Parameters.AddWithValue("@Date", dtDate.Value.Date)
                cmd.Parameters.AddWithValue("@Time", dtTime.Text)
                cmd.Parameters.AddWithValue("@ID", txtID.Text)
                cmd.ExecuteNonQuery()
                MsgBox("Successfully Updated!", vbOKOnly + vbInformation, "Success!")
                reset()
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                conn.Close()
                Call loadData()
            End Try
        End If
    End Sub
    Private Sub appointmentList_DoubleClick(sender As Object, e As EventArgs) Handles appointmentList.DoubleClick
        txtID.Text = appointmentList.Item("ApID", appointmentList.CurrentRow.Index).Value
        cboPatient.Text = appointmentList.Item("ApPatient", appointmentList.CurrentRow.Index).Value
        txtService.Text = appointmentList.Item("ApService", appointmentList.CurrentRow.Index).Value
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim Yes As Integer
        If cboPatient.SelectedIndex = -1 Or txtService.Text = "" Then
            MsgBox("Please select a patient in patient list before deleting", vbOKOnly + vbExclamation, "Delete")
            Exit Sub
        End If

        Yes = MsgBox("Do you want to Delete this?", vbYesNo + vbInformation, "Delete")
        If Yes = vbYes Then

            Try

                conn.Open()
                cmd = conn.CreateCommand()
                cmd.CommandText = "DELETE FROM tbl_appointment WHERE ApID=@ID;"
                cmd.Parameters.AddWithValue("@ID", txtID.Text)
                cmd.ExecuteNonQuery()
                conn.Close()
                MsgBox("Successfully Deleted!", vbOKOnly + vbInformation, "Success!")
                reset()
                loadData()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        reset()
    End Sub
End Class