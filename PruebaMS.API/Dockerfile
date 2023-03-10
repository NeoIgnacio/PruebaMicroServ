#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
RUN curl -k "https://152.199.4.184/v3/index.json"
WORKDIR /src
COPY ["PruebaMS.API/PruebaMS.API.csproj", "PruebaMS.API/"]
COPY ["PruebaMS.Application/PruebaMS.Application.csproj", "PruebaMS.Application/"]
COPY ["PruebaMS.Domain/PruebaMS.Domain.csproj", "PruebaMS.Domain/"]
COPY ["PruebaMS.Contracts/PruebaMS.Contracts.csproj", "PruebaMS.Contracts/"]
COPY ["PruebaMS.Infraestructure/PruebaMS.Infrastructure.csproj", "PruebaMS.Infraestructure/"]
COPY ["PruebaMs.Test/PruebaMS.Test.csproj", "PruebaMS.Test/"]
RUN dotnet restore "PruebaMS.API/PruebaMS.API.csproj"
COPY . .
WORKDIR "/src/PruebaMS.API"
RUN dotnet build "PruebaMS.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PruebaMS.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PruebaMS.API.dll"]