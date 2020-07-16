using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace TestApp.Utils.Worker
{

    [InheritedExport("IPluginTest", typeof(IWorkerJob))]
    public interface IWorkerJob
    {
        ValueTask<IWorkerJob> Init(int index, WorkerThreadResult workerThreadResult);
        ValueTask DoWorkAsync();
        WorkerThreadResult GetResults();
    }
}
