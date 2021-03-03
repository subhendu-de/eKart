# eKart

eKart is a fictitious project containing a product api endpoint. The api endpoint provides all the http verbs. It uses entity framework to connect to the sql database.

The product api can be released in two ways

- Regular build artifact deployment
- Docker container based deployment

The former deploys the code to Azure app service and SQL Azure while the later deploys to Azure container instance.

#### Regular build artifact deployment

Run the ARM template

Nested templates are used to deploy the artifacts. All the nested templates should be accessed publicly either by hosting it on the public Git repository or on a storage account. There is a shortcut way to test the nested templates locally. Please follow the steps below

 - Install Node.js
 - Install http-server and NPM package

```bash
npm install -g http-server
```

 - Download and unzip [ngrok](https://ngrok.com/) on your local machine let’s say D:\ngrok
 - Go to the scripts folder
 - Type http-server and hit enter
 - Open another command prompt
 - Type cd D:\ngrok and hit enter
 - Type ngork.exe http 8080 and hit enter to serve the files externally
 - Open the azuredeploy.json file and change the baseURI variable


```ps
New-AzSubscriptionDeployment `
  -Name eKartDeployment `
  -Location centralindia `
  -TemplateFile azuredeploy.json
```

Configure the azure-pipeline

#### Docker container based deployment
How to run the SQL container

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=MyPass@word" -e "MSSQL_PID=Express" -p 1439:1433 -d --name=sql microsoft/mssql-server-linux:latest
```

How to run the web container

```bash
docker run -p 8080:80 ekart
```
