'Name : Justine Nanggai
'Class : DDT5A
'Lab Task : 4
Public Class LoginForm2

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'if user do not enter any password and username the messagges appear the user ' the form is not complete yet'
        If txtpswd.Text = "" And txtusername.Text = "" Then
            MessageBox.Show("Incomplete !Please Complete the form", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            ' only admin can log in into the system to manage the record
        ElseIf txtpswd.Text = "admin" And txtusername.Text = "admin" Then
            MessageBox.Show("You Log In As Admin ", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Form1.Show()
        Else
            MessageBox.Show("Uknown User ", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide()

        End If
    End Sub
End Class