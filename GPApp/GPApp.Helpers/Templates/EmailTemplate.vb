Public Class EmailTemplate

    Public Shared Function GetEmailMarketing(Optional urlBase As String = "http://localhost:51670") As String

        Dim urlPropaganda = urlBase + "/api/v1/produto/email/email"

        Dim html =
                <html lang="br">
                    <head>
                        <meta charset="UTF-8"/>
                        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
                        <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
                        <title>Document</title>
                    </head>
                    <body>
                        <h1>Teste</h1>
                        <img width="0" height="0" alt="Email" src=<%= """" + urlPropaganda + """" %>></img>
                        <a href=<%= """" + urlPropaganda + """" %>>Visitar</a>
                    </body>
                    <script>
                        var h1 =  document.getElementById("emailtrack");
                        var img = document.createElement("img");
                        h1.addEventListener('click', ()=> {
                            img.src = <%= """" + urlPropaganda + """" %>
                        });
                    </script>
                </html>

        Return "<!DOCTYPE html>" + html.ToString()

    End Function

End Class