# QuanLySinhVien_CSDLPT
Demo Cơ Sở Dữ Liệu Phân Tán
📚 Mô tả
Demo ứng dụng Quản Lý Sinh Viên sử dụng Cơ Sở Dữ Liệu Phân Tán với SQL Server 2022 và Visual Studio 2022
🛠️ Công nghệ sử dụng
Database: SQL Server 2022
Development: Visual Studio 2022
Backend: C# .NET 6.0/7.0
Frontend: WinForms
Tools: SQL Server Management Studio (SSMS) 19+
📋 Tính năng demo CSDL Phân Tán
Phân mảnh ngang theo mã lớp (L1, L2)
Phân mảnh dọc các mảnh con
Distributed Transactions (TransactionScope)
Query Across Multiple Databases
Connection Pooling & Load Balancing
Data Replication Setup
🚀 Hướng dẫn cài đặt
Yêu cầu hệ thống:
SQL Server 2022 Developer/Express Edition
Visual Studio 2022 (v17.0+)
.NET 6.0 Runtime
Các bước:
Clone repository: git clone https://github.com/vixxy05/QuanLySinhVien_CSDLPT.git
Mở SSMS, chạy scripts trong thư mục database/
Mở solution .sln trong Visual Studio 2022
Cấu hình connection strings trong app.config
Build và Run (F5)
📁 Cấu trúc project
text
QuanLySinhVien_CSDLPT/
├── 📂 database/                 # Scripts database
│   ├── QuanLySinhVien.sql      # Tạo database & dữ liệu mẫu
│   ├── stored_procedures.sql   # Procedures phân tán
│   └── fragmentation_views.sql # Views phân mảnh
├── 📂 src/                     # Source code C#
│   ├── 📂 Models/              # Data models
│   │   ├── SinhVien.cs
│   │   ├── Lop.cs
│   │   └── DangKy.cs
│   ├── 📂 Services/            # Business logic
│   │   ├── DatabaseService.cs
│   │   ├── DistributedService.cs
│   │   └── ConnectionManager.cs
│   ├── 📂 Forms/               # Giao diện WinForms
│   │   ├── frmMain.Designer.cs
│   │   ├── frmMain.cs
│   │   ├── frmLogin.cs
│   │   └── frmConnection.cs
│   ├── Program.cs
│   └── App.config
├── 📂 docs/                    # Tài liệu hướng dẫn
│   ├── setup-guide.md
│   └── demo-steps.md
├── README.md
├── QuanLySinhVien.sln
└── LICENSE
🔧 Demo Features Chi Tiết
Phân mảnh ngang:
sql
-- Mảnh sv1: Sinh viên lớp L1
CREATE VIEW sv1 AS SELECT * FROM sinhvien WHERE mslop = 'L1';

-- Mảnh sv2: Sinh viên lớp L2  
CREATE VIEW sv2 AS SELECT * FROM sinhvien WHERE mslop = 'L2';
Phân mảnh dọc:
sql
-- Mảnh sv1_doc1 (thông tin cá nhân)
CREATE VIEW sv1_doc1 AS 
SELECT mssv, hoten, phai, ngaysinh FROM sinhvien WHERE mslop = 'L1';
-- Mảnh sv1_doc2 (thông tin học vụ)
CREATE VIEW sv1_doc2 AS 
SELECT mssv, mslop, hocbong FROM sinhvien WHERE mslop = 'L1';
Distributed Transactions:
csharp
using (TransactionScope scope = new TransactionScope())
{
    // Xóa từ mảnh cũ
    DeleteFromFragment(sourceFragment, studentId);
    
    // Thêm vào mảnh mới  
    InsertIntoFragment(targetFragment, studentData);
    scope.Complete(); // Commit transaction
}
🎮 Hướng dẫn sử dụng
Đăng nhập:
Username: Vỹ
Password: 123
Chức năng chính:
Quản lý sinh viên - CRUD đầy đủ
Chuyển lớp - Chuyển sinh viên giữa L1 ↔ L2
Xem phân mảnh - Hiển thị theo các mảnh khác nhau
Quản lý kết nối - Chuyển đổi giữa server MAIN/REPLICA
📊 Kiến trúc phân tán
text
[Client App - WinForms C#]
          ↓
[Database Service Layer]
          ↓
[SQL Server 2022 - MAIN]
          ⇄
[SQL Server 2022 - REPLICA]
