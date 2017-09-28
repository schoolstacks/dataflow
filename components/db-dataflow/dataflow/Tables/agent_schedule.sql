CREATE TABLE [dataflow].[agent_schedule] (
    [ID]      INT IDENTITY (1, 1) NOT NULL,
    [AgentID] INT NOT NULL,
    [Day]     INT NOT NULL,
    [Hour]    INT NOT NULL,
    [Minute]  INT NOT NULL,
    CONSTRAINT [PK_agent_schedule] PRIMARY KEY CLUSTERED ([ID] ASC), 
    CONSTRAINT [FK_agent_schedule_Agent] FOREIGN KEY ([AgentID]) REFERENCES [dataflow].[Agent]([ID])
);

