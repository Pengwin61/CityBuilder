using Cysharp.Threading.Tasks;
using System.Threading;

namespace Loading.Steps
{
    public class ConfigStep : ILoading
    {
        private const string PATH = "Configuration";

        public UniTask Load(CancellationToken cancelLoading)
        {
            //load config from path
            //save it in game class
            return UniTask.CompletedTask;
        }
    }
}