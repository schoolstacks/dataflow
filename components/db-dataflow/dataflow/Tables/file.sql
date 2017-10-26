CREATE TABLE [dataflow].[file] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [Filename]   VARCHAR (MAX) NOT NULL,
    [URL]        VARCHAR (MAX) NULL,
    [AgentID]    INT           NOT NULL,
    [Status]     VARCHAR (255) NOT NULL,
    [Message]    VARCHAR (MAX) NULL,
    [Rows]       INT           NULL,
    [CreateDate] DATETIME      NULL,
    [UpdateDate] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_file_agent] FOREIGN KEY ([AgentID]) REFERENCES [dataflow].[agent] ([ID]),
    CONSTRAINT [FK_file_file_status] FOREIGN KEY ([Status]) REFERENCES [dataflow].[file_status] ([Value])
);



