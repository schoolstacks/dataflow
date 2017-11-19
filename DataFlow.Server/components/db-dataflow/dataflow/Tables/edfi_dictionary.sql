CREATE TABLE [dataflow].[edfi_dictionary] (
    [ID]            INT          IDENTITY (1, 1) NOT NULL,
    [GroupSet]      VARCHAR (50) NOT NULL,
    [OriginalValue] VARCHAR (50) NOT NULL,
    [DisplayValue]  VARCHAR (50) NOT NULL,
    [DisplayOrder]  INT          NULL,
    CONSTRAINT [PK_edfi_dictionary] PRIMARY KEY CLUSTERED ([ID] ASC)
);

