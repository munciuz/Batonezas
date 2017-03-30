CREATE TABLE Dish(
	Id INT IDENTITY(1, 1) NOT NULL,
	Name NVARCHAR(256) NOT NULL,
	DishTypeId INT NOT NULL,
	IsValid BIT NOT NULL,
	IsConfirmed BIT NOT NULL,
	CreatedByUserId INT NOT NULL,
	CreatedDateTime DATETIME NOT NULL,
	CONSTRAINT PK_Dish PRIMARY KEY(Id)
)

EXEC FK 'Dish', 'CreatedByUserId', 'User'
EXEC FK 'Dish', 'DishTypeId'