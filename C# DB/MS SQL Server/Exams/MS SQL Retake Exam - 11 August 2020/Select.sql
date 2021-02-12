--TASK 5
SELECT 
	Name,
	Price,
	Description
	FROM Products
ORDER BY Price DESC, Name ASC

--TASK 6
SELECT 
	f.ProductId,
	f.Rate,
	f.Description,
	f.CustomerId,
	c.Age,
	c.Gender
	FROM Feedbacks AS f
JOIN Customers AS c ON f.CustomerId = c.Id
WHERE Rate < 5
ORDER BY f.ProductId DESC, f.Rate ASC

--TASK 7
SELECT
	CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
	c.PhoneNumber,
	c.Gender
FROM Customers AS c
LEFT JOIN Feedbacks AS f ON f.CustomerId = c.Id
WHERE f.Id IS NULL
ORDER BY c.Id ASC

--TASK 8
SELECT
		c.FirstName,
		c.Age,
		c.PhoneNumber
		FROM Customers AS c
	JOIN Countries AS co ON c.CountryId = co.Id
	WHERE (c.Age >= 21 AND c.FirstName LIKE '%an%') 
		OR (c.PhoneNumber LIKE '%38' AND co.Name != 'Greece')
ORDER BY c.FirstName ASC, c.Age DESC

--TASK 9
SELECT * FROM (SELECT
		d.Name AS DistributorName,
		i.Name AS IngredientName,
		p.Name AS ProductName,
		AVG(f.Rate) AS AverageRate
			FROM Distributors AS d
				JOIN Ingredients AS i ON d.Id = i.DistributorId
				JOIN ProductsIngredients AS pi ON i.Id = pi.IngredientId
				JOIN Products AS p ON pi.ProductId = p.Id
				JOIN Feedbacks AS f ON p.Id = f.ProductId
		GROUP BY d.Name, i.Name, p.Name) AS tmp
	WHERE AverageRate BETWEEN 5 AND 8
ORDER BY DistributorName ASC, IngredientName ASC, ProductName ASC

--TASK 10
--Select all countries with their most active distributor (the one with the greatest number of ingredients). If there are several distributors with most ingredients delivered, list them all. Order by country name then by distributor name.
SELECT
	CountryName,
	DistributorName
	FROM (SELECT 
		c.Name AS CountryName,
		d.Name AS DistributorName,
		COUNT(i.Id) AS Count, 
		DENSE_RANK() OVER (PARTITION BY c.Name ORDER BY COUNT(i.Id) DESC) AS [Rank]
		FROM Countries AS c
		JOIN Distributors AS d ON c.Id = d.CountryId 
		LEFT JOIN Ingredients AS i ON d.Id = i.DistributorId
		GROUP BY c.Name, d.Name) as temp
	WHERE Rank = 1
	ORDER BY CountryName, DistributorName

--TASK 11
CREATE VIEW v_UserWithCountries AS
SELECT 
	CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
	c.Age,
	c.Gender,
	co.Name
FROM Customers AS c
JOIN Countries AS co ON c.CountryId = co.Id

SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age

 --TASK 12
CREATE OR ALTER TRIGGER tr_DeleteFromProducts
ON Products
INSTEAD OF DELETE
AS
BEGIN
	DELETE FROM Feedbacks
	WHERE ProductId IN (SELECT p.Id FROM Products AS p
				JOIN deleted AS d ON p.Id = d.Id)

	DELETE FROM ProductsIngredients
	WHERE ProductId IN (SELECT p.Id FROM Products AS p
				JOIN deleted AS d ON p.Id = d.Id)

	DELETE FROM Products
	WHERE Products.Id IN (SELECT p.Id FROM Products AS p
				JOIN deleted AS d ON p.Id = d.Id)
END

DELETE FROM Products WHERE Id = 7