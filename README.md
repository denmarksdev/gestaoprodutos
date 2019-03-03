# Gestão de Produtos
Sistema de cadastro de produtos utilizando conhecimentos em C#, Angular 2+ e ASPNET.CORE

# Visão geral

![](https://github.com/denmarksdev/gestaoprodutos/blob/master/Docs/GPApp.jpg?raw=true "Gestão de produtos APP")

# Requerimentos

- [NPM 6.4.1](https://www.npmjs.com/)
- [Angular CLI 7.2.2](https://cli.angular.io/) 
- [NET Standard 2.0]( https://docs.microsoft.com/pt-br/dotnet/standard/net-standard) 
- [NET Framework 4.6](https://www.microsoft.com/pt-br/download/details.aspx?id=48137)
- [NET Core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)
- [Visual Studio 2017+](https://visualstudio.microsoft.com/pt-br)
- [Visual studio code](https://code.visualstudio.com/) para programação do client em Angular(sugestão)
- [Opcional] [SqlServer](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads), [Postgresql](https://www.postgresql.org/)

# Uso

1. Para facilitar a execução do projeto, todas as plataformas estão configuradas para utilizar o **SQLite** 
1. Em **GPApp.Web** na pasta client executar o comando `npm i` para instalar todos as dependências do projeto em **Angular**
1. No **visual Studio 2017+** botão direito do mouse na solução e escolher a opção **Restore Nuget Packages**
1. Novamente botão direito do mouse na solução em **properties > Commom Properties > Startup Project** selecione a opção **Multiple startup projects**, marcar a **Action** como **Start** nos projetos **GPApp.UWP, GPApp.WPF, GPApp.WEB e GPApp.WinForms**

# Configuração da base dados SqlServer e Postgresql

## ASP.Net Core
- **appsettings.json** e **Startup.cs** no método **ConfiguraBaseDados** 
### Windows Forms
- **app.config** e **Bootstrapper.cs** no método **start**
### WPF 
- **app.config** e **SplashScreenViewModel** no método **OnNavigatedTo**
### UWP
- **Configuracao.resw** e **App.xaml** no método **OnLaunchApplicationAsync** 

## Referências

- [Mark Heath - **Windows Forms Best Practices**]( https://www.pluralsight.com/courses/windows-forms-best-practices)
- [Thomas Claudius Huber - **WPF and MVVM: Test Driven Development of ViewModels** ](https://www.pluralsight.com/courses/wpf-mvvm-test-driven-development-viewmodels) 
- [Debora Kurata - **Defensive Coding in C#**](https://www.pluralsight.com/courses/defensive-coding-csharp)
- [Flávio de Almeida - **Carreira Angular Alura**](https://cursos.alura.com.br/career/angular)
- [Daniel Jacobson - **Building Cloud Connected UWP**](https://www.lynda.com/Windows-tutorials/Welcome/570960/591566-4.html?srchtrk=index%3a1%0alinktypeid%3a2%0aq%3aUWP%0apage%3a1%0as%3arelevance%0asa%3atrue%0aproducttypeid%3a2)
- [Google - **Angular Material**](https://material.angular.io/)
- [Dennis Magno - **Metro Modern UI**](http://denricdenise.info/)
- [Ignace Maes - **MaterialSkin**](https://github.com/IgnaceMaes/MaterialSkin)
- [James Willock - **MaterialDesignThemes**](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit)
- [Brian Lagunas - **Prism Library** ](https://prismlibrary.github.io/) 
- [Microsoft.Toolkit - **Microsoft.Toolkit.Uwp.UI.Controls**](https://github.com/windows-toolkit/WindowsCommunityToolkit)
- [Daniel Cazzulino, kzu - **Moq4**](https://github.com/moq/moq4)
- [James Newkirk, Brad Wilson - **XUnit**](https://github.com/xunit/xunit)
