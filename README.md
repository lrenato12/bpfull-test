# Cliente API - Sistema de Cadastro

## Visão Geral
Este projeto é uma API para cadastro e gerenciamento de clientes, permitindo operações como criação e leitura de clientes. A API segue os padrões REST e utiliza .NET no backend com Angular no frontend.

## Tecnologias Utilizadas
- **Backend**: .NET Core
- **Frontend**: Angular
- **Banco de Dados**: SQL Server
- **ORM**: Dapper
- **Padrão de Projeto**: Unit of Work e Repository Pattern
- **Injeção de Dependência**: Configurada no `Program.cs`

## Estrutura do Projeto

### Backend
```
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
```

### Frontend
```
├── ClienteApp
│   ├── src
│   │   ├── app
│   │   │   ├── components
│   │   │   ├── services
│   │   │   ├── models
│   │   │   ├── app.module.ts
│   │   │   ├── app.component.ts
```

## Instalação e Configuração

### Backend (.NET Core API)
1. Clone o repositório:
   ```sh
   git clone https://github.com/seu-usuario/seu-repositorio.git
   ```
2. Acesse a pasta do backend:
   ```sh
   cd Cliente.API
   ```
3. Instale as dependências:
   ```sh
   dotnet restore
   ```
4. Configure a string de conexão no `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=SEU_SERVIDOR;Database=SEU_BANCO;User Id=SEU_USUARIO;Password=SUA_SENHA;"
   }
   ```
5. Execute as migrações e inicialize o banco de dados:
   ```sh
   dotnet ef database update
   ```
6. Execute a API:
   ```sh
   dotnet run
   ```

### Frontend (Angular)
1. Acesse a pasta do frontend:
   ```sh
   cd ClienteApp
   ```
2. Instale as dependências:
   ```sh
   npm install
   ```
3. Execute o frontend:
   ```sh
   ng serve
   ```

## Endpoints da API
### Criar Cliente
**POST** `/api/clientes`
```json
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
```

### Listar Clientes
**GET** `/api/clientes`

## Principais Funcionalidades
- Cadastro e validação de clientes
- Persistência no banco de dados com Dapper
- Padrão Unit of Work para gerenciar transações
- Formatação de CPF e CNPJ antes da exibição
- Injeção de dependência configurada no `Program.cs`

## Contribuição
1. Fork este repositório
2. Crie uma branch para sua feature:
   ```sh
   git checkout -b minha-feature
   ```
3. Commit suas alterações:
   ```sh
   git commit -m "Adicionando minha feature"
   ```
4. Envie para o repositório remoto:
   ```sh
   git push origin minha-feature
   ```
5. Abra um Pull Request

## Contato
Para dúvidas ou sugestões, entre em contato via email: `renatim9100@gmail.com`

