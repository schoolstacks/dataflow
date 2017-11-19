CREATE TABLE [dataflow].[agent] (
    [ID]            INT              IDENTITY (1, 1) NOT NULL,
    [Name]          VARCHAR (255)    NOT NULL,
    [AgentTypeCode] VARCHAR (50)     NOT NULL,
    [URL]           VARCHAR (MAX)    NULL,
    [Username]      VARCHAR (MAX)    NULL,
    [Password]      VARCHAR (MAX)    NULL,
    [Directory]     VARCHAR (MAX)    NULL,
    [FilePattern]   VARCHAR (MAX)    NULL,
    [Queue]         UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Custom]        VARCHAR (MAX)    NULL,
    [Enabled]       BIT              NOT NULL,
    [Created]       DATETIME         CONSTRAINT [DF_agent_Created] DEFAULT (getdate()) NOT NULL,
    [LastExecuted]  DATETIME         NULL,
    CONSTRAINT [PK_agent] PRIMARY KEY CLUSTERED ([ID] ASC)
);

