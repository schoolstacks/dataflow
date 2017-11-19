/*    ==Scripting Parameters==

    Source Database Engine Edition : Microsoft Azure SQL Database Edition
    Source Database Engine Type : Microsoft Azure SQL Database

    Target Database Engine Edition : Microsoft Azure SQL Database Edition
    Target Database Engine Type : Microsoft Azure SQL Database
*/
SET IDENTITY_INSERT [dataflow].[lookup] ON 

INSERT [dataflow].[lookup] ([ID], [GroupSet], [Key], [Value]) VALUES (19, N'mclass-progress-gender', N'M', N'Male')
INSERT [dataflow].[lookup] ([ID], [GroupSet], [Key], [Value]) VALUES (20, N'mclass-progress-hispanic', N'N/A', N'N/A')
INSERT [dataflow].[lookup] ([ID], [GroupSet], [Key], [Value]) VALUES (21, N'mclass-progress-schools', N'Winterfell Elementary', N'101101001')
INSERT [dataflow].[lookup] ([ID], [GroupSet], [Key], [Value]) VALUES (22, N'mclass-progress-grades', N'K', N'Twelfth grade')
INSERT [dataflow].[lookup] ([ID], [GroupSet], [Key], [Value]) VALUES (24, N'mclass-progress-grade', N'K', N'Twelfth grade')
SET IDENTITY_INSERT [dataflow].[lookup] OFF
GO