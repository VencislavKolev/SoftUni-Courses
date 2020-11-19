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