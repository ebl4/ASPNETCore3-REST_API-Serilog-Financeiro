#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["br.com.rdc.financeiro.web/br.com.rdc.financeiro.web.csproj", "br.com.rdc.financeiro.web/"]
COPY ["br.com.rdc.financeiro.service/br.com.rdc.financeiro.service.csproj", "br.com.rdc.financeiro.service/"]
COPY ["br.com.rdc.financeiro.domain/br.com.rdc.financeiro.domain.csproj", "br.com.rdc.financeiro.domain/"]
COPY ["br.com.rdc.financeiro.application/br.com.rdc.financeiro.application.csproj", "br.com.rdc.financeiro.application/"]
COPY ["br.com.rdc.financeiro.persistence/br.com.rdc.financeiro.persistence.csproj", "br.com.rdc.financeiro.persistence/"]
RUN dotnet restore "br.com.rdc.financeiro.web/br.com.rdc.financeiro.web.csproj"
COPY . .
WORKDIR "/src/br.com.rdc.financeiro.web"
RUN dotnet build "br.com.rdc.financeiro.web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "br.com.rdc.financeiro.web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "br.com.rdc.financeiro.web.dll"]