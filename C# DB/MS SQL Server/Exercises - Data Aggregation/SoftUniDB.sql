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