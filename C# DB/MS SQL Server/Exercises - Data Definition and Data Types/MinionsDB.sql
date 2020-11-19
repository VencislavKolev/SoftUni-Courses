--Task 1
CREATE TABLE Minions(
	Id INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	Age TINYINT
	);

--Task 2 
CREATE TABLE Towns(
	Id int primary key not null,
	[Name] nvarchar(50) not null
	)

--Task 3
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

--Task 4
INSERT INTO Towns(Id,[Name])
VALUES
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')

INSERT INTO Minions(Id,[Name],Age,TownId)
	VALUES
		(1,'Kevin',22,1),
		(2,'Bob',15,3),
		(3,'Steward',NULL,2)

--Task 5
TRUNCATE TABLE Minions

--Task 6 
DROP TABLE Minions
DROP TABLE Towns

--Task 7
CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX)
CHECK(DATALENGTH(Picture) <= 2*1024*1024),
Height DECIMAL(3,2),
[Weight] DECIMAL(5,2),
Gender CHAR(1) NOT NULL
CHECK(Gender = 'm' OR Gender = 'f'),
Birthdate DATETIME2 NOT NULL,
Biography NVARCHAR(MAX)
)

INSERT INTO People ([Name],Gender,Birthdate)
VALUES 
('Venci0','m','04-07-1997'),
('Venci1','m','04-07-1997'),
('Venci2','m','04-07-1997'),
('Venci3','m','04-07-1997'),
('Venci4','m','04-07-1997')

--Task 8

CREATE TABLE Users(
Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
Username VARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX)
CHECK (DATALENGTH(ProfilePicture) <= 900*1024),
LastLoginTime DATETIME2,
IsDeleted BIT NOT NULL
)

INSERT INTO Users(Username,[Password],IsDeleted)
VALUES
('Test0',123456,0),
('Test1',123456,1),
('Test2',123456,0),
('Test3',123456,1),
('Test4',123456,1)

--Task 9
ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC07BB4B5B65]

ALTER TABLE Users
ADD CONSTRAINT PK_Users_CompositeIdUsername
PRIMARY KEY(Id,Username)

--Task 10
ALTER TABLE Users
ADD CONSTRAINT CK_Users_PasswordLength
CHECK(LEN([Password]) >=5 )

--Task 11
ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

INSERT INTO Users(Username,[Password],IsDeleted)
VALUES
('TestNoTime',123456,0)

--Task 12
ALTER TABLE Users
DROP CONSTRAINT PK_Users_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id
PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_UsernameLength
CHECK (LEN(Username) >= 3)