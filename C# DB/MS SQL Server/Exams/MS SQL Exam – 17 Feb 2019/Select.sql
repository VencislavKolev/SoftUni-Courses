--TASK 5
SELECT FirstName, LastName, Age
	FROM Students
	WHERE Age >= 12
ORDER BY FirstName ASC, LastName ASC

--TASK 6
SELECT  s.FirstName,
		s.LastName,
		COUNT(*) AS TeachersCount
	FROM Students AS s
	JOIN StudentsTeachers AS st ON s.Id = st.StudentId
GROUP BY s.FirstName, s.LastName

--TASK 7
SELECT s.FirstName + ' ' + s.LastName AS [Full Name] 
	FROM Students AS s
	LEFT JOIN StudentsExams AS se ON s.Id = se.StudentId
	WHERE se.Grade IS NULL
ORDER BY [Full Name] ASC

--TASK 8
SELECT TOP (10)
		s.FirstName,
		s.LastName,
		FORMAT(AVG(se.Grade), 'N2') AS Grade
	FROM Students AS s
		JOIN StudentsExams AS se ON s.Id = se.StudentId
	GROUP BY s.FirstName, s.LastName
ORDER BY Grade DESC, s.FirstName ASC, s.LastName ASC

--TASK 9
SELECT 
	CONCAT(s.FirstName, ' ', (s.MiddleName + ' '), s.LastName) AS [Full Name]
	FROM Students AS s
	LEFT JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId
	WHERE ss.SubjectId IS NULL
ORDER BY [Full Name] ASC

--TASK 10
SELECT 
		s.Name,
		AVG(ss.Grade) AS AverageGrade
	FROM Subjects AS s
		JOIN StudentsSubjects AS ss ON s.Id = ss.SubjectId
	GROUP BY s.Id, s.Name
ORDER BY s.Id ASC

--TASK 11
CREATE OR ALTER FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(18,4))
RETURNS NVARCHAR(100)
AS
BEGIN
	DECLARE @returnMessage NVARCHAR(100)
	DECLARE @studentIdCheck INT = ISNULL(
											(SELECT s.Id FROM Students AS s
											WHERE s.Id = @studentId)
										,0)

	IF(@studentIdCheck = 0)
		BEGIN
			SET @returnMessage = 'The student with provided id does not exist in the school!'
		END

	ELSE IF (@grade > 6.00)
		BEGIN
			SET @returnMessage = 'Grade cannot be above 6.00!'
		END

	ELSE
		BEGIN
			DECLARE @count INT = (SELECT COUNT(*)
						FROM Students AS s
						JOIN StudentsExams AS se ON s.Id = se.StudentId
						WHERE s.Id = @studentId AND (se.Grade BETWEEN @grade AND @grade + 0.5))

			DECLARE @firstName NVARCHAR(MAX) = (SELECT FirstName FROM Students
												WHERE Id = @studentId)

			SET @returnMessage = (SELECT CONCAT('You have to update ', @count , ' grades for the student ',@FirstName))
		END
	RETURN @returnMessage
END
 
SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)
SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)

--TASK 12
CREATE OR ALTER PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
	DECLARE @studentIdCheck INT = ISNULL(
											(SELECT s.Id FROM Students AS s
											WHERE s.Id = @StudentId)
										,0)
	IF(@studentIdCheck = 0)
		BEGIN
			THROW 50001, 'This school has no student with the provided id!', 1;
		END
	ELSE
		BEGIN
			DELETE FROM StudentsExams 
			WHERE StudentId = @studentIdCheck

			DELETE FROM StudentsSubjects 
			WHERE StudentId = @studentIdCheck

			DELETE FROM StudentsTeachers 
			WHERE StudentId = @studentIdCheck

			DELETE FROM Students
			WHERE Id = @studentIdCheck
		END
GO

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students

EXEC usp_ExcludeFromSchool 301