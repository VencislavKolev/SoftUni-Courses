--TASK 5
SELECT 
	j.Id,
	FORMAT (j.JourneyStart, 'dd/MM/yyyy') AS JourneyStart,
	FORMAT (j.JourneyEnd, 'dd/MM/yyyy') AS JourneyEnd
	FROM Journeys AS j
WHERE j.Purpose = 'Military'
ORDER BY j.JourneyStart ASC

--TASK 6
SELECT 
	c.Id AS id,
	c.FirstName + ' ' + c.LastName AS full_name
	FROM Colonists AS c
	JOIN TravelCards AS tc ON c.Id = tc.ColonistId
	WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY c.Id ASC

--TASK 7
SELECT COUNT(*) AS Count 
	FROM TravelCards
	WHERE JourneyId IN(SELECT Id FROM Journeys
					WHERE Purpose = 'Technical')

--TASK 8
SELECT
	s.Name,
	s.Manufacturer
FROM Colonists AS c
JOIN TravelCards AS tc ON c.Id = tc.ColonistId
JOIN Journeys AS j ON tc.JourneyId = j.Id
JOIN Spaceships AS s ON j.SpaceshipId = s.Id
WHERE DATEDIFF(YEAR, BirthDate, '01/01/2019') < 30 
		AND tc.JobDuringJourney = 'Pilot'
ORDER BY s.Name ASC

--TASK 9
SELECT 
	p.Name AS PlanetName,
	COUNT(*) AS JourneysCount
	FROM Journeys AS j
JOIN Spaceports AS s ON j.DestinationSpaceportId = s.Id
JOIN Planets AS p ON s.PlanetId = p.Id
GROUP BY p.Name
ORDER BY JourneysCount DESC, PlanetName ASC

--TASK 10
SELECT * FROM (SELECT 
	tc.JobDuringJourney,
	c.FirstName + ' ' + c.LastName AS FullName,
	DENSE_RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate ASC) AS JobRank
	FROM Colonists AS c
	JOIN TravelCards AS tc ON c.Id = tc.ColonistId) AS ranked
	WHERE ranked.JobRank = 2

--TASK 11
CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN
	DECLARE @ColonistsCount INT = 
				(SELECT COUNT(*) AS Count 
				FROM TravelCards AS tc
				JOIN Journeys AS j ON tc.JourneyId = j.Id
				JOIN Spaceports AS s ON j.DestinationSpaceportId = s.Id
				JOIN Planets AS p ON s.PlanetId = p.Id
				WHERE p.Name = @PlanetName)

	RETURN @ColonistsCount
END

SELECT dbo.udf_GetColonistsCount('Otroyphus')

--TASK 12
CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(20))
AS
	DECLARE @JourneyIdExists INT = ISNULL((SELECT Id FROM Journeys WHERE Id = @JourneyId),0)

	IF(@JourneyIdExists = 0)
		THROW 50001, 'The journey does not exist!', 1;

	DECLARE @CurrentPurpose VARCHAR(20) = (SELECT Purpose FROM Journeys WHERE Id = @JourneyId)

	IF(@NewPurpose = @CurrentPurpose)
		THROW 50001, 'You cannot change the purpose!', 1;

	ELSE
		UPDATE Journeys
		SET Purpose = @NewPurpose

EXEC usp_ChangeJourneyPurpose 4, 'Technical'
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'
