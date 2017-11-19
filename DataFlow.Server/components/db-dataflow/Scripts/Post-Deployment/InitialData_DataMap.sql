/*    ==Scripting Parameters==

    Source Database Engine Edition : Microsoft Azure SQL Database Edition
    Source Database Engine Type : Microsoft Azure SQL Database

    Target Database Engine Edition : Microsoft Azure SQL Database Edition
    Target Database Engine Type : Microsoft Azure SQL Database
*/
SET IDENTITY_INSERT [dataflow].[datamap] ON 

INSERT [dataflow].[datamap] ([ID], [Name], [EntityID], [Map], [CreateDate], [UpdateDate]) VALUES (3, N'M:Class Progress - Student', 1, N'{
    "studentUniqueId": {
        "data-type": "string",
        "source": "column",
        "source-column": "Student Primary ID"
    },
	"firstName": {
	    "data-type": "string",
        "source": "column",
        "source-column": "Student First Name"     
	},
	"lastSurname": {
	    "data-type": "string",
        "source": "column",
        "source-column": "Student Last Name"  
	},
  "sexType": {
    "data-type": "string",
    "source": "lookup_table",
    "source-table": "mclass-progress-gender",
    "source-column": "GENDER",
    "default": "Not Selected"
  },
	"birthDate": {
	    "data-type": "date-time",
        "source": "column",
        "source-column": "Date of Birth",
        "default": "1900-01-01"
	},
	"hispanicLatinoEthnicity": {
	    "data-type": "boolean",
        "source": "lookup_table",
        "source-table": "mclass-progress-hispanic",
        "source-column": "RACE",
        "default": "false"
	}
}', NULL, NULL)
INSERT [dataflow].[datamap] ([ID], [Name], [EntityID], [Map], [CreateDate], [UpdateDate]) VALUES (4, N'M:Class Progress - Student Enrollment', 3, N'{
  "schoolReference": {
    "schoolId": {
      "data-type": "integer",
      "source": "lookup-table",
      "source-table": "mclass-progress-schools",
      "source-column": "School Name"
    }
  },
  "studentReference": {
    "studentUniqueId": {
      "data-type": "string",
      "source": "column",
      "source-column": "Student Primary ID"
    }
  },
  "entryDate": {
    "data-type": "date-time",
    "source": "column",
    "source-column": "Enrollment Date"
  },
  "entryGradeLevelDescriptor": {
    "data-type": "string",
    "source": "lookup-table",
    "source-table": "mclass-progress-grades",
    "source-column": "Grade",
    "default": "Twelfth grade"
  }
}', NULL, NULL)
INSERT [dataflow].[datamap] ([ID], [Name], [EntityID], [Map], [CreateDate], [UpdateDate]) VALUES (5, N'M:Class Progress - Assessment Item', 13, N'{
  "assessmentReference": {
    "title": {
      "data-type": "string",
      "source": "column",
      "source-column": "Assessment"
    },
    "assessedGradeLevelDescriptor": {
      "data-type": "string",
      "source": "static",
      "value": "Twelfth grade"
    },
    "academicSubjectDescriptor": {
      "data-type": "string",
      source: "static",
      "value": "Reading"
    },
    "version": {
      "data-type": "integer",
      "source": "static",
      "value": 1
    }
  },
  "identificationCode": {
    "data-type": "string",
    "source": "column",
    "source-column": "Measure"
  }
}', NULL, CAST(N'2017-10-12T15:31:50.210' AS DateTime))
INSERT [dataflow].[datamap] ([ID], [Name], [EntityID], [Map], [CreateDate], [UpdateDate]) VALUES (6, N'M:Class Progress - Student Assessment w/ One Item Per', 2, N'{
  "assessmentReference": {
    "title": {
      "data-type": "string",
      "source": "column",
      "source-column": "Assessment"
    },
    "assessedGradeLevelDescriptor": {
      "data-type": "string",
      "source": "lookup-table",
      "source-table": "mclass-progress-grade",
      "source-column": "Assessment Grade",
      "default": "Twelfth grade"
    },
    "academicSubjectDescriptor": {
      "data-type": "string",
      "source": "static",
      "value": "Reading"
    },
    "version": {
      "data-type": "integer",
      "source": "static",
      "value": "1"
    }
  },
  "studentReference": {
    "studentUniqueId": {
      "data-type": "string",
      "source": "column",
      "source-column": "Student Primary ID"
    }
  },
  "administrationDate": {
    "data-type": "date-time",
    "source": "column",
    "source-column": "Probe Clientdate"
  },
  "items": [
    {
      "assessmentItemReference": {
        "assessmentTitle": {
          "data-type": "string",
          "source": "column",
          "source-column": "Assessment"
        },
        "academicSubjectDescriptor": {
          "data-type": "string",
          "source": "static",
          "value": "Reading"
        },
        "assessedGradeLevelDescriptor": {
          "data-type": "string",
          "source": "lookup-table",
          "source-table": "mclass-progress-grade",
          "source-column": "Assessment Grade",
          "default": "Twelfth grade"
        },
        "version": {
          "data-type": "integer",
          "source": "static",
          "value": "1"
        },
        "identificationCode": {
          "data-type": "string",
          "source": "column",
          "source-column": "Measure"
        }
      },
      "assessmentItemResultType": {
        "data-type": "string",
        "source": "static",
        "value": "Met Standard"
      }
    }
  ]
}', NULL, NULL)
INSERT [dataflow].[datamap] ([ID], [Name], [EntityID], [Map], [CreateDate], [UpdateDate]) VALUES (8, N'M:Class Progress - Assessment', 7, N'{
    "title": {
        "data-type": "string",
        "source": "column",
        "source-column": "Assessment"
    },
    "assessedGradeLevelDescriptor": {
        "data-type": "string",
        "source": "static",
        "value": "Twelfth grade"
    },
    "academicSubjectDescriptor": {
        "data-type": "string",
        source: "static",
        "value":  "Reading"
    },
  "version": {
    "data-type": "integer",
    "source": "static",
    "value": 1
  },
  "namespace": {
    "data-type": "string",
    "source": "static",
    "value": "http://ed-fi.org/Assessment/Assessment.xml"
  },
 "identificationCodes": [
    {
      "assessmentIdentificationSystemDescriptor": {
        "data-type": "string",
        "source": "static",
        "value": "School"
      },
      "identificationCode": {
        "data-type": "string",
        "source": "column",
        "source-column": "Assessment"
      }
    }
  ]
}', NULL, CAST(N'2017-10-12T15:30:04.840' AS DateTime))
SET IDENTITY_INSERT [dataflow].[datamap] OFF
GO