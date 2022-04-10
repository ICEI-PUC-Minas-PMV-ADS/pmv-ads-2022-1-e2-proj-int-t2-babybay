<b> 4. Metodologia  </b>

Para o desenvolvimento de Babybay, serão aplicados os princípios AGILE, utilizando as metodologias Scrum e Kanban (conhecido como "Scrumban") para auxiliar o gerenciamento do projeto. 

 

<b> 4.1. Relações de Ambientes de Trabalho </b>

Os artefatos do projeto são desenvolvidos a partir de diversas plataformas e a relação dos ambientes com seus respectivos propósitos é apresentada na tabela que se segue.   



   

<b> 4.2. Gestão de código fonte </b>  

Para a gestão de código fonte do software desenvolvido pela equipe, o grupo utiliza um processo baseado no Git Flow. Desta forma, todas as manutenções no código são realizadas em branches separados, identificados como Hotfix, Release, Develop e Feature. 

 

 

Figura 1 - GitFlow 

Fonte: https://expressus.io/diagrams/git-flow-workflow-diagram-template 

 

<b> 4.3 Gerenciamento de Projeto </b>  

Assim está dividida a equipe Babybay: 

 

<b> Scrum Master:  </b>

Carlos Hilario Siqueira Camuzzi  

 

<b> Product Owner:   </b>

Julia de Oliveira Sartori 

 

<b> Equipe de Desenvolvimento:  </b>

Carlos Hilario Siqueira Camuzzi 

Adriana Silva Lacerda  

Ezequiel Silva de Souza Almeida 

Gabriel Antônio Lopes Costa 

Ila Feitosa da Nóbrega 

 

<b> Equipe de Design:  </b>

Ila Feitosa da Nóbrega 

Júlia de Oliveira Sartori 

 

Para organização e distribuição das tarefas do projeto, a equipe está utilizando a ferramenta Trello, estruturado com as seguintes listas:  

<b> Backlog </b> 

Define os artefatos a serem entregues 

<b> Plano de Sprint </b>

Inicialmente recebem os cards que serão movidos, e possuem a devida identificação de qual sprint pertencem por meio de etiquetas; 

<b> Design </b>

Esta lista apresentam as atividades designadas a equipe de Design do projeto; 

<b> A Fazer </b>

Recebe as atividades ainda a serem realizadas pela equipe; 

<b> Em andamento </b>

Tarefas sendo executadas no presente momento pelo time; 

<b> Teste </b>

Checagem de Qualidade. Quando as tarefas são concluídas, elas são movidas para o “CQ”;   

<b> Concluído </b>

Nesta lista são colocadas as tarefas que passaram pelos testes e controle de qualidade e estão prontas para serem entregues ao usuário. Não há mais edições ou revisões necessárias. 

 

Figura 2 - Organização do Trello 

 

			 




 
# Metodologia

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Documentação de Especificação</a></span>

Descreva aqui a metodologia de trabalho do grupo para atacar o problema. Definições sobre os ambiente de trabalho utilizados pela  equipe para desenvolver o projeto. Abrange a relação de ambientes utilizados, a estrutura para gestão do código fonte, além da definição do processo e ferramenta através dos quais a equipe se organiza (Gestão de Times).

## Controle de Versão

A ferramenta de controle de versão adotada no projeto foi o
[Git](https://git-scm.com/), sendo que o [Github](https://github.com)
foi utilizado para hospedagem do repositório.

O projeto segue a seguinte convenção para o nome de branches:

- `main`: versão estável já testada do software
- `unstable`: versão já testada do software, porém instável
- `testing`: versão em testes do software
- `dev`: versão de desenvolvimento do software

Quanto à gerência de issues, o projeto adota a seguinte convenção para
etiquetas:

- `documentation`: melhorias ou acréscimos à documentação
- `bug`: uma funcionalidade encontra-se com problemas
- `enhancement`: uma funcionalidade precisa ser melhorada
- `feature`: uma nova funcionalidade precisa ser introduzida

Discuta como a configuração do projeto foi feita na ferramenta de versionamento escolhida. Exponha como a gerência de tags, merges, commits e branchs é realizada. Discuta como a gerência de issues foi realizada.

> **Links Úteis**:
> - [Tutorial GitHub](https://guides.github.com/activities/hello-world/)
> - [Git e Github](https://www.youtube.com/playlist?list=PLHz_AreHm4dm7ZULPAmadvNhH6vk9oNZA)
>  - [Comparando fluxos de trabalho](https://www.atlassian.com/br/git/tutorials/comparing-workflows)
> - [Understanding the GitHub flow](https://guides.github.com/introduction/flow/)
> - [The gitflow workflow - in less than 5 mins](https://www.youtube.com/watch?v=1SXpE08hvGs)

## Gerenciamento de Projeto

### Divisão de Papéis

Apresente a divisão de papéis entre os membros do grupo.

> **Links Úteis**:
> - [11 Passos Essenciais para Implantar Scrum no seu 
> Projeto](https://mindmaster.com.br/scrum-11-passos/)
> - [Scrum em 9 minutos](https://www.youtube.com/watch?v=XfvQWnRgxG0)

### Processo

Coloque  informações sobre detalhes da implementação do Scrum seguido pelo grupo. O grupo poderá fazer uso de ferramentas on-line para acompanhar o andamento do projeto, a execução das tarefas e o status de desenvolvimento da solução.
 
> **Links Úteis**:
> - [Project management, made simple](https://github.com/features/project-management/)
> - [Sobre quadros de projeto](https://docs.github.com/pt/github/managing-your-work-on-github/about-project-boards)
> - [Como criar Backlogs no Github](https://www.youtube.com/watch?v=RXEy6CFu9Hk)
> - [Tutorial Slack](https://slack.com/intl/en-br/)

### Ferramentas

As ferramentas empregadas no projeto são:

- Editor de código.
- Ferramentas de comunicação
- Ferramentas de desenho de tela (_wireframing_)

O editor de código foi escolhido porque ele possui uma integração com o
sistema de versão. As ferramentas de comunicação utilizadas possuem
integração semelhante e por isso foram selecionadas. Por fim, para criar
diagramas utilizamos essa ferramenta por melhor captar as
necessidades da nossa solução.

Liste quais ferramentas foram empregadas no desenvolvimento do projeto, justificando a escolha delas, sempre que possível.
 
> **Possíveis Ferramentas que auxiliarão no gerenciamento**: 
> - [Slack](https://slack.com/)
> - [Github](https://github.com/)
