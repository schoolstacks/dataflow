using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.OdsApi.Sdk;
using EdFi.OdsApi.Models.Resources;
using RestSharp;
  
namespace EdFi.OdsApi.Api.Resources 
{
    public class StaffEducationOrganizationEmploymentAssociationsApi 
    {
        private readonly IRestClient client;

        public StaffEducationOrganizationEmploymentAssociationsApi(IRestClient client)
        {
            this.client = client;
        }
      
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StaffEducationOrganizationEmploymentAssociation>> GetStaffEducationOrganizationEmploymentAssociationsAll(int? offset= null, int? limit= null) 
        {
            var request = new RestRequest("/staffEducationOrganizationEmploymentAssociations", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            var response = client.Execute<List<StaffEducationOrganizationEmploymentAssociation>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources matching values of an example resource (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get by Example&quot; search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="educationOrganizationId">EducationOrganization Identity Column</param>
        /// <param name="staffUniqueId">A unique alpha-numeric code assigned to a staff.</param>
        /// <param name="employmentStatusDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="hireDate">The month, day, and year on which an individual was hired for a position.</param>
        /// <param name="endDate">The month, day, and year on which a contract between an individual and a governing authority ends or is terminated under the provisions of the contract (or the date on which the agreement is made invalid).</param>
        /// <param name="separationType">Type of employment separation; for example:  Voluntary separation  Involuntary separation  Mutual agreement  Other</param>
        /// <param name="separationReasonDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="department">The department or suborganization the employee/contractor is associated with in the Education Organization.</param>
        /// <param name="fullTimeEquivalency">The ratio between the hours of work expected in a position and the hours of work normally expected in a full-time position in the same setting.</param>
        /// <param name="offerDate">Date at which the staff member was made an official offer for this employment.</param>
        /// <param name="hourlyWage">Hourly wage associated with the employment position being reported.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StaffEducationOrganizationEmploymentAssociation>> GetStaffEducationOrganizationEmploymentAssociationsAll(int? offset= null, int? limit= null, int? educationOrganizationId= null, string staffUniqueId= null, string employmentStatusDescriptor= null, DateTime? hireDate= null, DateTime? endDate= null, string separationType= null, string separationReasonDescriptor= null, string department= null, double? fullTimeEquivalency= null, DateTime? offerDate= null, double? hourlyWage= null, string id= null) 
        {
            var request = new RestRequest("/staffEducationOrganizationEmploymentAssociations", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (educationOrganizationId != null)
                request.AddParameter("educationOrganizationId", educationOrganizationId);
            if (staffUniqueId != null)
                request.AddParameter("staffUniqueId", staffUniqueId);
            if (employmentStatusDescriptor != null)
                request.AddParameter("employmentStatusDescriptor", employmentStatusDescriptor);
            if (hireDate != null)
                request.AddParameter("hireDate", hireDate);
            if (endDate != null)
                request.AddParameter("endDate", endDate);
            if (separationType != null)
                request.AddParameter("separationType", separationType);
            if (separationReasonDescriptor != null)
                request.AddParameter("separationReasonDescriptor", separationReasonDescriptor);
            if (department != null)
                request.AddParameter("department", department);
            if (fullTimeEquivalency != null)
                request.AddParameter("fullTimeEquivalency", fullTimeEquivalency);
            if (offerDate != null)
                request.AddParameter("offerDate", offerDate);
            if (hourlyWage != null)
                request.AddParameter("hourlyWage", hourlyWage);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<StaffEducationOrganizationEmploymentAssociation>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the values of the resource's natural key (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get by Key&quot; search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="educationOrganizationId">EducationOrganization Identity Column</param>
        /// <param name="staffUniqueId">A unique alpha-numeric code assigned to a staff.</param>
        /// <param name="employmentStatusDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="hireDate">The month, day, and year on which an individual was hired for a position.</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<StaffEducationOrganizationEmploymentAssociation> GetStaffEducationOrganizationEmploymentAssociationByKey(int? educationOrganizationId, string staffUniqueId, string employmentStatusDescriptor, DateTime? hireDate, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/staffEducationOrganizationEmploymentAssociations", Method.GET);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (educationOrganizationId == null || staffUniqueId == null || employmentStatusDescriptor == null || hireDate == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (educationOrganizationId != null)
                request.AddParameter("educationOrganizationId", educationOrganizationId);
            if (staffUniqueId != null)
                request.AddParameter("staffUniqueId", staffUniqueId);
            if (employmentStatusDescriptor != null)
                request.AddParameter("employmentStatusDescriptor", employmentStatusDescriptor);
            if (hireDate != null)
                request.AddParameter("hireDate", hireDate);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<StaffEducationOrganizationEmploymentAssociation>(request);

            return response;
        }
        /// <summary>
        /// Creates or updates resources based on the natural key values of the supplied resource. The POST operation can be used to create or update resources. In database terms, this is often referred to as an &quot;upsert&quot; operation (insert + update).  Clients should NOT include the resource &quot;id&quot; in the JSON body because it will result in an error (you must use a PUT operation to update a resource by &quot;id&quot;). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.
        /// </summary>
        /// <param name="body">The JSON representation of the &quot;staffEducationOrganizationEmploymentAssociation&quot; resource to be created or updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PostStaffEducationOrganizationEmploymentAssociations(StaffEducationOrganizationEmploymentAssociation body) 
        {
            var request = new RestRequest("/staffEducationOrganizationEmploymentAssociations", Method.POST);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (body == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddBody(body);
            var response = client.Execute(request);

            var location = response.Headers.FirstOrDefault(x => x.Name == "Location");

            if (location != null && !string.IsNullOrWhiteSpace(location.Value.ToString()))
                body.id = location.Value.ToString().Split('/').Last();
            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Id&quot; pattern). This GET operation retrieves a resource by the specified resource identifier.
        /// </summary>
        /// <param name="id">A resource identifier specifying the resource to be retrieved.</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<StaffEducationOrganizationEmploymentAssociation> GetStaffEducationOrganizationEmploymentAssociationsById(string id, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/staffEducationOrganizationEmploymentAssociations/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<StaffEducationOrganizationEmploymentAssociation>(request);

            return response;
        }
        /// <summary>
        /// Updates or creates a resource based on the resource identifier. The PUT operation is used to update or create a resource by identifier.  If the resource doesn't exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource &quot;id&quot; is provided in the JSON body, it will be ignored as well.
        /// </summary>
        /// <param name="id">A resource identifier specifying the resource to be updated.</param>
        /// <param name="IfMatch">The ETag header value used to prevent the PUT from updating a resource modified by another consumer.</param>
        /// <param name="body">The JSON representation of the &quot;staffEducationOrganizationEmploymentAssociation&quot; resource to be updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PutStaffEducationOrganizationEmploymentAssociation(string id, string IfMatch, StaffEducationOrganizationEmploymentAssociation body) 
        {
            var request = new RestRequest("/staffEducationOrganizationEmploymentAssociations/{id}", Method.PUT);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null || body == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("If-Match", IfMatch);
            request.AddBody(body);
            var response = client.Execute(request);

            var location = response.Headers.FirstOrDefault(x => x.Name == "Location");

            if (location != null && !string.IsNullOrWhiteSpace(location.Value.ToString()))
                body.id = location.Value.ToString().Split('/').Last();
            return response;
        }
        /// <summary>
        /// Deletes an existing resource using the resource identifier. The DELETE operation is used to delete an existing resource by identifier.  If the resource doesn't exist, an error will result (the resource will not be found).
        /// </summary>
        /// <param name="id">A resource identifier specifying the resource to be deleted.</param>
        /// <param name="IfMatch">The ETag header value used to prevent the DELETE from removing a resource modified by another consumer.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse DeleteStaffEducationOrganizationEmploymentAssociationById(string id, string IfMatch= null) 
        {
            var request = new RestRequest("/staffEducationOrganizationEmploymentAssociations/{id}", Method.DELETE);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("If-Match", IfMatch);
            var response = client.Execute(request);

            return response;
        }
        }
    }

