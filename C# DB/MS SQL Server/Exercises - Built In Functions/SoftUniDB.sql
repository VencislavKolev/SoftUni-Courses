--USE SoftUni

--TASK 1
SELECT FirstName, LastName FROM Employees
	WHERE FirstName LIKE'SA%'

--TASK 2
SELECT FirstName, LastName FROM Employees
	WHERE LastName LIKE '%ei%'

--TASK 3
SELECT FirstName FROM Employees
	WHERE( DepartmentID IN(3, 10) AND
	DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005)

--TASK 4
SELECT FirstName FROM Employees
	WHERE JobTitle NOT LIKE '%engineer%'

--TASK 5
SELECT [Name] FROM Towns
	WHERE LEN([Name]) IN (5,6)
		ORDER BY [Name]

--TASK 6
SELECT TownID, [Name] FROM Towns
	WHERE [Name] LIKE '[MKBE]%'
		ORDER BY [Name]

--TASK 7
SELECT TownID, [Name] FROM Towns
	WHERE [Name]  LIKE '[^RBD]%' 
	--WHERE [Name] NOT LIKE '[RBD]%'
		ORDER BY [Name]

--TASK 8
CREATE VIEW V_EmployeesHiredAfter2000 AS
	SELECT FirstName, LastName FROM Employees
		WHERE DATEPART(YEAR,HireDate) > 2000

--SELECT * FROM V_EmployeesHiredAfter2000

--TASK 9
SELECT FirstName, LastName FROM Employees
	WHERE LEN(LastName) = 5

--TASK 10
SELECT EmployeeID, FirstName, LastName, Salary,
	DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS Rank
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000
	ORDER BY Salary DESC

--TASK 11
SELECT * FROM 
	(SELECT EmployeeID, FirstName, LastName, Salary,
		DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS Rank
		FROM Employees
		WHERE Salary BETWEEN 10000 AND 50000) AS tmp
WHERE tmp.Rank = 2
ORDER BY Salary DESC