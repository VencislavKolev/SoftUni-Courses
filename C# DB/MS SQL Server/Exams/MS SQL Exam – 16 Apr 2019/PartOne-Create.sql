CREATE DATABASE Airport
USE Airport

CREATE TABLE Planes
(
Id int PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL,
Seats int NOT NULL,
[Range] int NOT NULL,
)

CREATE TABLE Flights
(
Id int PRIMARY KEY IDENTITY,
DepartureTime datetime,
ArrivalTime datetime,
Origin NVARCHAR(50) NOT NULL,
Destination NVARCHAR(50) NOT NULL,
PlaneId int NOT NULL FOREIGN KEY REFERENCES Planes(Id)
)

CREATE TABLE Passengers
(
Id int PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Age int NOT NULL,
Address NVARCHAR(30) NOT NULL,
PassportId NCHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes
(
Id int PRIMARY KEY IDENTITY,
Type NVARCHAR(30) NOT NULL,
)

CREATE TABLE Luggages
(
Id int PRIMARY KEY IDENTITY,
LuggageTypeId int NOT NULL FOREIGN KEY REFERENCES LuggageTypes(Id),
PassengerId int NOT NULL FOREIGN KEY REFERENCES Passengers(Id),
)

CREATE TABLE Tickets
(
Id int PRIMARY KEY IDENTITY,
PassengerId int NOT NULL FOREIGN KEY REFERENCES Passengers(Id),
FlightId int NOT NULL FOREIGN KEY REFERENCES Flights(Id),
LuggageId int NOT NULL FOREIGN KEY REFERENCES Luggages(Id),
Price DECIMAL(18,2) NOT NULL
)

--TASK 2
INSERT INTO Planes (Name, Seats, Range)
VALUES
('Airbus 336', 112, 5132),
('Airbus 330', 432, 5325),
('Boeing 369', 231, 2355),
('Stelt 297', 254, 2143),
('Boeing 338', 165, 5111),
('Airbus 558', 387, 1342),
('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes(Type)
VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

--TASK 3
--SELECT Id FROM Flights
--WHERE Destination = 'Carlsbad'

UPDATE Tickets
SET Price *= 1.13
WHERE FlightId = (SELECT Id FROM Flights
				WHERE Destination = 'Carlsbad')


--TASK 4
--SELECT * FROM Flights
--WHERE Destination = 'Ayn Halagim'
--FlightId 30

DELETE FROM Tickets
WHERE FlightId = 30

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'