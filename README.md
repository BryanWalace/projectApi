# Projeto API - Loja - README

Bem-vindo ao meu Projeto API! Este projeto é parte de uma avaliação no final do semestre da disciplina de Topicos especiais da Faculdade Positivo. Desenvolvido em C# utilizando o framework .NET, esta API representa uma solução robusta e segura para gerenciar autenticação e autorização em sistemas web.

## Funcionalidades

- **Autenticação JWT**: A API utiliza tokens JWT (JSON Web Tokens) para autenticar usuários. Quando um usuário faz login com suas credenciais, a API gera um token JWT que é usado para autorizar as solicitações posteriores.

- **Endpoint de Login**: O endpoint `/login` permite que os usuários façam login fornecendo um nome de usuário e senha. Se as credenciais forem válidas, a API gera um token JWT e o retorna ao cliente.

- **Validação de Token**: O token JWT gerado pela API é validado com base em uma chave secreta armazenada no servidor. Isso garante que apenas tokens válidos emitidos pela API sejam aceitos para autorizar solicitações subsequentes.

## Estrutura do Projeto

O projeto consiste em duas classes principais:

1. **UserController**: Esta classe é responsável por lidar com a lógica de autenticação do usuário. Ela contém um método `login` que valida as credenciais do usuário fornecidas e retorna um valor booleano indicando se o login foi bem-sucedido ou não.

2. **TokenGenerator**: Esta classe é responsável por gerar tokens JWT. Ela contém um método `GenerateToken` que recebe um nome de usuário como entrada e retorna um token JWT válido, assinado com uma chave secreta.

Além disso, o projeto utiliza a biblioteca `Microsoft.AspNetCore.Authentication.JwtBearer` para configurar a autenticação JWT e o middleware do ASP.NET Core para lidar com solicitações HTTP.

## Como Executar o Projeto

Para executar o projeto, siga estas etapas:

1. Clone o repositório para o seu ambiente local.
2. Abra o projeto em um ambiente de desenvolvimento compatível com o .NET, como o Visual Studio ou o Visual Studio Code.
3. Certifique-se de ter todas as dependências instaladas, incluindo o .NET SDK.
4. Execute o projeto e acesse os endpoints da API usando um cliente HTTP adequado, como o Postman ou o cURL.

## Contribuição

Este projeto é um esforço pessoal. Se você deseja contribuir com melhorias, novas funcionalidades ou correções de bugs, fique à vontade para enviar pull requests e relatar problemas.

---

