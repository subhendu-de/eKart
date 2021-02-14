# eKart

#### How to run the SQL container

```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=MyPass@word" -e "MSSQL_PID=Express" -p 1439:1433 -d --name=sql microsoft/mssql-server-linux:latest
```
#### How to run the web container

```
docker run -p 8080:80 ekart
```
