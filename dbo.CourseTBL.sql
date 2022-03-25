CREATE TABLE [dbo].[CourseTBL] (
    [CourseID] INT        NOT NULL,
    [Faculty]  NCHAR (10) NULL,
	UnitId INT NOT NULL,
    PRIMARY KEY CLUSTERED ([CourseID] ASC),
	FOREIGN KEY (UnitId) REFERENCES [dbo].[UnitTBL] (UnitId)
);

