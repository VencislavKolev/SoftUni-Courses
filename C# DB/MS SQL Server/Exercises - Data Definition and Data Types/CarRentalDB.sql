--Task 14
CREATE DATABASE CarRental
--USE CarRental

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(30) NOT NULL,
DailyRate INT NOT NULL,
WeeklyRate INT NOT NULL,
MonthlyRate INT,
WeekendRate INT
)

CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY,
PlateNumber INT,
Manufacturer NVARCHAR(20) NOT NULL,
Model NVARCHAR(20) NOT NULL,
CarYear INT NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Doors INT,
Picture VARBINARY(MAX)
CHECK (DATALENGTH(Picture) <= 500 * 1024),
Condition NVARCHAR(10),
Available BIT
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
Title NVARCHAR(15) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY,
DriverLicenceNumber INT NOT NULL,
FullName NVARCHAR(30) NOT NULL,
[Address] NVARCHAR(50) NOT NULL,
City NVARCHAR(30),
ZIPCode INT,
Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
CardId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
TankLevel INT,
KilometrageStart INT,
KilometrageEnd INT,
TotalKilometrage INT,
StartDate DATETIME2,
EndDate DATETIME2,
TotalDays INT NOT NULL,
RateApplied INT,
TaxRate INT,
OrderStatus BIT,
Notes NVARCHAR(MAX)
)

INSERT INTO Categories(CategoryName,DailyRate,WeeklyRate)
VALUES
('Cars',50,250),
('MiniVans',60,300),
('Truck',70,400)

INSERT INTO Cars(Manufacturer,Model,CarYear,CategoryId)
VALUES
('Opel','Corsa',2005,1),
('VW','Transporter',2008,2),
('Mercedes','Sprinter',2010,3)

INSERT INTO Employees(FirstName,LastName,Title)
VALUES
('Vencislav','Kolev','Owner'),
('Andjela','Pavlova','Manager'),
('First','Last','Mechanic')

INSERT INTO Customers(DriverLicenceNumber,FullName,[Address])
VALUES
(123123,'FullName0','SomeAddress0'),
(234234,'FullName1','SomeAddress1'),
(345345,'FullName2','SomeAddress2')

INSERT INTO RentalOrders(EmployeeId,CustomerId,CardId,TotalDays)
VALUES
(1,1,1,3),
(2,3,2,6),
(3,2,3,9)