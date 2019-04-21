# Distribuição de Lucros

<p align="center">
  <img src="https://statig3.akamaized.net/bancodeimagens/9m/r1/lb/9mr1lb1wujwo4drvo74g1bfku.jpg" />
</p>

### Resumo

Este repositório tem por função realizar o desafio de criar uma api para distribuição de lucros da empresa XPTO para seus colaboradores.

Para criação dessa Api foi utilizado apenas uma rota, ela tem por função buscar na base de dados (Firebase) os dados dos colaboradores e fazer o cálculo de participação dos lucros para cada funcionário e com base em um valor informado calcular quanto a empresa terá de gastos e a distribuição para cada funcionário.

### API - DistribuicaoLucro
```
/api/v{version}/DistribuicaoLucro/{valorTotalDisponibilizado}
```

### Executar

Para executar a api é necessário baixar o dotnet core 2.2

[.net core 2.2 Runtime & SDK](https://dotnet.microsoft.com/download/dotnet-core/2.2)

Depois da instalação, o repositório baixado e dentro da pasta api(desafio-distribuicao-lucro-api\src\distribuicao-lucro-api), executar o comando abaixo:
```
dotnet run --project DistribuicaoLucro.Api.csproj
```

### Testes

Para a execução direta dos testes unitários é necessário estar na pasta (desafio-distribuicao-lucro-api\test\distribuicao-lucro-test), e então executar o comando abaixo:
```
dotnet test --project DistribuicaoLucro.Test.csproj
```

Para gerar o coverage de testes da aplicação também é necessário estar na pasta (desafio-distribuicao-lucro-api\test\distribuicao-lucro-test) e executar o bat file descrito abaixo:
```
coverageGenerator.bat
```
