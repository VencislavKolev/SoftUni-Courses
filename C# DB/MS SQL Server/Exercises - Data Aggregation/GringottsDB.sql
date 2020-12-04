--TASK 1
SELECT COUNT(*) FROM WizzardDeposits

--TASK 2
SELECT TOP(1)
	MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits
	GROUP BY MagicWandSize
ORDER BY LongestMagicWand DESC

--TASK 3
SELECT 
	DepositGroup,
	MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits
	GROUP BY DepositGroup

--TASK 4
SELECT TOP(2)
	DepositGroup 
		FROM(SELECT 
		DepositGroup,
		AVG(MagicWandSize) AS AverageWandSize
		FROM WizzardDeposits
		GROUP BY DepositGroup) AS AvgWandSizeQuery
ORDER BY AverageWandSize ASC

SELECT TOP(2)
	DepositGroup
	FROM WizzardDeposits
	GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize) ASC

--TASK 5
SELECT 
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
GROUP BY DepositGroup

--TASK 6
SELECT 
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--TASK7
SELECT 
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--TASK 8
SELECT
	DepositGroup,
	MagicWandCreator,
	MIN(DepositCharge) AS MinDepositCharge
	FROM WizzardDeposits
	GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator ASC, DepositGroup ASC

--TASK 9
---OPTION 1
SELECT AgeGroup,
		COUNT(*) AS WizardCount
FROM(SELECT 
		CASE
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END AS [AgeGroup]
	FROM WizzardDeposits) AS [AgeGroupQuery]
GROUP BY AgeGroup

--- OPTION 2
SELECT 
		CASE
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END AS [AgeGroup],
		COUNT(*)
	FROM WizzardDeposits
GROUP BY (CASE
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END)

--TASK 10
SELECT 
	DISTINCT LEFT(FirstName,1) AS FirstLetter
	FROM (SELECT FirstName
			FROM WizzardDeposits
			WHERE DepositGroup = 'Troll Chest'
	GROUP BY FirstName) AS UniqueNameQuery

--TASK 11
SELECT 
	DepositGroup,
	IsDepositExpired,
	AVG(DepositInterest) AS [AverageInterest]
	FROM WizzardDeposits
		WHERE DepositStartDate > '1985-01-01'
	GROUP BY DepositGroup,IsDepositExpired
ORDER BY DepositGroup DESC,IsDepositExpired ASC

--TASK 12
SELECT
	SUM([Difference]) AS SumDifference
	FROM(SELECT
			FirstName AS [Host Wizard],
			DepositAmount AS [Host Wizard Deposit],
			LEAD(FirstName) OVER(ORDER BY Id ASC) AS[Guest Wizard],
			LEAD(DepositAmount) OVER(ORDER BY Id) AS [Guest Wizard Deposit],
			DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id) AS [Difference]
			FROM WizzardDeposits
		) AS TempTable
