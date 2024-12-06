PROJETO - ARQUITETURA EM MICROSSERVIÇOS

Objetivo: Construir o back end de uma aplicação com a utilização da arquitetura de microsserviços.


1. Documento de Requisitos

a) Propósito do Sistema:
Gerenciar dados de um condomínio, incluindo o cadastro de residências, moradores e taxas de condomínio, permitindo integração entre os dados.

b) Usuários:
- Administradores do condomínio

c) Requisitos Funcionais:
- Cadastrar e buscar residências.
- Cadastrar, buscar e atualizar dívida dos moradores.
- Cadastrar taxas de condomínio e vincular ao morador correspondente.
- Validar se a residência está ativa ao cadastrar uma taxa.
- Atualizar a dívida do morador ao registrar uma taxa.


2. Descritivo Técnico (Microsserviços e suas funções):

a) Residências: 
Gerencia informações das residências do condomínio, como número da casa, status (ativa/inativa) e informações básicas.

b) Moradores: 
Gerencia o cadastro de moradores, vinculando cada morador a uma residência e armazenando informações como nome e dívida atual.

c) Taxas de Condomínio: 
Registra taxas cobradas e integra-se com os microsserviços de Residências e Moradores para validar dados e atualizar a dívida.