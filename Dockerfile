FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

ARG connection_string
ARG redis_connection_string

WORKDIR /app

ENV ConnectionStrings__DefaultConnection=${connection_string}
ENV ConnectionStrings__RedisConnection=${redis_connection_string}

COPY LeadManagementApi/*.csproj ./

RUN dotnet restore

COPY LeadManagementApi/ ./

ENV PATH="$PATH:/root/.dotnet/tools"

RUN dotnet build --no-restore -c Release -o /app/build

FROM build-env AS publish
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "LeadManagementApi.dll"]
