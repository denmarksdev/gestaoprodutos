Public Class GridTemplate

    ''' <param name="titulo"> {plural,singular} </param>
    Public Shared Function GetRodape(titulo() As String, numeroItens As Integer, filtroAtivo As Boolean) As String

        Dim strTitulo = "Nenhum produto cadastrado"
        Dim strNumero = numeroItens.ToString()

        Select Case numeroItens
            Case 0
                strNumero = String.Empty
            Case 1
                strTitulo = titulo(0)
            Case Else
                strTitulo = titulo(1)
        End Select

        Dim template =
            <div>
                <span><strong><%= strNumero %></strong><%= strTitulo %></span>
                <span style="color:red;"><%= If(filtroAtivo, "Filtro ativo", "") %></span>
            </div>.ToString()

        Return template

    End Function

End Class