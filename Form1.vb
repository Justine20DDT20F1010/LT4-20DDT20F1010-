'Justine Nanggai
'20DDT20F1010
'DDT5A
Imports System.Data.SqlClient

Public Class Form1
    'Set the sqlconnection make sure remember the password and user
    Dim con As New SqlConnection("server=DESKTOP-D46HQFR;database=Product;user=sa;password=P@ssw0rd")
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ProductDataSet.tblProduct' table. You can move, or remove it, as needed.
        Me.TblProductTableAdapter.Fill(Me.ProductDataSet.tblProduct)

    End Sub
    'insert record
    Private Sub Btn_Insert_Click(sender As Object, e As EventArgs) Handles Btn_Insert.Click
        Dim insertquery As String = "insert into tblProduct(ID, Name, Price, Category, Quantity, Description) values('" & Tb_ID.Text & "','" & Tb_Name.Text & "','" & Tb_Price.Text & "','" & Cbx_Category.SelectedItem & "','" & Tb_Quantity.Text & "','" & Tb_Description.Text & "')"
        Dim cmd As New SqlCommand(insertquery, con)
        'connection open
        con.Open()
        'connection execute
        cmd.ExecuteNonQuery()
        'connection close
        con.Close()
        MsgBox("New Record Inserted Successfully!")
        Refresh()

        Me.TblProductTableAdapter.Fill(Me.ProductDataSet.tblProduct)
        Dim bs As New BindingSource
        bs.DataSource = ProductDataSet.Tables(0).DefaultView
        DataGridView1.DataSource = bs
    End Sub

    'clear text
    Private Sub Btn_Clear_Click(sender As Object, e As EventArgs) Handles Btn_Clear.Click
        'reset the txtbox
        Tb_ID.ResetText()
        Tb_Name.ResetText()
        Tb_Price.ResetText()
        Cbx_Category.ResetText()
        Tb_Quantity.ResetText()
        Tb_Description.ResetText()
    End Sub


    Private Sub Btn_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Delete.Click
        ' user need to enter a id of product to find the product and then to delete
        Dim ID As String = InputBox("Please enter the ID of the product: ", "Delete Record")
        Dim deletequery As String = "delete from tblProduct where ID= '" & ID & "'"
        Dim cmd As New SqlCommand(deletequery, con)
        'connection open
        con.Open()
        cmd.ExecuteNonQuery()
        'connection close
        con.Close()
        'messagebox
        MsgBox("Record Deleted Successfully!")
        Refresh()

        Me.TblProductTableAdapter.Fill(Me.ProductDataSet.tblProduct)
        Dim bs As New BindingSource
        bs.DataSource = ProductDataSet.Tables(0).DefaultView
        DataGridView1.DataSource = bs
    End Sub


    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        ' update record
        Dim updatequery As String = "update tblProduct set Name='" & Tb_Name.Text & "', Price='" & Tb_Price.Text & "',
Category='" & Cbx_Category.SelectedItem & "', Quantity='" & Tb_Quantity.Text & "', Description='" & Tb_Description.Text & "'
where id='" & Tb_ID.Text & "'"
        Dim cmd As New SqlCommand(updatequery, con)
        ' connection open
        con.Open()
        cmd.ExecuteNonQuery()
        'connection close
        con.Close()
        MsgBox("Record Updated Successfully!")
        Refresh()

        Me.TblProductTableAdapter.Fill(Me.ProductDataSet.tblProduct)
        Dim bs As New BindingSource
        bs.DataSource = ProductDataSet.Tables(0).DefaultView
        DataGridView1.DataSource = bs
    End Sub


    Private Sub Btn_Search_Click(sender As Object, e As EventArgs) Handles Btn_Search.Click
        'search record
        If Tb_ID.Text = "" Then
            MsgBox("Please insert the ID")
            Exit Sub
        End If
        ' using select *
        Dim searchquery As String = "select * from tblProduct where id= '" & Tb_ID.Text & "'"
        Dim cmd As New SqlCommand(searchquery, con)
        Dim ta As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        ta.Fill(table)
        If table.Rows.Count > 0 Then
            Tb_Name.Text = table.Rows(0)(1).ToString
            Tb_Price.Text = table.Rows(0)(2).ToString
            Cbx_Category.SelectedItem = table.Rows(0)(3).ToString
            Tb_Quantity.Text = table.Rows(0)(4).ToString
            Tb_Description.Text = table.Rows(0)(5).ToString
        Else
            MsgBox("No Record Found")
        End If

        Me.TblProductTableAdapter.Fill(Me.ProductDataSet.tblProduct)
        Dim bs As New BindingSource
        bs.DataSource = ProductDataSet.Tables(0).DefaultView
        DataGridView1.DataSource = bs
    End Sub

    Private Sub Btn_Exit_Click(sender As Object, e As EventArgs) Handles Btn_Exit.Click
        Me.Close()

    End Sub
End Class
