#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CowUtters.csproj", "."]
RUN dotnet restore "./CowUtters.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CowUtters.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CowUtters.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

RUN mkdir -p /infiles
RUN mkdir -p /out

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CowUtters.dll"]
