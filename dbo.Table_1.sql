CREATE TABLE [dbo].[UnitTBL]
(
	[UnitId] INT NOT NULL,
	[UnitName] INT NOT NULL,
	[ClassId] INT,
	PRIMARY KEY (UnitId),
	FOREIGN KEY (ClassId)
);
