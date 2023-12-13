# Sobre
Esta API fornece a criação de consultas médicas, juntamente com paciente e médico, atualizando seu estado (MARCADA, REMARCADA, CANCELADA e FINALIZADA)

# Preparando Ambiente
## Tecnologias
Para rodar o projeto, você irá necessitar ter instaladas as seguintes dependências:

| Dependências    | Versão |
|-----------------|--------|
| .NET            | 7.0.4  |
| docker          | 24.0.5 |
| docker-compose  | 1.29.2 |

## Rodando o Projeto
Na raiz do projeto basta digitar o comando `docker-compose up -d` na sua CLI favorita e, após rodar, acessar `localhost:5103/swagger` para realizar as requisições.

# Escolhas de Design
## Arquitetura
Foi escolhida a arquitetura cebola, devido a ser um design em camadas, logo preza pela separação de contextos, gerando menor acoplamento das partes envolvidas. Basicamente, é estruturada da seguinte forma: `Apresentação >> Serviços >> Infraestrutura >> Domínio`, sendo as camadas internas isoladas do mundo exterior.

## Camadas
Alguns componentes foram separados por projetos e, apesar de a arquitetura não ser baseada em pastas, este método de separação/organização serve ao nosso propósito de manter camadas mais internas sem dependências das mais externas, devido ao sistema de referenciamento. Abaixo irei falar um pouco de como as camadas foram pensadas para o projeto, sendo da mais interna (`Domínio`) até a mais externa (`Apresentação`).

### Domínio
Esta camada é fundamental para a definição das regras de negócio, provendo abstrações para camadas superiores implementarem (tornando-se um domínio anêmico). Dividi o domínio em dois projetos: um para definir as entidades da nossa API (`Domain`) e outro para disponibilizar interfaces para as demais camadas (`Domain.Contracts`), como as regras para persistência dos dados, que serão implementadas pela Infraestrutura.

### Infraestrutura
A infraestrutura utiliza os contratos definidos pelo domínio e os implementa para que camadas superiores, como a de aplicação (`Services`), possam utilizar. Nesta camada, implementamos os repositórios (abstrações para acesso à base de dados) e a configuração dos nossos modelos, mapeando-os para a base de dados.

### Serviços/Aplicação
Esta parte implementa a lógica de negócio (`Services`), executando processos requisitados pela camada de apresentação e define interfaces (`Services.Contracts`) para que componentes superiores possam utilizá-las. Aqui foram desenvolvidos serviços especializados (`AuthenticateService`) e genéricos (`GenericService`), com possibilidade de especialização, que implementam operações comuns (CRUD).

### Apresentação/Controller
Serve como porta de entrada para que o mundo externo possa se comunicar com nossa API, tendo usuários requisitando ou enviando dados para processamento. Esta porta se dá pela `Controller` que espera por comandos e, quando enviados, chama a camada de `Serviços/Aplicação` para executar as tarefas.

### Recursos Compartilhados
Peças (`Shareds`) que todas as camadas podem precisar, não mantendo dependência com nenhuma delas, sendo um coringa na nossa aplicação.
Como exemplo de recurso compartilhado temos os DTOs (Data Transfer Objects) que nos ajudam a omitir dados que não queremos mostrar para o cliente (uma API serve para simplificar, então espelhar o seu banco de dados para o cliente não é legal).
