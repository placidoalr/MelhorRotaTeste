# MelhorRotaTeste
  * Como executar a aplicação
- Abra o projeto inteiro no VisualStudio
- Selecione MelhorRotaTeste > https 
- Execute o projeto
- Opção 1 servirá para adicionar mais rotas ao arquivo, seguindo o padrão de (RotaInicial,RotaFinal,Custo)
- Opção 2 servirá para buscar o melhor valor para a rota digitada, seguindo o padrão (RotaInicial-RotaFinal)
- Opção 0 servirá para parar a aplicação

  * Estrutura dos arquivos/pacotes
   MelhorRotaTeste/
   ├── Models/
   │   └── RouteModel.cs
   ├── Services/
   │   └── RouteService.cs
   │   └── TravelService.cs
   └── Program.cs
   MelhorRotaTeste/
   └── Tests/
       └── RouteTest.cs

  * Explique as decisões de design adotadas para a solução de forma simplificada e objetiva
  Como não era permitido utilizar o algoritimo de DIJKSTRA, pesquisei alguns outros tipos de algoritimos que poderiam ser uteis, tendo isso em mente achei o Algoritmo de Bellman-Ford que pareceu fácil e útil no cenário proposto.
  Utilizei também para testes unitários o MSTest
