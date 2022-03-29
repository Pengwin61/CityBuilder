using System;
using System.Collections;
using System.Collections.Generic;

namespace Loadings
{
    public interface ILoading
    {
        void Load();
        bool IsLoaded { get; }
    }


    public class LoadingSteps
    {
        protected List<ILoading> steps = new List<ILoading>();

        public void AddStep(Action init, Func<bool> isLoad)
        {
            AddStep(new Initializer(init, isLoad));
        }

        public void AddStep(Action init)
        {
            AddStep(new Initializer(init));
        }

        public void AddStep(ILoading loading)
        {
            steps.Add(loading);
        }
    }

    public class LoadingInTurn : LoadingSteps, ILoading
    {
        public bool IsLoaded { get; set; }

        public void Load()
        {
            CoroutineContainer.Start(LoadInTurn());
        }

        public IEnumerator LoadInTurn()
        {
            var initAssets = steps.GetEnumerator();
            while (initAssets.MoveNext())
            {
                yield return Yielders.EndOfFrame;
                var asset = initAssets.Current;
                asset.Load();
                while (!asset.IsLoaded)
                {
                    yield return Yielders.EndOfFrame;
                }
            }
            IsLoaded = true;
        }
    }

    public class LoadingAsync : LoadingSteps, ILoading
    {
        public bool IsLoaded
        {
            get
            {
                for (int i = 0; i < steps.Count; i++)
                {
                    if (!steps[i].IsLoaded)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public void Load()
        {
            for (int i = 0; i < steps.Count; i++)
            {
                steps[i].Load();
            }
        }
    }

    public class Initializer : ILoading
    {
        private readonly Action initializedAction;
        private readonly Func<bool> isLoadAction;

        public Initializer(Action init)
        {
            initializedAction = init;
            isLoadAction = () => true;
        }
        public Initializer(Action init, Func<bool> isLoaded)
        {
            initializedAction = init;
            isLoadAction = isLoaded;
        }

        public bool IsLoaded => isLoadAction();

        public void Load()
        {
            initializedAction?.Invoke();
        }
    }
}