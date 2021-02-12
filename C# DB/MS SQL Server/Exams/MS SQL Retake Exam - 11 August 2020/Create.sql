CREATE DATABASE Bakery
USE Bakery

CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25) NOT NULL,
	LastName NVARCHAR(25) NOT NULL,
	Gender CHAR CHECK(Gender IN ('M', 'F')) NOT NULL,
	Age INT NOT NULL,
	PhoneNumber CHAR(10) NOT NULL,
	CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(25) UNIQUE NOT NULL,
	Description NVARCHAR(250) NOT NULL,
	Recipe NVARCHAR(MAX) NOT NULL,
	Price DECIMAL(18,4) CHECK(Price > 0)
)

CREATE TABLE Feedbacks
(
	Id INT PRIMARY KEY IDENTITY,
	Description NVARCHAR(255),
	Rate DECIMAL(18,2) CHECK(Rate BETWEEN 0 AND 10),
	ProductId INT FOREIGN KEY REFERENCES Products(Id) NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Products(Id) NOT NULL
)

CREATE TABLE Distributors
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(25) UNIQUE NOT NULL,
	AddressText NVARCHAR(30) NOT NULL,
	Summary NVARCHAR(200) NOT NULL,
	CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Ingredients
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(30) NOT NULL,
	Description NVARCHAR(200) NOT NULL,
	OriginCountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL,
	DistributorId INT FOREIGN KEY REFERENCES Distributors(Id) NOT NULL
)

CREATE TABLE ProductsIngredients
(
	ProductId INT FOREIGN KEY REFERENCES Products(Id) NOT NULL,
	IngredientId INT FOREIGN KEY REFERENCES Ingredients(Id) NOT NULL,
	PRIMARY KEY (ProductId, IngredientId)
)

--TASK 2

INSERT INTO Distributors (Name, AddressText, Summary, CountryId)
VALUES
('Deloitte & Touche', '6 Arch St #9757', 'Customizable neutral traveling', 2),
('Congress Title', '58 Hancock St', 'Customer loyalty', 13),
('Kitchen People', '3 E 31st St #77',' Triple-buffered stable delivery', 1),
('General Color Co Inc', '6185 Bohn St #72' ,'Focus group', 21),
('Beck Corporation', '21 E 64th Ave' ,'Quality-focused 4th generation hardware', 23)

INSERT INTO Customers (FirstName, LastName, Age, Gender, PhoneNumber, CountryId)
VALUES
('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
('Kendra', 'Loud', 22, 'F',	'0063631526', 11),
('Lourdes','Bauswell', 50, 'M',	'0139037043', 8),
('Hannah', 'Edmison', 18, 'F',	'0043343686', 1),
('Tom', 'Loeza', 31, 'M', '0144876096', 23),
('Queenie', 'Kramarczyk', 30,'F', '0064215793',	29),
('Hiu','Portaro', 25, 'M', '0068277755', 16),
('Josefa','Opitz', 43, 'F', '0197887645', 17)


--TASK 3
UPDATE Ingredients
SET DistributorId = 35
WHERE Name IN('Bay Leaf', 'Paprika', 'Poppy')

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8

--TASK 4
DELETE FROM Feedbacks
WHERE ProductId = 5 OR CustomerId = 14