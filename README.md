# Data Flow

## Overview

Data Flow is a toolset designed to help ease the burden of data migration and utilization in learning environments.  It does so by providing methods to extract information out of spreadsheet-based data (CSV and Excel files), and transform and load to the Ed-Fi Alliance Operational Data Store (ODS) API (see (https://www.ed-fi.org/what-is-ed-fi/ed-fi-technology/)).

Data Flow is a tool set primarily based a .C# NET toolset with a web administration panel in ASP.NET to view data and job status, and server components as .NET command-line applications to process data.  Data Flow also contains a Google Chrome extension prototype to help automate the delivery of data from web sites without SFTP/FTPS export ability.  Data Flow is designed to run on-premise or within cloud hosted environments like Microsoft Azure or Amazon Web Services.  This is designed to match the Ed-Fi ODS and API operating model of choice by education-serving entities.

## Use Cases

* Obtain CSV or Excel files via SFTP, FTPS, web site via Chrome extension or manual upload
* Map source data to Ed-Fi API endpoints for roster and learning data population
* Populate roster and learning data into a Ed-Fi ODS API
* View learning data and job status within ODS browser

## Installation Requirements

* Visual Studio 2015 with .NET 4.5.2 (used to remain consistent with the Ed-Fi ODS API 2.x)
* Microsoft Azure with App Services -or-
* Windows Server 2012+ with IIS 8+ and MS SQL 2012+ either within a Virtual Machine or physical server
* An operating Ed-Fi ODS API 2.x

## Documentation

For documentation, including installation steps, please see the Data Flow wiki on GitHub at:  https://github.com/schoolstacks/dataflow/wiki

## Contributing

Community contributions to this application will keep it healthy and active.  We strongly welcome pull requests with new feature enhancements and bug fixes.

## License

This project is licensed under the Apache 2.0 license - see the [LICENSE.md](LICENSE.md) file for details.