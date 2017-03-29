CREATE TABLE PlaceReview(
	Id INT IDENTITY(1, 1) NOT NULL,
	ReviewId INT NOT NULL,
	CONSTRAINT PK_PlaceReview PRIMARY KEY(Id)
)

EXEC FK 'PlaceReview', 'ReviewId'