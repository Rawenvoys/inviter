CREATE OR ALTER PROCEDURE SP_InvitationGetByCode
(
	@code UNIQUEIDENTIFIER
)
AS
BEGIN
	SELECT 
		i.Id
		,i.DisplayName
		,i.KnowledgeTypes
        ,i.AskForAfterparty 
        ,i.AskForAccomodation
        ,i.AskAboutAccompanying
		,i.QRCode
		,i.InvitationDate
	FROM Invitation i
	WHERE i.Id = @code
END
GO

CREATE OR ALTER PROCEDURE SP_GuestGetByCode
(
	@code UNIQUEIDENTIFIER
)
AS
BEGIN
	SELECT 
		g.Id
		,g.InvitationId
		,g.FirstName
		,g.LastName
		,g.IsAccompanyingPerson
		,g.IsChild
	FROM Guest g
	WHERE g.InvitationId = @code
END
GO

CREATE OR ALTER PROCEDURE SP_GuestResponseGetByGuestId
(
	@guestId UNIQUEIDENTIFIER
)
AS
BEGIN
	SELECT 
		gr.GuestId
		,gr.WillBeAtWeddingParty
		,gr.WillBeAtAfterparty
		,gr.NeedAccomodation
	FROM GuestResponse gr
	WHERE gr.GuestId = @guestId
END
GO

CREATE OR ALTER PROCEDURE SP_GuestRemove
(
	@guestId UNIQUEIDENTIFIER
)
AS
BEGIN
	DELETE FROM GuestResponse WHERE GuestId = @guestId
	DELETE FROM Guest WHERE Id = @guestId
END
GO


CREATE OR ALTER PROCEDURE SP_GuestSave
(
	@id UNIQUEIDENTIFIER = NULL
	,@invitationId UNIQUEIDENTIFIER
	,@firstName NVARCHAR(100) = NULL
	,@lastName NVARCHAR(100) = NULL
	,@isAccompanyingPerson BIT
	,@isChild BIT
)
AS
BEGIN
	DECLARE @result TABLE(Name NVARCHAR(200), Id UNIQUEIDENTIFIER);
	
	MERGE Guest AS t
	USING (
		SELECT 
			@id AS 'Id'
			, @invitationId AS 'InvitationId'
			, @firstName AS 'FirstName'
			, @lastName AS 'LastName'
			, @isAccompanyingPerson 'IsAccompanyingPerson'
			, @isChild AS 'IsChild'
	) AS s
	ON t.Id = s.Id
	WHEN MATCHED THEN 
		UPDATE 
		SET InvitationId = @invitationId
			, FirstName = @firstName
			, LastName = @lastName
			, IsAccompanyingPerson = @isAccompanyingPerson
			, IsChild = @isChild
	WHEN NOT MATCHED THEN 
		INSERT (InvitationId, FirstName, LastName, IsAccompanyingPerson, IsChild)
		VALUES (@invitationId, @firstName, @lastName, @isAccompanyingPerson, @isChild)
	OUTPUT $action, INSERTED.Id INTO @result;
		
	SELECT Id FROM @result
END
GO


CREATE OR ALTER PROCEDURE SP_GuestResponseSave
(
	@guestId UNIQUEIDENTIFIER = NULL
	,@willBeAtWeddingParty BIT = NULL
	,@willBeAtAfterparty BIT = NULL
	,@needAccomodation BIT = NULL
)
AS
BEGIN
	DECLARE @result TABLE(Name NVARCHAR(200), Id UNIQUEIDENTIFIER);
	
	MERGE GuestResponse AS t
	USING (
		SELECT @guestId AS 'GuestId'
			, @willBeAtWeddingParty AS 'WillBeAtWeddingParty'
			, @willBeAtAfterparty AS 'WillBeAtAfterparty'
			, @needAccomodation AS 'NeedAccomodation'
	) AS s
	ON t.GuestId = s.GuestId
	WHEN MATCHED THEN 
		UPDATE 
		SET  WillBeAtWeddingParty = @willBeAtWeddingParty
			, WillBeAtAfterparty = @willBeAtAfterparty
			, NeedAccomodation = @needAccomodation
	WHEN NOT MATCHED THEN 
		INSERT (GuestId, WillBeAtWeddingParty, WillBeAtAfterparty, NeedAccomodation)
		VALUES (@guestId, @willBeAtWeddingParty, @willBeAtAfterparty, @needAccomodation)
	OUTPUT $action, INSERTED.GuestId INTO @result;
		
	SELECT Id FROM @result
END
GO

CREATE OR ALTER PROCEDURE SP_InvitationGetWithoutQRCode
AS
BEGIN
	SELECT 
		i.Id
		,i.DisplayName
		,i.KnowledgeTypes
        ,i.AskForAfterparty 
        ,i.AskForAccomodation
        ,i.AskAboutAccompanying
		,i.QRCode
		,i.InvitationDate
	FROM Invitation i
	WHERE i.QRCode IS NULL
END
GO


CREATE OR ALTER PROCEDURE SP_InvitationGetAll
AS
BEGIN
	SELECT 
		i.Id
		,i.DisplayName
		,i.KnowledgeTypes
        ,i.AskForAfterparty 
        ,i.AskForAccomodation
        ,i.AskAboutAccompanying
		,i.QRCode
		,i.InvitationDate
	FROM Invitation i
END
GO


CREATE OR ALTER PROCEDURE SP_InvitationSave
(
	 @id UNIQUEIDENTIFIER
	,@displayName NVARCHAR(2000)
	,@knowledgeTypes INT
	,@askForAfterparty BIT
	,@askForAccomodation BIT
	,@askAboutAccompanying BIT
	,@qrCode VARBINARY = NULL
	,@invitationDate DATETIME2 = NULL
)
AS
BEGIN
	DECLARE @result TABLE(Name NVARCHAR(200), Id UNIQUEIDENTIFIER);
	
	MERGE Invitation AS i
	USING (
		SELECT 
			@id AS 'Id'
			,@displayName AS 'DisplayName'
			,@knowledgeTypes AS 'KnowledgeTypes'
			,@askForAfterparty AS 'AskForAfterparty'
			,@askForAccomodation AS 'AskForAccomodation'
			,@askAboutAccompanying AS 'AskAboutAccompanying'
			,@qrCode AS 'QRCode'
			,@invitationDate AS 'InvitationDate' 
	) AS s
	ON i.Id = s.Id
	WHEN MATCHED THEN 
		UPDATE 
		SET DisplayName = @displayName
			,KnowledgeTypes = @knowledgeTypes
			,AskForAfterparty = @askForAfterparty
			,AskForAccomodation = @askForAccomodation
			,AskAboutAccompanying = @askAboutAccompanying
			,QRCode = @qrCode
			,InvitationDate = @invitationDate
	WHEN NOT MATCHED THEN 
		INSERT (Id, DisplayName, KnowledgeTypes, AskForAfterparty, AskForAccomodation, AskAboutAccompanying, QRCode, InvitationDate)
		VALUES (@id, @displayName, @knowledgeTypes, @askForAfterparty, @askForAccomodation, @askAboutAccompanying, @qrCode, @invitationDate)
	OUTPUT $action, INSERTED.Id INTO @result;
		
	SELECT Id FROM @result
END
GO