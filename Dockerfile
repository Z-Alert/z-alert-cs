FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ZAlert.Api/ZAlert.Api.csproj", "ZAlert.Api/"]
RUN dotnet restore "ZAlert.Api/ZAlert.Api.csproj"
COPY . .
WORKDIR "/src/ZAlert.Api"
RUN dotnet build "ZAlert.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ZAlert.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZAlert.Api.dll"]
