
# Integração API REST

Aplicação desenvolvida em ASP.NET com padrão MVC com o intuito de desenvolver endpoints para realizar um CRUD com uma API REST gratuita,
utilizando a entidade cliente com um banco de dados local em txt para testes.

## Interface

Tela com a lista de clientes cadastrados
![02](https://user-images.githubusercontent.com/74942532/139539417-305f1b4f-db41-4a24-aa3a-a268edba6e25.png)

Tela de cadastro e alteração dos dados do clientes
![003](https://user-images.githubusercontent.com/74942532/139539433-ee4aaf6e-b545-45ba-9eff-73edac35e33e.png)

## Quais são as funções?

Fazer um CRUD com a API `crudcrud` e salvar as informações em um banco de dados local em txt.

## API REST

### Como criar um endpoint na API

Acesse o site https://crudcrud.com e seu endpoint já estará criado e pronto para uso.

![001](https://user-images.githubusercontent.com/74942532/139539612-2ec720cd-b857-4cb3-83fa-3d7728c9a38d.png)

### Pontos a se destacar

O endpoint tem duração de 24 horas para testes, podendo fazer 100 requests.

![01](https://user-images.githubusercontent.com/74942532/139539616-aaec25ed-c4d7-4ecd-ac78-07a7a6d42ad6.png)

## Antes de rodar o projeto

Alterar as constantes dentro dos arquivos:

#### `/Models/Cliente.cs`
constante: "DIRETORIO_BD", com o diretório completo até o arquivo txt

#### `/HUB/Integracao.cs`
constante: "ENDPOINT", com o id criado no site https://crudcrud.com

logo após as alterações, tudo pronto para executar o projeto.

#### Observação

Dentro dos respectivos arquivos tem toda informação para alterar o que for necessário para o funcionamento.

## Sobre

Integração desenvolvida utilizando as seguintes tecnologias: Visual Studio (ASP.NET), Bootstrap e Newtonsoft (Json).
