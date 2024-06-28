Imports MySql.Data.MySqlClient

Public Class editarproducto

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        registrarproducto.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim comando = New MySqlCommand("SELECT * FROM productos WHERE username = '" + TextBox1.Text + "';", conex)
            Dim resultado = comando.ExecuteReader
            resultado.Read()
            If (TextBox1.Text <> "") Then

                If resultado.HasRows Then

                    TextBox2.Text = resultado("username")
                    TextBox3.Text = resultado("precio")
                    TextBox4.Text = resultado("direccion")
                    resultado.Close()
                Else

                    MsgBox("ERROR, el producto no existe.")
                    resultado.Close()
                End If
            Else
                MsgBox("ERROR,  coloque el nombre del producto que se desea modificar.")
            End If
        Catch ex As Exception
            MsgBox("error: " + ex.Message)

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim comando = New MySqlCommand("UPDATE productos SET username = '" + TextBox2.Text + "', precio = '" + TextBox3.Text + "', direccion = '" + TextBox4.Text + "' WHERE username = '" + TextBox1.Text + "';", conex)
        Dim update = comando.ExecuteNonQuery
        MsgBox("GUARDADO")
    End Sub
End Class