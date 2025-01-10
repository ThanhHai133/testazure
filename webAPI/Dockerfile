# Chọn image chính thức của .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Đặt thư mục làm việc trong container
WORKDIR /src

# Sao chép toàn bộ mã nguồn vào thư mục /src trong container
COPY . .

# Tạo thư mục build và cấp quyền truy cập
RUN mkdir -p /app/build/webAPI && chmod -R 777 /app/build

# Restore các dependencies cho dự án
RUN dotnet restore "./webAPI.csproj"

# Build dự án và xuất kết quả vào thư mục build
RUN dotnet build "./webAPI.csproj" -c Release -o /app/build/webAPI/

# Stage publish để tạo ra ứng dụng đã được publish
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

# Tạo thư mục ứng dụng trong container
WORKDIR /app

# Sao chép build đã được thực hiện từ bước trước vào container
COPY --from=build /app/build/webAPI ./

# Cung cấp cổng mà ứng dụng sẽ sử dụng
EXPOSE 80

# Thiết lập lệnh khởi chạy cho container
ENTRYPOINT ["dotnet", "webAPI.dll"]
