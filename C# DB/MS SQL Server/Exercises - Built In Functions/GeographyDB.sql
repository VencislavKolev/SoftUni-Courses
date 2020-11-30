--USE Geography

--TASK 12
SELECT CountryName AS [Country Name], IsoCode AS [ISO COde]
	FROM Countries
	WHERE CountryName LIKE '%a%a%a%'
	ORDER BY IsoCode

--TASK 13
SELECT PeakName, RiverName,
	LOWER(PeakName + SUBSTRING(RiverName, 2, LEN(RiverName))) as Mix
	FROM Peaks, Rivers
	WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
	ORDER BY Mix