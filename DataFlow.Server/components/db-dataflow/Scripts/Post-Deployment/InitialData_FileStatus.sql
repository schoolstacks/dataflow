/*    ==Scripting Parameters==

    Source Database Engine Edition : Microsoft Azure SQL Database Edition
    Source Database Engine Type : Microsoft Azure SQL Database

    Target Database Engine Edition : Microsoft Azure SQL Database Edition
    Target Database Engine Type : Microsoft Azure SQL Database
*/
INSERT [dataflow].[file_status] ([Value]) VALUES (N'ERROR_LOAD')
INSERT [dataflow].[file_status] ([Value]) VALUES (N'ERROR_TRANSFORM')
INSERT [dataflow].[file_status] ([Value]) VALUES (N'ERROR_UPLOAD')
INSERT [dataflow].[file_status] ([Value]) VALUES (N'LOADED')
INSERT [dataflow].[file_status] ([Value]) VALUES (N'TRANSFORMED')
INSERT [dataflow].[file_status] ([Value]) VALUES (N'UPLOADED')
GO