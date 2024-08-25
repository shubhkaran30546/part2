# Use the official .NET 8.0 SDK image as the build environment 
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build 
WORKDIR /src 
# Copy the project file and restore dependencies 
COPY ["part2.csproj", "./"] 
RUN dotnet restore "part2.csproj" 
# Copy the rest of the source code and build the project 
COPY . . 
RUN dotnet build "part2.csproj" -c Release -o /app/build 
# Publish the application 
RUN dotnet publish "part2.csproj" -c Release -o /app/publish 
# Use the official .NET 8.0 runtime image for the final image 
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final 
WORKDIR /app 
# Copy the published application from the build stage 
COPY --from=build /app/publish . 
# Set the environment variable for ASP.NET Core to listen on port 8080 
ENV ASPNETCORE_URLS=http://+:8080 
# Expose the port the app runs on 
EXPOSE 8080 
# Define the entry point for the application 
ENTRYPOINT ["dotnet", "part2.dll"]
