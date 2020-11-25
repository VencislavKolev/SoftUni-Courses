CREATE DATABASE EntityRelationsDemo
USE EntityRelationsDemo
--Task 1


CREATE TABLE Passports(
	PassportID INT PRIMARY KEY IDENTITY (101, 1),
	PassportNumber CHAR(8) NOT NULL
)

CREATE TABLE Person(
	PersonId INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	Salary DECIMAL(7,2) NOT NULL,
	PassportID INT NOT NULL FOREIGN KEY REFERENCES Passports(PassportID) UNIQUE
)

INSERT INTO Passports (PassportNumber)
	VALUES
	('N34FG21B'),
	('K65LO4R7'),
	('ZE657QP2')

INSERT INTO Person ( FirstName, Salary, PassportID)
	VALUES
	('Roberto', 43300.00, 102),
	('Tom', 56100.00, 103),
	('Yana', 60200.00, 101)

--Task 2
CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	EstablishedOn DATE NOT NULL
)

CREATE TABLE Models(
	ModelID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(30) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID) NOT NULL
)


INSERT INTO Manufacturers ([Name], EstablishedOn)
VALUES	
	('BMW', '03/07/1916'),
	('Tesla', '01/01/2003'),
	('Lada', '05/01/1966')

INSERT INTO Models ([Name],ManufacturerID)
VALUES
	('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
	('Nova', 3)

--Task 3
CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY IDENTITY (101, 1),
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams(
	StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT NOT NULL FOREIGN KEY REFERENCES Exams(ExamId),
	PRIMARY KEY (StudentID,ExamID)
)

INSERT INTO Students ([Name])
VALUES
	('Mila'),
	('Toni'),
	('Ron')

INSERT INTO Exams([Name])
VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')

INSERT INTO StudentsExams (StudentID,ExamID)
VALUES
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103)

--SELECT s.Name,e.Name FROM StudentsExams AS se
--JOIN Students AS s ON s.StudentID = se.StudentID
--JOIN Exams AS e ON e.ExamID = se.ExamID

--Task 4
CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers(TeacherID,[Name],ManagerID)
VALUES
	(101,'John', NULL),
	(102,'Maya', 106),
	(103,'Silvia', 106),
	(104,'Ted', 105),
	(105,'Mark', 101),
	(106,'Greta', 101)

--Task 9

--USE Geography

SELECT m.MountainRange, p.PeakName ,p.Elevation FROM Peaks as p
JOIN Mountains AS m ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC