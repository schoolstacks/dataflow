/*    ==Scripting Parameters==

    Source Database Engine Edition : Microsoft Azure SQL Database Edition
    Source Database Engine Type : Microsoft Azure SQL Database

    Target Database Engine Edition : Microsoft Azure SQL Database Edition
    Target Database Engine Type : Microsoft Azure SQL Database
*/
SET IDENTITY_INSERT [dataflow].[agent_schedule] ON 

INSERT [dataflow].[agent_schedule] ([ID], [AgentID], [Day], [Hour], [Minute]) VALUES (1, 1, 3, 10, 12)
INSERT [dataflow].[agent_schedule] ([ID], [AgentID], [Day], [Hour], [Minute]) VALUES (13, 1, 1, 7, 11)
INSERT [dataflow].[agent_schedule] ([ID], [AgentID], [Day], [Hour], [Minute]) VALUES (14, 1, 1, 1, 1)
INSERT [dataflow].[agent_schedule] ([ID], [AgentID], [Day], [Hour], [Minute]) VALUES (15, 1, 2, 1, 1)
INSERT [dataflow].[agent_schedule] ([ID], [AgentID], [Day], [Hour], [Minute]) VALUES (16, 1, 3, 1, 1)
INSERT [dataflow].[agent_schedule] ([ID], [AgentID], [Day], [Hour], [Minute]) VALUES (17, 1, 5, 21, 0)
SET IDENTITY_INSERT [dataflow].[agent_schedule] OFF
GO