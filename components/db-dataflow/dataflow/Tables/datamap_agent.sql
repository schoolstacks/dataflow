CREATE TABLE [dataflow].[datamap_agent] (
    [ID]              INT IDENTITY (1, 1) NOT NULL,
    [DataMapID]       INT NOT NULL,
    [AgentID]         INT NOT NULL,
    [ProcessingOrder] INT NOT NULL,
    CONSTRAINT [PK_dataflow.datamap_agent] PRIMARY KEY CLUSTERED ([ID] ASC)
);

