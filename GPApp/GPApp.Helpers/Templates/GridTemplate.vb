Public Class GridTemplate

    ''' <param name="titulo"> {plural,singular} </param>
    Public Shared Function GetRodape(titulo() As String, numeroItens As Integer) As String

        Dim strTitulo = String.Empty

        Select Case numeroItens
            Case 1
                strTitulo = titulo(0)
            Case Else
                strTitulo = titulo(1)
        End Select

        Dim template =
            <div>
                <span><strong><%= numeroItens %></strong><%= strTitulo %></span>
            </div>.ToString()

        Return template

    End Function

End Class