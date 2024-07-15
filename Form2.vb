Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DatabasemarketDataSet.Table1db' table. You can move, or remove it, as needed.
        Me.Table1dbTableAdapter.Fill(Me.DatabasemarketDataSet.Table1db)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Table1dbBindingSource.AddNew()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        On Error GoTo saveerror
        Table1dbBindingSource.EndEdit()
        Table1dbTableAdapter.Update(DatabasemarketDataSet.Table1db)
        MsgBox("saved")
saveerror:
        Exit Sub
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Table1dbBindingSource.RemoveCurrent()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub



End Class