CREATE TABLE Tag(
	Id INT IDENTITY(1, 1) NOT NULL,
	Name NVARCHAR(256) NOT NULL,
	IsValid BIT NOT NULL,
	CreatedByUserId INT NOT NULL,
	CreatedDateTime DATETIME NOT NULL,
	CONSTRAINT PK_Tag PRIMARY KEY(Id)
)