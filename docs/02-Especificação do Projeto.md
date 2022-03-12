# Especificações do Projeto


A definição do problema e os pontos mais relevantes a serem tratados nesse projeto, foram levantados com a participação de stakeholders e representados no formato de personas e histórias de usuários: 

## Personas

As personas levantadas durante o processo, estão representadas abaixo: 

________________________________________________________________________________________
Nome | Idade | Ocupação
---|---|---
![Contadora]()**Ana Alice Soares** | 27 anos | Estudante de Enfermagem. Mãe solteira, também trabalha meio período em uma livraria local pertencente ao avô de uma de suas amigas, com o intuito de conseguir manter seus estudos e ainda colaborar em casa e na criação de seu filho.

Aplicativos | Motivações | Frustrações | Hobbies/História
---|---|---|---
- Instagram<br> - TikTok<br> Twitter | - Encontrar o equilíbrio entre investir em si mesma para alcançar seu sonho de ser enfermeira, agora que está de volta ao ensino superior, e prover as melhores condições e oportunidades para o crescimento de seu filho, agora com 5 anos, colaborando em suas despesas que são arcadas majoritariamente pelos avós do menino (seus pais). | - Não sobra dinheiro algum para extras (roupas, cursos, cinema, entre outros);<br><br> - Pouco ou nenhum tempo livre. | - Gosta de gravar conteúdo para a rede social Instagram sobre ser mãe de primeira viagem e solteira, tendo uma base modesta, mas sólida de seguidores. Ultimamente tem se interessado por ambientalismo e sustentabilidade.<br><br> - Tornou-se mãe solteira aos 22 anos, quando ainda estava no 3º período de enfermagem; decidiu dar uma pausa nos estudos por uns anos até que seu filho fosse maior.  

 ________________________________________________________________________________________
 Nome | Idade | Ocupação
---|---|---
![Empresário]()<br>**João Guilherme Pereira** | 35 anos | Recém-desempregado, mas trabalha com Design em empresas de Publicidade e Propaganda. 

Aplicativos | Motivações | Frustrações | Hobbies/História
---|---|---|---
- Twitter<br> - YouTube | - Encontrar outro emprego o quão antes possível, para que sua esposa não tenha que arcar com os gastos da família (eles e seus dois filhos) sozinha.<br><br> - Preocupado com a quantidade de despesas que os filhos geram anualmente, devido ao seu crescimento e custos com educação. | -Falência da empresa em que trabalhava depois de tanto tempo e energia investidos.<br><br> - Preços de quaisquer bens de consumo aumentando constantemente.<br><br> - Não estar conseguindo ser contratado por outra empresa. | - Ciclismo e ensinar sua filha mais velha (8 anos) sobre.<br><br> - Assistir e incentivar sua filha mais nova (5 anos) no novo interesse dela, jogar vôlei. 
________________________________________________________________________________________
 Nome | Idade | Ocupação
---|---|---
![Marketing]()**Carlos Oliveira** | 29 anos | Mestrando na área de Ciências da Computação, é pai solteiro, ex-namorada e mãe de seu filho mora em outro continente e não possui meios financeiros o suficiente para ajudar financeiramente. 

Aplicativos | Motivações | Frustrações | Hobbies/História
---|---|---|---
 - Twitter<br> - YouTube<br> Linkedin. | - Terminar o mestrado e conseguir um emprego com bom salário para que os avós do menino parem de ter tantas despesas com ele e seu filho (moram na casa dos pais de Carlos). | - Bolsa do mestrado insuficiente para arcar com os custos de vida dele e do filho.<br><br> - Menino entrando em uma intensa fase de crescimento acaba demandando muito investimento. | - Gosta de jogar videogames, com o filho e também sozinho.<br><br> - Decidiu fazer o mestrado após ser demitido do seu antigo emprego e achar que possibilitaria melhores oportunidades em sua carreira.
________________________________________________________________________________________

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|João Guilherme Teixeira | Roupas de crianças através de permuta ou doação | Para poupar dinheiro com roupas que serão usadas por pouco tempo |
|Ana Alice Soares | Alternativas para desfazer das roupas que não cabem no filho sem gerar desperdício  | Conseguir efetuas trocas e evitar o acúmulo de roupas em bom estado de conservação |
| Ana Alice Soares | Aplicação que faça a mediação de trocas de roupas | Contato e confiabilidade entre usuários; centralização de busca por roupas |
| Carlos Oliveira | Aplicação para visualizar em fotos e vídeos o estado da roupa a ser trocada | Para garantir boas condições das peças |
| Carlos Oliveira | Aplicação para buscar outros pais ou responsáveis em sua região | Facilidade a aquisição de peças e garantir formas de mediação da entrega |
| João Guilherme Teixeira | Comprar menos roupas novas | Ajudar na preservação do meio ambiente 

Apresente aqui as histórias de usuário que são relevantes para o projeto de sua solução. As Histórias de Usuário consistem em uma ferramenta poderosa para a compreensão e elicitação dos requisitos funcionais e não funcionais da sua aplicação. Se possível, agrupe as histórias de usuário por contexto, para facilitar consultas recorrentes à essa parte do documento.

> **Links Úteis**:
> - [Histórias de usuários com exemplos e template](https://www.atlassian.com/br/agile/project-management/user-stories)
> - [Como escrever boas histórias de usuário (User Stories)](https://medium.com/vertice/como-escrever-boas-users-stories-hist%C3%B3rias-de-usu%C3%A1rios-b29c75043fac)
> - [User Stories: requisitos que humanos entendem](https://www.luiztools.com.br/post/user-stories-descricao-de-requisitos-que-humanos-entendem/)
> - [Histórias de Usuários: mais exemplos](https://www.reqview.com/doc/user-stories-example.html)
> - [9 Common User Story Mistakes](https://airfocus.com/blog/user-story-mistakes/)

## Requisitos do Projeto

O escopo funcional do projeto é definido por requisitos funcionais que descrevem a interação dos usuários com a aplicação, e por requisitos não-funcionais que descrevem aspectos do sistema. Esses requisitos estão apresentados abaixo:	

### Requisitos Funcionais

A tabela a seguir apresenta os requisitos funcionais, conforme o seu grau de relevância: 

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| O usuário deve se cadastrar na plataforma com seus dados pessoais, incluindo endereço e CPF  | ALTA | 
|RF-002| A aplicação deve permitir a criação de loja virtual para anúncio de roupas destinadas a troca ou doação    | ALTA |
|RF-003| A aplicação deve permitir o cadastro de produto com descrição, tipo, tamanho e idade aproximada da criança que utilizou a roupa | ALTA |
|RF-004| Aplicação deve permitir a postagem de fotos e descrição no anúncio do produto | ALTA |
|RF-005| A aplicação deve permitir a postagem de vídeo no anúncio do produto | BAIXA |
|RF-006| A aplicação deve permitir ao usuário a exclusão de anúncio, produto ou cadastro de usuário | MÉDIA |
|RF-007| A aplicação deve exibir para o usuário a opção de curtir produtos de interesse, bem como favoritar lojas | MÉDIA  |
|RF-008| A aplicação deve ter campo de busca por lojas e produtos | MÉDIA |
|RF-009| A aplicação deve possuir filtros de busca para idade, categoria, tamanho e gênero  | MÉDIA |
|RF-010| A aplicação deve fornecer ao usuário a possibilidade de ajustar seu raio geográfico de busca | BAIXA |
|RF-011| A aplicação deve permitir a troca de informações entre as partes via caixa de perguntas e respostas | MÉDIA |
|RF-012| A aplicação deve disponibilizar a opção ao usuário doar produto para outros usuários  | BAIXA |
|RF-013| A aplicação deve permitir ao usuário recusar ou aceitar a solicitação de troca  | MÉDIA |
|RF-014| A aplicação deve validar com as partes envolvidas a realização da troca  | BAIXA |
|RF-015| A aplicação deve solicitar as partes envolvidas na negociação a avaliação da troca  | BAIXA |
|RF-016| A aplicação deve fornecer campo de ajuda e informações para orientação de uso  | BAIXA | 
|RF-017| A aplicação deve exibir para o usuário a opção de denunciar postagens com conteúdo malicioso | BAIXA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| O sistema deve ser implementado no front-end em linguagem HTML, CSS e JavaScript | ALTA | 
|RNF-002| O sistema deve ser implementado no back-end utilizando a linguagem C# e banco de dados relacional | MÉDIA | 
|RNF-003| O sistema deve estar disponível pelo menos 90% das 24h por dia e 7 dias na semana | BAIXA |
|RNF-004| O sistema deve retornar a busca por produtos em no máximo 5 segundos  | MÉDIA |
|RNF-005| A aplicação deve fornecer ferramenta de geolocalização | MÉDIA |
|RNF-006| O sistema deverá suportar arquivos de imagens png e jpeg com tamanho máximo de 8 mb | ALTA |
|RNF-007| O sistema deve suportar arquivos de vídeo no formato mp4, mkv ou ogv com duração de no máximo 15 segundos | MÉDIA |
|RNF-008| O sistema não deve validar postagens de produto com menos de três fotos, um vídeo e uma descrição | MÉDIA |
|RNF-009| O sistema deve ser responsivo, se adaptando a diversos formatos | ALTA |
|RNF-010| O sistema deve fornecer opções de acessibilidade tais como ajuste de contraste e tamanho fonte | BAIXA |
|RNF-011| A aplicação deve notificar as partes em eventuais interesses de produtos  | MÉDIA |
|RNF-012| A aplicação deve registrar e exibir as trocas realizadas através de um histórico de usuário | MÉDIA |
|RNF-013| A loja virtual deve ser bloqueada automaticamente em caso de 3 denúncias por conteúdo indevido  | BAIXA |
|RNF-014| Os usuários envolvidos em uma negociação devem ser impedidos de efetuar novas trocas caso não avaliem a última troca realizada | BAIXA |
|RNF-015| A aplicação deverá permitir ao administrador do sistema realizar análise das peças via foto e vídeo, para posterior validação na moeda interna *BabyCoin*  | MÉDIA |
|RNF-016| O sistema deve gerenciar o fluxo de entrada e saída da moeda interna *BabyCoin* na conta dos usuários no momento da finalização da troca | BAIXA |
|RNF-017| A aplicação deverá permitir ao usuário a compra da moeda interna *BabyCoin*, mediante a pagamento via PIX  | BAIXA |


## Restrições

As questões que limitam a execução desse projeto e que se configuram como obrigações claras para o desenvolvimento do projeto em questão são apresentadas na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|RE-001| O projeto não poderá ser entregue após 26/06/2022 |
|RE-002| O projeto não poderá ser terceirizado para outra equipe |


## Diagrama de Casos de Uso

O diagrama de casos de uso a seguir demonstra as principais ligações entre casos de usos e atores, permitindo detalhar os requisitos funcionais identificados na etapa de elicitação. 


IMAGEM AQUI
