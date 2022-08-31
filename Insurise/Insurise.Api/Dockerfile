FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Insurise.WEB/Insurise.WEB.csproj", "Insurise.WEB/"]
RUN dotnet restore "Insurise.WEB/Insurise.WEB.csproj"
COPY . .
WORKDIR "/src/Insurise.WEB"
RUN dotnet build "Insurise.WEB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Insurise.WEB.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Insurise.WEB.dll"]
