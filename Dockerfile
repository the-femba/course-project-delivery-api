FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /
COPY . ./app

WORKDIR /app
RUN dotnet restore
RUN dotnet publish -c release -o /app/Flx.ProjectName.WebApi --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0

WORKDIR /app/Flx.ProjectName.WebApi

COPY --from=build /app/Flx.Oriole.WebApi ./

ENTRYPOINT ["dotnet", "Flx.ProjectName.WebApi.dll"]