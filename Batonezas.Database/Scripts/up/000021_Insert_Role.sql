SET IDENTITY_INSERT dbo.[Role] ON

INSERT dbo.Role
(
    Id,--Id - this column value is auto-generated
    Name
)
VALUES
(
    1, -- Id - int
    N'Admin' -- Name - nvarchar
)

SET IDENTITY_INSERT dbo.[Role] OFF