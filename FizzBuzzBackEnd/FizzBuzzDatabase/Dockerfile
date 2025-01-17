# Use the official .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy all application files and build the project
COPY . ./
RUN dotnet publish -c Release -o /out

# Use the official .NET runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build-env /out .

# Expose the default port for ASP.NET Core
EXPOSE 80

# Set the entry point to the built DLL
ENTRYPOINT ["dotnet", "FizzBuzzDatabase.dll"]
