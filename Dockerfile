FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./UserManager.csproj" --disable-parallel
RUN dotnet publish "./UserManager.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/sdk:5.0 
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5001
ENTRYPOINT ["dotnet", "UserManager.dll"]