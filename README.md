# eKart

**eKart** is a fictitious project showcasing a product api endpoint. It all the http verbs following the RESTful pattern. It also uses entity framework to connect to the sql azure database. The sample is build in .NET 5.0 and detailed article is available [ASP.NET Core web api with Swagger | .NET 5 - Getting started](http://dotnetartisan.in/getting-started-aspnet-core-web-api/)

The eKart product api can be released in two ways

- Regular build artifact deployment to managed services like Azure App Service
- Container based deployment to Azure Kubernetes Service

The detailed article is available [How to deploy Azure app service using Azure pipeline](http://dotnetartisan.in/deploy-azure-app-service-azure-pipeline/)

### Regular build artifact deployment

This is a two staged process. More details can be found in the article [How to deploy Azure app service using Azure pipeline](http://dotnetartisan.in/deploy-azure-app-service-azure-pipeline/)

##### How to Run the arm template scripts locally

```ps
New-AzSubscriptionDeployment `
  -Name eKartDeployment `
  -Location centralindia `
  -TemplateFile azuredeploy.json
```
<sup>Please check the baseURI in the azuredeploy.json before running the arm template scripts</sup>

**Please read the steps below** if you want to make additional changes and run the arm template scripts from your local machine to validate. 

Linked templates are used to deploy the artifacts. They should be accessed publicly either by hosting it on the public Git repository or on a storage account. There is a shortcut to test the linked templates locally. Please follow the steps below

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

#### Docker container based deployment
How to run the SQL container

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=MyPass@word" -e "MSSQL_PID=Express" -p 1439:1433 -d --name=sql microsoft/mssql-server-linux:latest
```

How to run the web container

```bash
docker run -p 8080:80 ekart
```
