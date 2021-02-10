--CREATE DATABASE TripService

CREATE TABLE Cities
(
	Id int PRIMARY KEY IDENTITY,
	Name NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
	Id int PRIMARY KEY IDENTITY,
	Name NVARCHAR(30) NOT NULL,
	CityId int NOT NULL FOREIGN KEY REFERENCES Cities(Id),
	EmployeeCount int NOT NULL,
	BaseRate DECIMAL(18,2)
)

CREATE TABLE Rooms
(
	Id int PRIMARY KEY IDENTITY,
	Price DECIMAL(18,2) NOT NULL,
	Type NVARCHAR(20) NOT NULL,
	Beds int NOT NULL,
	HotelId int NOT NULL FOREIGN KEY REFERENCES Hotels(Id)
)

CREATE TABLE Trips
(
	Id int PRIMARY KEY IDENTITY,
	RoomId int NOT NULL FOREIGN KEY REFERENCES Rooms(Id),
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CHECK (BookDate < ArrivalDate),
	CHECK (ArrivalDate < ReturnDate),
	CancelDate DATE
)

CREATE TABLE Accounts
(
	Id int PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId int NOT NULL FOREIGN KEY REFERENCES Cities(Id),
	BirthDate DATE NOT NULL,
	Email NVARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips
(
	AccountId int NOT NULL FOREIGN KEY REFERENCES Accounts(Id),
	TripId int NOT NULL FOREIGN KEY REFERENCES Trips(Id),
	Luggage int NOT NULL CHECK (Luggage >= 0)
	PRIMARY KEY (AccountId, TripId)
)

--TASK 2
INSERT INTO Accounts
VALUES
('John', 'Smith', 'Smith', 34,			'1975-07-21',	'j_smith@gmail.com'),
('Gosho', NULL,	'Petrov', 11,			'1978-05-16',	'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov',	59,		'1849-09-26',	'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2,'1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips
VALUES
(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),	   
(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

--TASK 3
UPDATE Rooms
SET Price *= 1.14
WHERE HotelId IN(5, 7, 9)

--TASK 4
SELECT * FROM Accounts
WHERE Id = 47

DELETE FROM AccountsTrips
WHERE AccountId = 47