--Task 9
CREATE PROCEDURE usp_GetHoldersFullName
AS
	SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM AccountHolders

GO

--Task 10
