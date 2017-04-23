CREATE TABLE DishTag(
	Id INT IDENTITY(1, 1) NOT NULL,
	DishId INT NOT NULL,
	TagId INT NOT NULL,
	CreatedByUserId INT NOT NULL,
	CreatedDateTime DATETIME NOT NULL,
	CONSTRAINT PK_DishTag PRIMARY KEY(Id)
)

EXEC FK 'DishTag', 'DishId'
EXEC FK 'DishTag', 'TagId'
EXEC FK 'DishTag', 'CreatedByUserId', 'User'