<body>
    <h1>Documentação do projeto de Estoque de Loja - Eduardo de Assis Rodrigues </h1>
    <h2>Caractetístcas:</h2>
    <p>O projeto foi desenvolvido usando a Versão 8.0 do .NET com as Dependencias instaladas usando a versão 8.0.17</p>
    <p>Para a execução correta da solução, é preciso segui o seguinte passo a passo. Já com o repositório copiado, Projeto > Propriedades > Configurar Projetos de Inicialização > Varios Projetos de Inicialização: > Colocar tanto o EstoqueLoja.API quanto o EstoqueLoja.WEB como Iniciar.</p>
    <p>O banco de dados ultilizado foi o SQL Server gerenciado pelo SSMS.<p>
    <p>Utilizei a autenticação pelo windows para o banco de dados, configurado junto com o JWT no appSettings.json</p>
    <h2>Desenvovimento do Projeto:</h1>
    <p>Foram feitos dois projetos dentro da mesma solução, um apenas com a API e um apenas com o MVC web, comecei a fazer pelo banco de dados, com ele pronto parti par a parte da API, com o uso do EF core Powertools usei a engenharia reversa e criei os models a partir do banco de dados, comecei a fazer a partir do CRUD das Tabelas de Loja, Produto e ItensEstoque.</p>
    <p>Após isso parti para parte do MVC, configurei os repositórios, os models, os controllers e os interfaces parecido com o que fiz na parte da API, cofigurei a comunicação entre elas e fiz a parte do frontend com ajuda do scaffolding, fiz alguns ajustes no _layout e terminei com a tela de login e a tela de cadastro de usuário, os CRUDs de Produto, Loja e ItensEstoque só podem ser visualizados com o usuário logado</p>


</body>