using System;
using System.Collections.Generic;
using System.Linq;
using DataFlow.EdFi.Models.Resources;
using RestSharp;

namespace DataFlow.EdFi.Api.Resources 
{
    public class StaffEducationOrganizationAssignmentAssociationsApi 
    {
        private readonly IRestClient client;

        public StaffEducationOrganizationAssignmentAssociationsApi(IRestClient client)
        {
            this.client = client;
        }
      
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StaffEducationOrganizationAssignmentAssociation>> GetStaffEducationOrganizationAssignmentAssociationsAll(int? offset= null, int? limit= null) 
        {
            var request = new RestRequest("/staffEducationOrganizationAssignmentAssociations", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            var response = client.Execute<List<StaffEducationOrganizationAssignmentAssociation>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources matching values of an example resource (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get by Example&quot; search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="staffUniqueId">A unique alpha-numeric code assigned to a staff.</param>
        /// <param name="educationOrganizationId">EducationOrganization Identity Column</param>
        /// <param name="staffClassificationDescriptor">The titles of employment, official status, or rank of education staff.</param>
        /// <param name="beginDate">Month, day, and year of the start or effective date of a staff member's employment, contract, or relationship with the LEA.</param>
        /// <param name="positionTitle">The descriptive name of an individual's position.</param>
        /// <param name="endDate">Month, day, and year of the end or termination date of a staff member's employment, contract, or relationship with the LEA.</param>
        /// <param name="orderOfAssignment">Describes whether the assignment is this the staff member's primary assignment, secondary assignment, etc.</param>
        /// <param name="employmentEducationOrganizationId">EducationOrganization Identity Column</param>
        /// <param name="employmentStatusDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="employmentHireDate">The month, day, and year on which an individual was hired for a position.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StaffEducationOrganizationAssignmentAssociation>> GetStaffEducationOrganizationAssignmentAssociationsAll(int? offset= null, int? limit= null, string staffUniqueId= null, int? educationOrganizationId= null, string staffClassificationDescriptor= null, DateTime? beginDate= null, string positionTitle= null, DateTime? endDate= null, int? orderOfAssignment= null, int? employmentEducationOrganizationId= null, string employmentStatusDescriptor= null, DateTime? employmentHireDate= null, string id= null) 
        {
            var request = new RestRequest("/staffEducationOrganizationAssignmentAssociations", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (staffUniqueId != null)
                request.AddParameter("staffUniqueId", staffUniqueId);
            if (educationOrganizationId != null)
                request.AddParameter("educationOrganizationId", educationOrganizationId);
            if (staffClassificationDescriptor != null)
                request.AddParameter("staffClassificationDescriptor", staffClassificationDescriptor);
            if (beginDate != null)
                request.AddParameter("beginDate", beginDate);
            if (positionTitle != null)
                request.AddParameter("positionTitle", positionTitle);
            if (endDate != null)
                request.AddParameter("endDate", endDate);
            if (orderOfAssignment != null)
                request.AddParameter("orderOfAssignment", orderOfAssignment);
            if (employmentEducationOrganizationId != null)
                request.AddParameter("employmentEducationOrganizationId", employmentEducationOrganizationId);
            if (employmentStatusDescriptor != null)
                request.AddParameter("employmentStatusDescriptor", employmentStatusDescriptor);
            if (employmentHireDate != null)
                request.AddParameter("employmentHireDate", employmentHireDate);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<StaffEducationOrganizationAssignmentAssociation>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the values of the resource's natural key (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get by Key&quot; search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="staffUniqueId">A unique alpha-numeric code assigned to a staff.</param>
        /// <param name="educationOrganizationId">EducationOrganization Identity Column</param>
        /// <param name="staffClassificationDescriptor">The titles of employment, official status, or rank of education staff.</param>
        /// <param name="beginDate">Month, day, and year of the start or effective date of a staff member's employment, contract, or relationship with the LEA.</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<StaffEducationOrganizationAssignmentAssociation> GetStaffEducationOrganizationAssignmentAssociationByKey(string staffUniqueId, int? educationOrganizationId, string staffClassificationDescriptor, DateTime? beginDate, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/staffEducationOrganizationAssignmentAssociations", Method.GET);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (staffUniqueId == null || educationOrganizationId == null || staffClassificationDescriptor == null || beginDate == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (staffUniqueId != null)
                request.AddParameter("staffUniqueId", staffUniqueId);
            if (educationOrganizationId != null)
                request.AddParameter("educationOrganizationId", educationOrganizationId);
            if (staffClassificationDescriptor != null)
                request.AddParameter("staffClassificationDescriptor", staffClassificationDescriptor);
            if (beginDate != null)
                request.AddParameter("beginDate", beginDate);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<StaffEducationOrganizationAssignmentAssociation>(request);

            return response;
        }
        /// <summary>
        /// Creates or updates resources based on the natural key values of the supplied resource. The POST operation can be used to create or update resources. In database terms, this is often referred to as an &quot;upsert&quot; operation (insert + update).  Clients should NOT include the resource &quot;id&quot; in the JSON body because it will result in an error (you must use a PUT operation to update a resource by &quot;id&quot;). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.
        /// </summary>
        /// <param name="body">The JSON representation of the &quot;staffEducationOrganizationAssignmentAssociation&quot; resource to be created or updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PostStaffEducationOrganizationAssignmentAssociations(StaffEducationOrganizationAssignmentAssociation body) 
        {
            var request = new RestRequest("/staffEducationOrganizationAssignmentAssociations", Method.POST);
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
        public IRestResponse<StaffEducationOrganizationAssignmentAssociation> GetStaffEducationOrganizationAssignmentAssociationsById(string id, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/staffEducationOrganizationAssignmentAssociations/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<StaffEducationOrganizationAssignmentAssociation>(request);

            return response;
        }
        /// <summary>
        /// Updates or creates a resource based on the resource identifier. The PUT operation is used to update or create a resource by identifier.  If the resource doesn't exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource &quot;id&quot; is provided in the JSON body, it will be ignored as well.
        /// </summary>
        /// <param name="id">A resource identifier specifying the resource to be updated.</param>
        /// <param name="IfMatch">The ETag header value used to prevent the PUT from updating a resource modified by another consumer.</param>
        /// <param name="body">The JSON representation of the &quot;staffEducationOrganizationAssignmentAssociation&quot; resource to be updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PutStaffEducationOrganizationAssignmentAssociation(string id, string IfMatch, StaffEducationOrganizationAssignmentAssociation body) 
        {
            var request = new RestRequest("/staffEducationOrganizationAssignmentAssociations/{id}", Method.PUT);
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
        public IRestResponse DeleteStaffEducationOrganizationAssignmentAssociationById(string id, string IfMatch= null) 
        {
            var request = new RestRequest("/staffEducationOrganizationAssignmentAssociations/{id}", Method.DELETE);
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

