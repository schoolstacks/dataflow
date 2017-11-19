CREATE TABLE [dataflow].[configuration] (
    [Key]      VARCHAR (255) NOT NULL,
    [Category] VARCHAR (255) NULL,
    [Type]     VARCHAR (255) NULL,
    [Value]    VARCHAR (MAX) NULL,
    CONSTRAINT [PK_dataflow.configuration] PRIMARY KEY CLUSTERED ([Key] ASC)
);

