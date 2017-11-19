DECLARE @EducationOrganizationId INT = 101101001
DECLARE @StateOrganizationId INT = 255901
DECLARE @EducationOrganizationIdentificationSystemDescriptorId INT = 461 --School
DECLARE @MaxGradeLevelDescriptorId INT = 21
DECLARE @CurrentGradeLevelDescriptorId INT = 1
DECLARE @MailingAddressTypeId INT = 5
DECLARE @StateAbbreviationType_AA INT = 1 --AA
DECLARE @PostalCode nvarchar(17) = '11111'

INSERT INTO [edfi].[EducationOrganization]
           ([EducationOrganizationId]
           ,[StateOrganizationId]
           ,[NameOfInstitution]
           ,[ShortNameOfInstitution]
           ,[WebSite]
           ,[OperationalStatusTypeId]
           ,[Id]
           ,[LastModifiedDate]
           ,[CreateDate])
     VALUES
           (@EducationOrganizationId
           ,@StateOrganizationId
           ,'Winterfell Elementary'
           ,NULL
           ,NULL
           ,NULL
           ,NEWID()
           ,GETUTCDATE()
           ,GETUTCDATE()
		   )

INSERT INTO [edfi].[EducationOrganizationIdentificationCode]
           ([EducationOrganizationId]
           ,[IdentificationCode]
           ,[CreateDate]
           ,[EducationOrganizationIdentificationSystemDescriptorId])
     VALUES
           (@EducationOrganizationId
           ,@EducationOrganizationId
           ,GETUTCDATE()
           ,@EducationOrganizationIdentificationSystemDescriptorId)

INSERT INTO [edfi].[EducationOrganizationAddress]
           ([EducationOrganizationId]
           ,[AddressTypeId]
           ,[StreetNumberName]
           ,[ApartmentRoomSuiteNumber]
           ,[BuildingSiteNumber]
           ,[City]
           ,[StateAbbreviationTypeId]
           ,[PostalCode]
           ,[NameOfCounty]
           ,[CountyFIPSCode]
           ,[Latitude]
           ,[Longitude]
           ,[BeginDate]
           ,[EndDate]
           ,[CreateDate])
     VALUES
           (@EducationOrganizationId
           ,@MailingAddressTypeId
           ,'N/A'
           ,'N/A'
           ,NULL
           ,'N/A'
           ,@StateAbbreviationType_AA
           ,@PostalCode
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,GETUTCDATE()
		   )


INSERT INTO [edfi].[School]
           ([SchoolId]
           ,[LocalEducationAgencyId]
           ,[SchoolTypeId]
           ,[CharterStatusTypeId]
           ,[TitleIPartASchoolDesignationTypeId]
           ,[MagnetSpecialProgramEmphasisSchoolTypeId]
           ,[AdministrativeFundingControlDescriptorId]
           ,[InternetAccessTypeId]
           ,[CharterApprovalAgencyTypeId]
           ,[CharterApprovalSchoolYear])
     VALUES
           (@EducationOrganizationId
           ,@StateOrganizationId
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
		   )

WHILE (@CurrentGradeLevelDescriptorId <= @MaxGradeLevelDescriptorId)
BEGIN
	INSERT INTO [edfi].[SchoolGradeLevel]
			   ([SchoolId]
			   ,[GradeLevelDescriptorId]
			   ,[CreateDate])
		 VALUES
			   (@EducationOrganizationId
			   ,@CurrentGradeLevelDescriptorId
			   ,GETUTCDATE())
	SET @CurrentGradeLevelDescriptorId = @CurrentGradeLevelDescriptorId + 1
END

SET @EducationOrganizationId = 101101002
SET @StateOrganizationId = 255901
INSERT INTO [edfi].[EducationOrganization]
           ([EducationOrganizationId]
           ,[StateOrganizationId]
           ,[NameOfInstitution]
           ,[ShortNameOfInstitution]
           ,[WebSite]
           ,[OperationalStatusTypeId]
           ,[Id]
           ,[LastModifiedDate]
           ,[CreateDate])
     VALUES
           (@EducationOrganizationId
           ,@StateOrganizationId
           ,'Winterfell Middle'
           ,NULL
           ,NULL
           ,NULL
           ,NEWID()
           ,GETUTCDATE()
           ,GETUTCDATE()
		   )

INSERT INTO [edfi].[EducationOrganizationIdentificationCode]
           ([EducationOrganizationId]
           ,[IdentificationCode]
           ,[CreateDate]
           ,[EducationOrganizationIdentificationSystemDescriptorId])
     VALUES
           (@EducationOrganizationId
           ,@EducationOrganizationId
           ,GETUTCDATE()
           ,@EducationOrganizationIdentificationSystemDescriptorId)


INSERT INTO [edfi].[EducationOrganizationAddress]
           ([EducationOrganizationId]
           ,[AddressTypeId]
           ,[StreetNumberName]
           ,[ApartmentRoomSuiteNumber]
           ,[BuildingSiteNumber]
           ,[City]
           ,[StateAbbreviationTypeId]
           ,[PostalCode]
           ,[NameOfCounty]
           ,[CountyFIPSCode]
           ,[Latitude]
           ,[Longitude]
           ,[BeginDate]
           ,[EndDate]
           ,[CreateDate])
     VALUES
           (@EducationOrganizationId
           ,@MailingAddressTypeId
           ,'N/A'
           ,'N/A'
           ,NULL
           ,'N/A'
           ,@StateAbbreviationType_AA
           ,@PostalCode
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,GETUTCDATE()
		   )

INSERT INTO [edfi].[School]
           ([SchoolId]
           ,[LocalEducationAgencyId]
           ,[SchoolTypeId]
           ,[CharterStatusTypeId]
           ,[TitleIPartASchoolDesignationTypeId]
           ,[MagnetSpecialProgramEmphasisSchoolTypeId]
           ,[AdministrativeFundingControlDescriptorId]
           ,[InternetAccessTypeId]
           ,[CharterApprovalAgencyTypeId]
           ,[CharterApprovalSchoolYear])
     VALUES
           (@EducationOrganizationId
           ,@StateOrganizationId
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
		   )

SET @CurrentGradeLevelDescriptorId = 1
WHILE (@CurrentGradeLevelDescriptorId <= @MaxGradeLevelDescriptorId)
BEGIN
	INSERT INTO [edfi].[SchoolGradeLevel]
			   ([SchoolId]
			   ,[GradeLevelDescriptorId]
			   ,[CreateDate])
		 VALUES
			   (@EducationOrganizationId
			   ,@CurrentGradeLevelDescriptorId
			   ,GETUTCDATE())
	SET @CurrentGradeLevelDescriptorId = @CurrentGradeLevelDescriptorId + 1
END
GO


