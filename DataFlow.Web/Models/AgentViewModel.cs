using System.Collections.Generic;
using DataFlow.Models;
using Renci.SshNet.Sftp;

namespace DataFlow.Web.Models
{
    public class AgentViewModel
    {
        public class Index
        {
            public Index()
            {
                Agents = new List<Agent>();
                SftpFiles = new List<SftpFile>();
            }

            public List<Agent> Agents { get; set; }
            public List<SftpFile> SftpFiles { get; set; }
        }
    }
}