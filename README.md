# Backend Challenge - Pok�mons

This is a project developed for a backend challenge by Coodesh. It focuses on providing an API that interacts with Pok�mon data.

## Descri��o

Este projeto foi desenvolvido como parte de um desafio t�cnico proposto pela Coodesh. Ele implementa uma API em .NET Core para fornecer informa��es sobre Pok�mons, al�m de opera��es como busca e filtragem.

## Tecnologias

- ASP.NET Core
- Entity Framework Core
- SQLite
- Swagger para documenta��o da API

## Pr�-requisitos

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- Opcional: Docker para execu��o da aplica��o

## Instala��o

1. Clone o reposit�rio:

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

3. Execute as migra��es para configurar o banco de dados:
```bash
dotnet ef database update
dotnet run
```

4. Acesse a documenta��o da API (Swagger) atrav�s do endere�o:
http://localhost:5000/api

### Executando com Docker
Para utilizar Docker, voc� pode rodar o seguinte comando:

```bash
docker-compose up --build
```

### Testes
Para executar os testes unit�rios, siga os passos abaixo:

Verifique se as depend�ncias est�o instaladas e se o banco de dados de teste est� configurado corretamente no appsettings.json da camada de testes.

Abra o terminal na pasta raiz do projeto e execute o comando de teste:

```bash
dotnet test
```

Este comando ir� executar todos os testes definidos no projeto.

Os testes de unidade est�o localizados na pasta Coodesh-Pokemon.Tests, onde voc� pode encontrar casos de testes para verificar o funcionamento correto dos endpoints e servi�os da API.

Se voc� estiver utilizando o Docker, certifique-se de que os containers est�o rodando antes de executar os testes.

>  This is a challenge by [Coodesh](https://coodesh.com/)