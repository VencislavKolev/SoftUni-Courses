CREATE DATABASE School
USE School

CREATE TABLE Students
(
	Id int PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age int NOT NULL CHECK (Age >= 5 AND Age <= 100),
	Address NVARCHAR(50),
	Phone NCHAR(10)
)

CREATE TABLE Subjects
(
	Id int PRIMARY KEY IDENTITY,
	Name NVARCHAR(20) NOT NULL,
	Lessons int NOT NULL CHECK(Lessons > 0)
)

CREATE TABLE StudentsSubjects
(
	Id int PRIMARY KEY IDENTITY,
	StudentId int NOT NULL FOREIGN KEY REFERENCES Students(Id),
	SubjectId int NOT NULL FOREIGN KEY REFERENCES Subjects(Id),
	Grade DECIMAL(3,2) NOT NULL CHECK (Grade >= 2 AND Grade <= 6) 
)

CREATE TABLE Exams
(
	Id int PRIMARY KEY IDENTITY,
	Date datetime2,
	SubjectId int NOT NULL FOREIGN KEY REFERENCES Subjects(Id)
)

CREATE TABLE StudentsExams
(
	StudentId int NOT NULL FOREIGN KEY REFERENCES Students(Id),
	ExamId int NOT NULL FOREIGN KEY REFERENCES Exams(Id),
	Grade DECIMAL(3,2) NOT NULL CHECK (Grade >= 2 AND Grade <= 6)
	PRIMARY KEY(StudentId, ExamId)
)

CREATE TABLE Teachers
(
	Id int PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Address NVARCHAR(20) NOT NULL,
	Phone CHAR(10),
	SubjectId int NOT NULL FOREIGN KEY REFERENCES Subjects(Id)
)

CREATE TABLE StudentsTeachers
(
	StudentId int NOT NULL FOREIGN KEY REFERENCES Students(Id),
	TeacherId int NOT NULL FOREIGN KEY REFERENCES Teachers(Id),
	PRIMARY KEY(StudentId, TeacherId)
)

--TASK 2
INSERT INTO Teachers
VALUES
	('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
	('Gerrard', 'Lowin', '370 Talisman Plaza', '3324874824', 2),
	('Merrile', 'Lambdin', '81 Dahle Plaza', '4373065154', 5),
	('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)

INSERT INTO Subjects
VALUES
	('Geometry', 12),
	('Health', 10),
	('Drama', 7),
	('Sports', 9)

--TASK 3
--SELECT * FROM StudentsSubjects
--WHERE SubjectId IN (1,2) AND Grade >= 5.50

UPDATE StudentsSubjects
	SET Grade = 6.00
	WHERE SubjectId IN (1, 2) AND Grade >= 5.50

--TASK 4
--SELECT Id FROM Teachers
--WHERE Phone LIKE ('%72%')

DELETE FROM StudentsTeachers
	WHERE TeacherId IN (SELECT Id FROM Teachers
					WHERE Phone LIKE ('%72%')
					)
DELETE FROM Teachers
	WHERE Phone LIKE ('%72%')