# Teste para .Net C# Dev Backend

[![Lyncas Logo](https://img-dev.feedback.house/TCo5z9DrSyX0EQoakV8sJkx1mSg=/fit-in/300x300/smart/https://s3.amazonaws.com/feedbackhouse-media-development/modules%2Fcore%2Fcompany%2F5c9e1b01c5f3d0003c5fa53b%2Flogo%2F5c9ec4f869d1cb003cb7996d)](https://www.lyncas.net)
### Requisitos

- Google books (https://developers.google.com/books/)

### Diferencial

- Testes unitários

## Como participar?

1. Faça um clone deste repositório.
2. Quando estiver finalizado a prova, compartilhe seu código no seu Git de preferência e nos envie para o e-mail que consta ao final desse documento.
3. Faremos nossa análise e te daremos um retorno.

## Detalhes da prova

### Critérios analisados

- Arquitetura do projeto (camadas)
- Aplicação de orientação a objeto
- Funcionalidades e funcionamento

### O que você deve desenvolver

- A prova consiste em construir uma interface interna para comunicação com o Google Books API
- Seu projeto deve também conter um arquivo README com a explicação das tecnologias utilizadas e as instruções para rodar.
- Descrever suas dificuldades e facilidades, bem como o número de horas de desenvolvimento.
- A comunicação com o Google Books API deve ser feita utilizando um HttpClient padrão, feito na mão e sem o uso de qualquer library.
- O Google Books API é aberto e não requer nenhuam autenticação.

### Funcionalidades

A API deve conter os seguintes endpoints

1. GET /api/books?p={term} (com paginação) onde term é o termo de pesquisa direto para o Google Books, ex: ?term=Harry Potter
2. POST /api/book/{id}/favorite
3. GET /api/book/favorites - retornar uma lista de favoritos
4. DELETE /api/book/{id}/favorite - excluir um favorito

### Especificações técnicas

* O App deve se comunicar com o Google Books API pelo backend .Net e não fazer uso de nenhuma lib

## Dúvidas? Envio da prova?
`testes@lyncas.net`

### Desde já obrigado pelo seu interesse e boa prova!
