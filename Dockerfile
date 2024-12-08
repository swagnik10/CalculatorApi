# Use the official .NET SDK image based on Alpine to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src

# Copy the project file and restore any dependencies (via dotnet restore)
COPY ["CalculatorApi.csproj", "."]
RUN dotnet restore "CalculatorApi.csproj"

# Copy the rest of the application and build it
COPY . . 
WORKDIR "/src"
RUN dotnet build "CalculatorApi.csproj" -c Release -o /app/build

# Publish the application (producing the output ready for runtime)
FROM build AS publish
RUN dotnet publish "CalculatorApi.csproj" -c Release -o /app/publish

# Use the official .NET ASP.NET image based on Alpine for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 80

# Set environment variable to listen on port 80
ENV ASPNETCORE_URLS=http://0.0.0.0:80

# Copy the published output to the runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "CalculatorApi.dll"]
