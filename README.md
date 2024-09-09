# Backend Challenge - Pok�mons

## Introdu��o
>  This is a challenge by [Coodesh](https://coodesh.com/)

Backend Challenge - Pok�mons
Teste da Codesh para testar habilidades de Front Developer

## Instru��es
1 - Clonar o reposi~t�rio para sua m�quima, em seguida sugiro criar uma nova branch para evitar perdas dos arquivos originais.
2 - Abrir o projeto no Visual Studio (ou progrma compat�vel)
3 - Dentro do Visual Studio executar o projeto

### O Projeto
- O Projeto tem uma Home contendo: 
	- link para API
	- Busca por ID (N�mero do Pok�mon)
		- 1 e 898 - n�mero de Pok�mons atualmente na PokeAPI (05/09/2024)
	- Busca aleat�ria de 10 Pok�mons
	- Cria��o do Mestre Pok�mon
	- Capturar um Pok�mon como Mestre

## Front-end

### Home
- Buscar Pok�mon por ID (N�mero do Pok�mon)
	- 1 e 898 - n�mero de Pok�mons atualmente na PokeAPI (05/09/2024)
- Gerar 12 Pok�mons aleat�rios
- Criar um Mestre Pok�mon
- Capturar um Pok�mon

### Privacidade
- Redireciona para essa p�gina explicando o que � o projeto

### API
- Redireciona para p�gina contendo as APIs usadas no Projeto

## Backend-end
Agora, voc� pode testar a API usando ferramentas como Postman ou cURL:

### Buscar Pok�mon espec�fico

### Buscar 12 Pok�mons de forma aleat�ria

### Cria��o do Mestre:
- Recebe Nome, Idade e CPF do Mestre

GET /api/PokemonMasters: Lista todos os mestres Pok�mon.
GET /api/PokemonMasters/{id}: Obt�m um mestre Pok�mon pelo ID.
POST /api/PokemonMasters: Cria um novo mestre Pok�mon.
PUT /api/PokemonMasters/{id}: Atualiza um mestre Pok�mon existente.
DELETE /api/PokemonMasters/{id}: Exclui um mestre Pok�mon pelo ID.

### Captura do Pok�mon:
- Recebe o CPF do mestre Pok�mon.
- Verifica no banco de dados se o mestre Pok�mon existe.
- Escolhe um Pok�mon de forma aleat�ria entre 1 e 899.
- Cria uma nova captura no banco de dados e vincula ao mestre.

POST /api/PokemonCaptures/capture: Cria uma nova captura de Pok�mon.

### Criar e Aplicar as Migra��es
Ap�s a cria��o dos arquivos de modelo do Mestre Pok�mon (PokemonMaster.cs) aplicar as migra��es a baixo para cria��o da base de dados.

```shell
dotnet ef migrations add InitialCreate
dotnet ef database update
```
