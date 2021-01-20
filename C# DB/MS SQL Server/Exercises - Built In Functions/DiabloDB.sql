--TASK 14
SELECT TOP (50)
      [Name]
      ,FORMAT([Start], 'yyyy-MM-dd') AS [Start]
  FROM [Games]
  WHERE DATEPART(YEAR,[Start]) IN (2011, 2012)
  ORDER BY [Start], [Name]

--TASK 15
SELECT [Username]
	,RIGHT(Email, LEN([Email]) - CHARINDEX('@',Email)) AS [Email Provider]
	  --,SUBSTRING(Email,CHARINDEX('@',Email) + 1, LEN([Email])) AS [Provider]
  FROM [Users]
  ORDER BY [Email Provider], [Username]

--TASK 16
SELECT [Username],[IpAddress] AS [IP Address] 
	FROM Users
	WHERE [IpAddress] LIKE '___.1_%._%.___'
	ORDER BY [Username]

--TASK 17
SELECT [Name] AS Game,
	CASE
    WHEN DATEPART(HOUR,[Start]) >= 0 and DATEPART(HOUR,[Start]) < 12 THEN 'Morning' 
	WHEN DATEPART(HOUR,[Start]) >= 12 and DATEPART(HOUR,[Start]) < 18 THEN 'Afternoon' 
	WHEN DATEPART(HOUR,[Start]) >= 18 and DATEPART(HOUR,[Start]) < 24 THEN 'Evening'
END AS [Part of the Day],
	CASE
    WHEN Duration <= 3 THEN 'Extra Short'
    WHEN Duration >= 4 AND Duration <= 6 THEN 'Short'
	WHEN Duration > 6 THEN 'Long'
    ELSE 'Extra Long'
END AS [Duration]
FROM Games
ORDER BY Game, Duration

--TASK 18 ORDERS DB
SELECT [ProductName]
      ,[OrderDate]
	  ,DATEADD(DAY,3,OrderDate) AS [Pay Due]
	  ,DATEADD(MONTH,1,OrderDate) AS [Deliver Due]
  FROM [Orders]

--TASK 19
--USE Orders
CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	[Birthdate] DATETIME2 NOT NULL
)
INSERT INTO People
VALUES
	('Victor','2000-12-07 00:00:00.000'),
	('Steven','1992-09-10 00:00:00.000'),
	('Stephen','1910-09-19 00:00:00.000'),
	('John','2010-01-06 00:00:00.000')

SELECT [Name],
	DATEDIFF(YEAR,Birthdate,GETDATE()) AS [Age in Years],
	DATEDIFF(MONTH,Birthdate,GETDATE()) AS [Age in Months], 
	DATEDIFF(DAY,Birthdate,GETDATE()) AS [Age in Days],
	DATEDIFF(MINUTE,Birthdate,GETDATE()) AS [Age in Minutes]
FROM People
