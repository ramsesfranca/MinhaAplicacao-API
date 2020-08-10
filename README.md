# Minha Aplicação - Ramsés França

# Descrição da solução
Foram desenvolvidas 1 solutions (.sln) e dois projetos (MinhaAplicacao_API - projeto da API) e (MinhaAplicacao_Cliente - projeto cliente/front-end) para demonstrar o devido isolamento entre a API e o front-end.

# Projeto MinhaAplicacao_API (API)
Foi desenvolvida utilizando ASP.NET Core Web API 3.1 e EF Core com Code-first + Migrations. Para persitência dos dados foi utilizado SQL Server 2017.

Dentre as biliotecas utilizadas estão:

- AutoMapper
- FluentValidation

# Projeto MinhaAplicacao_Cliente (Cliente/front-end)
Foi desenvolvida utilizando ASP.NET MVC Core 3.1

# Instruções de execução

Todas as dependências dos projetos foram utilizadas com base em pacotes NuGet, sendo necessário apenas o build assim que as solutions sejam abertas.

Foi criando um script para criação do banco (MinhaAplicacao-API\sql\Script_Criacao_Banco.sql)

Como foi utilizado Code-first com Migrations, para geração da base de dados basta executar o comando Update-Database na CLI do Visual Studio, apontando para o projeto que contém o MinhaAplicacaoDbContext (MinhaAplicacao.Infraestrutura). O programa se encarregará de ler as Migrations e criar as tabelas na base de dados. A connection string aponta para a base MinhaAplicacao numa instância local do SQL Server.

# Documentação da API
