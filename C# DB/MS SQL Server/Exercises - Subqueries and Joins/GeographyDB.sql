--TASK 12
-- OPTION 1
SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation 
	FROM Countries AS c
	JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	JOIN Mountains AS m ON mc.MountainId = m.Id
	JOIN Peaks AS p ON m.Id = p.MountainId
	WHERE c.CountryName = 'Bulgaria' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--OPTION 2
SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation 
	FROM MountainsCountries AS mc
	JOIN Mountains AS m ON mc.MountainId = m.Id
	JOIN Peaks AS p ON m.Id = p.MountainId
	WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--TASK 13
SELECT CountryCode, COUNT(MountainId) AS MountainRange
	FROM MountainsCountries
	WHERE CountryCode IN ('BG','RU','US')
GROUP BY CountryCode

--SELECT 
--	mc.CountryCode,
--	COUNT(m.MountainRange) AS MountainRange
--		FROM MountainsCountries AS mc
--		JOIN Mountains AS m ON mc.MountainId = m.Id
--		WHERE mc.CountryCode IN ('BG','RU','US')
--	GROUP BY mc.CountryCode

--TASK 14
SELECT TOP(5)
	c.CountryName, r.RiverName
	FROM Countries AS c
	LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
	WHERE c.ContinentCode = 'AF'
	--JOIN Continents AS ct ON c.ContinentCode = ct.ContinentCode
	--WHERE ct.ContinentName = 'Africa'
ORDER BY c.CountryName ASC

--TASK 15
SELECT MostUsedCurrency.ContinentCode
      ,MostUsedCurrency.CurrencyCode
      ,MostUsedCurrency.CurrencyUsage
FROM
    (
        SELECT c.ContinentCode
              ,c.CurrencyCode
              ,COUNT(c.CurrencyCode) AS CurrencyUsage
              ,DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS CurrencyRank
        FROM Countries AS c
        GROUP BY c.ContinentCode, c.CurrencyCode
        HAVING COUNT(c.CurrencyCode) > 1

    ) AS MostUsedCurrency
WHERE MostUsedCurrency.CurrencyRank = 1
ORDER BY MostUsedCurrency.ContinentCode, MostUsedCurrency.CurrencyUsage

--TASK 16
SELECT COUNT(*) AS Count
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	WHERE mc.CountryCode IS NULL

--TASK 17
SELECT TOP(5) CountryName,
	MAX(p.Elevation) AS HighestPeakElevation,
	MAX(r.[Length]) AS LongestRiverLength
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON m.Id = p.MountainId
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC,
		 LongestRiverLength DESC,
		 c.CountryName ASC

--TASK 18
SELECT TOP(5)
	Country,
	CASE 
		WHEN PeakName IS NULL THEN '(no highest peak)'
		ELSE PeakName
	 END AS [Highest Peak Name],
	CASE
		WHEN Elevation IS NULL THEN 0
		ELSE Elevation
	 END AS [Highest Peak Elevation],

	CASE
		WHEN MountainRange IS NULL THEN '(no mountain)'
		ELSE MountainRange
	END AS Mountain
FROM (SELECT *,
	DENSE_RANK() OVER (PARTITION BY Country ORDER BY Elevation DESC) AS [PeakRank]
	FROM	
	(SELECT c.CountryName AS Country,
			p.PeakName,
			p.Elevation,
			m.MountainRange
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p ON mc.MountainId = p.MountainId
	) AS [FullInfoQuery]
) AS [RankingQuery]
WHERE PeakRank = 1
ORDER BY Country ASC, [Highest Peak Name] ASC