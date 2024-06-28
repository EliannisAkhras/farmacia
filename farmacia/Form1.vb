Imports MySql.Data.MySqlClient
Imports Mysqlx.Expect.Open.Types
Imports MySql.Data
Public Class Form1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        quererregistrar.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox2.PasswordChar = ""
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call conectar()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            ' Mostrar contraseña
            TextBox1.PasswordChar = ""
        Else
            'Ocultar contraseña
            TextBox1.PasswordChar = "X"
        End If
    End Sub

    Public comand As New MySqlConnection
    Public seleccion As MySqlCommand = New MySqlCommand
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Then
            MsgBox("ERROR, faltan datos")
        Else
            Try
                Dim comando = New MySqlCommand("SELECT * FROM usuarios WHERE username = '" + TextBox2.Text + "';", conex)
                Dim resultado = comando.ExecuteReader
                resultado.Read()
                If (resultado.HasRows) Then
                    If (TextBox1.Text = resultado("password")) Then

                        MsgBox("El nombre es: " + resultado("username"))

                    End If
                Else
                    MsgBox("ERROR, el usuario no existe")
                End If
                resultado.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub


End Class
