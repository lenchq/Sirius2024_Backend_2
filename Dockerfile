FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Sirius.GymGraphQL/Sirius.GymGraphQL.csproj", "Sirius.GymGraphQL/"]
RUN dotnet restore "Sirius.GymGraphQL/Sirius.GymGraphQL.csproj"
COPY . .
RUN dotnet build "Sirius.GymGraphQL/Sirius.GymGraphQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sirius.GymGraphQL/Sirius.GymGraphQL.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sirius.GymGraphQL.dll"]
