# Symptom Libary

</br>

Sistema desenvolvido para catalogar doenças com seus respectivos sintomas.

Foi criado um projeto Api Rest, utilizando os seguintes recursos:

- Frameworks/Bibliotecas: .Net Core, MSTest, Flunt, Entity Framework
- Arquetetura: Hexagonal
- Cloud: Azure
- Documentação: Swagger
- Banco de dados: MongoDB
- CI/CD: Github Actions

Funcionalidades implementadas:

- Cadastro de sintomas;
- Cadastro de doenças;
- Consulta de doenças através dos sintomas;

</br>

# Frameworks/Bibliotecas

## .Net Core

- Versão utilizada: 3.1

.NET é um framework livre e de código aberto para os sistemas operacionais Windows, Linux e macOS.

---

## MSTest

- Versão utilizada: 3.1

A Estrutura de Teste de Unidade do Visual Studio descreve o conjunto de ferramentas de teste de unidade da Microsoft, integrado a algumas versões do Visual Studio 2005 e posterior.

---

## Flunt

- Versão utilizada: 2.5

O Flunt é uma maneira fluente de usar o Notification Pattern com suas entidades, concentrando todas as alterações feitas e facilitando o acesso quando você precisar.

---

## Entity Framework

- Versão utilizada: 3.1

Entity Framework é uma das principais ferramentas de persistência presentes na plataforma .NET, sendo parte integrante do pacote de tecnologias ADO.NET.

</br>

# Aquitetura

## Hexagonal

A arquitetura hexagonal, ou arquitetura de portas e adaptadores, é um padrão arquitetural usado no design de software. O objetivo é criar componentes de aplicativos fracamente acoplados que possam ser facilmente conectados ao ambiente de software por meio de portas e adaptadores.

</br>

# Cloud

## Azure

O Microsoft Azure é uma plataforma destinada à execução de aplicativos e serviços, baseada nos conceitos da computação em nuvem.

</br>

# Documentação

## Swagger

Swagger é um conjunto de ferramentas de desenvolvedor de API da SmartBear Software e uma especificação anterior na qual a especificação OpenAPI é baseada

</br>

# Banco de dados

## MongoDB

MongoDB é um software de banco de dados orientado a documentos livre, de código aberto e multiplataforma, escrito na linguagem C++.

</br>

# CI/CD

## Github Actions

GitHub Actions é uma plataforma de integração contínua e entrega contínua (CI/CD) que permite automatizar a sua compilação, testar e pipeline de implantação. É possível criar fluxos de trabalho que criam e testam cada pull request no seu repositório, ou implantar pull requests mesclados em produção.

</br>

# Como executar o projeto ?

- Primeiramente deve-se verificar se o computador ao qual deseje executar o projeto possui a versão 3.1 do .Net Core instalada e o MongoDB instalado.

</br>

## Visual Studio Code

Após realizar o clone do projeto em sua maquina, abra um novo terminal e navegue ate o localao qual realizou o clone do projeto e navegue ate a pasta Backend execute o seguinte comando

 ~~~ csharp
dotnet run
~~~

# Visual Studio

Após realizar o clone do projeto em sua maquina, vá até a pasta do projeto abra a solução e aperte F5 para iniciar o projeto.