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
