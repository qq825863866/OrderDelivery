#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
#COPY ["Ods.WebApi/Ods.WebApi.csproj", "Ods.WebApi/"]
#COPY ["Ods.Common/Ods.Common.csproj", "Ods.Common/"]
#COPY ["Ods.Services/Ods.Services.csproj", "Ods.Services/"]
#COPY ["Ods.Repository/Ods.Repository.csproj", "Ods.Repository/"]
COPY ./**/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done
RUN dotnet restore "Ods.WebApi/Ods.WebApi.csproj"
COPY . .
WORKDIR "/src/Ods.WebApi"
RUN dotnet build "Ods.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ods.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ods.WebApi.dll"]
