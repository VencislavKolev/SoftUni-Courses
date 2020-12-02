--TASK 1
SELECT TOP(50)
	e.FirstName, e.LastName, t.[Name] AS [Town], a.AddressText
	FROM Employees AS e
	LEFT JOIN Addresses AS a ON e.AddressID = a.AddressID
	LEFT JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

--TASK 2
SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name AS DepartmentName
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

--TASK 3
SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS DeptName
	FROM Employees AS e
	JOIN Departments AS d 
	ON (e.DepartmentID = d.DepartmentID
	AND HireDate > '1999-01-01'
	AND d.Name IN ('Sales', 'Finance'))
ORDER BY e.HireDate

--TASK 4
SELECT TOP(50)
	e.EmployeeID,
	e.FirstName + ' ' + e.LastName AS EmployeeName,
	m.FirstName + ' ' + m.LastName AS ManagerName,
	d.Name AS DepartmentName
	FROM Employees AS e
	LEFT JOIN Employees AS m ON e.ManagerID = m.EmployeeID
	LEFT JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

select * from Employees