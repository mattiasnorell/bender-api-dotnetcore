using System.Diagnostics;
using System.Threading.Tasks;

namespace BenderApi.Business.Deploy{
    public class DeployHandler : IDeployHandler
    {
        public void Deploy()
        {
            
        }

        public async Task<string> RunDeployStep(string app, string arguments)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = app,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            
            process.Start();
            var processResult = await process.StandardOutput.ReadToEndAsync();
            process.WaitForExit();
            process.Close();

            return processResult;
        }
    }
}