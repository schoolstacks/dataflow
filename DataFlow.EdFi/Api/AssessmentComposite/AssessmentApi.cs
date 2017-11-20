using System;
using System.Collections.Generic;
using DataFlow.EdFi.Models.AssessmentComposite;
using RestSharp;

namespace DataFlow.EdFi.Api.AssessmentComposite 
{
    public class AssessmentApi 
    {
        private readonly IRestClient client;

        public AssessmentApi(IRestClient client)
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
        public IRestResponse<List<Assessment>> GetAssessmentsAll(int? offset= null, int? limit= null, string fields= null) 
        {
            var request = new RestRequest("/assessment/assessments", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            var response = client.Execute<List<Assessment>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get By Example&quot; pattern. The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="academicSubjectDescriptor">The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject</param>
        /// <param name="assessedGradeLevelDescriptor">The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="assessmentTitle">The title or name of the assessment.  NEDM: Assessment Title</param>
        /// <param name="version">The version identifier for the assessment.</param>
        /// <param name="assessmentFamilyTitle">The title or name of the assessment.</param>
        /// <param name="assessmentCategoryDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="assessmentPeriodDescriptor">The ID of the Assessment Period Descriptor</param>
        /// <param name="lowestAssessedGradeLevelDescriptor">If the test assessment spans a range of grades, then this attribute holds the lowest grade assessed.  If only one grade level is assessed, then this attribute is omitted. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="assessmentForm">Identifies the form of the assessment, for example a regular versus makeup form, multiple choice versus constructed response, etc.</param>
        /// <param name="revisionDate">The month, day, and year that the conceptual design for the assessment was most recently revised substantially.</param>
        /// <param name="maxRawScore">The maximum raw score achievable across all assessment items that are correct and scored at the maximum.</param>
        /// <param name="nomenclature">Reflects the common nomenclature for an element.</param>
        /// <param name="namespace">Namespace for the Assessment.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Assessment>> GetAssessmentsByExample(int? offset= null, int? limit= null, string fields= null, string q= null, string academicSubjectDescriptor= null, string assessedGradeLevelDescriptor= null, string assessmentTitle= null, int? version= null, string assessmentFamilyTitle= null, string assessmentCategoryDescriptor= null, string assessmentPeriodDescriptor= null, string lowestAssessedGradeLevelDescriptor= null, string assessmentForm= null, DateTime? revisionDate= null, int? maxRawScore= null, string nomenclature= null, string @namespace= null, string id= null) 
        {
            var request = new RestRequest("/assessment/assessments", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (assessedGradeLevelDescriptor != null)
                request.AddParameter("assessedGradeLevelDescriptor", assessedGradeLevelDescriptor);
            if (assessmentTitle != null)
                request.AddParameter("assessmentTitle", assessmentTitle);
            if (version != null)
                request.AddParameter("version", version);
            if (assessmentFamilyTitle != null)
                request.AddParameter("assessmentFamilyTitle", assessmentFamilyTitle);
            if (assessmentCategoryDescriptor != null)
                request.AddParameter("assessmentCategoryDescriptor", assessmentCategoryDescriptor);
            if (assessmentPeriodDescriptor != null)
                request.AddParameter("assessmentPeriodDescriptor", assessmentPeriodDescriptor);
            if (lowestAssessedGradeLevelDescriptor != null)
                request.AddParameter("lowestAssessedGradeLevelDescriptor", lowestAssessedGradeLevelDescriptor);
            if (assessmentForm != null)
                request.AddParameter("assessmentForm", assessmentForm);
            if (revisionDate != null)
                request.AddParameter("revisionDate", revisionDate);
            if (maxRawScore != null)
                request.AddParameter("maxRawScore", maxRawScore);
            if (nomenclature != null)
                request.AddParameter("nomenclature", nomenclature);
            if (@namespace != null)
                request.AddParameter("@namespace", @namespace);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Assessment>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get By Key&quot; pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="academicSubjectDescriptor">The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject</param>
        /// <param name="assessedGradeLevelDescriptor">The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="assessmentTitle">The title or name of the assessment.  NEDM: Assessment Title</param>
        /// <param name="version">The version identifier for the assessment.</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<Assessment> GetAssessmentsByKey(string academicSubjectDescriptor= null, string assessedGradeLevelDescriptor= null, string assessmentTitle= null, int? version= null, string fields= null, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/assessment/assessments", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (assessedGradeLevelDescriptor != null)
                request.AddParameter("assessedGradeLevelDescriptor", assessedGradeLevelDescriptor);
            if (assessmentTitle != null)
                request.AddParameter("assessmentTitle", assessmentTitle);
            if (version != null)
                request.AddParameter("version", version);
            if (fields != null)
                request.AddParameter("fields", fields);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<Assessment>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Id&quot; pattern). This GET operation provides access to resources using the &quot;Get By Id&quot; pattern.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<Assessment> GetAssessmentsById(string id, string fields= null, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/assessment/assessments/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (fields != null)
                request.AddParameter("fields", fields);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<Assessment>(request);

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
        /// <param name="academicSubjectDescriptor">The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject</param>
        /// <param name="assessedGradeLevelDescriptor">The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="assessmentTitle">The title or name of the assessment.  NEDM: Assessment Title</param>
        /// <param name="version">The version identifier for the assessment.</param>
        /// <param name="assessmentFamilyTitle">The title or name of the assessment.</param>
        /// <param name="assessmentCategoryDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="assessmentPeriodDescriptor">The ID of the Assessment Period Descriptor</param>
        /// <param name="lowestAssessedGradeLevelDescriptor">If the test assessment spans a range of grades, then this attribute holds the lowest grade assessed.  If only one grade level is assessed, then this attribute is omitted. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="assessmentForm">Identifies the form of the assessment, for example a regular versus makeup form, multiple choice versus constructed response, etc.</param>
        /// <param name="revisionDate">The month, day, and year that the conceptual design for the assessment was most recently revised substantially.</param>
        /// <param name="maxRawScore">The maximum raw score achievable across all assessment items that are correct and scored at the maximum.</param>
        /// <param name="nomenclature">Reflects the common nomenclature for an element.</param>
        /// <param name="namespace">Namespace for the Assessment.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Assessment>> GetAssessmentsByLocalEducationAgency(string localEducationAgency_id, int? offset= null, int? limit= null, string fields= null, string q= null, string academicSubjectDescriptor= null, string assessedGradeLevelDescriptor= null, string assessmentTitle= null, int? version= null, string assessmentFamilyTitle= null, string assessmentCategoryDescriptor= null, string assessmentPeriodDescriptor= null, string lowestAssessedGradeLevelDescriptor= null, string assessmentForm= null, DateTime? revisionDate= null, int? maxRawScore= null, string nomenclature= null, string @namespace= null, string id= null) 
        {
            var request = new RestRequest("/assessment/localEducationAgencies/{localEducationAgency_id}/assessments", Method.GET);
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
            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (assessedGradeLevelDescriptor != null)
                request.AddParameter("assessedGradeLevelDescriptor", assessedGradeLevelDescriptor);
            if (assessmentTitle != null)
                request.AddParameter("assessmentTitle", assessmentTitle);
            if (version != null)
                request.AddParameter("version", version);
            if (assessmentFamilyTitle != null)
                request.AddParameter("assessmentFamilyTitle", assessmentFamilyTitle);
            if (assessmentCategoryDescriptor != null)
                request.AddParameter("assessmentCategoryDescriptor", assessmentCategoryDescriptor);
            if (assessmentPeriodDescriptor != null)
                request.AddParameter("assessmentPeriodDescriptor", assessmentPeriodDescriptor);
            if (lowestAssessedGradeLevelDescriptor != null)
                request.AddParameter("lowestAssessedGradeLevelDescriptor", lowestAssessedGradeLevelDescriptor);
            if (assessmentForm != null)
                request.AddParameter("assessmentForm", assessmentForm);
            if (revisionDate != null)
                request.AddParameter("revisionDate", revisionDate);
            if (maxRawScore != null)
                request.AddParameter("maxRawScore", maxRawScore);
            if (nomenclature != null)
                request.AddParameter("nomenclature", nomenclature);
            if (@namespace != null)
                request.AddParameter("@namespace", @namespace);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Assessment>>(request);

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
        /// <param name="academicSubjectDescriptor">The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject</param>
        /// <param name="assessedGradeLevelDescriptor">The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="assessmentTitle">The title or name of the assessment.  NEDM: Assessment Title</param>
        /// <param name="version">The version identifier for the assessment.</param>
        /// <param name="assessmentFamilyTitle">The title or name of the assessment.</param>
        /// <param name="assessmentCategoryDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="assessmentPeriodDescriptor">The ID of the Assessment Period Descriptor</param>
        /// <param name="lowestAssessedGradeLevelDescriptor">If the test assessment spans a range of grades, then this attribute holds the lowest grade assessed.  If only one grade level is assessed, then this attribute is omitted. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="assessmentForm">Identifies the form of the assessment, for example a regular versus makeup form, multiple choice versus constructed response, etc.</param>
        /// <param name="revisionDate">The month, day, and year that the conceptual design for the assessment was most recently revised substantially.</param>
        /// <param name="maxRawScore">The maximum raw score achievable across all assessment items that are correct and scored at the maximum.</param>
        /// <param name="nomenclature">Reflects the common nomenclature for an element.</param>
        /// <param name="namespace">Namespace for the Assessment.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Assessment>> GetAssessmentsBySchool(string school_id, int? offset= null, int? limit= null, string fields= null, string q= null, string academicSubjectDescriptor= null, string assessedGradeLevelDescriptor= null, string assessmentTitle= null, int? version= null, string assessmentFamilyTitle= null, string assessmentCategoryDescriptor= null, string assessmentPeriodDescriptor= null, string lowestAssessedGradeLevelDescriptor= null, string assessmentForm= null, DateTime? revisionDate= null, int? maxRawScore= null, string nomenclature= null, string @namespace= null, string id= null) 
        {
            var request = new RestRequest("/assessment/schools/{school_id}/assessments", Method.GET);
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
            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (assessedGradeLevelDescriptor != null)
                request.AddParameter("assessedGradeLevelDescriptor", assessedGradeLevelDescriptor);
            if (assessmentTitle != null)
                request.AddParameter("assessmentTitle", assessmentTitle);
            if (version != null)
                request.AddParameter("version", version);
            if (assessmentFamilyTitle != null)
                request.AddParameter("assessmentFamilyTitle", assessmentFamilyTitle);
            if (assessmentCategoryDescriptor != null)
                request.AddParameter("assessmentCategoryDescriptor", assessmentCategoryDescriptor);
            if (assessmentPeriodDescriptor != null)
                request.AddParameter("assessmentPeriodDescriptor", assessmentPeriodDescriptor);
            if (lowestAssessedGradeLevelDescriptor != null)
                request.AddParameter("lowestAssessedGradeLevelDescriptor", lowestAssessedGradeLevelDescriptor);
            if (assessmentForm != null)
                request.AddParameter("assessmentForm", assessmentForm);
            if (revisionDate != null)
                request.AddParameter("revisionDate", revisionDate);
            if (maxRawScore != null)
                request.AddParameter("maxRawScore", maxRawScore);
            if (nomenclature != null)
                request.AddParameter("nomenclature", nomenclature);
            if (@namespace != null)
                request.AddParameter("@namespace", @namespace);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Assessment>>(request);

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
        /// <param name="academicSubjectDescriptor">The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject</param>
        /// <param name="assessedGradeLevelDescriptor">The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="assessmentTitle">The title or name of the assessment.  NEDM: Assessment Title</param>
        /// <param name="version">The version identifier for the assessment.</param>
        /// <param name="assessmentFamilyTitle">The title or name of the assessment.</param>
        /// <param name="assessmentCategoryDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="assessmentPeriodDescriptor">The ID of the Assessment Period Descriptor</param>
        /// <param name="lowestAssessedGradeLevelDescriptor">If the test assessment spans a range of grades, then this attribute holds the lowest grade assessed.  If only one grade level is assessed, then this attribute is omitted. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="assessmentForm">Identifies the form of the assessment, for example a regular versus makeup form, multiple choice versus constructed response, etc.</param>
        /// <param name="revisionDate">The month, day, and year that the conceptual design for the assessment was most recently revised substantially.</param>
        /// <param name="maxRawScore">The maximum raw score achievable across all assessment items that are correct and scored at the maximum.</param>
        /// <param name="nomenclature">Reflects the common nomenclature for an element.</param>
        /// <param name="namespace">Namespace for the Assessment.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Assessment>> GetAssessmentsByStaff(string staff_id, int? offset= null, int? limit= null, string fields= null, string q= null, string academicSubjectDescriptor= null, string assessedGradeLevelDescriptor= null, string assessmentTitle= null, int? version= null, string assessmentFamilyTitle= null, string assessmentCategoryDescriptor= null, string assessmentPeriodDescriptor= null, string lowestAssessedGradeLevelDescriptor= null, string assessmentForm= null, DateTime? revisionDate= null, int? maxRawScore= null, string nomenclature= null, string @namespace= null, string id= null) 
        {
            var request = new RestRequest("/assessment/staffs/{staff_id}/assessments", Method.GET);
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
            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (assessedGradeLevelDescriptor != null)
                request.AddParameter("assessedGradeLevelDescriptor", assessedGradeLevelDescriptor);
            if (assessmentTitle != null)
                request.AddParameter("assessmentTitle", assessmentTitle);
            if (version != null)
                request.AddParameter("version", version);
            if (assessmentFamilyTitle != null)
                request.AddParameter("assessmentFamilyTitle", assessmentFamilyTitle);
            if (assessmentCategoryDescriptor != null)
                request.AddParameter("assessmentCategoryDescriptor", assessmentCategoryDescriptor);
            if (assessmentPeriodDescriptor != null)
                request.AddParameter("assessmentPeriodDescriptor", assessmentPeriodDescriptor);
            if (lowestAssessedGradeLevelDescriptor != null)
                request.AddParameter("lowestAssessedGradeLevelDescriptor", lowestAssessedGradeLevelDescriptor);
            if (assessmentForm != null)
                request.AddParameter("assessmentForm", assessmentForm);
            if (revisionDate != null)
                request.AddParameter("revisionDate", revisionDate);
            if (maxRawScore != null)
                request.AddParameter("maxRawScore", maxRawScore);
            if (nomenclature != null)
                request.AddParameter("nomenclature", nomenclature);
            if (@namespace != null)
                request.AddParameter("@namespace", @namespace);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Assessment>>(request);

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
        /// <param name="academicSubjectDescriptor">The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject</param>
        /// <param name="assessedGradeLevelDescriptor">The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="assessmentTitle">The title or name of the assessment.  NEDM: Assessment Title</param>
        /// <param name="version">The version identifier for the assessment.</param>
        /// <param name="assessmentFamilyTitle">The title or name of the assessment.</param>
        /// <param name="assessmentCategoryDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="assessmentPeriodDescriptor">The ID of the Assessment Period Descriptor</param>
        /// <param name="lowestAssessedGradeLevelDescriptor">If the test assessment spans a range of grades, then this attribute holds the lowest grade assessed.  If only one grade level is assessed, then this attribute is omitted. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="assessmentForm">Identifies the form of the assessment, for example a regular versus makeup form, multiple choice versus constructed response, etc.</param>
        /// <param name="revisionDate">The month, day, and year that the conceptual design for the assessment was most recently revised substantially.</param>
        /// <param name="maxRawScore">The maximum raw score achievable across all assessment items that are correct and scored at the maximum.</param>
        /// <param name="nomenclature">Reflects the common nomenclature for an element.</param>
        /// <param name="namespace">Namespace for the Assessment.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Assessment>> GetAssessmentsBySection(string section_id, int? offset= null, int? limit= null, string fields= null, string q= null, string academicSubjectDescriptor= null, string assessedGradeLevelDescriptor= null, string assessmentTitle= null, int? version= null, string assessmentFamilyTitle= null, string assessmentCategoryDescriptor= null, string assessmentPeriodDescriptor= null, string lowestAssessedGradeLevelDescriptor= null, string assessmentForm= null, DateTime? revisionDate= null, int? maxRawScore= null, string nomenclature= null, string @namespace= null, string id= null) 
        {
            var request = new RestRequest("/assessment/sections/{section_id}/assessments", Method.GET);
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
            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (assessedGradeLevelDescriptor != null)
                request.AddParameter("assessedGradeLevelDescriptor", assessedGradeLevelDescriptor);
            if (assessmentTitle != null)
                request.AddParameter("assessmentTitle", assessmentTitle);
            if (version != null)
                request.AddParameter("version", version);
            if (assessmentFamilyTitle != null)
                request.AddParameter("assessmentFamilyTitle", assessmentFamilyTitle);
            if (assessmentCategoryDescriptor != null)
                request.AddParameter("assessmentCategoryDescriptor", assessmentCategoryDescriptor);
            if (assessmentPeriodDescriptor != null)
                request.AddParameter("assessmentPeriodDescriptor", assessmentPeriodDescriptor);
            if (lowestAssessedGradeLevelDescriptor != null)
                request.AddParameter("lowestAssessedGradeLevelDescriptor", lowestAssessedGradeLevelDescriptor);
            if (assessmentForm != null)
                request.AddParameter("assessmentForm", assessmentForm);
            if (revisionDate != null)
                request.AddParameter("revisionDate", revisionDate);
            if (maxRawScore != null)
                request.AddParameter("maxRawScore", maxRawScore);
            if (nomenclature != null)
                request.AddParameter("nomenclature", nomenclature);
            if (@namespace != null)
                request.AddParameter("@namespace", @namespace);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Assessment>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated Program resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="program_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="academicSubjectDescriptor">The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject</param>
        /// <param name="assessedGradeLevelDescriptor">The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="assessmentTitle">The title or name of the assessment.  NEDM: Assessment Title</param>
        /// <param name="version">The version identifier for the assessment.</param>
        /// <param name="assessmentFamilyTitle">The title or name of the assessment.</param>
        /// <param name="assessmentCategoryDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="assessmentPeriodDescriptor">The ID of the Assessment Period Descriptor</param>
        /// <param name="lowestAssessedGradeLevelDescriptor">If the test assessment spans a range of grades, then this attribute holds the lowest grade assessed.  If only one grade level is assessed, then this attribute is omitted. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="assessmentForm">Identifies the form of the assessment, for example a regular versus makeup form, multiple choice versus constructed response, etc.</param>
        /// <param name="revisionDate">The month, day, and year that the conceptual design for the assessment was most recently revised substantially.</param>
        /// <param name="maxRawScore">The maximum raw score achievable across all assessment items that are correct and scored at the maximum.</param>
        /// <param name="nomenclature">Reflects the common nomenclature for an element.</param>
        /// <param name="namespace">Namespace for the Assessment.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Assessment>> GetAssessmentsByProgram(string program_id, int? offset= null, int? limit= null, string fields= null, string q= null, string academicSubjectDescriptor= null, string assessedGradeLevelDescriptor= null, string assessmentTitle= null, int? version= null, string assessmentFamilyTitle= null, string assessmentCategoryDescriptor= null, string assessmentPeriodDescriptor= null, string lowestAssessedGradeLevelDescriptor= null, string assessmentForm= null, DateTime? revisionDate= null, int? maxRawScore= null, string nomenclature= null, string @namespace= null, string id= null) 
        {
            var request = new RestRequest("/assessment/programs/{program_id}/assessments", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("program_id", program_id);
            // verify required params are set
            if (program_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (assessedGradeLevelDescriptor != null)
                request.AddParameter("assessedGradeLevelDescriptor", assessedGradeLevelDescriptor);
            if (assessmentTitle != null)
                request.AddParameter("assessmentTitle", assessmentTitle);
            if (version != null)
                request.AddParameter("version", version);
            if (assessmentFamilyTitle != null)
                request.AddParameter("assessmentFamilyTitle", assessmentFamilyTitle);
            if (assessmentCategoryDescriptor != null)
                request.AddParameter("assessmentCategoryDescriptor", assessmentCategoryDescriptor);
            if (assessmentPeriodDescriptor != null)
                request.AddParameter("assessmentPeriodDescriptor", assessmentPeriodDescriptor);
            if (lowestAssessedGradeLevelDescriptor != null)
                request.AddParameter("lowestAssessedGradeLevelDescriptor", lowestAssessedGradeLevelDescriptor);
            if (assessmentForm != null)
                request.AddParameter("assessmentForm", assessmentForm);
            if (revisionDate != null)
                request.AddParameter("revisionDate", revisionDate);
            if (maxRawScore != null)
                request.AddParameter("maxRawScore", maxRawScore);
            if (nomenclature != null)
                request.AddParameter("nomenclature", nomenclature);
            if (@namespace != null)
                request.AddParameter("@namespace", @namespace);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Assessment>>(request);

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
        /// <param name="academicSubjectDescriptor">The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject</param>
        /// <param name="assessedGradeLevelDescriptor">The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="assessmentTitle">The title or name of the assessment.  NEDM: Assessment Title</param>
        /// <param name="version">The version identifier for the assessment.</param>
        /// <param name="assessmentFamilyTitle">The title or name of the assessment.</param>
        /// <param name="assessmentCategoryDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="assessmentPeriodDescriptor">The ID of the Assessment Period Descriptor</param>
        /// <param name="lowestAssessedGradeLevelDescriptor">If the test assessment spans a range of grades, then this attribute holds the lowest grade assessed.  If only one grade level is assessed, then this attribute is omitted. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="assessmentForm">Identifies the form of the assessment, for example a regular versus makeup form, multiple choice versus constructed response, etc.</param>
        /// <param name="revisionDate">The month, day, and year that the conceptual design for the assessment was most recently revised substantially.</param>
        /// <param name="maxRawScore">The maximum raw score achievable across all assessment items that are correct and scored at the maximum.</param>
        /// <param name="nomenclature">Reflects the common nomenclature for an element.</param>
        /// <param name="namespace">Namespace for the Assessment.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Assessment>> GetAssessmentsByStudent(string student_id, int? offset= null, int? limit= null, string fields= null, string q= null, string academicSubjectDescriptor= null, string assessedGradeLevelDescriptor= null, string assessmentTitle= null, int? version= null, string assessmentFamilyTitle= null, string assessmentCategoryDescriptor= null, string assessmentPeriodDescriptor= null, string lowestAssessedGradeLevelDescriptor= null, string assessmentForm= null, DateTime? revisionDate= null, int? maxRawScore= null, string nomenclature= null, string @namespace= null, string id= null) 
        {
            var request = new RestRequest("/assessment/students/{student_id}/assessments", Method.GET);
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
            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (assessedGradeLevelDescriptor != null)
                request.AddParameter("assessedGradeLevelDescriptor", assessedGradeLevelDescriptor);
            if (assessmentTitle != null)
                request.AddParameter("assessmentTitle", assessmentTitle);
            if (version != null)
                request.AddParameter("version", version);
            if (assessmentFamilyTitle != null)
                request.AddParameter("assessmentFamilyTitle", assessmentFamilyTitle);
            if (assessmentCategoryDescriptor != null)
                request.AddParameter("assessmentCategoryDescriptor", assessmentCategoryDescriptor);
            if (assessmentPeriodDescriptor != null)
                request.AddParameter("assessmentPeriodDescriptor", assessmentPeriodDescriptor);
            if (lowestAssessedGradeLevelDescriptor != null)
                request.AddParameter("lowestAssessedGradeLevelDescriptor", lowestAssessedGradeLevelDescriptor);
            if (assessmentForm != null)
                request.AddParameter("assessmentForm", assessmentForm);
            if (revisionDate != null)
                request.AddParameter("revisionDate", revisionDate);
            if (maxRawScore != null)
                request.AddParameter("maxRawScore", maxRawScore);
            if (nomenclature != null)
                request.AddParameter("nomenclature", nomenclature);
            if (@namespace != null)
                request.AddParameter("@namespace", @namespace);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Assessment>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StudentAssessment>> GetStudentAssessmentsAll(int? offset= null, int? limit= null, string fields= null) 
        {
            var request = new RestRequest("/assessment/studentAssessments", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            var response = client.Execute<List<StudentAssessment>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get By Example&quot; pattern. The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="assessment_id">The unique identifier of the associated Assessment.</param>
        /// <param name="administrationDate">The month(s), day(s), and year on which an assessment is administered or first day of administration if over multiple days.</param>
        /// <param name="assessmentTitle">The title or name of the assessment.  NEDM: Assessment Title</param>
        /// <param name="assessedGradeLevelDescriptor">The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="academicSubjectDescriptor">The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject</param>
        /// <param name="version">The version identifier for the test assessment.  NEDM: Assessment Version</param>
        /// <param name="studentUniqueId">A unique number or alphanumeric code assigned to a student by a state education agency.</param>
        /// <param name="administrationEnvironmentType">The environment in which the test was administered.  For example:  Electronic  Classroom  Testing Center  ...  ....</param>
        /// <param name="eventCircumstanceType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="whenAssessedGradeLevelDescriptor">The grade level of a student when assessed.</param>
        /// <param name="administrationLanguageDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="reasonNotTestedType">The primary reason student is not tested. For example:  Absent  Refusal by parent  Refusal by student  Medical waiver  Illness  Disruptive behavior  LEP Exempt  ...</param>
        /// <param name="retestIndicatorType">Indicator if the test was retaken.  For example:  Primary administration  First retest  Second retest  ...</param>
        /// <param name="administrationEndDate">Assessment Administration End Date, if administered over multiple days.</param>
        /// <param name="serialNumber">The unique number for the assessment form or answer document.</param>
        /// <param name="eventDescription">Describes special events that occur before during or after the assessment session that may impact use of results.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StudentAssessment>> GetStudentAssessmentsByExample(int? offset= null, int? limit= null, string fields= null, string q= null, string assessment_id= null, DateTime? administrationDate= null, string assessmentTitle= null, string assessedGradeLevelDescriptor= null, string academicSubjectDescriptor= null, int? version= null, int? studentUniqueId= null, string administrationEnvironmentType= null, string eventCircumstanceType= null, string whenAssessedGradeLevelDescriptor= null, string administrationLanguageDescriptor= null, string reasonNotTestedType= null, string retestIndicatorType= null, DateTime? administrationEndDate= null, string serialNumber= null, string eventDescription= null, string id= null) 
        {
            var request = new RestRequest("/assessment/studentAssessments", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (assessment_id != null)
                request.AddParameter("assessment_id", assessment_id);
            if (administrationDate != null)
                request.AddParameter("administrationDate", administrationDate);
            if (assessmentTitle != null)
                request.AddParameter("assessmentTitle", assessmentTitle);
            if (assessedGradeLevelDescriptor != null)
                request.AddParameter("assessedGradeLevelDescriptor", assessedGradeLevelDescriptor);
            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (version != null)
                request.AddParameter("version", version);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (administrationEnvironmentType != null)
                request.AddParameter("administrationEnvironmentType", administrationEnvironmentType);
            if (eventCircumstanceType != null)
                request.AddParameter("eventCircumstanceType", eventCircumstanceType);
            if (whenAssessedGradeLevelDescriptor != null)
                request.AddParameter("whenAssessedGradeLevelDescriptor", whenAssessedGradeLevelDescriptor);
            if (administrationLanguageDescriptor != null)
                request.AddParameter("administrationLanguageDescriptor", administrationLanguageDescriptor);
            if (reasonNotTestedType != null)
                request.AddParameter("reasonNotTestedType", reasonNotTestedType);
            if (retestIndicatorType != null)
                request.AddParameter("retestIndicatorType", retestIndicatorType);
            if (administrationEndDate != null)
                request.AddParameter("administrationEndDate", administrationEndDate);
            if (serialNumber != null)
                request.AddParameter("serialNumber", serialNumber);
            if (eventDescription != null)
                request.AddParameter("eventDescription", eventDescription);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<StudentAssessment>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get By Key&quot; pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="administrationDate">The month(s), day(s), and year on which an assessment is administered or first day of administration if over multiple days.</param>
        /// <param name="assessmentTitle">The title or name of the assessment.  NEDM: Assessment Title</param>
        /// <param name="assessedGradeLevelDescriptor">The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="academicSubjectDescriptor">The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject</param>
        /// <param name="version">The version identifier for the test assessment.  NEDM: Assessment Version</param>
        /// <param name="studentUniqueId">A unique number or alphanumeric code assigned to a student by a state education agency.</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<StudentAssessment> GetStudentAssessmentsByKey(DateTime? administrationDate= null, string assessmentTitle= null, string assessedGradeLevelDescriptor= null, string academicSubjectDescriptor= null, int? version= null, int? studentUniqueId= null, string fields= null, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/assessment/studentAssessments", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (administrationDate != null)
                request.AddParameter("administrationDate", administrationDate);
            if (assessmentTitle != null)
                request.AddParameter("assessmentTitle", assessmentTitle);
            if (assessedGradeLevelDescriptor != null)
                request.AddParameter("assessedGradeLevelDescriptor", assessedGradeLevelDescriptor);
            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (version != null)
                request.AddParameter("version", version);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (fields != null)
                request.AddParameter("fields", fields);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<StudentAssessment>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Id&quot; pattern). This GET operation provides access to resources using the &quot;Get By Id&quot; pattern.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<StudentAssessment> GetStudentAssessmentsById(string id, string fields= null, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/assessment/studentAssessments/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (fields != null)
                request.AddParameter("fields", fields);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<StudentAssessment>(request);

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
        /// <param name="assessment_id">The unique identifier of the associated Assessment.</param>
        /// <param name="administrationDate">The month(s), day(s), and year on which an assessment is administered or first day of administration if over multiple days.</param>
        /// <param name="assessmentTitle">The title or name of the assessment.  NEDM: Assessment Title</param>
        /// <param name="assessedGradeLevelDescriptor">The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="academicSubjectDescriptor">The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject</param>
        /// <param name="version">The version identifier for the test assessment.  NEDM: Assessment Version</param>
        /// <param name="studentUniqueId">A unique number or alphanumeric code assigned to a student by a state education agency.</param>
        /// <param name="administrationEnvironmentType">The environment in which the test was administered.  For example:  Electronic  Classroom  Testing Center  ...  ....</param>
        /// <param name="eventCircumstanceType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="whenAssessedGradeLevelDescriptor">The grade level of a student when assessed.</param>
        /// <param name="administrationLanguageDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="reasonNotTestedType">The primary reason student is not tested. For example:  Absent  Refusal by parent  Refusal by student  Medical waiver  Illness  Disruptive behavior  LEP Exempt  ...</param>
        /// <param name="retestIndicatorType">Indicator if the test was retaken.  For example:  Primary administration  First retest  Second retest  ...</param>
        /// <param name="administrationEndDate">Assessment Administration End Date, if administered over multiple days.</param>
        /// <param name="serialNumber">The unique number for the assessment form or answer document.</param>
        /// <param name="eventDescription">Describes special events that occur before during or after the assessment session that may impact use of results.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StudentAssessment>> GetStudentAssessmentsByLocalEducationAgency(string localEducationAgency_id, int? offset= null, int? limit= null, string fields= null, string q= null, string assessment_id= null, DateTime? administrationDate= null, string assessmentTitle= null, string assessedGradeLevelDescriptor= null, string academicSubjectDescriptor= null, int? version= null, int? studentUniqueId= null, string administrationEnvironmentType= null, string eventCircumstanceType= null, string whenAssessedGradeLevelDescriptor= null, string administrationLanguageDescriptor= null, string reasonNotTestedType= null, string retestIndicatorType= null, DateTime? administrationEndDate= null, string serialNumber= null, string eventDescription= null, string id= null) 
        {
            var request = new RestRequest("/assessment/localEducationAgencies/{localEducationAgency_id}/studentAssessments", Method.GET);
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
            if (assessment_id != null)
                request.AddParameter("assessment_id", assessment_id);
            if (administrationDate != null)
                request.AddParameter("administrationDate", administrationDate);
            if (assessmentTitle != null)
                request.AddParameter("assessmentTitle", assessmentTitle);
            if (assessedGradeLevelDescriptor != null)
                request.AddParameter("assessedGradeLevelDescriptor", assessedGradeLevelDescriptor);
            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (version != null)
                request.AddParameter("version", version);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (administrationEnvironmentType != null)
                request.AddParameter("administrationEnvironmentType", administrationEnvironmentType);
            if (eventCircumstanceType != null)
                request.AddParameter("eventCircumstanceType", eventCircumstanceType);
            if (whenAssessedGradeLevelDescriptor != null)
                request.AddParameter("whenAssessedGradeLevelDescriptor", whenAssessedGradeLevelDescriptor);
            if (administrationLanguageDescriptor != null)
                request.AddParameter("administrationLanguageDescriptor", administrationLanguageDescriptor);
            if (reasonNotTestedType != null)
                request.AddParameter("reasonNotTestedType", reasonNotTestedType);
            if (retestIndicatorType != null)
                request.AddParameter("retestIndicatorType", retestIndicatorType);
            if (administrationEndDate != null)
                request.AddParameter("administrationEndDate", administrationEndDate);
            if (serialNumber != null)
                request.AddParameter("serialNumber", serialNumber);
            if (eventDescription != null)
                request.AddParameter("eventDescription", eventDescription);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<StudentAssessment>>(request);

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
        /// <param name="assessment_id">The unique identifier of the associated Assessment.</param>
        /// <param name="administrationDate">The month(s), day(s), and year on which an assessment is administered or first day of administration if over multiple days.</param>
        /// <param name="assessmentTitle">The title or name of the assessment.  NEDM: Assessment Title</param>
        /// <param name="assessedGradeLevelDescriptor">The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="academicSubjectDescriptor">The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject</param>
        /// <param name="version">The version identifier for the test assessment.  NEDM: Assessment Version</param>
        /// <param name="studentUniqueId">A unique number or alphanumeric code assigned to a student by a state education agency.</param>
        /// <param name="administrationEnvironmentType">The environment in which the test was administered.  For example:  Electronic  Classroom  Testing Center  ...  ....</param>
        /// <param name="eventCircumstanceType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="whenAssessedGradeLevelDescriptor">The grade level of a student when assessed.</param>
        /// <param name="administrationLanguageDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="reasonNotTestedType">The primary reason student is not tested. For example:  Absent  Refusal by parent  Refusal by student  Medical waiver  Illness  Disruptive behavior  LEP Exempt  ...</param>
        /// <param name="retestIndicatorType">Indicator if the test was retaken.  For example:  Primary administration  First retest  Second retest  ...</param>
        /// <param name="administrationEndDate">Assessment Administration End Date, if administered over multiple days.</param>
        /// <param name="serialNumber">The unique number for the assessment form or answer document.</param>
        /// <param name="eventDescription">Describes special events that occur before during or after the assessment session that may impact use of results.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StudentAssessment>> GetStudentAssessmentsBySchool(string school_id, int? offset= null, int? limit= null, string fields= null, string q= null, string assessment_id= null, DateTime? administrationDate= null, string assessmentTitle= null, string assessedGradeLevelDescriptor= null, string academicSubjectDescriptor= null, int? version= null, int? studentUniqueId= null, string administrationEnvironmentType= null, string eventCircumstanceType= null, string whenAssessedGradeLevelDescriptor= null, string administrationLanguageDescriptor= null, string reasonNotTestedType= null, string retestIndicatorType= null, DateTime? administrationEndDate= null, string serialNumber= null, string eventDescription= null, string id= null) 
        {
            var request = new RestRequest("/assessment/schools/{school_id}/studentAssessments", Method.GET);
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
            if (assessment_id != null)
                request.AddParameter("assessment_id", assessment_id);
            if (administrationDate != null)
                request.AddParameter("administrationDate", administrationDate);
            if (assessmentTitle != null)
                request.AddParameter("assessmentTitle", assessmentTitle);
            if (assessedGradeLevelDescriptor != null)
                request.AddParameter("assessedGradeLevelDescriptor", assessedGradeLevelDescriptor);
            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (version != null)
                request.AddParameter("version", version);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (administrationEnvironmentType != null)
                request.AddParameter("administrationEnvironmentType", administrationEnvironmentType);
            if (eventCircumstanceType != null)
                request.AddParameter("eventCircumstanceType", eventCircumstanceType);
            if (whenAssessedGradeLevelDescriptor != null)
                request.AddParameter("whenAssessedGradeLevelDescriptor", whenAssessedGradeLevelDescriptor);
            if (administrationLanguageDescriptor != null)
                request.AddParameter("administrationLanguageDescriptor", administrationLanguageDescriptor);
            if (reasonNotTestedType != null)
                request.AddParameter("reasonNotTestedType", reasonNotTestedType);
            if (retestIndicatorType != null)
                request.AddParameter("retestIndicatorType", retestIndicatorType);
            if (administrationEndDate != null)
                request.AddParameter("administrationEndDate", administrationEndDate);
            if (serialNumber != null)
                request.AddParameter("serialNumber", serialNumber);
            if (eventDescription != null)
                request.AddParameter("eventDescription", eventDescription);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<StudentAssessment>>(request);

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
        /// <param name="assessment_id">The unique identifier of the associated Assessment.</param>
        /// <param name="administrationDate">The month(s), day(s), and year on which an assessment is administered or first day of administration if over multiple days.</param>
        /// <param name="assessmentTitle">The title or name of the assessment.  NEDM: Assessment Title</param>
        /// <param name="assessedGradeLevelDescriptor">The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="academicSubjectDescriptor">The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject</param>
        /// <param name="version">The version identifier for the test assessment.  NEDM: Assessment Version</param>
        /// <param name="studentUniqueId">A unique number or alphanumeric code assigned to a student by a state education agency.</param>
        /// <param name="administrationEnvironmentType">The environment in which the test was administered.  For example:  Electronic  Classroom  Testing Center  ...  ....</param>
        /// <param name="eventCircumstanceType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="whenAssessedGradeLevelDescriptor">The grade level of a student when assessed.</param>
        /// <param name="administrationLanguageDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="reasonNotTestedType">The primary reason student is not tested. For example:  Absent  Refusal by parent  Refusal by student  Medical waiver  Illness  Disruptive behavior  LEP Exempt  ...</param>
        /// <param name="retestIndicatorType">Indicator if the test was retaken.  For example:  Primary administration  First retest  Second retest  ...</param>
        /// <param name="administrationEndDate">Assessment Administration End Date, if administered over multiple days.</param>
        /// <param name="serialNumber">The unique number for the assessment form or answer document.</param>
        /// <param name="eventDescription">Describes special events that occur before during or after the assessment session that may impact use of results.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StudentAssessment>> GetStudentAssessmentsByStaff(string staff_id, int? offset= null, int? limit= null, string fields= null, string q= null, string assessment_id= null, DateTime? administrationDate= null, string assessmentTitle= null, string assessedGradeLevelDescriptor= null, string academicSubjectDescriptor= null, int? version= null, int? studentUniqueId= null, string administrationEnvironmentType= null, string eventCircumstanceType= null, string whenAssessedGradeLevelDescriptor= null, string administrationLanguageDescriptor= null, string reasonNotTestedType= null, string retestIndicatorType= null, DateTime? administrationEndDate= null, string serialNumber= null, string eventDescription= null, string id= null) 
        {
            var request = new RestRequest("/assessment/staffs/{staff_id}/studentAssessments", Method.GET);
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
            if (assessment_id != null)
                request.AddParameter("assessment_id", assessment_id);
            if (administrationDate != null)
                request.AddParameter("administrationDate", administrationDate);
            if (assessmentTitle != null)
                request.AddParameter("assessmentTitle", assessmentTitle);
            if (assessedGradeLevelDescriptor != null)
                request.AddParameter("assessedGradeLevelDescriptor", assessedGradeLevelDescriptor);
            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (version != null)
                request.AddParameter("version", version);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (administrationEnvironmentType != null)
                request.AddParameter("administrationEnvironmentType", administrationEnvironmentType);
            if (eventCircumstanceType != null)
                request.AddParameter("eventCircumstanceType", eventCircumstanceType);
            if (whenAssessedGradeLevelDescriptor != null)
                request.AddParameter("whenAssessedGradeLevelDescriptor", whenAssessedGradeLevelDescriptor);
            if (administrationLanguageDescriptor != null)
                request.AddParameter("administrationLanguageDescriptor", administrationLanguageDescriptor);
            if (reasonNotTestedType != null)
                request.AddParameter("reasonNotTestedType", reasonNotTestedType);
            if (retestIndicatorType != null)
                request.AddParameter("retestIndicatorType", retestIndicatorType);
            if (administrationEndDate != null)
                request.AddParameter("administrationEndDate", administrationEndDate);
            if (serialNumber != null)
                request.AddParameter("serialNumber", serialNumber);
            if (eventDescription != null)
                request.AddParameter("eventDescription", eventDescription);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<StudentAssessment>>(request);

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
        /// <param name="assessment_id">The unique identifier of the associated Assessment.</param>
        /// <param name="administrationDate">The month(s), day(s), and year on which an assessment is administered or first day of administration if over multiple days.</param>
        /// <param name="assessmentTitle">The title or name of the assessment.  NEDM: Assessment Title</param>
        /// <param name="assessedGradeLevelDescriptor">The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="academicSubjectDescriptor">The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject</param>
        /// <param name="version">The version identifier for the test assessment.  NEDM: Assessment Version</param>
        /// <param name="studentUniqueId">A unique number or alphanumeric code assigned to a student by a state education agency.</param>
        /// <param name="administrationEnvironmentType">The environment in which the test was administered.  For example:  Electronic  Classroom  Testing Center  ...  ....</param>
        /// <param name="eventCircumstanceType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="whenAssessedGradeLevelDescriptor">The grade level of a student when assessed.</param>
        /// <param name="administrationLanguageDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="reasonNotTestedType">The primary reason student is not tested. For example:  Absent  Refusal by parent  Refusal by student  Medical waiver  Illness  Disruptive behavior  LEP Exempt  ...</param>
        /// <param name="retestIndicatorType">Indicator if the test was retaken.  For example:  Primary administration  First retest  Second retest  ...</param>
        /// <param name="administrationEndDate">Assessment Administration End Date, if administered over multiple days.</param>
        /// <param name="serialNumber">The unique number for the assessment form or answer document.</param>
        /// <param name="eventDescription">Describes special events that occur before during or after the assessment session that may impact use of results.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StudentAssessment>> GetStudentAssessmentsBySection(string section_id, int? offset= null, int? limit= null, string fields= null, string q= null, string assessment_id= null, DateTime? administrationDate= null, string assessmentTitle= null, string assessedGradeLevelDescriptor= null, string academicSubjectDescriptor= null, int? version= null, int? studentUniqueId= null, string administrationEnvironmentType= null, string eventCircumstanceType= null, string whenAssessedGradeLevelDescriptor= null, string administrationLanguageDescriptor= null, string reasonNotTestedType= null, string retestIndicatorType= null, DateTime? administrationEndDate= null, string serialNumber= null, string eventDescription= null, string id= null) 
        {
            var request = new RestRequest("/assessment/sections/{section_id}/studentAssessments", Method.GET);
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
            if (assessment_id != null)
                request.AddParameter("assessment_id", assessment_id);
            if (administrationDate != null)
                request.AddParameter("administrationDate", administrationDate);
            if (assessmentTitle != null)
                request.AddParameter("assessmentTitle", assessmentTitle);
            if (assessedGradeLevelDescriptor != null)
                request.AddParameter("assessedGradeLevelDescriptor", assessedGradeLevelDescriptor);
            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (version != null)
                request.AddParameter("version", version);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (administrationEnvironmentType != null)
                request.AddParameter("administrationEnvironmentType", administrationEnvironmentType);
            if (eventCircumstanceType != null)
                request.AddParameter("eventCircumstanceType", eventCircumstanceType);
            if (whenAssessedGradeLevelDescriptor != null)
                request.AddParameter("whenAssessedGradeLevelDescriptor", whenAssessedGradeLevelDescriptor);
            if (administrationLanguageDescriptor != null)
                request.AddParameter("administrationLanguageDescriptor", administrationLanguageDescriptor);
            if (reasonNotTestedType != null)
                request.AddParameter("reasonNotTestedType", reasonNotTestedType);
            if (retestIndicatorType != null)
                request.AddParameter("retestIndicatorType", retestIndicatorType);
            if (administrationEndDate != null)
                request.AddParameter("administrationEndDate", administrationEndDate);
            if (serialNumber != null)
                request.AddParameter("serialNumber", serialNumber);
            if (eventDescription != null)
                request.AddParameter("eventDescription", eventDescription);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<StudentAssessment>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated Program resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="program_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="assessment_id">The unique identifier of the associated Assessment.</param>
        /// <param name="administrationDate">The month(s), day(s), and year on which an assessment is administered or first day of administration if over multiple days.</param>
        /// <param name="assessmentTitle">The title or name of the assessment.  NEDM: Assessment Title</param>
        /// <param name="assessedGradeLevelDescriptor">The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="academicSubjectDescriptor">The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject</param>
        /// <param name="version">The version identifier for the test assessment.  NEDM: Assessment Version</param>
        /// <param name="studentUniqueId">A unique number or alphanumeric code assigned to a student by a state education agency.</param>
        /// <param name="administrationEnvironmentType">The environment in which the test was administered.  For example:  Electronic  Classroom  Testing Center  ...  ....</param>
        /// <param name="eventCircumstanceType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="whenAssessedGradeLevelDescriptor">The grade level of a student when assessed.</param>
        /// <param name="administrationLanguageDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="reasonNotTestedType">The primary reason student is not tested. For example:  Absent  Refusal by parent  Refusal by student  Medical waiver  Illness  Disruptive behavior  LEP Exempt  ...</param>
        /// <param name="retestIndicatorType">Indicator if the test was retaken.  For example:  Primary administration  First retest  Second retest  ...</param>
        /// <param name="administrationEndDate">Assessment Administration End Date, if administered over multiple days.</param>
        /// <param name="serialNumber">The unique number for the assessment form or answer document.</param>
        /// <param name="eventDescription">Describes special events that occur before during or after the assessment session that may impact use of results.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StudentAssessment>> GetStudentAssessmentsByProgram(string program_id, int? offset= null, int? limit= null, string fields= null, string q= null, string assessment_id= null, DateTime? administrationDate= null, string assessmentTitle= null, string assessedGradeLevelDescriptor= null, string academicSubjectDescriptor= null, int? version= null, int? studentUniqueId= null, string administrationEnvironmentType= null, string eventCircumstanceType= null, string whenAssessedGradeLevelDescriptor= null, string administrationLanguageDescriptor= null, string reasonNotTestedType= null, string retestIndicatorType= null, DateTime? administrationEndDate= null, string serialNumber= null, string eventDescription= null, string id= null) 
        {
            var request = new RestRequest("/assessment/programs/{program_id}/studentAssessments", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("program_id", program_id);
            // verify required params are set
            if (program_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (assessment_id != null)
                request.AddParameter("assessment_id", assessment_id);
            if (administrationDate != null)
                request.AddParameter("administrationDate", administrationDate);
            if (assessmentTitle != null)
                request.AddParameter("assessmentTitle", assessmentTitle);
            if (assessedGradeLevelDescriptor != null)
                request.AddParameter("assessedGradeLevelDescriptor", assessedGradeLevelDescriptor);
            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (version != null)
                request.AddParameter("version", version);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (administrationEnvironmentType != null)
                request.AddParameter("administrationEnvironmentType", administrationEnvironmentType);
            if (eventCircumstanceType != null)
                request.AddParameter("eventCircumstanceType", eventCircumstanceType);
            if (whenAssessedGradeLevelDescriptor != null)
                request.AddParameter("whenAssessedGradeLevelDescriptor", whenAssessedGradeLevelDescriptor);
            if (administrationLanguageDescriptor != null)
                request.AddParameter("administrationLanguageDescriptor", administrationLanguageDescriptor);
            if (reasonNotTestedType != null)
                request.AddParameter("reasonNotTestedType", reasonNotTestedType);
            if (retestIndicatorType != null)
                request.AddParameter("retestIndicatorType", retestIndicatorType);
            if (administrationEndDate != null)
                request.AddParameter("administrationEndDate", administrationEndDate);
            if (serialNumber != null)
                request.AddParameter("serialNumber", serialNumber);
            if (eventDescription != null)
                request.AddParameter("eventDescription", eventDescription);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<StudentAssessment>>(request);

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
        /// <param name="assessment_id">The unique identifier of the associated Assessment.</param>
        /// <param name="administrationDate">The month(s), day(s), and year on which an assessment is administered or first day of administration if over multiple days.</param>
        /// <param name="assessmentTitle">The title or name of the assessment.  NEDM: Assessment Title</param>
        /// <param name="assessedGradeLevelDescriptor">The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="academicSubjectDescriptor">The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject</param>
        /// <param name="version">The version identifier for the test assessment.  NEDM: Assessment Version</param>
        /// <param name="studentUniqueId">A unique number or alphanumeric code assigned to a student by a state education agency.</param>
        /// <param name="administrationEnvironmentType">The environment in which the test was administered.  For example:  Electronic  Classroom  Testing Center  ...  ....</param>
        /// <param name="eventCircumstanceType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="whenAssessedGradeLevelDescriptor">The grade level of a student when assessed.</param>
        /// <param name="administrationLanguageDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="reasonNotTestedType">The primary reason student is not tested. For example:  Absent  Refusal by parent  Refusal by student  Medical waiver  Illness  Disruptive behavior  LEP Exempt  ...</param>
        /// <param name="retestIndicatorType">Indicator if the test was retaken.  For example:  Primary administration  First retest  Second retest  ...</param>
        /// <param name="administrationEndDate">Assessment Administration End Date, if administered over multiple days.</param>
        /// <param name="serialNumber">The unique number for the assessment form or answer document.</param>
        /// <param name="eventDescription">Describes special events that occur before during or after the assessment session that may impact use of results.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StudentAssessment>> GetStudentAssessmentsByStudent(string student_id, int? offset= null, int? limit= null, string fields= null, string q= null, string assessment_id= null, DateTime? administrationDate= null, string assessmentTitle= null, string assessedGradeLevelDescriptor= null, string academicSubjectDescriptor= null, int? version= null, int? studentUniqueId= null, string administrationEnvironmentType= null, string eventCircumstanceType= null, string whenAssessedGradeLevelDescriptor= null, string administrationLanguageDescriptor= null, string reasonNotTestedType= null, string retestIndicatorType= null, DateTime? administrationEndDate= null, string serialNumber= null, string eventDescription= null, string id= null) 
        {
            var request = new RestRequest("/assessment/students/{student_id}/studentAssessments", Method.GET);
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
            if (assessment_id != null)
                request.AddParameter("assessment_id", assessment_id);
            if (administrationDate != null)
                request.AddParameter("administrationDate", administrationDate);
            if (assessmentTitle != null)
                request.AddParameter("assessmentTitle", assessmentTitle);
            if (assessedGradeLevelDescriptor != null)
                request.AddParameter("assessedGradeLevelDescriptor", assessedGradeLevelDescriptor);
            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (version != null)
                request.AddParameter("version", version);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (administrationEnvironmentType != null)
                request.AddParameter("administrationEnvironmentType", administrationEnvironmentType);
            if (eventCircumstanceType != null)
                request.AddParameter("eventCircumstanceType", eventCircumstanceType);
            if (whenAssessedGradeLevelDescriptor != null)
                request.AddParameter("whenAssessedGradeLevelDescriptor", whenAssessedGradeLevelDescriptor);
            if (administrationLanguageDescriptor != null)
                request.AddParameter("administrationLanguageDescriptor", administrationLanguageDescriptor);
            if (reasonNotTestedType != null)
                request.AddParameter("reasonNotTestedType", reasonNotTestedType);
            if (retestIndicatorType != null)
                request.AddParameter("retestIndicatorType", retestIndicatorType);
            if (administrationEndDate != null)
                request.AddParameter("administrationEndDate", administrationEndDate);
            if (serialNumber != null)
                request.AddParameter("serialNumber", serialNumber);
            if (eventDescription != null)
                request.AddParameter("eventDescription", eventDescription);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<StudentAssessment>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources using the associated Assessment resource's identifier (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using a filtered &quot;Get By Example&quot; pattern.
        /// </summary>
        /// <param name="assessment_id"></param>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="fields">Specifies a subset of properties that should be returned for each entity (e.g. &quot;property1,collection1(collProp1,collProp2)&quot;).</param>
        /// <param name="q">Specifies a query filter expression for the request.  Currently only supports range-based queries on dates and numbers (e.g. &quot;[2016-03-07..2016-03-10]&quot;).</param>
        /// <param name="administrationDate">The month(s), day(s), and year on which an assessment is administered or first day of administration if over multiple days.</param>
        /// <param name="assessmentTitle">The title or name of the assessment.  NEDM: Assessment Title</param>
        /// <param name="assessedGradeLevelDescriptor">The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="academicSubjectDescriptor">The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject</param>
        /// <param name="version">The version identifier for the test assessment.  NEDM: Assessment Version</param>
        /// <param name="studentUniqueId">A unique number or alphanumeric code assigned to a student by a state education agency.</param>
        /// <param name="administrationEnvironmentType">The environment in which the test was administered.  For example:  Electronic  Classroom  Testing Center  ...  ....</param>
        /// <param name="eventCircumstanceType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="whenAssessedGradeLevelDescriptor">The grade level of a student when assessed.</param>
        /// <param name="administrationLanguageDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="reasonNotTestedType">The primary reason student is not tested. For example:  Absent  Refusal by parent  Refusal by student  Medical waiver  Illness  Disruptive behavior  LEP Exempt  ...</param>
        /// <param name="retestIndicatorType">Indicator if the test was retaken.  For example:  Primary administration  First retest  Second retest  ...</param>
        /// <param name="administrationEndDate">Assessment Administration End Date, if administered over multiple days.</param>
        /// <param name="serialNumber">The unique number for the assessment form or answer document.</param>
        /// <param name="eventDescription">Describes special events that occur before during or after the assessment session that may impact use of results.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StudentAssessment>> GetStudentAssessmentsByAssessment(string assessment_id, int? offset= null, int? limit= null, string fields= null, string q= null, DateTime? administrationDate= null, string assessmentTitle= null, string assessedGradeLevelDescriptor= null, string academicSubjectDescriptor= null, int? version= null, int? studentUniqueId= null, string administrationEnvironmentType= null, string eventCircumstanceType= null, string whenAssessedGradeLevelDescriptor= null, string administrationLanguageDescriptor= null, string reasonNotTestedType= null, string retestIndicatorType= null, DateTime? administrationEndDate= null, string serialNumber= null, string eventDescription= null, string id= null) 
        {
            var request = new RestRequest("/assessment/assessments/{assessment_id}/studentAssessments", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("assessment_id", assessment_id);
            // verify required params are set
            if (assessment_id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (fields != null)
                request.AddParameter("fields", fields);
            if (q != null)
                request.AddParameter("q", q);
            if (administrationDate != null)
                request.AddParameter("administrationDate", administrationDate);
            if (assessmentTitle != null)
                request.AddParameter("assessmentTitle", assessmentTitle);
            if (assessedGradeLevelDescriptor != null)
                request.AddParameter("assessedGradeLevelDescriptor", assessedGradeLevelDescriptor);
            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (version != null)
                request.AddParameter("version", version);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (administrationEnvironmentType != null)
                request.AddParameter("administrationEnvironmentType", administrationEnvironmentType);
            if (eventCircumstanceType != null)
                request.AddParameter("eventCircumstanceType", eventCircumstanceType);
            if (whenAssessedGradeLevelDescriptor != null)
                request.AddParameter("whenAssessedGradeLevelDescriptor", whenAssessedGradeLevelDescriptor);
            if (administrationLanguageDescriptor != null)
                request.AddParameter("administrationLanguageDescriptor", administrationLanguageDescriptor);
            if (reasonNotTestedType != null)
                request.AddParameter("reasonNotTestedType", reasonNotTestedType);
            if (retestIndicatorType != null)
                request.AddParameter("retestIndicatorType", retestIndicatorType);
            if (administrationEndDate != null)
                request.AddParameter("administrationEndDate", administrationEndDate);
            if (serialNumber != null)
                request.AddParameter("serialNumber", serialNumber);
            if (eventDescription != null)
                request.AddParameter("eventDescription", eventDescription);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<StudentAssessment>>(request);

            return response;
        }
        }
    }

