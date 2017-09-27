using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sftp_janitor
{
    class SFTPAgent
    {

        public string Name { get; set; }
        public string URL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Directory { get; set; }
        public string FilePattern { get; set; }
        public System.Guid Queue { get; set; }

        public static SFTPAgent GetInstance(string name, string url, string username, string password, string directory, string filePattern, System.Guid queue)
        {
            SFTPAgent agent = new SFTPAgent();
            agent.Name = name;
            agent.URL = url;
            agent.Username = username;
            agent.Password = password;
            agent.Directory = directory;
            agent.FilePattern = filePattern;
            agent.Queue = queue;

            return agent;
        }
    }
}
