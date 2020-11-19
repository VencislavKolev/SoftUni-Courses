--Task 15
CREATE DATABASE Hotel
--USE Hotel

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
Title NVARCHAR(15) NOT NULL,
Notes NVARCHAR(200)
)

CREATE TABLE Customers(
AccountNumber INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
PhoneNumber INT,
EmergencyName NVARCHAR(20),
EmergencyNumber INT,
Notes NVARCHAR(200)
)

CREATE TABLE RoomStatus(
RoomStatus NVARCHAR(10) PRIMARY KEY NOT NULL,
Notes NVARCHAR(200)
)


CREATE TABLE RoomTypes(
RoomType NVARCHAR(20) PRIMARY KEY NOT NULL,
Notes NVARCHAR(200)
)

CREATE TABLE BedTypes(
BedType NVARCHAR(20) PRIMARY KEY NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Rooms(
RoomNumber INT PRIMARY KEY NOT NULL,
RoomType NVARCHAR(20) FOREIGN KEY REFERENCES RoomTypes(RoomType),
BedType NVARCHAR(20) FOREIGN KEY REFERENCES BedTypes(BedType),
Rate INT NOT NULL,
RoomStatus NVARCHAR(10) FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
Notes NVARCHAR(200)
)

CREATE TABLE Payments(
Id  INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate DATETIME2,
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
FirstDateOccupied DATE NOT NULL,
LastDateOccupied DATE NOT NULL,
TotalDays AS DATEDIFF(DAY,FirstDateOccupied,LastDateOccupied),
AmountCharged DECIMAL(6,2) NOT NULL,
TaxRate INT NOT NULL,
TaxAmount AS (AmountCharged * TaxRate) / 100,
PaymentTotal AS AmountCharged * TaxRate / 100 + AmountCharged,
Notes NVARCHAR(200)
)

CREATE TABLE Occupancies(
Id INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
DateOccupied DATE NOT NULL,
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
RateApplied INT,
PhoneCharge INT,
Notes NVARCHAR(200)
)

INSERT INTO Employees(FirstName, LastName, Title) 
	VALUES
	('Ivan', 'Ivanov', 'Manager'),
	('Georgi', 'Georgiev', 'Host'),
	('Petar', 'Petrov', 'Security')

INSERT INTO Customers(FirstName, LastName)
VALUES
	('Stoycho', 'Stoychev'),
	('Krasimir', 'Krasimirov'),
	('Angel', 'Angelov')

INSERT INTO RoomStatus(RoomStatus)
VALUES
('Occupied'),('Available'),('Unavalable')

INSERT INTO RoomTypes(RoomType)
VALUES
('Single'),('Double'),('Apartment')

INSERT INTO BedTypes(BedType)
VALUES
('Queen'),('King'),('Single')

INSERT INTO Rooms(RoomNumber,RoomType,BedType,Rate,RoomStatus)
VALUES
(212, 'Single', 'Single', 30, 'Available'),
(424, 'Double', 'Queen', 60,'Available'),
(848, 'Apartment', 'King', 90, 'Occupied')

INSERT INTO Payments(EmployeeId,PaymentDate,
AccountNumber,FirstDateOccupied,LastDateOccupied,
AmountCharged,TaxRate)
VALUES
(1, '2013-12-30', 1, '2013-11-30', '2013-12-04', 200.0, 5),
(2, '2016-06-20', 2, '2016-06-06', '2016-06-09', 400.0, 2),
(3, '2019-03-10', 3, '2019-02-27', '2019-03-04', 800.0, 10)

INSERT INTO Occupancies(EmployeeId, DateOccupied,
AccountNumber, RoomNumber, RateApplied, PhoneCharge)
VALUES
(1, '2018-02-02', 1, 212, 40.0, 12),
(2, '2019-04-04', 2, 424, 80.0, 11),
(3, '2020-08-08', 3, 848, 120.0, 10)

--Judje 23
UPDATE Payments
SET TaxRate-=3

--Judje 24
TRUNCATE TABLE Occupancies