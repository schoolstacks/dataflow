using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.OdsApi.Sdk;
using EdFi.OdsApi.Models.EnrollmentComposite;
using RestSharp;
  
namespace EdFi.OdsApi.Api.EnrollmentComposite 
{
    public class EnrollmentApi 
    {
        private readonly IRestClient client;

        public EnrollmentApi(IRestClient client)
        {
            this.client = client;
        }
      
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<LocalEducationAgency>> GetLocalEducationAgenciesAll(int? offset= null, int? limit= null, string fields= null) 
        {
            var request = new RestRequest("/enrollment/localEducationAgencies", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            var response = client.Execute<List<LocalEducationAgency>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get By Example&quot; pattern. The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="localEducationAgencyId">The identifier assigned to a local education agency by the State Education Agency (SEA).</param>
        /// <param name="educationServiceCenterId">EducationServiceCenter Identity Column</param>
        /// <param name="parentLocalEducationAgencyId">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="stateEducationAgencyId">StateEducationAgency Identity Column</param>
        /// <param name="operationalStatusType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="stateOrganizationId">The identifier assigned to an education agency by the State Education Agency (SEA).  Also known as the State LEP ID.  NEDM: IdentificationCode, LEA Identifier (State)</param>
        /// <param name="nameOfInstitution">The full, legally accepted name of the institution.  NEDM: Name of Institution</param>
        /// <param name="shortNameOfInstitution">A short name for the institution.</param>
        /// <param name="webSite">The public web site address (URL) for the educational organization.</param>
        /// <param name="id"></param>
        /// <param name="charterStatusType">Key for CharterStatus</param>
        /// <param name="localEducationAgencyCategoryType">Key for LEACategory</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<LocalEducationAgency>> GetLocalEducationAgenciesByExample(int? offset= null, int? limit= null, string fields= null, string q= null, int? localEducationAgencyId= null, int? educationServiceCenterId= null, int? parentLocalEducationAgencyId= null, int? stateEducationAgencyId= null, string operationalStatusType= null, string stateOrganizationId= null, string nameOfInstitution= null, string shortNameOfInstitution= null, string webSite= null, string id= null, string charterStatusType= null, string localEducationAgencyCategoryType= null) 
        {
            var request = new RestRequest("/enrollment/localEducationAgencies", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (localEducationAgencyId != null)
                request.AddParameter("localEducationAgencyId", localEducationAgencyId);
            if (educationServiceCenterId != null)
                request.AddParameter("educationServiceCenterId", educationServiceCenterId);
            if (parentLocalEducationAgencyId != null)
                request.AddParameter("parentLocalEducationAgencyId", parentLocalEducationAgencyId);
            if (stateEducationAgencyId != null)
                request.AddParameter("stateEducationAgencyId", stateEducationAgencyId);
            if (operationalStatusType != null)
                request.AddParameter("operationalStatusType", operationalStatusType);
            if (stateOrganizationId != null)
                request.AddParameter("stateOrganizationId", stateOrganizationId);
            if (nameOfInstitution != null)
                request.AddParameter("nameOfInstitution", nameOfInstitution);
            if (shortNameOfInstitution != null)
                request.AddParameter("shortNameOfInstitution", shortNameOfInstitution);
            if (webSite != null)
                request.AddParameter("webSite", webSite);
            if (id != null)
                request.AddParameter("id", id);
            if (charterStatusType != null)
                request.AddParameter("charterStatusType", charterStatusType);
            if (localEducationAgencyCategoryType != null)
                request.AddParameter("localEducationAgencyCategoryType", localEducationAgencyCategoryType);
            var response = client.Execute<List<LocalEducationAgency>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get By Key&quot; pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="localEducationAgencyId">The identifier assigned to a local education agency by the State Education Agency (SEA).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<LocalEducationAgency> GetLocalEducationAgenciesByKey(int? localEducationAgencyId= null, string fields= null, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/enrollment/localEducationAgencies", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (localEducationAgencyId != null)
                request.AddParameter("localEducationAgencyId", localEducationAgencyId);
            if (fields != null)
                request.AddParameter("fields", fields);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<LocalEducationAgency>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Id&quot; pattern). This GET operation provides access to resources using the &quot;Get By Id&quot; pattern.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<LocalEducationAgency> GetLocalEducationAgenciesById(string id, string fields= null, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/enrollment/localEducationAgencies/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (fields != null)
                request.AddParameter("fields", fields);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<LocalEducationAgency>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<School>> GetSchoolsAll(int? offset= null, int? limit= null, string fields= null) 
        {
            var request = new RestRequest("/enrollment/schools", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            var response = client.Execute<List<School>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get By Example&quot; pattern. The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="schoolId">The identifier assigned to a school by the State Education Agency (SEA).</param>
        /// <param name="localEducationAgencyId">EducationOrganization Identity Column</param>
        /// <param name="charterApprovalSchoolYear">Key for School</param>
        /// <param name="operationalStatusType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="stateOrganizationId">The identifier assigned to an education agency by the State Education Agency (SEA).  Also known as the State LEP ID.  NEDM: IdentificationCode, LEA Identifier (State)</param>
        /// <param name="nameOfInstitution">The full, legally accepted name of the institution.  NEDM: Name of Institution</param>
        /// <param name="shortNameOfInstitution">A short name for the institution.</param>
        /// <param name="webSite">The public web site address (URL) for the educational organization.</param>
        /// <param name="id"></param>
        /// <param name="administrativeFundingControlDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="charterApprovalAgencyType">Key for MagnetSpecialProgramEmphasisSchool</param>
        /// <param name="charterStatusType">A school or agency providing free public elementary or secondary education to eligible students under a specific charter granted by the state legislature or other appropriate authority and designated by such authority to be a charter school.</param>
        /// <param name="internetAccessType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="magnetSpecialProgramEmphasisSchoolType">A school that has been designed: 1) to attract students of different racial/ethnic backgrounds for the purpose of reducing, preventing, or eliminating racial isolation; and/or 2)to provide an academic or social focus on a particular theme (e.g., science/math, performing arts, gifted/talented, or foreign language).</param>
        /// <param name="schoolType">The instructional categorization of the school (e.g., Regular, Alternative)</param>
        /// <param name="titleIPartASchoolDesignationType">Denotes the Title I Part A designation for the school.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<School>> GetSchoolsByExample(int? offset= null, int? limit= null, string fields= null, string q= null, int? schoolId= null, int? localEducationAgencyId= null, int? charterApprovalSchoolYear= null, string operationalStatusType= null, string stateOrganizationId= null, string nameOfInstitution= null, string shortNameOfInstitution= null, string webSite= null, string id= null, string administrativeFundingControlDescriptor= null, string charterApprovalAgencyType= null, string charterStatusType= null, string internetAccessType= null, string magnetSpecialProgramEmphasisSchoolType= null, string schoolType= null, string titleIPartASchoolDesignationType= null) 
        {
            var request = new RestRequest("/enrollment/schools", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (localEducationAgencyId != null)
                request.AddParameter("localEducationAgencyId", localEducationAgencyId);
            if (charterApprovalSchoolYear != null)
                request.AddParameter("charterApprovalSchoolYear", charterApprovalSchoolYear);
            if (operationalStatusType != null)
                request.AddParameter("operationalStatusType", operationalStatusType);
            if (stateOrganizationId != null)
                request.AddParameter("stateOrganizationId", stateOrganizationId);
            if (nameOfInstitution != null)
                request.AddParameter("nameOfInstitution", nameOfInstitution);
            if (shortNameOfInstitution != null)
                request.AddParameter("shortNameOfInstitution", shortNameOfInstitution);
            if (webSite != null)
                request.AddParameter("webSite", webSite);
            if (id != null)
                request.AddParameter("id", id);
            if (administrativeFundingControlDescriptor != null)
                request.AddParameter("administrativeFundingControlDescriptor", administrativeFundingControlDescriptor);
            if (charterApprovalAgencyType != null)
                request.AddParameter("charterApprovalAgencyType", charterApprovalAgencyType);
            if (charterStatusType != null)
                request.AddParameter("charterStatusType", charterStatusType);
            if (internetAccessType != null)
                request.AddParameter("internetAccessType", internetAccessType);
            if (magnetSpecialProgramEmphasisSchoolType != null)
                request.AddParameter("magnetSpecialProgramEmphasisSchoolType", magnetSpecialProgramEmphasisSchoolType);
            if (schoolType != null)
                request.AddParameter("schoolType", schoolType);
            if (titleIPartASchoolDesignationType != null)
                request.AddParameter("titleIPartASchoolDesignationType", titleIPartASchoolDesignationType);
            var response = client.Execute<List<School>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get By Key&quot; pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="schoolId">The identifier assigned to a school by the State Education Agency (SEA).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<School> GetSchoolsByKey(int? schoolId= null, string fields= null, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/enrollment/schools", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (fields != null)
                request.AddParameter("fields", fields);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<School>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Id&quot; pattern). This GET operation provides access to resources using the &quot;Get By Id&quot; pattern.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<School> GetSchoolsById(string id, string fields= null, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/enrollment/schools/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (fields != null)
                request.AddParameter("fields", fields);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<School>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated LocalEducationAgency resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="localEducationAgency_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="schoolId">The identifier assigned to a school by the State Education Agency (SEA).</param>
        /// <param name="localEducationAgencyId">EducationOrganization Identity Column</param>
        /// <param name="charterApprovalSchoolYear">Key for School</param>
        /// <param name="operationalStatusType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="stateOrganizationId">The identifier assigned to an education agency by the State Education Agency (SEA).  Also known as the State LEP ID.  NEDM: IdentificationCode, LEA Identifier (State)</param>
        /// <param name="nameOfInstitution">The full, legally accepted name of the institution.  NEDM: Name of Institution</param>
        /// <param name="shortNameOfInstitution">A short name for the institution.</param>
        /// <param name="webSite">The public web site address (URL) for the educational organization.</param>
        /// <param name="id"></param>
        /// <param name="administrativeFundingControlDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="charterApprovalAgencyType">Key for MagnetSpecialProgramEmphasisSchool</param>
        /// <param name="charterStatusType">A school or agency providing free public elementary or secondary education to eligible students under a specific charter granted by the state legislature or other appropriate authority and designated by such authority to be a charter school.</param>
        /// <param name="internetAccessType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="magnetSpecialProgramEmphasisSchoolType">A school that has been designed: 1) to attract students of different racial/ethnic backgrounds for the purpose of reducing, preventing, or eliminating racial isolation; and/or 2)to provide an academic or social focus on a particular theme (e.g., science/math, performing arts, gifted/talented, or foreign language).</param>
        /// <param name="schoolType">The instructional categorization of the school (e.g., Regular, Alternative)</param>
        /// <param name="titleIPartASchoolDesignationType">Denotes the Title I Part A designation for the school.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<School>> GetSchoolsByLocalEducationAgency(string localEducationAgency_id, int? offset= null, int? limit= null, string fields= null, string q= null, int? schoolId= null, int? localEducationAgencyId= null, int? charterApprovalSchoolYear= null, string operationalStatusType= null, string stateOrganizationId= null, string nameOfInstitution= null, string shortNameOfInstitution= null, string webSite= null, string id= null, string administrativeFundingControlDescriptor= null, string charterApprovalAgencyType= null, string charterStatusType= null, string internetAccessType= null, string magnetSpecialProgramEmphasisSchoolType= null, string schoolType= null, string titleIPartASchoolDesignationType= null) 
        {
            var request = new RestRequest("/enrollment/localEducationAgencies/{localEducationAgency_id}/schools", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("localEducationAgency_id", localEducationAgency_id);
            // verify required params are set
            if (localEducationAgency_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (localEducationAgencyId != null)
                request.AddParameter("localEducationAgencyId", localEducationAgencyId);
            if (charterApprovalSchoolYear != null)
                request.AddParameter("charterApprovalSchoolYear", charterApprovalSchoolYear);
            if (operationalStatusType != null)
                request.AddParameter("operationalStatusType", operationalStatusType);
            if (stateOrganizationId != null)
                request.AddParameter("stateOrganizationId", stateOrganizationId);
            if (nameOfInstitution != null)
                request.AddParameter("nameOfInstitution", nameOfInstitution);
            if (shortNameOfInstitution != null)
                request.AddParameter("shortNameOfInstitution", shortNameOfInstitution);
            if (webSite != null)
                request.AddParameter("webSite", webSite);
            if (id != null)
                request.AddParameter("id", id);
            if (administrativeFundingControlDescriptor != null)
                request.AddParameter("administrativeFundingControlDescriptor", administrativeFundingControlDescriptor);
            if (charterApprovalAgencyType != null)
                request.AddParameter("charterApprovalAgencyType", charterApprovalAgencyType);
            if (charterStatusType != null)
                request.AddParameter("charterStatusType", charterStatusType);
            if (internetAccessType != null)
                request.AddParameter("internetAccessType", internetAccessType);
            if (magnetSpecialProgramEmphasisSchoolType != null)
                request.AddParameter("magnetSpecialProgramEmphasisSchoolType", magnetSpecialProgramEmphasisSchoolType);
            if (schoolType != null)
                request.AddParameter("schoolType", schoolType);
            if (titleIPartASchoolDesignationType != null)
                request.AddParameter("titleIPartASchoolDesignationType", titleIPartASchoolDesignationType);
            var response = client.Execute<List<School>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated Section resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="section_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="schoolId">The identifier assigned to a school by the State Education Agency (SEA).</param>
        /// <param name="localEducationAgencyId">EducationOrganization Identity Column</param>
        /// <param name="charterApprovalSchoolYear">Key for School</param>
        /// <param name="operationalStatusType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="stateOrganizationId">The identifier assigned to an education agency by the State Education Agency (SEA).  Also known as the State LEP ID.  NEDM: IdentificationCode, LEA Identifier (State)</param>
        /// <param name="nameOfInstitution">The full, legally accepted name of the institution.  NEDM: Name of Institution</param>
        /// <param name="shortNameOfInstitution">A short name for the institution.</param>
        /// <param name="webSite">The public web site address (URL) for the educational organization.</param>
        /// <param name="id"></param>
        /// <param name="administrativeFundingControlDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="charterApprovalAgencyType">Key for MagnetSpecialProgramEmphasisSchool</param>
        /// <param name="charterStatusType">A school or agency providing free public elementary or secondary education to eligible students under a specific charter granted by the state legislature or other appropriate authority and designated by such authority to be a charter school.</param>
        /// <param name="internetAccessType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="magnetSpecialProgramEmphasisSchoolType">A school that has been designed: 1) to attract students of different racial/ethnic backgrounds for the purpose of reducing, preventing, or eliminating racial isolation; and/or 2)to provide an academic or social focus on a particular theme (e.g., science/math, performing arts, gifted/talented, or foreign language).</param>
        /// <param name="schoolType">The instructional categorization of the school (e.g., Regular, Alternative)</param>
        /// <param name="titleIPartASchoolDesignationType">Denotes the Title I Part A designation for the school.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<School>> GetSchoolsBySection(string section_id, int? offset= null, int? limit= null, string fields= null, string q= null, int? schoolId= null, int? localEducationAgencyId= null, int? charterApprovalSchoolYear= null, string operationalStatusType= null, string stateOrganizationId= null, string nameOfInstitution= null, string shortNameOfInstitution= null, string webSite= null, string id= null, string administrativeFundingControlDescriptor= null, string charterApprovalAgencyType= null, string charterStatusType= null, string internetAccessType= null, string magnetSpecialProgramEmphasisSchoolType= null, string schoolType= null, string titleIPartASchoolDesignationType= null) 
        {
            var request = new RestRequest("/enrollment/sections/{section_id}/schools", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("section_id", section_id);
            // verify required params are set
            if (section_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (localEducationAgencyId != null)
                request.AddParameter("localEducationAgencyId", localEducationAgencyId);
            if (charterApprovalSchoolYear != null)
                request.AddParameter("charterApprovalSchoolYear", charterApprovalSchoolYear);
            if (operationalStatusType != null)
                request.AddParameter("operationalStatusType", operationalStatusType);
            if (stateOrganizationId != null)
                request.AddParameter("stateOrganizationId", stateOrganizationId);
            if (nameOfInstitution != null)
                request.AddParameter("nameOfInstitution", nameOfInstitution);
            if (shortNameOfInstitution != null)
                request.AddParameter("shortNameOfInstitution", shortNameOfInstitution);
            if (webSite != null)
                request.AddParameter("webSite", webSite);
            if (id != null)
                request.AddParameter("id", id);
            if (administrativeFundingControlDescriptor != null)
                request.AddParameter("administrativeFundingControlDescriptor", administrativeFundingControlDescriptor);
            if (charterApprovalAgencyType != null)
                request.AddParameter("charterApprovalAgencyType", charterApprovalAgencyType);
            if (charterStatusType != null)
                request.AddParameter("charterStatusType", charterStatusType);
            if (internetAccessType != null)
                request.AddParameter("internetAccessType", internetAccessType);
            if (magnetSpecialProgramEmphasisSchoolType != null)
                request.AddParameter("magnetSpecialProgramEmphasisSchoolType", magnetSpecialProgramEmphasisSchoolType);
            if (schoolType != null)
                request.AddParameter("schoolType", schoolType);
            if (titleIPartASchoolDesignationType != null)
                request.AddParameter("titleIPartASchoolDesignationType", titleIPartASchoolDesignationType);
            var response = client.Execute<List<School>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated Staff resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="staff_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="schoolId">The identifier assigned to a school by the State Education Agency (SEA).</param>
        /// <param name="localEducationAgencyId">EducationOrganization Identity Column</param>
        /// <param name="charterApprovalSchoolYear">Key for School</param>
        /// <param name="operationalStatusType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="stateOrganizationId">The identifier assigned to an education agency by the State Education Agency (SEA).  Also known as the State LEP ID.  NEDM: IdentificationCode, LEA Identifier (State)</param>
        /// <param name="nameOfInstitution">The full, legally accepted name of the institution.  NEDM: Name of Institution</param>
        /// <param name="shortNameOfInstitution">A short name for the institution.</param>
        /// <param name="webSite">The public web site address (URL) for the educational organization.</param>
        /// <param name="id"></param>
        /// <param name="administrativeFundingControlDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="charterApprovalAgencyType">Key for MagnetSpecialProgramEmphasisSchool</param>
        /// <param name="charterStatusType">A school or agency providing free public elementary or secondary education to eligible students under a specific charter granted by the state legislature or other appropriate authority and designated by such authority to be a charter school.</param>
        /// <param name="internetAccessType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="magnetSpecialProgramEmphasisSchoolType">A school that has been designed: 1) to attract students of different racial/ethnic backgrounds for the purpose of reducing, preventing, or eliminating racial isolation; and/or 2)to provide an academic or social focus on a particular theme (e.g., science/math, performing arts, gifted/talented, or foreign language).</param>
        /// <param name="schoolType">The instructional categorization of the school (e.g., Regular, Alternative)</param>
        /// <param name="titleIPartASchoolDesignationType">Denotes the Title I Part A designation for the school.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<School>> GetSchoolsByStaff(string staff_id, int? offset= null, int? limit= null, string fields= null, string q= null, int? schoolId= null, int? localEducationAgencyId= null, int? charterApprovalSchoolYear= null, string operationalStatusType= null, string stateOrganizationId= null, string nameOfInstitution= null, string shortNameOfInstitution= null, string webSite= null, string id= null, string administrativeFundingControlDescriptor= null, string charterApprovalAgencyType= null, string charterStatusType= null, string internetAccessType= null, string magnetSpecialProgramEmphasisSchoolType= null, string schoolType= null, string titleIPartASchoolDesignationType= null) 
        {
            var request = new RestRequest("/enrollment/staffs/{staff_id}/schools", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("staff_id", staff_id);
            // verify required params are set
            if (staff_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (localEducationAgencyId != null)
                request.AddParameter("localEducationAgencyId", localEducationAgencyId);
            if (charterApprovalSchoolYear != null)
                request.AddParameter("charterApprovalSchoolYear", charterApprovalSchoolYear);
            if (operationalStatusType != null)
                request.AddParameter("operationalStatusType", operationalStatusType);
            if (stateOrganizationId != null)
                request.AddParameter("stateOrganizationId", stateOrganizationId);
            if (nameOfInstitution != null)
                request.AddParameter("nameOfInstitution", nameOfInstitution);
            if (shortNameOfInstitution != null)
                request.AddParameter("shortNameOfInstitution", shortNameOfInstitution);
            if (webSite != null)
                request.AddParameter("webSite", webSite);
            if (id != null)
                request.AddParameter("id", id);
            if (administrativeFundingControlDescriptor != null)
                request.AddParameter("administrativeFundingControlDescriptor", administrativeFundingControlDescriptor);
            if (charterApprovalAgencyType != null)
                request.AddParameter("charterApprovalAgencyType", charterApprovalAgencyType);
            if (charterStatusType != null)
                request.AddParameter("charterStatusType", charterStatusType);
            if (internetAccessType != null)
                request.AddParameter("internetAccessType", internetAccessType);
            if (magnetSpecialProgramEmphasisSchoolType != null)
                request.AddParameter("magnetSpecialProgramEmphasisSchoolType", magnetSpecialProgramEmphasisSchoolType);
            if (schoolType != null)
                request.AddParameter("schoolType", schoolType);
            if (titleIPartASchoolDesignationType != null)
                request.AddParameter("titleIPartASchoolDesignationType", titleIPartASchoolDesignationType);
            var response = client.Execute<List<School>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated Student resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="student_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="schoolId">The identifier assigned to a school by the State Education Agency (SEA).</param>
        /// <param name="localEducationAgencyId">EducationOrganization Identity Column</param>
        /// <param name="charterApprovalSchoolYear">Key for School</param>
        /// <param name="operationalStatusType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="stateOrganizationId">The identifier assigned to an education agency by the State Education Agency (SEA).  Also known as the State LEP ID.  NEDM: IdentificationCode, LEA Identifier (State)</param>
        /// <param name="nameOfInstitution">The full, legally accepted name of the institution.  NEDM: Name of Institution</param>
        /// <param name="shortNameOfInstitution">A short name for the institution.</param>
        /// <param name="webSite">The public web site address (URL) for the educational organization.</param>
        /// <param name="id"></param>
        /// <param name="administrativeFundingControlDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="charterApprovalAgencyType">Key for MagnetSpecialProgramEmphasisSchool</param>
        /// <param name="charterStatusType">A school or agency providing free public elementary or secondary education to eligible students under a specific charter granted by the state legislature or other appropriate authority and designated by such authority to be a charter school.</param>
        /// <param name="internetAccessType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="magnetSpecialProgramEmphasisSchoolType">A school that has been designed: 1) to attract students of different racial/ethnic backgrounds for the purpose of reducing, preventing, or eliminating racial isolation; and/or 2)to provide an academic or social focus on a particular theme (e.g., science/math, performing arts, gifted/talented, or foreign language).</param>
        /// <param name="schoolType">The instructional categorization of the school (e.g., Regular, Alternative)</param>
        /// <param name="titleIPartASchoolDesignationType">Denotes the Title I Part A designation for the school.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<School>> GetSchoolsByStudent(string student_id, int? offset= null, int? limit= null, string fields= null, string q= null, int? schoolId= null, int? localEducationAgencyId= null, int? charterApprovalSchoolYear= null, string operationalStatusType= null, string stateOrganizationId= null, string nameOfInstitution= null, string shortNameOfInstitution= null, string webSite= null, string id= null, string administrativeFundingControlDescriptor= null, string charterApprovalAgencyType= null, string charterStatusType= null, string internetAccessType= null, string magnetSpecialProgramEmphasisSchoolType= null, string schoolType= null, string titleIPartASchoolDesignationType= null) 
        {
            var request = new RestRequest("/enrollment/students/{student_id}/schools", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("student_id", student_id);
            // verify required params are set
            if (student_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (localEducationAgencyId != null)
                request.AddParameter("localEducationAgencyId", localEducationAgencyId);
            if (charterApprovalSchoolYear != null)
                request.AddParameter("charterApprovalSchoolYear", charterApprovalSchoolYear);
            if (operationalStatusType != null)
                request.AddParameter("operationalStatusType", operationalStatusType);
            if (stateOrganizationId != null)
                request.AddParameter("stateOrganizationId", stateOrganizationId);
            if (nameOfInstitution != null)
                request.AddParameter("nameOfInstitution", nameOfInstitution);
            if (shortNameOfInstitution != null)
                request.AddParameter("shortNameOfInstitution", shortNameOfInstitution);
            if (webSite != null)
                request.AddParameter("webSite", webSite);
            if (id != null)
                request.AddParameter("id", id);
            if (administrativeFundingControlDescriptor != null)
                request.AddParameter("administrativeFundingControlDescriptor", administrativeFundingControlDescriptor);
            if (charterApprovalAgencyType != null)
                request.AddParameter("charterApprovalAgencyType", charterApprovalAgencyType);
            if (charterStatusType != null)
                request.AddParameter("charterStatusType", charterStatusType);
            if (internetAccessType != null)
                request.AddParameter("internetAccessType", internetAccessType);
            if (magnetSpecialProgramEmphasisSchoolType != null)
                request.AddParameter("magnetSpecialProgramEmphasisSchoolType", magnetSpecialProgramEmphasisSchoolType);
            if (schoolType != null)
                request.AddParameter("schoolType", schoolType);
            if (titleIPartASchoolDesignationType != null)
                request.AddParameter("titleIPartASchoolDesignationType", titleIPartASchoolDesignationType);
            var response = client.Execute<List<School>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Section>> GetSectionsAll(int? offset= null, int? limit= null, string fields= null) 
        {
            var request = new RestRequest("/enrollment/sections", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            var response = client.Execute<List<Section>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get By Example&quot; pattern. The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="uniqueSectionCode">A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned.</param>
        /// <param name="sequenceOfCourse">When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1.</param>
        /// <param name="schoolId">School Identity Column</param>
        /// <param name="classPeriodName">An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period</param>
        /// <param name="localCourseCode">The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.</param>
        /// <param name="schoolYear">The identifier for the school year.</param>
        /// <param name="termDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="classroomIdentificationCode">A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.</param>
        /// <param name="availableCreditType">The type of credits or units of value awarded for the completion of a course.</param>
        /// <param name="educationalEnvironmentType">The setting in which a child receives education and related services; for example:  Center-based instruction  Home-based instruction  Hospital class  Mainstream  Residential care and treatment facility  ....</param>
        /// <param name="instructionLanguageDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="mediumOfInstructionType">The media through which teachers provide instruction to students and students and teachers communicate about instructional matters; for example:  Technology-based instruction in classroom  Correspondence instruction  Face-to-face instruction  Virtual/On-line Distance learning  Center-based instruction  ...</param>
        /// <param name="populationServedType">The population for which the course was designed; for example:  Bilingual students  Remedial education students  Gifted and talented students  Career and Technical Education students  Special education students  ....</param>
        /// <param name="availableCreditConversion">Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.</param>
        /// <param name="availableCredits">Credits or units of value awarded for the completion of a course.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Section>> GetSectionsByExample(int? offset= null, int? limit= null, string fields= null, string q= null, string uniqueSectionCode= null, int? sequenceOfCourse= null, int? schoolId= null, string classPeriodName= null, string localCourseCode= null, int? schoolYear= null, string termDescriptor= null, string classroomIdentificationCode= null, string availableCreditType= null, string educationalEnvironmentType= null, string instructionLanguageDescriptor= null, string mediumOfInstructionType= null, string populationServedType= null, double? availableCreditConversion= null, double? availableCredits= null, string id= null) 
        {
            var request = new RestRequest("/enrollment/sections", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (uniqueSectionCode != null)
                request.AddParameter("uniqueSectionCode", uniqueSectionCode);
            if (sequenceOfCourse != null)
                request.AddParameter("sequenceOfCourse", sequenceOfCourse);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (classPeriodName != null)
                request.AddParameter("classPeriodName", classPeriodName);
            if (localCourseCode != null)
                request.AddParameter("localCourseCode", localCourseCode);
            if (schoolYear != null)
                request.AddParameter("schoolYear", schoolYear);
            if (termDescriptor != null)
                request.AddParameter("termDescriptor", termDescriptor);
            if (classroomIdentificationCode != null)
                request.AddParameter("classroomIdentificationCode", classroomIdentificationCode);
            if (availableCreditType != null)
                request.AddParameter("availableCreditType", availableCreditType);
            if (educationalEnvironmentType != null)
                request.AddParameter("educationalEnvironmentType", educationalEnvironmentType);
            if (instructionLanguageDescriptor != null)
                request.AddParameter("instructionLanguageDescriptor", instructionLanguageDescriptor);
            if (mediumOfInstructionType != null)
                request.AddParameter("mediumOfInstructionType", mediumOfInstructionType);
            if (populationServedType != null)
                request.AddParameter("populationServedType", populationServedType);
            if (availableCreditConversion != null)
                request.AddParameter("availableCreditConversion", availableCreditConversion);
            if (availableCredits != null)
                request.AddParameter("availableCredits", availableCredits);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Section>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get By Key&quot; pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="uniqueSectionCode">A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned.</param>
        /// <param name="sequenceOfCourse">When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1.</param>
        /// <param name="schoolId">School Identity Column</param>
        /// <param name="classPeriodName">An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period</param>
        /// <param name="localCourseCode">The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.</param>
        /// <param name="schoolYear">The identifier for the school year.</param>
        /// <param name="termDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="classroomIdentificationCode">A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<Section> GetSectionsByKey(string uniqueSectionCode= null, int? sequenceOfCourse= null, int? schoolId= null, string classPeriodName= null, string localCourseCode= null, int? schoolYear= null, string termDescriptor= null, string classroomIdentificationCode= null, string fields= null, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/enrollment/sections", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (uniqueSectionCode != null)
                request.AddParameter("uniqueSectionCode", uniqueSectionCode);
            if (sequenceOfCourse != null)
                request.AddParameter("sequenceOfCourse", sequenceOfCourse);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (classPeriodName != null)
                request.AddParameter("classPeriodName", classPeriodName);
            if (localCourseCode != null)
                request.AddParameter("localCourseCode", localCourseCode);
            if (schoolYear != null)
                request.AddParameter("schoolYear", schoolYear);
            if (termDescriptor != null)
                request.AddParameter("termDescriptor", termDescriptor);
            if (classroomIdentificationCode != null)
                request.AddParameter("classroomIdentificationCode", classroomIdentificationCode);
            if (fields != null)
                request.AddParameter("fields", fields);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<Section>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Id&quot; pattern). This GET operation provides access to resources using the &quot;Get By Id&quot; pattern.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<Section> GetSectionsById(string id, string fields= null, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/enrollment/sections/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (fields != null)
                request.AddParameter("fields", fields);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<Section>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated LocalEducationAgency resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="localEducationAgency_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="uniqueSectionCode">A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned.</param>
        /// <param name="sequenceOfCourse">When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1.</param>
        /// <param name="schoolId">School Identity Column</param>
        /// <param name="classPeriodName">An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period</param>
        /// <param name="localCourseCode">The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.</param>
        /// <param name="schoolYear">The identifier for the school year.</param>
        /// <param name="termDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="classroomIdentificationCode">A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.</param>
        /// <param name="availableCreditType">The type of credits or units of value awarded for the completion of a course.</param>
        /// <param name="educationalEnvironmentType">The setting in which a child receives education and related services; for example:  Center-based instruction  Home-based instruction  Hospital class  Mainstream  Residential care and treatment facility  ....</param>
        /// <param name="instructionLanguageDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="mediumOfInstructionType">The media through which teachers provide instruction to students and students and teachers communicate about instructional matters; for example:  Technology-based instruction in classroom  Correspondence instruction  Face-to-face instruction  Virtual/On-line Distance learning  Center-based instruction  ...</param>
        /// <param name="populationServedType">The population for which the course was designed; for example:  Bilingual students  Remedial education students  Gifted and talented students  Career and Technical Education students  Special education students  ....</param>
        /// <param name="availableCreditConversion">Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.</param>
        /// <param name="availableCredits">Credits or units of value awarded for the completion of a course.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Section>> GetSectionsByLocalEducationAgency(string localEducationAgency_id, int? offset= null, int? limit= null, string fields= null, string q= null, string uniqueSectionCode= null, int? sequenceOfCourse= null, int? schoolId= null, string classPeriodName= null, string localCourseCode= null, int? schoolYear= null, string termDescriptor= null, string classroomIdentificationCode= null, string availableCreditType= null, string educationalEnvironmentType= null, string instructionLanguageDescriptor= null, string mediumOfInstructionType= null, string populationServedType= null, double? availableCreditConversion= null, double? availableCredits= null, string id= null) 
        {
            var request = new RestRequest("/enrollment/localEducationAgencies/{localEducationAgency_id}/sections", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("localEducationAgency_id", localEducationAgency_id);
            // verify required params are set
            if (localEducationAgency_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (uniqueSectionCode != null)
                request.AddParameter("uniqueSectionCode", uniqueSectionCode);
            if (sequenceOfCourse != null)
                request.AddParameter("sequenceOfCourse", sequenceOfCourse);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (classPeriodName != null)
                request.AddParameter("classPeriodName", classPeriodName);
            if (localCourseCode != null)
                request.AddParameter("localCourseCode", localCourseCode);
            if (schoolYear != null)
                request.AddParameter("schoolYear", schoolYear);
            if (termDescriptor != null)
                request.AddParameter("termDescriptor", termDescriptor);
            if (classroomIdentificationCode != null)
                request.AddParameter("classroomIdentificationCode", classroomIdentificationCode);
            if (availableCreditType != null)
                request.AddParameter("availableCreditType", availableCreditType);
            if (educationalEnvironmentType != null)
                request.AddParameter("educationalEnvironmentType", educationalEnvironmentType);
            if (instructionLanguageDescriptor != null)
                request.AddParameter("instructionLanguageDescriptor", instructionLanguageDescriptor);
            if (mediumOfInstructionType != null)
                request.AddParameter("mediumOfInstructionType", mediumOfInstructionType);
            if (populationServedType != null)
                request.AddParameter("populationServedType", populationServedType);
            if (availableCreditConversion != null)
                request.AddParameter("availableCreditConversion", availableCreditConversion);
            if (availableCredits != null)
                request.AddParameter("availableCredits", availableCredits);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Section>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated School resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="school_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="uniqueSectionCode">A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned.</param>
        /// <param name="sequenceOfCourse">When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1.</param>
        /// <param name="schoolId">School Identity Column</param>
        /// <param name="classPeriodName">An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period</param>
        /// <param name="localCourseCode">The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.</param>
        /// <param name="schoolYear">The identifier for the school year.</param>
        /// <param name="termDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="classroomIdentificationCode">A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.</param>
        /// <param name="availableCreditType">The type of credits or units of value awarded for the completion of a course.</param>
        /// <param name="educationalEnvironmentType">The setting in which a child receives education and related services; for example:  Center-based instruction  Home-based instruction  Hospital class  Mainstream  Residential care and treatment facility  ....</param>
        /// <param name="instructionLanguageDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="mediumOfInstructionType">The media through which teachers provide instruction to students and students and teachers communicate about instructional matters; for example:  Technology-based instruction in classroom  Correspondence instruction  Face-to-face instruction  Virtual/On-line Distance learning  Center-based instruction  ...</param>
        /// <param name="populationServedType">The population for which the course was designed; for example:  Bilingual students  Remedial education students  Gifted and talented students  Career and Technical Education students  Special education students  ....</param>
        /// <param name="availableCreditConversion">Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.</param>
        /// <param name="availableCredits">Credits or units of value awarded for the completion of a course.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Section>> GetSectionsBySchool(string school_id, int? offset= null, int? limit= null, string fields= null, string q= null, string uniqueSectionCode= null, int? sequenceOfCourse= null, int? schoolId= null, string classPeriodName= null, string localCourseCode= null, int? schoolYear= null, string termDescriptor= null, string classroomIdentificationCode= null, string availableCreditType= null, string educationalEnvironmentType= null, string instructionLanguageDescriptor= null, string mediumOfInstructionType= null, string populationServedType= null, double? availableCreditConversion= null, double? availableCredits= null, string id= null) 
        {
            var request = new RestRequest("/enrollment/schools/{school_id}/sections", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("school_id", school_id);
            // verify required params are set
            if (school_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (uniqueSectionCode != null)
                request.AddParameter("uniqueSectionCode", uniqueSectionCode);
            if (sequenceOfCourse != null)
                request.AddParameter("sequenceOfCourse", sequenceOfCourse);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (classPeriodName != null)
                request.AddParameter("classPeriodName", classPeriodName);
            if (localCourseCode != null)
                request.AddParameter("localCourseCode", localCourseCode);
            if (schoolYear != null)
                request.AddParameter("schoolYear", schoolYear);
            if (termDescriptor != null)
                request.AddParameter("termDescriptor", termDescriptor);
            if (classroomIdentificationCode != null)
                request.AddParameter("classroomIdentificationCode", classroomIdentificationCode);
            if (availableCreditType != null)
                request.AddParameter("availableCreditType", availableCreditType);
            if (educationalEnvironmentType != null)
                request.AddParameter("educationalEnvironmentType", educationalEnvironmentType);
            if (instructionLanguageDescriptor != null)
                request.AddParameter("instructionLanguageDescriptor", instructionLanguageDescriptor);
            if (mediumOfInstructionType != null)
                request.AddParameter("mediumOfInstructionType", mediumOfInstructionType);
            if (populationServedType != null)
                request.AddParameter("populationServedType", populationServedType);
            if (availableCreditConversion != null)
                request.AddParameter("availableCreditConversion", availableCreditConversion);
            if (availableCredits != null)
                request.AddParameter("availableCredits", availableCredits);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Section>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated Staff resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="staff_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="uniqueSectionCode">A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned.</param>
        /// <param name="sequenceOfCourse">When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1.</param>
        /// <param name="schoolId">School Identity Column</param>
        /// <param name="classPeriodName">An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period</param>
        /// <param name="localCourseCode">The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.</param>
        /// <param name="schoolYear">The identifier for the school year.</param>
        /// <param name="termDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="classroomIdentificationCode">A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.</param>
        /// <param name="availableCreditType">The type of credits or units of value awarded for the completion of a course.</param>
        /// <param name="educationalEnvironmentType">The setting in which a child receives education and related services; for example:  Center-based instruction  Home-based instruction  Hospital class  Mainstream  Residential care and treatment facility  ....</param>
        /// <param name="instructionLanguageDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="mediumOfInstructionType">The media through which teachers provide instruction to students and students and teachers communicate about instructional matters; for example:  Technology-based instruction in classroom  Correspondence instruction  Face-to-face instruction  Virtual/On-line Distance learning  Center-based instruction  ...</param>
        /// <param name="populationServedType">The population for which the course was designed; for example:  Bilingual students  Remedial education students  Gifted and talented students  Career and Technical Education students  Special education students  ....</param>
        /// <param name="availableCreditConversion">Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.</param>
        /// <param name="availableCredits">Credits or units of value awarded for the completion of a course.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Section>> GetSectionsByStaff(string staff_id, int? offset= null, int? limit= null, string fields= null, string q= null, string uniqueSectionCode= null, int? sequenceOfCourse= null, int? schoolId= null, string classPeriodName= null, string localCourseCode= null, int? schoolYear= null, string termDescriptor= null, string classroomIdentificationCode= null, string availableCreditType= null, string educationalEnvironmentType= null, string instructionLanguageDescriptor= null, string mediumOfInstructionType= null, string populationServedType= null, double? availableCreditConversion= null, double? availableCredits= null, string id= null) 
        {
            var request = new RestRequest("/enrollment/staffs/{staff_id}/sections", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("staff_id", staff_id);
            // verify required params are set
            if (staff_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (uniqueSectionCode != null)
                request.AddParameter("uniqueSectionCode", uniqueSectionCode);
            if (sequenceOfCourse != null)
                request.AddParameter("sequenceOfCourse", sequenceOfCourse);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (classPeriodName != null)
                request.AddParameter("classPeriodName", classPeriodName);
            if (localCourseCode != null)
                request.AddParameter("localCourseCode", localCourseCode);
            if (schoolYear != null)
                request.AddParameter("schoolYear", schoolYear);
            if (termDescriptor != null)
                request.AddParameter("termDescriptor", termDescriptor);
            if (classroomIdentificationCode != null)
                request.AddParameter("classroomIdentificationCode", classroomIdentificationCode);
            if (availableCreditType != null)
                request.AddParameter("availableCreditType", availableCreditType);
            if (educationalEnvironmentType != null)
                request.AddParameter("educationalEnvironmentType", educationalEnvironmentType);
            if (instructionLanguageDescriptor != null)
                request.AddParameter("instructionLanguageDescriptor", instructionLanguageDescriptor);
            if (mediumOfInstructionType != null)
                request.AddParameter("mediumOfInstructionType", mediumOfInstructionType);
            if (populationServedType != null)
                request.AddParameter("populationServedType", populationServedType);
            if (availableCreditConversion != null)
                request.AddParameter("availableCreditConversion", availableCreditConversion);
            if (availableCredits != null)
                request.AddParameter("availableCredits", availableCredits);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Section>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated Student resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="student_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="uniqueSectionCode">A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned.</param>
        /// <param name="sequenceOfCourse">When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1.</param>
        /// <param name="schoolId">School Identity Column</param>
        /// <param name="classPeriodName">An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period</param>
        /// <param name="localCourseCode">The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.</param>
        /// <param name="schoolYear">The identifier for the school year.</param>
        /// <param name="termDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="classroomIdentificationCode">A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.</param>
        /// <param name="availableCreditType">The type of credits or units of value awarded for the completion of a course.</param>
        /// <param name="educationalEnvironmentType">The setting in which a child receives education and related services; for example:  Center-based instruction  Home-based instruction  Hospital class  Mainstream  Residential care and treatment facility  ....</param>
        /// <param name="instructionLanguageDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="mediumOfInstructionType">The media through which teachers provide instruction to students and students and teachers communicate about instructional matters; for example:  Technology-based instruction in classroom  Correspondence instruction  Face-to-face instruction  Virtual/On-line Distance learning  Center-based instruction  ...</param>
        /// <param name="populationServedType">The population for which the course was designed; for example:  Bilingual students  Remedial education students  Gifted and talented students  Career and Technical Education students  Special education students  ....</param>
        /// <param name="availableCreditConversion">Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.</param>
        /// <param name="availableCredits">Credits or units of value awarded for the completion of a course.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Section>> GetSectionsByStudent(string student_id, int? offset= null, int? limit= null, string fields= null, string q= null, string uniqueSectionCode= null, int? sequenceOfCourse= null, int? schoolId= null, string classPeriodName= null, string localCourseCode= null, int? schoolYear= null, string termDescriptor= null, string classroomIdentificationCode= null, string availableCreditType= null, string educationalEnvironmentType= null, string instructionLanguageDescriptor= null, string mediumOfInstructionType= null, string populationServedType= null, double? availableCreditConversion= null, double? availableCredits= null, string id= null) 
        {
            var request = new RestRequest("/enrollment/students/{student_id}/sections", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("student_id", student_id);
            // verify required params are set
            if (student_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (uniqueSectionCode != null)
                request.AddParameter("uniqueSectionCode", uniqueSectionCode);
            if (sequenceOfCourse != null)
                request.AddParameter("sequenceOfCourse", sequenceOfCourse);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (classPeriodName != null)
                request.AddParameter("classPeriodName", classPeriodName);
            if (localCourseCode != null)
                request.AddParameter("localCourseCode", localCourseCode);
            if (schoolYear != null)
                request.AddParameter("schoolYear", schoolYear);
            if (termDescriptor != null)
                request.AddParameter("termDescriptor", termDescriptor);
            if (classroomIdentificationCode != null)
                request.AddParameter("classroomIdentificationCode", classroomIdentificationCode);
            if (availableCreditType != null)
                request.AddParameter("availableCreditType", availableCreditType);
            if (educationalEnvironmentType != null)
                request.AddParameter("educationalEnvironmentType", educationalEnvironmentType);
            if (instructionLanguageDescriptor != null)
                request.AddParameter("instructionLanguageDescriptor", instructionLanguageDescriptor);
            if (mediumOfInstructionType != null)
                request.AddParameter("mediumOfInstructionType", mediumOfInstructionType);
            if (populationServedType != null)
                request.AddParameter("populationServedType", populationServedType);
            if (availableCreditConversion != null)
                request.AddParameter("availableCreditConversion", availableCreditConversion);
            if (availableCredits != null)
                request.AddParameter("availableCredits", availableCredits);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Section>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<SectionEnrollment>> GetSectionEnrollmentsAll(int? offset= null, int? limit= null, string fields= null) 
        {
            var request = new RestRequest("/enrollment/sectionEnrollments", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            var response = client.Execute<List<SectionEnrollment>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get By Example&quot; pattern. The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="uniqueSectionCode">A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned.</param>
        /// <param name="sequenceOfCourse">When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1.</param>
        /// <param name="schoolId">School Identity Column</param>
        /// <param name="classPeriodName">An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period</param>
        /// <param name="localCourseCode">The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.</param>
        /// <param name="schoolYear">The identifier for the school year.</param>
        /// <param name="termDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="classroomIdentificationCode">A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.</param>
        /// <param name="availableCreditType">The type of credits or units of value awarded for the completion of a course.</param>
        /// <param name="educationalEnvironmentType">The setting in which a child receives education and related services; for example:  Center-based instruction  Home-based instruction  Hospital class  Mainstream  Residential care and treatment facility  ....</param>
        /// <param name="instructionLanguageDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="mediumOfInstructionType">The media through which teachers provide instruction to students and students and teachers communicate about instructional matters; for example:  Technology-based instruction in classroom  Correspondence instruction  Face-to-face instruction  Virtual/On-line Distance learning  Center-based instruction  ...</param>
        /// <param name="populationServedType">The population for which the course was designed; for example:  Bilingual students  Remedial education students  Gifted and talented students  Career and Technical Education students  Special education students  ....</param>
        /// <param name="availableCreditConversion">Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.</param>
        /// <param name="availableCredits">Credits or units of value awarded for the completion of a course.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<SectionEnrollment>> GetSectionEnrollmentsByExample(int? offset= null, int? limit= null, string fields= null, string q= null, string uniqueSectionCode= null, int? sequenceOfCourse= null, int? schoolId= null, string classPeriodName= null, string localCourseCode= null, int? schoolYear= null, string termDescriptor= null, string classroomIdentificationCode= null, string availableCreditType= null, string educationalEnvironmentType= null, string instructionLanguageDescriptor= null, string mediumOfInstructionType= null, string populationServedType= null, double? availableCreditConversion= null, double? availableCredits= null, string id= null) 
        {
            var request = new RestRequest("/enrollment/sectionEnrollments", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (uniqueSectionCode != null)
                request.AddParameter("uniqueSectionCode", uniqueSectionCode);
            if (sequenceOfCourse != null)
                request.AddParameter("sequenceOfCourse", sequenceOfCourse);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (classPeriodName != null)
                request.AddParameter("classPeriodName", classPeriodName);
            if (localCourseCode != null)
                request.AddParameter("localCourseCode", localCourseCode);
            if (schoolYear != null)
                request.AddParameter("schoolYear", schoolYear);
            if (termDescriptor != null)
                request.AddParameter("termDescriptor", termDescriptor);
            if (classroomIdentificationCode != null)
                request.AddParameter("classroomIdentificationCode", classroomIdentificationCode);
            if (availableCreditType != null)
                request.AddParameter("availableCreditType", availableCreditType);
            if (educationalEnvironmentType != null)
                request.AddParameter("educationalEnvironmentType", educationalEnvironmentType);
            if (instructionLanguageDescriptor != null)
                request.AddParameter("instructionLanguageDescriptor", instructionLanguageDescriptor);
            if (mediumOfInstructionType != null)
                request.AddParameter("mediumOfInstructionType", mediumOfInstructionType);
            if (populationServedType != null)
                request.AddParameter("populationServedType", populationServedType);
            if (availableCreditConversion != null)
                request.AddParameter("availableCreditConversion", availableCreditConversion);
            if (availableCredits != null)
                request.AddParameter("availableCredits", availableCredits);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<SectionEnrollment>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get By Key&quot; pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="uniqueSectionCode">A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned.</param>
        /// <param name="sequenceOfCourse">When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1.</param>
        /// <param name="schoolId">School Identity Column</param>
        /// <param name="classPeriodName">An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period</param>
        /// <param name="localCourseCode">The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.</param>
        /// <param name="schoolYear">The identifier for the school year.</param>
        /// <param name="termDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="classroomIdentificationCode">A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<SectionEnrollment> GetSectionEnrollmentsByKey(string uniqueSectionCode= null, int? sequenceOfCourse= null, int? schoolId= null, string classPeriodName= null, string localCourseCode= null, int? schoolYear= null, string termDescriptor= null, string classroomIdentificationCode= null, string fields= null, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/enrollment/sectionEnrollments", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (uniqueSectionCode != null)
                request.AddParameter("uniqueSectionCode", uniqueSectionCode);
            if (sequenceOfCourse != null)
                request.AddParameter("sequenceOfCourse", sequenceOfCourse);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (classPeriodName != null)
                request.AddParameter("classPeriodName", classPeriodName);
            if (localCourseCode != null)
                request.AddParameter("localCourseCode", localCourseCode);
            if (schoolYear != null)
                request.AddParameter("schoolYear", schoolYear);
            if (termDescriptor != null)
                request.AddParameter("termDescriptor", termDescriptor);
            if (classroomIdentificationCode != null)
                request.AddParameter("classroomIdentificationCode", classroomIdentificationCode);
            if (fields != null)
                request.AddParameter("fields", fields);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<SectionEnrollment>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Id&quot; pattern). This GET operation provides access to resources using the &quot;Get By Id&quot; pattern.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<SectionEnrollment> GetSectionEnrollmentsById(string id, string fields= null, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/enrollment/sectionEnrollments/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (fields != null)
                request.AddParameter("fields", fields);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<SectionEnrollment>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated LocalEducationAgency resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="localEducationAgency_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="uniqueSectionCode">A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned.</param>
        /// <param name="sequenceOfCourse">When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1.</param>
        /// <param name="schoolId">School Identity Column</param>
        /// <param name="classPeriodName">An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period</param>
        /// <param name="localCourseCode">The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.</param>
        /// <param name="schoolYear">The identifier for the school year.</param>
        /// <param name="termDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="classroomIdentificationCode">A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.</param>
        /// <param name="availableCreditType">The type of credits or units of value awarded for the completion of a course.</param>
        /// <param name="educationalEnvironmentType">The setting in which a child receives education and related services; for example:  Center-based instruction  Home-based instruction  Hospital class  Mainstream  Residential care and treatment facility  ....</param>
        /// <param name="instructionLanguageDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="mediumOfInstructionType">The media through which teachers provide instruction to students and students and teachers communicate about instructional matters; for example:  Technology-based instruction in classroom  Correspondence instruction  Face-to-face instruction  Virtual/On-line Distance learning  Center-based instruction  ...</param>
        /// <param name="populationServedType">The population for which the course was designed; for example:  Bilingual students  Remedial education students  Gifted and talented students  Career and Technical Education students  Special education students  ....</param>
        /// <param name="availableCreditConversion">Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.</param>
        /// <param name="availableCredits">Credits or units of value awarded for the completion of a course.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<SectionEnrollment>> GetSectionEnrollmentsByLocalEducationAgency(string localEducationAgency_id, int? offset= null, int? limit= null, string fields= null, string q= null, string uniqueSectionCode= null, int? sequenceOfCourse= null, int? schoolId= null, string classPeriodName= null, string localCourseCode= null, int? schoolYear= null, string termDescriptor= null, string classroomIdentificationCode= null, string availableCreditType= null, string educationalEnvironmentType= null, string instructionLanguageDescriptor= null, string mediumOfInstructionType= null, string populationServedType= null, double? availableCreditConversion= null, double? availableCredits= null, string id= null) 
        {
            var request = new RestRequest("/enrollment/localEducationAgencies/{localEducationAgency_id}/sectionEnrollments", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("localEducationAgency_id", localEducationAgency_id);
            // verify required params are set
            if (localEducationAgency_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (uniqueSectionCode != null)
                request.AddParameter("uniqueSectionCode", uniqueSectionCode);
            if (sequenceOfCourse != null)
                request.AddParameter("sequenceOfCourse", sequenceOfCourse);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (classPeriodName != null)
                request.AddParameter("classPeriodName", classPeriodName);
            if (localCourseCode != null)
                request.AddParameter("localCourseCode", localCourseCode);
            if (schoolYear != null)
                request.AddParameter("schoolYear", schoolYear);
            if (termDescriptor != null)
                request.AddParameter("termDescriptor", termDescriptor);
            if (classroomIdentificationCode != null)
                request.AddParameter("classroomIdentificationCode", classroomIdentificationCode);
            if (availableCreditType != null)
                request.AddParameter("availableCreditType", availableCreditType);
            if (educationalEnvironmentType != null)
                request.AddParameter("educationalEnvironmentType", educationalEnvironmentType);
            if (instructionLanguageDescriptor != null)
                request.AddParameter("instructionLanguageDescriptor", instructionLanguageDescriptor);
            if (mediumOfInstructionType != null)
                request.AddParameter("mediumOfInstructionType", mediumOfInstructionType);
            if (populationServedType != null)
                request.AddParameter("populationServedType", populationServedType);
            if (availableCreditConversion != null)
                request.AddParameter("availableCreditConversion", availableCreditConversion);
            if (availableCredits != null)
                request.AddParameter("availableCredits", availableCredits);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<SectionEnrollment>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated School resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="school_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="uniqueSectionCode">A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned.</param>
        /// <param name="sequenceOfCourse">When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1.</param>
        /// <param name="schoolId">School Identity Column</param>
        /// <param name="classPeriodName">An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period</param>
        /// <param name="localCourseCode">The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.</param>
        /// <param name="schoolYear">The identifier for the school year.</param>
        /// <param name="termDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="classroomIdentificationCode">A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.</param>
        /// <param name="availableCreditType">The type of credits or units of value awarded for the completion of a course.</param>
        /// <param name="educationalEnvironmentType">The setting in which a child receives education and related services; for example:  Center-based instruction  Home-based instruction  Hospital class  Mainstream  Residential care and treatment facility  ....</param>
        /// <param name="instructionLanguageDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="mediumOfInstructionType">The media through which teachers provide instruction to students and students and teachers communicate about instructional matters; for example:  Technology-based instruction in classroom  Correspondence instruction  Face-to-face instruction  Virtual/On-line Distance learning  Center-based instruction  ...</param>
        /// <param name="populationServedType">The population for which the course was designed; for example:  Bilingual students  Remedial education students  Gifted and talented students  Career and Technical Education students  Special education students  ....</param>
        /// <param name="availableCreditConversion">Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.</param>
        /// <param name="availableCredits">Credits or units of value awarded for the completion of a course.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<SectionEnrollment>> GetSectionEnrollmentsBySchool(string school_id, int? offset= null, int? limit= null, string fields= null, string q= null, string uniqueSectionCode= null, int? sequenceOfCourse= null, int? schoolId= null, string classPeriodName= null, string localCourseCode= null, int? schoolYear= null, string termDescriptor= null, string classroomIdentificationCode= null, string availableCreditType= null, string educationalEnvironmentType= null, string instructionLanguageDescriptor= null, string mediumOfInstructionType= null, string populationServedType= null, double? availableCreditConversion= null, double? availableCredits= null, string id= null) 
        {
            var request = new RestRequest("/enrollment/schools/{school_id}/sectionEnrollments", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("school_id", school_id);
            // verify required params are set
            if (school_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (uniqueSectionCode != null)
                request.AddParameter("uniqueSectionCode", uniqueSectionCode);
            if (sequenceOfCourse != null)
                request.AddParameter("sequenceOfCourse", sequenceOfCourse);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (classPeriodName != null)
                request.AddParameter("classPeriodName", classPeriodName);
            if (localCourseCode != null)
                request.AddParameter("localCourseCode", localCourseCode);
            if (schoolYear != null)
                request.AddParameter("schoolYear", schoolYear);
            if (termDescriptor != null)
                request.AddParameter("termDescriptor", termDescriptor);
            if (classroomIdentificationCode != null)
                request.AddParameter("classroomIdentificationCode", classroomIdentificationCode);
            if (availableCreditType != null)
                request.AddParameter("availableCreditType", availableCreditType);
            if (educationalEnvironmentType != null)
                request.AddParameter("educationalEnvironmentType", educationalEnvironmentType);
            if (instructionLanguageDescriptor != null)
                request.AddParameter("instructionLanguageDescriptor", instructionLanguageDescriptor);
            if (mediumOfInstructionType != null)
                request.AddParameter("mediumOfInstructionType", mediumOfInstructionType);
            if (populationServedType != null)
                request.AddParameter("populationServedType", populationServedType);
            if (availableCreditConversion != null)
                request.AddParameter("availableCreditConversion", availableCreditConversion);
            if (availableCredits != null)
                request.AddParameter("availableCredits", availableCredits);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<SectionEnrollment>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated Staff resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="staff_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="uniqueSectionCode">A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned.</param>
        /// <param name="sequenceOfCourse">When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1.</param>
        /// <param name="schoolId">School Identity Column</param>
        /// <param name="classPeriodName">An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period</param>
        /// <param name="localCourseCode">The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.</param>
        /// <param name="schoolYear">The identifier for the school year.</param>
        /// <param name="termDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="classroomIdentificationCode">A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.</param>
        /// <param name="availableCreditType">The type of credits or units of value awarded for the completion of a course.</param>
        /// <param name="educationalEnvironmentType">The setting in which a child receives education and related services; for example:  Center-based instruction  Home-based instruction  Hospital class  Mainstream  Residential care and treatment facility  ....</param>
        /// <param name="instructionLanguageDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="mediumOfInstructionType">The media through which teachers provide instruction to students and students and teachers communicate about instructional matters; for example:  Technology-based instruction in classroom  Correspondence instruction  Face-to-face instruction  Virtual/On-line Distance learning  Center-based instruction  ...</param>
        /// <param name="populationServedType">The population for which the course was designed; for example:  Bilingual students  Remedial education students  Gifted and talented students  Career and Technical Education students  Special education students  ....</param>
        /// <param name="availableCreditConversion">Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.</param>
        /// <param name="availableCredits">Credits or units of value awarded for the completion of a course.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<SectionEnrollment>> GetSectionEnrollmentsByStaff(string staff_id, int? offset= null, int? limit= null, string fields= null, string q= null, string uniqueSectionCode= null, int? sequenceOfCourse= null, int? schoolId= null, string classPeriodName= null, string localCourseCode= null, int? schoolYear= null, string termDescriptor= null, string classroomIdentificationCode= null, string availableCreditType= null, string educationalEnvironmentType= null, string instructionLanguageDescriptor= null, string mediumOfInstructionType= null, string populationServedType= null, double? availableCreditConversion= null, double? availableCredits= null, string id= null) 
        {
            var request = new RestRequest("/enrollment/staffs/{staff_id}/sectionEnrollments", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("staff_id", staff_id);
            // verify required params are set
            if (staff_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (uniqueSectionCode != null)
                request.AddParameter("uniqueSectionCode", uniqueSectionCode);
            if (sequenceOfCourse != null)
                request.AddParameter("sequenceOfCourse", sequenceOfCourse);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (classPeriodName != null)
                request.AddParameter("classPeriodName", classPeriodName);
            if (localCourseCode != null)
                request.AddParameter("localCourseCode", localCourseCode);
            if (schoolYear != null)
                request.AddParameter("schoolYear", schoolYear);
            if (termDescriptor != null)
                request.AddParameter("termDescriptor", termDescriptor);
            if (classroomIdentificationCode != null)
                request.AddParameter("classroomIdentificationCode", classroomIdentificationCode);
            if (availableCreditType != null)
                request.AddParameter("availableCreditType", availableCreditType);
            if (educationalEnvironmentType != null)
                request.AddParameter("educationalEnvironmentType", educationalEnvironmentType);
            if (instructionLanguageDescriptor != null)
                request.AddParameter("instructionLanguageDescriptor", instructionLanguageDescriptor);
            if (mediumOfInstructionType != null)
                request.AddParameter("mediumOfInstructionType", mediumOfInstructionType);
            if (populationServedType != null)
                request.AddParameter("populationServedType", populationServedType);
            if (availableCreditConversion != null)
                request.AddParameter("availableCreditConversion", availableCreditConversion);
            if (availableCredits != null)
                request.AddParameter("availableCredits", availableCredits);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<SectionEnrollment>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated Student resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="student_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="uniqueSectionCode">A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned.</param>
        /// <param name="sequenceOfCourse">When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1.</param>
        /// <param name="schoolId">School Identity Column</param>
        /// <param name="classPeriodName">An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period</param>
        /// <param name="localCourseCode">The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.</param>
        /// <param name="schoolYear">The identifier for the school year.</param>
        /// <param name="termDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="classroomIdentificationCode">A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.</param>
        /// <param name="availableCreditType">The type of credits or units of value awarded for the completion of a course.</param>
        /// <param name="educationalEnvironmentType">The setting in which a child receives education and related services; for example:  Center-based instruction  Home-based instruction  Hospital class  Mainstream  Residential care and treatment facility  ....</param>
        /// <param name="instructionLanguageDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="mediumOfInstructionType">The media through which teachers provide instruction to students and students and teachers communicate about instructional matters; for example:  Technology-based instruction in classroom  Correspondence instruction  Face-to-face instruction  Virtual/On-line Distance learning  Center-based instruction  ...</param>
        /// <param name="populationServedType">The population for which the course was designed; for example:  Bilingual students  Remedial education students  Gifted and talented students  Career and Technical Education students  Special education students  ....</param>
        /// <param name="availableCreditConversion">Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.</param>
        /// <param name="availableCredits">Credits or units of value awarded for the completion of a course.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<SectionEnrollment>> GetSectionEnrollmentsByStudent(string student_id, int? offset= null, int? limit= null, string fields= null, string q= null, string uniqueSectionCode= null, int? sequenceOfCourse= null, int? schoolId= null, string classPeriodName= null, string localCourseCode= null, int? schoolYear= null, string termDescriptor= null, string classroomIdentificationCode= null, string availableCreditType= null, string educationalEnvironmentType= null, string instructionLanguageDescriptor= null, string mediumOfInstructionType= null, string populationServedType= null, double? availableCreditConversion= null, double? availableCredits= null, string id= null) 
        {
            var request = new RestRequest("/enrollment/students/{student_id}/sectionEnrollments", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("student_id", student_id);
            // verify required params are set
            if (student_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (uniqueSectionCode != null)
                request.AddParameter("uniqueSectionCode", uniqueSectionCode);
            if (sequenceOfCourse != null)
                request.AddParameter("sequenceOfCourse", sequenceOfCourse);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (classPeriodName != null)
                request.AddParameter("classPeriodName", classPeriodName);
            if (localCourseCode != null)
                request.AddParameter("localCourseCode", localCourseCode);
            if (schoolYear != null)
                request.AddParameter("schoolYear", schoolYear);
            if (termDescriptor != null)
                request.AddParameter("termDescriptor", termDescriptor);
            if (classroomIdentificationCode != null)
                request.AddParameter("classroomIdentificationCode", classroomIdentificationCode);
            if (availableCreditType != null)
                request.AddParameter("availableCreditType", availableCreditType);
            if (educationalEnvironmentType != null)
                request.AddParameter("educationalEnvironmentType", educationalEnvironmentType);
            if (instructionLanguageDescriptor != null)
                request.AddParameter("instructionLanguageDescriptor", instructionLanguageDescriptor);
            if (mediumOfInstructionType != null)
                request.AddParameter("mediumOfInstructionType", mediumOfInstructionType);
            if (populationServedType != null)
                request.AddParameter("populationServedType", populationServedType);
            if (availableCreditConversion != null)
                request.AddParameter("availableCreditConversion", availableCreditConversion);
            if (availableCredits != null)
                request.AddParameter("availableCredits", availableCredits);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<SectionEnrollment>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Student>> GetStudentsAll(int? offset= null, int? limit= null, string fields= null) 
        {
            var request = new RestRequest("/enrollment/students", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            var response = client.Execute<List<Student>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get By Example&quot; pattern. The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="studentUniqueId">A unique alphanumeric code assigned to a student.</param>
        /// <param name="citizenshipStatusType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="birthCountryDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="limitedEnglishProficiencyDescriptor">An indication that the student has sufficient difficulty speaking, reading, writing, or understanding the English language, as to require special English Language services.</param>
        /// <param name="oldEthnicityType">Previous definition of Ethnicity combining Hispanic/latino and race:  1 - American Indian or Alaskan Native  2 - Asian or Pacific Islander  3 - Black, not of Hispanic origin  4 - Hispanic  5 - White, not of Hispanic origin</param>
        /// <param name="schoolFoodServicesEligibilityDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="sexType">A person''s gender.</param>
        /// <param name="birthStateAbbreviationType">The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which an individual was born.</param>
        /// <param name="personalTitlePrefix">A prefix used to denote the title, degree, position, or seniority of the person.</param>
        /// <param name="firstName">A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.</param>
        /// <param name="middleName">A secondary name given to an individual at birth, baptism, or during another naming ceremony.</param>
        /// <param name="lastSurname">The name borne in common by members of a family.</param>
        /// <param name="generationCodeSuffix">An appendage, if any, used to denote an individual's generation in his family (e.g., Jr., Sr., III).</param>
        /// <param name="maidenName">The person's maiden name.</param>
        /// <param name="birthDate">The month, day, and year on which an individual was born.</param>
        /// <param name="birthCity">The set of elements that capture relevant data regarding a person's birth, including birth date and place of birth.</param>
        /// <param name="dateEnteredUS">For students born outside of the U.S., the date the student entered the U.S.</param>
        /// <param name="multipleBirthStatus">Indicator of whether the student was born with other siblings (i.e., twins, triplets, etc.)</param>
        /// <param name="profileThumbnail">ProfileThumbnail.</param>
        /// <param name="hispanicLatinoEthnicity">An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, &quot;Spanish origin,&quot; can be used in addition to &quot;Hispanic or Latino.&quot;</param>
        /// <param name="economicDisadvantaged">An indication of inadequate financial condition of an individual's family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.</param>
        /// <param name="displacementStatus">Indicates a state health or weather related event that displaces a group of students, and may require additional funding, educational, or social services.</param>
        /// <param name="loginId">The login ID for the user; used for security access control interface.</param>
        /// <param name="birthInternationalProvince">For students born outside of the US, the Province or jurisdiction in which an individual is born.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Student>> GetStudentsByExample(int? offset= null, int? limit= null, string fields= null, string q= null, string studentUniqueId= null, string citizenshipStatusType= null, string birthCountryDescriptor= null, string limitedEnglishProficiencyDescriptor= null, string oldEthnicityType= null, string schoolFoodServicesEligibilityDescriptor= null, string sexType= null, string birthStateAbbreviationType= null, string personalTitlePrefix= null, string firstName= null, string middleName= null, string lastSurname= null, string generationCodeSuffix= null, string maidenName= null, DateTime? birthDate= null, string birthCity= null, DateTime? dateEnteredUS= null, bool? multipleBirthStatus= null, string profileThumbnail= null, bool? hispanicLatinoEthnicity= null, bool? economicDisadvantaged= null, string displacementStatus= null, string loginId= null, string birthInternationalProvince= null, string id= null) 
        {
            var request = new RestRequest("/enrollment/students", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (citizenshipStatusType != null)
                request.AddParameter("citizenshipStatusType", citizenshipStatusType);
            if (birthCountryDescriptor != null)
                request.AddParameter("birthCountryDescriptor", birthCountryDescriptor);
            if (limitedEnglishProficiencyDescriptor != null)
                request.AddParameter("limitedEnglishProficiencyDescriptor", limitedEnglishProficiencyDescriptor);
            if (oldEthnicityType != null)
                request.AddParameter("oldEthnicityType", oldEthnicityType);
            if (schoolFoodServicesEligibilityDescriptor != null)
                request.AddParameter("schoolFoodServicesEligibilityDescriptor", schoolFoodServicesEligibilityDescriptor);
            if (sexType != null)
                request.AddParameter("sexType", sexType);
            if (birthStateAbbreviationType != null)
                request.AddParameter("birthStateAbbreviationType", birthStateAbbreviationType);
            if (personalTitlePrefix != null)
                request.AddParameter("personalTitlePrefix", personalTitlePrefix);
            if (firstName != null)
                request.AddParameter("firstName", firstName);
            if (middleName != null)
                request.AddParameter("middleName", middleName);
            if (lastSurname != null)
                request.AddParameter("lastSurname", lastSurname);
            if (generationCodeSuffix != null)
                request.AddParameter("generationCodeSuffix", generationCodeSuffix);
            if (maidenName != null)
                request.AddParameter("maidenName", maidenName);
            if (birthDate != null)
                request.AddParameter("birthDate", birthDate);
            if (birthCity != null)
                request.AddParameter("birthCity", birthCity);
            if (dateEnteredUS != null)
                request.AddParameter("dateEnteredUS", dateEnteredUS);
            if (multipleBirthStatus != null)
                request.AddParameter("multipleBirthStatus", multipleBirthStatus);
            if (profileThumbnail != null)
                request.AddParameter("profileThumbnail", profileThumbnail);
            if (hispanicLatinoEthnicity != null)
                request.AddParameter("hispanicLatinoEthnicity", hispanicLatinoEthnicity);
            if (economicDisadvantaged != null)
                request.AddParameter("economicDisadvantaged", economicDisadvantaged);
            if (displacementStatus != null)
                request.AddParameter("displacementStatus", displacementStatus);
            if (loginId != null)
                request.AddParameter("loginId", loginId);
            if (birthInternationalProvince != null)
                request.AddParameter("birthInternationalProvince", birthInternationalProvince);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Student>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get By Key&quot; pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="studentUniqueId">A unique alphanumeric code assigned to a student.</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<Student> GetStudentsByKey(string studentUniqueId= null, string fields= null, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/enrollment/students", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (fields != null)
                request.AddParameter("fields", fields);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<Student>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Id&quot; pattern). This GET operation provides access to resources using the &quot;Get By Id&quot; pattern.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<Student> GetStudentsById(string id, string fields= null, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/enrollment/students/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (fields != null)
                request.AddParameter("fields", fields);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<Student>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated LocalEducationAgency resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="localEducationAgency_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="studentUniqueId">A unique alphanumeric code assigned to a student.</param>
        /// <param name="citizenshipStatusType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="birthCountryDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="limitedEnglishProficiencyDescriptor">An indication that the student has sufficient difficulty speaking, reading, writing, or understanding the English language, as to require special English Language services.</param>
        /// <param name="oldEthnicityType">Previous definition of Ethnicity combining Hispanic/latino and race:  1 - American Indian or Alaskan Native  2 - Asian or Pacific Islander  3 - Black, not of Hispanic origin  4 - Hispanic  5 - White, not of Hispanic origin</param>
        /// <param name="schoolFoodServicesEligibilityDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="sexType">A person''s gender.</param>
        /// <param name="birthStateAbbreviationType">The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which an individual was born.</param>
        /// <param name="personalTitlePrefix">A prefix used to denote the title, degree, position, or seniority of the person.</param>
        /// <param name="firstName">A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.</param>
        /// <param name="middleName">A secondary name given to an individual at birth, baptism, or during another naming ceremony.</param>
        /// <param name="lastSurname">The name borne in common by members of a family.</param>
        /// <param name="generationCodeSuffix">An appendage, if any, used to denote an individual's generation in his family (e.g., Jr., Sr., III).</param>
        /// <param name="maidenName">The person's maiden name.</param>
        /// <param name="birthDate">The month, day, and year on which an individual was born.</param>
        /// <param name="birthCity">The set of elements that capture relevant data regarding a person's birth, including birth date and place of birth.</param>
        /// <param name="dateEnteredUS">For students born outside of the U.S., the date the student entered the U.S.</param>
        /// <param name="multipleBirthStatus">Indicator of whether the student was born with other siblings (i.e., twins, triplets, etc.)</param>
        /// <param name="profileThumbnail">ProfileThumbnail.</param>
        /// <param name="hispanicLatinoEthnicity">An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, &quot;Spanish origin,&quot; can be used in addition to &quot;Hispanic or Latino.&quot;</param>
        /// <param name="economicDisadvantaged">An indication of inadequate financial condition of an individual's family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.</param>
        /// <param name="displacementStatus">Indicates a state health or weather related event that displaces a group of students, and may require additional funding, educational, or social services.</param>
        /// <param name="loginId">The login ID for the user; used for security access control interface.</param>
        /// <param name="birthInternationalProvince">For students born outside of the US, the Province or jurisdiction in which an individual is born.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Student>> GetStudentsByLocalEducationAgency(string localEducationAgency_id, int? offset= null, int? limit= null, string fields= null, string q= null, string studentUniqueId= null, string citizenshipStatusType= null, string birthCountryDescriptor= null, string limitedEnglishProficiencyDescriptor= null, string oldEthnicityType= null, string schoolFoodServicesEligibilityDescriptor= null, string sexType= null, string birthStateAbbreviationType= null, string personalTitlePrefix= null, string firstName= null, string middleName= null, string lastSurname= null, string generationCodeSuffix= null, string maidenName= null, DateTime? birthDate= null, string birthCity= null, DateTime? dateEnteredUS= null, bool? multipleBirthStatus= null, string profileThumbnail= null, bool? hispanicLatinoEthnicity= null, bool? economicDisadvantaged= null, string displacementStatus= null, string loginId= null, string birthInternationalProvince= null, string id= null) 
        {
            var request = new RestRequest("/enrollment/localEducationAgencies/{localEducationAgency_id}/students", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("localEducationAgency_id", localEducationAgency_id);
            // verify required params are set
            if (localEducationAgency_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (citizenshipStatusType != null)
                request.AddParameter("citizenshipStatusType", citizenshipStatusType);
            if (birthCountryDescriptor != null)
                request.AddParameter("birthCountryDescriptor", birthCountryDescriptor);
            if (limitedEnglishProficiencyDescriptor != null)
                request.AddParameter("limitedEnglishProficiencyDescriptor", limitedEnglishProficiencyDescriptor);
            if (oldEthnicityType != null)
                request.AddParameter("oldEthnicityType", oldEthnicityType);
            if (schoolFoodServicesEligibilityDescriptor != null)
                request.AddParameter("schoolFoodServicesEligibilityDescriptor", schoolFoodServicesEligibilityDescriptor);
            if (sexType != null)
                request.AddParameter("sexType", sexType);
            if (birthStateAbbreviationType != null)
                request.AddParameter("birthStateAbbreviationType", birthStateAbbreviationType);
            if (personalTitlePrefix != null)
                request.AddParameter("personalTitlePrefix", personalTitlePrefix);
            if (firstName != null)
                request.AddParameter("firstName", firstName);
            if (middleName != null)
                request.AddParameter("middleName", middleName);
            if (lastSurname != null)
                request.AddParameter("lastSurname", lastSurname);
            if (generationCodeSuffix != null)
                request.AddParameter("generationCodeSuffix", generationCodeSuffix);
            if (maidenName != null)
                request.AddParameter("maidenName", maidenName);
            if (birthDate != null)
                request.AddParameter("birthDate", birthDate);
            if (birthCity != null)
                request.AddParameter("birthCity", birthCity);
            if (dateEnteredUS != null)
                request.AddParameter("dateEnteredUS", dateEnteredUS);
            if (multipleBirthStatus != null)
                request.AddParameter("multipleBirthStatus", multipleBirthStatus);
            if (profileThumbnail != null)
                request.AddParameter("profileThumbnail", profileThumbnail);
            if (hispanicLatinoEthnicity != null)
                request.AddParameter("hispanicLatinoEthnicity", hispanicLatinoEthnicity);
            if (economicDisadvantaged != null)
                request.AddParameter("economicDisadvantaged", economicDisadvantaged);
            if (displacementStatus != null)
                request.AddParameter("displacementStatus", displacementStatus);
            if (loginId != null)
                request.AddParameter("loginId", loginId);
            if (birthInternationalProvince != null)
                request.AddParameter("birthInternationalProvince", birthInternationalProvince);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Student>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated School resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="school_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="studentUniqueId">A unique alphanumeric code assigned to a student.</param>
        /// <param name="citizenshipStatusType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="birthCountryDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="limitedEnglishProficiencyDescriptor">An indication that the student has sufficient difficulty speaking, reading, writing, or understanding the English language, as to require special English Language services.</param>
        /// <param name="oldEthnicityType">Previous definition of Ethnicity combining Hispanic/latino and race:  1 - American Indian or Alaskan Native  2 - Asian or Pacific Islander  3 - Black, not of Hispanic origin  4 - Hispanic  5 - White, not of Hispanic origin</param>
        /// <param name="schoolFoodServicesEligibilityDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="sexType">A person''s gender.</param>
        /// <param name="birthStateAbbreviationType">The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which an individual was born.</param>
        /// <param name="personalTitlePrefix">A prefix used to denote the title, degree, position, or seniority of the person.</param>
        /// <param name="firstName">A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.</param>
        /// <param name="middleName">A secondary name given to an individual at birth, baptism, or during another naming ceremony.</param>
        /// <param name="lastSurname">The name borne in common by members of a family.</param>
        /// <param name="generationCodeSuffix">An appendage, if any, used to denote an individual's generation in his family (e.g., Jr., Sr., III).</param>
        /// <param name="maidenName">The person's maiden name.</param>
        /// <param name="birthDate">The month, day, and year on which an individual was born.</param>
        /// <param name="birthCity">The set of elements that capture relevant data regarding a person's birth, including birth date and place of birth.</param>
        /// <param name="dateEnteredUS">For students born outside of the U.S., the date the student entered the U.S.</param>
        /// <param name="multipleBirthStatus">Indicator of whether the student was born with other siblings (i.e., twins, triplets, etc.)</param>
        /// <param name="profileThumbnail">ProfileThumbnail.</param>
        /// <param name="hispanicLatinoEthnicity">An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, &quot;Spanish origin,&quot; can be used in addition to &quot;Hispanic or Latino.&quot;</param>
        /// <param name="economicDisadvantaged">An indication of inadequate financial condition of an individual's family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.</param>
        /// <param name="displacementStatus">Indicates a state health or weather related event that displaces a group of students, and may require additional funding, educational, or social services.</param>
        /// <param name="loginId">The login ID for the user; used for security access control interface.</param>
        /// <param name="birthInternationalProvince">For students born outside of the US, the Province or jurisdiction in which an individual is born.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Student>> GetStudentsBySchool(string school_id, int? offset= null, int? limit= null, string fields= null, string q= null, string studentUniqueId= null, string citizenshipStatusType= null, string birthCountryDescriptor= null, string limitedEnglishProficiencyDescriptor= null, string oldEthnicityType= null, string schoolFoodServicesEligibilityDescriptor= null, string sexType= null, string birthStateAbbreviationType= null, string personalTitlePrefix= null, string firstName= null, string middleName= null, string lastSurname= null, string generationCodeSuffix= null, string maidenName= null, DateTime? birthDate= null, string birthCity= null, DateTime? dateEnteredUS= null, bool? multipleBirthStatus= null, string profileThumbnail= null, bool? hispanicLatinoEthnicity= null, bool? economicDisadvantaged= null, string displacementStatus= null, string loginId= null, string birthInternationalProvince= null, string id= null) 
        {
            var request = new RestRequest("/enrollment/schools/{school_id}/students", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("school_id", school_id);
            // verify required params are set
            if (school_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (citizenshipStatusType != null)
                request.AddParameter("citizenshipStatusType", citizenshipStatusType);
            if (birthCountryDescriptor != null)
                request.AddParameter("birthCountryDescriptor", birthCountryDescriptor);
            if (limitedEnglishProficiencyDescriptor != null)
                request.AddParameter("limitedEnglishProficiencyDescriptor", limitedEnglishProficiencyDescriptor);
            if (oldEthnicityType != null)
                request.AddParameter("oldEthnicityType", oldEthnicityType);
            if (schoolFoodServicesEligibilityDescriptor != null)
                request.AddParameter("schoolFoodServicesEligibilityDescriptor", schoolFoodServicesEligibilityDescriptor);
            if (sexType != null)
                request.AddParameter("sexType", sexType);
            if (birthStateAbbreviationType != null)
                request.AddParameter("birthStateAbbreviationType", birthStateAbbreviationType);
            if (personalTitlePrefix != null)
                request.AddParameter("personalTitlePrefix", personalTitlePrefix);
            if (firstName != null)
                request.AddParameter("firstName", firstName);
            if (middleName != null)
                request.AddParameter("middleName", middleName);
            if (lastSurname != null)
                request.AddParameter("lastSurname", lastSurname);
            if (generationCodeSuffix != null)
                request.AddParameter("generationCodeSuffix", generationCodeSuffix);
            if (maidenName != null)
                request.AddParameter("maidenName", maidenName);
            if (birthDate != null)
                request.AddParameter("birthDate", birthDate);
            if (birthCity != null)
                request.AddParameter("birthCity", birthCity);
            if (dateEnteredUS != null)
                request.AddParameter("dateEnteredUS", dateEnteredUS);
            if (multipleBirthStatus != null)
                request.AddParameter("multipleBirthStatus", multipleBirthStatus);
            if (profileThumbnail != null)
                request.AddParameter("profileThumbnail", profileThumbnail);
            if (hispanicLatinoEthnicity != null)
                request.AddParameter("hispanicLatinoEthnicity", hispanicLatinoEthnicity);
            if (economicDisadvantaged != null)
                request.AddParameter("economicDisadvantaged", economicDisadvantaged);
            if (displacementStatus != null)
                request.AddParameter("displacementStatus", displacementStatus);
            if (loginId != null)
                request.AddParameter("loginId", loginId);
            if (birthInternationalProvince != null)
                request.AddParameter("birthInternationalProvince", birthInternationalProvince);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Student>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated Section resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="section_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="studentUniqueId">A unique alphanumeric code assigned to a student.</param>
        /// <param name="citizenshipStatusType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="birthCountryDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="limitedEnglishProficiencyDescriptor">An indication that the student has sufficient difficulty speaking, reading, writing, or understanding the English language, as to require special English Language services.</param>
        /// <param name="oldEthnicityType">Previous definition of Ethnicity combining Hispanic/latino and race:  1 - American Indian or Alaskan Native  2 - Asian or Pacific Islander  3 - Black, not of Hispanic origin  4 - Hispanic  5 - White, not of Hispanic origin</param>
        /// <param name="schoolFoodServicesEligibilityDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="sexType">A person''s gender.</param>
        /// <param name="birthStateAbbreviationType">The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which an individual was born.</param>
        /// <param name="personalTitlePrefix">A prefix used to denote the title, degree, position, or seniority of the person.</param>
        /// <param name="firstName">A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.</param>
        /// <param name="middleName">A secondary name given to an individual at birth, baptism, or during another naming ceremony.</param>
        /// <param name="lastSurname">The name borne in common by members of a family.</param>
        /// <param name="generationCodeSuffix">An appendage, if any, used to denote an individual's generation in his family (e.g., Jr., Sr., III).</param>
        /// <param name="maidenName">The person's maiden name.</param>
        /// <param name="birthDate">The month, day, and year on which an individual was born.</param>
        /// <param name="birthCity">The set of elements that capture relevant data regarding a person's birth, including birth date and place of birth.</param>
        /// <param name="dateEnteredUS">For students born outside of the U.S., the date the student entered the U.S.</param>
        /// <param name="multipleBirthStatus">Indicator of whether the student was born with other siblings (i.e., twins, triplets, etc.)</param>
        /// <param name="profileThumbnail">ProfileThumbnail.</param>
        /// <param name="hispanicLatinoEthnicity">An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, &quot;Spanish origin,&quot; can be used in addition to &quot;Hispanic or Latino.&quot;</param>
        /// <param name="economicDisadvantaged">An indication of inadequate financial condition of an individual's family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.</param>
        /// <param name="displacementStatus">Indicates a state health or weather related event that displaces a group of students, and may require additional funding, educational, or social services.</param>
        /// <param name="loginId">The login ID for the user; used for security access control interface.</param>
        /// <param name="birthInternationalProvince">For students born outside of the US, the Province or jurisdiction in which an individual is born.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Student>> GetStudentsBySection(string section_id, int? offset= null, int? limit= null, string fields= null, string q= null, string studentUniqueId= null, string citizenshipStatusType= null, string birthCountryDescriptor= null, string limitedEnglishProficiencyDescriptor= null, string oldEthnicityType= null, string schoolFoodServicesEligibilityDescriptor= null, string sexType= null, string birthStateAbbreviationType= null, string personalTitlePrefix= null, string firstName= null, string middleName= null, string lastSurname= null, string generationCodeSuffix= null, string maidenName= null, DateTime? birthDate= null, string birthCity= null, DateTime? dateEnteredUS= null, bool? multipleBirthStatus= null, string profileThumbnail= null, bool? hispanicLatinoEthnicity= null, bool? economicDisadvantaged= null, string displacementStatus= null, string loginId= null, string birthInternationalProvince= null, string id= null) 
        {
            var request = new RestRequest("/enrollment/sections/{section_id}/students", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("section_id", section_id);
            // verify required params are set
            if (section_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (citizenshipStatusType != null)
                request.AddParameter("citizenshipStatusType", citizenshipStatusType);
            if (birthCountryDescriptor != null)
                request.AddParameter("birthCountryDescriptor", birthCountryDescriptor);
            if (limitedEnglishProficiencyDescriptor != null)
                request.AddParameter("limitedEnglishProficiencyDescriptor", limitedEnglishProficiencyDescriptor);
            if (oldEthnicityType != null)
                request.AddParameter("oldEthnicityType", oldEthnicityType);
            if (schoolFoodServicesEligibilityDescriptor != null)
                request.AddParameter("schoolFoodServicesEligibilityDescriptor", schoolFoodServicesEligibilityDescriptor);
            if (sexType != null)
                request.AddParameter("sexType", sexType);
            if (birthStateAbbreviationType != null)
                request.AddParameter("birthStateAbbreviationType", birthStateAbbreviationType);
            if (personalTitlePrefix != null)
                request.AddParameter("personalTitlePrefix", personalTitlePrefix);
            if (firstName != null)
                request.AddParameter("firstName", firstName);
            if (middleName != null)
                request.AddParameter("middleName", middleName);
            if (lastSurname != null)
                request.AddParameter("lastSurname", lastSurname);
            if (generationCodeSuffix != null)
                request.AddParameter("generationCodeSuffix", generationCodeSuffix);
            if (maidenName != null)
                request.AddParameter("maidenName", maidenName);
            if (birthDate != null)
                request.AddParameter("birthDate", birthDate);
            if (birthCity != null)
                request.AddParameter("birthCity", birthCity);
            if (dateEnteredUS != null)
                request.AddParameter("dateEnteredUS", dateEnteredUS);
            if (multipleBirthStatus != null)
                request.AddParameter("multipleBirthStatus", multipleBirthStatus);
            if (profileThumbnail != null)
                request.AddParameter("profileThumbnail", profileThumbnail);
            if (hispanicLatinoEthnicity != null)
                request.AddParameter("hispanicLatinoEthnicity", hispanicLatinoEthnicity);
            if (economicDisadvantaged != null)
                request.AddParameter("economicDisadvantaged", economicDisadvantaged);
            if (displacementStatus != null)
                request.AddParameter("displacementStatus", displacementStatus);
            if (loginId != null)
                request.AddParameter("loginId", loginId);
            if (birthInternationalProvince != null)
                request.AddParameter("birthInternationalProvince", birthInternationalProvince);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Student>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated Staff resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="staff_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="studentUniqueId">A unique alphanumeric code assigned to a student.</param>
        /// <param name="citizenshipStatusType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="birthCountryDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="limitedEnglishProficiencyDescriptor">An indication that the student has sufficient difficulty speaking, reading, writing, or understanding the English language, as to require special English Language services.</param>
        /// <param name="oldEthnicityType">Previous definition of Ethnicity combining Hispanic/latino and race:  1 - American Indian or Alaskan Native  2 - Asian or Pacific Islander  3 - Black, not of Hispanic origin  4 - Hispanic  5 - White, not of Hispanic origin</param>
        /// <param name="schoolFoodServicesEligibilityDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="sexType">A person''s gender.</param>
        /// <param name="birthStateAbbreviationType">The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which an individual was born.</param>
        /// <param name="personalTitlePrefix">A prefix used to denote the title, degree, position, or seniority of the person.</param>
        /// <param name="firstName">A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.</param>
        /// <param name="middleName">A secondary name given to an individual at birth, baptism, or during another naming ceremony.</param>
        /// <param name="lastSurname">The name borne in common by members of a family.</param>
        /// <param name="generationCodeSuffix">An appendage, if any, used to denote an individual's generation in his family (e.g., Jr., Sr., III).</param>
        /// <param name="maidenName">The person's maiden name.</param>
        /// <param name="birthDate">The month, day, and year on which an individual was born.</param>
        /// <param name="birthCity">The set of elements that capture relevant data regarding a person's birth, including birth date and place of birth.</param>
        /// <param name="dateEnteredUS">For students born outside of the U.S., the date the student entered the U.S.</param>
        /// <param name="multipleBirthStatus">Indicator of whether the student was born with other siblings (i.e., twins, triplets, etc.)</param>
        /// <param name="profileThumbnail">ProfileThumbnail.</param>
        /// <param name="hispanicLatinoEthnicity">An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, &quot;Spanish origin,&quot; can be used in addition to &quot;Hispanic or Latino.&quot;</param>
        /// <param name="economicDisadvantaged">An indication of inadequate financial condition of an individual's family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.</param>
        /// <param name="displacementStatus">Indicates a state health or weather related event that displaces a group of students, and may require additional funding, educational, or social services.</param>
        /// <param name="loginId">The login ID for the user; used for security access control interface.</param>
        /// <param name="birthInternationalProvince">For students born outside of the US, the Province or jurisdiction in which an individual is born.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Student>> GetStudentsByStaff(string staff_id, int? offset= null, int? limit= null, string fields= null, string q= null, string studentUniqueId= null, string citizenshipStatusType= null, string birthCountryDescriptor= null, string limitedEnglishProficiencyDescriptor= null, string oldEthnicityType= null, string schoolFoodServicesEligibilityDescriptor= null, string sexType= null, string birthStateAbbreviationType= null, string personalTitlePrefix= null, string firstName= null, string middleName= null, string lastSurname= null, string generationCodeSuffix= null, string maidenName= null, DateTime? birthDate= null, string birthCity= null, DateTime? dateEnteredUS= null, bool? multipleBirthStatus= null, string profileThumbnail= null, bool? hispanicLatinoEthnicity= null, bool? economicDisadvantaged= null, string displacementStatus= null, string loginId= null, string birthInternationalProvince= null, string id= null) 
        {
            var request = new RestRequest("/enrollment/staffs/{staff_id}/students", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("staff_id", staff_id);
            // verify required params are set
            if (staff_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (citizenshipStatusType != null)
                request.AddParameter("citizenshipStatusType", citizenshipStatusType);
            if (birthCountryDescriptor != null)
                request.AddParameter("birthCountryDescriptor", birthCountryDescriptor);
            if (limitedEnglishProficiencyDescriptor != null)
                request.AddParameter("limitedEnglishProficiencyDescriptor", limitedEnglishProficiencyDescriptor);
            if (oldEthnicityType != null)
                request.AddParameter("oldEthnicityType", oldEthnicityType);
            if (schoolFoodServicesEligibilityDescriptor != null)
                request.AddParameter("schoolFoodServicesEligibilityDescriptor", schoolFoodServicesEligibilityDescriptor);
            if (sexType != null)
                request.AddParameter("sexType", sexType);
            if (birthStateAbbreviationType != null)
                request.AddParameter("birthStateAbbreviationType", birthStateAbbreviationType);
            if (personalTitlePrefix != null)
                request.AddParameter("personalTitlePrefix", personalTitlePrefix);
            if (firstName != null)
                request.AddParameter("firstName", firstName);
            if (middleName != null)
                request.AddParameter("middleName", middleName);
            if (lastSurname != null)
                request.AddParameter("lastSurname", lastSurname);
            if (generationCodeSuffix != null)
                request.AddParameter("generationCodeSuffix", generationCodeSuffix);
            if (maidenName != null)
                request.AddParameter("maidenName", maidenName);
            if (birthDate != null)
                request.AddParameter("birthDate", birthDate);
            if (birthCity != null)
                request.AddParameter("birthCity", birthCity);
            if (dateEnteredUS != null)
                request.AddParameter("dateEnteredUS", dateEnteredUS);
            if (multipleBirthStatus != null)
                request.AddParameter("multipleBirthStatus", multipleBirthStatus);
            if (profileThumbnail != null)
                request.AddParameter("profileThumbnail", profileThumbnail);
            if (hispanicLatinoEthnicity != null)
                request.AddParameter("hispanicLatinoEthnicity", hispanicLatinoEthnicity);
            if (economicDisadvantaged != null)
                request.AddParameter("economicDisadvantaged", economicDisadvantaged);
            if (displacementStatus != null)
                request.AddParameter("displacementStatus", displacementStatus);
            if (loginId != null)
                request.AddParameter("loginId", loginId);
            if (birthInternationalProvince != null)
                request.AddParameter("birthInternationalProvince", birthInternationalProvince);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Student>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Staff>> GetStaffsAll(int? offset= null, int? limit= null, string fields= null) 
        {
            var request = new RestRequest("/enrollment/staffs", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            var response = client.Execute<List<Staff>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get By Example&quot; pattern. The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="staffUniqueId">A unique alphanumeric code assigned to a staff.</param>
        /// <param name="citizenshipStatusType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="highestCompletedLevelOfEducationDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="oldEthnicityType">Previous definition of Ethnicity combining Hispanic/latino and race:  1 - American Indian or Alaskan Native  2 - Asian or Pacific Islander  3 - Black, not of Hispanic origin  4 - Hispanic  5 - White, not of Hispanic origin</param>
        /// <param name="sexType">A person''s gender.</param>
        /// <param name="personalTitlePrefix">A prefix used to denote the title, degree, position, or seniority of the person.</param>
        /// <param name="firstName">A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.</param>
        /// <param name="middleName">A secondary name given to an individual at birth, baptism, or during another naming ceremony.</param>
        /// <param name="lastSurname">The name borne in common by members of a family.</param>
        /// <param name="generationCodeSuffix">An appendage, if any, used to denote an individual's generation in his family (e.g., Jr., Sr., III).</param>
        /// <param name="maidenName">The person's maiden name.</param>
        /// <param name="birthDate">The month, day, and year on which an individual was born.</param>
        /// <param name="hispanicLatinoEthnicity">An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, &quot;Spanish origin,&quot; can be used in addition to &quot;Hispanic or Latino.&quot;</param>
        /// <param name="yearsOfPriorProfessionalExperience">The total number of years that an individual has previously held a similar professional position in one or more education institutions.</param>
        /// <param name="yearsOfPriorTeachingExperience">The total number of years that an individual has previously held a teaching position in one or more education institutions.</param>
        /// <param name="highlyQualifiedTeacher">An indication of whether a teacher is classified as highly qualified for his/her assignment according to state definition. This attribute indicates the teacher is highly qualified for ALL Sections being taught.</param>
        /// <param name="loginId">The login ID for the user; used for security access control interface.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Staff>> GetStaffsByExample(int? offset= null, int? limit= null, string fields= null, string q= null, string staffUniqueId= null, string citizenshipStatusType= null, string highestCompletedLevelOfEducationDescriptor= null, string oldEthnicityType= null, string sexType= null, string personalTitlePrefix= null, string firstName= null, string middleName= null, string lastSurname= null, string generationCodeSuffix= null, string maidenName= null, DateTime? birthDate= null, bool? hispanicLatinoEthnicity= null, double? yearsOfPriorProfessionalExperience= null, double? yearsOfPriorTeachingExperience= null, bool? highlyQualifiedTeacher= null, string loginId= null, string id= null) 
        {
            var request = new RestRequest("/enrollment/staffs", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (staffUniqueId != null)
                request.AddParameter("staffUniqueId", staffUniqueId);
            if (citizenshipStatusType != null)
                request.AddParameter("citizenshipStatusType", citizenshipStatusType);
            if (highestCompletedLevelOfEducationDescriptor != null)
                request.AddParameter("highestCompletedLevelOfEducationDescriptor", highestCompletedLevelOfEducationDescriptor);
            if (oldEthnicityType != null)
                request.AddParameter("oldEthnicityType", oldEthnicityType);
            if (sexType != null)
                request.AddParameter("sexType", sexType);
            if (personalTitlePrefix != null)
                request.AddParameter("personalTitlePrefix", personalTitlePrefix);
            if (firstName != null)
                request.AddParameter("firstName", firstName);
            if (middleName != null)
                request.AddParameter("middleName", middleName);
            if (lastSurname != null)
                request.AddParameter("lastSurname", lastSurname);
            if (generationCodeSuffix != null)
                request.AddParameter("generationCodeSuffix", generationCodeSuffix);
            if (maidenName != null)
                request.AddParameter("maidenName", maidenName);
            if (birthDate != null)
                request.AddParameter("birthDate", birthDate);
            if (hispanicLatinoEthnicity != null)
                request.AddParameter("hispanicLatinoEthnicity", hispanicLatinoEthnicity);
            if (yearsOfPriorProfessionalExperience != null)
                request.AddParameter("yearsOfPriorProfessionalExperience", yearsOfPriorProfessionalExperience);
            if (yearsOfPriorTeachingExperience != null)
                request.AddParameter("yearsOfPriorTeachingExperience", yearsOfPriorTeachingExperience);
            if (highlyQualifiedTeacher != null)
                request.AddParameter("highlyQualifiedTeacher", highlyQualifiedTeacher);
            if (loginId != null)
                request.AddParameter("loginId", loginId);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Staff>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get By Key&quot; pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="staffUniqueId">A unique alphanumeric code assigned to a staff.</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<Staff> GetStaffsByKey(string staffUniqueId= null, string fields= null, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/enrollment/staffs", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (staffUniqueId != null)
                request.AddParameter("staffUniqueId", staffUniqueId);
            if (fields != null)
                request.AddParameter("fields", fields);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<Staff>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Id&quot; pattern). This GET operation provides access to resources using the &quot;Get By Id&quot; pattern.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<Staff> GetStaffsById(string id, string fields= null, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/enrollment/staffs/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (fields != null)
                request.AddParameter("fields", fields);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<Staff>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated LocalEducationAgency resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="localEducationAgency_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="staffUniqueId">A unique alphanumeric code assigned to a staff.</param>
        /// <param name="citizenshipStatusType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="highestCompletedLevelOfEducationDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="oldEthnicityType">Previous definition of Ethnicity combining Hispanic/latino and race:  1 - American Indian or Alaskan Native  2 - Asian or Pacific Islander  3 - Black, not of Hispanic origin  4 - Hispanic  5 - White, not of Hispanic origin</param>
        /// <param name="sexType">A person''s gender.</param>
        /// <param name="personalTitlePrefix">A prefix used to denote the title, degree, position, or seniority of the person.</param>
        /// <param name="firstName">A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.</param>
        /// <param name="middleName">A secondary name given to an individual at birth, baptism, or during another naming ceremony.</param>
        /// <param name="lastSurname">The name borne in common by members of a family.</param>
        /// <param name="generationCodeSuffix">An appendage, if any, used to denote an individual's generation in his family (e.g., Jr., Sr., III).</param>
        /// <param name="maidenName">The person's maiden name.</param>
        /// <param name="birthDate">The month, day, and year on which an individual was born.</param>
        /// <param name="hispanicLatinoEthnicity">An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, &quot;Spanish origin,&quot; can be used in addition to &quot;Hispanic or Latino.&quot;</param>
        /// <param name="yearsOfPriorProfessionalExperience">The total number of years that an individual has previously held a similar professional position in one or more education institutions.</param>
        /// <param name="yearsOfPriorTeachingExperience">The total number of years that an individual has previously held a teaching position in one or more education institutions.</param>
        /// <param name="highlyQualifiedTeacher">An indication of whether a teacher is classified as highly qualified for his/her assignment according to state definition. This attribute indicates the teacher is highly qualified for ALL Sections being taught.</param>
        /// <param name="loginId">The login ID for the user; used for security access control interface.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Staff>> GetStaffsByLocalEducationAgency(string localEducationAgency_id, int? offset= null, int? limit= null, string fields= null, string q= null, string staffUniqueId= null, string citizenshipStatusType= null, string highestCompletedLevelOfEducationDescriptor= null, string oldEthnicityType= null, string sexType= null, string personalTitlePrefix= null, string firstName= null, string middleName= null, string lastSurname= null, string generationCodeSuffix= null, string maidenName= null, DateTime? birthDate= null, bool? hispanicLatinoEthnicity= null, double? yearsOfPriorProfessionalExperience= null, double? yearsOfPriorTeachingExperience= null, bool? highlyQualifiedTeacher= null, string loginId= null, string id= null) 
        {
            var request = new RestRequest("/enrollment/localEducationAgencies/{localEducationAgency_id}/staffs", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("localEducationAgency_id", localEducationAgency_id);
            // verify required params are set
            if (localEducationAgency_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (staffUniqueId != null)
                request.AddParameter("staffUniqueId", staffUniqueId);
            if (citizenshipStatusType != null)
                request.AddParameter("citizenshipStatusType", citizenshipStatusType);
            if (highestCompletedLevelOfEducationDescriptor != null)
                request.AddParameter("highestCompletedLevelOfEducationDescriptor", highestCompletedLevelOfEducationDescriptor);
            if (oldEthnicityType != null)
                request.AddParameter("oldEthnicityType", oldEthnicityType);
            if (sexType != null)
                request.AddParameter("sexType", sexType);
            if (personalTitlePrefix != null)
                request.AddParameter("personalTitlePrefix", personalTitlePrefix);
            if (firstName != null)
                request.AddParameter("firstName", firstName);
            if (middleName != null)
                request.AddParameter("middleName", middleName);
            if (lastSurname != null)
                request.AddParameter("lastSurname", lastSurname);
            if (generationCodeSuffix != null)
                request.AddParameter("generationCodeSuffix", generationCodeSuffix);
            if (maidenName != null)
                request.AddParameter("maidenName", maidenName);
            if (birthDate != null)
                request.AddParameter("birthDate", birthDate);
            if (hispanicLatinoEthnicity != null)
                request.AddParameter("hispanicLatinoEthnicity", hispanicLatinoEthnicity);
            if (yearsOfPriorProfessionalExperience != null)
                request.AddParameter("yearsOfPriorProfessionalExperience", yearsOfPriorProfessionalExperience);
            if (yearsOfPriorTeachingExperience != null)
                request.AddParameter("yearsOfPriorTeachingExperience", yearsOfPriorTeachingExperience);
            if (highlyQualifiedTeacher != null)
                request.AddParameter("highlyQualifiedTeacher", highlyQualifiedTeacher);
            if (loginId != null)
                request.AddParameter("loginId", loginId);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Staff>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated School resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="school_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="staffUniqueId">A unique alphanumeric code assigned to a staff.</param>
        /// <param name="citizenshipStatusType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="highestCompletedLevelOfEducationDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="oldEthnicityType">Previous definition of Ethnicity combining Hispanic/latino and race:  1 - American Indian or Alaskan Native  2 - Asian or Pacific Islander  3 - Black, not of Hispanic origin  4 - Hispanic  5 - White, not of Hispanic origin</param>
        /// <param name="sexType">A person''s gender.</param>
        /// <param name="personalTitlePrefix">A prefix used to denote the title, degree, position, or seniority of the person.</param>
        /// <param name="firstName">A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.</param>
        /// <param name="middleName">A secondary name given to an individual at birth, baptism, or during another naming ceremony.</param>
        /// <param name="lastSurname">The name borne in common by members of a family.</param>
        /// <param name="generationCodeSuffix">An appendage, if any, used to denote an individual's generation in his family (e.g., Jr., Sr., III).</param>
        /// <param name="maidenName">The person's maiden name.</param>
        /// <param name="birthDate">The month, day, and year on which an individual was born.</param>
        /// <param name="hispanicLatinoEthnicity">An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, &quot;Spanish origin,&quot; can be used in addition to &quot;Hispanic or Latino.&quot;</param>
        /// <param name="yearsOfPriorProfessionalExperience">The total number of years that an individual has previously held a similar professional position in one or more education institutions.</param>
        /// <param name="yearsOfPriorTeachingExperience">The total number of years that an individual has previously held a teaching position in one or more education institutions.</param>
        /// <param name="highlyQualifiedTeacher">An indication of whether a teacher is classified as highly qualified for his/her assignment according to state definition. This attribute indicates the teacher is highly qualified for ALL Sections being taught.</param>
        /// <param name="loginId">The login ID for the user; used for security access control interface.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Staff>> GetStaffsBySchool(string school_id, int? offset= null, int? limit= null, string fields= null, string q= null, string staffUniqueId= null, string citizenshipStatusType= null, string highestCompletedLevelOfEducationDescriptor= null, string oldEthnicityType= null, string sexType= null, string personalTitlePrefix= null, string firstName= null, string middleName= null, string lastSurname= null, string generationCodeSuffix= null, string maidenName= null, DateTime? birthDate= null, bool? hispanicLatinoEthnicity= null, double? yearsOfPriorProfessionalExperience= null, double? yearsOfPriorTeachingExperience= null, bool? highlyQualifiedTeacher= null, string loginId= null, string id= null) 
        {
            var request = new RestRequest("/enrollment/schools/{school_id}/staffs", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("school_id", school_id);
            // verify required params are set
            if (school_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (staffUniqueId != null)
                request.AddParameter("staffUniqueId", staffUniqueId);
            if (citizenshipStatusType != null)
                request.AddParameter("citizenshipStatusType", citizenshipStatusType);
            if (highestCompletedLevelOfEducationDescriptor != null)
                request.AddParameter("highestCompletedLevelOfEducationDescriptor", highestCompletedLevelOfEducationDescriptor);
            if (oldEthnicityType != null)
                request.AddParameter("oldEthnicityType", oldEthnicityType);
            if (sexType != null)
                request.AddParameter("sexType", sexType);
            if (personalTitlePrefix != null)
                request.AddParameter("personalTitlePrefix", personalTitlePrefix);
            if (firstName != null)
                request.AddParameter("firstName", firstName);
            if (middleName != null)
                request.AddParameter("middleName", middleName);
            if (lastSurname != null)
                request.AddParameter("lastSurname", lastSurname);
            if (generationCodeSuffix != null)
                request.AddParameter("generationCodeSuffix", generationCodeSuffix);
            if (maidenName != null)
                request.AddParameter("maidenName", maidenName);
            if (birthDate != null)
                request.AddParameter("birthDate", birthDate);
            if (hispanicLatinoEthnicity != null)
                request.AddParameter("hispanicLatinoEthnicity", hispanicLatinoEthnicity);
            if (yearsOfPriorProfessionalExperience != null)
                request.AddParameter("yearsOfPriorProfessionalExperience", yearsOfPriorProfessionalExperience);
            if (yearsOfPriorTeachingExperience != null)
                request.AddParameter("yearsOfPriorTeachingExperience", yearsOfPriorTeachingExperience);
            if (highlyQualifiedTeacher != null)
                request.AddParameter("highlyQualifiedTeacher", highlyQualifiedTeacher);
            if (loginId != null)
                request.AddParameter("loginId", loginId);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Staff>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated Section resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="section_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="staffUniqueId">A unique alphanumeric code assigned to a staff.</param>
        /// <param name="citizenshipStatusType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="highestCompletedLevelOfEducationDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="oldEthnicityType">Previous definition of Ethnicity combining Hispanic/latino and race:  1 - American Indian or Alaskan Native  2 - Asian or Pacific Islander  3 - Black, not of Hispanic origin  4 - Hispanic  5 - White, not of Hispanic origin</param>
        /// <param name="sexType">A person''s gender.</param>
        /// <param name="personalTitlePrefix">A prefix used to denote the title, degree, position, or seniority of the person.</param>
        /// <param name="firstName">A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.</param>
        /// <param name="middleName">A secondary name given to an individual at birth, baptism, or during another naming ceremony.</param>
        /// <param name="lastSurname">The name borne in common by members of a family.</param>
        /// <param name="generationCodeSuffix">An appendage, if any, used to denote an individual's generation in his family (e.g., Jr., Sr., III).</param>
        /// <param name="maidenName">The person's maiden name.</param>
        /// <param name="birthDate">The month, day, and year on which an individual was born.</param>
        /// <param name="hispanicLatinoEthnicity">An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, &quot;Spanish origin,&quot; can be used in addition to &quot;Hispanic or Latino.&quot;</param>
        /// <param name="yearsOfPriorProfessionalExperience">The total number of years that an individual has previously held a similar professional position in one or more education institutions.</param>
        /// <param name="yearsOfPriorTeachingExperience">The total number of years that an individual has previously held a teaching position in one or more education institutions.</param>
        /// <param name="highlyQualifiedTeacher">An indication of whether a teacher is classified as highly qualified for his/her assignment according to state definition. This attribute indicates the teacher is highly qualified for ALL Sections being taught.</param>
        /// <param name="loginId">The login ID for the user; used for security access control interface.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Staff>> GetStaffsBySection(string section_id, int? offset= null, int? limit= null, string fields= null, string q= null, string staffUniqueId= null, string citizenshipStatusType= null, string highestCompletedLevelOfEducationDescriptor= null, string oldEthnicityType= null, string sexType= null, string personalTitlePrefix= null, string firstName= null, string middleName= null, string lastSurname= null, string generationCodeSuffix= null, string maidenName= null, DateTime? birthDate= null, bool? hispanicLatinoEthnicity= null, double? yearsOfPriorProfessionalExperience= null, double? yearsOfPriorTeachingExperience= null, bool? highlyQualifiedTeacher= null, string loginId= null, string id= null) 
        {
            var request = new RestRequest("/enrollment/sections/{section_id}/staffs", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("section_id", section_id);
            // verify required params are set
            if (section_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (staffUniqueId != null)
                request.AddParameter("staffUniqueId", staffUniqueId);
            if (citizenshipStatusType != null)
                request.AddParameter("citizenshipStatusType", citizenshipStatusType);
            if (highestCompletedLevelOfEducationDescriptor != null)
                request.AddParameter("highestCompletedLevelOfEducationDescriptor", highestCompletedLevelOfEducationDescriptor);
            if (oldEthnicityType != null)
                request.AddParameter("oldEthnicityType", oldEthnicityType);
            if (sexType != null)
                request.AddParameter("sexType", sexType);
            if (personalTitlePrefix != null)
                request.AddParameter("personalTitlePrefix", personalTitlePrefix);
            if (firstName != null)
                request.AddParameter("firstName", firstName);
            if (middleName != null)
                request.AddParameter("middleName", middleName);
            if (lastSurname != null)
                request.AddParameter("lastSurname", lastSurname);
            if (generationCodeSuffix != null)
                request.AddParameter("generationCodeSuffix", generationCodeSuffix);
            if (maidenName != null)
                request.AddParameter("maidenName", maidenName);
            if (birthDate != null)
                request.AddParameter("birthDate", birthDate);
            if (hispanicLatinoEthnicity != null)
                request.AddParameter("hispanicLatinoEthnicity", hispanicLatinoEthnicity);
            if (yearsOfPriorProfessionalExperience != null)
                request.AddParameter("yearsOfPriorProfessionalExperience", yearsOfPriorProfessionalExperience);
            if (yearsOfPriorTeachingExperience != null)
                request.AddParameter("yearsOfPriorTeachingExperience", yearsOfPriorTeachingExperience);
            if (highlyQualifiedTeacher != null)
                request.AddParameter("highlyQualifiedTeacher", highlyQualifiedTeacher);
            if (loginId != null)
                request.AddParameter("loginId", loginId);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Staff>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated Student resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="student_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="staffUniqueId">A unique alphanumeric code assigned to a staff.</param>
        /// <param name="citizenshipStatusType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="highestCompletedLevelOfEducationDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="oldEthnicityType">Previous definition of Ethnicity combining Hispanic/latino and race:  1 - American Indian or Alaskan Native  2 - Asian or Pacific Islander  3 - Black, not of Hispanic origin  4 - Hispanic  5 - White, not of Hispanic origin</param>
        /// <param name="sexType">A person''s gender.</param>
        /// <param name="personalTitlePrefix">A prefix used to denote the title, degree, position, or seniority of the person.</param>
        /// <param name="firstName">A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.</param>
        /// <param name="middleName">A secondary name given to an individual at birth, baptism, or during another naming ceremony.</param>
        /// <param name="lastSurname">The name borne in common by members of a family.</param>
        /// <param name="generationCodeSuffix">An appendage, if any, used to denote an individual's generation in his family (e.g., Jr., Sr., III).</param>
        /// <param name="maidenName">The person's maiden name.</param>
        /// <param name="birthDate">The month, day, and year on which an individual was born.</param>
        /// <param name="hispanicLatinoEthnicity">An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, &quot;Spanish origin,&quot; can be used in addition to &quot;Hispanic or Latino.&quot;</param>
        /// <param name="yearsOfPriorProfessionalExperience">The total number of years that an individual has previously held a similar professional position in one or more education institutions.</param>
        /// <param name="yearsOfPriorTeachingExperience">The total number of years that an individual has previously held a teaching position in one or more education institutions.</param>
        /// <param name="highlyQualifiedTeacher">An indication of whether a teacher is classified as highly qualified for his/her assignment according to state definition. This attribute indicates the teacher is highly qualified for ALL Sections being taught.</param>
        /// <param name="loginId">The login ID for the user; used for security access control interface.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Staff>> GetStaffsByStudent(string student_id, int? offset= null, int? limit= null, string fields= null, string q= null, string staffUniqueId= null, string citizenshipStatusType= null, string highestCompletedLevelOfEducationDescriptor= null, string oldEthnicityType= null, string sexType= null, string personalTitlePrefix= null, string firstName= null, string middleName= null, string lastSurname= null, string generationCodeSuffix= null, string maidenName= null, DateTime? birthDate= null, bool? hispanicLatinoEthnicity= null, double? yearsOfPriorProfessionalExperience= null, double? yearsOfPriorTeachingExperience= null, bool? highlyQualifiedTeacher= null, string loginId= null, string id= null) 
        {
            var request = new RestRequest("/enrollment/students/{student_id}/staffs", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("student_id", student_id);
            // verify required params are set
            if (student_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (staffUniqueId != null)
                request.AddParameter("staffUniqueId", staffUniqueId);
            if (citizenshipStatusType != null)
                request.AddParameter("citizenshipStatusType", citizenshipStatusType);
            if (highestCompletedLevelOfEducationDescriptor != null)
                request.AddParameter("highestCompletedLevelOfEducationDescriptor", highestCompletedLevelOfEducationDescriptor);
            if (oldEthnicityType != null)
                request.AddParameter("oldEthnicityType", oldEthnicityType);
            if (sexType != null)
                request.AddParameter("sexType", sexType);
            if (personalTitlePrefix != null)
                request.AddParameter("personalTitlePrefix", personalTitlePrefix);
            if (firstName != null)
                request.AddParameter("firstName", firstName);
            if (middleName != null)
                request.AddParameter("middleName", middleName);
            if (lastSurname != null)
                request.AddParameter("lastSurname", lastSurname);
            if (generationCodeSuffix != null)
                request.AddParameter("generationCodeSuffix", generationCodeSuffix);
            if (maidenName != null)
                request.AddParameter("maidenName", maidenName);
            if (birthDate != null)
                request.AddParameter("birthDate", birthDate);
            if (hispanicLatinoEthnicity != null)
                request.AddParameter("hispanicLatinoEthnicity", hispanicLatinoEthnicity);
            if (yearsOfPriorProfessionalExperience != null)
                request.AddParameter("yearsOfPriorProfessionalExperience", yearsOfPriorProfessionalExperience);
            if (yearsOfPriorTeachingExperience != null)
                request.AddParameter("yearsOfPriorTeachingExperience", yearsOfPriorTeachingExperience);
            if (highlyQualifiedTeacher != null)
                request.AddParameter("highlyQualifiedTeacher", highlyQualifiedTeacher);
            if (loginId != null)
                request.AddParameter("loginId", loginId);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Staff>>(request);

            return response;
        }
        }
    }

