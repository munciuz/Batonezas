SET IDENTITY_INSERT dbo.[User] ON

INSERT INTO dbo.[User]
(
    Id,--Id - this column value is auto-generated
    Email,
    EmailConfirmed,
    PasswordHash,
    PhoneNumberConfirmed,
    TwoFactorEnabled,
    LockoutEnabled,
    AccessFailedCount,
    UserName,
    Discriminator
)
VALUES
(
    1, -- Id - int
    N'admin@somesite.com', -- Email - nvarchar
    1, -- EmailConfirmed - bit
    N'AAkoFPvmCEYNpRWwtLoU7SBCL7WLLK8Qm25jkpXDKw7LCwug6ttseJ2F8cEd3h8MLQ==', -- PasswordHash - nvarchar administrator123
    0, -- PhoneNumberConfirmed - bit
    0, -- TwoFactorEnabled - bit
    0, -- LockoutEnabled - bit
    0, -- AccessFailedCount - int
    N'administrator', -- UserName - nvarchar
    N'IdentityUser' -- Discriminator - nvarchar
)

SET IDENTITY_INSERT dbo.[User] OFF