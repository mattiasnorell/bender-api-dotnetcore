using System.Collections.Generic;
using System.Threading.Tasks;
using BenderApi.Models;

namespace BenderApi.Business.Database{
    public interface IDatabaseRepository {
        Project GetProject(int id);
        IEnumerable<Project> GetAllProjects();
    }
}