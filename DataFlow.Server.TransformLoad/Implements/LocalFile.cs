using DataFlow.Server.TransformLoad.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataFlow.Server.TransformLoad.Implements
{
    public class LocalFile : IFile
    {
        private FileInfo _localFileInfo = null;
        private string _url = null;
        private Uri _uri;
        public LocalFile(System.IO.FileInfo localFileInfo, string url)
        {
            this._localFileInfo = localFileInfo;
            _url = url;
            this._uri = new Uri(url);
        }

        public string FileUrl
        {
            get
            {
                return this._url;
            }
        }

        public string Name
        {
            get
            {
                return this._localFileInfo.Name;
            }
        }

        public Uri Uri
        {
            get
            {
                return _uri;
            }
        }

        public string DownloadText()
        {
            return File.ReadAllText(this._localFileInfo.FullName);
        }

        public void DownloadToFile(string filePath, FileMode mode)
        {
            switch (mode)
            {
                case FileMode.Create: case FileMode.CreateNew:
                    File.Copy(this._localFileInfo.FullName, filePath, true);
                    break;
                case FileMode.Append:
                    File.AppendAllText(filePath, File.ReadAllText(this._localFileInfo.FullName));
                    break;
            }
        }
    }
}
