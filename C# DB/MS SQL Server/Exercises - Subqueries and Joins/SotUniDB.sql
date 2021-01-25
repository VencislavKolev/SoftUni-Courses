--USE SoftUni

--TASK 1
SELECT TOP(5)
	e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	ORDER BY e.AddressID ASC

--TASK 2
SELECT TOP(50)
	e.FirstName, e.LastName, t.Name, a.AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName ASC, e.LastName ASC

--TASK 3
SELECT e.EmployeeID, e.FirstName, e.LastName,d.Name
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID ASC

--TASK 4
SELECT TOP(5)
  e.EmployeeID, e.FirstName, e.Salary, d.Name 
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE e.Salary > 15000
ORDER BY e.DepartmentID ASC

--TASK 5
SELECT TOP(3)
	e.EmployeeID, e.FirstName 
	FROM EmployeesProjects AS ep
	right JOIN Employees AS e ON ep.EmployeeID = e.EmployeeID
	WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID ASC

--TASK 6
SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS DeptName
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE e.HireDate > '1999-01-01' AND d.Name IN ('Sales', 'Finance')
ORDER BY e.HireDate ASC

--TASK 7
SELECT TOP(5)
	e.EmployeeID, e.FirstName, p.Name
	FROM EmployeesProjects AS ep
	JOIN Employees AS e ON ep.EmployeeID = e.EmployeeID
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID
	WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID ASC

--TASK 8
SELECT e.EmployeeID, e.FirstName ,
	CASE
		WHEN YEAR(p.StartDate) >= 2005 THEN NULL
		ELSE p.[Name]
	END AS ProjectName
	FROM EmployeesProjects AS ep
	JOIN Employees AS e ON ep.EmployeeID = e.EmployeeID AND e.EmployeeID = 24
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID 

--TASK 9
SELECT e.EmployeeID, e.FirstName, m.EmployeeID, m.FirstName AS ManagerName
	FROM Employees AS e
	JOIN Employees AS m ON e.ManagerID = m.EmployeeID
	WHERE m.EmployeeID IN (3,7)
ORDER BY e.EmployeeID ASC

--TASK 10
SELECT TOP(50)
	e.EmployeeID,
	e.FirstName + ' ' + e.LastName AS EmployeeName,
	m.FirstName + ' ' + m.LastName AS ManagerName,
	d.Name
	FROM Employees AS e
	JOIN Employees AS m ON e.ManagerID = m.EmployeeID
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

--TASK 11
--SELECT TOP(1)
--	(SELECT AVG(Salary) FROM Employees AS e 
--		WHERE e.DepartmentID = d.DepartmentID) 
--			AS AverageSalary
--	FROM Departments AS d
--ORDER BY AverageSalary ASC

SELECT TOP (1) tmp.AverageSalary AS MinAverageSalary
FROM
(
	SELECT AVG(Salary) AS AverageSalary
	FROM Employees
	GROUP BY DepartmentID
) AS tmp
ORDER BY tmp.AverageSalary ASC