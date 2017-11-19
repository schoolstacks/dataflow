/*    ==Scripting Parameters==

    Source Database Engine Edition : Microsoft Azure SQL Database Edition
    Source Database Engine Type : Microsoft Azure SQL Database

    Target Database Engine Edition : Microsoft Azure SQL Database Edition
    Target Database Engine Type : Microsoft Azure SQL Database
*/
SET IDENTITY_INSERT [dataflow].[agent] ON 

INSERT [dataflow].[agent] ([ID], [Name], [AgentTypeCode], [URL], [Username], [Password], [Directory], [FilePattern], [Queue], [Custom], [Enabled], [Created], [LastExecuted]) VALUES (1, N'M:Class Progress Report', N'SFTP', N'az-e2-dataflow-dev-lz01.eastus2.cloudapp.azure.com', N'user01', N'GetFilesNow2000!', N'/home/user01/data/assessments', N'mcl*.csv', N'2ea59c8b-b65c-4859-a5bc-1be86cb58b63', N'', 1, CAST(N'2017-10-12T23:35:32.173' AS DateTime), CAST(N'2017-10-13T01:11:15.370' AS DateTime))
SET IDENTITY_INSERT [dataflow].[agent] OFF
GO