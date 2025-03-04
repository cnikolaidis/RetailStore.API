CREATE TABLE PaymentMethods
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
	Title NVARCHAR(MAX) DEFAULT NULL
);

INSERT INTO PaymentMethods (Title)
VALUES ('Credit Card'), ('Debit Card'), ('PayPal'), ('Bank Transfer'), ('Cash on Delivery'), ('Apple Pay'), ('Google Pay'), ('Stripe'), ('Amazon Pay'), ('Bitcoin');

CREATE TABLE DeliveryStatuses
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
	Title NVARCHAR(MAX) DEFAULT NULL
);

INSERT INTO DeliveryStatuses (Title)
VALUES ('Pending'), ('Shipped'), ('Out for Delivery'), ('Delivered'), ('Returned'), ('Failed Delivery'), ('In Transit'), ('Delayed'), ('Canceled'), ('Awaiting Pickup');

CREATE TABLE Products
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
	Title NVARCHAR(MAX) DEFAULT NULL,
	Description NVARCHAR(MAX) DEFAULT NULL,
	Price DECIMAL(18,5) DEFAULT 0.0,
	Stock INT NOT NULL DEFAULT 0,
	DateCreated DATETIME NOT NULL DEFAULT GETDATE(),
	DateUpdated DATETIME NOT NULL DEFAULT GETDATE()
);

INSERT INTO Products (Title, Description, Price, Stock, DateCreated, DateUpdated)
VALUES
    ('Laptop', '14-inch laptop with 8GB RAM and 256GB SSD', 799.99, 50, GETDATE(), GETDATE()),
    ('Smartphone', 'Latest model with 6.5-inch screen and 128GB storage', 599.99, 120, GETDATE(), GETDATE()),
    ('Headphones', 'Noise-cancelling over-ear headphones', 129.99, 200, GETDATE(), GETDATE()),
    ('Bluetooth Speaker', 'Portable Bluetooth speaker with 20-hour battery life', 49.99, 150, GETDATE(), GETDATE()),
    ('Smartwatch', 'Fitness-focused smartwatch with heart rate monitor', 199.99, 75, GETDATE(), GETDATE()),
    ('Keyboard', 'Wireless mechanical keyboard with RGB lighting', 89.99, 180, GETDATE(), GETDATE()),
    ('Mouse', 'Ergonomic wireless mouse', 29.99, 250, GETDATE(), GETDATE()),
    ('Tablet', '10-inch tablet with 64GB storage', 249.99, 80, GETDATE(), GETDATE()),
    ('4K Monitor', '27-inch 4K ultra HD monitor', 499.99, 30, GETDATE(), GETDATE()),
    ('Smart Light Bulb', 'Wi-Fi-enabled smart light bulb with color changing feature', 19.99, 300, GETDATE(), GETDATE()),
    ('Camera', 'DSLR camera with 18-55mm lens', 899.99, 40, GETDATE(), GETDATE()),
    ('External Hard Drive', '1TB external hard drive for data storage', 59.99, 100, GETDATE(), GETDATE()),
    ('Power Bank', 'Portable power bank with 10,000mAh capacity', 24.99, 180, GETDATE(), GETDATE()),
    ('Game Console', 'Next-gen gaming console with 1TB storage', 499.99, 60, GETDATE(), GETDATE()),
    ('Gaming Mouse', 'High precision gaming mouse with adjustable DPI', 39.99, 140, GETDATE(), GETDATE());

CREATE TABLE Customers
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
	FullName NVARCHAR(MAX) DEFAULT NULL,
	MailAddress NVARCHAR(MAX) DEFAULT NULL,
	PhoneNo NVARCHAR(MAX) DEFAULT NULL,
	BirthDate DATETIME NOT NULL DEFAULT NULL,
	DateCreated DATETIME NOT NULL DEFAULT GETDATE(),
	DateUpdated DATETIME NOT NULL DEFAULT GETDATE()
);

INSERT INTO Customers (FullName, MailAddress, PhoneNo, BirthDate, DateCreated, DateUpdated)
VALUES
    ('John Doe', 'john.doe@example.com', '+1 555-1234', '1985-06-15', GETDATE(), GETDATE()),
    ('Jane Smith', 'jane.smith@example.com', '+1 555-5678', '1990-11-22', GETDATE(), GETDATE()),
    ('Alice Johnson', 'alice.johnson@example.com', '+1 555-8765', '1982-03-09', GETDATE(), GETDATE()),
    ('Robert Brown', 'robert.brown@example.com', '+1 555-4321', '1975-12-30', GETDATE(), GETDATE()),
    ('Emily Davis', 'emily.davis@example.com', '+1 555-9988', '2000-01-25', GETDATE(), GETDATE()),
    ('Michael Wilson', 'michael.wilson@example.com', '+1 555-5566', '1988-07-19', GETDATE(), GETDATE()),
    ('Sophia Martinez', 'sophia.martinez@example.com', '+1 555-6655', '1995-05-03', GETDATE(), GETDATE()),
    ('William Taylor', 'william.taylor@example.com', '+1 555-2233', '1992-02-18', GETDATE(), GETDATE()),
    ('Olivia Anderson', 'olivia.anderson@example.com', '+1 555-8899', '1989-09-12', GETDATE(), GETDATE()),
    ('James Thomas', 'james.thomas@example.com', '+1 555-4444', '1993-08-27', GETDATE(), GETDATE());

CREATE TABLE Orders
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	TotalAmount DECIMAL(18, 5) DEFAULT 0.0,
	DateCreated DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE OrderItems
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
	OrderId INT FOREIGN KEY REFERENCES Orders(Id),
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	Quantity INT NOT NULL DEFAULT 0,
	SubTotal DECIMAL(18, 5) DEFAULT 0.0,
	DateCreated DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Payments
(
	OrderId INT PRIMARY KEY NOT NULL FOREIGN KEY REFERENCES Orders(Id) ON DELETE CASCADE,
	PaymentMethodId INT FOREIGN KEY REFERENCES PaymentMethods(Id),
	DateCreated DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Deliveries
(
	OrderId INT PRIMARY KEY NOT NULL FOREIGN KEY REFERENCES Orders(Id) ON DELETE CASCADE,
	TrackingNumber NVARCHAR(MAX) NOT NULL DEFAULT NULL,
	DateCreated DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE DeliveryDetails
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
	DeliveryId INT FOREIGN KEY REFERENCES Deliveries(OrderId),
	DeliveryStatusId INT FOREIGN KEY REFERENCES DeliveryStatuses(Id),
	DateCreated DATETIME NOT NULL DEFAULT GETDATE()
);