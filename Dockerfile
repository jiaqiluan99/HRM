#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim-amd64 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Recruiting/Recruiting.API/Recruiting.API.csproj", "Services/Recruiting/Recruiting.API/"]
COPY ["Services/Recruiting/ApplicationCore/ApplicationCore.csproj", "Services/Recruiting/ApplicationCore/"]
COPY ["Services/Recruiting/Infrastructure/Infrastructure.csproj", "Services/Recruiting/Infrastructure/"]
RUN dotnet restore "Services/Recruiting/Recruiting.API/Recruiting.API.csproj"
COPY . .
WORKDIR "/src/Services/Recruiting/Recruiting.API"
RUN dotnet build "Recruiting.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Recruiting.API.csproj" -c Release -o /app/publish -r linux-x64 --self-contained false /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV MSSQLConnectionString='Server=tcp:march2023hrmjl.database.windows.net,1433;Initial Catalog=Recruiting;Persist Security Info=False;User ID=marchBatch;Password=March2023;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;'
ENV RedisConnectionString='march2023jl.redis.cache.windows.net:6380,password=buPMinmsJO1hPw941BITRT8wJbIM85WuoAzCaOFPBE4=,ssl=True,abortConnect=False' 
ENTRYPOINT ["dotnet", "Recruiting.API.dll"]
