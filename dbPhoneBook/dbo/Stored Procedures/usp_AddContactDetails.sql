CREATE PROCEDURE [dbo].[usp_AddContactDetails]
	@Entries NVARCHAR(200),
	@Name NVARCHAR(200),
	@PhoneNumber BIGINT
AS
BEGIN 
	
	INSERT INTO tblPhoneBook([Name], [Entries], [CreatedDateTime])
	VALUES(@Name, @Entries, GETDATE())

	INSERT INTO tblEntry([PhoneNumber], [Name], [CreatedDateTime])
	VALUES(@PhoneNumber, (SELECT [Name] FROM tblPhoneBook where [Name] = @Name), GETDATE())

END