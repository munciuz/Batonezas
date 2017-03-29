CREATE TABLE DishReview(
	Id INT IDENTITY(1, 1) NOT NULL,
	ReviewId INT NOT NULL,
	DishId INT NOT NULL,
	CONSTRAINT PK_DishReview PRIMARY KEY(Id)
)

EXEC FK 'DishReview', 'ReviewId'
EXEC FK 'DishReview', 'DishId'