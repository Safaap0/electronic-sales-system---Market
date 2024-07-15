Public Class Form4
    Private Function AuthenticateUser(username As String, password As String) As Boolean
        ' Dummy authentication, replace with your logic
        If username = "mazin" AndAlso password = "1973" Then
            Return True
        End If

        If username = "safaa" AndAlso password = "2002" Then
            Return True
        End If
        Return False
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If AuthenticateUser(TextBox1.Text, TextBox2.Text) Then
            Dim mainForm As New Form1 With {
            .LoggedInUsername = TextBox1.Text ' Pass the username to Form1
            }
            mainForm.Show()
            Me.Hide() ' Hide the login form
        Else
            MessageBox.Show("Invalid username or password. Please try again.")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Label1.AutoSize = True

    End Sub




End Class