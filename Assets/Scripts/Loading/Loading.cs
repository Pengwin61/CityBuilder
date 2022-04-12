using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Loading
{
    public interface ILoading
    {
        UniTask Load(CancellationToken cancelLoading);
    }

    public class LoadingSteps
    {
        protected Queue<ILoading> steps;

        public LoadingSteps(params ILoading[] loadings)
        {
            steps = new Queue<ILoading>(loadings);
        }
    }

    public class LoadingInTurn : LoadingSteps, ILoading
    {
        public LoadingInTurn(params ILoading[] loadings) : base(loadings) { }

        public async UniTask Load(CancellationToken cancelLoading)
        {
            await UniTask.NextFrame(cancelLoading);
            while (steps.Count > 0)
            {
                await steps.Dequeue().Load(cancelLoading);
            }
        }
    }

    public class LoadingAsync : LoadingSteps, ILoading
    {
        public LoadingAsync(params ILoading[] loadings) : base(loadings) { }

        public async UniTask Load(CancellationToken cancelLoading)
        {
            var loading = steps
                .Select(step => step.Load(cancelLoading))
                .ToArray();
            steps.Clear();
            await UniTask.WhenAll(loading);
        }
    }
}