USE Diablo
--Task 13
CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN SELECT (SELECT tmp.Cash AS [SumCash]
		FROM (SELECT g.Name,
				ug.Cash,
				ROW_NUMBER() OVER (PARTITION BY g.Name ORDER BY ug.Cash DESC) AS [RowNum]
			FROM UsersGames AS ug
			JOIN Games AS g ON ug.GameId = g.Id
			WHERE g.Name = @gameName
			) AS [tmp]
		WHERE tmp.RowNum % 2 != 0) 
	AS [SumCash]

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')