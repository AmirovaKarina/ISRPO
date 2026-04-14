use AlarmClockDB
go 

create table Alarms (
	Id INT IDENTITY(1,1) PRIMARY KEY,
    AlarmTime TIME(7) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    RepeatDaily BIT NOT NULL DEFAULT 0,
    Label NVARCHAR(100) NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
)
go