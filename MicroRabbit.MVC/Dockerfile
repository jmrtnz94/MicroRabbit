﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MicroRabbit.MVC/MicroRabbit.MVC.csproj", "MicroRabbit.MVC/"]
RUN dotnet restore "MicroRabbit.MVC/MicroRabbit.MVC.csproj"
COPY . .
WORKDIR "/src/MicroRabbit.MVC"
RUN dotnet build "MicroRabbit.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroRabbit.MVC.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroRabbit.MVC.dll"]
