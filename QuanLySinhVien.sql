-- ============================================================================
-- KIỂM TRA VÀ XÓA DATABASE CŨ NẾU TỒN TẠI
-- ============================================================================

USE master;
GO

-- Kiểm tra và xóa replication trước khi xóa database
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'QuanLySinhVien')
BEGIN
    -- Ngắt tất cả kết nối đến database
    ALTER DATABASE QuanLySinhVien SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    
    -- Xóa replication trước
    IF EXISTS (SELECT * FROM sys.databases WHERE name = 'QuanLySinhVien' AND is_published = 1)
    BEGIN
        EXEC sp_removedbreplication 'QuanLySinhVien';
        PRINT N'Đã xóa replication khỏi database QuanLySinhVien';
    END
    
    -- Sau đó mới xóa database
    DROP DATABASE QuanLySinhVien;
    PRINT N'Đã xóa database cũ QuanLySinhVien';
END
GO

-- Tạo database mới
CREATE DATABASE QuanLySinhVien;
GO

USE QuanLySinhVien;
GO

-- ============================================================================
-- TẠO CÁC BẢNG THEO ĐỀ BÀI (KHÔNG CÓ BẢNG MONHOC)
-- ============================================================================

-- Tạo bảng lớp
CREATE TABLE lop (
    mslop VARCHAR(10) PRIMARY KEY,
    tenlop NVARCHAR(50),
    khoa NVARCHAR(50)
);
GO

-- Tạo bảng sinhvien
CREATE TABLE sinhvien (
    mssv VARCHAR(10) PRIMARY KEY,
    hoten NVARCHAR(100),
    phai NVARCHAR(10),
    ngaysinh DATE,
    mslop VARCHAR(10),
    hocbong DECIMAL(10,2),
    FOREIGN KEY (mslop) REFERENCES lop(mslop)
);
GO

-- Tạo bảng dangky (KHÔNG CÓ KHÓA NGOẠI MONHOC)
CREATE TABLE dangky (
    mssv VARCHAR(10),
    msmon VARCHAR(10),
    diem1 DECIMAL(4,2),
    diem2 DECIMAL(4,2),
    diem3 DECIMAL(4,2),
    PRIMARY KEY (mssv, msmon),
    FOREIGN KEY (mssv) REFERENCES sinhvien(mssv)
);
GO

-- ============================================================================
-- CHÈN DỮ LIỆU MẪU (50 SINH VIÊN CÓ TÊN CỤ THỂ)
-- ============================================================================

-- Chèn dữ liệu bảng lớp
INSERT INTO lop (mslop, tenlop, khoa) VALUES
('L1', N'Lớp Công nghệ thông tin 1', N'Công nghệ thông tin'),
('L2', N'Lớp Kế toán 1', N'Kế toán');
PRINT N'Đã chèn dữ liệu bảng lop';
GO

-- Chèn dữ liệu bảng sinhvien (50 sinh viên có tên cụ thể)
INSERT INTO sinhvien (mssv, hoten, phai, ngaysinh, mslop, hocbong) VALUES
-- Lớp L1 - Công nghệ thông tin (25 sinh viên)
('SV001', N'Nguyễn Văn An', N'Nam', '2000-01-15', 'L1', 5000000),
('SV002', N'Trần Thị Bích', N'Nữ', '2000-02-20', 'L1', 6000000),
('SV003', N'Lê Văn Cường', N'Nam', '2000-03-10', 'L1', 4500000),
('SV004', N'Phạm Thị Dung', N'Nữ', '2000-04-25', 'L1', 5500000),
('SV005', N'Hoàng Văn Đạt', N'Nam', '2000-05-05', 'L1', 4800000),
('SV006', N'Vũ Thị Em', N'Nữ', '2000-06-15', 'L1', 5200000),
('SV007', N'Đặng Văn Phong', N'Nam', '2000-07-20', 'L1', 4700000),
('SV008', N'Bùi Thị Gia Hân', N'Nữ', '2000-08-10', 'L1', 5800000),
('SV009', N'Ngô Văn Hiếu', N'Nam', '2000-09-30', 'L1', 4900000),
('SV010', N'Dương Thị Hoa', N'Nữ', '2000-10-12', 'L1', 5100000),
('SV011', N'Phan Văn Hùng', N'Nam', '2000-11-25', 'L1', 4600000),
('SV012', N'Trịnh Thị Kim', N'Nữ', '2000-12-08', 'L1', 5400000),
('SV013', N'Võ Văn Lâm', N'Nam', '2001-01-18', 'L1', 5300000),
('SV014', N'Đỗ Thị Liên', N'Nữ', '2001-02-22', 'L1', 5700000),
('SV015', N'Mai Văn Minh', N'Nam', '2001-03-14', 'L1', 4400000),
('SV016', N'Lý Thị Ngọc', N'Nữ', '2001-04-19', 'L1', 5900000),
('SV017', N'Chu Văn Phú', N'Nam', '2001-05-28', 'L1', 4200000),
('SV018', N'Cao Thị Quỳnh', N'Nữ', '2001-06-03', 'L1', 6100000),
('SV019', N'Lâm Văn Sơn', N'Nam', '2001-07-11', 'L1', 4300000),
('SV020', N'Tô Thị Thanh', N'Nữ', '2001-08-24', 'L1', 5600000),
('SV021', N'Hà Văn Thành', N'Nam', '2001-09-09', 'L1', 4100000),
('SV022', N'Kiều Thị Uyên', N'Nữ', '2001-10-17', 'L1', 6200000),
('SV023', N'Vương Văn Việt', N'Nam', '2001-11-26', 'L1', 4000000),
('SV024', N'Trương Thị Xuân', N'Nữ', '2001-12-05', 'L1', 6300000),
('SV025', N'Đinh Văn Yên', N'Nam', '2002-01-13', 'L1', 3900000),

-- Lớp L2 - Kế toán (25 sinh viên)
('SV026', N'Nguyễn Thị Ánh', N'Nữ', '2000-01-22', 'L2', 5200000),
('SV027', N'Trần Văn Bảo', N'Nam', '2000-02-14', 'L2', 4800000),
('SV028', N'Lê Thị Cẩm', N'Nữ', '2000-03-18', 'L2', 5500000),
('SV029', N'Phạm Văn Dũng', N'Nam', '2000-04-29', 'L2', 4600000),
('SV030', N'Hoàng Thị Em', N'Nữ', '2000-05-07', 'L2', 5800000),
('SV031', N'Vũ Văn Phúc', N'Nam', '2000-06-19', 'L2', 4400000),
('SV032', N'Đặng Thị Giang', N'Nữ', '2000-07-23', 'L2', 5900000),
('SV033', N'Bùi Văn Hào', N'Nam', '2000-08-15', 'L2', 4300000),
('SV034', N'Ngô Thị Hương', N'Nữ', '2000-09-28', 'L2', 6000000),
('SV035', N'Dương Văn Khải', N'Nam', '2000-10-04', 'L2', 4200000),
('SV036', N'Phan Thị Lan', N'Nữ', '2000-11-11', 'L2', 6100000),
('SV037', N'Trịnh Văn Long', N'Nam', '2000-12-21', 'L2', 4100000),
('SV038', N'Võ Thị Mai', N'Nữ', '2001-01-16', 'L2', 6200000),
('SV039', N'Đỗ Văn Nam', N'Nam', '2001-02-27', 'L2', 4000000),
('SV040', N'Mai Thị Oanh', N'Nữ', '2001-03-08', 'L2', 6300000),
('SV041', N'Lý Văn Phước', N'Nam', '2001-04-12', 'L2', 3900000),
('SV042', N'Chu Thị Quế', N'Nữ', '2001-05-25', 'L2', 6400000),
('SV043', N'Cao Văn Sang', N'Nam', '2001-06-30', 'L2', 3800000),
('SV044', N'Lâm Thị Tuyết', N'Nữ', '2001-07-09', 'L2', 6500000),
('SV045', N'Tô Văn Thắng', N'Nam', '2001-08-18', 'L2', 3700000),
('SV046', N'Hà Thị Vân', N'Nữ', '2001-09-22', 'L2', 6600000),
('SV047', N'Kiều Văn Xuân', N'Nam', '2001-10-31', 'L2', 3600000),
('SV048', N'Vương Thị Yến', N'Nữ', '2001-11-14', 'L2', 6700000),
('SV049', N'Trương Văn Bình', N'Nam', '2001-12-03', 'L2', 3500000),
('SV050', N'Đinh Thị Châu', N'Nữ', '2002-01-26', 'L2', 6800000);
PRINT N'Đã chèn dữ liệu bảng sinhvien';
GO

-- Chèn dữ liệu bảng dangky
INSERT INTO dangky (mssv, msmon, diem1, diem2, diem3) VALUES
-- Sinh viên lớp L1
('SV001', 'M01', 7.5, 8.0, 8.5),
('SV001', 'M02', 6.5, 7.0, 7.5),
('SV002', 'M01', 8.0, 8.5, 9.0),
('SV003', 'M02', 7.0, 7.5, 8.0),
('SV004', 'M01', 6.0, 7.5, 8.5),
('SV005', 'M02', 8.5, 9.0, 9.5),
('SV006', 'M01', 7.0, 7.5, 8.0),
('SV007', 'M03', 6.5, 7.5, 8.5),
('SV008', 'M04', 8.0, 8.0, 8.0),
('SV009', 'M05', 7.5, 8.5, 9.0),

-- Sinh viên lớp L2
('SV026', 'M01', 7.0, 7.5, 8.0),
('SV027', 'M02', 8.0, 8.5, 9.0),
('SV028', 'M03', 6.5, 7.0, 7.5),
('SV029', 'M04', 7.5, 8.0, 8.5),
('SV030', 'M05', 8.5, 9.0, 9.5),
('SV031', 'M01', 6.0, 7.0, 8.0),
('SV032', 'M02', 7.0, 7.5, 8.0),
('SV033', 'M03', 8.0, 8.5, 9.0),
('SV034', 'M04', 6.5, 7.5, 8.5),
('SV035', 'M05', 7.5, 8.0, 8.5);
PRINT N'Đã chèn dữ liệu bảng dangky';
GO

-- ============================================================================
-- XÓA CÁC VIEW CŨ NẾU TỒN TẠI
-- ============================================================================

IF OBJECT_ID('sv1', 'V') IS NOT NULL DROP VIEW sv1;
IF OBJECT_ID('sv2', 'V') IS NOT NULL DROP VIEW sv2;
IF OBJECT_ID('sv1_doc1', 'V') IS NOT NULL DROP VIEW sv1_doc1;
IF OBJECT_ID('sv1_doc2', 'V') IS NOT NULL DROP VIEW sv1_doc2;
IF OBJECT_ID('sv2_doc1', 'V') IS NOT NULL DROP VIEW sv2_doc1;
IF OBJECT_ID('sv2_doc2', 'V') IS NOT NULL DROP VIEW sv2_doc2;
PRINT N'Đã xóa các view cũ (nếu có)';
GO

-- ============================================================================
-- PHÂN MẢNH THEO YÊU CẦU ĐỀ BÀI
-- ============================================================================

-- 1. Phân mảnh ngang bảng sinhvien theo mslop
CREATE VIEW sv1 AS
SELECT * FROM sinhvien WHERE mslop = 'L1';
GO

CREATE VIEW sv2 AS
SELECT * FROM sinhvien WHERE mslop = 'L2';
GO

-- 2. Phân mảnh dọc mảnh sv1 (theo đề bài)
CREATE VIEW sv1_doc1 AS
SELECT mssv, hoten, phai, ngaysinh FROM sinhvien WHERE mslop = 'L1';
GO

CREATE VIEW sv1_doc2 AS
SELECT mssv, mslop, hocbong FROM sinhvien WHERE mslop = 'L1';
GO

-- 3. Phân mảnh dọc mảnh sv2 (theo đề bài)
CREATE VIEW sv2_doc1 AS
SELECT mssv, hoten, mslop FROM sinhvien WHERE mslop = 'L2';
GO

CREATE VIEW sv2_doc2 AS
SELECT mssv, phai, ngaysinh, hocbong FROM sinhvien WHERE mslop = 'L2';
GO

PRINT N'Đã tạo các view phân mảnh theo yêu cầu đề bài';
GO

-- ============================================================================
-- XÓA CÁC STORED PROCEDURE CŨ NẾU TỒN TẠI
-- ============================================================================

IF OBJECT_ID('sp_Cau3_Muc1', 'P') IS NOT NULL DROP PROCEDURE sp_Cau3_Muc1;
IF OBJECT_ID('sp_Cau3_Muc2', 'P') IS NOT NULL DROP PROCEDURE sp_Cau3_Muc2;
IF OBJECT_ID('sp_Cau4_Muc1', 'P') IS NOT NULL DROP PROCEDURE sp_Cau4_Muc1;
IF OBJECT_ID('sp_Cau4_Muc2', 'P') IS NOT NULL DROP PROCEDURE sp_Cau4_Muc2;
PRINT N'Đã xóa các stored procedure cũ (nếu có)';
GO

-- ============================================================================
-- STORED PROCEDURE CHO CÁC CÂU TRUY VẤN
-- ============================================================================

-- Câu 3: Nhập vào mã số lớp, cho biết thông tin sinh viên (Mức 1 - Toàn cục)
CREATE PROCEDURE sp_Cau3_Muc1
    @mslop VARCHAR(10)
AS
BEGIN
    SELECT * FROM sinhvien WHERE mslop = @mslop;
END;
GO

-- Câu 3: Nhập vào mã số lớp, cho biết thông tin sinh viên (Mức 2 - Phân mảnh)
CREATE PROCEDURE sp_Cau3_Muc2
    @mslop VARCHAR(10)
AS
BEGIN
    IF @mslop = 'L1'
        SELECT * FROM sv1;
    ELSE IF @mslop = 'L2'
        SELECT * FROM sv2;
    ELSE
        PRINT N'Không tìm thấy lớp ' + @mslop;
END;
GO

-- Câu 4: Sửa mã lớp từ L1 sang L2 (Mức 1 - Toàn cục)
CREATE PROCEDURE sp_Cau4_Muc1
    @mssv VARCHAR(10),
    @mslop_moi VARCHAR(10)
AS
BEGIN
    UPDATE sinhvien SET mslop = @mslop_moi WHERE mssv = @mssv;
    
    IF @@ROWCOUNT > 0
        PRINT N'Cập nhật thành công!';
    ELSE
        PRINT N'Không tìm thấy sinh viên!';
END;
GO

-- Câu 4: Sửa mã lớp từ L1 sang L2 (Mức 2 - Phân mảnh)
CREATE PROCEDURE sp_Cau4_Muc2
    @mssv VARCHAR(10),
    @mslop_moi VARCHAR(10)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- 1. Lấy thông tin sinh viên cần chuyển
        DECLARE @hoten NVARCHAR(100), @phai NVARCHAR(10), 
                @ngaysinh DATE, @hocbong DECIMAL(10,2), @mslop_cu VARCHAR(10);
                
        SELECT @hoten = hoten, @phai = phai, @ngaysinh = ngaysinh, 
               @hocbong = hocbong, @mslop_cu = mslop
        FROM sinhvien WHERE mssv = @mssv;
        
        IF @mslop_cu IS NULL
        BEGIN
            PRINT N'Không tìm thấy sinh viên ' + @mssv;
            RETURN;
        END;

        -- KIỂM TRA ĐIỀU KIỆN CHUYỂN
        IF @mslop_cu = @mslop_moi
        BEGIN
             PRINT N'Lỗi: Mã lớp mới (' + @mslop_moi + N') trùng với mã lớp cũ (' + @mslop_cu + N'). Không thực hiện chuyển.';
             RETURN;
        END
        
        -- 2. Xóa dữ liệu liên quan trong bảng dangky trước
        DELETE FROM dangky WHERE mssv = @mssv;

        -- 3. Xóa khỏi mảnh cũ (bảng gốc)
        DELETE FROM sinhvien WHERE mssv = @mssv;
        
        -- 4. Thêm vào mảnh mới (bảng gốc)
        INSERT INTO sinhvien (mssv, hoten, phai, ngaysinh, mslop, hocbong)
        VALUES (@mssv, @hoten, @phai, @ngaysinh, @mslop_moi, @hocbong);
        
        COMMIT TRANSACTION;
        PRINT N'Chuyển lớp thành công! Sinh viên ' + @mssv + N' đã chuyển từ ' + @mslop_cu + N' sang ' + @mslop_moi;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        PRINT N'Lỗi: ' + ERROR_MESSAGE();
    END CATCH;
END;
GO

PRINT N'Đã tạo các stored procedure';
GO

-- ============================================================================
-- TEST CÁC CHỨC NĂNG
-- ============================================================================

PRINT N'';
PRINT N'=== BẮT ĐẦU TEST CÁC CHỨC NĂNG ===';
PRINT N'';

-- Test Câu 3 Mức 1
PRINT N'=== CÂU 3 MỨC 1 - SINH VIÊN LỚP L1 (25 sinh viên) ===';
EXEC sp_Cau3_Muc1 'L1';

PRINT N'=== CÂU 3 MỨC 1 - SINH VIÊN LỚP L2 (25 sinh viên) ===';
EXEC sp_Cau3_Muc1 'L2';

PRINT N'';

-- Test Câu 3 Mức 2
PRINT N'=== CÂU 3 MỨC 2 - SINH VIÊN LỚP L1 (Phân mảnh) ===';
EXEC sp_Cau3_Muc2 'L1';

PRINT N'=== CÂU 3 MỨC 2 - SINH VIÊN LỚP L2 (Phân mảnh) ===';
EXEC sp_Cau3_Muc2 'L2';

PRINT N'';

-- Test Câu 4 Mức 1
PRINT N'=== CÂU 4 MỨC 1 - CHUYỂN SV001 TỪ L1 SANG L2 ===';
EXEC sp_Cau4_Muc1 'SV001', 'L2';

PRINT N'';

-- Kiểm tra kết quả sau khi chuyển
PRINT N'=== KIỂM TRA SAU KHI CHUYỂN LỚP (Mức 1) ===';
PRINT N'Lớp L1 (24 sinh viên):';
EXEC sp_Cau3_Muc1 'L1';
PRINT N'Lớp L2 (26 sinh viên):';
EXEC sp_Cau3_Muc1 'L2';

PRINT N'';

-- Test Câu 4 Mức 2 (chuyển về L1)
PRINT N'=== CÂU 4 MỨC 2 - CHUYỂN SV001 TỪ L2 VỀ L1 ===';
EXEC sp_Cau4_Muc2 'SV001', 'L1';

PRINT N'';

-- Kiểm tra kết quả
PRINT N'=== KIỂM TRA SAU KHI CHUYỂN LỚP (Mức 2) ===';
PRINT N'Lớp L1 (25 sinh viên):';
EXEC sp_Cau3_Muc2 'L1';
PRINT N'Lớp L2 (25 sinh viên):';
EXEC sp_Cau3_Muc2 'L2';

PRINT N'';

-- Xem các phân mảnh dọc
PRINT N'=== PHÂN MẢNH DỌC SV1 ===';
SELECT * FROM sv1_doc1;
SELECT * FROM sv1_doc2;

PRINT N'=== PHÂN MẢNH DỌC SV2 ===';
SELECT * FROM sv2_doc1;
SELECT * FROM sv2_doc2;

PRINT N'';
PRINT N'=== HOÀN TẤT TEST ===';
PRINT N'Database QuanLySinhVien đã được tạo thành công với 50 sinh viên!';
PRINT N'Phân mảnh ngang: L1 (25 SV) - L2 (25 SV)';
PRINT N'Phân mảnh dọc: Đã tạo đúng theo yêu cầu đề bài';
GO