using Utils;

namespace Battle
{
    public class BattleContoller : Singleton<BattleContoller>
    {
        public static void Start()
        {
            Instance.StartInternal();
        }

        private void StartInternal()
        {

        }
    }
}