<b> 4. Projeto da Solução 

4.1 Projeto de Interface </b>  

Dentre as preocupações para a montagem da interface do sistema, estamos estabelecendo foco em questões como agilidade, acessibilidade e usabilidade. Desta forma, o projeto tem uma identidade visual padronizada em todas as telas que são projetadas para funcionamento em desktops.  

 

 4.2 Diagrama de Fluxo 

O diagrama que define o fluxo do sistema é representado a seguir: 

   

Figura 3 – Fluxo do usuário 

  

  

4.3 Wireframes Interativos 

Conforme fluxo de telas do projeto, apresentado no item anterior, as telas do sistema são apresentadas em detalhes nos itens que se seguem. As telas do sistema apresentam uma estrutura comum em que existem 3 grandes blocos, descritos a seguir. São eles:  

Cabeçalho: Local onde são dispostos elementos fixos;  

Conteúdo: Apresenta o conteúdo da tela em questão;  

Rodapé: Apresenta os elementos de navegação secundária, geralmente associados a contatos e site externo.  

 

  

Figura 4 – Tela inicial do site com a barra lateral à mostra 

 

 

Figura 5 – Tela inicial do site com a barra lateral oculta 

  

4.3.1 Tela Login  

A tela Login será a que o usuário irá realizar o login no sistema através do e-mail e senha já cadastrados anteriormente. A tela também contará com opções de “Esqueceu a senha”, caso o usuário não lembre, que irá redirecioná-lo para uma tela em que ele possa recuperar a senha e um botão “Cadastre-se”, para caso o usuário não seja cadastrado, ele será redirecionado para uma tela onde fornecerá seus dados.  

  

 

  

Figura 6 – Login 

 

4.3.2 Tela de cadastro para usuário 

A tela de cadastro é responsável por obter informações essenciais do usuário. Conta com um redirecionamento para uma tela de cadastro de endereço e outra para confirmação do e-mail cadastrado. 

 

  

Figura 7 – Cadastro de usuário 

 

Figura 8 – Cadastro de endereço 

 

 Figura 9 – Confirmação de e-mail 

 

 

  

4.3.3 Tela inicial do usuário/Boas vindas do usuário  

Após realizado o login ou após finalizado o cadastro, o usuário é redirecionado a um menu principal que conta com as opções de criar novo anúncio, buscar roupas, guarda roupa de usuário e configurações. É possível também redirecionar ao inbox ao clicar no ícone de mensagem e também sair da conta. 

 

 

Figura 10 – Menu principal com a barra lateral oculta 

  

Figura 11 – Menu principal com a barra lateral à mostra 

  

4.3.4 Tela “Criar novo anúncio”  

Após clicar na opção de criar novo anúncio no menu principal do usuário, redireciona-se para uma tela de postagem de peça de roupa. 

 

 

 Figura 12 - Criar novo anúncio  

  

4.3.5 Telas de busca de roupas  

Ao clicar em “Buscar roupas” no menu principal, o usuário é redirecionado às telas de busca, onde irá navegar para encontrar as postagens de peças que deseja adquirir, dentro dos critérios de idade, gênero e categoria que definir. 

 

 

Figura 13 – Busca geral de peças de roupa 

 

Figura 14 – Tela de item individual 

  

4.3.6 Tela de inbox e negociação de troca  

Após clicar no botão “Eu quero!” em uma peça, tanto na busca geral como na postagem individual, o usuário é redirecionado ao inbox do anunciante, que irá aceitar ou recusar a troca. 

 

 

 Figura 15 – Inbox/solicitação de troca  

  

4.3.7 Telas de “Meu guarda roupa” 

Após clicar em “Meu guarda roupa” no menu principal, o usuário é redirecionado às seções de anúncios já publicados (“Minhas publicações”), pendentes (“Publicações pendentes” - aguardam análise da moderação se o anúncio atende a todos os critérios estabelecidos e regras do site) e peças de outros usuários que foram favoritadas para possível compra posterior (“Favoritos”). 

  

 

Figura 16 – Meu guarda roupa: Minhas publicações 

 

Figura 17 – Meu guarda roupa: Publicações pendentes 

 

  

Figura 18 – Meu guarda roupa: Favoritos 

 

4.3.8 Telas da seção “Minha carteira” 

Após clicar em “Minha carteira” na barra lateral do site, o usuário é redirecionado à página que o possibilita checar seu saldo de Babycoin, moeda de troca do site, bem como fazer compra de mais Babycoin e também visualizar seu extrato da moeda e histórico de trocas. 

 

 

Figura 19 – Minha carteira 

 

 

Figura 20 – Página de compra de Babycoin 

 

 

Figura 21 – Confirmação de compra de Babycoin 

 

 

Figura 22 – Extrato da carteira 

 

Figura 23 – Histórico de trocas 

 

4.3.9 Telas de Configurações e Desativar/Excluir Conta 

Após clicar em “Configurações” no menu principal, o usuário é redirecionado à página de ajustes da conta, onde pode alterar o nome de seu usuário, bem como sua senha, atualizar endereço cadastrado e desativar ou excluir conta. 

 

Inserindo imagem... 

Figura 24 – Configurações 

 

 

Figura 25 – Atualizar endereço 

 

 

Figura 26 – Desativar conta 

 

Figura 27 – Excluir conta 

 

4.3.10 Tela de visualização de perfil de usuário 

Após clicar no username de um anunciante, o usuário é redirecionado ao seu perfil, onde todas as peças disponibilizadas por aquele e que ainda não foram trocadas estão dispostas. 

 

 

Figura 28 – Perfil de usuário 

 

4.3.11 Tela de denúncia de usuário ou postagem 

Após clicar na opção de denúncia de postagem ou anunciante que é disponibilizada nas páginas das peças individuais ou no perfil deste, o usuário é redirecionado a uma página em que pode denunciar através de um dos motivos listados ou descrever algum outro. 

 

 

Figura 29 – Página de denúncia de postagem e/ou usuário 


# Projeto de Interface

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Documentação de Especificação</a></span>

Visão geral da interação do usuário pelas telas do sistema e protótipo interativo das telas com as funcionalidades que fazem parte do sistema (wireframes).

 Apresente as principais interfaces da plataforma. Discuta como ela foi elaborada de forma a atender os requisitos funcionais, não funcionais e histórias de usuário abordados nas <a href="2-Especificação do Projeto.md"> Documentação de Especificação</a>.

## Diagrama de Fluxo

O diagrama apresenta o estudo do fluxo de interação do usuário com o sistema interativo e  muitas vezes sem a necessidade do desenho do design das telas da interface. Isso permite que o design das interações seja bem planejado e gere impacto na qualidade no design do wireframe interativo que será desenvolvido logo em seguida.

O diagrama de fluxo pode ser desenvolvido com “boxes” que possuem internamente a indicação dos principais elementos de interface - tais como menus e acessos - e funcionalidades, tais como editar, pesquisar, filtrar, configurar - e a conexão entre esses boxes a partir do processo de interação. Você pode ver mais explicações e exemplos https://www.lucidchart.com/blog/how-to-make-a-user-flow-diagram.

![Exemplo de Diagrama de Fluxo](img/diagramafluxo2.jpg)

As referências abaixo irão auxiliá-lo na geração do artefato “Diagramas de Fluxo”.

> **Links Úteis**:
> - [Fluxograma online: seis sites para fazer gráfico sem instalar nada | Produtividade | TechTudo](https://www.techtudo.com.br/listas/2019/03/fluxograma-online-seis-sites-para-fazer-grafico-sem-instalar-nada.ghtml)

## Wireframes

![Exemplo de Wireframe](img/wireframe-example.png)

São protótipos usados em design de interface para sugerir a estrutura de um site web e seu relacionamentos entre suas páginas. Um wireframe web é uma ilustração semelhante do layout de elementos fundamentais na interface.
 
> **Links Úteis**:
> - [Protótipos vs Wireframes](https://www.nngroup.com/videos/prototypes-vs-wireframes-ux-projects/)
> - [Ferramentas de Wireframes](https://rockcontent.com/blog/wireframes/)
> - [MarvelApp](https://marvelapp.com/developers/documentation/tutorials/)
> - [Figma](https://www.figma.com/)
> - [Adobe XD](https://www.adobe.com/br/products/xd.html#scroll)
> - [Axure](https://www.axure.com/edu) (Licença Educacional)
> - [InvisionApp](https://www.invisionapp.com/) (Licença Educacional)
