# eKart

eKart is a fictitious project containing a product api endpoint. The api endpoint provides all the http verbs. It uses entity framework to connect to the sql azure database.

The eKart product api can be released in two ways

- Regular build artifact deployment
- Docker container based deployment

The former deploys the code to Azure app service and SQL Azure while the later deploys to an Azure container instance cluster.

### Regular build artifact deployment

This is a two step process. You can run the arm template located under the scripts folder

##### How to Run the arm template scripts

```ps
New-AzSubscriptionDeployment `
  -Name eKartDeployment `
  -Location centralindia `
  -TemplateFile azuredeploy.json
```
<sup>Please check the baseURI in the azuredeploy.json before running the arm template scripts</sup>

**Please read the steps below** if you want to make additional changes and run the arm template scripts from your local machine to validate. 

Nested/linked templates are used to deploy the artifacts. All the nested templates should be accessed publicly either by hosting it on the public Git repository or on a storage account. There is a shortcut to test the nested templates locally. Please follow the steps below

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

##### Run the azure-pipeline

The eKart product api is built using azure pipeline and deploy to the azure app service. Please refer to the azure-pipeline.yml to configure and run it.

Once both the steps are completed, the api swagger page is accessible here https://ekartapi2021.azurewebsites.net/


<span style="color:red">**To be Done**</span>
#### Docker container based deployment
How to run the SQL container

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=MyPass@word" -e "MSSQL_PID=Express" -p 1439:1433 -d --name=sql microsoft/mssql-server-linux:latest
```

How to run the web container

```bash
docker run -p 8080:80 ekart
```
