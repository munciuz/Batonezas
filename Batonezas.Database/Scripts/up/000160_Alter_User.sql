ALTER TABLE [User]
ADD ImageId INT NULL

EXEC FK 'User', 'ImageId'