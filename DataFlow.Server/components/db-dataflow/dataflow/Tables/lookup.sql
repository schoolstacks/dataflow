CREATE TABLE [dataflow].[lookup] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [GroupSet] VARCHAR (1024) NOT NULL,
    [Key]      VARCHAR (1024) NOT NULL,
    [Value]    VARCHAR (1024) NOT NULL,
    CONSTRAINT [PK_lookup] PRIMARY KEY CLUSTERED ([ID] ASC)
);

