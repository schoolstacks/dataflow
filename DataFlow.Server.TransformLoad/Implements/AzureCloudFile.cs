using DataFlow.Server.TransformLoad.Interfaces;
using Microsoft.WindowsAzure.Storage.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFlow.Server.TransformLoad.Implements
{
    public class AzureCloudFile : IFile
    {
        private CloudFile _cloudFile = null;
        public AzureCloudFile(CloudFile cloudFile)
        {
            this._cloudFile = cloudFile;
        }

        public string FileUrl
        {
            get
            {
                return this._cloudFile.Uri.ToString();
            }
        }

        public string Name
        {
            get
            {
                return this._cloudFile.Name;
            }
        }

        public void DownloadToFile(string filePath, FileMode mode)
        {
            this._cloudFile.DownloadToFile(filePath, mode);
        }

        public string DownloadText()
        {
            return this._cloudFile.DownloadText();
        }

        public Uri Uri
        {
            get
            {
                return this._cloudFile.Uri;
            }
        }
    }
}
