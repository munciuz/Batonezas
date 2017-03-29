CREATE TABLE Review(
	Id INT IDENTITY(1, 1) NOT NULL,
	[Text] NVARCHAR(1024) NOT NULL,
	Rating INT NOT NULL,
	ImageId INT NULL,
	PlaceId INT NOT NULL,
	IsValid BIT NOT NULL,
	CreatedByUserId INT NOT NULL,
	CreatedDateTime DATETIME NOT NULL,
	CONSTRAINT PK_Review PRIMARY KEY(Id)
)

EXEC FK 'Review', 'CreatedByUserId', 'User'
EXEC FK 'Review', 'ImageId'
EXEC FK 'Review', 'PlaceId'