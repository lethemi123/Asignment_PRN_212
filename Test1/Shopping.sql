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
