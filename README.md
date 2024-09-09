# Backend Challenge - Pokémons

This is a project developed for a backend challenge by Coodesh. It focuses on providing an API that interacts with Pokémon data.

## Descrição

Este projeto foi desenvolvido como parte de um desafio técnico proposto pela Coodesh. Ele implementa uma API em .NET Core para fornecer informações sobre Pokémons, além de operações como busca e filtragem.

## Tecnologias

- ASP.NET Core
- Entity Framework Core
- SQLite
- Swagger para documentação da API

## Pré-requisitos

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- Opcional: Docker para execução da aplicação

## Instalação

1. Clone o repositório:

```bash
git clone https://github.com/Haltt/Coodesh-Pokemon.git
cd Coodesh-Pokemon
```

2. Configure o banco de dados no arquivo appsettings.json:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=pokemonDB.db"
  }
}
```

3. Execute as migrações para configurar o banco de dados:
```bash
dotnet ef database update
dotnet run
```

4. Acesse a documentação da API (Swagger) através do endereço:
http://localhost:5000/api

### Executando com Docker
Para utilizar Docker, você pode rodar o seguinte comando:

```bash
docker-compose up --build
```

### Testes
Para executar os testes unitários, siga os passos abaixo:

Verifique se as dependências estão instaladas e se o banco de dados de teste está configurado corretamente no appsettings.json da camada de testes.

Abra o terminal na pasta raiz do projeto e execute o comando de teste:

```bash
dotnet test
```

Este comando irá executar todos os testes definidos no projeto.

Os testes de unidade estão localizados na pasta Coodesh-Pokemon.Tests, onde você pode encontrar casos de testes para verificar o funcionamento correto dos endpoints e serviços da API.

Se você estiver utilizando o Docker, certifique-se de que os containers estão rodando antes de executar os testes.

>  This is a challenge by [Coodesh](https://coodesh.com/)