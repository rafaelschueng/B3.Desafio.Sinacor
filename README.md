# B3.Desafio.Sinacor
Desafio de Front e Back-End para o projeto Sinacor - B3

Para testar o código do back-end:
dotnet test ./back/B3.Desafio.Sinacor.Tests/

Para rodar o projeto de back-end:
dotnet run --project ./back/B3.Desafio.Sinacor/B3.Desafio.Sinacor.csproj

Para rodar o teste de cobertura:
dotnet test ./back/B3.Desafio.Sinacor.Tests/  /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=lcov.info

Para rodar o front-end:
cd ./front/sinacor-front-app/; npm run start
