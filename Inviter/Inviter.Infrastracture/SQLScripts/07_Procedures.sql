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


