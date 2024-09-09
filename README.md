# Backend Challenge - Pokémons

## Introdução
>  This is a challenge by [Coodesh](https://coodesh.com/)

Backend Challenge - Pokémons
Teste da Codesh para testar habilidades de Front Developer

## Instruções
1 - Clonar o reposi~tório para sua máquima, em seguida sugiro criar uma nova branch para evitar perdas dos arquivos originais.
2 - Abrir o projeto no Visual Studio (ou progrma compatível)
3 - Dentro do Visual Studio executar o projeto

### O Projeto
- O Projeto tem uma Home contendo: 
	- link para API
	- Busca por ID (Número do Pokémon)
		- 1 e 898 - número de Pokémons atualmente na PokeAPI (05/09/2024)
	- Busca aleatória de 10 Pokémons
	- Criação do Mestre Pokémon
	- Capturar um Pokémon como Mestre

## Front-end

### Home
- Buscar Pokémon por ID (Número do Pokémon)
	- 1 e 898 - número de Pokémons atualmente na PokeAPI (05/09/2024)
- Gerar 12 Pokémons aleatórios
- Criar um Mestre Pokémon
- Capturar um Pokémon

### Privacidade
- Redireciona para essa página explicando o que é o projeto

### API
- Redireciona para página contendo as APIs usadas no Projeto

## Backend-end
Agora, você pode testar a API usando ferramentas como Postman ou cURL:

### Buscar Pokémon específico

### Buscar 12 Pokémons de forma aleatória

### Criação do Mestre:
- Recebe Nome, Idade e CPF do Mestre

GET /api/PokemonMasters: Lista todos os mestres Pokémon.
GET /api/PokemonMasters/{id}: Obtém um mestre Pokémon pelo ID.
POST /api/PokemonMasters: Cria um novo mestre Pokémon.
PUT /api/PokemonMasters/{id}: Atualiza um mestre Pokémon existente.
DELETE /api/PokemonMasters/{id}: Exclui um mestre Pokémon pelo ID.

### Captura do Pokémon:
- Recebe o CPF do mestre Pokémon.
- Verifica no banco de dados se o mestre Pokémon existe.
- Escolhe um Pokémon de forma aleatória entre 1 e 899.
- Cria uma nova captura no banco de dados e vincula ao mestre.

POST /api/PokemonCaptures/capture: Cria uma nova captura de Pokémon.

### Criar e Aplicar as Migrações
Após a criação dos arquivos de modelo do Mestre Pokémon (PokemonMaster.cs) aplicar as migrações a baixo para criação da base de dados.

```shell
dotnet ef migrations add InitialCreate
dotnet ef database update
```
