USE SoftUni
--Task 2
SELECT * FROM Departments

--Task 3
SELECT [Name] FROM Departments

--Task 4
SELECT FirstName,LastName,Salary 
	FROM Employees

--Task 5
SELECT FirstName,MiddleName,LastName
	FROM Employees

--Task 6
--SELECT FirstName + '.' + LastName + '@softuni.bg' 
SELECT CONCAT(FirstName, '.', LastName, '@', 'softuni.bg')
	AS [Full Email Address] -- 'Full Email Address'
	FROM Employees

--Task 7
SELECT DISTINCT Salary
	FROM Employees

--Task 8
SELECT * FROM Employees
	WHERE JobTitle = 'SALES REPRESENTATIVE'

--Task 9
SELECT FirstName,LastName,JobTitle
	FROM Employees
	WHERE Salary >= 20000 AND
			Salary <= 30000

--Task 10
--NULL + ' ' = '' (EMPTY STRING)
--SELECT CONCAT(FirstName, ' ', (MiddleName + ' '), LastName)	
SELECT CONCAT(FirstName, ' ', MiddleName ,' ', LastName)	
	AS [FullName]
	FROM Employees
	WHERE Salary IN (25000 ,14000 ,12500 ,23600)

--Task 11
SELECT FirstName, LastName 
	FROM Employees
	WHERE ManagerID IS NULL

--Task 12
SELECT FirstName, LastName, Salary
	FROM Employees
	WHERE Salary > 50000
	ORDER BY Salary DESC

--Task 13
SELECT TOP(5) FirstName, LastName
	FROM Employees
	ORDER BY Salary DESC

--Task 14
SELECT FirstName, LastName
	FROM Employees
	WHERE DepartmentID != 4

--Task 15
SELECT * FROM Employees
	ORDER BY Salary DESC,
			FirstName,
			LastName DESC,
			MiddleName

--Task 16
CREATE VIEW V_EmployeeSalaries AS
	SELECT FirstName, LastName, Salary
	FROM Employees

--SELECT * FROM V_EmployeeSalaries

--Task 17
CREATE VIEW V_EmployeeNameJobTitle 
AS
(SELECT CONCAT (FirstName, ' ', ISNULL(MiddleName,''), ' ', LastName)
	AS [FullName], JobTitle
	FROM Employees)

--SELECT * FROM V_EmployeeNameJobTitle

--Task 18
SELECT DISTINCT JobTitle
	FROM Employees

--Task 19
SELECT TOP(10) * FROM Projects
	ORDER BY StartDate ASC, [Name] ASC

--Task 20
SELECT TOP(7) 
	FirstName,LastName,HireDate
	FROM Employees
	ORDER BY HireDate DESC

--Task 21
--SELECT * FROM Departments
--	WHERE [Name] = 'Engineering'
--	OR [Name] = 'Tool Design'
--	OR [Name] = 'Marketing'
--	OR [Name] = 'Information Services'

UPDATE Employees
	SET Salary *= 1.12
	WHERE DepartmentId IN(1, 2, 4, 11)

SELECT Salary FROM Employees