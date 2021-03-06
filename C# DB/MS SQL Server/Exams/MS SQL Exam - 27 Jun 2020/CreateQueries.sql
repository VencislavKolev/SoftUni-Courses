--CREATE DATABASE WMS

CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL,
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) UNIQUE NOT NULL,
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
	Status VARCHAR(11) CHECK (Status IN ('Pending', 'In Progress', 'Finished')) DEFAULT 'Pending' NOT NULL,
	ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 0 NOT NULL,
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) UNIQUE NOT NULL,
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	Description VARCHAR(255),
	Price DECIMAL(6,2) CHECK (Price > 0) NOT NULL,
	VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT CHECK (StockQty >= 0) DEFAULT 0 NOT NULL
)

CREATE TABLE OrderParts
(
	OrderId INT FOREIGN KEY REFERENCES Orders(OrderId),
	PartId INT FOREIGN KEY REFERENCES Parts(PartId),
	Quantity INT CHECK (Quantity > 0) DEFAULT 1 NOT NULL,
	PRIMARY KEY(OrderId, PartId)
)

CREATE TABLE PartsNeeded
(
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId),
	PartId INT FOREIGN KEY REFERENCES Parts(PartId),
	Quantity INT CHECK (Quantity > 0) DEFAULT 1 NOT NULL,
	PRIMARY KEY (JobId, PartId)
)

--TASK 2
INSERT INTO Clients
VALUES
('Teri', 'Ennaco','570-889-5187'),
('Merlyn', 'Lawler','201-588-7810'),
('Georgene', 'Montezuma','925-615-5185'),
('Jettie', 'Mconnell','908-802-3564'),
('Lemuel', 'Latzke','631-748-6479'),
('Melodie', 'Knipp','805-690-1682'),
('Candida', 'Corbley','908-275-8357')

INSERT INTO Parts
VALUES
('WP8182119','Door Boot Seal', 117.86, 2, 0),
('W10780048','Suspension Rod', 42.81, 1, 0),
('W10841140','Silicone Adhesive', 6.77,	4, 0),
('WPY055980','High Temperature Adhesive', 13.94, 3, 0)

--TASK 3
UPDATE Jobs
	SET Status = 'In Progress',
		MechanicId = 3
WHERE Status = 'Pending'

--TASK 4
DELETE FROM OrderParts
WHERE OrderId = 19
  
DELETE FROM Orders
WHERE OrderId = 19