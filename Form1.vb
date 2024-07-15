Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class Form1

    Dim iandc As New Dictionary(Of String, Double)()
    Public Property LoggedInUsername As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Add items to the ComboBox
        ComboBox1.Items.AddRange({"sweets", "drinks", "cookies", "chips", "cola", "juice", "water", "snacks", "tea", "coffee", "soda", "power", "milkshake", "smoothie", "Gtea"})

        ' Add corresponding prices to the dictionary
        iandc.Add("sweets", 10.0)
        iandc.Add("drinks", 20.0)
        iandc.Add("cookies", 50.0)
        iandc.Add("chips", 15.0)
        iandc.Add("cola", 25.0)
        iandc.Add("juice", 30.0)
        iandc.Add("water", 5.0)
        iandc.Add("snacks", 12.0)
        iandc.Add("tea", 10.0)
        iandc.Add("coffee", 15.0)
        iandc.Add("soda", 20.0)
        iandc.Add("power", 40.0)
        iandc.Add("milkshake", 30.0)
        iandc.Add("smoothie", 35.0)
        iandc.Add("Gtea", 25.0)
    End Sub

    Private Sub UpdateTotalCostAndDiscount()
        Dim totalCost As Double = 0
        For Each item As String In ListBox1.Items
            Dim itemcost As Double = CDbl(item.Substring(item.LastIndexOf("$"c) + 1))
            totalCost += itemcost
        Next

        ' Apply discount if total cost is over $100
        Dim discountAmount As Double = If(totalCost > 100, totalCost * 0.11, 0)

        ' Update TextBoxes
        TextBox1.Text = totalCost.ToString("f2")
        TextBox4.Text = discountAmount.ToString("f2")
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ListBox1.Text = " "
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim selectitem As String = ComboBox1.SelectedItem.ToString()
        Dim cost As Double = iandc(selectitem)
        Dim quantity As Double = 0
        If Double.TryParse(TextBox5.Text, quantity) Then
            Dim itemandquantity As Double = quantity * cost
            ListBox1.Items.Add(selectitem & " | " & quantity & " |" & "   $" & itemandquantity.ToString("f2"))
        Else
            Dim itemandquantity As Double = cost
            ListBox1.Items.Add(selectitem & " | 1 | " & "   $" & itemandquantity.ToString("f2"))

        End If
        Dim totalcost As Double = 0
        For Each item As String In ListBox1.Items
            Dim itemcost As Double = CDbl(item.Substring(item.LastIndexOf("$"c) + 1))
            totalcost += itemcost

        Next

        If totalcost > 100 Then
            totalcost *= 0.9

        End If
        TextBox1.Text = totalcost.ToString("f2")
        TextBox5.Clear()
        UpdateTotalCostAndDiscount()
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        ListBox1.Items.Clear()
        TextBox1.Clear()
        TextBox4.Clear()
        UpdateTotalCostAndDiscount()
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim newItem As String = TextBox2.Text.Trim()
        Dim newCostText As String = TextBox3.Text.Trim()

        If Not String.IsNullOrEmpty(newItem) AndAlso Not String.IsNullOrEmpty(newCostText) Then
            Dim newCost As Double
            If Double.TryParse(newCostText, newCost) Then
                ' Add the new item and its cost to the dictionary
                iandc.Add(newItem, newCost)

                ' Add the new item to the ComboBox
                ComboBox1.Items.Add(newItem)

                ' Clear TextBoxes after adding
                TextBox2.Clear()
                TextBox3.Clear()
            Else
                MessageBox.Show("Please enter a valid cost.")
            End If
        Else
            MessageBox.Show("Please enter both item name and cost.")
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Create a list to hold forms to close
        Dim formsToClose As New List(Of Form)

        ' Add all open forms except for the current form (Form1) to the list
        For Each frm As Form In Application.OpenForms
            If frm IsNot Me Then ' Check if the form is not the current form
                formsToClose.Add(frm)
            End If
        Next

        ' Close all forms in the list
        For Each frm As Form In formsToClose
            frm.Close()
        Next

        ' Finally, close the current form
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sb As New System.Text.StringBuilder()

        ' Append user's name and login date to StringBuilder
        sb.AppendLine("Welcome: cashier system")
        sb.AppendLine("اهلا و سهلا بكم")
        sb.AppendLine("ماركت بغداد")
        sb.AppendLine("User: " & LoggedInUsername) ' Use the property to access the username
        sb.AppendLine("Login Date: " & Date.Now().ToString())

        ' Append ListBox1 items to StringBuilder
        For Each item As Object In ListBox1.Items
            sb.AppendLine(item.ToString())
        Next

        ' Calculate discount amount
        Dim totalCost As Double = CDbl(TextBox1.Text)
        Dim discountAmount As Double = 0
        If totalCost > 100 Then
            discountAmount = totalCost * 0.11 ' Calculate 10% of the total cost as discount
        End If
        Dim discountAmountString As String = discountAmount.ToString("f2")

        ' Set TextBox4 text to the discount amount
        TextBox4.Text = discountAmountString

        ' Append discount information to StringBuilder
        sb.AppendLine("Discount: $" & discountAmountString)

        ' Append TextBox1 text to StringBuilder
        sb.AppendLine("Total Cost: $" & TextBox1.Text)

        ' Generate a unique file name using the current date and time
        Dim fileName As String = "output_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".txt"
        Dim filePath As String = System.IO.Path.Combine("D:\system2024\invoice", fileName)

        ' Write the content to the file
        System.IO.File.WriteAllText(filePath, sb.ToString())
    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim db_form As New Form2()
        db_form.Show()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim newform As New Form3()
        newform.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If ListBox1.SelectedIndex <> -1 Then ' Check if an item is selected
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex) ' Remove the selected item
        Else
            MessageBox.Show("Please select an item to delete.")
        End If
        UpdateTotalCostAndDiscount()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim Llogin As New Form4()
        Llogin.Show()
        Me.Hide()
    End Sub
End Class
