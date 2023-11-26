Imports MySql.Data.MySqlClient
Public Class patList

    Dim conn As MySqlConnection = New MySqlConnection("server=localhost;username=root;password=;database=serenity_db")
    Dim cmd As New MySqlCommand
    Dim adapter As New MySqlDataAdapter
    Dim tbl As New DataTable
    Dim dr As MySqlDataReader


    Sub loadData()

        Try
            conn.Open()
            cmd.Connection = conn
            cmd.CommandText = "SELECT * FROM tbl_patient"
            adapter.SelectCommand = cmd
            tbl.Clear()
            adapter.Fill(tbl)
            patientList.DataSource = tbl
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) 
        frmVital.Show()
    End Sub

    Private Sub patList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
    End Sub

    Private Sub patientList_DoubleClick(sender As Object, e As EventArgs) Handles patientList.DoubleClick
        dashboard.btnPatient.Visible = True
        dashboard.btnPatient2.Visible = False
        dashboard.btnAppointment2.Visible = True
        dashboard.btnAppointment.Visible = False
        dashboard.btnPatientList2.Visible = True
        dashboard.btnPatientList.Visible = False
        Dim patientForm = New frmPatient

        patientForm.TopLevel = False
        dashboard.pnlContent.Controls.Add(patientForm)
        patientForm.BringToFront()
        patientForm.Show()



        patientForm.txtName.Text = patientList.Item("PatName", patientList.CurrentRow.Index).Value
        patientForm.cboSex.Text = patientList.Item("PatSex", patientList.CurrentRow.Index).Value
        patientForm.dtBday.Value = patientList.Item("PatBday", patientList.CurrentRow.Index).Value
        patientForm.txtHeight.Text = patientList.Item("PatHeight", patientList.CurrentRow.Index).Value
        patientForm.txtWeight.Text = patientList.Item("PatWeight", patientList.CurrentRow.Index).Value
        patientForm.txtAddress.Text = patientList.Item("PatAddress", patientList.CurrentRow.Index).Value
        patientForm.txtContact.Text = patientList.Item("PatContact", patientList.CurrentRow.Index).Value
        patientForm.txtReligion.Text = patientList.Item("PatReligion", patientList.CurrentRow.Index).Value
        patientForm.cboBlood.Text = patientList.Item("PatBlood", patientList.CurrentRow.Index).Value
        patientForm.txtNationality.Text = patientList.Item("PatNationality", patientList.CurrentRow.Index).Value
        patientForm.txtFullname.Text = patientList.Item("PatEName", patientList.CurrentRow.Index).Value
        patientForm.txtEContact.Text = patientList.Item("PatEContact", patientList.CurrentRow.Index).Value
        patientForm.txtEAddress.Text = patientList.Item("PatEAddress", patientList.CurrentRow.Index).Value
        patientForm.txtRelationship.Text = patientList.Item("PatRelationship", patientList.CurrentRow.Index).Value
        patientForm.txtID.Text = patientList.Item("PatID", patientList.CurrentRow.Index).Value
    End Sub
End Class