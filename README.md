# EasyMenu

APIRest para gestão de cardápios digitais


## 🚀 Começando

Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.


## 📋 Pré-requisitos


### 🛠️ Ferramentas

```
Visual Studio 2022
```
```
Git
```
```
SQL server management studio
```

### 💻 Tecnologias

```
.Net 7
```
```
C#
```
```
SQL Server
```
```
Entity Framework
```

## 🔧 Instalação

### 😎 API

Clone esse repositório em sua maquina local usando git bash:

```
git clone https://github.com/Luis-Henrique/EasyMenu
```

Abra a solução `EasyMenu.sln` usando Visual Studio 2022

Defina `EasyMenu.Api.Admin` como projeto de inicialização

![2023-07-16-22-44-49](https://github.com/Luis-Henrique/EasyMenu/assets/101938473/7a05bab7-0c0d-4580-bfd4-d45c913e3823)

Inicialize o projeto:

![2023-07-16-22-35-33](https://github.com/Luis-Henrique/EasyMenu/assets/101938473/41c4b8d7-6de8-40c5-b2ce-87fce12b5e2c)

### 🎲 DataBase

Para criar o banco utilize o arquivo `createDatabase.sql` salvo na pasta items

Configure sua string de conexação no arquivo `appsettings.json`

### ✨ Requisições 

#### Requisições via swagger

Na página do Swagger selecione a requisição desejada

Clique em tryOut se necessário passe os valores desejados via arquivo `json`

Depois clique em execute

Veja os detalhes da resposta na parte inferior

Demonstração:

![2023-07-16-22-49-16](https://github.com/Luis-Henrique/EasyMenu/assets/101938473/79116f0f-f91e-41e9-b509-cbb24c8684b8)

#### Requisições via postman

As requisições pelo postman deverão ser feitas via `body` utilizando formato `json`

Demonstração:

![2023-07-16-22-54-02](https://github.com/Luis-Henrique/EasyMenu/assets/101938473/1bf32b34-4b04-42ca-aa21-280bf4932200)

> **Warning**
> Caso o `Authorize` esteja ativado na controller, será necessário realizar a autorização do usúario e passar o token do login no header da requisição

`Authorize`

![image](https://github.com/Luis-Henrique/EasyMenu/assets/101938473/45c06c5f-a512-4c5e-862c-5121a2ff435f)

`Basic Auth`

![image](https://github.com/Luis-Henrique/EasyMenu/assets/101938473/8a2839a5-2c3c-490a-a354-b62801d4fb05)

`Token`

![image](https://github.com/Luis-Henrique/EasyMenu/assets/101938473/44db46f8-fa55-40aa-8347-271b746ec9a6)

### ⚙️ Executando os testes

*Em implementação*
