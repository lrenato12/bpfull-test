Cliente API - Sistema de Cadastro

Visão Geral

Este projeto é uma API para cadastro e gerenciamento de clientes, permitindo operações como criação e leitura de clientes. A API segue os padrões REST e utiliza .NET no backend com Angular no frontend.

Tecnologias Utilizadas

Backend: .NET Core

Frontend: Angular

Banco de Dados: SQL Server

ORM: Dapper

Padrão de Projeto: Unit of Work e Repository Pattern

Injeção de Dependência: Configurada no Program.cs

Estrutura do Projeto

Backend

├── Cliente.API
│   ├── Controllers
│   ├── Models
│   ├── Services
│   ├── Repositories
│   ├── DataAccess
│   ├── Validators
│   ├── Interfaces
│   ├── Program.cs
│   ├── Startup.cs

Frontend

├── ClienteApp
│   ├── src
│   │   ├── app
│   │   │   ├── components
│   │   │   ├── services
│   │   │   ├── models
│   │   │   ├── app.module.ts
│   │   │   ├── app.component.ts

Instalação e Configuração

Backend (.NET Core API)

Clone o repositório:

git clone https://github.com/seu-usuario/seu-repositorio.git

Acesse a pasta do backend:

cd Cliente.API

Instale as dependências:

dotnet restore

Configure a string de conexão no secrets da API:

"ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=SEU_BANCO;User Id=SEU_USUARIO;Password=SUA_SENHA;"
}

Execute as migrações e inicialize o banco de dados:

dotnet ef database update

Execute a API:

dotnet run

Frontend (Angular)

Acesse a pasta do frontend:

cd ClienteApp

Instale as dependências:

npm install

Execute o frontend:

ng serve

Endpoints da API

Criar Cliente

POST /api/clientes

{
    "nome": "Luiz Renato",
    "email": "renatim9100@gmail.com",
    "telefone": "16991950410",
    "documento": "87535434534535",
    "cep": "14305070",
    "endereco": "Rua X",
    "bairro": "Centro",
    "cidade": "Batatais",
    "estado": "SP",
    "pais": "Brasil"
}

Listar Clientes

GET /api/clientes

Principais Funcionalidades

Cadastro e validação de clientes

Persistência no banco de dados com Dapper

Padrão Unit of Work para gerenciar transações

Formatação de CPF e CNPJ antes da exibição

Injeção de dependência configurada no Program.cs

Contribuição

Fork este repositório

Crie uma branch para sua feature:

git checkout -b minha-feature

Commit suas alterações:

git commit -m "Adicionando minha feature"

Envie para o repositório remoto:

git push origin minha-feature

Abra um Pull Request

Contato

Para dúvidas ou sugestões, entre em contato via email: renatim9100@gmail.com
