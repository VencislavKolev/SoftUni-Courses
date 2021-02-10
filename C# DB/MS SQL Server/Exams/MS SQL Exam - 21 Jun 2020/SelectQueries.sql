--TASK 5
SELECT	a.FirstName,
		a.LastName,
		FORMAT(a.BirthDate,'MM-dd-yyyy') AS BirthDate,
		c.Name AS Hometown,
		a.Email
	FROM Accounts AS a
	JOIN Cities AS c ON a.CityId = c.Id
	WHERE Email LIKE 'e%'
ORDER BY Hometown ASC

--TASK 6
SELECT	
		c.Name AS City,
		COUNT(*) AS Hotels
	FROM Cities AS c
		JOIN Hotels AS h ON c.Id = h.CityId
	GROUP BY c.Name
ORDER BY Hotels DESC, c.Name ASC

--TASK 7
SELECT 
		a.Id AS AccountId,
		a.FirstName + ' ' + a.LastName AS FullName,
		MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongestTrip,
		MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS ShortestTrip
	FROM Accounts AS a
		JOIN AccountsTrips AS at ON a.Id = at.AccountId
		JOIN Trips AS t ON at.TripId = t.Id
	WHERE MiddleName IS NULL AND CancelDate IS NULL
	GROUP BY a.Id, a.FirstName, a.LastName
ORDER BY LongestTrip DESC, ShortestTrip ASC

--TASK 8
SELECT TOP(10)
		c.Id,
		c.Name AS City,
		c.CountryCode AS Country,
		COUNT(*) AS Accounts
	FROM Cities AS c
		JOIN Accounts AS a ON c.Id = a.CityId
	GROUP BY c.Id, c.Name, c.CountryCode
ORDER BY Accounts DESC

--TASK 9
SELECT 
		a.Id,
		a.Email,
		c.Name,
		COUNT(*) AS Trips
	FROM Accounts AS a
		JOIN AccountsTrips AS at ON a.Id = at.AccountId
		JOIN Trips AS t ON at.TripId = t.Id
		JOIN Rooms AS r ON t.RoomId = r.Id
		JOIN Hotels AS h ON r.HotelId = h.Id
		JOIN Cities AS c ON a.CityId = c.Id
	WHERE a.CityId = h.CityId
	GROUP BY a.Id, a.Email, c.Name
ORDER BY Trips DESC, a.Id ASC

--TASK 10
SELECT 
		at.TripId AS Id,
		a.FirstName + ' ' + ISNULL(a.MiddleName + ' ','') + a.LastName AS [Full Name],
		c.Name AS [From],
		hc.Name AS [To],
		CASE
			WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
			ELSE CONCAT(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate), ' days')
		END AS Duration
	FROM AccountsTrips AS at
		JOIN Accounts AS a ON at.AccountId = a.Id
		JOIN Cities AS c ON a.CityId = c.Id
		JOIN Trips AS t ON at.TripId = t.Id
		JOIN Rooms AS r ON t.RoomId = r.Id
		JOIN Hotels AS h ON r.HotelId = h.Id
		JOIN Cities AS hc ON h.CityId = hc.Id --joining cities 2 times but for different needs!
ORDER BY [Full Name] ASC, at.TripId ASC

--IIF operator
--TASK 11
CREATE OR ALTER FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @outputMessage NVARCHAR(MAX) = (SELECT TOP(1) CONCAT('Room ', r.Id, ': ', r.Type, ' (', r.Beds, ' beds) ', '- $', (h.BaseRate + r.Price) * @People)
								FROM Rooms AS r
								JOIN Hotels AS h ON r.HotelId = h.Id
							WHERE Beds >= @People AND HotelId = @HotelId AND 
										NOT EXISTS (SELECT * FROM Trips AS t
													WHERE t.RoomId = r.Id 
													AND @Date BETWEEN t.ArrivalDate AND t.ReturnDate 
													AND t.CancelDate IS NULL)
							ORDER BY (h.BaseRate + r.Price) * @People DESC)
		IF(@outputMessage IS NULL)
		SET @outputMessage = 'No rooms available'

	RETURN @outputMessage
END
SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)

--TEST
DECLARE @HotelId INT = 112
DECLARE @Date DATE = '2011-12-17'
DECLARE @People INT = 2
SELECT CONCAT('Room ', r.Id, ': ', r.Type, ' (', r.Beds, ' beds) ', '- $', (h.BaseRate + r.Price) * @People) AS Res,
	(h.BaseRate + r.Price) * @People AS TotalPrice
	FROM Rooms AS r
	JOIN Hotels AS h ON r.HotelId = h.Id
WHERE Beds >= @People AND HotelId = @HotelId AND 
			NOT EXISTS (SELECT * FROM Trips AS t
						WHERE t.RoomId = r.Id 
						AND @Date BETWEEN t.ArrivalDate AND t.ReturnDate 
						AND t.CancelDate IS NULL)
ORDER BY TotalPrice DESC
--•	(HotelBaseRate + RoomPrice) * PeopleCount

--TASK 12
CREATE OR ALTER PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	DECLARE @currentHotelId INT =  (SELECT r.HotelId
									FROM Trips AS t
									JOIN Rooms AS r ON t.RoomId = r.Id
									WHERE t.Id = @TripId)

	DECLARE @targetRoomHotelId INT = (SELECT HotelId FROM Rooms
									WHERE Id = @TargetRoomId)

	DECLARE @peopleInTrip INT = (SELECT COUNT(*) FROM AccountsTrips AS at
								WHERE at.TripId = @TripId)

	DECLARE @targetRoomBeds INT = (SELECT Beds FROM Rooms
									WHERE Id = @TargetRoomId)

	IF(@currentHotelId != @targetRoomHotelId)
		THROW 50001, 'Target room is in another hotel!', 1;

	ELSE IF (@peopleInTrip > @targetRoomBeds)
		THROW 50001, 'Not enough beds in target room!', 1;

	ELSE
		BEGIN
			UPDATE Trips
			SET RoomId = @TargetRoomId
		END 
		
EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10
EXEC usp_SwitchRoom 10, 7
EXEC usp_SwitchRoom 10, 8
