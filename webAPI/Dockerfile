# Use the official ASP.NET runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Sao chép file .csproj vào thư mục src trong container
COPY ["webAPI.csproj", "./"]

# Restore dependencies (nuget)
RUN dotnet restore "./webAPI.csproj"

# Sao chép toàn bộ mã nguồn vào container
COPY . .

# Chuyển đến thư mục chứa file csproj và build
WORKDIR /src
RUN dotnet build "./webAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage publish để tạo ra ứng dụng đã được publish
FROM build AS publish
RUN dotnet publish "./webAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage - sử dụng base image và copy ứng dụng đã publish vào
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set the entry point for the container
ENTRYPOINT ["dotnet", "webAPI.dll"]
