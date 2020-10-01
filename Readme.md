### Game Loan Manager

Sistema para gerência e controle de empréstimo de jogos a amigos. Desenvolvido em .Net Core e ReactJS. O sistema de gerência de banco de dados utilizado é o SQLite, a camada de acesso aos dados foi implementado com EF Core e Dapper.

### Execução
Para levantar o sistema execute:

		cd FrontEnd/ClientApp
		npm install
		npm run build
		cd ../../GameManagement
		dotnet publish -c Release -r ubuntu.18.04-x64 -o bin\dockercontent --self-contained
		docker-compose up

Após isso a aplicação estará disponível em http://localhost:5001

O usuário padrão: admin  senha: admin.

Nota.: Ao cadastrar novos amigos, são criados usuários adicionais com as credenciais:
usuário: [nome do amigo]  e senha: [nome do amigo]

### Demonstração
O vídeo com a demonstração do sistema em funcionamento está disponível [neste link](https://youtu.be/1OALMgovr0c).
