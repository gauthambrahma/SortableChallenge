#Source - https://docs.docker.com/engine/examples/dotnetcore/

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /SortableChallenge

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /SortableChallenge

COPY --from=build-env /SortableChallenge/out .
ENTRYPOINT ["dotnet", "SortableChallenge.dll"]
