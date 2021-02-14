CREATE TABLE [dbo].[tblPhoneBook] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (200) NOT NULL,
    [Entries]         NVARCHAR (200) NULL,
    [CreatedDateTime] DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([Name] ASC)
);

