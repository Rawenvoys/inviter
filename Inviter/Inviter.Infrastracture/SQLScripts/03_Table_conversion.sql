IF db_name()<>'master' and
   not exists (	select * from information_schema.tables
		where table_name='_Migration' and table_type='BASE TABLE')
BEGIN
	Print 'Create table _Migration';

CREATE TABLE _Migration
(
	Id UNIQUEIDENTIFIER NOT NULL
	,ExecutionDateUTC DATETIME2 NOT NULL
)
END;


IF NOT EXISTS (SELECT * FROM _Migration WHERE Id = 'D943E7F6-B1CF-44EA-8811-C5C94032E8F0')
BEGIN
	ALTER TABLE Guest
	ALTER COLUMN FirstName NVARCHAR(100) NULL

	ALTER TABLE Guest
	ALTER COLUMN LastName NVARCHAR(100) NULL

	INSERT INTO _Migration VALUES('D943E7F6-B1CF-44EA-8811-C5C94032E8F0', GETUTCDATE())
END

