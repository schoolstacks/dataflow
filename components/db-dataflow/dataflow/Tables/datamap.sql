CREATE TABLE [dataflow].[datamap] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (255) NOT NULL,
    [EntityID]   INT           NOT NULL,
    [Map]        VARCHAR (MAX) NULL,
    [CreateDate] DATETIME      NULL,
    [UpdateDate] DATETIME      NULL,
    CONSTRAINT [PK_datamap] PRIMARY KEY CLUSTERED ([ID] ASC), 
    CONSTRAINT [FK_datamap_Entity] FOREIGN KEY ([EntityID]) REFERENCES [dataflow].[Entity]([ID])
);

