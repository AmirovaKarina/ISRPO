CREATE TABLE FileOperations (
        Id             INT PRIMARY KEY IDENTITY(1,1),
        FilePath       NVARCHAR(500)    NOT NULL,
        Content        NVARCHAR(MAX)    NOT NULL,
        SymbolCount    INT              NOT NULL,
        OperationType  NVARCHAR(50)     NOT NULL,
        OperationDate  DATETIME         NOT NULL DEFAULT GETDATE()
)