/*    ==Scripting Parameters==

    Source Database Engine Edition : Microsoft Azure SQL Database Edition
    Source Database Engine Type : Microsoft Azure SQL Database

    Target Database Engine Edition : Microsoft Azure SQL Database Edition
    Target Database Engine Type : Microsoft Azure SQL Database
*/
SET IDENTITY_INSERT [dataflow].[entity] ON 

INSERT [dataflow].[entity] ([ID], [Name], [Namespace], [URL], [Family], [Metadata], [CreateDate], [UpdateDate]) VALUES (1, N'students', NULL, N'https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/metadata/resources/api-docs/students', NULL, N'
{
  "apiVersion": "2.0",
  "swaggerVersion":"1.2",
  "basePath": "https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/api/v2.0/2017",
  "resourcePath":"/students",
  "produces": [
    "application/json"
  ],
  "apis" : [
        {
            "path":"/students",
            "description":"This entity represents an individual for whom instruction, services, and/or care are provided in an early childhood, elementary, or secondary educational program under the jurisdiction of a school, education agency or other institution or program. A student is a person who has been enrolled in a school or other educational institution.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getStudentsAll",
                    "type":"array",
                    "items":{"$ref":"student"},
                    "parameters":[
                       {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        }
                    ],
                    "summary":"Retrieves resources based with paging capabilities (using the \"Get All\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get All\" pattern. In this version of the API there is support for paging.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The matching resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"array",
                            "items":{"$ref":"student"}                         },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors.  This will typically be an issue with the query parameters or their values."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getStudentsAll",
                    "type":"array",
                    "items":{"$ref":"student"},
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        },
                        {
                            "paramType":"query",
                            "name":"studentUniqueId",
                            "type":"string",
                            "description":"A unique alpha-numeric code assigned to a student.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"personalTitlePrefix",
                            "type":"string",
                            "description":"A prefix used to denote the title, degree, position, or seniority of the person.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"firstName",
                            "type":"string",
                            "description":"A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"middleName",
                            "type":"string",
                            "description":"A secondary name given to an individual at birth, baptism, or during another naming ceremony.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"lastSurname",
                            "type":"string",
                            "description":"The name borne in common by members of a family.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"generationCodeSuffix",
                            "type":"string",
                            "description":"An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"maidenName",
                            "type":"string",
                            "description":"The person''s maiden name.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"sexType",
                            "type":"string", 
                            "description":"A person''''s gender.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"birthDate",
                            "type":"date-time",
                            "description":"The month, day, and year on which an individual was born.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"birthCity",
                            "type":"string",
                            "description":"The set of elements that capture relevant data regarding a person''s birth, including birth date and place of birth.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"birthStateAbbreviationType",
                            "type":"string", 
                            "description":"The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which an individual was born.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"dateEnteredUS",
                            "type":"date-time",
                            "description":"For students born outside of the U.S., the date the student entered the U.S.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"multipleBirthStatus",
                            "type":"boolean",
                            "description":"Indicator of whether the student was born with other siblings (i.e., twins, triplets, etc.)",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"profileThumbnail",
                            "type":"string",
                            "description":"ProfileThumbnail.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"hispanicLatinoEthnicity",
                            "type":"boolean",
                            "description":"An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, \"Spanish origin,\" can be used in addition to \"Hispanic or Latino.\"",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"oldEthnicityType",
                            "type":"string", 
                            "description":"Previous definition of Ethnicity combining Hispanic/latino and race:  1 - American Indian or Alaskan Native  2 - Asian or Pacific Islander  3 - Black, not of Hispanic origin  4 - Hispanic  5 - White, not of Hispanic origin",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"economicDisadvantaged",
                            "type":"boolean",
                            "description":"An indication of inadequate financial condition of an individual''s family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"schoolFoodServicesEligibilityDescriptor",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"limitedEnglishProficiencyDescriptor",
                            "type":"string", 
                            "description":"An indication that the student has sufficient difficulty speaking, reading, writing, or understanding the English language, as to require special English Language services.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"displacementStatus",
                            "type":"string",
                            "description":"Indicates a state health or weather related event that displaces a group of students, and may require additional funding, educational, or social services.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"loginId",
                            "type":"string",
                            "description":"The login ID for the user; used for security access control interface.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"birthInternationalProvince",
                            "type":"string",
                            "description":"For students born outside of the US, the Province or jurisdiction in which an individual is born.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"citizenshipStatusType",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"id",
                            "type":"string",
                            "description":"",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"birthCountryDescriptor",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                    ],
                    "summary":"Retrieves resources matching values of an example resource (using the \"Get By Example\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Example\" search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"student"
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getStudentByKey",
                    "type":"student",
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"studentUniqueId",
                            "type":"string",
                            "description":"A unique alpha-numeric code assigned to a student.",
                            "required":true
                        }
                        ,{
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the values of the resource''s natural key (using the \"Get By Key\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Key\" search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"student"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                                {
                    "method":"POST",
                    "nickname":"postStudents",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"body",
                            "name":"student",
                            "description":"The JSON representation of the \"student\" resource to be created or updated.",
                            "required":true,
                            "type":"student"
                        }
                    ],
                    "summary":"Creates or updates resources based on the natural key values of the supplied resource.",
                    "notes":"The POST operation can be used to create or update resources. In database terms, this is often referred to as an \"upsert\" operation (insert + update).  Clients should NOT include the resource \"id\" in the JSON body because it will result in an error (you must use a PUT operation to update a resource by \"id\"). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is available in the ETag header of the response."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        },
        {
            "path":"/students/{id}",
            "description":"This entity represents an individual for whom instruction, services, and/or care are provided in an early childhood, elementary, or secondary educational program under the jurisdiction of a school, education agency or other institution or program. A student is a person who has been enrolled in a school or other educational institution.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getStudentsById",
                    "type":"student",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be retrieved.",
                            "required":true,
                            "type":"string"
                        },
                        {
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the resource''s identifier (using the \"Get By Id\" pattern).",
                    "notes":"This GET operation retrieves a resource by the specified resource identifier.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"student"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"PUT",
                    "nickname":"putStudent",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be updated.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the PUT from updating a resource modified by another consumer.",
                          "type": "string",
                          "required": false
                        },
                        {
                            "paramType":"body",
                            "name":"student",
                            "description":"The JSON representation of the \"student\" resource to be updated.",
                            "required":true,
                            "type":"student"
                        }
                    ],
                    "summary":"Updates or creates a resource based on the resource identifier.",
                    "notes":"The PUT operation is used to update or create a resource by identifier.  If the resource doesn''t exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource \"id\" is provided in the JSON body, it will be ignored as well.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is returned in a response header."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"DELETE",
                    "nickname":"deleteStudentById",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be deleted.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the DELETE from removing a resource modified by another consumer.",
                          "type": "string",
                          "required": false,
                          "allowMultiple": false
                        }
                    ],
                    "summary":"Deletes an existing resource using the resource identifier.",
                    "notes":"The DELETE operation is used to delete an existing resource by identifier.  If the resource doesn''t exist, an error will result (the resource will not be found).",
                    "responseMessages":[
                        {
                            "code":202,
                            "message":"The request has accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was successfully deleted."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        }
    ],
    "models": {
        "student": {
            "id":"student",
            "properties": {
                "id": {
                    "type":"string",
                    "required":true,
                    "description":"The unique identifier of the resource."
                }
                ,"studentUniqueId": {
                    "type":"string",
                    "required":true,
                    "description":"A unique alpha-numeric code assigned to a student."
                }
                ,"personalTitlePrefix": {
                    "type":"string",
                    "required":false,
                    "description":"A prefix used to denote the title, degree, position, or seniority of the person."
                }
                ,"firstName": {
                    "type":"string",
                    "required":true,
                    "description":"A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change."
                }
                ,"middleName": {
                    "type":"string",
                    "required":false,
                    "description":"A secondary name given to an individual at birth, baptism, or during another naming ceremony."
                }
                ,"lastSurname": {
                    "type":"string",
                    "required":true,
                    "description":"The name borne in common by members of a family."
                }
                ,"generationCodeSuffix": {
                    "type":"string",
                    "required":false,
                    "description":"An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III)."
                }
                ,"maidenName": {
                    "type":"string",
                    "required":false,
                    "description":"The person''s maiden name."
                }
                ,"sexType": {
                    "type":"string",
                    "required":true,
                    "description":"A person''''s gender."
                }
                ,"birthDate": {
                    "type":"date-time",
                    "required":true,
                    "description":"The month, day, and year on which an individual was born."
                }
                ,"birthCity": {
                    "type":"string",
                    "required":false,
                    "description":"The set of elements that capture relevant data regarding a person''s birth, including birth date and place of birth."
                }
                ,"birthStateAbbreviationType": {
                    "type":"string",
                    "required":false,
                    "description":"The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which an individual was born."
                }
                ,"dateEnteredUS": {
                    "type":"date-time",
                    "required":false,
                    "description":"For students born outside of the U.S., the date the student entered the U.S."
                }
                ,"multipleBirthStatus": {
                    "type":"boolean",
                    "required":false,
                    "description":"Indicator of whether the student was born with other siblings (i.e., twins, triplets, etc.)"
                }
                ,"profileThumbnail": {
                    "type":"string",
                    "required":false,
                    "description":"ProfileThumbnail."
                }
                ,"hispanicLatinoEthnicity": {
                    "type":"boolean",
                    "required":true,
                    "description":"An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, \"Spanish origin,\" can be used in addition to \"Hispanic or Latino.\""
                }
                ,"oldEthnicityType": {
                    "type":"string",
                    "required":false,
                    "description":"Previous definition of Ethnicity combining Hispanic/latino and race:  1 - American Indian or Alaskan Native  2 - Asian or Pacific Islander  3 - Black, not of Hispanic origin  4 - Hispanic  5 - White, not of Hispanic origin"
                }
                ,"economicDisadvantaged": {
                    "type":"boolean",
                    "required":false,
                    "description":"An indication of inadequate financial condition of an individual''s family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy."
                }
                ,"schoolFoodServicesEligibilityDescriptor": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"limitedEnglishProficiencyDescriptor": {
                    "type":"string",
                    "required":false,
                    "description":"An indication that the student has sufficient difficulty speaking, reading, writing, or understanding the English language, as to require special English Language services."
                }
                ,"displacementStatus": {
                    "type":"string",
                    "required":false,
                    "description":"Indicates a state health or weather related event that displaces a group of students, and may require additional funding, educational, or social services."
                }
                ,"loginId": {
                    "type":"string",
                    "required":false,
                    "description":"The login ID for the user; used for security access control interface."
                }
                ,"birthInternationalProvince": {
                    "type":"string",
                    "required":false,
                    "description":"For students born outside of the US, the Province or jurisdiction in which an individual is born."
                }
                ,"citizenshipStatusType": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"studentUniqueId": {
                    "type":"string",
                    "required":true,
                    "description":"A unique alphanumeric code assigned to a student."
                }
                ,"birthCountryDescriptor": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"learningStyle": {
                    "type":"studentLearningStyle",
                    "required":false,
                    "description":"The student''s relative preference to visual, auditory and tactile learning expressed as percentages."
                }
                ,"addresses": {
                    "type":"array",
                    "items":{"$ref":"studentAddress"},
                    "required":false,
                    "description":"An unordered collection of studentAddresses.  The set of elements that describes an address, including the street address, city, state, and ZIP code."
                }
                ,"characteristics": {
                    "type":"array",
                    "items":{"$ref":"studentCharacteristic"},
                    "required":false,
                    "description":"An unordered collection of studentCharacteristics.  Reflects important characteristics of the student''s home situation: Displaced Homemaker, Homeless, Immigrant, Migratory, Military Parent, Pregnant Teen, Single Parent, Unaccompanied Youth."
                }
                ,"cohortYears": {
                    "type":"array",
                    "items":{"$ref":"studentCohortYear"},
                    "required":false,
                    "description":"An unordered collection of studentCohortYears.  The type and year of a cohort (e.g., 9th grade) the student belongs to as determined by the year that student entered a specific grade."
                }
                ,"disabilities": {
                    "type":"array",
                    "items":{"$ref":"studentDisability"},
                    "required":false,
                    "description":"An unordered collection of studentDisabilities.  This type represents an impairment of body structure or function, a limitation in activities or a restriction in participation, as ordered by severity of impairment."
                }
                ,"electronicMails": {
                    "type":"array",
                    "items":{"$ref":"studentElectronicMail"},
                    "required":false,
                    "description":"An unordered collection of studentElectronicMails.  "
                }
                ,"identificationCodes": {
                    "type":"array",
                    "items":{"$ref":"studentIdentificationCode"},
                    "required":false,
                    "description":"An unordered collection of studentIdentificationCodes.  A coding scheme that is used for identification and record-keeping purposes by schools, social services or other agencies to refer to a student."
                }
                ,"identificationDocuments": {
                    "type":"array",
                    "items":{"$ref":"studentIdentificationDocument"},
                    "required":false,
                    "description":"An unordered collection of studentIdentificationDocuments.  Represents the valid document that a person uses for identification."
                }
                ,"indicators": {
                    "type":"array",
                    "items":{"$ref":"studentIndicator"},
                    "required":false,
                    "description":"An unordered collection of studentIndicators.  An indicator or metric computed for the student (e.g., at risk) to influence more effective education or direct specific interventions."
                }
                ,"internationalAddresses": {
                    "type":"array",
                    "items":{"$ref":"studentInternationalAddress"},
                    "required":false,
                    "description":"An unordered collection of studentInternationalAddresses.  The set of elements that describes an address, including the street address and country for international students."
                }
                ,"languages": {
                    "type":"array",
                    "items":{"$ref":"studentLanguage"},
                    "required":false,
                    "description":"An unordered collection of studentLanguages.  Language(s) the individual uses to communicate."
                }
                ,"otherNames": {
                    "type":"array",
                    "items":{"$ref":"studentOtherName"},
                    "required":false,
                    "description":"An unordered collection of studentOtherNames.  Other names (e.g., alias, nickname, previous legal name) associated with a person."
                }
                ,"programParticipations": {
                    "type":"array",
                    "items":{"$ref":"studentProgramParticipation"},
                    "required":false,
                    "description":"An unordered collection of studentProgramParticipations.  Key programs the student is participating in or receives services from."
                }
                ,"races": {
                    "type":"array",
                    "items":{"$ref":"studentRace"},
                    "required":false,
                    "description":"An unordered collection of studentRaces.  The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The data model allows for multiple entries so that each individual can specify all appropriate races."
                }
                ,"telephones": {
                    "type":"array",
                    "items":{"$ref":"studentTelephone"},
                    "required":false,
                    "description":"An unordered collection of studentTelephones.  The 10-digit telephone number, including the area code, for the person."
                }
                ,"visas": {
                    "type":"array",
                    "items":{"$ref":"studentVisa"},
                    "required":false,
                    "description":"An unordered collection of studentVisas.  Describe the types of Visa that a non-U.S. citizen student holds."
                }
                ,"_etag": {
                    "type":"string",
                    "required":false,
                    "description":"A unique system-generated value that identifies the version of the resource."
                }
            }
        }
        ,"studentCharacteristic": {
            "id":"studentCharacteristic",
            "properties": {
                "descriptor": {
                    "type":"string",
                    "required":true,
                    "description":"The characteristic designated for the student."
                }
                ,"beginDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The date the characteristic was designated."
                }
                ,"endDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The date the characteristic was removed."
                }
                ,"designatedBy": {
                    "type":"string",
                    "required":false,
                    "description":"The person, organization, or department that made a student designation."
                }
            }
        }
        ,"studentIndicator": {
            "id":"studentIndicator",
            "properties": {
                "indicatorName": {
                    "type":"string",
                    "required":true,
                    "description":"The name of the Indicator, indicator group, or metric computed for the student (e.g., at risk) to influence more effective education or direct specific interventions."
                }
                ,"indicator": {
                    "type":"string",
                    "required":true,
                    "description":"Indicator or metric computed for the student (e.g., at risk) to influence more effective education or direct specific interventions."
                }
                ,"indicatorGroup": {
                    "type":"string",
                    "required":false,
                    "description":"The name for a group of indicators."
                }
                ,"beginDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The date when the indicator was assigned or computed."
                }
                ,"endDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The date the indicator or metric was sunset or removed."
                }
                ,"designatedBy": {
                    "type":"string",
                    "required":false,
                    "description":"The person, organization, or department that made a student designation."
                }
            }
        }
        ,"studentDisability": {
            "id":"studentDisability",
            "properties": {
                "disabilityDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"disabilityDiagnosis": {
                    "type":"string",
                    "required":false,
                    "description":"A description of the disability diagnosis."
                }
                ,"orderOfDisability": {
                    "type":"integer",
                    "required":false,
                    "description":"The order by severity of student''s disabilities: 1- Primary, 2 - Secondary, 3 - Tertiary, etc."
                }
                ,"disabilityDeterminationSourceType": {
                    "type":"string",
                    "required":false,
                    "description":"Key for Disability Determination Source Type"
                }
            }
        }
        ,"studentTelephone": {
            "id":"studentTelephone",
            "properties": {
                "telephoneNumberType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for TelephoneNumber"
                }
                ,"orderOfPriority": {
                    "type":"integer",
                    "required":false,
                    "description":"The order of priority assigned to telephone numbers to define which number to attempt first, second, etc."
                }
                ,"textMessageCapabilityIndicator": {
                    "type":"boolean",
                    "required":false,
                    "description":"An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages."
                }
                ,"telephoneNumber": {
                    "type":"string",
                    "required":true,
                    "description":"The telephone number including the area code, and extension, if applicable."
                }
            }
        }
        ,"studentElectronicMail": {
            "id":"studentElectronicMail",
            "properties": {
                "electronicMailType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for ElectronicMail"
                }
                ,"electronicMailAddress": {
                    "type":"string",
                    "required":true,
                    "description":"The electronic mail (e-mail) address listed for an individual or organization."
                }
                ,"primaryEmailAddressIndicator": {
                    "type":"boolean",
                    "required":false,
                    "description":"An indication that the electronic mail address should be used as the principal electronic mail address for an individual or organization."
                }
            }
        }
        ,"studentCohortYear": {
            "id":"studentCohortYear",
            "properties": {
                "schoolYearTypeReference": {
                    "type":"schoolYearTypeReference",
                    "required":true,
                    "description":"A reference to the related SchoolYearType resource."
                }
                ,"cohortYearType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for CohortYear"
                }
            }
        }
        , "schoolYearTypeReference": {
            "id":"schoolYearTypeReference",
            "properties": {
                "schoolYear": {
                    "type":"integer",
                    "required":true,
                    "description":"Key for School"
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related schoolYearType resource."
                }
            }
        }
        ,"studentRace": {
            "id":"studentRace",
            "properties": {
                "raceType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for Race"
                }
            }
        }
        ,"studentIdentificationCode": {
            "id":"studentIdentificationCode",
            "properties": {
                "assigningOrganizationIdentificationCode": {
                    "type":"string",
                    "required":true,
                    "description":"The organization code or name assigning the StudentIdentificationCode."
                }
                ,"studentIdentificationSystemDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"identificationCode": {
                    "type":"string",
                    "required":true,
                    "description":"A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, a state, or other agency or entity."
                }
            }
        }
        ,"studentIdentificationDocument": {
            "id":"studentIdentificationDocument",
            "properties": {
                "personalInformationVerificationType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for PersonalInformationVerification"
                }
                ,"identificationDocumentUseType": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"documentTitle": {
                    "type":"string",
                    "required":false,
                    "description":"The title of the document given by the issuer."
                }
                ,"documentExpirationDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The day when the document  expires, if null then never expires."
                }
                ,"issuerDocumentIdentificationCode": {
                    "type":"string",
                    "required":false,
                    "description":"The unique identifier on the issuer''s identification system."
                }
                ,"issuerName": {
                    "type":"string",
                    "required":false,
                    "description":"Name of the entity or institution that issued the document."
                }
                ,"issuerCountryDescriptor": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
            }
        }
        ,"studentVisa": {
            "id":"studentVisa",
            "properties": {
                "visaType": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
            }
        }
        ,"studentLanguage": {
            "id":"studentLanguage",
            "properties": {
                "languageDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"uses": {
                    "type":"array",
                    "items":{"$ref":"studentLanguageUse"},
                    "required":false,
                    "description":"An unordered collection of studentLanguageUses.  A description of how the language is used (e.g. Home Language, Native Language, Spoken Language)."
                }
            }
        }
        ,"studentLanguageUse": {
            "id":"studentLanguageUse",
            "properties": {
                "languageUseType": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
            }
        }
        ,"studentOtherName": {
            "id":"studentOtherName",
            "properties": {
                "otherNameType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for OtherName"
                }
                ,"personalTitlePrefix": {
                    "type":"string",
                    "required":false,
                    "description":"A prefix used to denote the title, degree, position, or seniority of the person."
                }
                ,"firstName": {
                    "type":"string",
                    "required":true,
                    "description":"A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change."
                }
                ,"middleName": {
                    "type":"string",
                    "required":false,
                    "description":"A secondary name given to an individual at birth, baptism, or during another naming ceremony."
                }
                ,"lastSurname": {
                    "type":"string",
                    "required":true,
                    "description":"The name borne in common by members of a family."
                }
                ,"generationCodeSuffix": {
                    "type":"string",
                    "required":false,
                    "description":"An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III)."
                }
            }
        }
        ,"studentAddress": {
            "id":"studentAddress",
            "properties": {
                "addressType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for Address"
                }
                ,"streetNumberName": {
                    "type":"string",
                    "required":true,
                    "description":"The street number and street name or post office box number of an address."
                }
                ,"apartmentRoomSuiteNumber": {
                    "type":"string",
                    "required":false,
                    "description":"The apartment, room, or suite number of an address."
                }
                ,"buildingSiteNumber": {
                    "type":"string",
                    "required":false,
                    "description":"The number of the building on the site, if more than one building shares the same address."
                }
                ,"city": {
                    "type":"string",
                    "required":true,
                    "description":"The name of the city in which an address is located."
                }
                ,"stateAbbreviationType": {
                    "type":"string",
                    "required":true,
                    "description":"The abbreviation for the state (within the United States) or outlying area in which an address is located."
                }
                ,"postalCode": {
                    "type":"string",
                    "required":true,
                    "description":"The five or nine digit zip code or overseas postal code portion of an address."
                }
                ,"nameOfCounty": {
                    "type":"string",
                    "required":false,
                    "description":"The name of the county, parish, borough, or comparable unit (within a state) in which an address is located."
                }
                ,"countyFIPSCode": {
                    "type":"string",
                    "required":false,
                    "description":"Definition The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the \"first-order subdivisions\" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code."
                }
                ,"latitude": {
                    "type":"string",
                    "required":false,
                    "description":"The geographic latitude of the physical address."
                }
                ,"longitude": {
                    "type":"string",
                    "required":false,
                    "description":"The geographic longitude of the physical address."
                }
                ,"beginDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The first date the address is valid. For physical addresses, the date the person moved to that address."
                }
                ,"endDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The last date the address is valid. For physical addresses, this would be the date the person moved from that address."
                }
            }
        }
        ,"studentInternationalAddress": {
            "id":"studentInternationalAddress",
            "properties": {
                "addressType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for Address"
                }
                ,"addressLine1": {
                    "type":"string",
                    "required":true,
                    "description":"The first line of the address."
                }
                ,"addressLine2": {
                    "type":"string",
                    "required":false,
                    "description":"The second line of the address."
                }
                ,"addressLine3": {
                    "type":"string",
                    "required":false,
                    "description":"The third line of the address."
                }
                ,"addressLine4": {
                    "type":"string",
                    "required":false,
                    "description":"The fourth line of the address."
                }
                ,"latitude": {
                    "type":"string",
                    "required":false,
                    "description":"The geographic latitude of the physical address."
                }
                ,"longitude": {
                    "type":"string",
                    "required":false,
                    "description":"The geographic longitude of the physical address."
                }
                ,"beginDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The first date the address is valid. For physical addresses, the date the person moved to that address."
                }
                ,"endDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The last date the address is valid. For physical addresses, this would be the date the person moved from that address."
                }
                ,"countryDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
            }
        }
        ,"studentLearningStyle": {
            "id":"studentLearningStyle",
            "properties": {
                "visualLearning": {
                    "type":"number",
                    "required":true,
                    "description":"The student''s relative preference expressed as a percent to visual learning."
                }
                ,"auditoryLearning": {
                    "type":"number",
                    "required":true,
                    "description":"The student''s relative preference expressed as a percent to auditory learning."
                }
                ,"tactileLearning": {
                    "type":"number",
                    "required":true,
                    "description":"The student''s relative preference expressed as a percent to kinesthetic or tactile learning."
                }
            }
        }
        ,"studentProgramParticipation": {
            "id":"studentProgramParticipation",
            "properties": {
                "programType": {
                    "type":"string",
                    "required":true,
                    "description":"The program the student is associated with or receiving services from."
                }
                ,"beginDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The date the Student was associated with the Program or service."
                }
                ,"endDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The date the Program participation ended."
                }
                ,"designatedBy": {
                    "type":"string",
                    "required":false,
                    "description":"The person, organization, or department that made a student designation."
                }
                ,"programCharacteristics": {
                    "type":"array",
                    "items":{"$ref":"studentProgramParticipationProgramCharacteristic"},
                    "required":false,
                    "description":"An unordered collection of studentProgramParticipationProgramCharacteristics.  Reflects important characteristics of the Program that a Student participates in, such as categories or particular indications."
                }
            }
        }
        ,"studentProgramParticipationProgramCharacteristic": {
            "id":"studentProgramParticipationProgramCharacteristic",
            "properties": {
                "programCharacteristicDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
            }
        }
        ,"webServiceError": {
                    "id":"webServiceError",
                    "properties": {
                        "message": {
                            "type":"string",
                            "required":false,
                            "description":"The \"user-friendly\" error message."
                        },
                        "exceptionMessage": {
                            "type":"string",
                            "required":false,
                            "description":"The system-generated exception message."
                        },
                        "exceptionType": {
                            "type":"string",
                            "required":false,
                            "description":"The type of the exception."
                        },
                        "stackTrace": {
                            "type":"string",
                            "required":false,
                            "description":"The server-side stack trace (only available in DEBUG builds)."
                        }
                    }
                }
        ,"link": {
                "id":"link",
                "properties": {
                    "rel": {
                        "type":"string",
                        "required":false,
                        "description":"Describes the nature of the relationship to the referenced resource."
                    },
                    "href": {
                        "type":"string",
                        "required":false,
                        "description":"The URL to the related resource."
                    }
                }
            }
    }
}
        ', NULL, NULL)
INSERT [dataflow].[entity] ([ID], [Name], [Namespace], [URL], [Family], [Metadata], [CreateDate], [UpdateDate]) VALUES (2, N'studentAssessments', NULL, N'https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/metadata/resources/api-docs/studentAssessments', NULL, N'
{
  "apiVersion": "2.0",
  "swaggerVersion":"1.2",
  "basePath": "https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/api/v2.0/2017",
  "resourcePath":"/studentAssessments",
  "produces": [
    "application/json"
  ],
  "apis" : [
        {
            "path":"/studentAssessments",
            "description":"This entity represents the analysis or scoring of a student''s response on an assessment. The analysis results in a value that represents a student''s performance on a set of items on a test.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getStudentAssessmentsAll",
                    "type":"array",
                    "items":{"$ref":"studentAssessment"},
                    "parameters":[
                       {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        }
                    ],
                    "summary":"Retrieves resources based with paging capabilities (using the \"Get All\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get All\" pattern. In this version of the API there is support for paging.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The matching resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"array",
                            "items":{"$ref":"studentAssessment"}                         },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors.  This will typically be an issue with the query parameters or their values."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getStudentAssessmentsAll",
                    "type":"array",
                    "items":{"$ref":"studentAssessment"},
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        },
                        {
                            "paramType":"query",
                            "name":"studentUniqueId",
                            "type":"string",
                            "description":"A unique alpha-numeric code assigned to a student.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"assessmentTitle",
                            "type":"string",
                            "description":"The title or name of the assessment.  NEDM: Assessment Title",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"academicSubjectDescriptor",
                            "type":"string", 
                            "description":"The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"assessedGradeLevelDescriptor",
                            "type":"string", 
                            "description":"The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"version",
                            "type":"integer",
                            "description":"The version identifier for the test assessment.  NEDM: Assessment Version",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"administrationDate",
                            "type":"date-time",
                            "description":"The month(s), day(s), and year on which an assessment is administered or first day of administration if over multiple days.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"administrationEndDate",
                            "type":"date-time",
                            "description":"Assessment Administration End Date, if administered over multiple days.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"serialNumber",
                            "type":"string",
                            "description":"The unique number for the assessment form or answer document.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"administrationLanguageDescriptor",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"administrationEnvironmentType",
                            "type":"string", 
                            "description":"The environment in which the test was administered.  For example:  Electronic  Classroom  Testing Center  ...  ....",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"retestIndicatorType",
                            "type":"string", 
                            "description":"Indicator if the test was retaken.  For example:  Primary administration  First retest  Second retest  ...",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"reasonNotTestedType",
                            "type":"string", 
                            "description":"The primary reason student is not tested. For example:  Absent  Refusal by parent  Refusal by student  Medical waiver  Illness  Disruptive behavior  LEP Exempt  ...",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"whenAssessedGradeLevelDescriptor",
                            "type":"string", 
                            "description":"The grade level of a student when assessed.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"eventCircumstanceType",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"eventDescription",
                            "type":"string",
                            "description":"Describes special events that occur before during or after the assessment session that may impact use of results.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"id",
                            "type":"string",
                            "description":"",
                            "required":false
                        }
                    ],
                    "summary":"Retrieves resources matching values of an example resource (using the \"Get By Example\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Example\" search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"studentAssessment"
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getStudentAssessmentByKey",
                    "type":"studentAssessment",
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"studentUniqueId",
                            "type":"string",
                            "description":"A unique alpha-numeric code assigned to a student.",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"assessmentTitle",
                            "type":"string",
                            "description":"The title or name of the assessment.  NEDM: Assessment Title",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"academicSubjectDescriptor",
                            "type":"string", 
                            "description":"The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"assessedGradeLevelDescriptor",
                            "type":"string", 
                            "description":"The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"version",
                            "type":"integer",
                            "description":"The version identifier for the test assessment.  NEDM: Assessment Version",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"administrationDate",
                            "type":"date-time",
                            "description":"The month(s), day(s), and year on which an assessment is administered or first day of administration if over multiple days.",
                            "required":true
                        }
                        ,{
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the values of the resource''s natural key (using the \"Get By Key\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Key\" search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"studentAssessment"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                                {
                    "method":"POST",
                    "nickname":"postStudentAssessments",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"body",
                            "name":"studentAssessment",
                            "description":"The JSON representation of the \"studentAssessment\" resource to be created or updated.",
                            "required":true,
                            "type":"studentAssessment"
                        }
                    ],
                    "summary":"Creates or updates resources based on the natural key values of the supplied resource.",
                    "notes":"The POST operation can be used to create or update resources. In database terms, this is often referred to as an \"upsert\" operation (insert + update).  Clients should NOT include the resource \"id\" in the JSON body because it will result in an error (you must use a PUT operation to update a resource by \"id\"). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is available in the ETag header of the response."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        },
        {
            "path":"/studentAssessments/{id}",
            "description":"This entity represents the analysis or scoring of a student''s response on an assessment. The analysis results in a value that represents a student''s performance on a set of items on a test.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getStudentAssessmentsById",
                    "type":"studentAssessment",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be retrieved.",
                            "required":true,
                            "type":"string"
                        },
                        {
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the resource''s identifier (using the \"Get By Id\" pattern).",
                    "notes":"This GET operation retrieves a resource by the specified resource identifier.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"studentAssessment"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"PUT",
                    "nickname":"putStudentAssessment",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be updated.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the PUT from updating a resource modified by another consumer.",
                          "type": "string",
                          "required": false
                        },
                        {
                            "paramType":"body",
                            "name":"studentAssessment",
                            "description":"The JSON representation of the \"studentAssessment\" resource to be updated.",
                            "required":true,
                            "type":"studentAssessment"
                        }
                    ],
                    "summary":"Updates or creates a resource based on the resource identifier.",
                    "notes":"The PUT operation is used to update or create a resource by identifier.  If the resource doesn''t exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource \"id\" is provided in the JSON body, it will be ignored as well.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is returned in a response header."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"DELETE",
                    "nickname":"deleteStudentAssessmentById",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be deleted.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the DELETE from removing a resource modified by another consumer.",
                          "type": "string",
                          "required": false,
                          "allowMultiple": false
                        }
                    ],
                    "summary":"Deletes an existing resource using the resource identifier.",
                    "notes":"The DELETE operation is used to delete an existing resource by identifier.  If the resource doesn''t exist, an error will result (the resource will not be found).",
                    "responseMessages":[
                        {
                            "code":202,
                            "message":"The request has accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was successfully deleted."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        }
    ],
    "models": {
        "studentAssessment": {
            "id":"studentAssessment",
            "properties": {
                "id": {
                    "type":"string",
                    "required":true,
                    "description":"The unique identifier of the resource."
                }
                ,"assessmentReference": {
                    "type":"assessmentReference",
                    "required":true,
                    "description":"A reference to the related Assessment resource."
                }
                ,"studentReference": {
                    "type":"studentReference",
                    "required":true,
                    "description":"A reference to the related Student resource."
                }
                ,"administrationDate": {
                    "type":"date-time",
                    "required":true,
                    "description":"The month(s), day(s), and year on which an assessment is administered or first day of administration if over multiple days."
                }
                ,"administrationEndDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"Assessment Administration End Date, if administered over multiple days."
                }
                ,"serialNumber": {
                    "type":"string",
                    "required":false,
                    "description":"The unique number for the assessment form or answer document."
                }
                ,"administrationLanguageDescriptor": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"administrationEnvironmentType": {
                    "type":"string",
                    "required":false,
                    "description":"The environment in which the test was administered.  For example:  Electronic  Classroom  Testing Center  ...  ...."
                }
                ,"retestIndicatorType": {
                    "type":"string",
                    "required":false,
                    "description":"Indicator if the test was retaken.  For example:  Primary administration  First retest  Second retest  ..."
                }
                ,"reasonNotTestedType": {
                    "type":"string",
                    "required":false,
                    "description":"The primary reason student is not tested. For example:  Absent  Refusal by parent  Refusal by student  Medical waiver  Illness  Disruptive behavior  LEP Exempt  ..."
                }
                ,"whenAssessedGradeLevelDescriptor": {
                    "type":"string",
                    "required":false,
                    "description":"The grade level of a student when assessed."
                }
                ,"eventCircumstanceType": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"eventDescription": {
                    "type":"string",
                    "required":false,
                    "description":"Describes special events that occur before during or after the assessment session that may impact use of results."
                }
                ,"accommodations": {
                    "type":"array",
                    "items":{"$ref":"studentAssessmentAccommodation"},
                    "required":false,
                    "description":"An unordered collection of studentAssessmentAccommodations.  The specific type of special variation used in how an examination is presented, how it is administered or how the test taker is allowed to respond. This generally refers to changes that do not substantially alter what the examination measures. The proper use of accommodations does not substantially change academic level or performance criteria (e.g., Braille, Enlarged Monitor View, Extra Time, Large Print, Setting, Oral Administration)."
                }
                ,"items": {
                    "type":"array",
                    "items":{"$ref":"studentAssessmentItem"},
                    "required":false,
                    "description":"An unordered collection of studentAssessmentItems.  This entity represents the student''s response to an assessment item and the item-level scores such as correct, incorrect, or met standard."
                }
                ,"performanceLevels": {
                    "type":"array",
                    "items":{"$ref":"studentAssessmentPerformanceLevel"},
                    "required":false,
                    "description":"An unordered collection of studentAssessmentPerformanceLevels.  Indicates the various levels or thresholds for the performance achieved by the student on the assessment."
                }
                ,"scoreResults": {
                    "type":"array",
                    "items":{"$ref":"studentAssessmentScoreResult"},
                    "required":false,
                    "description":"An unordered collection of studentAssessmentScoreResults.  A meaningful raw score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc."
                }
                ,"studentObjectiveAssessments": {
                    "type":"array",
                    "items":{"$ref":"studentAssessmentStudentObjectiveAssessment"},
                    "required":false,
                    "description":"An unordered collection of studentAssessmentStudentObjectiveAssessments.  This entity holds the score and or performance levels earned for an objective assessment by a student."
                }
                ,"_etag": {
                    "type":"string",
                    "required":false,
                    "description":"A unique system-generated value that identifies the version of the resource."
                }
            }
        }
        , "assessmentReference": {
            "id":"assessmentReference",
            "properties": {
                "title": {
                    "type":"string",
                    "required":true,
                    "description":"The title or name of the assessment.  NEDM: Assessment Title"
                }
                ,"assessedGradeLevelDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ..."
                }
                ,"academicSubjectDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject"
                }
                ,"version": {
                    "type":"integer",
                    "required":true,
                    "description":"The version identifier for the assessment."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related assessment resource."
                }
            }
        }
        , "studentReference": {
            "id":"studentReference",
            "properties": {
                "studentUniqueId": {
                    "type":"string",
                    "required":true,
                    "description":"A unique alpha-numeric code assigned to a student."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related student resource."
                }
            }
        }
        ,"studentAssessmentPerformanceLevel": {
            "id":"studentAssessmentPerformanceLevel",
            "properties": {
                "performanceLevelDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"The ID of the Performance Level Descriptor"
                }
                ,"performanceLevelMet": {
                    "type":"boolean",
                    "required":true,
                    "description":"Optional indicator of whether the performance level was met."
                }
            }
        }
        ,"studentAssessmentAccommodation": {
            "id":"studentAssessmentAccommodation",
            "properties": {
                "accommodationDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
            }
        }
        ,"studentAssessmentScoreResult": {
            "id":"studentAssessmentScoreResult",
            "properties": {
                "assessmentReportingMethodType": {
                    "type":"string",
                    "required":true,
                    "description":"The name of the analytic score.  For example:  Percentile  Quantile measure  Lexile measure  Vertical scale score  TPM score  ...  ..."
                }
                ,"result": {
                    "type":"string",
                    "required":true,
                    "description":"A meaningful raw score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc."
                }
                ,"resultDatatypeType": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
            }
        }
        ,"studentAssessmentItem": {
            "id":"studentAssessmentItem",
            "properties": {
                "assessmentItemReference": {
                    "type":"assessmentItemReference",
                    "required":true,
                    "description":"A reference to the related AssessmentItem resource."
                }
                ,"assessmentResponse": {
                    "type":"string",
                    "required":false,
                    "description":"A student''s response to a stimulus on a test."
                }
                ,"responseIndicatorType": {
                    "type":"string",
                    "required":false,
                    "description":"Indicator of the response.  For example:  Nonscorable response  Ineffective response  Effective response  Partial response  ..."
                }
                ,"assessmentItemResultType": {
                    "type":"string",
                    "required":true,
                    "description":"The analyzed result of a student''''s response to an assessment item.. For example:  Correct  Incorrect  Met standard  ..."
                }
                ,"rawScoreResult": {
                    "type":"integer",
                    "required":false,
                    "description":"A meaningful raw score of the performance of an individual on an assessment item."
                }
                ,"timeAssessed": {
                    "type":"string",
                    "required":false,
                    "description":"The overall time a student actually spent during the AssessmentItem."
                }
                ,"descriptiveFeedback": {
                    "type":"string",
                    "required":false,
                    "description":"The formative descriptive feedback that was given to a learner in response to the results from a scored/evaluated assessment item."
                }
            }
        }
        , "assessmentItemReference": {
            "id":"assessmentItemReference",
            "properties": {
                "assessmentTitle": {
                    "type":"string",
                    "required":true,
                    "description":"The title or name of the assessment.  NEDM: Assessment Title"
                }
                ,"academicSubjectDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject"
                }
                ,"assessedGradeLevelDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ..."
                }
                ,"version": {
                    "type":"integer",
                    "required":true,
                    "description":"The version identifier for the test assessment.  NEDM: Assessment Version"
                }
                ,"identificationCode": {
                    "type":"string",
                    "required":true,
                    "description":"A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, a state, or other agency or entity."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related assessmentItem resource."
                }
            }
        }
        ,"studentAssessmentStudentObjectiveAssessment": {
            "id":"studentAssessmentStudentObjectiveAssessment",
            "properties": {
                "objectiveAssessmentReference": {
                    "type":"objectiveAssessmentReference",
                    "required":true,
                    "description":"A reference to the related ObjectiveAssessment resource."
                }
                ,"performanceLevels": {
                    "type":"array",
                    "items":{"$ref":"studentAssessmentStudentObjectiveAssessmentPerformanceLevel"},
                    "required":false,
                    "description":"An unordered collection of studentAssessmentStudentObjectiveAssessmentPerformanceLevels.  The performance level(s) achieved for the objective assessment."
                }
                ,"scoreResults": {
                    "type":"array",
                    "items":{"$ref":"studentAssessmentStudentObjectiveAssessmentScoreResult"},
                    "required":true,
                    "description":"An unordered collection of studentAssessmentStudentObjectiveAssessmentScoreResults.  A meaningful raw score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc."
                }
            }
        }
        , "objectiveAssessmentReference": {
            "id":"objectiveAssessmentReference",
            "properties": {
                "assessmentTitle": {
                    "type":"string",
                    "required":true,
                    "description":"The title or name of the assessment.  NEDM: Assessment Title"
                }
                ,"academicSubjectDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject"
                }
                ,"assessedGradeLevelDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ..."
                }
                ,"version": {
                    "type":"integer",
                    "required":true,
                    "description":"The version identifier for the test assessment.  NEDM: Assessment Version"
                }
                ,"identificationCode": {
                    "type":"string",
                    "required":true,
                    "description":"A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, a state, or other agency or entity."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related objectiveAssessment resource."
                }
            }
        }
        ,"studentAssessmentStudentObjectiveAssessmentScoreResult": {
            "id":"studentAssessmentStudentObjectiveAssessmentScoreResult",
            "properties": {
                "assessmentReportingMethodType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for AssessmentReportingMethod"
                }
                ,"result": {
                    "type":"string",
                    "required":true,
                    "description":"The value of a meaningful raw score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc."
                }
                ,"resultDatatypeType": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
            }
        }
        ,"studentAssessmentStudentObjectiveAssessmentPerformanceLevel": {
            "id":"studentAssessmentStudentObjectiveAssessmentPerformanceLevel",
            "properties": {
                "performanceLevelDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"performanceLevelMet": {
                    "type":"boolean",
                    "required":true,
                    "description":"Indicator of whether the student met the designated performance level."
                }
            }
        }
        ,"webServiceError": {
                    "id":"webServiceError",
                    "properties": {
                        "message": {
                            "type":"string",
                            "required":false,
                            "description":"The \"user-friendly\" error message."
                        },
                        "exceptionMessage": {
                            "type":"string",
                            "required":false,
                            "description":"The system-generated exception message."
                        },
                        "exceptionType": {
                            "type":"string",
                            "required":false,
                            "description":"The type of the exception."
                        },
                        "stackTrace": {
                            "type":"string",
                            "required":false,
                            "description":"The server-side stack trace (only available in DEBUG builds)."
                        }
                    }
                }
        ,"link": {
                "id":"link",
                "properties": {
                    "rel": {
                        "type":"string",
                        "required":false,
                        "description":"Describes the nature of the relationship to the referenced resource."
                    },
                    "href": {
                        "type":"string",
                        "required":false,
                        "description":"The URL to the related resource."
                    }
                }
            }
    }
}
        ', NULL, NULL)
INSERT [dataflow].[entity] ([ID], [Name], [Namespace], [URL], [Family], [Metadata], [CreateDate], [UpdateDate]) VALUES (3, N'studentSchoolAssociations', NULL, N'https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/metadata/resources/api-docs/studentSchoolAssociations', NULL, N'
{
  "apiVersion": "2.0",
  "swaggerVersion":"1.2",
  "basePath": "https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/api/v2.0/2017",
  "resourcePath":"/studentSchoolAssociations",
  "produces": [
    "application/json"
  ],
  "apis" : [
        {
            "path":"/studentSchoolAssociations",
            "description":"This association represents the School in which a student is enrolled. The semantics of enrollment may differ slightly by state. Non-enrollment relationships between a student and an education organization may be described using the StudentEducationOrganizationAssociation.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getStudentSchoolAssociationsAll",
                    "type":"array",
                    "items":{"$ref":"studentSchoolAssociation"},
                    "parameters":[
                       {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        }
                    ],
                    "summary":"Retrieves resources based with paging capabilities (using the \"Get All\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get All\" pattern. In this version of the API there is support for paging.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The matching resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"array",
                            "items":{"$ref":"studentSchoolAssociation"}                         },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors.  This will typically be an issue with the query parameters or their values."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getStudentSchoolAssociationsAll",
                    "type":"array",
                    "items":{"$ref":"studentSchoolAssociation"},
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        },
                        {
                            "paramType":"query",
                            "name":"studentUniqueId",
                            "type":"string",
                            "description":"A unique alpha-numeric code assigned to a student.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"schoolId",
                            "type":"integer",
                            "description":"School Identity Column",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"entryDate",
                            "type":"date-time",
                            "description":"The month, day, and year on which an individual enters and begins to receive instructional services in a school.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"schoolYear",
                            "type":"integer",
                            "description":"Identifier for a school year.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"entryGradeLevelDescriptor",
                            "type":"string", 
                            "description":"The grade level or primary instructional level at which a student enters and receives services in a school or an educational institution during a given academic session.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"entryGradeLevelReasonType",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"entryTypeDescriptor",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"repeatGradeIndicator",
                            "type":"boolean",
                            "description":"An indicator of whether the student is enrolling to repeat a grade level, either by failure or an agreement to hold the student back.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"schoolChoiceTransfer",
                            "type":"boolean",
                            "description":"An indication of whether students transferred in or out of the school did so during the school year under the provisions for public school choice in accordance with Title I, Part A, Section 1116.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"exitWithdrawDate",
                            "type":"date-time",
                            "description":"The month, day, and year of the first day after the date of an individual''s last attendance at a school (if known), the day on which an individual graduated, or the date on which it becomes known officially that an individual left school.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"exitWithdrawTypeDescriptor",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"residencyStatusDescriptor",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"primarySchool",
                            "type":"boolean",
                            "description":"Indicates if a given enrollment record should be considered the primary record for a student. If omitted, the default is true.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"employedWhileEnrolled",
                            "type":"boolean",
                            "description":"An individual who is a paid employee or works in his or her own business, profession, or farm and at the same time is enrolled in secondary, postsecondary, or adult education.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"classOfSchoolYear",
                            "type":"integer",
                            "description":"Projected High School graduation year",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"educationOrganizationId",
                            "type":"integer",
                            "description":"EducationOrganization Identity Column",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"graduationPlanTypeDescriptor",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"graduationSchoolYear",
                            "type":"integer",
                            "description":"The identifier for the school year.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"id",
                            "type":"string",
                            "description":"",
                            "required":false
                        }
                    ],
                    "summary":"Retrieves resources matching values of an example resource (using the \"Get By Example\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Example\" search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"studentSchoolAssociation"
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getStudentSchoolAssociationByKey",
                    "type":"studentSchoolAssociation",
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"studentUniqueId",
                            "type":"string",
                            "description":"A unique alpha-numeric code assigned to a student.",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"schoolId",
                            "type":"integer",
                            "description":"School Identity Column",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"entryDate",
                            "type":"date-time",
                            "description":"The month, day, and year on which an individual enters and begins to receive instructional services in a school.",
                            "required":true
                        }
                        ,{
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the values of the resource''s natural key (using the \"Get By Key\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Key\" search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"studentSchoolAssociation"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                                {
                    "method":"POST",
                    "nickname":"postStudentSchoolAssociations",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"body",
                            "name":"studentSchoolAssociation",
                            "description":"The JSON representation of the \"studentSchoolAssociation\" resource to be created or updated.",
                            "required":true,
                            "type":"studentSchoolAssociation"
                        }
                    ],
                    "summary":"Creates or updates resources based on the natural key values of the supplied resource.",
                    "notes":"The POST operation can be used to create or update resources. In database terms, this is often referred to as an \"upsert\" operation (insert + update).  Clients should NOT include the resource \"id\" in the JSON body because it will result in an error (you must use a PUT operation to update a resource by \"id\"). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is available in the ETag header of the response."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        },
        {
            "path":"/studentSchoolAssociations/{id}",
            "description":"This association represents the School in which a student is enrolled. The semantics of enrollment may differ slightly by state. Non-enrollment relationships between a student and an education organization may be described using the StudentEducationOrganizationAssociation.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getStudentSchoolAssociationsById",
                    "type":"studentSchoolAssociation",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be retrieved.",
                            "required":true,
                            "type":"string"
                        },
                        {
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the resource''s identifier (using the \"Get By Id\" pattern).",
                    "notes":"This GET operation retrieves a resource by the specified resource identifier.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"studentSchoolAssociation"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"PUT",
                    "nickname":"putStudentSchoolAssociation",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be updated.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the PUT from updating a resource modified by another consumer.",
                          "type": "string",
                          "required": false
                        },
                        {
                            "paramType":"body",
                            "name":"studentSchoolAssociation",
                            "description":"The JSON representation of the \"studentSchoolAssociation\" resource to be updated.",
                            "required":true,
                            "type":"studentSchoolAssociation"
                        }
                    ],
                    "summary":"Updates or creates a resource based on the resource identifier.",
                    "notes":"The PUT operation is used to update or create a resource by identifier.  If the resource doesn''t exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource \"id\" is provided in the JSON body, it will be ignored as well.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is returned in a response header."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"DELETE",
                    "nickname":"deleteStudentSchoolAssociationById",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be deleted.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the DELETE from removing a resource modified by another consumer.",
                          "type": "string",
                          "required": false,
                          "allowMultiple": false
                        }
                    ],
                    "summary":"Deletes an existing resource using the resource identifier.",
                    "notes":"The DELETE operation is used to delete an existing resource by identifier.  If the resource doesn''t exist, an error will result (the resource will not be found).",
                    "responseMessages":[
                        {
                            "code":202,
                            "message":"The request has accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was successfully deleted."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        }
    ],
    "models": {
        "studentSchoolAssociation": {
            "id":"studentSchoolAssociation",
            "properties": {
                "id": {
                    "type":"string",
                    "required":true,
                    "description":"The unique identifier of the resource."
                }
                ,"graduationPlanReference": {
                    "type":"graduationPlanReference",
                    "required":false,
                    "description":"A reference to the related GraduationPlan resource."
                }
                ,"schoolReference": {
                    "type":"schoolReference",
                    "required":true,
                    "description":"A reference to the related School resource."
                }
                ,"classOfSchoolYearTypeReference": {
                    "type":"schoolYearTypeReference",
                    "required":false,
                    "description":"A reference to the related SchoolYearType resource."
                }
                ,"schoolYearTypeReference": {
                    "type":"schoolYearTypeReference",
                    "required":false,
                    "description":"A reference to the related SchoolYearType resource."
                }
                ,"studentReference": {
                    "type":"studentReference",
                    "required":true,
                    "description":"A reference to the related Student resource."
                }
                ,"entryDate": {
                    "type":"date-time",
                    "required":true,
                    "description":"The month, day, and year on which an individual enters and begins to receive instructional services in a school."
                }
                ,"entryGradeLevelDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"The grade level or primary instructional level at which a student enters and receives services in a school or an educational institution during a given academic session."
                }
                ,"entryGradeLevelReasonType": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"entryTypeDescriptor": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"repeatGradeIndicator": {
                    "type":"boolean",
                    "required":false,
                    "description":"An indicator of whether the student is enrolling to repeat a grade level, either by failure or an agreement to hold the student back."
                }
                ,"schoolChoiceTransfer": {
                    "type":"boolean",
                    "required":false,
                    "description":"An indication of whether students transferred in or out of the school did so during the school year under the provisions for public school choice in accordance with Title I, Part A, Section 1116."
                }
                ,"exitWithdrawDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The month, day, and year of the first day after the date of an individual''s last attendance at a school (if known), the day on which an individual graduated, or the date on which it becomes known officially that an individual left school."
                }
                ,"exitWithdrawTypeDescriptor": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"residencyStatusDescriptor": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"primarySchool": {
                    "type":"boolean",
                    "required":false,
                    "description":"Indicates if a given enrollment record should be considered the primary record for a student. If omitted, the default is true."
                }
                ,"employedWhileEnrolled": {
                    "type":"boolean",
                    "required":false,
                    "description":"An individual who is a paid employee or works in his or her own business, profession, or farm and at the same time is enrolled in secondary, postsecondary, or adult education."
                }
                ,"educationPlans": {
                    "type":"array",
                    "items":{"$ref":"studentSchoolAssociationEducationPlan"},
                    "required":false,
                    "description":"An unordered collection of studentSchoolAssociationEducationPlans.  Indicates the type of Education Plan(s) the student is following, if appropriate; for example: Special Education IEP or Vocational/CTE, etc."
                }
                ,"_etag": {
                    "type":"string",
                    "required":false,
                    "description":"A unique system-generated value that identifies the version of the resource."
                }
            }
        }
        , "graduationPlanReference": {
            "id":"graduationPlanReference",
            "properties": {
                "typeDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"educationOrganizationId": {
                    "type":"integer",
                    "required":true,
                    "description":"EducationOrganization Identity Column"
                }
                ,"graduationSchoolYear": {
                    "type":"integer",
                    "required":true,
                    "description":"Key for School"
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related graduationPlan resource."
                }
            }
        }
        , "schoolReference": {
            "id":"schoolReference",
            "properties": {
                "schoolId": {
                    "type":"integer",
                    "required":true,
                    "description":"The identifier assigned to a school by the State Education Agency (SEA)."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related school resource."
                }
            }
        }
        , "schoolYearTypeReference": {
            "id":"schoolYearTypeReference",
            "properties": {
                "schoolYear": {
                    "type":"integer",
                    "required":true,
                    "description":"Key for School"
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related schoolYearType resource."
                }
            }
        }
        , "schoolYearTypeReference": {
            "id":"schoolYearTypeReference",
            "properties": {
                "schoolYear": {
                    "type":"integer",
                    "required":true,
                    "description":"Key for School"
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related schoolYearType resource."
                }
            }
        }
        , "studentReference": {
            "id":"studentReference",
            "properties": {
                "studentUniqueId": {
                    "type":"string",
                    "required":true,
                    "description":"A unique alpha-numeric code assigned to a student."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related student resource."
                }
            }
        }
        ,"studentSchoolAssociationEducationPlan": {
            "id":"studentSchoolAssociationEducationPlan",
            "properties": {
                "educationPlanType": {
                    "type":"string",
                    "required":true,
                    "description":"The type of education plan the student is following."
                }
            }
        }
        ,"webServiceError": {
                    "id":"webServiceError",
                    "properties": {
                        "message": {
                            "type":"string",
                            "required":false,
                            "description":"The \"user-friendly\" error message."
                        },
                        "exceptionMessage": {
                            "type":"string",
                            "required":false,
                            "description":"The system-generated exception message."
                        },
                        "exceptionType": {
                            "type":"string",
                            "required":false,
                            "description":"The type of the exception."
                        },
                        "stackTrace": {
                            "type":"string",
                            "required":false,
                            "description":"The server-side stack trace (only available in DEBUG builds)."
                        }
                    }
                }
        ,"link": {
                "id":"link",
                "properties": {
                    "rel": {
                        "type":"string",
                        "required":false,
                        "description":"Describes the nature of the relationship to the referenced resource."
                    },
                    "href": {
                        "type":"string",
                        "required":false,
                        "description":"The URL to the related resource."
                    }
                }
            }
    }
}
        ', NULL, NULL)
INSERT [dataflow].[entity] ([ID], [Name], [Namespace], [URL], [Family], [Metadata], [CreateDate], [UpdateDate]) VALUES (4, N'studentSectionAssociations', NULL, N'https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/metadata/resources/api-docs/studentSectionAssociations', NULL, N'
{
  "apiVersion": "2.0",
  "swaggerVersion":"1.2",
  "basePath": "https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/api/v2.0/2017",
  "resourcePath":"/studentSectionAssociations",
  "produces": [
    "application/json"
  ],
  "apis" : [
        {
            "path":"/studentSectionAssociations",
            "description":"This association indicates the course sections to which a student is assigned.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getStudentSectionAssociationsAll",
                    "type":"array",
                    "items":{"$ref":"studentSectionAssociation"},
                    "parameters":[
                       {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        }
                    ],
                    "summary":"Retrieves resources based with paging capabilities (using the \"Get All\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get All\" pattern. In this version of the API there is support for paging.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The matching resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"array",
                            "items":{"$ref":"studentSectionAssociation"}                         },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors.  This will typically be an issue with the query parameters or their values."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getStudentSectionAssociationsAll",
                    "type":"array",
                    "items":{"$ref":"studentSectionAssociation"},
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        },
                        {
                            "paramType":"query",
                            "name":"studentUniqueId",
                            "type":"string",
                            "description":"A unique alpha-numeric code assigned to a student.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"schoolId",
                            "type":"integer",
                            "description":"School Identity Column",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"classPeriodName",
                            "type":"string",
                            "description":"An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period or AB schedules).  =",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"classroomIdentificationCode",
                            "type":"string",
                            "description":"A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"localCourseCode",
                            "type":"string",
                            "description":"The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"uniqueSectionCode",
                            "type":"string",
                            "description":"A unique identifier for the section, that is defined for a campus by the classroom, the subjects taught, and the instructors that are assigned.  NEDM: Unique Course Code",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"sequenceOfCourse",
                            "type":"integer",
                            "description":"When a section is part of a sequence of parts for a course, the number if the sequence.  If the course has only onle part, the value of this section attribute should be 1.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"schoolYear",
                            "type":"integer",
                            "description":"The identifier for the school year.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"termDescriptor",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"beginDate",
                            "type":"date-time",
                            "description":"Month, day, and year of the Student''s entry or assignment to the Section.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"endDate",
                            "type":"date-time",
                            "description":"Month, day, and year of the withdrawal or exit of the Student from the Section.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"homeroomIndicator",
                            "type":"boolean",
                            "description":"Indicates the Section is the student''s homeroom. Homeroom period may the convention for taking daily attendance.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"repeatIdentifierType",
                            "type":"string", 
                            "description":"An indication as to whether a student has previously taken a given course.  NEDM: Repeat Identifier  Repeated, counted in grade point average  Repeated, not counted in grade point average  Not repeated  Other",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"teacherStudentDataLinkExclusion",
                            "type":"boolean",
                            "description":"Indicates that the student-section combination is excluded from calculation of value-added or growth attribution calculations used for a particular teacher evaluation.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"id",
                            "type":"string",
                            "description":"",
                            "required":false
                        }
                    ],
                    "summary":"Retrieves resources matching values of an example resource (using the \"Get By Example\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Example\" search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"studentSectionAssociation"
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getStudentSectionAssociationByKey",
                    "type":"studentSectionAssociation",
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"studentUniqueId",
                            "type":"string",
                            "description":"A unique alpha-numeric code assigned to a student.",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"schoolId",
                            "type":"integer",
                            "description":"School Identity Column",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"classPeriodName",
                            "type":"string",
                            "description":"An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period or AB schedules).  =",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"classroomIdentificationCode",
                            "type":"string",
                            "description":"A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"localCourseCode",
                            "type":"string",
                            "description":"The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"uniqueSectionCode",
                            "type":"string",
                            "description":"A unique identifier for the section, that is defined for a campus by the classroom, the subjects taught, and the instructors that are assigned.  NEDM: Unique Course Code",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"sequenceOfCourse",
                            "type":"integer",
                            "description":"When a section is part of a sequence of parts for a course, the number if the sequence.  If the course has only onle part, the value of this section attribute should be 1.",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"schoolYear",
                            "type":"integer",
                            "description":"The identifier for the school year.",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"termDescriptor",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"beginDate",
                            "type":"date-time",
                            "description":"Month, day, and year of the Student''s entry or assignment to the Section.",
                            "required":true
                        }
                        ,{
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the values of the resource''s natural key (using the \"Get By Key\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Key\" search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"studentSectionAssociation"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                                {
                    "method":"POST",
                    "nickname":"postStudentSectionAssociations",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"body",
                            "name":"studentSectionAssociation",
                            "description":"The JSON representation of the \"studentSectionAssociation\" resource to be created or updated.",
                            "required":true,
                            "type":"studentSectionAssociation"
                        }
                    ],
                    "summary":"Creates or updates resources based on the natural key values of the supplied resource.",
                    "notes":"The POST operation can be used to create or update resources. In database terms, this is often referred to as an \"upsert\" operation (insert + update).  Clients should NOT include the resource \"id\" in the JSON body because it will result in an error (you must use a PUT operation to update a resource by \"id\"). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is available in the ETag header of the response."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        },
        {
            "path":"/studentSectionAssociations/{id}",
            "description":"This association indicates the course sections to which a student is assigned.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getStudentSectionAssociationsById",
                    "type":"studentSectionAssociation",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be retrieved.",
                            "required":true,
                            "type":"string"
                        },
                        {
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the resource''s identifier (using the \"Get By Id\" pattern).",
                    "notes":"This GET operation retrieves a resource by the specified resource identifier.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"studentSectionAssociation"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"PUT",
                    "nickname":"putStudentSectionAssociation",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be updated.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the PUT from updating a resource modified by another consumer.",
                          "type": "string",
                          "required": false
                        },
                        {
                            "paramType":"body",
                            "name":"studentSectionAssociation",
                            "description":"The JSON representation of the \"studentSectionAssociation\" resource to be updated.",
                            "required":true,
                            "type":"studentSectionAssociation"
                        }
                    ],
                    "summary":"Updates or creates a resource based on the resource identifier.",
                    "notes":"The PUT operation is used to update or create a resource by identifier.  If the resource doesn''t exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource \"id\" is provided in the JSON body, it will be ignored as well.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is returned in a response header."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"DELETE",
                    "nickname":"deleteStudentSectionAssociationById",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be deleted.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the DELETE from removing a resource modified by another consumer.",
                          "type": "string",
                          "required": false,
                          "allowMultiple": false
                        }
                    ],
                    "summary":"Deletes an existing resource using the resource identifier.",
                    "notes":"The DELETE operation is used to delete an existing resource by identifier.  If the resource doesn''t exist, an error will result (the resource will not be found).",
                    "responseMessages":[
                        {
                            "code":202,
                            "message":"The request has accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was successfully deleted."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        }
    ],
    "models": {
        "studentSectionAssociation": {
            "id":"studentSectionAssociation",
            "properties": {
                "id": {
                    "type":"string",
                    "required":true,
                    "description":"The unique identifier of the resource."
                }
                ,"sectionReference": {
                    "type":"sectionReference",
                    "required":true,
                    "description":"A reference to the related Section resource."
                }
                ,"studentReference": {
                    "type":"studentReference",
                    "required":true,
                    "description":"A reference to the related Student resource."
                }
                ,"beginDate": {
                    "type":"date-time",
                    "required":true,
                    "description":"Month, day, and year of the Student''s entry or assignment to the Section."
                }
                ,"endDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"Month, day, and year of the withdrawal or exit of the Student from the Section."
                }
                ,"homeroomIndicator": {
                    "type":"boolean",
                    "required":false,
                    "description":"Indicates the Section is the student''s homeroom. Homeroom period may the convention for taking daily attendance."
                }
                ,"repeatIdentifierType": {
                    "type":"string",
                    "required":false,
                    "description":"An indication as to whether a student has previously taken a given course.  NEDM: Repeat Identifier  Repeated, counted in grade point average  Repeated, not counted in grade point average  Not repeated  Other"
                }
                ,"teacherStudentDataLinkExclusion": {
                    "type":"boolean",
                    "required":false,
                    "description":"Indicates that the student-section combination is excluded from calculation of value-added or growth attribution calculations used for a particular teacher evaluation."
                }
                ,"_etag": {
                    "type":"string",
                    "required":false,
                    "description":"A unique system-generated value that identifies the version of the resource."
                }
            }
        }
        , "sectionReference": {
            "id":"sectionReference",
            "properties": {
                "schoolId": {
                    "type":"integer",
                    "required":true,
                    "description":"School Identity Column"
                }
                ,"classPeriodName": {
                    "type":"string",
                    "required":true,
                    "description":"An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period"
                }
                ,"classroomIdentificationCode": {
                    "type":"string",
                    "required":true,
                    "description":"A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity."
                }
                ,"localCourseCode": {
                    "type":"string",
                    "required":true,
                    "description":"The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students."
                }
                ,"termDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"schoolYear": {
                    "type":"integer",
                    "required":true,
                    "description":"The identifier for the school year."
                }
                ,"uniqueSectionCode": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned."
                }
                ,"sequenceOfCourse": {
                    "type":"integer",
                    "required":true,
                    "description":"When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related section resource."
                }
            }
        }
        , "studentReference": {
            "id":"studentReference",
            "properties": {
                "studentUniqueId": {
                    "type":"string",
                    "required":true,
                    "description":"A unique alpha-numeric code assigned to a student."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related student resource."
                }
            }
        }
        ,"webServiceError": {
                    "id":"webServiceError",
                    "properties": {
                        "message": {
                            "type":"string",
                            "required":false,
                            "description":"The \"user-friendly\" error message."
                        },
                        "exceptionMessage": {
                            "type":"string",
                            "required":false,
                            "description":"The system-generated exception message."
                        },
                        "exceptionType": {
                            "type":"string",
                            "required":false,
                            "description":"The type of the exception."
                        },
                        "stackTrace": {
                            "type":"string",
                            "required":false,
                            "description":"The server-side stack trace (only available in DEBUG builds)."
                        }
                    }
                }
        ,"link": {
                "id":"link",
                "properties": {
                    "rel": {
                        "type":"string",
                        "required":false,
                        "description":"Describes the nature of the relationship to the referenced resource."
                    },
                    "href": {
                        "type":"string",
                        "required":false,
                        "description":"The URL to the related resource."
                    }
                }
            }
    }
}
        ', NULL, NULL)
INSERT [dataflow].[entity] ([ID], [Name], [Namespace], [URL], [Family], [Metadata], [CreateDate], [UpdateDate]) VALUES (6, N'staffs', NULL, N'https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/metadata/resources/api-docs/staffs', NULL, N'
{
  "apiVersion": "2.0",
  "swaggerVersion":"1.2",
  "basePath": "https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/api/v2.0/2017",
  "resourcePath":"/staffs",
  "produces": [
    "application/json"
  ],
  "apis" : [
        {
            "path":"/staffs",
            "description":"This entity represents an individual who performs specified activities for any public or private education institution or agency that provides instructional and/or support services to students or staff at the early childhood level through high school completion. For example, this includes: 1. An \"employee\" who performs services under the direction of the employing institution or agency is compensated for such services by the employer and is eligible for employee benefits and wage or salary tax withholdings 2. A \"contractor\" or \"consultant\" who performs services for an agreed upon fee or an employee of a management service contracted to work on site 3. A \"volunteer\" who performs services on a voluntary and uncompensated basis 4. An in-kind service provider 5. An independent contractor or businessperson working at a school site.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getStaffsAll",
                    "type":"array",
                    "items":{"$ref":"staff"},
                    "parameters":[
                       {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        }
                    ],
                    "summary":"Retrieves resources based with paging capabilities (using the \"Get All\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get All\" pattern. In this version of the API there is support for paging.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The matching resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"array",
                            "items":{"$ref":"staff"}                         },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors.  This will typically be an issue with the query parameters or their values."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getStaffsAll",
                    "type":"array",
                    "items":{"$ref":"staff"},
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        },
                        {
                            "paramType":"query",
                            "name":"staffUniqueId",
                            "type":"string",
                            "description":"A unique alpha-numeric code assigned to a staff.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"personalTitlePrefix",
                            "type":"string",
                            "description":"A prefix used to denote the title, degree, position, or seniority of the person.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"firstName",
                            "type":"string",
                            "description":"A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"middleName",
                            "type":"string",
                            "description":"A secondary name given to an individual at birth, baptism, or during another naming ceremony.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"lastSurname",
                            "type":"string",
                            "description":"The name borne in common by members of a family.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"generationCodeSuffix",
                            "type":"string",
                            "description":"An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"maidenName",
                            "type":"string",
                            "description":"The person''s maiden name.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"sexType",
                            "type":"string", 
                            "description":"A person''''s gender.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"birthDate",
                            "type":"date-time",
                            "description":"The month, day, and year on which an individual was born.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"hispanicLatinoEthnicity",
                            "type":"boolean",
                            "description":"An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, \"Spanish origin,\" can be used in addition to \"Hispanic or Latino.\"",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"oldEthnicityType",
                            "type":"string", 
                            "description":"Previous definition of Ethnicity combining Hispanic/latino and race:  1 - American Indian or Alaskan Native  2 - Asian or Pacific Islander  3 - Black, not of Hispanic origin  4 - Hispanic  5 - White, not of Hispanic origin",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"highestCompletedLevelOfEducationDescriptor",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"yearsOfPriorProfessionalExperience",
                            "type":"number",
                            "description":"The total number of years that an individual has previously held a similar professional position in one or more education institutions.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"yearsOfPriorTeachingExperience",
                            "type":"number",
                            "description":"The total number of years that an individual has previously held a teaching position in one or more education institutions.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"highlyQualifiedTeacher",
                            "type":"boolean",
                            "description":"An indication of whether a teacher is classified as highly qualified for his/her assignment according to state definition. This attribute indicates the teacher is highly qualified for ALL Sections being taught.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"loginId",
                            "type":"string",
                            "description":"The login ID for the user; used for security access control interface.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"citizenshipStatusType",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"id",
                            "type":"string",
                            "description":"",
                            "required":false
                        }
                    ],
                    "summary":"Retrieves resources matching values of an example resource (using the \"Get By Example\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Example\" search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"staff"
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getStaffByKey",
                    "type":"staff",
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"staffUniqueId",
                            "type":"string",
                            "description":"A unique alpha-numeric code assigned to a staff.",
                            "required":true
                        }
                        ,{
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the values of the resource''s natural key (using the \"Get By Key\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Key\" search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"staff"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                                {
                    "method":"POST",
                    "nickname":"postStaffs",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"body",
                            "name":"staff",
                            "description":"The JSON representation of the \"staff\" resource to be created or updated.",
                            "required":true,
                            "type":"staff"
                        }
                    ],
                    "summary":"Creates or updates resources based on the natural key values of the supplied resource.",
                    "notes":"The POST operation can be used to create or update resources. In database terms, this is often referred to as an \"upsert\" operation (insert + update).  Clients should NOT include the resource \"id\" in the JSON body because it will result in an error (you must use a PUT operation to update a resource by \"id\"). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is available in the ETag header of the response."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        },
        {
            "path":"/staffs/{id}",
            "description":"This entity represents an individual who performs specified activities for any public or private education institution or agency that provides instructional and/or support services to students or staff at the early childhood level through high school completion. For example, this includes: 1. An \"employee\" who performs services under the direction of the employing institution or agency is compensated for such services by the employer and is eligible for employee benefits and wage or salary tax withholdings 2. A \"contractor\" or \"consultant\" who performs services for an agreed upon fee or an employee of a management service contracted to work on site 3. A \"volunteer\" who performs services on a voluntary and uncompensated basis 4. An in-kind service provider 5. An independent contractor or businessperson working at a school site.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getStaffsById",
                    "type":"staff",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be retrieved.",
                            "required":true,
                            "type":"string"
                        },
                        {
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the resource''s identifier (using the \"Get By Id\" pattern).",
                    "notes":"This GET operation retrieves a resource by the specified resource identifier.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"staff"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"PUT",
                    "nickname":"putStaff",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be updated.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the PUT from updating a resource modified by another consumer.",
                          "type": "string",
                          "required": false
                        },
                        {
                            "paramType":"body",
                            "name":"staff",
                            "description":"The JSON representation of the \"staff\" resource to be updated.",
                            "required":true,
                            "type":"staff"
                        }
                    ],
                    "summary":"Updates or creates a resource based on the resource identifier.",
                    "notes":"The PUT operation is used to update or create a resource by identifier.  If the resource doesn''t exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource \"id\" is provided in the JSON body, it will be ignored as well.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is returned in a response header."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"DELETE",
                    "nickname":"deleteStaffById",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be deleted.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the DELETE from removing a resource modified by another consumer.",
                          "type": "string",
                          "required": false,
                          "allowMultiple": false
                        }
                    ],
                    "summary":"Deletes an existing resource using the resource identifier.",
                    "notes":"The DELETE operation is used to delete an existing resource by identifier.  If the resource doesn''t exist, an error will result (the resource will not be found).",
                    "responseMessages":[
                        {
                            "code":202,
                            "message":"The request has accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was successfully deleted."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        }
    ],
    "models": {
        "staff": {
            "id":"staff",
            "properties": {
                "id": {
                    "type":"string",
                    "required":true,
                    "description":"The unique identifier of the resource."
                }
                ,"staffUniqueId": {
                    "type":"string",
                    "required":true,
                    "description":"A unique alpha-numeric code assigned to a staff."
                }
                ,"personalTitlePrefix": {
                    "type":"string",
                    "required":false,
                    "description":"A prefix used to denote the title, degree, position, or seniority of the person."
                }
                ,"firstName": {
                    "type":"string",
                    "required":true,
                    "description":"A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change."
                }
                ,"middleName": {
                    "type":"string",
                    "required":false,
                    "description":"A secondary name given to an individual at birth, baptism, or during another naming ceremony."
                }
                ,"lastSurname": {
                    "type":"string",
                    "required":true,
                    "description":"The name borne in common by members of a family."
                }
                ,"generationCodeSuffix": {
                    "type":"string",
                    "required":false,
                    "description":"An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III)."
                }
                ,"maidenName": {
                    "type":"string",
                    "required":false,
                    "description":"The person''s maiden name."
                }
                ,"sexType": {
                    "type":"string",
                    "required":false,
                    "description":"A person''''s gender."
                }
                ,"birthDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The month, day, and year on which an individual was born."
                }
                ,"hispanicLatinoEthnicity": {
                    "type":"boolean",
                    "required":true,
                    "description":"An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, \"Spanish origin,\" can be used in addition to \"Hispanic or Latino.\""
                }
                ,"oldEthnicityType": {
                    "type":"string",
                    "required":false,
                    "description":"Previous definition of Ethnicity combining Hispanic/latino and race:  1 - American Indian or Alaskan Native  2 - Asian or Pacific Islander  3 - Black, not of Hispanic origin  4 - Hispanic  5 - White, not of Hispanic origin"
                }
                ,"highestCompletedLevelOfEducationDescriptor": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"yearsOfPriorProfessionalExperience": {
                    "type":"number",
                    "required":false,
                    "description":"The total number of years that an individual has previously held a similar professional position in one or more education institutions."
                }
                ,"yearsOfPriorTeachingExperience": {
                    "type":"number",
                    "required":false,
                    "description":"The total number of years that an individual has previously held a teaching position in one or more education institutions."
                }
                ,"highlyQualifiedTeacher": {
                    "type":"boolean",
                    "required":false,
                    "description":"An indication of whether a teacher is classified as highly qualified for his/her assignment according to state definition. This attribute indicates the teacher is highly qualified for ALL Sections being taught."
                }
                ,"loginId": {
                    "type":"string",
                    "required":false,
                    "description":"The login ID for the user; used for security access control interface."
                }
                ,"citizenshipStatusType": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"staffUniqueId": {
                    "type":"string",
                    "required":true,
                    "description":"A unique alphanumeric code assigned to a staff."
                }
                ,"addresses": {
                    "type":"array",
                    "items":{"$ref":"staffAddress"},
                    "required":false,
                    "description":"An unordered collection of staffAddresses.  The set of elements that describes an address, including the street address, city, state and ZIP code."
                }
                ,"credentials": {
                    "type":"array",
                    "items":{"$ref":"staffCredential"},
                    "required":false,
                    "description":"An unordered collection of staffCredentials.  The legal document giving authorization to perform teaching assignment services."
                }
                ,"electronicMails": {
                    "type":"array",
                    "items":{"$ref":"staffElectronicMail"},
                    "required":false,
                    "description":"An unordered collection of staffElectronicMails.  The numbers, letters and symbols used to identify an electronic mail (e-mail) user within the network to which the individual or organization belongs."
                }
                ,"identificationCodes": {
                    "type":"array",
                    "items":{"$ref":"staffIdentificationCode"},
                    "required":false,
                    "description":"An unordered collection of staffIdentificationCodes.  A coding scheme that is used for identification and record-keeping purposes by schools, social services or other agencies to refer to a staff member."
                }
                ,"identificationDocuments": {
                    "type":"array",
                    "items":{"$ref":"staffIdentificationDocument"},
                    "required":false,
                    "description":"An unordered collection of staffIdentificationDocuments.  Represents the valid document that a person uses for identification."
                }
                ,"internationalAddresses": {
                    "type":"array",
                    "items":{"$ref":"staffInternationalAddress"},
                    "required":false,
                    "description":"An unordered collection of staffInternationalAddresses.  The set of elements that describes an address, including the street address, city, state and ZIP code."
                }
                ,"languages": {
                    "type":"array",
                    "items":{"$ref":"staffLanguage"},
                    "required":false,
                    "description":"An unordered collection of staffLanguages.  Language(s) the individual uses to communicate."
                }
                ,"otherNames": {
                    "type":"array",
                    "items":{"$ref":"staffOtherName"},
                    "required":false,
                    "description":"An unordered collection of staffOtherNames.  Other names (e.g., alias, nickname, previous legal name) associated with a person."
                }
                ,"races": {
                    "type":"array",
                    "items":{"$ref":"staffRace"},
                    "required":false,
                    "description":"An unordered collection of staffRaces.  The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races."
                }
                ,"telephones": {
                    "type":"array",
                    "items":{"$ref":"staffTelephone"},
                    "required":false,
                    "description":"An unordered collection of staffTelephones.  The 10-digit telephone number, including the area code, for the person."
                }
                ,"visas": {
                    "type":"array",
                    "items":{"$ref":"staffVisa"},
                    "required":false,
                    "description":"An unordered collection of staffVisas.  Describe the types of visa that a non-U.S. citizen staff member holds."
                }
                ,"_etag": {
                    "type":"string",
                    "required":false,
                    "description":"A unique system-generated value that identifies the version of the resource."
                }
            }
        }
        ,"staffAddress": {
            "id":"staffAddress",
            "properties": {
                "addressType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for Address"
                }
                ,"streetNumberName": {
                    "type":"string",
                    "required":true,
                    "description":"The street number and street name or post office box number of an address."
                }
                ,"apartmentRoomSuiteNumber": {
                    "type":"string",
                    "required":false,
                    "description":"The apartment, room, or suite number of an address."
                }
                ,"buildingSiteNumber": {
                    "type":"string",
                    "required":false,
                    "description":"The number of the building on the site, if more than one building shares the same address."
                }
                ,"city": {
                    "type":"string",
                    "required":true,
                    "description":"The name of the city in which an address is located."
                }
                ,"stateAbbreviationType": {
                    "type":"string",
                    "required":true,
                    "description":"The abbreviation for the state (within the United States) or outlying area in which an address is located."
                }
                ,"postalCode": {
                    "type":"string",
                    "required":true,
                    "description":"The five or nine digit zip code or overseas postal code portion of an address."
                }
                ,"nameOfCounty": {
                    "type":"string",
                    "required":false,
                    "description":"The name of the county, parish, borough, or comparable unit (within a state) in which an address is located."
                }
                ,"countyFIPSCode": {
                    "type":"string",
                    "required":false,
                    "description":"Definition The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the \"first-order subdivisions\" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code."
                }
                ,"latitude": {
                    "type":"string",
                    "required":false,
                    "description":"The geographic latitude of the physical address."
                }
                ,"longitude": {
                    "type":"string",
                    "required":false,
                    "description":"The geographic longitude of the physical address."
                }
                ,"beginDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The first date the address is valid. For physical addresses, the date the person moved to that address."
                }
                ,"endDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The last date the address is valid. For physical addresses, this would be the date the person moved from that address."
                }
            }
        }
        ,"staffInternationalAddress": {
            "id":"staffInternationalAddress",
            "properties": {
                "addressType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for Address"
                }
                ,"addressLine1": {
                    "type":"string",
                    "required":true,
                    "description":"The first line of the address."
                }
                ,"addressLine2": {
                    "type":"string",
                    "required":false,
                    "description":"The second line of the address."
                }
                ,"addressLine3": {
                    "type":"string",
                    "required":false,
                    "description":"The third line of the address."
                }
                ,"addressLine4": {
                    "type":"string",
                    "required":false,
                    "description":"The fourth line of the address."
                }
                ,"latitude": {
                    "type":"string",
                    "required":false,
                    "description":"The geographic latitude of the physical address."
                }
                ,"longitude": {
                    "type":"string",
                    "required":false,
                    "description":"The geographic longitude of the physical address."
                }
                ,"beginDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The first date the address is valid. For physical addresses, the date the person moved to that address."
                }
                ,"endDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The last date the address is valid. For physical addresses, this would be the date the person moved from that address."
                }
                ,"countryDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
            }
        }
        ,"staffRace": {
            "id":"staffRace",
            "properties": {
                "raceType": {
                    "type":"string",
                    "required":true,
                    "description":"The general racial category which most clearly reflects the individual''''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.        AMERICAN-INDIAN-ALASKA-NATIVE-CODE        ASIAN-CODE        BLACK-AFRICAN-AMERICAN-CODE        NATIVE-HAWAIIAN-PACIFIC-ISLANDER-CODE        WHITE-CODE"
                }
            }
        }
        ,"staffElectronicMail": {
            "id":"staffElectronicMail",
            "properties": {
                "electronicMailType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for ElectronicMail"
                }
                ,"electronicMailAddress": {
                    "type":"string",
                    "required":true,
                    "description":"The electronic mail (e-mail) address listed for an individual or organization."
                }
                ,"primaryEmailAddressIndicator": {
                    "type":"boolean",
                    "required":false,
                    "description":"An indication that the electronic mail address should be used as the principal electronic mail address for an individual or organization."
                }
            }
        }
        ,"staffIdentificationCode": {
            "id":"staffIdentificationCode",
            "properties": {
                "staffIdentificationSystemDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"assigningOrganizationIdentificationCode": {
                    "type":"string",
                    "required":false,
                    "description":"The organization code or name assigning the staff Identification Code."
                }
                ,"identificationCode": {
                    "type":"string",
                    "required":true,
                    "description":"A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, a state, or other agency or entity."
                }
            }
        }
        ,"staffIdentificationDocument": {
            "id":"staffIdentificationDocument",
            "properties": {
                "personalInformationVerificationType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for PersonalInformationVerification"
                }
                ,"identificationDocumentUseType": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"documentTitle": {
                    "type":"string",
                    "required":false,
                    "description":"The title of the document given by the issuer."
                }
                ,"documentExpirationDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The day when the document  expires, if null then never expires."
                }
                ,"issuerDocumentIdentificationCode": {
                    "type":"string",
                    "required":false,
                    "description":"The unique identifier on the issuer''s identification system."
                }
                ,"issuerName": {
                    "type":"string",
                    "required":false,
                    "description":"Name of the entity or institution that issued the document."
                }
                ,"issuerCountryDescriptor": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
            }
        }
        ,"staffOtherName": {
            "id":"staffOtherName",
            "properties": {
                "otherNameType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for OtherName"
                }
                ,"personalTitlePrefix": {
                    "type":"string",
                    "required":false,
                    "description":"A prefix used to denote the title, degree, position, or seniority of the person."
                }
                ,"firstName": {
                    "type":"string",
                    "required":true,
                    "description":"A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change."
                }
                ,"middleName": {
                    "type":"string",
                    "required":false,
                    "description":"A secondary name given to an individual at birth, baptism, or during another naming ceremony."
                }
                ,"lastSurname": {
                    "type":"string",
                    "required":true,
                    "description":"The name borne in common by members of a family."
                }
                ,"generationCodeSuffix": {
                    "type":"string",
                    "required":false,
                    "description":"An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III)."
                }
            }
        }
        ,"staffTelephone": {
            "id":"staffTelephone",
            "properties": {
                "telephoneNumberType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for TelephoneNumber"
                }
                ,"orderOfPriority": {
                    "type":"integer",
                    "required":false,
                    "description":"The order of priority assigned to telephone numbers to define which number to attempt first, second, etc."
                }
                ,"textMessageCapabilityIndicator": {
                    "type":"boolean",
                    "required":false,
                    "description":"An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages."
                }
                ,"telephoneNumber": {
                    "type":"string",
                    "required":true,
                    "description":"The telephone number including the area code, and extension, if applicable."
                }
            }
        }
        ,"staffLanguage": {
            "id":"staffLanguage",
            "properties": {
                "languageDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"uses": {
                    "type":"array",
                    "items":{"$ref":"staffLanguageUse"},
                    "required":false,
                    "description":"An unordered collection of staffLanguageUses.  A description of how the language is used (e.g. Home Language, Native Language, Spoken Language)."
                }
            }
        }
        ,"staffLanguageUse": {
            "id":"staffLanguageUse",
            "properties": {
                "languageUseType": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
            }
        }
        ,"staffVisa": {
            "id":"staffVisa",
            "properties": {
                "visaType": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
            }
        }
        ,"staffCredential": {
            "id":"staffCredential",
            "properties": {
                "credentialFieldDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"The field of certification for the certificate (e.g., Mathematics, Music)"
                }
                ,"credentialType": {
                    "type":"string",
                    "required":true,
                    "description":"An indication of the category of credential an individual holds."
                }
                ,"levelDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"teachingCredentialDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"credentialIssuanceDate": {
                    "type":"date-time",
                    "required":true,
                    "description":"The month, day, and year on which an active credential was issued to an individual."
                }
                ,"credentialExpirationDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The month, day, and year on which an active credential held by an individual will expire."
                }
                ,"teachingCredentialBasisType": {
                    "type":"string",
                    "required":false,
                    "description":"An indication of the pre-determined criteria for granting the teaching credential that an individual holds."
                }
                ,"stateOfIssueStateAbbreviationType": {
                    "type":"string",
                    "required":false,
                    "description":"Key for StateAbbreviationType"
                }
            }
        }
        ,"webServiceError": {
                    "id":"webServiceError",
                    "properties": {
                        "message": {
                            "type":"string",
                            "required":false,
                            "description":"The \"user-friendly\" error message."
                        },
                        "exceptionMessage": {
                            "type":"string",
                            "required":false,
                            "description":"The system-generated exception message."
                        },
                        "exceptionType": {
                            "type":"string",
                            "required":false,
                            "description":"The type of the exception."
                        },
                        "stackTrace": {
                            "type":"string",
                            "required":false,
                            "description":"The server-side stack trace (only available in DEBUG builds)."
                        }
                    }
                }
        ,"link": {
                "id":"link",
                "properties": {
                    "rel": {
                        "type":"string",
                        "required":false,
                        "description":"Describes the nature of the relationship to the referenced resource."
                    },
                    "href": {
                        "type":"string",
                        "required":false,
                        "description":"The URL to the related resource."
                    }
                }
            }
    }
}
        ', NULL, NULL)
INSERT [dataflow].[entity] ([ID], [Name], [Namespace], [URL], [Family], [Metadata], [CreateDate], [UpdateDate]) VALUES (7, N'assessments', NULL, N'https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/metadata/resources/api-docs/assessments', NULL, N'
{
  "apiVersion": "2.0",
  "swaggerVersion":"1.2",
  "basePath": "https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/api/v2.0/2017",
  "resourcePath":"/assessments",
  "produces": [
    "application/json"
  ],
  "apis" : [
        {
            "path":"/assessments",
            "description":"This entity represents a tool, instrument, process, or exhibition composed of a systematic sampling of behavior for measuring a student''s competence, knowledge, skills, or behavior. An assessment can be used to measure differences in individuals or groups and changes in performance from one occasion to the next.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getAssessmentsAll",
                    "type":"array",
                    "items":{"$ref":"assessment"},
                    "parameters":[
                       {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        }
                    ],
                    "summary":"Retrieves resources based with paging capabilities (using the \"Get All\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get All\" pattern. In this version of the API there is support for paging.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The matching resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"array",
                            "items":{"$ref":"assessment"}                         },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors.  This will typically be an issue with the query parameters or their values."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getAssessmentsAll",
                    "type":"array",
                    "items":{"$ref":"assessment"},
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        },
                        {
                            "paramType":"query",
                            "name":"title",
                            "type":"string",
                            "description":"The title or name of the assessment.  NEDM: Assessment Title",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"assessedGradeLevelDescriptor",
                            "type":"string", 
                            "description":"The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"academicSubjectDescriptor",
                            "type":"string", 
                            "description":"The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"version",
                            "type":"integer",
                            "description":"The version identifier for the assessment.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"categoryDescriptor",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"lowestAssessedGradeLevelDescriptor",
                            "type":"string", 
                            "description":"If the test assessment spans a range of grades, then this attribute holds the lowest grade assessed.  If only one grade level is assessed, then this attribute is omitted. For example:  Adult  Prekindergarten  First grade  Second grade  ...",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"form",
                            "type":"string",
                            "description":"Identifies the form of the assessment, for example a regular versus makeup form, multiple choice versus constructed response, etc.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"revisionDate",
                            "type":"date-time",
                            "description":"The month, day, and year that the conceptual design for the assessment was most recently revised substantially.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"maxRawScore",
                            "type":"integer",
                            "description":"The maximum raw score achievable across all assessment items that are correct and scored at the maximum.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"nomenclature",
                            "type":"string",
                            "description":"Reflects the common nomenclature for an element.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"periodDescriptor",
                            "type":"string", 
                            "description":"The ID of the Assessment Period Descriptor",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"familyTitle",
                            "type":"string",
                            "description":"The title or name of the assessment.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"namespace",
                            "type":"string",
                            "description":"Namespace for the Assessment.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"id",
                            "type":"string",
                            "description":"",
                            "required":false
                        }
                    ],
                    "summary":"Retrieves resources matching values of an example resource (using the \"Get By Example\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Example\" search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"assessment"
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getAssessmentByKey",
                    "type":"assessment",
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"title",
                            "type":"string",
                            "description":"The title or name of the assessment.  NEDM: Assessment Title",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"assessedGradeLevelDescriptor",
                            "type":"string", 
                            "description":"The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"academicSubjectDescriptor",
                            "type":"string", 
                            "description":"The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"version",
                            "type":"integer",
                            "description":"The version identifier for the assessment.",
                            "required":true
                        }
                        ,{
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the values of the resource''s natural key (using the \"Get By Key\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Key\" search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"assessment"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                                {
                    "method":"POST",
                    "nickname":"postAssessments",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"body",
                            "name":"assessment",
                            "description":"The JSON representation of the \"assessment\" resource to be created or updated.",
                            "required":true,
                            "type":"assessment"
                        }
                    ],
                    "summary":"Creates or updates resources based on the natural key values of the supplied resource.",
                    "notes":"The POST operation can be used to create or update resources. In database terms, this is often referred to as an \"upsert\" operation (insert + update).  Clients should NOT include the resource \"id\" in the JSON body because it will result in an error (you must use a PUT operation to update a resource by \"id\"). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is available in the ETag header of the response."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        },
        {
            "path":"/assessments/{id}",
            "description":"This entity represents a tool, instrument, process, or exhibition composed of a systematic sampling of behavior for measuring a student''s competence, knowledge, skills, or behavior. An assessment can be used to measure differences in individuals or groups and changes in performance from one occasion to the next.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getAssessmentsById",
                    "type":"assessment",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be retrieved.",
                            "required":true,
                            "type":"string"
                        },
                        {
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the resource''s identifier (using the \"Get By Id\" pattern).",
                    "notes":"This GET operation retrieves a resource by the specified resource identifier.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"assessment"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"PUT",
                    "nickname":"putAssessment",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be updated.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the PUT from updating a resource modified by another consumer.",
                          "type": "string",
                          "required": false
                        },
                        {
                            "paramType":"body",
                            "name":"assessment",
                            "description":"The JSON representation of the \"assessment\" resource to be updated.",
                            "required":true,
                            "type":"assessment"
                        }
                    ],
                    "summary":"Updates or creates a resource based on the resource identifier.",
                    "notes":"The PUT operation is used to update or create a resource by identifier.  If the resource doesn''t exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource \"id\" is provided in the JSON body, it will be ignored as well.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is returned in a response header."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"DELETE",
                    "nickname":"deleteAssessmentById",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be deleted.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the DELETE from removing a resource modified by another consumer.",
                          "type": "string",
                          "required": false,
                          "allowMultiple": false
                        }
                    ],
                    "summary":"Deletes an existing resource using the resource identifier.",
                    "notes":"The DELETE operation is used to delete an existing resource by identifier.  If the resource doesn''t exist, an error will result (the resource will not be found).",
                    "responseMessages":[
                        {
                            "code":202,
                            "message":"The request has accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was successfully deleted."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        }
    ],
    "models": {
        "assessment": {
            "id":"assessment",
            "properties": {
                "id": {
                    "type":"string",
                    "required":true,
                    "description":"The unique identifier of the resource."
                }
                ,"assessmentFamilyReference": {
                    "type":"assessmentFamilyReference",
                    "required":false,
                    "description":"A reference to the related AssessmentFamily resource."
                }
                ,"title": {
                    "type":"string",
                    "required":true,
                    "description":"The title or name of the assessment.  NEDM: Assessment Title"
                }
                ,"assessedGradeLevelDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ..."
                }
                ,"academicSubjectDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject"
                }
                ,"version": {
                    "type":"integer",
                    "required":true,
                    "description":"The version identifier for the assessment."
                }
                ,"categoryDescriptor": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"lowestAssessedGradeLevelDescriptor": {
                    "type":"string",
                    "required":false,
                    "description":"If the test assessment spans a range of grades, then this attribute holds the lowest grade assessed.  If only one grade level is assessed, then this attribute is omitted. For example:  Adult  Prekindergarten  First grade  Second grade  ..."
                }
                ,"form": {
                    "type":"string",
                    "required":false,
                    "description":"Identifies the form of the assessment, for example a regular versus makeup form, multiple choice versus constructed response, etc."
                }
                ,"revisionDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The month, day, and year that the conceptual design for the assessment was most recently revised substantially."
                }
                ,"maxRawScore": {
                    "type":"integer",
                    "required":false,
                    "description":"The maximum raw score achievable across all assessment items that are correct and scored at the maximum."
                }
                ,"nomenclature": {
                    "type":"string",
                    "required":false,
                    "description":"Reflects the common nomenclature for an element."
                }
                ,"periodDescriptor": {
                    "type":"string",
                    "required":false,
                    "description":"The ID of the Assessment Period Descriptor"
                }
                ,"namespace": {
                    "type":"string",
                    "required":false,
                    "description":"Namespace for the Assessment."
                }
                ,"contentStandard": {
                    "type":"assessmentContentStandard",
                    "required":false,
                    "description":"An indication as to whether an assessment conforms to a standard."
                }
                ,"identificationCodes": {
                    "type":"array",
                    "items":{"$ref":"assessmentIdentificationCode"},
                    "required":true,
                    "description":"An unordered collection of assessmentIdentificationCodes.  A unique number or alphanumeric code assigned to an assessment by a school, school system, a state, or other agency or entity."
                }
                ,"languages": {
                    "type":"array",
                    "items":{"$ref":"assessmentLanguage"},
                    "required":false,
                    "description":"An unordered collection of assessmentLanguages.  An indication of the languages in which the Assessment is designed."
                }
                ,"performanceLevels": {
                    "type":"array",
                    "items":{"$ref":"assessmentPerformanceLevel"},
                    "required":false,
                    "description":"An unordered collection of assessmentPerformanceLevels.  Definition of the performance levels and the associated cut scores. Three styles are supported: 1. Specification of performance level by minimum and maximum score 2. Specification of performance level by cut score, using only minimum score 3. Specification of performance level without any mapping to scores ."
                }
                ,"programs": {
                    "type":"array",
                    "items":{"$ref":"assessmentProgram"},
                    "required":false,
                    "description":"An unordered collection of assessmentPrograms.  The programs associated with the Assessment."
                }
                ,"scores": {
                    "type":"array",
                    "items":{"$ref":"assessmentScore"},
                    "required":false,
                    "description":"An unordered collection of assessmentScores.  Definition of the scores to be expected from this assessment."
                }
                ,"sections": {
                    "type":"array",
                    "items":{"$ref":"assessmentSection"},
                    "required":false,
                    "description":"An unordered collection of assessmentSections.  The section(s) to which the Assessment is associated."
                }
                ,"_etag": {
                    "type":"string",
                    "required":false,
                    "description":"A unique system-generated value that identifies the version of the resource."
                }
            }
        }
        , "assessmentFamilyReference": {
            "id":"assessmentFamilyReference",
            "properties": {
                "title": {
                    "type":"string",
                    "required":true,
                    "description":"The title or name of the assessment family."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related assessmentFamily resource."
                }
            }
        }
        ,"assessmentLanguage": {
            "id":"assessmentLanguage",
            "properties": {
                "languageDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
            }
        }
        ,"assessmentScore": {
            "id":"assessmentScore",
            "properties": {
                "assessmentReportingMethodType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for AssessmentReportingMethod"
                }
                ,"minimumScore": {
                    "type":"string",
                    "required":false,
                    "description":"The minimum score possible on the assessment."
                }
                ,"maximumScore": {
                    "type":"string",
                    "required":false,
                    "description":"The maximum score possible on the assessment."
                }
                ,"resultDatatypeType": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
            }
        }
        ,"assessmentContentStandard": {
            "id":"assessmentContentStandard",
            "properties": {
                "mandatingEducationOrganizationReference": {
                    "type":"educationOrganizationReference",
                    "required":false,
                    "description":"A reference to the related EducationOrganization resource."
                }
                ,"title": {
                    "type":"string",
                    "required":true,
                    "description":"The name of the content standard, for example Common Core."
                }
                ,"version": {
                    "type":"string",
                    "required":false,
                    "description":"The version identifier for the content."
                }
                ,"uri": {
                    "type":"string",
                    "required":false,
                    "description":"The public web site address (URL), file, or ftp locator."
                }
                ,"publicationDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The date on which this content was first published."
                }
                ,"publicationYear": {
                    "type":"integer",
                    "required":false,
                    "description":"The year at which this content was first published."
                }
                ,"publicationStatusType": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"beginDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The beginning of the period during which this learning standard document is intended for use."
                }
                ,"endDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The end of the period during which this learning standard document is intended for use."
                }
                ,"authors": {
                    "type":"array",
                    "items":{"$ref":"assessmentContentStandardAuthor"},
                    "required":false,
                    "description":"An unordered collection of assessmentContentStandardAuthors.  The person or organization chiefly responsible for the intellectual content of the standard."
                }
            }
        }
        , "educationOrganizationReference": {
            "id":"educationOrganizationReference",
            "properties": {
                "educationOrganizationId": {
                    "type":"integer",
                    "required":true,
                    "description":"EducationOrganization Identity Column"
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related educationOrganization resource."
                }
            }
        }
        ,"assessmentContentStandardAuthor": {
            "id":"assessmentContentStandardAuthor",
            "properties": {
                "author": {
                    "type":"string",
                    "required":true,
                    "description":"The person or organization chiefly responsible for the intellectual content of the standard."
                }
            }
        }
        ,"assessmentIdentificationCode": {
            "id":"assessmentIdentificationCode",
            "properties": {
                "assessmentIdentificationSystemDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"assigningOrganizationIdentificationCode": {
                    "type":"string",
                    "required":false,
                    "description":"The organization code or name assigning the assessment identification code."
                }
                ,"identificationCode": {
                    "type":"string",
                    "required":true,
                    "description":"A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, a state, or other agency or entity."
                }
            }
        }
        ,"assessmentPerformanceLevel": {
            "id":"assessmentPerformanceLevel",
            "properties": {
                "performanceLevelDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"The performance level(s) defined for the assessment."
                }
                ,"assessmentReportingMethodType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for AssessmentReportingMethod"
                }
                ,"minimumScore": {
                    "type":"string",
                    "required":false,
                    "description":"The minimum score required to make the indicated level of performance."
                }
                ,"maximumScore": {
                    "type":"string",
                    "required":false,
                    "description":"The maximum score to make the indicated level of performance."
                }
                ,"resultDatatypeType": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
            }
        }
        ,"assessmentSection": {
            "id":"assessmentSection",
            "properties": {
                "sectionReference": {
                    "type":"sectionReference",
                    "required":true,
                    "description":"A reference to the related Section resource."
                }
            }
        }
        , "sectionReference": {
            "id":"sectionReference",
            "properties": {
                "schoolId": {
                    "type":"integer",
                    "required":true,
                    "description":"School Identity Column"
                }
                ,"classPeriodName": {
                    "type":"string",
                    "required":true,
                    "description":"An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period"
                }
                ,"classroomIdentificationCode": {
                    "type":"string",
                    "required":true,
                    "description":"A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity."
                }
                ,"localCourseCode": {
                    "type":"string",
                    "required":true,
                    "description":"The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students."
                }
                ,"termDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"schoolYear": {
                    "type":"integer",
                    "required":true,
                    "description":"The identifier for the school year."
                }
                ,"uniqueSectionCode": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned."
                }
                ,"sequenceOfCourse": {
                    "type":"integer",
                    "required":true,
                    "description":"When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related section resource."
                }
            }
        }
        ,"assessmentProgram": {
            "id":"assessmentProgram",
            "properties": {
                "programReference": {
                    "type":"programReference",
                    "required":true,
                    "description":"A reference to the related Program resource."
                }
            }
        }
        , "programReference": {
            "id":"programReference",
            "properties": {
                "educationOrganizationId": {
                    "type":"integer",
                    "required":true,
                    "description":"EducationOrganization Identity Column"
                }
                ,"type": {
                    "type":"string",
                    "required":true,
                    "description":"Key for Program"
                }
                ,"name": {
                    "type":"string",
                    "required":true,
                    "description":"The formal name of the program of instruction, training, services or benefits available through federal, state, or local agencies."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related program resource."
                }
            }
        }
        ,"webServiceError": {
                    "id":"webServiceError",
                    "properties": {
                        "message": {
                            "type":"string",
                            "required":false,
                            "description":"The \"user-friendly\" error message."
                        },
                        "exceptionMessage": {
                            "type":"string",
                            "required":false,
                            "description":"The system-generated exception message."
                        },
                        "exceptionType": {
                            "type":"string",
                            "required":false,
                            "description":"The type of the exception."
                        },
                        "stackTrace": {
                            "type":"string",
                            "required":false,
                            "description":"The server-side stack trace (only available in DEBUG builds)."
                        }
                    }
                }
        ,"link": {
                "id":"link",
                "properties": {
                    "rel": {
                        "type":"string",
                        "required":false,
                        "description":"Describes the nature of the relationship to the referenced resource."
                    },
                    "href": {
                        "type":"string",
                        "required":false,
                        "description":"The URL to the related resource."
                    }
                }
            }
    }
}
        ', NULL, NULL)
INSERT [dataflow].[entity] ([ID], [Name], [Namespace], [URL], [Family], [Metadata], [CreateDate], [UpdateDate]) VALUES (8, N'staffSchoolAssociations', NULL, N'https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/metadata/resources/api-docs/staffSchoolAssociations', NULL, N'
{
  "apiVersion": "2.0",
  "swaggerVersion":"1.2",
  "basePath": "https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/api/v2.0/2017",
  "resourcePath":"/staffSchoolAssociations",
  "produces": [
    "application/json"
  ],
  "apis" : [
        {
            "path":"/staffSchoolAssociations",
            "description":"This association indicates the School(s) to which a staff member provides instructional services.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getStaffSchoolAssociationsAll",
                    "type":"array",
                    "items":{"$ref":"staffSchoolAssociation"},
                    "parameters":[
                       {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        }
                    ],
                    "summary":"Retrieves resources based with paging capabilities (using the \"Get All\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get All\" pattern. In this version of the API there is support for paging.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The matching resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"array",
                            "items":{"$ref":"staffSchoolAssociation"}                         },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors.  This will typically be an issue with the query parameters or their values."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getStaffSchoolAssociationsAll",
                    "type":"array",
                    "items":{"$ref":"staffSchoolAssociation"},
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        },
                        {
                            "paramType":"query",
                            "name":"staffUniqueId",
                            "type":"string",
                            "description":"A unique alpha-numeric code assigned to a staff.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"programAssignmentDescriptor",
                            "type":"string", 
                            "description":"The name of the program for which the individual is assigned; for example:  Regular education  Title I-Academic  Title I-Non-Academic  Special Education  Bilingual/English as a Second Language  NEDM: Program Assignment",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"schoolId",
                            "type":"integer",
                            "description":"School Identity Column",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"schoolYear",
                            "type":"integer",
                            "description":"The identifier for the school year.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"id",
                            "type":"string",
                            "description":"",
                            "required":false
                        }
                    ],
                    "summary":"Retrieves resources matching values of an example resource (using the \"Get By Example\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Example\" search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"staffSchoolAssociation"
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getStaffSchoolAssociationByKey",
                    "type":"staffSchoolAssociation",
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"staffUniqueId",
                            "type":"string",
                            "description":"A unique alpha-numeric code assigned to a staff.",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"programAssignmentDescriptor",
                            "type":"string", 
                            "description":"The name of the program for which the individual is assigned; for example:  Regular education  Title I-Academic  Title I-Non-Academic  Special Education  Bilingual/English as a Second Language  NEDM: Program Assignment",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"schoolId",
                            "type":"integer",
                            "description":"School Identity Column",
                            "required":true
                        }
                        ,{
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the values of the resource''s natural key (using the \"Get By Key\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Key\" search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"staffSchoolAssociation"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                                {
                    "method":"POST",
                    "nickname":"postStaffSchoolAssociations",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"body",
                            "name":"staffSchoolAssociation",
                            "description":"The JSON representation of the \"staffSchoolAssociation\" resource to be created or updated.",
                            "required":true,
                            "type":"staffSchoolAssociation"
                        }
                    ],
                    "summary":"Creates or updates resources based on the natural key values of the supplied resource.",
                    "notes":"The POST operation can be used to create or update resources. In database terms, this is often referred to as an \"upsert\" operation (insert + update).  Clients should NOT include the resource \"id\" in the JSON body because it will result in an error (you must use a PUT operation to update a resource by \"id\"). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is available in the ETag header of the response."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        },
        {
            "path":"/staffSchoolAssociations/{id}",
            "description":"This association indicates the School(s) to which a staff member provides instructional services.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getStaffSchoolAssociationsById",
                    "type":"staffSchoolAssociation",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be retrieved.",
                            "required":true,
                            "type":"string"
                        },
                        {
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the resource''s identifier (using the \"Get By Id\" pattern).",
                    "notes":"This GET operation retrieves a resource by the specified resource identifier.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"staffSchoolAssociation"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"PUT",
                    "nickname":"putStaffSchoolAssociation",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be updated.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the PUT from updating a resource modified by another consumer.",
                          "type": "string",
                          "required": false
                        },
                        {
                            "paramType":"body",
                            "name":"staffSchoolAssociation",
                            "description":"The JSON representation of the \"staffSchoolAssociation\" resource to be updated.",
                            "required":true,
                            "type":"staffSchoolAssociation"
                        }
                    ],
                    "summary":"Updates or creates a resource based on the resource identifier.",
                    "notes":"The PUT operation is used to update or create a resource by identifier.  If the resource doesn''t exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource \"id\" is provided in the JSON body, it will be ignored as well.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is returned in a response header."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"DELETE",
                    "nickname":"deleteStaffSchoolAssociationById",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be deleted.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the DELETE from removing a resource modified by another consumer.",
                          "type": "string",
                          "required": false,
                          "allowMultiple": false
                        }
                    ],
                    "summary":"Deletes an existing resource using the resource identifier.",
                    "notes":"The DELETE operation is used to delete an existing resource by identifier.  If the resource doesn''t exist, an error will result (the resource will not be found).",
                    "responseMessages":[
                        {
                            "code":202,
                            "message":"The request has accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was successfully deleted."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        }
    ],
    "models": {
        "staffSchoolAssociation": {
            "id":"staffSchoolAssociation",
            "properties": {
                "id": {
                    "type":"string",
                    "required":true,
                    "description":"The unique identifier of the resource."
                }
                ,"schoolReference": {
                    "type":"schoolReference",
                    "required":true,
                    "description":"A reference to the related School resource."
                }
                ,"schoolYearTypeReference": {
                    "type":"schoolYearTypeReference",
                    "required":false,
                    "description":"A reference to the related SchoolYearType resource."
                }
                ,"staffReference": {
                    "type":"staffReference",
                    "required":true,
                    "description":"A reference to the related Staff resource."
                }
                ,"programAssignmentDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"The name of the program for which the individual is assigned; for example:  Regular education  Title I-Academic  Title I-Non-Academic  Special Education  Bilingual/English as a Second Language  NEDM: Program Assignment"
                }
                ,"academicSubjects": {
                    "type":"array",
                    "items":{"$ref":"staffSchoolAssociationAcademicSubject"},
                    "required":false,
                    "description":"An unordered collection of staffSchoolAssociationAcademicSubjects.  The teaching field taught by an individual: for example: English/Language Arts, Reading, Mathematics, Science, Social Sciences, etc."
                }
                ,"gradeLevels": {
                    "type":"array",
                    "items":{"$ref":"staffSchoolAssociationGradeLevel"},
                    "required":false,
                    "description":"An unordered collection of staffSchoolAssociationGradeLevels.  The set of grade levels for which the individual''s assignment is responsible."
                }
                ,"_etag": {
                    "type":"string",
                    "required":false,
                    "description":"A unique system-generated value that identifies the version of the resource."
                }
            }
        }
        , "schoolReference": {
            "id":"schoolReference",
            "properties": {
                "schoolId": {
                    "type":"integer",
                    "required":true,
                    "description":"The identifier assigned to a school by the State Education Agency (SEA)."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related school resource."
                }
            }
        }
        , "schoolYearTypeReference": {
            "id":"schoolYearTypeReference",
            "properties": {
                "schoolYear": {
                    "type":"integer",
                    "required":true,
                    "description":"Key for School"
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related schoolYearType resource."
                }
            }
        }
        , "staffReference": {
            "id":"staffReference",
            "properties": {
                "staffUniqueId": {
                    "type":"string",
                    "required":true,
                    "description":"A unique alpha-numeric code assigned to a staff."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related staff resource."
                }
            }
        }
        ,"staffSchoolAssociationAcademicSubject": {
            "id":"staffSchoolAssociationAcademicSubject",
            "properties": {
                "academicSubjectDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"Key for AcademicSubject"
                }
            }
        }
        ,"staffSchoolAssociationGradeLevel": {
            "id":"staffSchoolAssociationGradeLevel",
            "properties": {
                "gradeLevelDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
            }
        }
        ,"webServiceError": {
                    "id":"webServiceError",
                    "properties": {
                        "message": {
                            "type":"string",
                            "required":false,
                            "description":"The \"user-friendly\" error message."
                        },
                        "exceptionMessage": {
                            "type":"string",
                            "required":false,
                            "description":"The system-generated exception message."
                        },
                        "exceptionType": {
                            "type":"string",
                            "required":false,
                            "description":"The type of the exception."
                        },
                        "stackTrace": {
                            "type":"string",
                            "required":false,
                            "description":"The server-side stack trace (only available in DEBUG builds)."
                        }
                    }
                }
        ,"link": {
                "id":"link",
                "properties": {
                    "rel": {
                        "type":"string",
                        "required":false,
                        "description":"Describes the nature of the relationship to the referenced resource."
                    },
                    "href": {
                        "type":"string",
                        "required":false,
                        "description":"The URL to the related resource."
                    }
                }
            }
    }
}
        ', NULL, NULL)
INSERT [dataflow].[entity] ([ID], [Name], [Namespace], [URL], [Family], [Metadata], [CreateDate], [UpdateDate]) VALUES (9, N'staffSectionAssociations', NULL, N'https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/metadata/resources/api-docs/staffSectionAssociations', NULL, N'
{
  "apiVersion": "2.0",
  "swaggerVersion":"1.2",
  "basePath": "https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/api/v2.0/2017",
  "resourcePath":"/staffSectionAssociations",
  "produces": [
    "application/json"
  ],
  "apis" : [
        {
            "path":"/staffSectionAssociations",
            "description":"This association indicates the class sections to which a staff member is assigned.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getStaffSectionAssociationsAll",
                    "type":"array",
                    "items":{"$ref":"staffSectionAssociation"},
                    "parameters":[
                       {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        }
                    ],
                    "summary":"Retrieves resources based with paging capabilities (using the \"Get All\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get All\" pattern. In this version of the API there is support for paging.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The matching resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"array",
                            "items":{"$ref":"staffSectionAssociation"}                         },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors.  This will typically be an issue with the query parameters or their values."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getStaffSectionAssociationsAll",
                    "type":"array",
                    "items":{"$ref":"staffSectionAssociation"},
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        },
                        {
                            "paramType":"query",
                            "name":"staffUniqueId",
                            "type":"string",
                            "description":"A unique alpha-numeric code assigned to a staff.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"classroomIdentificationCode",
                            "type":"string",
                            "description":"A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"schoolId",
                            "type":"integer",
                            "description":"School Identity Column",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"classPeriodName",
                            "type":"string",
                            "description":"An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"localCourseCode",
                            "type":"string",
                            "description":"The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"schoolYear",
                            "type":"integer",
                            "description":"The identifier for the school year.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"termDescriptor",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"uniqueSectionCode",
                            "type":"string",
                            "description":"A unique identifier for the section, that is defined for a campus by the classroom, the subjects taught, and the instructors that are assigned.  NEDM: Unique Course Code",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"sequenceOfCourse",
                            "type":"integer",
                            "description":"When a section is part of a sequence of parts for a course, the number if the sequence.  If the course has only onle part, the value of this section attribute should be 1.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"classroomPositionDescriptor",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"beginDate",
                            "type":"date-time",
                            "description":"Month, day, and year of a teacher''s assignment to the Section. If blank, defaults to the first day of the first grading period for the Section.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"endDate",
                            "type":"date-time",
                            "description":"Month, day, and year of the last day of a staff member''s assignment to the Section.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"highlyQualifiedTeacher",
                            "type":"boolean",
                            "description":"An indication of whether a teacher is classified as highly qualified for his/her assignment according to state definition. This attribute indicates the teacher is highly qualified for this section being taught.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"teacherStudentDataLinkExclusion",
                            "type":"boolean",
                            "description":"Indicates that the entire section is excluded from calculation of value-added or growth attribution calculations used for a particular teacher evaluation.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"percentageContribution",
                            "type":"number",
                            "description":"Indicates the percentage of the total scheduled course time, academic standards, and/or learning activities delivered in this section by this staff member. A teacher of record designation may be based solely or partially on this contribution percentage.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"id",
                            "type":"string",
                            "description":"",
                            "required":false
                        }
                    ],
                    "summary":"Retrieves resources matching values of an example resource (using the \"Get By Example\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Example\" search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"staffSectionAssociation"
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getStaffSectionAssociationByKey",
                    "type":"staffSectionAssociation",
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"staffUniqueId",
                            "type":"string",
                            "description":"A unique alpha-numeric code assigned to a staff.",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"classroomIdentificationCode",
                            "type":"string",
                            "description":"A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"schoolId",
                            "type":"integer",
                            "description":"School Identity Column",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"classPeriodName",
                            "type":"string",
                            "description":"An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"localCourseCode",
                            "type":"string",
                            "description":"The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"schoolYear",
                            "type":"integer",
                            "description":"The identifier for the school year.",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"termDescriptor",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"uniqueSectionCode",
                            "type":"string",
                            "description":"A unique identifier for the section, that is defined for a campus by the classroom, the subjects taught, and the instructors that are assigned.  NEDM: Unique Course Code",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"sequenceOfCourse",
                            "type":"integer",
                            "description":"When a section is part of a sequence of parts for a course, the number if the sequence.  If the course has only onle part, the value of this section attribute should be 1.",
                            "required":true
                        }
                        ,{
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the values of the resource''s natural key (using the \"Get By Key\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Key\" search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"staffSectionAssociation"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                                {
                    "method":"POST",
                    "nickname":"postStaffSectionAssociations",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"body",
                            "name":"staffSectionAssociation",
                            "description":"The JSON representation of the \"staffSectionAssociation\" resource to be created or updated.",
                            "required":true,
                            "type":"staffSectionAssociation"
                        }
                    ],
                    "summary":"Creates or updates resources based on the natural key values of the supplied resource.",
                    "notes":"The POST operation can be used to create or update resources. In database terms, this is often referred to as an \"upsert\" operation (insert + update).  Clients should NOT include the resource \"id\" in the JSON body because it will result in an error (you must use a PUT operation to update a resource by \"id\"). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is available in the ETag header of the response."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        },
        {
            "path":"/staffSectionAssociations/{id}",
            "description":"This association indicates the class sections to which a staff member is assigned.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getStaffSectionAssociationsById",
                    "type":"staffSectionAssociation",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be retrieved.",
                            "required":true,
                            "type":"string"
                        },
                        {
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the resource''s identifier (using the \"Get By Id\" pattern).",
                    "notes":"This GET operation retrieves a resource by the specified resource identifier.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"staffSectionAssociation"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"PUT",
                    "nickname":"putStaffSectionAssociation",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be updated.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the PUT from updating a resource modified by another consumer.",
                          "type": "string",
                          "required": false
                        },
                        {
                            "paramType":"body",
                            "name":"staffSectionAssociation",
                            "description":"The JSON representation of the \"staffSectionAssociation\" resource to be updated.",
                            "required":true,
                            "type":"staffSectionAssociation"
                        }
                    ],
                    "summary":"Updates or creates a resource based on the resource identifier.",
                    "notes":"The PUT operation is used to update or create a resource by identifier.  If the resource doesn''t exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource \"id\" is provided in the JSON body, it will be ignored as well.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is returned in a response header."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"DELETE",
                    "nickname":"deleteStaffSectionAssociationById",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be deleted.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the DELETE from removing a resource modified by another consumer.",
                          "type": "string",
                          "required": false,
                          "allowMultiple": false
                        }
                    ],
                    "summary":"Deletes an existing resource using the resource identifier.",
                    "notes":"The DELETE operation is used to delete an existing resource by identifier.  If the resource doesn''t exist, an error will result (the resource will not be found).",
                    "responseMessages":[
                        {
                            "code":202,
                            "message":"The request has accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was successfully deleted."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        }
    ],
    "models": {
        "staffSectionAssociation": {
            "id":"staffSectionAssociation",
            "properties": {
                "id": {
                    "type":"string",
                    "required":true,
                    "description":"The unique identifier of the resource."
                }
                ,"sectionReference": {
                    "type":"sectionReference",
                    "required":true,
                    "description":"A reference to the related Section resource."
                }
                ,"staffReference": {
                    "type":"staffReference",
                    "required":true,
                    "description":"A reference to the related Staff resource."
                }
                ,"classroomPositionDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"beginDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"Month, day, and year of a teacher''s assignment to the Section. If blank, defaults to the first day of the first grading period for the Section."
                }
                ,"endDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"Month, day, and year of the last day of a staff member''s assignment to the Section."
                }
                ,"highlyQualifiedTeacher": {
                    "type":"boolean",
                    "required":false,
                    "description":"An indication of whether a teacher is classified as highly qualified for his/her assignment according to state definition. This attribute indicates the teacher is highly qualified for this section being taught."
                }
                ,"teacherStudentDataLinkExclusion": {
                    "type":"boolean",
                    "required":false,
                    "description":"Indicates that the entire section is excluded from calculation of value-added or growth attribution calculations used for a particular teacher evaluation."
                }
                ,"percentageContribution": {
                    "type":"number",
                    "required":false,
                    "description":"Indicates the percentage of the total scheduled course time, academic standards, and/or learning activities delivered in this section by this staff member. A teacher of record designation may be based solely or partially on this contribution percentage."
                }
                ,"_etag": {
                    "type":"string",
                    "required":false,
                    "description":"A unique system-generated value that identifies the version of the resource."
                }
            }
        }
        , "sectionReference": {
            "id":"sectionReference",
            "properties": {
                "schoolId": {
                    "type":"integer",
                    "required":true,
                    "description":"School Identity Column"
                }
                ,"classPeriodName": {
                    "type":"string",
                    "required":true,
                    "description":"An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period"
                }
                ,"classroomIdentificationCode": {
                    "type":"string",
                    "required":true,
                    "description":"A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity."
                }
                ,"localCourseCode": {
                    "type":"string",
                    "required":true,
                    "description":"The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students."
                }
                ,"termDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"schoolYear": {
                    "type":"integer",
                    "required":true,
                    "description":"The identifier for the school year."
                }
                ,"uniqueSectionCode": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned."
                }
                ,"sequenceOfCourse": {
                    "type":"integer",
                    "required":true,
                    "description":"When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related section resource."
                }
            }
        }
        , "staffReference": {
            "id":"staffReference",
            "properties": {
                "staffUniqueId": {
                    "type":"string",
                    "required":true,
                    "description":"A unique alpha-numeric code assigned to a staff."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related staff resource."
                }
            }
        }
        ,"webServiceError": {
                    "id":"webServiceError",
                    "properties": {
                        "message": {
                            "type":"string",
                            "required":false,
                            "description":"The \"user-friendly\" error message."
                        },
                        "exceptionMessage": {
                            "type":"string",
                            "required":false,
                            "description":"The system-generated exception message."
                        },
                        "exceptionType": {
                            "type":"string",
                            "required":false,
                            "description":"The type of the exception."
                        },
                        "stackTrace": {
                            "type":"string",
                            "required":false,
                            "description":"The server-side stack trace (only available in DEBUG builds)."
                        }
                    }
                }
        ,"link": {
                "id":"link",
                "properties": {
                    "rel": {
                        "type":"string",
                        "required":false,
                        "description":"Describes the nature of the relationship to the referenced resource."
                    },
                    "href": {
                        "type":"string",
                        "required":false,
                        "description":"The URL to the related resource."
                    }
                }
            }
    }
}
        ', NULL, NULL)
INSERT [dataflow].[entity] ([ID], [Name], [Namespace], [URL], [Family], [Metadata], [CreateDate], [UpdateDate]) VALUES (10, N'schools', NULL, N'https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/metadata/resources/api-docs/schools', NULL, N'
{
  "apiVersion": "2.0",
  "swaggerVersion":"1.2",
  "basePath": "https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/api/v2.0/2017",
  "resourcePath":"/schools",
  "produces": [
    "application/json"
  ],
  "apis" : [
        {
            "path":"/schools",
            "description":"This entity represents an educational organization that includes staff and students who participate in classes and educational activity groups.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getSchoolsAll",
                    "type":"array",
                    "items":{"$ref":"school"},
                    "parameters":[
                       {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        }
                    ],
                    "summary":"Retrieves resources based with paging capabilities (using the \"Get All\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get All\" pattern. In this version of the API there is support for paging.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The matching resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"array",
                            "items":{"$ref":"school"}                         },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors.  This will typically be an issue with the query parameters or their values."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getSchoolsAll",
                    "type":"array",
                    "items":{"$ref":"school"},
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        },
                        {
                            "paramType":"query",
                            "name":"schoolId",
                            "type":"integer",
                            "description":"The identifier assigned to a school by the State Education Agency (SEA).",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"localEducationAgencyId",
                            "type":"integer",
                            "description":"EducationOrganization Identity Column",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"type",
                            "type":"string", 
                            "description":"The instructional categorization of the school (e.g., Regular, Alternative)",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"charterStatusType",
                            "type":"string", 
                            "description":"A school or agency providing free public elementary or secondary education to eligible students under a specific charter granted by the state legislature or other appropriate authority and designated by such authority to be a charter school.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"titleIPartASchoolDesignationType",
                            "type":"string", 
                            "description":"Denotes the Title I Part A designation for the school.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"magnetSpecialProgramEmphasisSchoolType",
                            "type":"string", 
                            "description":"A school that has been designed: 1) to attract students of different racial/ethnic backgrounds for the purpose of reducing, preventing, or eliminating racial isolation; and/or 2)to provide an academic or social focus on a particular theme (e.g., science/math, performing arts, gifted/talented, or foreign language).",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"administrativeFundingControlDescriptor",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"internetAccessType",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"charterApprovalAgencyType",
                            "type":"string", 
                            "description":"Key for MagnetSpecialProgramEmphasisSchool",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"charterApprovalSchoolYear",
                            "type":"integer",
                            "description":"Key for School",
                            "required":false
                        }
                    ],
                    "summary":"Retrieves resources matching values of an example resource (using the \"Get By Example\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Example\" search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"school"
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getSchoolByKey",
                    "type":"school",
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"schoolId",
                            "type":"integer",
                            "description":"The identifier assigned to a school by the State Education Agency (SEA).",
                            "required":true
                        }
                        ,{
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the values of the resource''s natural key (using the \"Get By Key\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Key\" search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"school"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                                {
                    "method":"POST",
                    "nickname":"postSchools",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"body",
                            "name":"school",
                            "description":"The JSON representation of the \"school\" resource to be created or updated.",
                            "required":true,
                            "type":"school"
                        }
                    ],
                    "summary":"Creates or updates resources based on the natural key values of the supplied resource.",
                    "notes":"The POST operation can be used to create or update resources. In database terms, this is often referred to as an \"upsert\" operation (insert + update).  Clients should NOT include the resource \"id\" in the JSON body because it will result in an error (you must use a PUT operation to update a resource by \"id\"). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is available in the ETag header of the response."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        },
        {
            "path":"/schools/{id}",
            "description":"This entity represents an educational organization that includes staff and students who participate in classes and educational activity groups.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getSchoolsById",
                    "type":"school",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be retrieved.",
                            "required":true,
                            "type":"string"
                        },
                        {
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the resource''s identifier (using the \"Get By Id\" pattern).",
                    "notes":"This GET operation retrieves a resource by the specified resource identifier.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"school"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"PUT",
                    "nickname":"putSchool",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be updated.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the PUT from updating a resource modified by another consumer.",
                          "type": "string",
                          "required": false
                        },
                        {
                            "paramType":"body",
                            "name":"school",
                            "description":"The JSON representation of the \"school\" resource to be updated.",
                            "required":true,
                            "type":"school"
                        }
                    ],
                    "summary":"Updates or creates a resource based on the resource identifier.",
                    "notes":"The PUT operation is used to update or create a resource by identifier.  If the resource doesn''t exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource \"id\" is provided in the JSON body, it will be ignored as well.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is returned in a response header."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"DELETE",
                    "nickname":"deleteSchoolById",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be deleted.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the DELETE from removing a resource modified by another consumer.",
                          "type": "string",
                          "required": false,
                          "allowMultiple": false
                        }
                    ],
                    "summary":"Deletes an existing resource using the resource identifier.",
                    "notes":"The DELETE operation is used to delete an existing resource by identifier.  If the resource doesn''t exist, an error will result (the resource will not be found).",
                    "responseMessages":[
                        {
                            "code":202,
                            "message":"The request has accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was successfully deleted."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        }
    ],
    "models": {
        "school": {
            "id":"school",
            "properties": {
                "id": {
                    "type":"string",
                    "required":true,
                    "description":"The unique identifier of the resource."
                }
                ,"localEducationAgencyReference": {
                    "type":"localEducationAgencyReference",
                    "required":false,
                    "description":"A reference to the related LocalEducationAgency resource."
                }
                ,"charterApprovalSchoolYearTypeReference": {
                    "type":"schoolYearTypeReference",
                    "required":false,
                    "description":"A reference to the related SchoolYearType resource."
                }
                ,"schoolId": {
                    "type":"integer",
                    "required":true,
                    "description":"The identifier assigned to a school by the State Education Agency (SEA)."
                }
                ,"stateOrganizationId": {
                    "type":"string",
                    "required":true,
                    "description":"The identifier assigned to an education agency by the State Education Agency (SEA).  Also known as the State LEP ID.  NEDM: IdentificationCode, LEA Identifier (State)"
                }
                ,"nameOfInstitution": {
                    "type":"string",
                    "required":true,
                    "description":"The full, legally accepted name of the institution.  NEDM: Name of Institution"
                }
                ,"shortNameOfInstitution": {
                    "type":"string",
                    "required":false,
                    "description":"A short name for the institution."
                }
                ,"webSite": {
                    "type":"string",
                    "required":false,
                    "description":"The public web site address (URL) for the educational organization."
                }
                ,"operationalStatusType": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"type": {
                    "type":"string",
                    "required":false,
                    "description":"The instructional categorization of the school (e.g., Regular, Alternative)"
                }
                ,"charterStatusType": {
                    "type":"string",
                    "required":false,
                    "description":"A school or agency providing free public elementary or secondary education to eligible students under a specific charter granted by the state legislature or other appropriate authority and designated by such authority to be a charter school."
                }
                ,"titleIPartASchoolDesignationType": {
                    "type":"string",
                    "required":false,
                    "description":"Denotes the Title I Part A designation for the school."
                }
                ,"magnetSpecialProgramEmphasisSchoolType": {
                    "type":"string",
                    "required":false,
                    "description":"A school that has been designed: 1) to attract students of different racial/ethnic backgrounds for the purpose of reducing, preventing, or eliminating racial isolation; and/or 2)to provide an academic or social focus on a particular theme (e.g., science/math, performing arts, gifted/talented, or foreign language)."
                }
                ,"administrativeFundingControlDescriptor": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"internetAccessType": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"charterApprovalAgencyType": {
                    "type":"string",
                    "required":false,
                    "description":"Key for MagnetSpecialProgramEmphasisSchool"
                }
                ,"addresses": {
                    "type":"array",
                    "items":{"$ref":"educationOrganizationAddress"},
                    "required":true,
                    "description":"An unordered collection of educationOrganizationAddresses.  The set of elements that describes an address, including the street address, city, state and ZIP code."
                }
                ,"educationOrganizationCategories": {
                    "type":"array",
                    "items":{"$ref":"educationOrganizationCategory"},
                    "required":true,
                    "description":"An unordered collection of educationOrganizationCategories.  The classification of the education agency within the geographic boundaries of a state according to the level of administrative and operational control granted by the state."
                }
                ,"identificationCodes": {
                    "type":"array",
                    "items":{"$ref":"educationOrganizationIdentificationCode"},
                    "required":false,
                    "description":"An unordered collection of educationOrganizationIdentificationCodes.  A unique number or alphanumeric code that is assigned to an education organization by a school, school system, state, or other agency or entity."
                }
                ,"institutionTelephones": {
                    "type":"array",
                    "items":{"$ref":"educationOrganizationInstitutionTelephone"},
                    "required":false,
                    "description":"An unordered collection of educationOrganizationInstitutionTelephones.  The 10-digit telephone number, including the area code, for the person."
                }
                ,"internationalAddresses": {
                    "type":"array",
                    "items":{"$ref":"educationOrganizationInternationalAddress"},
                    "required":false,
                    "description":"An unordered collection of educationOrganizationInternationalAddresses.  The set of elements that describes an address, including the street address and country for international students."
                }
                ,"schoolCategories": {
                    "type":"array",
                    "items":{"$ref":"schoolCategory"},
                    "required":false,
                    "description":"An unordered collection of schoolCategories.  The category of school. (e.g., High School, Middle School or Elementary School)."
                }
                ,"gradeLevels": {
                    "type":"array",
                    "items":{"$ref":"schoolGradeLevel"},
                    "required":true,
                    "description":"An unordered collection of schoolGradeLevels.  The grade levels served at the school."
                }
                ,"_etag": {
                    "type":"string",
                    "required":false,
                    "description":"A unique system-generated value that identifies the version of the resource."
                }
            }
        }
        , "localEducationAgencyReference": {
            "id":"localEducationAgencyReference",
            "properties": {
                "localEducationAgencyId": {
                    "type":"integer",
                    "required":true,
                    "description":"The identifier assigned to a local education agency by the State Education Agency (SEA)."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related localEducationAgency resource."
                }
            }
        }
        , "schoolYearTypeReference": {
            "id":"schoolYearTypeReference",
            "properties": {
                "schoolYear": {
                    "type":"integer",
                    "required":true,
                    "description":"Key for School"
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related schoolYearType resource."
                }
            }
        }
        ,"schoolCategory": {
            "id":"schoolCategory",
            "properties": {
                "type": {
                    "type":"string",
                    "required":true,
                    "description":"The one or more categories of school. For example: High School, Middle School, and/or Elementary School."
                }
            }
        }
        ,"schoolGradeLevel": {
            "id":"schoolGradeLevel",
            "properties": {
                "gradeLevelDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"The grade levels served at the school."
                }
            }
        }
,         "educationOrganizationAddress": {
            "id":"educationOrganizationAddress",
            "properties": {
                "addressType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for Address"
                }
                ,"streetNumberName": {
                    "type":"string",
                    "required":true,
                    "description":"The street number and street name or post office box number of an address."
                }
                ,"apartmentRoomSuiteNumber": {
                    "type":"string",
                    "required":false,
                    "description":"The apartment, room, or suite number of an address."
                }
                ,"buildingSiteNumber": {
                    "type":"string",
                    "required":false,
                    "description":"The number of the building on the site, if more than one building shares the same address."
                }
                ,"city": {
                    "type":"string",
                    "required":true,
                    "description":"The name of the city in which an address is located."
                }
                ,"stateAbbreviationType": {
                    "type":"string",
                    "required":true,
                    "description":"The abbreviation for the state (within the United States) or outlying area in which an address is located."
                }
                ,"postalCode": {
                    "type":"string",
                    "required":true,
                    "description":"The five or nine digit zip code or overseas postal code portion of an address."
                }
                ,"nameOfCounty": {
                    "type":"string",
                    "required":false,
                    "description":"The name of the county, parish, borough, or comparable unit (within a state) in which an address is located."
                }
                ,"countyFIPSCode": {
                    "type":"string",
                    "required":false,
                    "description":"Definition The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the \"first-order subdivisions\" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code."
                }
                ,"latitude": {
                    "type":"string",
                    "required":false,
                    "description":"The geographic latitude of the physical address."
                }
                ,"longitude": {
                    "type":"string",
                    "required":false,
                    "description":"The geographic longitude of the physical address."
                }
                ,"beginDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The first date the address is valid. For physical addresses, the date the person moved to that address."
                }
                ,"endDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The last date the address is valid. For physical addresses, this would be the date the person moved from that address."
                }
            }
        }
        ,"educationOrganizationInternationalAddress": {
            "id":"educationOrganizationInternationalAddress",
            "properties": {
                "addressType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for Address"
                }
                ,"addressLine1": {
                    "type":"string",
                    "required":true,
                    "description":"The first line of the address."
                }
                ,"addressLine2": {
                    "type":"string",
                    "required":false,
                    "description":"The second line of the address."
                }
                ,"addressLine3": {
                    "type":"string",
                    "required":false,
                    "description":"The third line of the address."
                }
                ,"addressLine4": {
                    "type":"string",
                    "required":false,
                    "description":"The fourth line of the address."
                }
                ,"latitude": {
                    "type":"string",
                    "required":false,
                    "description":"The geographic latitude of the physical address."
                }
                ,"longitude": {
                    "type":"string",
                    "required":false,
                    "description":"The geographic longitude of the physical address."
                }
                ,"beginDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The first date the address is valid. For physical addresses, the date the person moved to that address."
                }
                ,"endDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The last date the address is valid. For physical addresses, this would be the date the person moved from that address."
                }
                ,"countryDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
            }
        }
        ,"educationOrganizationCategory": {
            "id":"educationOrganizationCategory",
            "properties": {
                "type": {
                    "type":"string",
                    "required":true,
                    "description":"The classification of the education agency within the geographic boundaries of a state according to the level of administrative and operational control granted by the state.  NEDM: Agency Type"
                }
            }
        }
        ,"educationOrganizationInstitutionTelephone": {
            "id":"educationOrganizationInstitutionTelephone",
            "properties": {
                "institutionTelephoneNumberType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for TelephoneNumber"
                }
                ,"telephoneNumber": {
                    "type":"string",
                    "required":true,
                    "description":"The telephone number including the area code, and extension, if applicable."
                }
            }
        }
        ,"educationOrganizationIdentificationCode": {
            "id":"educationOrganizationIdentificationCode",
            "properties": {
                "educationOrganizationIdentificationSystemDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"identificationCode": {
                    "type":"string",
                    "required":true,
                    "description":"A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, a state, or other agency or entity."
                }
            }
        }
        ,"webServiceError": {
                    "id":"webServiceError",
                    "properties": {
                        "message": {
                            "type":"string",
                            "required":false,
                            "description":"The \"user-friendly\" error message."
                        },
                        "exceptionMessage": {
                            "type":"string",
                            "required":false,
                            "description":"The system-generated exception message."
                        },
                        "exceptionType": {
                            "type":"string",
                            "required":false,
                            "description":"The type of the exception."
                        },
                        "stackTrace": {
                            "type":"string",
                            "required":false,
                            "description":"The server-side stack trace (only available in DEBUG builds)."
                        }
                    }
                }
        ,"link": {
                "id":"link",
                "properties": {
                    "rel": {
                        "type":"string",
                        "required":false,
                        "description":"Describes the nature of the relationship to the referenced resource."
                    },
                    "href": {
                        "type":"string",
                        "required":false,
                        "description":"The URL to the related resource."
                    }
                }
            }
    }
}
        ', NULL, NULL)
INSERT [dataflow].[entity] ([ID], [Name], [Namespace], [URL], [Family], [Metadata], [CreateDate], [UpdateDate]) VALUES (11, N'localEducationAgencies', NULL, N'https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/metadata/resources/api-docs/localEducationAgencies', NULL, N'
{
  "apiVersion": "2.0",
  "swaggerVersion":"1.2",
  "basePath": "https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/api/v2.0/2017",
  "resourcePath":"/localEducationAgencies",
  "produces": [
    "application/json"
  ],
  "apis" : [
        {
            "path":"/localEducationAgencies",
            "description":"This entity represents an administrative unit at the local level which exists primarily to operate schools or to contract for educational services. It includes school districts, charter schools, charter management organizations, or other local administrative organizations.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getLocalEducationAgenciesAll",
                    "type":"array",
                    "items":{"$ref":"localEducationAgency"},
                    "parameters":[
                       {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        }
                    ],
                    "summary":"Retrieves resources based with paging capabilities (using the \"Get All\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get All\" pattern. In this version of the API there is support for paging.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The matching resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"array",
                            "items":{"$ref":"localEducationAgency"}                         },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors.  This will typically be an issue with the query parameters or their values."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getLocalEducationAgenciesAll",
                    "type":"array",
                    "items":{"$ref":"localEducationAgency"},
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        },
                        {
                            "paramType":"query",
                            "name":"localEducationAgencyId",
                            "type":"integer",
                            "description":"The identifier assigned to a local education agency by the State Education Agency (SEA).",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"parentLocalEducationAgencyId",
                            "type":"integer",
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"categoryType",
                            "type":"string", 
                            "description":"Key for LEACategory",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"charterStatusType",
                            "type":"string", 
                            "description":"Key for CharterStatus",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"educationServiceCenterId",
                            "type":"integer",
                            "description":"EducationServiceCenter Identity Column",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"stateEducationAgencyId",
                            "type":"integer",
                            "description":"StateEducationAgency Identity Column",
                            "required":false
                        }
                    ],
                    "summary":"Retrieves resources matching values of an example resource (using the \"Get By Example\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Example\" search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"localEducationAgency"
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getLocalEducationAgencyByKey",
                    "type":"localEducationAgency",
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"localEducationAgencyId",
                            "type":"integer",
                            "description":"The identifier assigned to a local education agency by the State Education Agency (SEA).",
                            "required":true
                        }
                        ,{
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the values of the resource''s natural key (using the \"Get By Key\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Key\" search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"localEducationAgency"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                                {
                    "method":"POST",
                    "nickname":"postLocalEducationAgencies",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"body",
                            "name":"localEducationAgency",
                            "description":"The JSON representation of the \"localEducationAgency\" resource to be created or updated.",
                            "required":true,
                            "type":"localEducationAgency"
                        }
                    ],
                    "summary":"Creates or updates resources based on the natural key values of the supplied resource.",
                    "notes":"The POST operation can be used to create or update resources. In database terms, this is often referred to as an \"upsert\" operation (insert + update).  Clients should NOT include the resource \"id\" in the JSON body because it will result in an error (you must use a PUT operation to update a resource by \"id\"). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is available in the ETag header of the response."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        },
        {
            "path":"/localEducationAgencies/{id}",
            "description":"This entity represents an administrative unit at the local level which exists primarily to operate schools or to contract for educational services. It includes school districts, charter schools, charter management organizations, or other local administrative organizations.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getLocalEducationAgenciesById",
                    "type":"localEducationAgency",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be retrieved.",
                            "required":true,
                            "type":"string"
                        },
                        {
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the resource''s identifier (using the \"Get By Id\" pattern).",
                    "notes":"This GET operation retrieves a resource by the specified resource identifier.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"localEducationAgency"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"PUT",
                    "nickname":"putLocalEducationAgency",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be updated.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the PUT from updating a resource modified by another consumer.",
                          "type": "string",
                          "required": false
                        },
                        {
                            "paramType":"body",
                            "name":"localEducationAgency",
                            "description":"The JSON representation of the \"localEducationAgency\" resource to be updated.",
                            "required":true,
                            "type":"localEducationAgency"
                        }
                    ],
                    "summary":"Updates or creates a resource based on the resource identifier.",
                    "notes":"The PUT operation is used to update or create a resource by identifier.  If the resource doesn''t exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource \"id\" is provided in the JSON body, it will be ignored as well.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is returned in a response header."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"DELETE",
                    "nickname":"deleteLocalEducationAgencyById",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be deleted.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the DELETE from removing a resource modified by another consumer.",
                          "type": "string",
                          "required": false,
                          "allowMultiple": false
                        }
                    ],
                    "summary":"Deletes an existing resource using the resource identifier.",
                    "notes":"The DELETE operation is used to delete an existing resource by identifier.  If the resource doesn''t exist, an error will result (the resource will not be found).",
                    "responseMessages":[
                        {
                            "code":202,
                            "message":"The request has accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was successfully deleted."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        }
    ],
    "models": {
        "localEducationAgency": {
            "id":"localEducationAgency",
            "properties": {
                "id": {
                    "type":"string",
                    "required":true,
                    "description":"The unique identifier of the resource."
                }
                ,"educationServiceCenterReference": {
                    "type":"educationServiceCenterReference",
                    "required":false,
                    "description":"A reference to the related EducationServiceCenter resource."
                }
                ,"parentLocalEducationAgencyReference": {
                    "type":"localEducationAgencyReference",
                    "required":false,
                    "description":"A reference to the related LocalEducationAgency resource."
                }
                ,"stateEducationAgencyReference": {
                    "type":"stateEducationAgencyReference",
                    "required":false,
                    "description":"A reference to the related StateEducationAgency resource."
                }
                ,"localEducationAgencyId": {
                    "type":"integer",
                    "required":true,
                    "description":"The identifier assigned to a local education agency by the State Education Agency (SEA)."
                }
                ,"stateOrganizationId": {
                    "type":"string",
                    "required":true,
                    "description":"The identifier assigned to an education agency by the State Education Agency (SEA).  Also known as the State LEP ID.  NEDM: IdentificationCode, LEA Identifier (State)"
                }
                ,"nameOfInstitution": {
                    "type":"string",
                    "required":true,
                    "description":"The full, legally accepted name of the institution.  NEDM: Name of Institution"
                }
                ,"shortNameOfInstitution": {
                    "type":"string",
                    "required":false,
                    "description":"A short name for the institution."
                }
                ,"webSite": {
                    "type":"string",
                    "required":false,
                    "description":"The public web site address (URL) for the educational organization."
                }
                ,"operationalStatusType": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"categoryType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for LEACategory"
                }
                ,"charterStatusType": {
                    "type":"string",
                    "required":false,
                    "description":"Key for CharterStatus"
                }
                ,"addresses": {
                    "type":"array",
                    "items":{"$ref":"educationOrganizationAddress"},
                    "required":true,
                    "description":"An unordered collection of educationOrganizationAddresses.  The set of elements that describes an address, including the street address, city, state and ZIP code."
                }
                ,"educationOrganizationCategories": {
                    "type":"array",
                    "items":{"$ref":"educationOrganizationCategory"},
                    "required":true,
                    "description":"An unordered collection of educationOrganizationCategories.  The classification of the education agency within the geographic boundaries of a state according to the level of administrative and operational control granted by the state."
                }
                ,"identificationCodes": {
                    "type":"array",
                    "items":{"$ref":"educationOrganizationIdentificationCode"},
                    "required":false,
                    "description":"An unordered collection of educationOrganizationIdentificationCodes.  A unique number or alphanumeric code that is assigned to an education organization by a school, school system, state, or other agency or entity."
                }
                ,"institutionTelephones": {
                    "type":"array",
                    "items":{"$ref":"educationOrganizationInstitutionTelephone"},
                    "required":false,
                    "description":"An unordered collection of educationOrganizationInstitutionTelephones.  The 10-digit telephone number, including the area code, for the person."
                }
                ,"internationalAddresses": {
                    "type":"array",
                    "items":{"$ref":"educationOrganizationInternationalAddress"},
                    "required":false,
                    "description":"An unordered collection of educationOrganizationInternationalAddresses.  The set of elements that describes an address, including the street address and country for international students."
                }
                ,"accountabilities": {
                    "type":"array",
                    "items":{"$ref":"localEducationAgencyAccountability"},
                    "required":false,
                    "description":"An unordered collection of localEducationAgencyAccountabilities.  This entity maintains information about federal reporting and accountability for Local Education Agencies."
                }
                ,"_etag": {
                    "type":"string",
                    "required":false,
                    "description":"A unique system-generated value that identifies the version of the resource."
                }
            }
        }
        , "educationServiceCenterReference": {
            "id":"educationServiceCenterReference",
            "properties": {
                "educationServiceCenterId": {
                    "type":"integer",
                    "required":true,
                    "description":"The identifier assigned to an education service center by the State Education Agency (SEA)."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related educationServiceCenter resource."
                }
            }
        }
        , "localEducationAgencyReference": {
            "id":"localEducationAgencyReference",
            "properties": {
                "localEducationAgencyId": {
                    "type":"integer",
                    "required":true,
                    "description":"The identifier assigned to a local education agency by the State Education Agency (SEA)."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related localEducationAgency resource."
                }
            }
        }
        , "stateEducationAgencyReference": {
            "id":"stateEducationAgencyReference",
            "properties": {
                "stateEducationAgencyId": {
                    "type":"integer",
                    "required":true,
                    "description":"The identifier assigned to a state education agency by the StateEducationAgency (SEA)."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related stateEducationAgency resource."
                }
            }
        }
        ,"localEducationAgencyAccountability": {
            "id":"localEducationAgencyAccountability",
            "properties": {
                "schoolYearTypeReference": {
                    "type":"schoolYearTypeReference",
                    "required":true,
                    "description":"A reference to the related SchoolYearType resource."
                }
                ,"gunFreeSchoolsActReportingStatusType": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"schoolChoiceImplementStatusType": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
            }
        }
        , "schoolYearTypeReference": {
            "id":"schoolYearTypeReference",
            "properties": {
                "schoolYear": {
                    "type":"integer",
                    "required":true,
                    "description":"Key for School"
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related schoolYearType resource."
                }
            }
        }
,         "educationOrganizationAddress": {
            "id":"educationOrganizationAddress",
            "properties": {
                "addressType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for Address"
                }
                ,"streetNumberName": {
                    "type":"string",
                    "required":true,
                    "description":"The street number and street name or post office box number of an address."
                }
                ,"apartmentRoomSuiteNumber": {
                    "type":"string",
                    "required":false,
                    "description":"The apartment, room, or suite number of an address."
                }
                ,"buildingSiteNumber": {
                    "type":"string",
                    "required":false,
                    "description":"The number of the building on the site, if more than one building shares the same address."
                }
                ,"city": {
                    "type":"string",
                    "required":true,
                    "description":"The name of the city in which an address is located."
                }
                ,"stateAbbreviationType": {
                    "type":"string",
                    "required":true,
                    "description":"The abbreviation for the state (within the United States) or outlying area in which an address is located."
                }
                ,"postalCode": {
                    "type":"string",
                    "required":true,
                    "description":"The five or nine digit zip code or overseas postal code portion of an address."
                }
                ,"nameOfCounty": {
                    "type":"string",
                    "required":false,
                    "description":"The name of the county, parish, borough, or comparable unit (within a state) in which an address is located."
                }
                ,"countyFIPSCode": {
                    "type":"string",
                    "required":false,
                    "description":"Definition The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the \"first-order subdivisions\" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code."
                }
                ,"latitude": {
                    "type":"string",
                    "required":false,
                    "description":"The geographic latitude of the physical address."
                }
                ,"longitude": {
                    "type":"string",
                    "required":false,
                    "description":"The geographic longitude of the physical address."
                }
                ,"beginDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The first date the address is valid. For physical addresses, the date the person moved to that address."
                }
                ,"endDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The last date the address is valid. For physical addresses, this would be the date the person moved from that address."
                }
            }
        }
        ,"educationOrganizationInternationalAddress": {
            "id":"educationOrganizationInternationalAddress",
            "properties": {
                "addressType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for Address"
                }
                ,"addressLine1": {
                    "type":"string",
                    "required":true,
                    "description":"The first line of the address."
                }
                ,"addressLine2": {
                    "type":"string",
                    "required":false,
                    "description":"The second line of the address."
                }
                ,"addressLine3": {
                    "type":"string",
                    "required":false,
                    "description":"The third line of the address."
                }
                ,"addressLine4": {
                    "type":"string",
                    "required":false,
                    "description":"The fourth line of the address."
                }
                ,"latitude": {
                    "type":"string",
                    "required":false,
                    "description":"The geographic latitude of the physical address."
                }
                ,"longitude": {
                    "type":"string",
                    "required":false,
                    "description":"The geographic longitude of the physical address."
                }
                ,"beginDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The first date the address is valid. For physical addresses, the date the person moved to that address."
                }
                ,"endDate": {
                    "type":"date-time",
                    "required":false,
                    "description":"The last date the address is valid. For physical addresses, this would be the date the person moved from that address."
                }
                ,"countryDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
            }
        }
        ,"educationOrganizationCategory": {
            "id":"educationOrganizationCategory",
            "properties": {
                "type": {
                    "type":"string",
                    "required":true,
                    "description":"The classification of the education agency within the geographic boundaries of a state according to the level of administrative and operational control granted by the state.  NEDM: Agency Type"
                }
            }
        }
        ,"educationOrganizationInstitutionTelephone": {
            "id":"educationOrganizationInstitutionTelephone",
            "properties": {
                "institutionTelephoneNumberType": {
                    "type":"string",
                    "required":true,
                    "description":"Key for TelephoneNumber"
                }
                ,"telephoneNumber": {
                    "type":"string",
                    "required":true,
                    "description":"The telephone number including the area code, and extension, if applicable."
                }
            }
        }
        ,"educationOrganizationIdentificationCode": {
            "id":"educationOrganizationIdentificationCode",
            "properties": {
                "educationOrganizationIdentificationSystemDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"identificationCode": {
                    "type":"string",
                    "required":true,
                    "description":"A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, a state, or other agency or entity."
                }
            }
        }
        ,"webServiceError": {
                    "id":"webServiceError",
                    "properties": {
                        "message": {
                            "type":"string",
                            "required":false,
                            "description":"The \"user-friendly\" error message."
                        },
                        "exceptionMessage": {
                            "type":"string",
                            "required":false,
                            "description":"The system-generated exception message."
                        },
                        "exceptionType": {
                            "type":"string",
                            "required":false,
                            "description":"The type of the exception."
                        },
                        "stackTrace": {
                            "type":"string",
                            "required":false,
                            "description":"The server-side stack trace (only available in DEBUG builds)."
                        }
                    }
                }
        ,"link": {
                "id":"link",
                "properties": {
                    "rel": {
                        "type":"string",
                        "required":false,
                        "description":"Describes the nature of the relationship to the referenced resource."
                    },
                    "href": {
                        "type":"string",
                        "required":false,
                        "description":"The URL to the related resource."
                    }
                }
            }
    }
}
        ', NULL, NULL)
INSERT [dataflow].[entity] ([ID], [Name], [Namespace], [URL], [Family], [Metadata], [CreateDate], [UpdateDate]) VALUES (12, N'sections', NULL, N'https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/metadata/resources/api-docs/sections', NULL, N'
{
  "apiVersion": "2.0",
  "swaggerVersion":"1.2",
  "basePath": "https://api01.dataflow.betaspaces.com/EdFi.Ods.WebApi/api/v2.0/2017",
  "resourcePath":"/sections",
  "produces": [
    "application/json"
  ],
  "apis" : [
        {
            "path":"/sections",
            "description":"This entity represents a setting in which organized instruction of course content is provided, in-person or otherwise, to one or more students for a given period of time. A course offering may be offered to more than one section.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getSectionsAll",
                    "type":"array",
                    "items":{"$ref":"section"},
                    "parameters":[
                       {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        }
                    ],
                    "summary":"Retrieves resources based with paging capabilities (using the \"Get All\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get All\" pattern. In this version of the API there is support for paging.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The matching resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"array",
                            "items":{"$ref":"section"}                         },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors.  This will typically be an issue with the query parameters or their values."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getSectionsAll",
                    "type":"array",
                    "items":{"$ref":"section"},
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        },
                        {
                            "paramType":"query",
                            "name":"schoolId",
                            "type":"integer",
                            "description":"School Identity Column",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"classPeriodName",
                            "type":"string",
                            "description":"An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"classroomIdentificationCode",
                            "type":"string",
                            "description":"A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"localCourseCode",
                            "type":"string",
                            "description":"The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"termDescriptor",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"schoolYear",
                            "type":"integer",
                            "description":"The identifier for the school year.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"uniqueSectionCode",
                            "type":"string",
                            "description":"A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"sequenceOfCourse",
                            "type":"integer",
                            "description":"When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"educationalEnvironmentType",
                            "type":"string", 
                            "description":"The setting in which a child receives education and related services; for example:  Center-based instruction  Home-based instruction  Hospital class  Mainstream  Residential care and treatment facility  ....",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"mediumOfInstructionType",
                            "type":"string", 
                            "description":"The media through which teachers provide instruction to students and students and teachers communicate about instructional matters; for example:  Technology-based instruction in classroom  Correspondence instruction  Face-to-face instruction  Virtual/On-line Distance learning  Center-based instruction  ...",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"populationServedType",
                            "type":"string", 
                            "description":"The population for which the course was designed; for example:  Bilingual students  Remedial education students  Gifted and talented students  Career and Technical Education students  Special education students  ....",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"availableCreditType",
                            "type":"string", 
                            "description":"The type of credits or units of value awarded for the completion of a course.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"availableCreditConversion",
                            "type":"number",
                            "description":"Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"instructionLanguageDescriptor",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"availableCredits",
                            "type":"number",
                            "description":"Credits or units of value awarded for the completion of a course.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"id",
                            "type":"string",
                            "description":"",
                            "required":false
                        }
                    ],
                    "summary":"Retrieves resources matching values of an example resource (using the \"Get By Example\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Example\" search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"section"
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getSectionByKey",
                    "type":"section",
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"schoolId",
                            "type":"integer",
                            "description":"School Identity Column",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"classPeriodName",
                            "type":"string",
                            "description":"An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"classroomIdentificationCode",
                            "type":"string",
                            "description":"A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"localCourseCode",
                            "type":"string",
                            "description":"The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"termDescriptor",
                            "type":"string", 
                            "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"schoolYear",
                            "type":"integer",
                            "description":"The identifier for the school year.",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"uniqueSectionCode",
                            "type":"string",
                            "description":"A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned.",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"sequenceOfCourse",
                            "type":"integer",
                            "description":"When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1.",
                            "required":true
                        }
                        ,{
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the values of the resource''s natural key (using the \"Get By Key\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Key\" search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"section"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                                {
                    "method":"POST",
                    "nickname":"postSections",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"body",
                            "name":"section",
                            "description":"The JSON representation of the \"section\" resource to be created or updated.",
                            "required":true,
                            "type":"section"
                        }
                    ],
                    "summary":"Creates or updates resources based on the natural key values of the supplied resource.",
                    "notes":"The POST operation can be used to create or update resources. In database terms, this is often referred to as an \"upsert\" operation (insert + update).  Clients should NOT include the resource \"id\" in the JSON body because it will result in an error (you must use a PUT operation to update a resource by \"id\"). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is available in the ETag header of the response."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        },
        {
            "path":"/sections/{id}",
            "description":"This entity represents a setting in which organized instruction of course content is provided, in-person or otherwise, to one or more students for a given period of time. A course offering may be offered to more than one section.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getSectionsById",
                    "type":"section",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be retrieved.",
                            "required":true,
                            "type":"string"
                        },
                        {
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the resource''s identifier (using the \"Get By Id\" pattern).",
                    "notes":"This GET operation retrieves a resource by the specified resource identifier.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"section"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"PUT",
                    "nickname":"putSection",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be updated.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the PUT from updating a resource modified by another consumer.",
                          "type": "string",
                          "required": false
                        },
                        {
                            "paramType":"body",
                            "name":"section",
                            "description":"The JSON representation of the \"section\" resource to be updated.",
                            "required":true,
                            "type":"section"
                        }
                    ],
                    "summary":"Updates or creates a resource based on the resource identifier.",
                    "notes":"The PUT operation is used to update or create a resource by identifier.  If the resource doesn''t exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource \"id\" is provided in the JSON body, it will be ignored as well.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is returned in a response header."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"DELETE",
                    "nickname":"deleteSectionById",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be deleted.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the DELETE from removing a resource modified by another consumer.",
                          "type": "string",
                          "required": false,
                          "allowMultiple": false
                        }
                    ],
                    "summary":"Deletes an existing resource using the resource identifier.",
                    "notes":"The DELETE operation is used to delete an existing resource by identifier.  If the resource doesn''t exist, an error will result (the resource will not be found).",
                    "responseMessages":[
                        {
                            "code":202,
                            "message":"The request has accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was successfully deleted."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        }
    ],
    "models": {
        "section": {
            "id":"section",
            "properties": {
                "id": {
                    "type":"string",
                    "required":true,
                    "description":"The unique identifier of the resource."
                }
                ,"classPeriodReference": {
                    "type":"classPeriodReference",
                    "required":true,
                    "description":"A reference to the related ClassPeriod resource."
                }
                ,"courseOfferingReference": {
                    "type":"courseOfferingReference",
                    "required":true,
                    "description":"A reference to the related CourseOffering resource."
                }
                ,"locationReference": {
                    "type":"locationReference",
                    "required":true,
                    "description":"A reference to the related Location resource."
                }
                ,"schoolReference": {
                    "type":"schoolReference",
                    "required":true,
                    "description":"A reference to the related School resource."
                }
                ,"uniqueSectionCode": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned."
                }
                ,"sequenceOfCourse": {
                    "type":"integer",
                    "required":true,
                    "description":"When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1."
                }
                ,"educationalEnvironmentType": {
                    "type":"string",
                    "required":false,
                    "description":"The setting in which a child receives education and related services; for example:  Center-based instruction  Home-based instruction  Hospital class  Mainstream  Residential care and treatment facility  ...."
                }
                ,"mediumOfInstructionType": {
                    "type":"string",
                    "required":false,
                    "description":"The media through which teachers provide instruction to students and students and teachers communicate about instructional matters; for example:  Technology-based instruction in classroom  Correspondence instruction  Face-to-face instruction  Virtual/On-line Distance learning  Center-based instruction  ..."
                }
                ,"populationServedType": {
                    "type":"string",
                    "required":false,
                    "description":"The population for which the course was designed; for example:  Bilingual students  Remedial education students  Gifted and talented students  Career and Technical Education students  Special education students  ...."
                }
                ,"availableCreditType": {
                    "type":"string",
                    "required":false,
                    "description":"The type of credits or units of value awarded for the completion of a course."
                }
                ,"availableCreditConversion": {
                    "type":"number",
                    "required":false,
                    "description":"Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units."
                }
                ,"instructionLanguageDescriptor": {
                    "type":"string",
                    "required":false,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                ,"availableCredits": {
                    "type":"number",
                    "required":false,
                    "description":"Credits or units of value awarded for the completion of a course."
                }
                ,"characteristics": {
                    "type":"array",
                    "items":{"$ref":"sectionCharacteristic"},
                    "required":false,
                    "description":"An unordered collection of sectionCharacteristics.  Reflects important characteristics of the Section, such as whether or not attendance is taken and the Section is graded."
                }
                ,"programs": {
                    "type":"array",
                    "items":{"$ref":"sectionProgram"},
                    "required":false,
                    "description":"An unordered collection of sectionPrograms.  Optional reference to program (e.g., CTE) to which the section is associated."
                }
                ,"_etag": {
                    "type":"string",
                    "required":false,
                    "description":"A unique system-generated value that identifies the version of the resource."
                }
            }
        }
        , "classPeriodReference": {
            "id":"classPeriodReference",
            "properties": {
                "schoolId": {
                    "type":"integer",
                    "required":true,
                    "description":"School Identity Column"
                }
                ,"name": {
                    "type":"string",
                    "required":true,
                    "description":"An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period"
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related classPeriod resource."
                }
            }
        }
        , "courseOfferingReference": {
            "id":"courseOfferingReference",
            "properties": {
                "localCourseCode": {
                    "type":"string",
                    "required":true,
                    "description":"The local code assigned by the LEA that identifies the organization of subject matter and related learning experiences provided for the instruction of students."
                }
                ,"schoolId": {
                    "type":"integer",
                    "required":true,
                    "description":"School Identity Column  "
                }
                ,"schoolYear": {
                    "type":"integer",
                    "required":true,
                    "description":"The identifier for the school year."
                }
                ,"termDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related courseOffering resource."
                }
            }
        }
        , "locationReference": {
            "id":"locationReference",
            "properties": {
                "schoolId": {
                    "type":"integer",
                    "required":true,
                    "description":"Location Identity Column"
                }
                ,"classroomIdentificationCode": {
                    "type":"string",
                    "required":true,
                    "description":"A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related location resource."
                }
            }
        }
        , "schoolReference": {
            "id":"schoolReference",
            "properties": {
                "schoolId": {
                    "type":"integer",
                    "required":true,
                    "description":"The identifier assigned to a school by the State Education Agency (SEA)."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related school resource."
                }
            }
        }
        ,"sectionProgram": {
            "id":"sectionProgram",
            "properties": {
                "programReference": {
                    "type":"programReference",
                    "required":true,
                    "description":"A reference to the related Program resource."
                }
            }
        }
        , "programReference": {
            "id":"programReference",
            "properties": {
                "educationOrganizationId": {
                    "type":"integer",
                    "required":true,
                    "description":"EducationOrganization Identity Column"
                }
                ,"type": {
                    "type":"string",
                    "required":true,
                    "description":"Key for Program"
                }
                ,"name": {
                    "type":"string",
                    "required":true,
                    "description":"The formal name of the program of instruction, training, services or benefits available through federal, state, or local agencies."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related program resource."
                }
            }
        }
        ,"sectionCharacteristic": {
            "id":"sectionCharacteristic",
            "properties": {
                "descriptor": {
                    "type":"string",
                    "required":true,
                    "description":"A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table."
                }
            }
        }
        ,"webServiceError": {
                    "id":"webServiceError",
                    "properties": {
                        "message": {
                            "type":"string",
                            "required":false,
                            "description":"The \"user-friendly\" error message."
                        },
                        "exceptionMessage": {
                            "type":"string",
                            "required":false,
                            "description":"The system-generated exception message."
                        },
                        "exceptionType": {
                            "type":"string",
                            "required":false,
                            "description":"The type of the exception."
                        },
                        "stackTrace": {
                            "type":"string",
                            "required":false,
                            "description":"The server-side stack trace (only available in DEBUG builds)."
                        }
                    }
                }
        ,"link": {
                "id":"link",
                "properties": {
                    "rel": {
                        "type":"string",
                        "required":false,
                        "description":"Describes the nature of the relationship to the referenced resource."
                    },
                    "href": {
                        "type":"string",
                        "required":false,
                        "description":"The URL to the related resource."
                    }
                }
            }
    }
}
        ', NULL, NULL)
INSERT [dataflow].[entity] ([ID], [Name], [Namespace], [URL], [Family], [Metadata], [CreateDate], [UpdateDate]) VALUES (13, N'assessmentItem', NULL, N'https://', NULL, N'{
  "apiVersion": "2.0",
  "swaggerVersion":"1.2",
  "basePath": "https://edfiodsapiwebsite-sandbox-xm4wsvuqhyvva.azurewebsites.net/api/v2.0/2017",
  "resourcePath":"/assessmentItems",
  "produces": [
    "application/json"
  ],
  "apis" : [
        {
            "path":"/assessmentItems",
            "description":"This entity represents one of many single measures that make up an assessment.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getAssessmentItemsAll",
                    "type":"array",
                    "items":{"$ref":"assessmentItem"},
                    "parameters":[
                       {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        }
                    ],
                    "summary":"Retrieves resources based with paging capabilities (using the \"Get All\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get All\" pattern. In this version of the API there is support for paging.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The matching resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"array",
                            "items":{"$ref":"assessmentItem"}                         },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors.  This will typically be an issue with the query parameters or their values."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getAssessmentItemsAll",
                    "type":"array",
                    "items":{"$ref":"assessmentItem"},
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"offset",
                            "description":"Indicates how many items should be skipped before returning results.",
                            "type":"integer",
                            "required":false
                        },
                        {
                            "paramType":"query",
                            "name":"limit",
                            "description":"Indicates the maximum number of items that should be returned in the results (defaults to 25).",
                            "type":"integer",
                            "required":false,
                            "minimum":1,
                            "maximum":250
                        },
                        {
                            "paramType":"query",
                            "name":"assessmentTitle",
                            "type":"string",
                            "description":"The title or name of the assessment.  NEDM: Assessment Title",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"academicSubjectDescriptor",
                            "type":"string", 
                            "description":"The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"assessedGradeLevelDescriptor",
                            "type":"string", 
                            "description":"The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"version",
                            "type":"integer",
                            "description":"The version identifier for the test assessment.  NEDM: Assessment Version",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"identificationCode",
                            "type":"string",
                            "description":"A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, a state, or other agency or entity.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"categoryType",
                            "type":"string", 
                            "description":"Category or type of the assessment item.  For example:  Multiple choice  Analytic  Prose  ....",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"maxRawScore",
                            "type":"integer",
                            "description":"The maximum raw score achievable across all assessment items that are correct and scored at the maximum.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"correctResponse",
                            "type":"string",
                            "description":"The correct response for the assessment item.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"expectedTimeAssessed",
                            "type":"string",
                            "description":"The duration of time allotted for the AssessmentItem.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"nomenclature",
                            "type":"string",
                            "description":"Reflects the common nomenclature for an element.",
                            "required":false
                        }
                        ,{
                            "paramType":"query",
                            "name":"id",
                            "type":"string",
                            "description":"",
                            "required":false
                        }
                    ],
                    "summary":"Retrieves resources matching values of an example resource (using the \"Get By Example\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Example\" search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource(s) were successfully retrieved.  If no instances are found will return an empty collection.",
                            "responseModel":"assessmentItem"
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"GET",
                    "nickname":"getAssessmentItemByKey",
                    "type":"assessmentItem",
                    "parameters":[
                        {
                            "paramType":"query",
                            "name":"assessmentTitle",
                            "type":"string",
                            "description":"The title or name of the assessment.  NEDM: Assessment Title",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"academicSubjectDescriptor",
                            "type":"string", 
                            "description":"The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"assessedGradeLevelDescriptor",
                            "type":"string", 
                            "description":"The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"version",
                            "type":"integer",
                            "description":"The version identifier for the test assessment.  NEDM: Assessment Version",
                            "required":true
                        }
                        ,{
                            "paramType":"query",
                            "name":"identificationCode",
                            "type":"string",
                            "description":"A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, a state, or other agency or entity.",
                            "required":true
                        }
                        ,{
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the values of the resource''s natural key (using the \"Get By Key\" pattern).",
                    "notes":"This GET operation provides access to resources using the \"Get by Key\" search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"assessmentItem"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                                {
                    "method":"POST",
                    "nickname":"postAssessmentItems",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"body",
                            "name":"assessmentItem",
                            "description":"The JSON representation of the \"assessmentItem\" resource to be created or updated.",
                            "required":true,
                            "type":"assessmentItem"
                        }
                    ],
                    "summary":"Creates or updates resources based on the natural key values of the supplied resource.",
                    "notes":"The POST operation can be used to create or update resources. In database terms, this is often referred to as an \"upsert\" operation (insert + update).  Clients should NOT include the resource \"id\" in the JSON body because it will result in an error (you must use a PUT operation to update a resource by \"id\"). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is available in the ETag header of the response."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        },
        {
            "path":"/assessmentItems/{id}",
            "description":"This entity represents one of many single measures that make up an assessment.",
            "operations":[
                {
                    "method":"GET",
                    "nickname":"getAssessmentItemsById",
                    "type":"assessmentItem",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be retrieved.",
                            "required":true,
                            "type":"string"
                        },
                        {
                            "paramType":"header",
                            "name":"If-None-Match",
                            "description":"The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.",
                            "required":false,
                            "type":"string"
                        }
                    ],
                    "summary":"Retrieves a specific resource using the resource''s identifier (using the \"Get By Id\" pattern).",
                    "notes":"This GET operation retrieves a resource by the specified resource identifier.",
                    "responseMessages":[
                        {
                            "code":200,
                            "message":"The resource was successfully retrieved.",
                            "responseModel":"assessmentItem"
                        },
                        {
                            "code":304,
                            "message":"The resource''s current server-side ETag value matched the If-None-Match header value supplied with the request indicating the resource has not been modified."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"PUT",
                    "nickname":"putAssessmentItem",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be updated.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the PUT from updating a resource modified by another consumer.",
                          "type": "string",
                          "required": false
                        },
                        {
                            "paramType":"body",
                            "name":"assessmentItem",
                            "description":"The JSON representation of the \"assessmentItem\" resource to be updated.",
                            "required":true,
                            "type":"assessmentItem"
                        }
                    ],
                    "summary":"Updates or creates a resource based on the resource identifier.",
                    "notes":"The PUT operation is used to update or create a resource by identifier.  If the resource doesn''t exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource \"id\" is provided in the JSON body, it will be ignored as well.",
                    "responseMessages":[
                        {
                            "code":201,
                            "message":"The resource was created.  An ETag value is available in the ETag header, and the location of the resource is available in the Location header of the response."
                        },
                        {
                            "code":202,
                            "message":"The resource has been validated and accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was updated.  An updated ETag value is returned in a response header."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                },
                {
                    "method":"DELETE",
                    "nickname":"deleteAssessmentItemById",
                    "type":"void",
                    "parameters":[
                        {
                            "paramType":"path",
                            "name":"id",
                            "description":"A resource identifier specifying the resource to be deleted.",
                            "required":true,
                            "type":"string"
                        },
                        {
                          "paramType": "header",
                          "name": "If-Match",
                          "description": "The ETag header value used to prevent the DELETE from removing a resource modified by another consumer.",
                          "type": "string",
                          "required": false,
                          "allowMultiple": false
                        }
                    ],
                    "summary":"Deletes an existing resource using the resource identifier.",
                    "notes":"The DELETE operation is used to delete an existing resource by identifier.  If the resource doesn''t exist, an error will result (the resource will not be found).",
                    "responseMessages":[
                        {
                            "code":202,
                            "message":"The request has accepted by the service, but processing has not yet completed due to current system load. Processing may still fail due to violation of referential integrity requirements."
                        },
                        {
                            "code":204,
                            "message":"The resource was successfully deleted."
                        },
                        {
                            "code":400,
                            "message":"Bad Request.  The request was invalid and cannot be completed.  See the response body for specific validation errors."
                        },
                        {
                            "code":401,
                            "message":"Unauthorized.  The request requires authentication.  The OAuth bearer token was either not provided or is invalid.  The operation may succeed once authenication has been successfully completed."
                        },
                        {
                            "code":403,
                            "message":"Forbidden.  The request cannot be completed in the current authorization context.  Contact your administrator if you believe this operation should be allowed."
                        },
                        {
                            "code":404,
                            "message":"The resource could not be found."
                        },
                        {
                            "code":409,
                            "message":"Conflict.  The request cannot be completed because it would result in an invalid state.  See the response body for details."
                        },
                        {
                            "code":412,
                            "message":"The resource''s current server-side ETag value does not match the supplied If-Match header value in the request.  This indicates the resource has been modified by another consumer."
                        },
                        {
                            "code":500,
                            "message":"An unhandled error occurred on the server. See the response body for details.",
                            "responseModel":"webServiceError"
                        }
                    ]
                }
            ]
        }
    ],
    "models": {
        "assessmentItem": {
            "id":"assessmentItem",
            "properties": {
                "id": {
                    "type":"string",
                    "required":true,
                    "description":"The unique identifier of the resource."
                }
                ,"assessmentReference": {
                    "type":"assessmentReference",
                    "required":true,
                    "description":"A reference to the related Assessment resource."
                }
                ,"identificationCode": {
                    "type":"string",
                    "required":true,
                    "description":"A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, a state, or other agency or entity."
                }
                ,"categoryType": {
                    "type":"string",
                    "required":false,
                    "description":"Category or type of the assessment item.  For example:  Multiple choice  Analytic  Prose  ...."
                }
                ,"maxRawScore": {
                    "type":"integer",
                    "required":false,
                    "description":"The maximum raw score achievable across all assessment items that are correct and scored at the maximum."
                }
                ,"correctResponse": {
                    "type":"string",
                    "required":false,
                    "description":"The correct response for the assessment item."
                }
                ,"expectedTimeAssessed": {
                    "type":"string",
                    "required":false,
                    "description":"The duration of time allotted for the AssessmentItem."
                }
                ,"nomenclature": {
                    "type":"string",
                    "required":false,
                    "description":"Reflects the common nomenclature for an element."
                }
                ,"learningStandards": {
                    "type":"array",
                    "items":{"$ref":"assessmentItemLearningStandard"},
                    "required":false,
                    "description":"An unordered collection of assessmentItemLearningStandards.  Learning Standard tested by this item."
                }
                ,"_etag": {
                    "type":"string",
                    "required":false,
                    "description":"A unique system-generated value that identifies the version of the resource."
                }
            }
        }
        , "assessmentReference": {
            "id":"assessmentReference",
            "properties": {
                "title": {
                    "type":"string",
                    "required":true,
                    "description":"The title or name of the assessment.  NEDM: Assessment Title"
                }
                ,"assessedGradeLevelDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ..."
                }
                ,"academicSubjectDescriptor": {
                    "type":"string",
                    "required":true,
                    "description":"The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject"
                }
                ,"version": {
                    "type":"integer",
                    "required":true,
                    "description":"The version identifier for the assessment."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related assessment resource."
                }
            }
        }
        ,"assessmentItemLearningStandard": {
            "id":"assessmentItemLearningStandard",
            "properties": {
                "learningStandardReference": {
                    "type":"learningStandardReference",
                    "required":true,
                    "description":"A reference to the related LearningStandard resource."
                }
            }
        }
        , "learningStandardReference": {
            "id":"learningStandardReference",
            "properties": {
                "learningStandardId": {
                    "type":"string",
                    "required":true,
                    "description":"A unique number or alphanumeric code assigned to a Learning Standard."
                }
                , "link": {
                    "type":"link",
                    "required":false,
                    "description":"Represents a hyperlink to the related learningStandard resource."
                }
            }
        }
        ,"webServiceError": {
                    "id":"webServiceError",
                    "properties": {
                        "message": {
                            "type":"string",
                            "required":false,
                            "description":"The \"user-friendly\" error message."
                        },
                        "exceptionMessage": {
                            "type":"string",
                            "required":false,
                            "description":"The system-generated exception message."
                        },
                        "exceptionType": {
                            "type":"string",
                            "required":false,
                            "description":"The type of the exception."
                        },
                        "stackTrace": {
                            "type":"string",
                            "required":false,
                            "description":"The server-side stack trace (only available in DEBUG builds)."
                        }
                    }
                }
        ,"link": {
                "id":"link",
                "properties": {
                    "rel": {
                        "type":"string",
                        "required":false,
                        "description":"Describes the nature of the relationship to the referenced resource."
                    },
                    "href": {
                        "type":"string",
                        "required":false,
                        "description":"The URL to the related resource."
                    }
                }
            }
    }
}
        ', NULL, NULL)
SET IDENTITY_INSERT [dataflow].[entity] OFF
GO