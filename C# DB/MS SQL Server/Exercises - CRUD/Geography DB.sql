--USE Geography

--Task 22
SELECT PeakName 
	FROM Peaks
	ORDER BY PeakName

--Task 23
SELECT TOP(30) CountryName, Population
	FROM Countries
	WHERE ContinentCode = 
	(SELECT ContinentCode FROM Continents
		WHERE ContinentName = 'Europe')
	ORDER BY Population DESC,
			CountryName ASC

--Task 24
SELECT CountryName, CountryCode,
	CASE
		WHEN CurrencyCode = 'EUR' THEN 'Euro'
		ELSE 'Not Euro'
	END AS [Currency]
FROM Countries
ORDER BY CountryName
