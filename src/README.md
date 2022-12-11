# OfertaFone

## Instalação

Para instalar as dependencias clone o projeto e execute o seguinte comando dentro da pasta.

```shell
dotnet build .\OfertaFone.WebUI.csproj
```

logo após execute o sistema:

```
dotnet run OfertaFone.WebUI.dll
```

### Pré-requisitos

Para executar este container deverá ter o Docker instalado.

* [Windows](https://docs.docker.com/windows/started)
* [OS X](https://docs.docker.com/mac/started/)
* [Linux](https://docs.docker.com/linux/started/)

### Containers

#### Compose Project

O projeto já possui um docker-compose configurado, conseguirá executar o projeto somente executando o código:

```shell
docker-compose up
```

Para construir a Imagem do Docker:

```shell
docker build -t ofertafone .
```

Para executar o Docker na porta 80:

```shell
docker container run --name ofertafone -p 80:80 ofertafone
```

## Authors

* **José Vicente** - *Work* - [Jvicentemelo](https://github.com/Jvicentemelo)
* **Karen Franco** - *Work* - [Karenfranco23](https://github.com/Karenfranco23)
* **Luiz Carlos** - *Work* - [Luiiz-Souza](https://github.com/Luiiz-Souza)
* **Pedro Rodrigues** - *Work* - [pedrovitorrs](https://github.com/pedrovitorrs)
* **Ursula Daniela** - *Work* - [Ursula01](https://github.com/Ursula01)

## Como contribuir

Esteja sempre atento à criação de novas branches, padronização de commits e comentários em código
para que possamos melhorar sua mantenabilidade.
