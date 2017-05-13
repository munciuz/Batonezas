CREATE TABLE PlacePlaceType (
	Id INT IDENTITY(1, 1) NOT NULL,
	PlaceId INT NOT NULL,
	PlaceTypeId INT NOT NULL,
	CONSTRAINT PK_PlacePlaceType PRIMARY KEY(Id)
)

EXEC FK 'PlacePlaceType', 'PlaceId'
EXEC FK 'PlacePlaceType', 'PlaceTypeId'