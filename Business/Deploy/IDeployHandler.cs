using System.Threading.Tasks;

namespace BenderApi.Business.Deploy{
    public interface IDeployHandler {
        void Deploy();
        Task<string> RunDeployStep(string app, string arguments);
    }
}