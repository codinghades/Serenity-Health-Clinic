Imports MySql.Data.MySqlClient

Public Class frmPatient

    Dim conn As MySqlConnection = New MySqlConnection("server=localhost;username=root;password=;database=serenity_db")
    Dim cmd As New MySqlCommand
    Dim adapter As New MySqlDataAdapter
    Dim tbl As New DataTable
    Dim dr As MySqlDataReader

    Sub reset()
        txtName.Clear()
        cboSex.SelectedIndex = -1
        txtHeight.Clear()
        txtWeight.Clear()
        txtAddress.Clear()
        txtContact.Clear()
        txtReligion.Clear()
        cboBlood.SelectedIndex = -1
        txtNationality.Clear()
        txtFullname.Clear()
        txtEContact.Clear()
        txtEAddress.Clear()
        txtRelationship.Clear()
        txtName.Focus()
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click

        frmVital.Show()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim Yes As Integer
        If txtName.Text = "" Or cboSex.SelectedIndex = -1 Or txtHeight.Text = "" Or txtWeight.Text = "" Or txtAddress.Text = "" Or txtContact.Text = "" Or txtReligion.Text = "" Or cboBlood.SelectedIndex = -1 Or txtNationality.Text = "" Or txtFullname.Text = "" Or txtEContact.Text = "" Or txtEAddress.Text = "" Or txtRelationship.Text = "" Then
            MsgBox("Please fill out the missing credentials before saving", vbOKOnly + vbExclamation, "Missing!")
            Exit Sub
        End If

        Yes = MsgBox("Do you want to save this?", vbYesNo + vbInformation, "Save")
        If Yes = vbYes Then
            Try
                conn.Open()
                Dim query As String
                query = "INSERT INTO tbl_patient(PatName,PatSex,PatBday,PatHeight,PatWeight,PatAddress,PatContact,PatReligion,PatBlood,PatNationality,PatEName,PatEContact,PatEAddress,PatRelationship)values(@Name,@Sex,@Bday,@Height,@Weight,@Address,@Contact,@Religion,@Blood,@Nationality,@EName,@EContact,@EAddress,@Relationship)"
                cmd = New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Name", txtName.Text)
                cmd.Parameters.AddWithValue("@Sex", cboSex.SelectedItem)
                cmd.Parameters.AddWithValue("@Bday", dtBday.Value.Date)
                cmd.Parameters.AddWithValue("@Height", txtHeight.Text)
                cmd.Parameters.AddWithValue("@Weight", txtWeight.Text)
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
                cmd.Parameters.AddWithValue("@Contact", txtContact.Text)
                cmd.Parameters.AddWithValue("@Religion", txtReligion.Text)
                cmd.Parameters.AddWithValue("@Blood", cboBlood.SelectedItem)
                cmd.Parameters.AddWithValue("@Nationality", txtNationality.Text)
                cmd.Parameters.AddWithValue("@EName", txtFullname.Text)
                cmd.Parameters.AddWithValue("@EContact", txtEContact.Text)
                cmd.Parameters.AddWithValue("@EAddress", txtEAddress.Text)
                cmd.Parameters.AddWithValue("@Relationship", txtRelationship.Text)
                cmd.ExecuteNonQuery()
                conn.Close()
                MsgBox("Successfully Save!", vbOKOnly + vbInformation, "Success!")
                reset()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim Yes As Integer
        If txtName.Text = "" Or cboSex.SelectedIndex = -1 Or txtHeight.Text = "" Or txtWeight.Text = "" Or txtAddress.Text = "" Or txtContact.Text = "" Or txtReligion.Text = "" Or cboBlood.SelectedIndex = -1 Or txtNationality.Text = "" Or txtFullname.Text = "" Or txtEContact.Text = "" Or txtEAddress.Text = "" Or txtRelationship.Text = "" Then
            MsgBox("Please select a patient in patient list before updating", vbOKOnly + vbExclamation, "Missing!")
            Exit Sub
        End If

        Yes = MsgBox("Do you want to update this?", vbYesNo + vbInformation, "Update")

        If Yes = vbYes Then
            Try
                conn.Open()

                Dim query As String = "UPDATE tbl_patient SET PatName = @Name, PatSex = @Sex, PatBday = @Bday, PatHeight = @Height, PatWeight = @Weight, PatAddress = @Address, PatContact = @Contact, PatReligion = @Religion, PatNationality = @Nationality, PatEName = @EName, PatEContact = @EContact, PatEAddress = @EAddress, PatRelationship = @Relationship WHERE PatID = @ID"

                Dim cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@Name", txtName.Text)
                cmd.Parameters.AddWithValue("@Sex", cboSex.SelectedItem)
                cmd.Parameters.AddWithValue("@Bday", dtBday.Value.Date)
                cmd.Parameters.AddWithValue("@Height", txtHeight.Text)
                cmd.Parameters.AddWithValue("@Weight", txtWeight.Text)
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
                cmd.Parameters.AddWithValue("@Contact", txtContact.Text)
                cmd.Parameters.AddWithValue("@Religion", txtReligion.Text)
                cmd.Parameters.AddWithValue("@Blood", cboBlood.SelectedItem)
                cmd.Parameters.AddWithValue("@Nationality", txtNationality.Text)
                cmd.Parameters.AddWithValue("@EName", txtFullname.Text)
                cmd.Parameters.AddWithValue("@EContact", txtEContact.Text)
                cmd.Parameters.AddWithValue("@EAddress", txtEAddress.Text)
                cmd.Parameters.AddWithValue("@Relationship", txtRelationship.Text)
                cmd.Parameters.AddWithValue("@ID", txtID.Text)

                cmd.ExecuteNonQuery()
                conn.Close()

                MsgBox("Successfully Updated!!", vbOKOnly + vbInformation, "Success!")
                reset()

            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Try

        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim Yes As Integer
        If txtName.Text = "" Or cboSex.SelectedIndex = -1 Or txtHeight.Text = "" Or txtWeight.Text = "" Or txtAddress.Text = "" Or txtContact.Text = "" Or txtReligion.Text = "" Or cboBlood.SelectedIndex = -1 Or txtNationality.Text = "" Or txtFullname.Text = "" Or txtEContact.Text = "" Or txtEAddress.Text = "" Or txtRelationship.Text = "" Then
            MsgBox("Please select a patient in Patient List before deleting", vbOKOnly + vbExclamation, "Missing!")
            Exit Sub
        End If

        Yes = MsgBox("Do you want to delete this?", vbYesNo + vbInformation, "Delete")

        If Yes = vbYes Then
            Try
                conn.Open()
                cmd = conn.CreateCommand
                cmd.CommandText = "DELETE FROM tbl_patient WHERE PatID = @ID"
                cmd.Parameters.AddWithValue("@ID", txtID.Text)
                cmd.ExecuteNonQuery()
                conn.Close()
                MsgBox("Successfully Deleted!", MsgBoxStyle.Information, "Success")
                reset()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        reset()
    End Sub

End Class