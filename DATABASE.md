#Cơ sở dữ liệu Robotics Lab

Website sử dụng Entity Framework Core 10 và SQLite. Tệp dữ liệu mặc định là `App_Data/robotics.db`, nằm ngoài thư mục công khai `wwwroot`.

## Chạy website

```powershell
dotnet restore
  dotnet run --project "web robotics.csproj"
```

Khi khởi động, ứng dụng áp dụng migration còn thiếu và nhập dữ liệu mẫu một lần trong transaction. Bảng `SeedHistory` đánh dấu đã nhập; khởi động lại không ghi đè chỉnh sửa hoặc phục hồi dữ liệu đã xóa.

## Các bảng

| Bảng | Nội dung |
| --- | --- |
| Members | Thành viên và các điểm nổi bật |
| Projects | Dự án, thông số, công nghệ, trạng thái và tính năng |
| Publications | Công bố khoa học, tác giả, DOI và năm |
| Articles | Bài viết Markdown, phân loại, cấp độ và thẻ |
| Documents | Tài liệu, phiên bản, kích thước và đường dẫn tải |
| SeedHistory | Trạng thái nhập dữ liệu mẫu |

Các bảng nội dung có khóa chính `Id`. Slug dự án và bài viết có chỉ mục duy nhất. Có chỉ mục phân loại và năm công bố. `Highlights`, `KeyFeatures`, `Tags` được lưu dạng mảng JSON và ánh xạ về `List<string>`.

Tên người phụ trách, tác giả và danh mục hiện được giữ dưới dạng chuỗi theo dữ liệu gốc; chưa thiết lập quan hệ khóa ngoại cho các trường này. `PublishedDate` giữ định dạng `dd/MM/yyyy` để tương thích giao diện.

Các controller, tìm kiếm và truy vấn dữ liệu của chatbot sử dụng `RoboticsDataService`. Các câu trả lời chuyên đề cố định của chatbot vẫn nằm trong mã nguồn. Dữ liệu khởi tạo trong `RoboticsMockData` chỉ được dùng bởi bộ khởi tạo.

## Cấu hình và chỉnh sửa

Đổi `ConnectionStrings:RoboticsDatabase` trong `appsettings.json`, hoặc biến môi trường `ConnectionStrings__RoboticsDatabase`. Đường dẫn tương đối được tính từ thư mục gốc ứng dụng. Thư mục dữ liệu cần quyền ghi.

Có thể mở tệp SQLite bằng công cụ quản trị SQLite hoặc dùng `RoboticsDbContext` và `SaveChangesAsync()` trong chức năng quản trị sau này. Chưa có giao diện thêm/sửa/xóa hoặc phân quyền quản trị trong thay đổi này.

## Thay đổi cấu trúc

```powershell
dotnet tool restore
dotnet ef migrations add TenThayDoi
dotnet ef database update
```

Migration đầu tiên và model snapshot nằm trong `Migrations`. Sao lưu trước khi áp dụng migration trên dữ liệu thật. Với nhiều máy chủ ứng dụng, chạy migration ở bước triển khai trước khi khởi động đồng thời các máy chủ.

## Sao lưu

Dừng ứng dụng trước khi sao chép `App_Data/robotics.db`. Nếu cần sao lưu khi đang chạy, dùng SQLite Backup API hoặc lệnh `.backup`; không chỉ sao chép tệp `.db` khi SQLite đang dùng WAL. Lưu tệp dữ liệu trên ổ đĩa bền vững khi triển khai; không đưa vào mã nguồn.

Tham khảo: [EF Core migrations](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/).
