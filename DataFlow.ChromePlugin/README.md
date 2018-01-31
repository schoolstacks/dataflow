### Data Flow Google Chrome Extension Overview

The Google Chrome Extension is a prototype data agent within Data Flow.  It is designed to automate the cycle of downloading CSV/Excel source files from learning data web sites and upload them back to the Data Flow stack for processing into the Ed-Fi ODS API.  The Chrome Extension will replicate the GET or POST actions a user needs to take to download a file, and once the file is obtained, it will send the binary source file to Data Flow and queue for processing.  

Please note: This prototype has had a limited amount of testing, please review and extend as your particular use cases require.

### Usage

The Chrome extension can be installed by using the "Load unpacked extension..." button found in the Chrome More Tools > Extensions menu.  For production usage, one would go through the steps to package and publish in the Chrome Web Store (see: https://support.google.com/chrome_webstore/answer/1047776?hl=en), which would allow for user download and/or automated configuration to Chromebooks.

![Data Flow Chrome Extension installation](https://dl.dropboxusercontent.com/s/mamhcos5k6iuysk/dataflow-chrome-1.png?dl=0)

Once installed, the Data Flow configuration will appear and require the URL of the Data Flow Admin Panel.

![Data Flow Chrome Extension configuration](https://dl.dropboxusercontent.com/s/2cp4dozit70asx2/dataflow-chrome-2.png?dl=0)

Once configured, use the Agent screen within the Data Flow Admin Panel.  Define the Agent Type as "Chrome" and choose a GET or POST agent action.  Custom parameters are for custom POST variables which may need to be sent during the automation of downloading source files.  URL is the GET or POST action URL to retrieve the file and LoginURL is the page to redirect the end user if the file is not able to be retrieved (assuming a logged out session).  This may take some experimentation with the source web site, using Chrome's Inspect feature to determine the proper URLs and elements.  Select the UUID of the Chrome extension for each agent to receive this configuration.

![Data Flow Chrome agent configuration](https://dl.dropboxusercontent.com/s/co2b47f0dy2rhaz/dataflow-chrome-3.png?dl=0)

Once agents are defined, the Chrome extension will pick up its configuration from Data Flow.  Either this will run as configured or one may manually run by right-clicking on the Data Flow extension icon and selecting "Options".

![Data Flow Chrome agent listing within the extension](https://dl.dropboxusercontent.com/s/df1gjg7vrkp06mf/dataflow-chrome-4.png?dl=0)

### API Information

Within the Data Flow Admin Panel, four API endpoints exist to configure the Chrome extension:

* `/api/register` - Each Chrome extension will self-register to obtain an access token from Data Flow.  This creates a permissioned relationship between the client and server for purposes of communication with this API.

* `/api/agents` - Once registered, a Chrome extension will ask for its lists of pre-defined agents and schedules to obtain data.  A Data Flow administrator must grant explicit permission to each agent for data exchange to occur.

* `/api/data` - Once a source data file is obtained, this endpoint will be used to receive binaries of source files.  If accepted, the file will be stored in Azure or local file storage as configured.

* `/api/log` - File operations by the Chrome extension will be logged using this endpoint.  Results of the log can be found in the Applications log in the Data Flow Admin Panel.

### Other

Arrow icon by Ivan Ilijas from the Noun Project (https://thenounproject.com/ika2289/) as licensed by as Creative Commons CCBY