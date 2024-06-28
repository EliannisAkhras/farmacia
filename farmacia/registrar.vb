Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class registrar
    Private Sub registrar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        quererregistrar.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "") Then
            MsgBox("faltan datos")
        Else
            Dim comando = New MySqlCommand("SELECT * FROM usuarios WHERE username = '" + TextBox1.Text + "';", conex)
            Dim resultado = comando.ExecuteReader
            resultado.Read()
            If (resultado.HasRows) Then
                MsgBox("El usuario ha sido registrado con el nombre: " + resultado("username") + ", exitosamente!!")
                resultado.Close()
            Else
                resultado.Close()

                If (TextBox3.Text = TextBox4.Text) Then
                    Try
                        comando = New MySqlCommand("INSERT INTO usuarios (username,password,fullname) VALUES ('" + TextBox1.Text + "','" + TextBox3.Text + "','" + TextBox2.Text + "')", conex)
                        Dim busqueda = comando.ExecuteNonQuery
                    Catch ex As Exception
                        MsgBox("ERROR: " + ex.Message)
                        TextBox1.Text = ""
                        TextBox2.Text = ""
                        TextBox3.Text = ""
                        TextBox4.Text = ""
                    End Try
                Else
                    MsgBox("ERROR, Las contraseñas no coinciden")
                End If
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            ' Mostrar contraseña
            TextBox3.PasswordChar = ""
        Else
            'Ocultar contraseña
            TextBox3.PasswordChar = "X"
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            ' Mostrar contraseña
            TextBox4.PasswordChar = ""
        Else
            'Ocultar contraseña
            TextBox4.PasswordChar = "X"
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim comando = New MySqlCommand("SELECT * FROM usuarios;", conex)
        Dim resultado = comando.ExecuteReader
        While (resultado.Read)
            MsgBox("username:" + resultado("username"))
        End While
        resultado.Close()

    End Sub
End Class