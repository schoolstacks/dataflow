using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFlow.Server.TransformLoad.Interfaces
{
    public interface IFile
    {
        string FileUrl { get; }
        string Name { get; }
        void DownloadToFile(string filePath, FileMode mode);
        string DownloadText();
        Uri Uri { get; }
    }
}
