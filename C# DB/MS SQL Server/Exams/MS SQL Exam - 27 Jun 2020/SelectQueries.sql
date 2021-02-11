--TASK 5
SELECT m.FirstName + ' ' + m.LastName AS Mechanic,
		j.Status,
		j.IssueDate
FROM Mechanics AS m
JOIN Jobs AS j ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId ASC, j.IssueDate ASC, j.JobId ASC

--TASK 6
SELECT 
		c.FirstName + ' ' + c.LastName AS Client,
		DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going],
		j.Status
	FROM Clients AS c
	JOIN Jobs AS j ON c.ClientId = j.ClientId
	WHERE j.Status != 'Finished'
ORDER BY [Days going] DESC, c.ClientId ASC

--TASK 7
SELECT
		m.FirstName + ' ' + m.LastName AS Mechanic,
		AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS AverageDays
	FROM Mechanics AS m
	JOIN Jobs AS j ON m.MechanicId = j.MechanicId
	GROUP BY m.MechanicId, m.FirstName, m.LastName
ORDER BY m.MechanicId ASC

--TASK 8
SELECT  
	m.FirstName + ' ' + m.LastName AS Mechanic
	FROM Mechanics AS m
WHERE m.MechanicId NOT IN (SELECT DISTINCT m.MechanicId
							FROM Mechanics AS m
							JOIN Jobs AS j ON m.MechanicId = j.MechanicId
							WHERE j.Status = 'In Progress' OR j.Status = 'Pending')
							--EXISTS (SELECT * FROM Jobs WHERE j.Status = 'In Progress' OR j.Status = 'Pending'))
ORDER BY m.MechanicId

--TASK 9
SELECT
		j.JobId,
		ISNULL(SUM(p.Price * op.Quantity), 0) AS Total
	FROM Jobs AS j
		LEFT JOIN Orders AS o ON j.JobId = o.JobId
		LEFT JOIN OrderParts AS op ON o.OrderId = op.OrderId
		LEFT JOIN Parts AS p ON op.PartId = p.PartId
	WHERE j.Status = 'Finished'
	GROUP BY j.JobId
ORDER BY Total DESC, j.JobId ASC

--TASK 10
SELECT
		p.PartId,
		p.Description,
		ISNULL(pn.Quantity, 0) AS Required,
		ISNULL(p.StockQty, 0) AS [In Stock],
		ISNULL(IIF(o.Delivered = 0, op.Quantity, 0), 0) AS Ordered
		FROM Jobs AS j
			LEFT JOIN PartsNeeded AS pn ON j.JobId = pn.JobId
			LEFT JOIN Parts AS p ON pn.PartId = p.PartId
			LEFT JOIN Orders AS o ON j.JobId = o.JobId
			LEFT JOIN OrderParts AS op ON o.OrderId = op.OrderId
			LEFT JOIN Parts AS np ON op.PartId = np.PartId
		WHERE j.Status != 'Finished'
				AND pn.Quantity > ISNULL (
				(p.StockQty + IIF(o.Delivered = 0, op.Quantity, 0))
				, 0)
ORDER BY p.PartId ASC

--TASK 11
CREATE OR ALTER PROCEDURE usp_PlaceOrder(@JobId INT, @PartSerialNumber VARCHAR(50), @Quantity INT)
AS
	DECLARE @JobIdExists INT = ISNULL((SELECT JobId FROM Jobs
										WHERE JobId = @JobId), 0)

	DECLARE @PartExists BIT = (SELECT COUNT(SerialNumber) FROM Parts
										WHERE SerialNumber = @PartSerialNumber)

	DECLARE @JobStatus VARCHAR(20) = (SELECT Status FROM Jobs
									WHERE JobId = @JobId)

	IF (@Quantity <= 0)
		THROW 50012, 'Part quantity must be more than zero!', 1;

	IF(@JobStatus = 'Finished')
		THROW 50011, 'This job is not active!', 1;

	IF(@JobIdExists = 0)
		THROW 50013, 'Job not found!', 1;

	IF (@PartExists = 0)
		THROW 50014, 'Part not found!', 1;

	DECLARE @OrderForJobId INT = (SELECT COUNT(OrderId) FROM Orders
								WHERE JobId = @JobId AND IssueDate IS NULL)
	IF(@OrderForJobId = 0)
	INSERT INTO Orders
	VALUES (@JobId, NULL, 0)

	DECLARE @OrderId INT = (SELECT OrderId FROM Orders
							WHERE JobId = @JobId AND IssueDate IS NULL)

	IF(@OrderId > 0 AND @PartExists = 1)
		BEGIN
			DECLARE @PartId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @PartSerialNumber)
			DECLARE @PartExistsInOrder INT = (SELECT COUNT(*) FROM OrderParts WHERE OrderId = @OrderId AND PartId = @PartId)

		IF(@PartExistsInOrder > 0)
			BEGIN
				UPDATE OrderParts
				SET Quantity += @Quantity
				WHERE OrderId = @OrderId AND PartId = @PartId
			END

		ELSE
			BEGIN
				INSERT INTO OrderParts
				VALUES (@OrderId, @PartId, @Quantity)
			END

		END
GO


DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH

--TASK 12
CREATE FUNCTION udf_GetCost(@JobId INT)
RETURNS DECIMAL(18, 2)
AS
BEGIN
	DECLARE @result DECIMAL(18, 2) = (SELECT ISNULL(SUM(p.Price * op.Quantity), 0) AS Sum
		FROM Jobs AS j
		JOIN Orders AS o ON j.JobId = o.JobId
		JOIN OrderParts AS op ON o.OrderId = op.OrderId
		JOIN Parts AS p ON op.PartId = p.PartId
		WHERE j.JobId = @JobId)
	RETURN @result
END

SELECT dbo.udf_GetCost(1)