using System.Collections.Generic;

namespace BenderApi.Models{
    public class BuildConfiguration{
        public bool ClearDestinationFolder { get ;set; }
        public IEnumerable<BuildStep> Steps {get ;set;}

    }
}