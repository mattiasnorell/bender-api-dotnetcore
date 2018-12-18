using System;
using System.Collections.Generic;

namespace BenderApi.Models{
    public class Project{
        public int Id { get ;set; }
        public string ProjectId { get ;set; }
        public string ProjectName {get ;set;}
        public string RepositoryUrl{ get;set;}
        public string BranchName { get;set;}
        public string Version { get;set; }
        public DateTime LastDeployAtUtc { get ;set;}
        public IEnumerable<DeployEnvironment> DeployEnvironments { get; set; }
    }
}