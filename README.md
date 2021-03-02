# eKart

eKart is a fictitious project containing a product api endpoint. The api endpoint provides all the http verbs. It uses entity framework to connect to the sql database.

The product api can be released in two ways

- Regular build artifact deployment
- Docker container based deployment

The former deploys the code to Azure app service and SQL Azure while the later deploys to Azure container instance.

#### Regular build artifact deployment

Run the ARM template
```ps
New-AzSubscriptionDeployment `
  -Name eKartDeployment `
  -Location centralindia `
  -Template azuredeploy.json
```

Configure the azure-pipeline

#### Docker container based deployment
How to run the SQL container

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=MyPass@word" -e "MSSQL_PID=Express" -p 1439:1433 -d --name=sql microsoft/mssql-server-linux:latest
```bash
How to run the web container

```
docker run -p 8080:80 ekart
```
