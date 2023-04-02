IF db_name()<>'master' and
   not exists (	select * from information_schema.tables
		where table_name='Invitation' and table_type='BASE TABLE')
BEGIN
	Print 'Create table Invitation';
	
	CREATE TABLE [dbo].[Invitation](	
			[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT(NEWID()), -- PK
			[DisplayName] NVARCHAR(1000) NOT NULL,
			[KnowledgeTypes] INT NOT NULL,
			[AskForAfterparty] BIT NOT NULL CONSTRAINT DV_Invitation_AskForAfterparty DEFAULT(0),
			[AskForAccomodation] BIT NOT NULL CONSTRAINT DV_Invitation_AskForAccomodation DEFAULT(0),
			[AskAboutAccompanying] BIT NOT NULL CONSTRAINT DV_Invitation_AskAboutAccompanying DEFAULT(0)
  	) ON [Primary];
END;
--- End of Invitation

IF db_name()<>'master' and
   not exists (	select * from information_schema.tables
		where table_name='Guest' and table_type='BASE TABLE')
BEGIN
	Print 'Create table Guest';
	
	CREATE TABLE [dbo].[Guest](	
			[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT(NEWID()), -- PK
			[FirstName] NVARCHAR(100) NOT NULL,
			[LastName] NVARCHAR(100) NOT NULL,
			[InvitationId] UNIQUEIDENTIFIER NOT NULL,
			[IsAccompanyingPerson] BIT NOT NULL CONSTRAINT DV_Guest_IsAccompanyingPerson DEFAULT(0),
			[IsChild] BIT NOT NULL CONSTRAINT DV_Guest_IsChild DEFAULT(0),
			CONSTRAINT [FK_Guest_Invitation] FOREIGN KEY(InvitationId) REFERENCES Invitation(Id)
  	) ON [Primary];
END;
--- End of Guest

IF db_name()<>'master' and
   not exists (	select * from information_schema.tables
		where table_name='GuestResponse' and table_type='BASE TABLE')
BEGIN
	Print 'Create table GuestResponse';
	
	CREATE TABLE [dbo].[GuestResponse](	
			[GuestId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, -- PK, FK
			[WillBeAtWeddingParty] BIT NULL,
			[WillBeAtAfterParty] BIT NULL,
			[NeedAccomodation] BIT NULL
			CONSTRAINT [FK_GuestResponse_Guest] FOREIGN KEY(GuestId) REFERENCES Guest(Id)
  	) ON [Primary];
END;
--- End of GuestResponse

