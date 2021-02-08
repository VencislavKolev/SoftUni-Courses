--TASK 5
SELECT * FROM Planes
WHERE Name LIKE '%tr%'
ORDER BY Id ASC, Name ASC, Seats ASC, Range ASC

--TASK 6
SELECT FlightId, SUM(Price) AS Price
	FROM Tickets
	GROUP BY FlightId
ORDER BY Price DESC, FlightId ASC

--TASK 7
SELECT tmp.FirstName + ' ' + tmp.LastName AS [Full Name],
		tmp.Origin,
		tmp.Destination
FROM
(SELECT t.FlightId,
		t.PassengerId,
		p.FirstName,
		p.LastName,
		f.Origin,
		f.Destination 
	FROM Tickets AS t
		JOIN Passengers AS P ON t.PassengerId = p.Id
		JOIN Flights AS f ON t.FlightId = f.Id
		) AS tmp
ORDER BY [Full Name] ASC, Origin ASC, Destination ASC

--TASK 8

SELECT FirstName, LastName, Age FROM Passengers
WHERE Id NOT IN (SELECT DISTINCT PassengerId FROM Tickets)
ORDER BY Age DESC, FirstName ASC, LastName ASC

--TASK 9
SELECT 
		p.FirstName + ' ' + p.LastName AS [Full Name],
		pl.Name AS [Plane Name],
		f.Origin + ' - ' + f.Destination AS [Trip],
		lt.Type AS [Luggage Type]
	FROM Tickets AS t
		JOIN Flights AS f ON t.FlightId = f.Id
		JOIN Planes AS pl ON f.PlaneId = pl.Id
		JOIN Passengers AS p ON t.PassengerId = p.Id
		JOIN Luggages AS l ON t.LuggageId = l.Id
		JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
	ORDER BY	[Full Name] ASC,
				[Plane Name] ASC,
				f.Origin ASC,
				f.Destination ASC,
				[Luggage Type] ASC

--TASK 10
SELECT *  FROM Tickets
SELECT * FROM Flights

--Option 1
SELECT	p.Name,
		p.Seats,
		COUNT(t.Id) AS [Passengers Count]
	FROM Tickets AS t
		JOIN Flights AS f ON t.FlightId = f.Id
		RIGHT JOIN Planes AS p ON f.PlaneId = p.Id
	GROUP BY p.Name, p.Seats
ORDER BY [Passengers Count] DESC, p.Name ASC, p.Seats ASC

--Option 2
SELECT p.[Name],
       p.Seats,
	   COUNT(t.Id) AS [Passengers Count]
FROM Planes AS p
		LEFT JOIN Flights AS f ON p.Id = f.PlaneId
		LEFT JOIN Tickets AS t ON f.Id = t.FlightId
	GROUP BY p.[Name], p.Seats
ORDER BY [Passengers Count] DESC, p.[Name], p.Seats

--TASK 11
CREATE OR ALTER FUNCTION udf_CalculateTickets(@origin NVARCHAR(50) , @destination NVARCHAR(50), @peopleCount INT)
RETURNS NVARCHAR(50)
AS
BEGIN 
	DECLARE @message NVARCHAR(50)
	DECLARE @pricePerPerson DECIMAL(18,2)
	DECLARE @totalPrice DECIMAL(18,2)
	DECLARE @flightId INT = 
		ISNULL((
			SELECT Id FROM Flights
			WHERE	Origin = @origin AND
					Destination = @destination)
				,0)

	IF (@peopleCount <= 0)
		BEGIN
			SET @message = 'Invalid people count!'
		END
	ELSE IF (@flightId = 0)
		BEGIN
			SET @message = 'Invalid flight!'
		END
	ELSE
		BEGIN
			SET @pricePerPerson = (SELECT t.Price
			FROM Tickets AS t
			JOIN Flights AS f ON t.FlightId = f.Id
			WHERE f.Id = @flightId)

			SET @totalPrice = @pricePerPerson * @peopleCount
			SET @message = CONCAT('Total price ',@TotalPrice)
		END
	RETURN @message
END

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)
SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)
SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)

--TASK 12
CREATE PROCEDURE usp_CancelFlights
AS
UPDATE Flights
	SET DepartureTime = NULL,
		ArrivalTime = NULL
WHERE ArrivalTime < DepartureTime
GO

EXEC usp_CancelFlights