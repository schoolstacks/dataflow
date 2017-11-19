DECLARE @AssessmentTitle NVARCHAR(60) = 'mCLASS:DIBELS'
DECLARE @GradeLevelDescriptorId_KinderGarten INT = 12
DECLARE @AssessmentCategoryDescriptorId_BenchmarkTest INT = 93
DECLARE @AcademicSubjectDescriptorId_Reading INT = 29
DECLARE @AssessmentNamespace NVARCHAR(255) = 'http://ed-fi.org/Assessment/Assessment.xml'
DECLARE @AssessmentIdentificationSystemDescriptorId_TestContractor INT = 112
INSERT INTO [edfi].[Assessment]
           ([AssessmentTitle]
           ,[AssessedGradeLevelDescriptorId]
           ,[AssessmentCategoryDescriptorId]
           ,[AcademicSubjectDescriptorId]
           ,[LowestAssessedGradeLevelDescriptorId]
           ,[AssessmentForm]
           ,[Version]
           ,[RevisionDate]
           ,[MaxRawScore]
           ,[Nomenclature]
           ,[AssessmentPeriodDescriptorId]
           ,[AssessmentFamilyTitle]
           ,[Namespace]
           ,[Id]
           ,[LastModifiedDate]
           ,[CreateDate])
     VALUES
           (@AssessmentTitle
           ,@GradeLevelDescriptorId_KinderGarten
           ,@AssessmentCategoryDescriptorId_BenchmarkTest
           ,@AcademicSubjectDescriptorId_Reading
           ,NULL
           ,NULL
           ,1
           ,GETUTCDATE()
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,@AssessmentNamespace
           ,NEWID()
           ,GETUTCDATE()
           ,GETUTCDATE())


INSERT INTO [edfi].[AssessmentIdentificationCode]
           ([AssessmentTitle]
           ,[AcademicSubjectDescriptorId]
           ,[AssessedGradeLevelDescriptorId]
           ,[Version]
           ,[AssessmentIdentificationSystemDescriptorId]
           ,[AssigningOrganizationIdentificationCode]
           ,[IdentificationCode]
           ,[CreateDate])
     VALUES
           (
            @AssessmentTitle
		   ,@AcademicSubjectDescriptorId_Reading
           ,@GradeLevelDescriptorId_KinderGarten
           ,1
           ,@AssessmentIdentificationSystemDescriptorId_TestContractor
           ,NULL
           ,NEWID()
           ,GETUTCDATE())
GO



GO


