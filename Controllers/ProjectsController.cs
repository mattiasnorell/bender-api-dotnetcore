
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BenderApi.Business.Database;
using BenderApi.Business.Deploy;
using BenderApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BenderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IDeployHandler deployHandler;
        private readonly IDatabaseRepository databaseRepository;

        public ProjectsController(IDeployHandler deployHandler, IDatabaseRepository databaseRepository){
            this.deployHandler = deployHandler;
            this.databaseRepository = databaseRepository;
        }
        
        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("getall")]
        public ActionResult<IEnumerable<Project>> Get(){

            var projects = this.databaseRepository.GetAllProjects();
            
            return projects.ToList();
        }

        [HttpPost]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("deploy")]
        public async Task<ActionResult<List<string>>> Deploy(DeployConfigurationDto deployConfiguration)
        {
            var project = this.databaseRepository.GetProject(deployConfiguration.ProjectId);
            var result = new List<string>();
            var environment = project.DeployEnvironments.Single(e => e.Id == deployConfiguration.EnvironmentId);

            foreach(var step in environment.BuildConfiguration.Steps){
                result.Add($"=== { environment.Name } === ");
                var buildStepResult = await this.deployHandler.RunDeployStep(step.Application, step.Arguments);
                result.Add(buildStepResult);
            }

            return result;
        }

    }

    public class DeployConfigurationDto{
        public int ProjectId{get;set;}
        public int EnvironmentId {get;set; }
    }
}
