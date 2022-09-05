# Especificações do Projeto

## Personas

|Diego Lopes| ![alt text](/docs/img/personas1.png) |
|-----------------------|-|
|Idade:|35|
|Ocupação:| Influencer digital |
|Aplicativos:| WhatsApp, Facebook, Instagram, LinkedIn, Aplicativos de bancos, Spotify    |
|Motivações | Possui um sonho de fazer publicidade de grandes marcas  |
|Frustrações | Não ter condições de ter um celular de ponta para fazer seus vídeos com qualidade |
|Hobbies | Gosta de ler, Ouvir música |

|Melissa Soares| ![alt text](/docs/img/personas2.png) |
|-----------------------|-|
|Idade:|56|
|Ocupação:| Publicitária em uma agência em período integral |
|Aplicativos:| WhatsApp, Facebook, Instagram |
|Motivações | Gostaria de morar em outro país para conhecer novas culturas, Seus filhos são seu tesouro   |
|Frustrações | Gostaria de trocar seu aparelho, mas não sabe aonde vender |
|Hobbies | Gosta de cuidar de suas plantas, Faz natação |

|Lucas Simão| <img src="docs/img/personas3.png" width="200"> |
|-----------------------|-|
|Idade:|15|
|Ocupação:| Estudante do ensino médio |
|Aplicativos:| WhatsApp, Facebook, Instagram, LinkedIn, Aplicativos de bancos, Spotify    |
|Motivações | Espera um dia ser jogador profissional de free fire, Encontrar seus amigos a noite para conversas divertidas  |
|Frustrações | Por jogar tanto no celular, a bateria acaba sendo prejudicada e por esse motivo ele sempre precisa comprar um aparelho novo, gastando muito dinheiro sempre |
|Hobbies | Andar de skate , Assistir TV  |

|Elisa Andrade| <img src="docs/img/personas4.png" width="200"> |
|-----------------------|-|
|Idade:|75|
|Ocupação:| Dona de casa, aposentada. Criou seus 2 filhos e agora curte seus netos e seu jardim |
|Aplicativos:| WhatsApp |
|Motivações | Seus netos são muito preciosos para ela, Encontrar alguns amigos para jogar xadrez |
|Frustrações | Por seus netos não morarem na mesma cidade, só conseguem se falar por vídeo chamada, Gostaria de trocar de celular para obter um com uma câmera melhor |
|Hobbies | Gosta de ler, Jogar Xadrez |

|Sergio Souza | <img src="docs/img/personas5.png" width="200"> |
|-----------------------|-|
|Idade:|55|
|Ocupação:| Analista de compras em uma startup que assessora vendas de roupa em atacado |
|Aplicativos:| WhatsApp, Facebook |
|Motivações |  Viajar ao mundo com sua esposa e conhecer novas culturas  |
|Frustrações | Sua empresa precisa diminuir custos com despesas de celulares corporativos para seus funcionários |
|Hobbies | Academia, Jogar tênis |

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
|RF-08| O sistema deverá ter um ambiente de administrador | Alta |
|RF-09| O sistema deverá manter logs de alterações feitas por usuários e administradores | Alta |
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
|RE-01| A primeira etapa do projeto referente a concepção e proposta de solução deverá ser entregue até o dia 11/09/2022. |
|RE-02| A segunda etapa do projeto referente ao projeto da solução deverá ser entregue até o dia 02/10/2022. |
|RE-03| A terceira etapa do projeto referente a 1ª fase do desenvolvimento da solução deverá ser entregue até o dia 30/10/2022. |
|RE-04| A quarta etapa do projeto referente a 2ª fase do desenvolvimento da solução deverá ser entregue até o dia 27/11/2022. |
|RE-05| A quinta etapa do projeto referente aos relatórios das avaliações e entrega da solução deverá ser entregue até o dia 11/12/2022. |
|RE-06| O sistema deve se restringir às tecnologias básicas back-end em desenvolvimento web. |
|RE-07| O sistema deve ser hospedado, não sendo permitido em localhost. |

## Diagrama de Casos de Uso

![alt text](/docs/img/diagrama.png)
##### *Figura 1 - diagrama de caso de uso*
