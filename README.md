# Lead Management API 📊

## :dart: Sobre

A Lead Management API é um projeto desenvolvido como parte do processo seletivo para a posição de Desenvolvedora C# na Ploomes. O objetivo é criar uma API para gerenciar leads, permitindo a criação, atualização, consulta e exclusão de informações relacionadas a potenciais clientes.

## :clipboard: Funcionalidades principais

- **Cadastro de Leads:** Permite o registro de novas leads com informações como empresa, nome do contato principal, e-mail, telefone, estágio do lead, data/hora de criação e atualização. Cada lead recebe um ID único no sistema.

- **Consulta de Leads:** Oferece a capacidade de consultar todas as leads cadastradas ou buscar uma lead específica pelo seu ID.

- **Atualização de Leads:** Possibilita a atualização das informações de uma lead existente, como alteração de e-mail, telefone ou empresa.

- **Exclusão de Leads:** Permite a remoção de uma lead do sistema com base no seu ID.

## :woman_technologist: Conhecimentos aplicados

- **Linguagem de Programação:** C#
- **Framework:** ASP.NET Core
- **Banco de Dados:** Entity Framework Core com SQL Server
  
## ⚙️ Como Executar

1. Clone o repositório em uma pasta de sua preferência
```
git clone git@github.com:julianaando/LeadManagementApi.git
```

2. Entre na pasta que você acabou de clonar e execute o Docker Compose para subir o container
```
docker-compose up --build
```
#### Acesse a aplicação localmente através da URL http://localhost:8080/

#### Ou através do link Azure https://leadmanagementapi-ploomes.azurewebsites.net/index.html
Você será direcionado à interface do Swagger, onde poderá explorar e testar os endpoints da API.

## 📚 Documentação (endpoints)

### :pencil: Leads

<details>
<summary> Cadastro (POST) </summary>
  <br>

| Método | Funcionalidade | URL |
|---|---|---|
| `POST` | Realiza o cadastro de uma nova lead | `http://localhost:8080/leads`

<details>
  <summary> A estrutura do corpo da requisição deve seguir o padrão abaixo: </summary>

  ```json
  {
    "CompanyName": "String",
    "PrimaryContactName": "String",
    "PrimaryContactEmail": "String",
    "PrimaryContactPhone": "String"
  }
  ```
</details>

<details>
  <summary> Um exemplo de resposta bem-sucedida com <code>status 201</code> é: </summary>
  
  ```json
  {
  "Id": 1,
  "CompanyName": "ABC Corp",
  "PrimaryContactName": "João Silva",
  "PrimaryContactEmail": "joao@example.com",
  "PrimaryContactPhone": "+55 11 1234-5678",
  "LeadStage": "CREATED",
  "CreatedAt":  "20-02-2024 18:56:33",
  "UpdatedAt":  "20-02-2024 18:56:33"
}
```
</details>

:x:  A requisição irá falhar se algum dos atributos não for preenchido corretamente ou estiver ausente.<br>
O endpoint retornará um erro <code>400</code> com uma mensagem referente. Exemplo: <code>{ "CompanyName is required" }</code><br>

</details>
<details>
<summary> Consultas (GET) </summary>
  <br>
| Método | Funcionalidade | URL |
|---|---|---|
| `GET` | Consulta todas as leads cadastradas | `http://localhost:8080/leads`

<details>
 <summary>  Um exemplo de resposta bem-sucedida com <code>status 200</code> é: </summary>
 
```json
[
  {
    "Id": 1,
    "CompanyName": "ABC Corp",
    "PrimaryContactName": "João Silva",
    "PrimaryContactEmail": "joao@example.com",
    "PrimaryContactPhone": "+55 11 1234-5678",
    "LeadStage": "CREATED",
    "CreatedAt": "20-02-2024 18:56:33",
    "UpdatedAt": "20-02-2024 18:56:33"
  },
  // Outras leads...
]
```
</details>
:x:&nbsp;&nbsp;A requisição irá falhar se não houver, pelo menos, uma lead cadastrada.<br>
O endpoint retornará um erro <code>400</code> com a mensagem: <code>{ "Lead" }</code>
<br>
---
| Método | Funcionalidade | URL |
|---|---|---|
| `GET` | Realiza a consulta de uma lead pelo seu ID | `http://localhost:8080/leads/{id}`
<details>
  
  <summary>  Um exemplo de resposta bem-sucedida com <code>status 200</code> é: </summary>
  
  ```
  {
    "Id": 1,
    "CompanyName": "ABC Corp",
    "PrimaryContactEmail": "joao@example.com",
    "PrimaryContactPhone": "+55 11 1234-5678",
    "PrimaryContactName": "João Silva",
    "LeadStage": "PROSPECTING",
    "CreatedAt": "20-02-2024 18:56:33",
    "UpdatedAt": "20-02-2024 18:56:33"
  }
```
</details>
</details>

<details>
  <summary> Atualização (PUT) </summary>
    <br>

  | Método | Funcionalidade | URL |
  |---|---|---|
  | `PUT` | Atualiza as informações de uma lead existente | `http://localhost:8080/leads/{id}`
  
  <details>
    
  > :warning: &nbsp; _Todos os atributos devem ser fornecidos, mesmo que não haja alteração_

  <summary> A estrutura do body da requisição deve seguir o padrão do exemplo abaixo: </summary>
  
    {
      "CompanyName": "Novo Nome da Lead",
      "PrimaryContactEmail": "novo@example.com",
      "PrimaryContactPhone": "+55 11 9876-5432",
      "PrimaryContactName": "Novo Nome da Lead",
      "LeadStage": "PROSPECTING"
    }
  
  </details>
  
  <details>
    <summary>  Um exemplo de resposta bem-sucedida com <code>status 200</code> é: </summary>
  
    {
      "Id": 1,
      "CompanyName": "Novo Nome da Lead",
      "PrimaryContactEmail": "novo@example.com",
      "PrimaryContactPhone": "+55 11 9876-5432",
      "PrimaryContactName": "Novo Nome da Lead",
      "LeadStage": "PROSPECTING",
      "CreatedAt": "20-02-2024 18:56:33",
      "UpdatedAt": "22-02-2024 09:34:12"
    }
  </details>

  :x:&nbsp;&nbsp; A requisição irá falhar se algum dos atributos não for preenchido corretamente ou estiver ausente.<br> 
  O endpoint retornará um erro <code>400</code> com uma mensagem referente. Exemplo: <code>{ "Lead {id} not found" }</code>
  
  > :warning: &nbsp; _O campo `leadStage` deve ser um dos seguintes valores: "INITIAL", "CREATED", "PROSPECTING", "QUALIFICATION", "PROPOSAL", "NEGOTIATION", "CLOSED"._
  <br>
</details>

<details>
  <summary> Exclusão (DELETE) </summary>
    <br>
  
  | Método | Funcionalidade | URL |
  |---|---|---|
  | `DELETE` | Remove uma lead existente | `http://localhost:8080/leads/{id}`
  
  -&nbsp;&nbsp;&nbsp;Para deletar uma lead, especifique o `id` desejado na URL, conforme mostrado acima. Não é necessário incluir um corpo de requisição, pois a ação de exclusão é baseada no `id` fornecido.

 - Uma exclusão bem sucedida retornará um <code>status 204</code> sem conteúdo <code>No Content</code>

- O endpoint retornará um erro <code>400</code> com uma mensagem referente. Exemplo: <code>{ "Lead {id} not found" }</code>
 </details>
