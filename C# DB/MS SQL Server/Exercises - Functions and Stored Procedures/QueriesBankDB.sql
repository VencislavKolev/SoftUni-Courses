--Task 9
CREATE PROCEDURE usp_GetHoldersFullName
AS
	SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM AccountHolders

GO

--Task 10
CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan(@Value DECIMAL(18,4))
AS
	SELECT FirstName, LastName
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON ah.Id = a.AccountHolderId
	GROUP BY FirstName, LastName
		HAVING SUM(Balance) > @Value
	ORDER BY FirstName ASC, LastName ASC
GO

EXEC usp_GetHoldersWithBalanceHigherThan 2