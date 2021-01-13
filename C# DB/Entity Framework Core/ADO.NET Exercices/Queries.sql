--Task 2
SELECT v.Name AS VillainName,
		COUNT(mv.VillainId) AS MinionsCount
FROM Villains AS v
	LEFT JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
	GROUP BY v.Name, mv.VillainId
	HAVING COUNT(mv.VillainId) > 3
ORDER BY mv.VillainId DESC

--Task 3
SELECT [Name] 
	FROM Villains
WHERE Villains.Id = 1

SELECT m.[Name], m.Age
FROM MinionsVillains AS mv
	JOIN Minions AS m ON mv.MinionId = m.Id
WHERE mv.VillainId = 2
ORDER BY m.Name ASC

--Task 4
SELECT [Id] FROM Towns
WHERE [Name] = 'Sofia'

INSERT INTO Towns
VALUES (@townName, 1)

SELECT * FROM Villains

SELECT [Id] FROM Villains
WHERE [Name] = 'Gru'

SELECT [Id] FROM EvilnessFactors
WHERE [Name] = 'Evil'

INSERT INTO Villains
VALUES (@villainName,@evilFactorId)

SELECT * FROM MinionsVillains

INSERT INTO MinionsVillains
VALUES (@minionId,@villianId)

SELECT * FROM Minions

INSERT INTO Minions(Name,Age,TownId)
VALUES(@name, @age, @townId)

--Task 5
SELECT c.Name, t.Name
FROM Towns AS t
JOIN Countries AS c ON t.CountryCode = c.Id
WHERE c.Name = 'bulgaria'

SELECT Id FROM Countries
WHERE Name = 'Bulgaria'

SELECT [Name] FROM Towns AS t
WHERE t.CountryCode = 1

UPDATE Towns
SET Name = UPPER(Name)
WHERE CountryCode = 1

--Task 6
SELECT Name 
FROM Villains
WHERE Id = 1

DELETE FROM MinionsVillains
WHERE VillainId=1

DELETE FROM Villains
WHERE Id=1
--Task 7
SELECT Name FROM Minions

INSERT INTO Minions(Name,Age,TownId)
VALUES('Test2',10,2)

--Task 8
UPDATE Minions
SET Name = UPPER(LEFT(Name,1)) + LOWER(SUBSTRING(Name,2,LEN(Name)))
WHERE Id = 13

UPDATE Minions
SET Name=UPPER(LEFT(Name,1))+LOWER(SUBSTRING(Name,2,LEN(Name)))

CREATE TABLE MinionsNA(
Id INT,
[Name] VARCHAR(50),
Age INT
)

INSERT INTO MinionsNA
VALUES
(1,'bob',14),
(2,'stuart',22),
(3,'kevin',13),
(4,'jimmy',49),
(5,'vicky jackson',26)

Drop table MinionsNA

SELECT * FROM MinionsNA

UPDATE MinionsNA
SET Age = Age + 1
WHERE Id = @Id

UPDATE MinionsNA
SET Name=UPPER(LEFT(Name,1))+LOWER(SUBSTRING(Name,2,LEN(Name)))
WHERE Id = @Id

select * from MinionsNA where rtrim(Name) like '% %'

DECLARE @MyName VARCHAR(30) = 'vicky jackson'
SELECT 
SUBSTRING(@MyName , 1, CHARINDEX(' ', @MyName ) - 1) AS [First],
SUBSTRING(@MyName , CHARINDEX(' ', @MyName ) + 1, LEN(@MyName)) AS [Last]

where rtrim(Name) like '% %'

SELECT Name FROM MinionsNA
WHERE Id = 5

DECLARE @MyName VARCHAR(30) = 'vicky jackson'
SELECT 
SUBSTRING(@MyName , 1, CHARINDEX(' ', @MyName ) - 1) AS [First],
SUBSTRING(@MyName , CHARINDEX(' ', @MyName ) + 1, LEN(@MyName)) AS [Last]

DECLARE @MyName VARCHAR(30) = 'vicky jackson'

UPDATE MinionsNA
SET [Name] =  SUBSTRING([Name] , 1, CHARINDEX(' ', [Name] ) - 1) 

+ SUBSTRING([Name] , CHARINDEX(' ', [Name] ) + 1, LEN([Name]))
WHERE Id=5;

UPDATE MinionsNA
SET Name = 
UPPER(LEFT(Name,1)) + LOWER(SUBSTRING(Name,2,CHARINDEX(' ',[Name]) -1)) +
UPPER(LEFT(SUBSTRING(Name,CHARINDEX(' ', [Name])+1,LEN(Name)),1)) + LOWER(SUBSTRING(Name,CHARINDEX(' ', [Name])+2,LEN(Name)))
WHERE Id=5

UPDATE MinionsNA
SET Name = 'vicky jackson'
WHERE Id=5

SELECT SUBSTRING(Name,CHARINDEX(' ', [Name])+1,LEN(Name))
FROM MinionsNA
WHERE Id=5

SELECT Name,Age
FROM MinionsNA

SELECT * FROM MinionsNA

--Task 9
CREATE PROCEDURE usp_GetOlder(@minionId INT)
AS
	UPDATE MinionsNA
	SET Age = Age + 1
	WHERE Id = @minionId
GO

EXEC usp_GetOlder 5

SELECT Name,Age
FROM MinionsNA
WHERE Id=@minionId