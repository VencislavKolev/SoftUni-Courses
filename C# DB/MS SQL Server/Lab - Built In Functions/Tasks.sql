/****** Script for SelectTopNRows command from SSMS  ******/
--Task 1
SELECT TOP (1000) [CustomerID]
      ,[FirstName]
      ,[LastName]
	  ,LEFT(PaymentNumber,6) + REPLICATE('*',(LEN(PaymentNumber)-6)) AS PaymentNumber
  FROM [Demo].[dbo].[Customers]

--Task 2
SELECT TOP (1000) [Id]
      ,(A * H)/2 AS Area
  FROM [Demo].[dbo].[Triangles2]
 
 --Task 3
 SELECT TOP (1000) [Id]
      ,[Name]
      ,[Quantity]
      ,[BoxCapacity]
      ,[PalletCapacity]
	  ,CEILING(Quantity * 1.0 / (PalletCapacity * BoxCapacity)) AS PalletsNeeded
  FROM [Demo].[dbo].[Products]

--Task 4
SELECT TOP (1000) [Id]
      ,[ProductName]
      ,[OrderDate]
	  ,DATEPART(QUARTER,OrderDate) AS Quarter
	  ,DATEPART(YEAR,OrderDate) AS Year
	  ,DATEPART(MONTH,OrderDate) AS Month
	  ,DATEPART(DAY,OrderDate) AS Day
  FROM [Orders].[dbo].[Orders]

--Task 5
SELECT TOP (1000) [ProjectID]
      ,[Name]
      ,[Description]
      ,[StartDate]
      ,[EndDate]
	  ,ISNULL(CAST(EndDate AS varchar),'Not Finished') AS ModifiedEndDate
  FROM [SoftUni].[dbo].[Projects]