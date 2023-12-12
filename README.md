
# Preparando Ambiente
## Tecnolgias
Para rodar o projeto você irá necessitar ter instaladas as seguintes dependencias

|Dependencias  |Versão |
|--------------|-------|
|.NET          |7.0.4  |
|docker        |24.0.5 |
|docker-compose|1.29.2 |

## Rodando o Projeto
Na raiz do projeto basta digitar o comando `docker-compose up -d`
na sua CLI favorita e, apos rodando, acessar `localhost:5103/swagger` para realizar as requisições.

# Escolhas de Design
## Arquitetura
Foi escolhida a arquitetura cebola, devido a ser um design que preza pela separação de contextos, gerando maior desacoplamento das camadas envolvidas. Basicamente, é estruturada da seguinte forma `Apresentação >> Serviços >> Infraestrutura >> Dominio`, sendo as camadas internas isoladas do mundo exterior.

## Camadas
### Dominio
Está camada é fundamental para definição das regras de negocio, provendo abstrações para camadas superiores implementarem (tornando-se um dominio anêmico). Dividi o dominio em dois projetos, um para definir as entidades da nossa API (`Domain`) e outro para disponibilizar interfaces para demais camadas (`Domain.Contracts`), como as regras para persistências dos dados, que serão implementadas pela Infraestrutura.

### Infraestrutura
A infra utiliza-se dos contratos definidos pelo dominio e os implementa para que camadas superiores, como a de aplicação (`Services`), possam utilizar. Nesta camada implementamos os repositorios (abstrações para acesso a base de dados) e a configuração de nossos modelos, mapeando-os para a base da dados.

### Serviços/Aplicação
Esta parte implementa a logica do negocio (`Services`), executando processos requisitados pela camada de apresentação e define interfaces (`Services.Contracts`) para que componentes superiores possam se utilizar

### Recursos Compartilhados


