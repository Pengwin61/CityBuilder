using Cysharp.Threading.Tasks;
using System.Threading;

namespace Loading.Steps
{
    public class PoolStep : ILoading
    {
        public UniTask Load(CancellationToken cancelLoading)
        {
            ObjectPooler.Init();
            return UniTask.CompletedTask;
        }
    }
}