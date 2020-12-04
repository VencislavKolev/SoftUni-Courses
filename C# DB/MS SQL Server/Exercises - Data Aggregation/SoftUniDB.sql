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


--TASK 16
SELECT 
	DepartmentID,
	MAX(Salary) AS MaxSalary
	FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--TASK 17
