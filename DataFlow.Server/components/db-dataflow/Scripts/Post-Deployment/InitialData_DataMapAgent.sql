/*    ==Scripting Parameters==

    Source Database Engine Edition : Microsoft Azure SQL Database Edition
    Source Database Engine Type : Microsoft Azure SQL Database

    Target Database Engine Edition : Microsoft Azure SQL Database Edition
    Target Database Engine Type : Microsoft Azure SQL Database
*/
SET IDENTITY_INSERT [dataflow].[datamap_agent] ON 

INSERT [dataflow].[datamap_agent] ([ID], [DataMapID], [AgentID], [ProcessingOrder]) VALUES (3, 3, 1, 1)
INSERT [dataflow].[datamap_agent] ([ID], [DataMapID], [AgentID], [ProcessingOrder]) VALUES (4, 4, 1, 2)
INSERT [dataflow].[datamap_agent] ([ID], [DataMapID], [AgentID], [ProcessingOrder]) VALUES (5, 5, 1, 4)
INSERT [dataflow].[datamap_agent] ([ID], [DataMapID], [AgentID], [ProcessingOrder]) VALUES (6, 6, 1, 5)
INSERT [dataflow].[datamap_agent] ([ID], [DataMapID], [AgentID], [ProcessingOrder]) VALUES (7, 8, 1, 3)
SET IDENTITY_INSERT [dataflow].[datamap_agent] OFF
GO