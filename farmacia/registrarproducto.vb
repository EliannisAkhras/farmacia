Imports MySql.Data.MySqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class registrarproducto
    Private Sub registrarproducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        quererregistrar.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "") Then
            MsgBox("ERROR, faltan datos")
        Else
            Try
                Dim comando = New MySqlCommand("SELECT * FROM productos WHERE username = '" + TextBox1.Text + "';", conex)
                Dim resultado = comando.ExecuteReader
                resultado.Read()
                If (resultado.HasRows) Then
                    MsgBox("El producto: " + resultado("username") + ", fue registrado correctamente. ")
                    resultado.Close()
                Else
                    resultado.Close()

                    comando = New MySqlCommand("INSERT INTO productos (username,precio,direccion) VALUES ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')", conex)
                    Dim busqueda = comando.ExecuteNonQuery
                End If
                resultado.Close()
            Catch ex As Exception
                MsgBox("ERROR: " + ex.Message)
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
            End Try

        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim comando = New MySqlCommand("SELECT * FROM productos;", conex)
        Dim resultado = comando.ExecuteReader
        While (resultado.Read)
            MsgBox("nombre: " + resultado("username") + ", precio: " + resultado("precio").ToString + ", proveedor: " + resultado("direccion"))
        End While
        resultado.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        editarproducto.Show()
    End Sub
End Class