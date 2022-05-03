using Cysharp.Threading.Tasks;
using System.Threading;

namespace Loading.Steps
{
    public class ConfigStep : ILoading
    {
        public UniTask Load(CancellationToken cancelLoading)
        {
            Config.Configs.Init();
            return UniTask.CompletedTask;
        }
    }
}