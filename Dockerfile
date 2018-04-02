FROM microsoft/dotnet:2.1-sdk 
WORKDIR /app

# Copy everything else and build
COPY . ./
RUN dotnet restore

WORKDIR /app/ToDos/ToDos.Server

ENTRYPOINT ["dotnet", "run","--server.urls","http://0.0.0.0:5000"]