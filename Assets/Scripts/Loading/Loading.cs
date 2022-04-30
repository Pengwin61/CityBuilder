using Cysharp.Threading.Tasks;
using System;
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
        public Action<int> onComplete;

        public int Count => steps.Count;

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
                onComplete?.Invoke(Count);
            }
        }
    }

    public class LoadingAsync : LoadingSteps, ILoading
    {
        private int _stepsLeft;

        public LoadingAsync(params ILoading[] loadings) : base(loadings) { }

        public async UniTask Load(CancellationToken cancelLoading)
        {
            var loading = steps
                .Select(step => step.Load(cancelLoading))
                .ToArray();
            _stepsLeft = loading.Length;
            steps.Clear();
            while (IsCompleteAll(loading) is false)
            {
                await UniTask.NextFrame();
            }
        }

        private bool IsCompleteAll(UniTask[] tasks)
        {
            var stepsLeft = 0;
            for (int i = 0; i < tasks.Length; i++)
            {
                if (tasks[i].Status != UniTaskStatus.Succeeded)
                {
                    stepsLeft++;
                }
            }

            if (stepsLeft != _stepsLeft)
            {
                _stepsLeft = stepsLeft;
                onComplete?.Invoke(stepsLeft);
            }

            return stepsLeft == 0;
        }
    }

    public class LoadingAction : ILoading
    {
        private readonly Action _loadAction;

        public LoadingAction(Action action)
        {
            _loadAction = action;
        }

        public UniTask Load(CancellationToken cancelLoading)
        {
            _loadAction?.Invoke();
            return UniTask.CompletedTask;
        }
    }
}