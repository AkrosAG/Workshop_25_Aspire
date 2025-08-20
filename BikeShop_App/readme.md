# Getting Started

Make sure the `ThoemusBike-Aspire.AppHost` project is set as the startup
project.

Run it!

> **N O T E:** The first time you run the app, it may take a little longer to start
if you don't already have the Postgres and Smtp4Dev container images downloaded.

The Aspire Dashboard will be launched and that will have links for the different
projects.  Start by clicking the link for the WebApp project!


docker pull rnwood/smtp4dev
docker run --rm -d --name fakemail -p 3000:80 -p 2525:25 rnwood/smtp4dev

docker pull datalust/seq
docker run --name seq -d --restart unless-stopped -e ACCEPT_EULA=Y -p 5341:80 datalust/seq

docker pull postgres
docker run -d --name thoemusbike-postgres -e POSTGRES_PASSWORD=thoemusbike -p 5432:5432 postgresWenn der Befehl `dotnet workload restore` das Problem nicht löst, probiere bitte Folgendes:

1. Führe `dotnet workload install aspire` aus, um gezielt den fehlenden Workload zu installieren.
2. Überprüfe mit `dotnet workload list`, ob der Workload tatsächlich installiert ist.
3. Aktualisiere das .NET SDK mit `dotnet --list-sdks` und ggf. einem Update.
4. Lösche ggf. den Ordner `obj` und `bin` im Projektverzeichnis und führe einen Clean-Build durch.
5. Starte Visual Studio neu.

Wenn das Problem weiterhin besteht, prüfe die Datei `global.json` im Projektverzeichnis auf eine evtl. inkompatible SDK-Version.
