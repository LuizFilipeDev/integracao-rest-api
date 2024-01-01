
# integration API REST

Application developed in ASP.NET with MVC standard with the aim of developing endpoints to perform a CRUD with a free REST API,
using the client entity with a local database in txt for testing.

## Interface

Screen with the list of registered customers
![02](https://user-images.githubusercontent.com/74942532/139539417-305f1b4f-db41-4a24-aa3a-a268edba6e25.png)

Screen for registering and changing customer data
![003](https://user-images.githubusercontent.com/74942532/139539433-ee4aaf6e-b545-45ba-9eff-73edac35e33e.png)

## What are the functions?

Perform a CRUD with the `crudcrud` API and save the information in a local database in txt.

## API REST

### How to create an API endpoint

Access the website https://crudcrud.com and your endpoint will be created and ready to use.

![001](https://user-images.githubusercontent.com/74942532/139539612-2ec720cd-b857-4cb3-83fa-3d7728c9a38d.png)

### Points to highlight

The endpoint lasts 24 hours for testing, and can make 100 requests.

![01](https://user-images.githubusercontent.com/74942532/139539616-aaec25ed-c4d7-4ecd-ac78-07a7a6d42ad6.png)

## Before running the project

Change constants within files:

#### `/Models/Cliente.cs`
constant: "DIRETORIO_BD", with the complete directory up to the txt file

#### `/HUB/Integracao.cs`
constant: "ENDPOINT", with the id created on the website https://crudcrud.com

Right after the changes, everything is ready to execute the project.

#### Observation

Within the respective files there is all the information to change whatever is necessary for operation.

## About

Integration developed using the following technologies: Visual Studio (ASP.NET), Bootstrap and Newtonsoft (Json).
