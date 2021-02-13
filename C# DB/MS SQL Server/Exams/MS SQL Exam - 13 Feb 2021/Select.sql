--TASK 5
SELECT 
	Id,
	Message,
	RepositoryId,
	ContributorId
	FROM Commits
ORDER BY Id ASC, Message ASC, RepositoryId ASC, ContributorId ASC

--TASK 6
SELECT
	Id,
	Name,
	Size
	FROM Files
WHERE Size > 1000 AND Name LIKE '%html%'
ORDER BY Size DESC, Id ASC, Name ASC

--TASK 7
SELECT 
	i.Id,
	CONCAT(u.Username, ' : ', i.Title) AS IssueAssignee
FROM Issues AS i
JOIN Users AS u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, IssueAssignee ASC

--TASK 8
SELECT 
	Id,
	Name,
	CONCAT(CONVERT(VARCHAR(MAX), Size),'KB') AS Size
FROM Files
WHERE Id != ParentId
ORDER BY Id ASC, Name ASC, Size DESC

SELECT 
	fp.Id,
	fp.Name,
	CONCAT(CONVERT(VARCHAR(MAX), fp.Size),'KB') AS Size
FROM Files AS f
RIGHT JOIN Files as fp ON f.ParentId = fp.Id
WHERE f.Id IS NULL
ORDER BY fp.Id ASC, fp.Name ASC, Size DESC

--TASK 9
SELECT TOP (5)
	r.Id,
	r.Name,
	COUNT(*) AS Commits
	FROM RepositoriesContributors AS rc
LEFT JOIN Repositories AS r ON rc.RepositoryId = r.Id
LEFT JOIN Commits AS c ON r.Id = c.RepositoryId
GROUP BY r.Id, r.Name
ORDER BY Commits DESC, r.Id ASC, r.Name ASC


--TASK 10
SELECT 
	u.Username,
	AVG(f.Size) AS Size
	FROM Users AS u
	JOIN Commits AS c ON u.Id = c.ContributorId
	JOIN Files AS f ON c.Id = f.CommitId
	GROUP BY u.Username
ORDER BY Size DESC, u.Username ASC

--TASK 11
CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(MAX))
RETURNS INT
AS
BEGIN 
	DECLARE @count INT = (SELECT COUNT(*) FROM Users AS u
						JOIN Commits AS c ON u.Id = c.ContributorId
						WHERE u.Username = @username)
	RETURN @count
END

SELECT dbo.udf_AllUserCommits('UnderSinduxrein')

--TASK 12
CREATE PROCEDURE usp_SearchForFiles(@fileExtension VARCHAR(MAX))
AS
	SELECT 
		f.Id,
		f.Name,
		CONCAT(CONVERT(VARCHAR(MAX), f.Size),'KB') AS Size
		FROM Files AS f
	WHERE Name LIKE '%' + @fileExtension
ORDER BY f.Id ASC, f.Name ASC, f.Size DESC

EXEC usp_SearchForFiles 'txt'