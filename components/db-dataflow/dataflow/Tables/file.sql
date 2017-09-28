CREATE TABLE [dataflow].[file] (
    [ID]         INT             IDENTITY (1, 1) NOT NULL,
    [Filename]   VARCHAR (MAX)   NOT NULL,
    [Content]    VARBINARY (MAX) NULL,
    [Metadata]   VARCHAR (MAX)   NULL,
    [CreateDate] DATETIME        NULL,
    [UpdateDate] DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

