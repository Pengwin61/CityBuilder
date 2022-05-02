using Pool;
using Utils;

namespace Battle
{
    public class BattleContoller : Singleton<BattleContoller>
    {
        public static void Start<Mode>()
            where Mode : ModeBase, new()
        {
            Instance.StartInternal<Mode>();
        }
        public static void ForceFinish()
        {
            Instance.ForceFinishInternal();
        }
        public static void OnFinish()
        {
            Instance.OnFinishInternal();
        }

        private ModeBase _mode;

        private void StartInternal<Mode>()
            where Mode : ModeBase, new()
        {
            _mode = PoolLogics<ModeBase>.GetFromPool<Mode>();
            _mode.Start();
        }

        private void ForceFinishInternal()
        {
            _mode.Finish();
        }

        private void OnFinishInternal()
        {
            PoolLogics<ModeBase>.AddInPool(_mode);
        }
    }
}