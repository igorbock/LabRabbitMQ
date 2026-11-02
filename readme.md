### Passo a passo do estudo
[Link da aula - Macoratti](https://macoratti.net/22/08/aspc_rabbitmq1.htm)

1. Colocar o Docker em **funcionamento** com WSL no disco secundário (D://); [Conversa no ChatGPT](https://chatgpt.com/share/6ae7da1f-0f4c-83e9-a4ec-3814c38a3cca)
2. Subir o container de SQL Server Express, com o comando:
`docker run -d \
  --name sqlserver-express \
  -e ACCEPT_EULA=Y \
  -e MSSQL_SA_PASSWORD='SqlDev#2026Senha' \
  -e MSSQL_PID=Express \
  -p 9876:1433 \
  -v sqlserver_express_data:/var/opt/mssql \
  --restart unless-stopped \
  mcr.microsoft.com/mssql/server:2022-latest`
  3. Alterar o appsettings.json e appsettings.development.json para receber a ConnectionString;
  4. Subir o container de RabbitMQ para funcionamento do projeto, com o comando: 
  `docker run --rm  -it -p 15672:15672 -p 5672:5672 rabbitmq:3-management`