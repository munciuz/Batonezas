CREATE PROCEDURE dbo.FK(
	@TableName NVARCHAR(250),
	@ColumnName NVARCHAR(250),
	@RelationTableName NVARCHAR(250) = NULL
)
AS
BEGIN
	DECLARE @executeSql varchar (255)
	DECLARE @errorText varchar (255)
	DECLARE @constraintName varchar (255)
	DECLARE @indexName varchar (255)

	IF (@RelationTableName IS NULL)
	BEGIN
		SET @RelationTableName = LEFT(@ColumnName, LEN(@ColumnName) - 2)
	END

	IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.[' + @TableName + ']'))
	BEGIN
		EXEC xp_sprintf @errorText OUTPUT, 'Table "%s" not exists', @TableName
		RAISERROR(@errorText, 16, 1)
		RETURN
	END

	IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.[' + @RelationTableName + ']'))
	BEGIN
		EXEC xp_sprintf @errorText OUTPUT, 'Table "%s" not exists', @RelationTableName
		RAISERROR(@errorText, 16, 1)
		RETURN
	END

	IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = @ColumnName AND Object_ID = Object_ID('dbo.[' + @TableName + ']'))
	BEGIN
		EXEC xp_sprintf @errorText OUTPUT, 'Table "%s" does not contain column "%s"', @TableName, @ColumnName
		RAISERROR(@errorText, 16, 1)
		RETURN
	END

	EXEC xp_sprintf @constraintName OUTPUT, 'FK_%s_%s', @TableName, @RelationTableName

	IF NOT EXISTS (SELECT TOP 1 * FROM sys.objects WHERE name = @constraintName	AND OBJECT_NAME(parent_object_id) = @TableName)
	BEGIN
		EXEC xp_sprintf @executeSql OUTPUT, 'ALTER TABLE [%s] ADD CONSTRAINT %s FOREIGN KEY(%s) REFERENCES [%s](Id)', 
			@TableName, @constraintName, @ColumnName, @RelationTableName
		EXEC(@executeSql)
	END
	
	EXEC xp_sprintf @indexName OUTPUT, 'IX_%s', @ColumnName
	
	IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID('dbo.[' + @TableName + ']') AND name = @indexName)
	BEGIN
		EXEC xp_sprintf @executeSql OUTPUT, 'CREATE INDEX %s ON [%s] (%s)', @indexName, @TableName, @ColumnName
		EXEC(@executeSql)
	END

END
GO