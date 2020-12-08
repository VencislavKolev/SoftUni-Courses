--TASK 13
--USE SoftUni
SELECT 
	DepartmentID,
	SUM(Salary) AS TotalSalary
	FROM Employees
	GROUP BY DepartmentID
ORDER BY DepartmentID

--TASK 14
SELECT
	DepartmentID,
	MIN(Salary) AS MinimumSalary
	FROM Employees
		WHERE HireDate > '01/01/2000' AND DepartmentID IN (2,5,7)
	GROUP BY DepartmentID

--TASK 15
SELECT * INTO EmployeeWithHighSalaries FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeeWithHighSalaries 
WHERE ManagerID = 42

UPDATE EmployeeWithHighSalaries
SET Salary += 5000
WHERE DepartmentID = 1

SELECT 
	DepartmentID,
	AVG(Salary) AS AverageSalary
	FROM EmployeeWithHighSalaries
GROUP BY DepartmentID

--TASK 16
SELECT 
	DepartmentID,
	MAX(Salary) AS MaxSalary
	FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--TASK 17
SELECT 
	COUNT(*) AS [Count]
	FROM Employees
	WHERE ManagerID IS NULL

--TASK 18
---OPTION 1
SELECT 
	DepartmentID,
	Salary AS [ThirdHighestSalary]
FROM(
	SELECT 
		DepartmentID,
		Salary,
		DENSE_RANK() OVER(PARTITION BY DepartmentId ORDER BY Salary DESC) AS [Rank]
		FROM Employees
		GROUP BY DepartmentID, Salary) AS tmp
WHERE Rank = 3

---OPTION 2
SELECT DISTINCT
	DepartmentID,
	Salary AS [ThirdHighestSalary]
FROM(
	SELECT 
		DepartmentID,
		Salary,
		DENSE_RANK() OVER(PARTITION BY DepartmentId ORDER BY Salary DESC) AS [Rank]
		FROM Employees) AS [SalaryRank]
WHERE Rank = 3

--TASK 19
SELECT TOP(10)
	FirstName,
	LastName,
	DepartmentID
FROM Employees AS e1
WHERE e1.Salary > (SELECT 
					AVG(Salary) AS AvgSalary
					FROM Employees AS emplAvgSalary
					WHERE emplAvgSalary.DepartmentID = e1.DepartmentID
					GROUP BY DepartmentID)
ORDER BY DepartmentID ASC