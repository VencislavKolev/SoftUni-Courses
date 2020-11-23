--Task 1
CREATE TABLE Minions(
	Id INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	Age TINYINT
	);

--Task 2 
CREATE TABLE Towns(
	Id int primary key not null,
	[Name] nvarchar(50) not null
	)

--Task 3
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

--Task 4
INSERT INTO Towns(Id,[Name])
VALUES
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')

INSERT INTO Minions(Id,[Name],Age,TownId)
	VALUES
		(1,'Kevin',22,1),
		(2,'Bob',15,3),
		(3,'Steward',NULL,2)

--Task 5
TRUNCATE TABLE Minions

--Task 6 
DROP TABLE Minions
DROP TABLE Towns

--Task 7
CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX)
CHECK(DATALENGTH(Picture) <= 2*1024*1024),
Height DECIMAL(3,2),
[Weight] DECIMAL(5,2),
Gender CHAR(1) NOT NULL
CHECK(Gender = 'm' OR Gender = 'f'),
Birthdate DATETIME2 NOT NULL,
Biography NVARCHAR(MAX)
)

INSERT INTO People ([Name],Gender,Birthdate)
VALUES 
('Venci0','m','04-07-1997'),
('Venci1','m','04-07-1997'),
('Venci2','m','04-07-1997'),
('Venci3','m','04-07-1997'),
('Venci4','m','04-07-1997')

--Task 8

CREATE TABLE Users(
Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
Username VARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX)
CHECK (DATALENGTH(ProfilePicture) <= 900*1024),
LastLoginTime DATETIME2,
IsDeleted BIT NOT NULL
)

INSERT INTO Users(Username,[Password],IsDeleted)
VALUES
('Test0',123456,0),
('Test1',123456,1),
('Test2',123456,0),
('Test3',123456,1),
('Test4',123456,1)

--Task 9
ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC07BB4B5B65]

ALTER TABLE Users
ADD CONSTRAINT PK_Users_CompositeIdUsername
PRIMARY KEY(Id,Username)

--Task 10
ALTER TABLE Users
ADD CONSTRAINT CK_Users_PasswordLength
CHECK(LEN([Password]) >=5 )

--Task 11
ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

INSERT INTO Users(Username,[Password],IsDeleted)
VALUES
('TestNoTime',123456,0)

--Task 12
ALTER TABLE Users
DROP CONSTRAINT PK_Users_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id
PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_UsernameLength
CHECK (LEN(Username) >= 3)

--Task 13
CREATE DATABASE Movies
--USE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY,
DirectorName NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY,
GenreName NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR(30) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
CopyrightYear INT,
[Length] INT,
GenreId INT FOREIGN KEY REFERENCES Genres(Id),
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Rating INT,
Notes NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName)
VALUES
('Venci0'),('Venci1'),('Venci2'),
('Venci3'),('Venci4')

INSERT INTO Genres(GenreName)
VALUES
('Comedy'),('Sci-Fi'),('Romantic'),
('Horror'),('Kids')

INSERT INTO Categories(CategoryName)
VALUES
('Action'),('Latest'),('Series'),
('TV Show'),('Sport')

INSERT INTO Movies(Title,DirectorId,GenreId,CategoryId)
VALUES
('Title0',1,2,3),
('Title1',2,3,4),
('Title2',3,4,5),
('Title3',4,5,1),
('Title4',5,1,2)


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


-- Task 16
CREATE DATABASE SoftUni
USE SoftUni

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Addresses(
Id INT PRIMARY KEY IDENTITY,
AddressName NVARCHAR(50) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
MiddleName NVARCHAR(30),
LastName NVARCHAR(30) NOT NULL,
JobTitle NVARCHAR(30) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
HireDate DATE NOT NULL,
Salary DECIMAL(7,2) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

--Task 18
INSERT INTO Towns([Name])
VALUES
('Sofia'),('Plovdiv'),('Varna'),('Burgas')

INSERT INTO Departments([Name])
VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees(FirstName,MiddleName,LastName,
JobTitle,DepartmentId,HireDate,Salary)
VALUES
('Ivan','Ivanov','Ivanov','.NET Developer','4','02/01/2013','3500.00'),
('Petar','Petrov','Petrov','Senior Engineer','1','03/02/2004','4000.00'),
('Maria','Petrova','Ivanova','Intern','5','08/26/2016','525.25'),
('Georgi','Teziev','Ivanov','CEO','2','12/09/2007','3000.00'),
('Peter','Pan','Pan','Intern','3','08/28/2016','599.88')

--Task 19
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--Task 20
SELECT * FROM Towns
ORDER BY[Name] ASC

SELECT * FROM Departments
ORDER BY[Name] ASC

SELECT * FROM Employees
ORDER BY[Salary] DESC

--Task 21
SELECT [Name] FROM Towns
ORDER BY[Name] ASC

SELECT [Name] FROM Departments
ORDER BY[Name] ASC

SELECT [FirstName],[LastName],[JobTitle],[Salary] FROM Employees
ORDER BY[Salary] DESC

--Task 22
UPDATE Employees
SET Salary*=1.1
SELECT Salary FROM Employees