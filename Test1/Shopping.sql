-- Bảng Category
CREATE TABLE Category (
    CategoryID VARCHAR(50) PRIMARY KEY,
    CategoryName VARCHAR(50) NOT NULL
);

-- Bảng Product
CREATE TABLE Product (
    ProductID VARCHAR(50) PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,                    -- Tăng kích thước để lưu tên dài hơn
    ProductPrice FLOAT NOT NULL CHECK (ProductPrice >= 0), -- Đảm bảo giá không âm
    ProductDescription VARCHAR(500),                      -- Mở rộng miêu tả nếu cần
    ImagePathProduct VARCHAR(255),
    Stock INT CHECK (Stock >= 0),                         -- Đảm bảo số lượng không âm
    CategoryID VARCHAR(50),                               -- Khóa ngoại đến bảng Category
    CreatedAt DATE DEFAULT GETDATE(),                  -- Mặc định là ngày hiện tại
    UpdatedAt DATE DEFAULT GETDATE(),
    CONSTRAINT FK_Product_Category FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID)
);

-- Bảng Person (Người dùng)
CREATE TABLE Person (
    Id VARCHAR(50) PRIMARY KEY,
    UserName VARCHAR(100) NOT NULL UNIQUE,                -- UNIQUE để tránh trùng username
    Password VARCHAR(255) NOT NULL,                       -- Password không được để trống
    FName VARCHAR(100),
    LName VARCHAR(100),
    Gender VARCHAR(10),
    Age INT CHECK (Age >= 0 AND Age <= 120),              -- Kiểm tra tuổi hợp lý
    Address VARCHAR(255),
    PhoneNumber VARCHAR(20),
    Email VARCHAR(100) UNIQUE,                            -- UNIQUE để đảm bảo email không trùng
    DateOfBirth DATE,
    PathImagePerson VARCHAR(255),
    RoleAccount BIT DEFAULT 0,                            -- Mặc định là user (0)
    Balance FLOAT DEFAULT 0 CHECK (Balance >= 0)          -- Số dư không âm
);

-- Bảng Cart (Giỏ hàng)
CREATE TABLE Cart (
    CartId VARCHAR(50) PRIMARY KEY,
    ProductID VARCHAR(50),                                -- Tham chiếu đến bảng Product
    PersonId VARCHAR(50),                                 -- Tham chiếu đến bảng Person
    Quantity INT CHECK (Quantity > 0),                     -- Đảm bảo số lượng dương
    CONSTRAINT FK_Cart_Product FOREIGN KEY (ProductID) REFERENCES Product(ProductID),
    CONSTRAINT FK_Cart_Person FOREIGN KEY (PersonId) REFERENCES Person(Id)
);

-- Bảng Orders (Đơn hàng)
CREATE TABLE Orders (
    OrderId VARCHAR(50) PRIMARY KEY,
    PersonId VARCHAR(50),                                 -- Tham chiếu đến người đặt hàng
    OrderAddress VARCHAR(255),
    TotalMoney FLOAT CHECK (TotalMoney >= 0),              -- Đảm bảo tổng tiền không âm
    OrderStatus VARCHAR(50) DEFAULT 'Processing..',            -- Mặc định trạng thái đơn hàng là 'Pending'
    CONSTRAINT FK_Order_Person FOREIGN KEY (PersonId) REFERENCES Person(Id)
);

-- Bảng OrderDetails (Chi tiết đơn hàng)
CREATE TABLE OrderDetails (
    OrderDetailId VARCHAR(50) PRIMARY KEY,                 -- Khóa chính riêng cho OrderDetail
    OrderID VARCHAR(50),                                   -- Tham chiếu đến đơn hàng
    ProductID VARCHAR(50),                                 -- Tham chiếu đến sản phẩm
    Quantity INT CHECK (Quantity > 0),                     -- Đảm bảo số lượng sản phẩm > 0
    CONSTRAINT FK_OrderDetail_Order FOREIGN KEY (OrderID) REFERENCES Orders(OrderId),
    CONSTRAINT FK_OrderDetail_Product FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

CREATE TABLE ProductVariants (
    VariantID VARCHAR(50) PRIMARY KEY,                     -- Mã biến thể (ví dụ: P001-128GB)
    ProductID VARCHAR(50) NOT NULL,                        -- FK đến bảng Product
    Storage VARCHAR(50),                                   -- Dung lượng, cấu hình (VD: 128GB, 16GB RAM)
    Price FLOAT CHECK (Price >= 0),                        -- Giá tiền biến thể
    Stock INT CHECK (Stock >= 0),                          -- Số lượng tồn kho riêng cho biến thể
    CONSTRAINT FK_ProductVariants_Product FOREIGN KEY (ProductID)
        REFERENCES Product(ProductID)
);


INSERT INTO Category (CategoryID, CategoryName) VALUES
('CAT01', 'Smartphones'),
('CAT02', 'Laptops'),
('CAT03', 'Accessories'),
('CAT04', 'Tablets'),
('CAT05', 'Smartwatches');

INSERT INTO Product (ProductID, ProductName, ProductDescription, ImagePathProduct, CategoryID, CreatedAt, UpdatedAt)
VALUES
('P007', 'iPhone 13', 'Previous generation Apple iPhone', 'E:\Asignment_PRN_212\Test1\ImageProduct\Smartphones\iphone13.png', 'CAT01', GETDATE(), GETDATE()),
('P008', 'Samsung Galaxy S21', 'Android phone with 120Hz AMOLED display', 'E:\Asignment_PRN_212\Test1\ImageProduct\Smartphones\SSU21.png', 'CAT01', GETDATE(), GETDATE()),
('P009', 'Google Pixel 6', 'Google smartphone with Tensor chip', 'E:\Asignment_PRN_212\Test1\ImageProduct\Smartphones\Google Pixel 6.png', 'CAT01', GETDATE(), GETDATE()),
('P010', 'OnePlus 9 Pro', 'Flagship Android phone with 5G support', 'E:\Asignment_PRN_212\Test1\ImageProduct\Smartphones\oneplus-9_3.png', 'CAT01', GETDATE(), GETDATE()),
('P011', 'Xiaomi Mi 11', 'Xiaomi flagship with Snapdragon 888', 'E:\Asignment_PRN_212\Test1\ImageProduct\Smartphones\Xiaomi Mi 11.png', 'CAT01', GETDATE(), GETDATE());

INSERT INTO Product (ProductID, ProductName, ProductDescription, ImagePathProduct,  CategoryID, CreatedAt, UpdatedAt)
VALUES
('P012', 'HP Spectre x360', 'Premium convertible laptop with Intel i7', 'E:\Asignment_PRN_212\Test1\ImageProduct\Laptops\HP Spectre x360.png',  'CAT02', GETDATE(), GETDATE()),
('P013', 'Lenovo ThinkPad X1 Carbon', 'Lightweight business laptop with Intel i7', 'E:\Asignment_PRN_212\Test1\ImageProduct\Laptops\Lenovo ThinkPad X1 Carbon.png', 'CAT02', GETDATE(), GETDATE()),
('P014', 'Asus ZenBook 14', 'Compact and powerful laptop with AMD Ryzen 7', 'E:\Asignment_PRN_212\Test1\ImageProduct\Laptops\Asus ZenBook 14.png',  'CAT02', GETDATE(), GETDATE()),
('P015', 'Microsoft Surface Laptop 4', 'Laptop with PixelSense display and Intel 11th Gen chip', '"E:\Asignment_PRN_212\Test1\ImageProduct\Laptops\Microsoft Surface Laptop 4.png"',  'CAT02', GETDATE(), GETDATE()),
('P016', 'Acer Swift 3', 'Budget-friendly ultrabook with Ryzen 5', 'E:\Asignment_PRN_212\Test1\ImageProduct\Laptops\Acer Swift 3.png', 'CAT02', GETDATE(), GETDATE());

INSERT INTO Product (ProductID, ProductName, ProductDescription, ImagePathProduct, CategoryID, CreatedAt, UpdatedAt)
VALUES
('P017', 'Logitech MX Master 3', 'Wireless mouse with ergonomic design', 'E:\Asignment_PRN_212\Test1\ImageProduct\Accessories\Logitech MX Master 3.png',  'CAT03', GETDATE(), GETDATE()),
('P018', 'Razer Kraken Headset', 'Gaming headset with RGB lighting and surround sound', 'E:\Asignment_PRN_212\Test1\ImageProduct\Accessories\Razer Kraken Headset.png',  'CAT03', GETDATE(), GETDATE()),
('P019', 'Anker PowerCore 10000', 'Portable charger with 10000mAh capacity', 'E:\Asignment_PRN_212\Test1\ImageProduct\Accessories\Anker PowerCore 10000.png',  'CAT03', GETDATE(), GETDATE()),
('P020', 'Samsung T7 Portable SSD', 'Fast portable storage with USB 3.2', 'E:\Asignment_PRN_212\Test1\ImageProduct\Accessories\Samsung T7 Portable SSD.png',  'CAT03', GETDATE(), GETDATE()),
('P021', 'Apple AirTag', 'Bluetooth tracker for keys, bags, and more', 'E:\Asignment_PRN_212\Test1\ImageProduct\Accessories\Apple AirTag.png',  'CAT03', GETDATE(), GETDATE());

INSERT INTO Product (ProductID, ProductName, ProductDescription, ImagePathProduct, CategoryID, CreatedAt, UpdatedAt)
VALUES
('P022', 'Apple iPad Pro 12.9', '12.9-inch tablet with M1 chip and ProMotion display', 'E:\Asignment_PRN_212\Test1\ImageProduct\Tablets\Apple iPad Pro 12.9.png', 'CAT04', GETDATE(), GETDATE()),
('P023', 'Samsung Galaxy Tab S7+', 'Android tablet with AMOLED display and S Pen support', 'E:\Asignment_PRN_212\Test1\ImageProduct\Tablets\Samsung Galaxy Tab S7+.png',  'CAT04', GETDATE(), GETDATE()),
('P024', 'Microsoft Surface Pro 7', '2-in-1 tablet with Intel i5 and Type Cover keyboard', 'E:\Asignment_PRN_212\Test1\ImageProduct\Tablets\Microsoft Surface Pro 7.png', 'CAT04', GETDATE(), GETDATE()),
('P025', 'Amazon Fire HD 10', 'Affordable tablet with 10.1-inch screen', 'E:\Asignment_PRN_212\Test1\ImageProduct\Tablets\_0002_6351530_sd.jpgmaxheight640maxwid_2.png',  'CAT04', GETDATE(), GETDATE()),
('P026', 'Lenovo Tab P11 Pro', 'Android tablet with Dolby Vision and 4K support', 'E:\Asignment_PRN_212\Test1\ImageProduct\Tablets\Lenovo Tab P11 Pro.png', 'CAT04', GETDATE(), GETDATE());

INSERT INTO Product (ProductID, ProductName, ProductDescription, ImagePathProduct, CategoryID, CreatedAt, UpdatedAt)
VALUES
('P027', 'Apple Watch Series 7', 'Smartwatch with always-on Retina display and fitness tracking', 'E:\Asignment_PRN_212\Test1\ImageProduct\Smartwatches\Apple Watch Series 7.png', 'CAT05', GETDATE(), GETDATE()),
('P028', 'Samsung Galaxy Watch 4', 'Smartwatch with health features and Wear OS', 'E:\Asignment_PRN_212\Test1\ImageProduct\Smartwatches\Samsung Galaxy Watch 4.png',  'CAT05', GETDATE(), GETDATE()),
('P029', 'Garmin Forerunner 945', 'GPS smartwatch for athletes with heart rate monitoring', 'E:\Asignment_PRN_212\Test1\ImageProduct\Smartwatches\Amazfit GTR 3.png', 'CAT05', GETDATE(), GETDATE()),
('P030', 'Fitbit Charge 5', 'Fitness tracker with built-in GPS and ECG monitoring', 'E:\Asignment_PRN_212\Test1\ImageProduct\Smartwatches\Fitbit Charge 5.png',  'CAT05', GETDATE(), GETDATE()),
('P031', 'Amazfit GTR 3', 'Affordable smartwatch with long battery life', 'E:\Asignment_PRN_212\Test1\ImageProduct\Smartwatches\Amazfit GTR 3.png',  'CAT05', GETDATE(), GETDATE());

INSERT INTO Person (Id, UserName, Password, FName, LName, Gender, Age, Address, PhoneNumber, Email, DateOfBirth, PathImagePerson, RoleAccount, Balance)
VALUES
('U006', 'sa', 'sa', 'Alice', 'Nguyen', 'Female', 22, '123 Tech Street', '0901234567', 'Lym@mail.com', '2002-02-20', 'img/user1.jpg', 1, 500.00);


CREATE TABLE ProductVariants_temp (
    VariantID INT PRIMARY KEY IDENTITY(1,1),
    ProductID VARCHAR(10),
    Storage VARCHAR(50),
    Price DECIMAL(10,2),
    Stock INT
);

-- Copy dữ liệu cũ qua (nếu có)
INSERT INTO ProductVariants_temp (ProductID, Storage, Price, Stock)
SELECT ProductID, Storage, Price, Stock FROM ProductVariants;

-- Xóa bảng cũ, đổi tên lại
DROP TABLE ProductVariants;
EXEC sp_rename 'ProductVariants_temp', 'ProductVariants';


-- Smartphones
INSERT INTO ProductVariants (ProductID, Storage, Price, Stock) VALUES
('P007', '128GB', 799.00, 20),
('P007', '256GB', 899.00, 15),

('P008', '128GB', 849.00, 18),
('P008', '256GB', 949.00, 14),

('P009', '128GB', 729.00, 15),
('P009', '256GB', 829.00, 12),

('P010', '128GB', 869.00, 12),
('P010', '256GB', 969.00, 10),

('P011', '128GB', 699.00, 25),
('P011', '256GB', 799.00, 20),

-- Laptops
('P012', '8GB RAM / 512GB SSD', 1199.00, 10),
('P012', '16GB RAM / 1TB SSD', 1399.00, 8),

('P013', '8GB RAM / 512GB SSD', 1299.00, 9),
('P013', '16GB RAM / 1TB SSD', 1499.00, 7),

('P014', '8GB RAM / 256GB SSD', 899.00, 12),
('P014', '16GB RAM / 512GB SSD', 1099.00, 10),

('P015', '8GB RAM / 512GB SSD', 999.00, 10),
('P015', '16GB RAM / 1TB SSD', 1399.00, 9),

('P016', '4GB RAM / 128GB SSD', 749.00, 14),
('P016', '8GB RAM / 256GB SSD', 849.00, 12),

-- Accessories
('P017', 'Standard', 99.00, 30),
('P017', 'Pro Version', 129.00, 20),

('P018', 'Standard', 119.00, 20),
('P018', 'Pro Version', 139.00, 15),

('P019', '10000mAh', 49.00, 50),
('P019', '20000mAh', 69.00, 40),

('P020', '1TB', 119.00, 15),
('P020', '2TB', 169.00, 10),

('P021', 'Single Pack', 29.00, 40),
('P021', 'Double Pack', 49.00, 35),

-- Tablets
('P022', '128GB Wi-Fi', 999.00, 7),
('P022', '256GB Wi-Fi', 1099.00, 5),

('P023', '64GB Wi-Fi', 799.00, 10),
('P023', '128GB Wi-Fi + LTE', 899.00, 8),

('P024', '128GB', 949.00, 6),
('P024', '256GB with Keyboard', 1049.00, 4),

('P025', '32GB', 149.00, 25),
('P025', '64GB', 199.00, 20),

('P026', '64GB', 449.00, 13),
('P026', '128GB', 499.00, 10),

-- Smartwatches
('P027', '41mm', 399.00, 18),
('P027', '45mm', 449.00, 12),

('P028', '44mm', 349.00, 20),
('P028', '44mm LTE', 399.00, 15),

('P029', 'Standard', 499.00, 12),
('P029', 'Premium', 599.00, 8),

('P030', 'Standard', 179.00, 22),
('P030', 'Special Edition', 219.00, 18),

('P031', 'Standard', 129.00, 30),
('P031', 'Limited', 149.00, 25);
DELETE FROM ProductVariants;
