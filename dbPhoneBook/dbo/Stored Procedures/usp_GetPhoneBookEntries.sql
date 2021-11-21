CREATE PROCEDURE [dbo].[usp_GetPhoneBookEntries]

AS
BEGIN
	SELECT PB.[Id], PB.[Name], PB.[Entries], E.[PhoneNumber], PB.[CreatedDateTime]
	FROM tblPhoneBook AS PB WITH (NOLOCK)
	INNER JOIN tblEntry AS E WITH (NOLOCK)
	ON  PB.[NAME] = E.[NAME]
	ORDER BY PB.[Id] DESC
END