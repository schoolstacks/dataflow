CREATE TABLE [dataflow].[processed_data] (
    [id]                 INT            IDENTITY (1, 1) NOT NULL,
    [base64HashedString] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_ProcessedData] PRIMARY KEY CLUSTERED ([id] ASC)
);

