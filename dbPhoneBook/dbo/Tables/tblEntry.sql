CREATE TABLE [dbo].[tblEntry] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [PhoneNumber]     BIGINT         NOT NULL,
    [Name]            NVARCHAR (200) NOT NULL,
    [CreatedDateTime] DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([PhoneNumber] ASC),
    FOREIGN KEY ([Name]) REFERENCES [dbo].[tblPhoneBook] ([Name])
);

