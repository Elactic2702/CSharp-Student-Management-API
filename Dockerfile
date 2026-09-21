FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["CSharp-Student-Management-API.csproj", "."]
RUN dotnet restore "CSharp-Student-Management-API.csproj"

COPY . .
RUN dotnet publish "CSharp-Student-Management-API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "CSharp-Student-Management-API.dll"]