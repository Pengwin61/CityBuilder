using Cysharp.Threading.Tasks;
using System.Threading;

namespace Loading.Steps
{
    public class MainLoadingCompleteStep : ILoading
    {
        public UniTask Load(CancellationToken cancelLoading)
        {
            //hide loading window
            //open main menu window
            return UniTask.CompletedTask;
        }
    }
}