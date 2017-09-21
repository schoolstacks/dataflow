CREATE SCHEMA [dataflow] AUTHORIZATION [dbo]
GO

CREATE TABLE [dataflow].[agent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[AgentTypeCode] [varchar](50) NOT NULL,
	[URL] [varchar](max) NULL,
	[Username] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
	[Directory] [varchar](max) NULL,
	[FilePattern] [varchar](max) NULL,
	[DataMapID] [int] NULL,
	[Custom] [varchar](max) NULL,
	[Enabled] [bit] NOT NULL,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_agent_Created]  DEFAULT (getdate()),
 CONSTRAINT [PK_agent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dataflow].[agent_schedule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AgentID] [int] NOT NULL,
	[Day] [int] NOT NULL,
	[Hour] [int] NOT NULL,
	[Minute] [int] NOT NULL,
 CONSTRAINT [PK_agent_schedule] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dataflow].[configuration](
	[Key] [varchar](255) NOT NULL,
	[Category] [varchar](255) NULL,
	[Type] [varchar](255) NULL,
	[Value] [varchar](max) NULL,
 CONSTRAINT [PK_dataflow.configuration] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dataflow].[datamap](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[EntityID] [int] NOT NULL,
	[Map] [varchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_datamap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dataflow].[entity](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Namespace] [varchar](max) NULL,
	[URL] [varchar](max) NULL,
	[Family] [varchar](max) NULL,
	[Metadata] [varchar](max) NULL,
	[CreateDate] [date] NULL,
	[UpdateDate] [date] NULL,
 CONSTRAINT [PK_entity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dataflow].[file](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Filename] [varchar](max) NOT NULL,
	[Content] [varbinary](max) NULL,
	[Metadata] [varchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dataflow].[log_application](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Thread] [varchar](255) NOT NULL,
	[Level] [varchar](50) NOT NULL,
	[Logger] [varchar](255) NOT NULL,
	[Message] [varchar](4000) NOT NULL,
	[Exception] [varchar](2000) NULL
) ON [PRIMARY]

GO

CREATE TABLE [dataflow].[log_ingestion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EducationOrganizationId] [uniqueidentifier] NULL,
	[Level] [varchar](255) NOT NULL,
	[Operation] [varchar](255) NOT NULL,
	[AgentID] [int] NULL,
	[Process] [varchar](max) NOT NULL,
	[Filename] [varchar](max) NULL,
	[Result] [varchar](255) NOT NULL,
	[Message] [varchar](max) NULL,
	[RecordCount] [int] NULL DEFAULT ((0)),
	[Date] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dataflow].[lookup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GroupSet] varchar(1024) NOT NULL,
	[Key] varchar(1024) NOT NULL,
	[Value] varchar(1024) NOT NULL
 CONSTRAINT [PK_lookup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dataflow].[statistic](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EntityID] [uniqueidentifier] NOT NULL,
	[EntityType] [varchar](255) NOT NULL,
	[TermDescriptorId] [int] NULL,
	[SchoolYear] [smallint] NULL,
	[Measure] [varchar](255) NOT NULL,
	[ValueInt] [int] NULL,
	[ValueDecimal] [decimal](18, 0) NULL,
	[ValueVarchar] [varchar](max) NULL,
	[InsertDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_statistic] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO