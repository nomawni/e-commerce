FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY *.csproj ./

COPY ./ ./
RUN dotnet restore

RUN dotnet publish -c release -o out --no-restore

FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "Product.dll" ]

