# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas

Diego Lopes tem 35 anos e é digital influencer. Pensa em fazer publicidades com grandes marcas, gosta muito de ler, ouvir música e está buscando um lugar para poder vender seu celular e comprar um modelo de ponta usado com um preço mais acessível.

Melissa Soares tem 56 anos e é publicitária em uma agência em período integral. Gostaria de morar em outro país para conhecer novas culturas e seu maior tesouro são seus filhos. Além disso gosta de cuidar de suas plantas e fazer natação. Procura um lugar para vender seu celular pois enjoou do seu atual e quer mudar um pouco de modelo.

Lucas Simão tem 15 anos e é estudante do ensino médio. Em seu tempo livre gosta de jogar free fire e espera um dia poder jogar profissionalmente também. Além disso gosta muito de andar de skate, assistir tv e encontrar seus amigos a noite. Por sempre estar jogando muito em seu celular, a bateria acaba sendo prejudicada tendo que trocar de celular várias vezes em um curto período de tempo, gastando muito dinheiro sempre. Por esses motivos está a procura de um celular usado que a bateria esteja em perfeitas condições gastando bem menos do que um celular novo.

Elisa Andrade tem 75 anos e é dona de casa aposentada. Gosta muito de ler e jogar xadrez com seus amigos. Por seus netos não morarem na mesma cidade, só conseguem se falar por vídeo chamada. Procura um lugar para poder comprar um celular com uma câmera melhor.

Sergio Souza tem 55 anos e é analista de compras em uma startup que assessora vendas de roupas em atacado. Seu grande sonho é viajar com sua esposa ao redor do mundo para conhecer novas culturas. Gosta de fazer academia e jogar tênis. Procura um lugar para comprar celulares usados para diminuir o custo da empresa ao comprar celulares corporativos novos.

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE`         |PARA ... `MOTIVO/VALOR`                               |
|--------------------|--------------------------------------------|------------------------------------------------------|
|Diego Lopes         |Um celular de ponta                         |Para gravar vídeos e tirar fotos com qualidades       |
|Melissa Soares      |Trocar o celular                            |Não tem um motivo específico, só quer trocar de modelo|
|Lucas Simão         |Trocar o celular para o mesmo modelo        |A bateria estar ruim e não conseguir mais jogar nele  |
|Elisa Andrade       |Trocar o celular para um modelo mais recente|Para obter um celular com uma câmera melhor           |
|Sergio Souza        |Comprar celulares com baixo custo           |Para diminuir o custo de sua empresa                  |

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID | Descrição do Requisito | Prioridade |
|------|------------------------------------------|-----|
|RF-01| O usuário deve ter a possibilidade de criar sua conta por meio de e-mail e senha.  | Alta |
|RF-02| O usuário deve ter a possibilidade de cadastrar seus dados pessoais como nome completo, data de nascimento, telefone, CPF e endereço | Alta |
|RF-03| O usuário logado deve ter a capacidade de cadastrar produtos para venda, incluindo fotos. | Alta |
|RF-04| O usuário logado poderá ver uma lista com seus produtos à venda. Ao clicar sobre um produto, será redirecionado para a tela de venda do produto.  | Alta | 
|RF-05| O usuário logado terá a opção de editar ou excluir seu anuncio.  | Alta |
|RF-06| O sistema deverá ocultar das buscas anúncios que foram finalizados por venda. | Alta |
|RF-07| O usuário logado poderá ver os itens comprados por ele. | Alta |
|RF-08| O sistema deverá ter um ambiente de administrador(?) | Alta |
|RF-09| O sistema deverá manter logs de alterações feitas por usuários e administradores(?) | Alta |
|RF-10| O sistema deverá ter a opção de favoritar itens pelo usuário logado. (Será necessário a criação de uma tela para exibição dos itens favoritados.) | Baixa |
|RF-11| O sistema deve ser capaz de enviar um código numérico por meio e-mail e/ou SMS. | Média |

### Requisitos não Funcionais

|ID | Descrição do Requisito | Prioridade |
|------|------------------------------------------|-----|
|RNF-01| As extensões permitidas são PNG, JPEG e MP4. | Média |
|RNF-02| O site precisa ser compatível com Microsoft Edge, Firefox, Google Chrome. | Alta |
|RNF-03| Os anexos não devem exceder 25 MB de tamanho. | Média |
|RNF-04| O código numérico enviado para redefinição de senha deve conter 6 dígitos. | Alta | 
|RNF-05| A senha deve conter no mínimo 6 e no máximo 10 caracteres incluindo, letra maiúscula, minúscula e número. | Alta |
|RNF-06| A interface do sistema deve ser responsiva em navegadores, tablets e smartphones. | Alta |
|RNF-07| O sistema deverá manter o funcionamento de 96% do tempo em 24hrs por dia, dos 7 dias da semana. | Média |

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| A primeira etapa do projeto referente a concepção e proposta de solução deverá ser entregue até o dia 11/09/2022. |
|02| A segunda etapa do projeto referente ao projeto da solução deverá ser entregue até o dia 02/10/2022. |
|03| A terceira etapa do projeto referente a 1ª fase do desenvolvimento da solução deverá ser entregue até o dia 30/10/2022. |
|04| A quarta etapa do projeto referente a 2ª fase do desenvolvimento da solução deverá ser entregue até o dia 27/11/2022. |
|05| A quinta etapa do projeto referente aos relatórios das avaliações e entrega da solução deverá ser entregue até o dia 11/12/2022. |

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
