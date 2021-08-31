# Copa dos Filmes

Sistema para gerenciamento da Copa dos Filmes, o maior campeonato de filmes do mundo.

## API

[![API](https://github.com/cassiofariasmachado/copa-filmes/actions/workflows/api.yml/badge.svg)](https://github.com/cassiofariasmachado/copa-filmes/actions/workflows/api.yml) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=copa-filmes-api&metric=alert_status)](https://sonarcloud.io/dashboard?id=copa-filmes-api)

### Estrutura da Solution

- **CopaFilmes.Api**: interface Rest da API, onde estão controllers, models e etc;
- **CopaFilmes.Domain**: domínio da aplicação, onde estão as regras de négocio;
- **CopaFilmes.Infra**: onde fica a integração com banco de dados, migrations, comunicação com outros sistemas e etc.

### Tecnologias

Foram utilizadas as seguintes tecnologias/bibliotecas:

- ASP.NET Core (5.0)
- Docker e Docker Compose

### Setup

Para executar o projeto execute os seguintes passos:

- [Instalação do .NET Core (5.0)](https://dotnet.microsoft.com/download)
- Instalação de uma IDE ou editor de texto compatível (recomendo o [VS Code](https://code.visualstudio.com/))
- Build/execução da aplicação
    - Utilizando _command line_

        ``` bash
        cd api/
        dotnet build # builda a solution
        dotnet test # executa os testes unitários

        cd src/CopaFilmes.Api
        dotnet run # executa o projeto da API
        ```

    - Utilizando o VS Code
        - Abrir projeto com o Code
        - Executar API no modo debug através do atalho F5


## APP 

[![APP](https://github.com/cassiofariasmachado/copa-filmes/actions/workflows/app.yml/badge.svg)](https://github.com/cassiofariasmachado/copa-filmes/actions/workflows/app.yml) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=copa-filmes-app&metric=alert_status)](https://sonarcloud.io/dashboard?id=copa-filmes-app)

### Arquitetura

A arquitetura do APP é simples. Trata-se de uma SPA desenvolvida utilizando React e React Router.

A estrutura de pastas está organizada da seguintes forma (src/):

- **components/:** componentes genéricos da aplicação;
- **config/:** abstração para acessar configurações do APP;
- **models/:** tipos utilizadas por todo APP (ex.: requests e responses da API, e etc);
- **routes/:** configurações de rotas do APP;
- **screens/:** páginas do APP;
- **services/:**
  - **api/:** comunicação com backend;
- **styles/:** estilos globais do APP;

### Tecnologias

Foram utilizadas as seguintes tecnologias/bibliotecas:

- TypeScript (4.1.2)
- React (17.0.2)
- React Router
- Axios
- Docker e Docker Compose

### Setup

Para executar o projeto execute os seguintes passos:

- [Instalação do Node (LTS 12.19.0)](https://nodejs.org/en/)
- Instalação de uma IDE ou editor de texto compatível (recomendo o [VS Code](https://code.visualstudio.com/))
- Build/execução da aplicação:

    ``` bash
    cd app/
    yarn install # instalação dos pacotes
    yarn test # executa os testes unitários
    yarn start # executa o APP com hot reload, na porta 3000
    ```

## Docker/Compose 

[![Docker](https://github.com/cassiofariasmachado/copa-filmes/actions/workflows/docker.yml/badge.svg)](https://github.com/cassiofariasmachado/copa-filmes/actions/workflows/docker.yml)

### Setup

Para executar toda a solução (API + APP) utilizando Docker e Docker Compose, basta:

- [Instalação do Docker](https://docs.docker.com/get-docker/)
- [Instalação do Docker Compose](https://docs.docker.com/compose/install/)
- Execução dos seguintes comandos:

    ``` bash
    docker-compose build
    docker-compose up -d
    ```

    Após execução dos comandos acima, o frontend estará disponível através da porta 3000 e o backend através da 5000.