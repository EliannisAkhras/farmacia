Imports MySql.Data
Imports MySql.Data.MySqlClient
Module Conexion

    Public conex As MySqlConnection
    Sub conectar()
        Dim conestr = "Server = localhost; Database = farmacia; Port = 3306; user id = root; password = ;"
        Try
            conex = New MySqlConnection(conestr)
            conex.ConnectionString = conestr
            conex.Open()
            MsgBox("Conexion exitosa!!!")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module
