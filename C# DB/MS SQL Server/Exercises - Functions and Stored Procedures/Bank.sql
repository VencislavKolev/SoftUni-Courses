----Task 9
--CREATE PROCEDURE usp_GetHoldersFullName
--AS
--	SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
--	FROM AccountHolders

--GO

----Task 10
--CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan(@Value DECIMAL(18,4))
--AS
--	SELECT FirstName, LastName
--	FROM AccountHolders AS ah
--	JOIN Accounts AS a ON ah.Id = a.AccountHolderId
--	GROUP BY FirstName, LastName
--		HAVING SUM(Balance) > @Value
--	ORDER BY FirstName ASC, LastName ASC
--GO

--EXEC usp_GetHoldersWithBalanceHigherThan 5050

--Task 11
--CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL,@rate FLOAT, @years INT)
--RETURNS DECIMAL(18,4)
--AS
--BEGIN
--	RETURN @sum * (SELECT POWER(1 + @rate, @years))
--END

--SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

--Task 12
CREATE OR ALTER PROCEDURE usp_CalculateFutureValueForAccount(@accountId INT, @rate FLOAT)
AS
	SELECT 
	tmp.[Account Id],
	tmp.[First Name],
	tmp.[Last Name],
	tmp.[Current Balance],
	dbo.ufn_CalculateFutureValue(tmp.[Current Balance],@rate,5) AS [Balance in 5 years]
	FROM
	(SELECT
		ah.Id AS [Account Id],
		ah.FirstName AS [First Name],
		ah.LastName AS [Last Name],
		SUM(Balance) as [Current Balance]
		FROM Accounts AS a
		JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
		GROUP BY FirstName, LastName, ah.Id
	) AS tmp

GO

--2
CREATE OR ALTER PROCEDURE usp_CalculateFutureValueForAccount(@accountId INT, @rate FLOAT)
AS
	SELECT TOP(1)
	tmp.Id			AS [Account Id],	
	tmp.FirstName	AS [First Name],
	tmp.LastName	AS [Last Name],
	tmp.Balance		AS [Current Balance],
	dbo.ufn_CalculateFutureValue(tmp.Balance, @rate, 5)
					AS [Balance in 5 years]
	FROM
	(SELECT
		a.Id,			
		ah.FirstName,	
		ah.LastName,		
		a.Balance		
		FROM Accounts AS a
		JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
	) AS tmp

GO

exec usp_CalculateFutureValueForAccount 1,0.1

SELECT * FROM
Accounts AS a
JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id