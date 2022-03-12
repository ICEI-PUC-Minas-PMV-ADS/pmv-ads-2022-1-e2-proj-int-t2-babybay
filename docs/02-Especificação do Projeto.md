# Especificações do Projeto


A definição do problema e os pontos mais relevantes a serem tratados nesse projeto, foram levantados com a participação de stakeholders e representados no formato de personas e histórias de usuários: 

## Personas

As personas levantadas durante o processo, estão representadas abaixo: 

________________________________________________________________________________________
Nome | Idade | Ocupação
---|---|---
![Contadora]  )**Ana Alice Soares** | 27 anos | Estudante de Enfermagem. Mãe solteira, também trabalha meio período em uma livraria local pertencente ao avô de uma de suas amigas, com o intuito de conseguir manter seus estudos e ainda colaborar em casa e na criação de seu filho.

Aplicativos | Motivações | Frustrações | Hobbies/História
---|---|---|---
Instagram;<br> TikTok;<br> Twitter |  Encontrar o equilíbrio entre investir em si mesma para alcançar seu sonho de ser enfermeira, agora que está de volta ao ensino superior, e prover as melhores condições e oportunidades para o crescimento de seu filho, agora com 5 anos, colaborando em suas despesas que são arcadas majoritariamente pelos avós do menino (seus pais). |  Não sobra dinheiro algum para extras (roupas, cursos, cinema, entre outros);<br> Pouco ou nenhum tempo livre. | Gosta de gravar conteúdo para a rede social Instagram sobre ser mãe de primeira viagem e solteira, tendo uma base modesta, mas sólida de seguidores. Ultimamente tem se interessado por ambientalismo e sustentabilidade.<br> Tornou-se mãe solteira aos 22 anos, quando ainda estava no 3º período de enfermagem; decidiu dar uma pausa nos estudos por uns anos até que seu filho fosse maior.  

 ________________________________________________________________________________________
 Nome | Idade | Ocupação
---|---|---
![Empresário](https://user-images.githubusercontent.com/91077484/136857072-9d8dabcd-d3a7-43fa-95b3-6c69cb6e0ba3.png)<br>**João Guilherme Pereira** | 66 anos | Empresário e proprietário de um supermercado de pequeno porte. 

Aplicativos | Motivações | Frustrações | Hobbies/História
---|---|---|---
Facebook. | Ensinar o filho sobre a empresa para que ele possa dar continuidade e até mesmo expandir. | Alto custo na compra de produtos para revenda;<br> Inflação diminuindo o poder de compra dos clientes;<br> Despreparo do filho para assumir o negócio da família. | Assistir futebol com o filho Mateus;<br> Adora o silêncio da pescaria no fim de semana.
________________________________________________________________________________________
 Nome | Idade | Ocupação
---|---|---
![Marketing](https://user-images.githubusercontent.com/91077484/136857076-523e11fb-09a5-4bb5-ac53-c30230ae78f8.png)**Cristina Vieira Netto** | 39 anos | Tecnóloga em marketing, cursando bacharelado em administração, empreendedora e proprietária de microempresa no ramo de publicidade. 

Aplicativos | Motivações | Frustrações | Hobbies/História
---|---|---|---
 Instagram;<br> Facebook;<br> Tik Tok. | Expandir a empresa e abrir filiais. | Dificuldade no início do negócio;<br> Dificuldade de implementação de tecnologia para expandir a empresa. | Ama música, tendo preferência para rock e pop;<br> Gosta de uma boa leitura, especialmente de romances.    
________________________________________________________________________________________



Lembre-se que você deve ser enumerar e descrever precisamente e personalizada todos os clientes ideais que sua solução almeja.

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Usuário do sistema  | Registrar minhas tarefas           | Não esquecer de fazê-las               |
|Administrador       | Alterar permissões                 | Permitir que possam administrar contas |

Apresente aqui as histórias de usuário que são relevantes para o projeto de sua solução. As Histórias de Usuário consistem em uma ferramenta poderosa para a compreensão e elicitação dos requisitos funcionais e não funcionais da sua aplicação. Se possível, agrupe as histórias de usuário por contexto, para facilitar consultas recorrentes à essa parte do documento.

> **Links Úteis**:
> - [Histórias de usuários com exemplos e template](https://www.atlassian.com/br/agile/project-management/user-stories)
> - [Como escrever boas histórias de usuário (User Stories)](https://medium.com/vertice/como-escrever-boas-users-stories-hist%C3%B3rias-de-usu%C3%A1rios-b29c75043fac)
> - [User Stories: requisitos que humanos entendem](https://www.luiztools.com.br/post/user-stories-descricao-de-requisitos-que-humanos-entendem/)
> - [Histórias de Usuários: mais exemplos](https://www.reqview.com/doc/user-stories-example.html)
> - [9 Common User Story Mistakes](https://airfocus.com/blog/user-story-mistakes/)

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| Permitir que o usuário cadastre tarefas | ALTA | 
|RF-002| Emitir um relatório de tarefas no mês   | MÉDIA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| O sistema deve ser responsivo para rodar em um dispositivos móvel | MÉDIA | 
|RNF-002| Deve processar requisições do usuário em no máximo 3s |  BAIXA | 

Com base nas Histórias de Usuário, enumere os requisitos da sua solução. Classifique esses requisitos em dois grupos:

- [Requisitos Funcionais
 (RF)](https://pt.wikipedia.org/wiki/Requisito_funcional):
 correspondem a uma funcionalidade que deve estar presente na
  plataforma (ex: cadastro de usuário).
- [Requisitos Não Funcionais
  (RNF)](https://pt.wikipedia.org/wiki/Requisito_n%C3%A3o_funcional):
  correspondem a uma característica técnica, seja de usabilidade,
  desempenho, confiabilidade, segurança ou outro (ex: suporte a
  dispositivos iOS e Android).
Lembre-se que cada requisito deve corresponder à uma e somente uma
característica alvo da sua solução. Além disso, certifique-se de que
todos os aspectos capturados nas Histórias de Usuário foram cobertos.

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |


Enumere as restrições à sua solução. Lembre-se de que as restrições geralmente limitam a solução candidata.

> **Links Úteis**:
> - [O que são Requisitos Funcionais e Requisitos Não Funcionais?](https://codificar.com.br/requisitos-funcionais-nao-funcionais/)
> - [O que são requisitos funcionais e requisitos não funcionais?](https://analisederequisitos.com.br/requisitos-funcionais-e-requisitos-nao-funcionais-o-que-sao/)

## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.

> **Links Úteis**:
> - [Criando Casos de Uso](https://www.ibm.com/docs/pt-br/elm/6.0?topic=requirements-creating-use-cases)
> - [Como Criar Diagrama de Caso de Uso: Tutorial Passo a Passo](https://gitmind.com/pt/fazer-diagrama-de-caso-uso.html/)
> - [Lucidchart](https://www.lucidchart.com/)
> - [Astah](https://astah.net/)
> - [Diagrams](https://app.diagrams.net/)
