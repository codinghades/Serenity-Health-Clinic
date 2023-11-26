Imports MySql.Data.MySqlClient


Public Class frmVital

    Dim conn As MySqlConnection = New MySqlConnection("server=localhost;username=root;password=;database=serenity_db")
    Dim cmd As New MySqlCommand
    Dim adapter As New MySqlDataAdapter
    Dim tbl As New DataTable
    Dim dr As MySqlDataReader

    Sub loadData()
        Try
            conn.Open()
            cmd.Connection = conn
            cmd.CommandText = "SELECT * FROM tbl_vital"
            adapter.SelectCommand = cmd
            tbl.Clear()
            adapter.Fill(tbl)
            vitalList.DataSource = tbl
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

            cboName.DataSource = tbl
            cboName.DisplayMember = "PatName"
            cboName.ValueMember = "PatName"
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub reset()
        cboName.SelectedIndex = -1
        txtBP.Clear()
        txtRR.Clear()
        txtPR.Clear()
        txtTemp.Clear()
        txtAllergies.Clear()
        txtDrug.Clear()
        txtMedication.Clear()
        txtAdmitted.Clear()
        txtDiagnosed.Clear()
        txtCurrent.Clear()
    End Sub
    Private Sub frmVital_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
        fillPatients()
        cboName.SelectedIndex = -1
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim Yes As Integer
        If cboName.SelectedIndex = -1 Or txtBP.Text = "" Or txtRR.Text = "" Or txtPR.Text = "" Or txtTemp.Text = "" Or txtAllergies.Text = "" Or txtDrug.Text = "" Or txtMedication.Text = "" Then
            MsgBox("Please fill out the missing credentials", vbOKOnly + vbExclamation, "Save")
            Exit Sub
        End If

        Yes = MsgBox("Do you want to save this?", vbYesNo + vbInformation, "Save")
        If Yes = vbYes Then
            Try
                conn.Open()
                Dim query As String
                query = "insert into tbl_vital(VtPatient,VtBP,VtRR,VtPR,VtTemp,VtAllergies,VtDrug,VtMedication,VtAdmitted,VtDiagnosed,VtCurrent)values(@Patient,@BP,@RR,@PR,@Temp,@Allergies,@Drug,@Medication,@Admitted,@Diagnosed,@Current)"
                cmd = New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Patient", cboName.SelectedValue.ToString())
                cmd.Parameters.AddWithValue("@BP", txtBP.Text)
                cmd.Parameters.AddWithValue("@RR", txtRR.Text)
                cmd.Parameters.AddWithValue("@PR", txtPR.Text)
                cmd.Parameters.AddWithValue("@Temp", txtTemp.Text)
                cmd.Parameters.AddWithValue("@Allergies", txtAllergies.Text)
                cmd.Parameters.AddWithValue("@Drug", txtDrug.Text)
                cmd.Parameters.AddWithValue("@Medication", txtMedication.Text)
                cmd.Parameters.AddWithValue("@Admitted", txtAdmitted.Text)
                cmd.Parameters.AddWithValue("@Diagnosed", txtDiagnosed.Text)
                cmd.Parameters.AddWithValue("@Current", txtCurrent.Text)
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

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim Yes As Integer
        If cboName.SelectedIndex = -1 Or txtBP.Text = "" Or txtRR.Text = "" Or txtPR.Text = "" Or txtTemp.Text = "" Or txtAllergies.Text = "" Or txtDrug.Text = "" Or txtMedication.Text = "" Then
            MsgBox("Please select a patient in patient list before updating", vbOKOnly + vbExclamation, "Updating")
            Exit Sub
        End If

        Yes = MsgBox("Do you want to Update this?", vbYesNo + vbInformation, "Update")

        If Yes = vbYes Then

            Try
                conn.Open()
                Dim query As String
                query = "UPDATE tbl_vital set VtPatient = @Patient, VtBP = @BP, VtRR = @RR, VtPR = @PR, VtTemp = @Temp, VtAllergies = @Allergies, VtDrug = @Drug, VtMedication = @Medication, VtAdmitted = @Admitted, VtDiagnosed = @Diagnosed, VtCurrent = @Current WHERE VtID = @ID"
                cmd = New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Patient", cboName.SelectedValue.ToString())
                cmd.Parameters.AddWithValue("@BP", txtBP.Text)
                cmd.Parameters.AddWithValue("@RR", txtRR.Text)
                cmd.Parameters.AddWithValue("@PR", txtPR.Text)
                cmd.Parameters.AddWithValue("@Temp", txtTemp.Text)
                cmd.Parameters.AddWithValue("@Allergies", txtAllergies.Text)
                cmd.Parameters.AddWithValue("@Drug", txtDrug.Text)
                cmd.Parameters.AddWithValue("@Medication", txtMedication.Text)
                cmd.Parameters.AddWithValue("@Admitted", txtAdmitted.Text)
                cmd.Parameters.AddWithValue("@Diagnosed", txtDiagnosed.Text)
                cmd.Parameters.AddWithValue("@Current", txtCurrent.Text)
                cmd.Parameters.AddWithValue("@ID", txtID.Text)
                cmd.ExecuteNonQuery()
                MsgBox("Successfully Save!", vbOKOnly + vbInformation, "Success!")
                reset()
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                conn.Close()
                loadData()
            End Try
        End If

    End Sub

    Private Sub vitalList_DoubleClick(sender As Object, e As EventArgs) Handles vitalList.DoubleClick
        txtID.Text = vitalList.Item("VtID", vitalList.CurrentRow.Index).Value
        cboName.Text = vitalList.Item("VtPatient", vitalList.CurrentRow.Index).Value
        txtBP.Text = vitalList.Item("VtBP", vitalList.CurrentRow.Index).Value
        txtRR.Text = vitalList.Item("VtRR", vitalList.CurrentRow.Index).Value
        txtPR.Text = vitalList.Item("VtPR", vitalList.CurrentRow.Index).Value
        txtTemp.Text = vitalList.Item("VtTemp", vitalList.CurrentRow.Index).Value
        txtAllergies.Text = vitalList.Item("VtAllergies", vitalList.CurrentRow.Index).Value
        txtDrug.Text = vitalList.Item("VtDrug", vitalList.CurrentRow.Index).Value
        txtMedication.Text = vitalList.Item("VtMedication", vitalList.CurrentRow.Index).Value
        txtAdmitted.Text = vitalList.Item("VtAdmitted", vitalList.CurrentRow.Index).Value
        txtDiagnosed.Text = vitalList.Item("VtDiagnosed", vitalList.CurrentRow.Index).Value
        txtCurrent.Text = vitalList.Item("VtCurrent", vitalList.CurrentRow.Index).Value
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim Yes As Integer
        If cboName.SelectedIndex = -1 Or txtBP.Text = "" Or txtRR.Text = "" Or txtPR.Text = "" Or txtTemp.Text = "" Or txtAllergies.Text = "" Or txtDrug.Text = "" Or txtMedication.Text = "" Then
            MsgBox("Please select a patient in patient list before deleting", vbOKOnly + vbExclamation, "Delete")
            Exit Sub
        End If

        Yes = MsgBox("Do you want to Delete this?", vbYesNo + vbInformation, "Delete")
        If Yes = vbYes Then

            Try

                conn.Open()
                cmd = conn.CreateCommand()
                cmd.CommandText = "DELETE FROM tbl_vital WHERE VtID=@ID;"
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