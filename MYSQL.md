# Kết nối MySQL

Dự án hỗ trợ MySQL 8.0+ qua MySql.EntityFrameworkCore. MySQL sử dụng context và migration riêng; tệp SQLite cũ vẫn được giữ nguyên. Máy phát triển này đã bật MySQL qua User Secrets: localhost:3306, database robotics_lab. appsettings.json giữ SQLite làm cấu hình dự phòng cho máy chưa có User Secrets.

## Cấu hình trên máy phát triển

Trong Visual Studio, bấm phải dự án → Manage User Secrets, nhập cấu hình sau và thay thông tin cho phù hợp:

```json
{
  "Database:Provider": "MySql",
  "ConnectionStrings:MySqlDatabase": "Server=localhost;Port=3306;Database=robotics_lab;User ID=robotics_app;Password=YOUR_PASSWORD;SslMode=Preferred;"
}
```

Không commit mật khẩu vào appsettings.json. User Secrets chỉ được tự động nạp khi chạy môi trường Development. Khi triển khai, đặt biến môi trường `Database__Provider=MySql` và `ConnectionStrings__MySqlDatabase` bằng cấu hình bí mật của máy chủ; dùng TLS phù hợp với máy chủ MySQL.

Tài khoản cần quyền tạo bảng, chỉ mục và đọc/ghi trên database đích. Có thể nhờ quản trị viên tạo database `robotics_lab` với bộ ký tự `utf8mb4` trước khi chạy.

## Khởi tạo

```powershell
dotnet tool restore
dotnet ef database update --context MySqlRoboticsDbContext
dotnet run --project "web robotics.csproj"
```

Website cũng áp dụng migration khi khởi động và nạp dữ liệu mẫu một lần. SQL sinh ra để xem trước nằm tại `Migrations/MySql/schema.sql`.

Ngày 18/11/2026, đã chuyển dữ liệu hiện có từ SQLite sang MySQL: 6 thành viên, 6 dự án, 6 bài viết, 5 công bố, 5 tài liệu. Đã đánh dấu SeedHistory để không nạp trùng dữ liệu mẫu. Đây là lần chuyển một lần, không đồng bộ hai database. Tệp `App_Data/robotics.db` vẫn được giữ lại.

Khi tạo migration mới, luôn chỉ rõ context:

```powershell
dotnet ef migrations add TenThayDoi --context MySqlRoboticsDbContext --output-dir Migrations/MySql
```

Các lệnh EF dành cho SQLite dùng `--context RoboticsDbContext`.

Tài liệu provider: https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core.html
