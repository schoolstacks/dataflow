/*    ==Scripting Parameters==

    Source Database Engine Edition : Microsoft Azure SQL Database Edition
    Source Database Engine Type : Microsoft Azure SQL Database

    Target Database Engine Edition : Microsoft Azure SQL Database Edition
    Target Database Engine Type : Microsoft Azure SQL Database
*/
SET IDENTITY_INSERT [dataflow].[file] ON 

INSERT [dataflow].[file] ([ID], [Filename], [URL], [AgentID], [Status], [Message], [Rows], [CreateDate], [UpdateDate]) VALUES (4, N'/home/user01/data/assessments/mcl-progress-monitoring.csv', N'https://dataflow.file.core.windows.net/sample-files/2ea59c8b-b65c-4859-a5bc-1be86cb58b63/mcl-progress-monitoring.csv', 1, N'UPLOADED', NULL, 667, CAST(N'2017-10-13T01:11:14.757' AS DateTime), NULL)
SET IDENTITY_INSERT [dataflow].[file] OFF
GO