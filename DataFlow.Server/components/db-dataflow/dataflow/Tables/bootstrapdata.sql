CREATE TABLE [dataflow].[bootstrapdata] (
    [ID]              INT           IDENTITY (1, 1) NOT NULL,
    [EntityID]        INT           NOT NULL,
    [Data]            VARCHAR (MAX) NOT NULL,
    [ProcessingOrder] INT           NOT NULL,
    [ProcessedDate]   DATETIME      NULL,
    [CreateDate]      DATETIME      NULL,
    [UpdateDate]      DATETIME      NULL,
    CONSTRAINT [PK_bootstrapdata] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_bootstrapdata_entity] FOREIGN KEY ([EntityID]) REFERENCES [dataflow].[entity] ([ID])
);

