using System.Collections.Generic;

namespace BenderApi.Models{
    public class DeployEnvironment{
        public int Id { get ;set; }
        public string Name {get ;set;}
        public string Destination{ get;set;}
        public BuildConfiguration BuildConfiguration { get;set;}
    }
}