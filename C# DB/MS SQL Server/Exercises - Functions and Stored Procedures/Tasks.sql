--SoftUni DB
--Task 1
--CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
--AS
--	SELECT FirstName, LastName
--	FROM Employees
--	WHERE Salary > 35000
--GO

--EXEC usp_GetEmployeesSalaryAbove35000

--Task 2
--CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@Number DECIMAL(18,4))
--AS
--	SELECT FirstName, LastName
--	FROM Employees
--	WHERE Salary >= @Number
--GO

--EXEC usp_GetEmployeesSalaryAboveNumber 48100

--Task 3
--CREATE OR ALTER PROCEDURE usp_GetTownsStartingWith (@Value NVARCHAR(50))
--AS
--	SELECT [Name]
--	FROM Towns
--	WHERE [Name] LIKE @Value + '%'
--GO

--EXEC usp_GetTownsStartingWith 'b'

--Task 4
--CREATE PROCEDURE usp_GetEmployeesFromTown(@Town NVARCHAR(50))
--AS
--	SELECT FirstName, LastName
--	FROM Employees AS e
--	JOIN Addresses AS a ON e.AddressID = a.AddressID
--	JOIN Towns AS t ON a.TownID = t.TownID
--	WHERE t.Name = @Town
--GO

--EXEC usp_GetEmployeesFromTown 'Sofia'

--Task 5
--CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
--RETURNS VARCHAR(10)
--AS
--BEGIN
--	DECLARE @salaryLevel VARCHAR(10)
--	IF(@salary < 30000)
--	SET @salaryLevel = 'Low'
--	ELSE IF(@salary <= 50000)
--	SET @salaryLevel = 'Average'
--	ELSE
--	SET @salaryLevel = 'High'

--	RETURN @salaryLevel
--END

--SELECT dbo.ufn_GetSalaryLevel(50001)

--Task 6
--CREATE PROCEDURE usp_EmployeesBySalaryLevel (@salaryLevel NVARCHAR(10))
--AS
--	SELECT FirstName, LastName
--	FROM Employees
--	WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
--GO

--EXEC usp_EmployeesBySalaryLevel 'High'

--Task 7

CREATE OR ALTER FUNCTION ufn_IsWordComprisedHARD(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @i INT = 1;
	WHILE(@i <= LEN(@word))
	BEGIN

		DECLARE @result BIT = 0;
		DECLARE @currWordChar NCHAR(1) = SUBSTRING(@word,@i,1);
		DECLARE @j INT = 1;

			WHILE(@j <= LEN(@setOfLetters))
			BEGIN
				DECLARE @currLettersChar NCHAR(1) = SUBSTRING(@setOfLetters,@j,1);
				IF(@currWordChar = @currLettersChar)
					SET @result = 1;
					SET @j = @j + 1;
			END
		IF(@result = 0)
		BREAK;
		SET @i = @i + 1;
	END
	RETURN @result;
END

CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @counter INT = 1;
	DECLARE @currWordChar CHAR;

	WHILE(@counter <= LEN(@word))
	BEGIN
		SET @currWordChar = SUBSTRING(@word,@counter,1);
		DECLARE @indexOfMatchedChar INT = CHARINDEX(@currWordChar,@setOfLetters,1);
		IF(@indexOfMatchedChar <= 0)
		RETURN 0
		SET @counter = @counter + 1;
	END
	RETURN 1
END

SELECT dbo.ufn_IsWordComprised('bobr','Rob')
SELECT dbo.ufn_IsWordComprised('oistmiahf','halves')
SELECT dbo.ufn_IsWordComprised('oistmiahf','Sofia')