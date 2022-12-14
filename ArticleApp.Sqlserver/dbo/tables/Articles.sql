--- Article Table

CREATE TABLE [dbo].[Articles]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1),
	[Title] NVarchar(255) NOT NULL,

	[Content] NVarchar(MAX) NOT NULL,

--- Auditable.cs 참조
	[CreatedBy] NVarchar(255) Null,			--- 등록자
	[Created] DateTime Default(GetDate()),				--- 등록일
	[ModifiedBy] NVarchar(255) Null,		--- 수정자
	[Modified] DateTime Null		--- 수정일
	
)

GO

