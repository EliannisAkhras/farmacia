Imports MySql.Data.MySqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class registrarclientes
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "") Then
            MsgBox("ERROR, faltan datos")
        Else
            Try
                Dim comando = New MySqlCommand("SELECT * FROM clientes WHERE username = '" + TextBox2.Text + "';", conex)
                Dim resultado = comando.ExecuteReader
                resultado.Read()
                If (resultado.HasRows) Then
                    MsgBox("El cliente: " + resultado("username") + " de cedula: " + resultado("cedula") + " y direccion: " + resultado("direccion") + " fue registrado exitosamente!!")
                    resultado.Close()
                Else
                    resultado.Close()

                    comando = New MySqlCommand("INSERT INTO clientes (username,cedula,direccion) VALUES ('" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')", conex)
                    Dim busqueda = comando.ExecuteNonQuery
                End If
                resultado.Close()
            Catch ex As Exception
                MsgBox("ERROR: " + ex.Message)
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""

            End Try

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        quererregistrar.Show()
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim comando = New MySqlCommand("SELECT * FROM clientes;", conex)
        Dim resultado = comando.ExecuteReader
        While (resultado.Read)
            MsgBox("nombre: " + resultado("username") + ", cedula: " + resultado("cedula") + ", direccion: " + resultado("direccion"))
        End While
        resultado.Close()

    End Sub
End Class