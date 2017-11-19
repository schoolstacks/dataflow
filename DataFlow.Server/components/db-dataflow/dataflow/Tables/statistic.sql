CREATE TABLE [dataflow].[statistic] (
    [ID]               INT              IDENTITY (1, 1) NOT NULL,
    [EntityID]         UNIQUEIDENTIFIER NOT NULL,
    [EntityType]       VARCHAR (255)    NOT NULL,
    [TermDescriptorId] INT              NULL,
    [SchoolYear]       SMALLINT         NULL,
    [Measure]          VARCHAR (255)    NOT NULL,
    [ValueInt]         INT              NULL,
    [ValueDecimal]     DECIMAL (18)     NULL,
    [ValueVarchar]     VARCHAR (MAX)    NULL,
    [InsertDate]       DATETIME         NULL,
    [UpdateDate]       DATETIME         NULL,
    CONSTRAINT [PK_statistic] PRIMARY KEY CLUSTERED ([ID] ASC)
);

