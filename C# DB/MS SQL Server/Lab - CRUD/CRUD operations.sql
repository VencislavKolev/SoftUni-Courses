USE SoftUni

--Task 1
SELECT FirstName + ' ' + LastName AS [FullName],
	JobTitle,
	Salary
	FROM Employees 

--Task 2
SELECT LastName, HireDate
	FROM Employees
	ORDER BY HireDate

--Task 3
CREATE VIEW v_EmployeesByDepartment AS
	SELECT FirstName + ' ' + LastName AS [FullName],
	Salary
	FROM Employees 

SELECT * FROM v_EmployeesByDepartment

--Task 4
USE Geography

CREATE VIEW v_HighestPeak AS
	SELECT TOP(1) 
	--Id,
	--PeakName,
	--Elevation,
	--MountainId
	*
	FROM Peaks
	ORDER BY Elevation DESC

SELECT * FROM v_HighestPeak

--Task 5
USE SoftUni

SELECT * FROM [Projects]
WHERE EndDate IS NULL

UPDATE Projects
	SET EndDate = GETDATE()
	WHERE EndDate IS NULL

-Task 6
SELECT * FROM Employees
	WHERE Salary <= 10000

UPDATE Employees
	SET Salary*=1.1
	WHERE Salary <= 10000

SELECT * FROM Employees
	WHERE DepartmentID = 3

UPDATE Employees
	SET JobTitle = 'Senior'+JobTitle
	WHERE DepartmentID = 3

