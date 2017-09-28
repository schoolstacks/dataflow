CREATE TABLE [dataflow].[log_ingestion] (
    [ID]                      INT              IDENTITY (1, 1) NOT NULL,
    [EducationOrganizationId] UNIQUEIDENTIFIER NULL,
    [Level]                   VARCHAR (255)    NOT NULL,
    [Operation]               VARCHAR (255)    NOT NULL,
    [AgentID]                 INT              NULL,
    [Process]                 VARCHAR (MAX)    NOT NULL,
    [Filename]                VARCHAR (MAX)    NULL,
    [Result]                  VARCHAR (255)    NOT NULL,
    [Message]                 VARCHAR (MAX)    NULL,
    [RecordCount]             INT              DEFAULT ((0)) NULL,
    [Date]                    DATETIME         NOT NULL
);

