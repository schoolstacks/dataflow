CREATE TABLE [dataflow].[entity] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (255) NOT NULL,
    [Namespace]  VARCHAR (MAX) NULL,
    [URL]        VARCHAR (MAX) NULL,
    [Family]     VARCHAR (MAX) NULL,
    [Metadata]   VARCHAR (MAX) NULL,
    [CreateDate] DATE          NULL,
    [UpdateDate] DATE          NULL,
    CONSTRAINT [PK_entity] PRIMARY KEY CLUSTERED ([ID] ASC)
);

