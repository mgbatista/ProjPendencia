# ProjPendencia
Atividade com exemplo de implementacao de testes unitarios

ProjTravelUnitTest
Criar a solução:

Dentro do diretório: \ProjTravelUnitTest:

dotnet new sln

Criar os projetos:

dotnet new webapi -o ProjTravelUnitTest.Api

dotnet new xunit -o ProjTravelUnitTest.Tests

Adicionando projetos a solução:

dotnet sln .\ProjTravelUnitTest.sln add .\ProjTravelUnitTest.Api
dotnet sln .\ProjTravelUnitTest.sln add .\ProjTravelUnitTest.Tests\

Criar o controller + Context:

dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet add package Microsoft.EntityFrameworkCore.SqlServer

dotnet tool install -g dotnet-aspnet-codegenerator

dotnet aspnet-codegenerator controller -name ClientController -async -api -m Client -dc ClientContext -outDir Controllers

Gerar Tabelas:

dotnet tool install --global dotnet-ef

dotnet ef migrations add v1

dotnet ef database update

Executar o Projeto Api:

dotnet run --project .\ProjTravelUnitTest.Api\

PARA VALIDAÇÃO DOS TESTES: Visual Studio (Facilidade para validar)

Repositório do professor que passou o exemplo: https://github.com/aannddrree/ProjTravelUnitTest
