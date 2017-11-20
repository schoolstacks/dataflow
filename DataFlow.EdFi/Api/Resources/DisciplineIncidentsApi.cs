using System;
using System.Collections.Generic;
using System.Linq;
using DataFlow.EdFi.Models.Resources;
using RestSharp;

namespace DataFlow.EdFi.Api.Resources 
{
    public class DisciplineIncidentsApi 
    {
        private readonly IRestClient client;

        public DisciplineIncidentsApi(IRestClient client)
        {
            this.client = client;
        }
      
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<DisciplineIncident>> GetDisciplineIncidentsAll(int? offset= null, int? limit= null) 
        {
            var request = new RestRequest("/disciplineIncidents", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            var response = client.Execute<List<DisciplineIncident>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources matching values of an example resource (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get by Example&quot; search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="incidentIdentifier">A locally assigned unique identifier (within the school or school district) to identify each specific incident or occurrence. The same identifier should be used to document the entire incident even if it included multiple offenses and multiple offenders.</param>
        /// <param name="schoolId">School Identity Column</param>
        /// <param name="incidentDate">The month, day, and year on which the DisciplineIncident occurred.</param>
        /// <param name="incidentTime">An indication of the time of day the incident took place.</param>
        /// <param name="incidentLocationType">Identifies where the incident occurred and whether or not it occurred on campus, for example:  On campus  Administrative offices area  Cafeteria area  Classroom  Hallway or stairs  ...</param>
        /// <param name="incidentDescription">The description for an incident.</param>
        /// <param name="reporterDescriptionDescriptor">Information on the type of individual who reported the incident. When known and/or if useful, use a more specific option code (e.g., &quot;Counselor&quot; rather than &quot;Professional Staff&quot;); for example:Student  Parent/guardian  Law enforcement officer  Nonschool personnel  Representative of visiting school  ...</param>
        /// <param name="reporterName">Identifies the reporter of the incident by name.</param>
        /// <param name="reportedToLawEnforcement">Indicator of whether the incident was reported to law enforcement.</param>
        /// <param name="caseNumber">The case number assigned to the incident by law enforcement or other organization.</param>
        /// <param name="incidentCost">The value of any quantifiable monetary loss directly resulting from the DisciplineIncident. Examples include the value of repairs necessitated by vandalism of a school facility, or the value of personnel resources used for repairs or consumed by the incident.</param>
        /// <param name="staffUniqueId">A unique alpha-numeric code assigned to a staff.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<DisciplineIncident>> GetDisciplineIncidentsAll(int? offset= null, int? limit= null, string incidentIdentifier= null, int? schoolId= null, DateTime? incidentDate= null, string incidentTime= null, string incidentLocationType= null, string incidentDescription= null, string reporterDescriptionDescriptor= null, string reporterName= null, bool? reportedToLawEnforcement= null, string caseNumber= null, double? incidentCost= null, string staffUniqueId= null, string id= null) 
        {
            var request = new RestRequest("/disciplineIncidents", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (incidentIdentifier != null)
                request.AddParameter("incidentIdentifier", incidentIdentifier);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (incidentDate != null)
                request.AddParameter("incidentDate", incidentDate);
            if (incidentTime != null)
                request.AddParameter("incidentTime", incidentTime);
            if (incidentLocationType != null)
                request.AddParameter("incidentLocationType", incidentLocationType);
            if (incidentDescription != null)
                request.AddParameter("incidentDescription", incidentDescription);
            if (reporterDescriptionDescriptor != null)
                request.AddParameter("reporterDescriptionDescriptor", reporterDescriptionDescriptor);
            if (reporterName != null)
                request.AddParameter("reporterName", reporterName);
            if (reportedToLawEnforcement != null)
                request.AddParameter("reportedToLawEnforcement", reportedToLawEnforcement);
            if (caseNumber != null)
                request.AddParameter("caseNumber", caseNumber);
            if (incidentCost != null)
                request.AddParameter("incidentCost", incidentCost);
            if (staffUniqueId != null)
                request.AddParameter("staffUniqueId", staffUniqueId);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<DisciplineIncident>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the values of the resource's natural key (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get by Key&quot; search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="incidentIdentifier">A locally assigned unique identifier (within the school or school district) to identify each specific incident or occurrence. The same identifier should be used to document the entire incident even if it included multiple offenses and multiple offenders.</param>
        /// <param name="schoolId">School Identity Column</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<DisciplineIncident> GetDisciplineIncidentByKey(string incidentIdentifier, int? schoolId, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/disciplineIncidents", Method.GET);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (incidentIdentifier == null || schoolId == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (incidentIdentifier != null)
                request.AddParameter("incidentIdentifier", incidentIdentifier);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<DisciplineIncident>(request);

            return response;
        }
        /// <summary>
        /// Creates or updates resources based on the natural key values of the supplied resource. The POST operation can be used to create or update resources. In database terms, this is often referred to as an &quot;upsert&quot; operation (insert + update).  Clients should NOT include the resource &quot;id&quot; in the JSON body because it will result in an error (you must use a PUT operation to update a resource by &quot;id&quot;). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.
        /// </summary>
        /// <param name="body">The JSON representation of the &quot;disciplineIncident&quot; resource to be created or updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PostDisciplineIncidents(DisciplineIncident body) 
        {
            var request = new RestRequest("/disciplineIncidents", Method.POST);
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
        public IRestResponse<DisciplineIncident> GetDisciplineIncidentsById(string id, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/disciplineIncidents/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<DisciplineIncident>(request);

            return response;
        }
        /// <summary>
        /// Updates or creates a resource based on the resource identifier. The PUT operation is used to update or create a resource by identifier.  If the resource doesn't exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource &quot;id&quot; is provided in the JSON body, it will be ignored as well.
        /// </summary>
        /// <param name="id">A resource identifier specifying the resource to be updated.</param>
        /// <param name="IfMatch">The ETag header value used to prevent the PUT from updating a resource modified by another consumer.</param>
        /// <param name="body">The JSON representation of the &quot;disciplineIncident&quot; resource to be updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PutDisciplineIncident(string id, string IfMatch, DisciplineIncident body) 
        {
            var request = new RestRequest("/disciplineIncidents/{id}", Method.PUT);
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
        public IRestResponse DeleteDisciplineIncidentById(string id, string IfMatch= null) 
        {
            var request = new RestRequest("/disciplineIncidents/{id}", Method.DELETE);
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

