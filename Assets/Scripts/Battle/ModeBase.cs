namespace Battle
{
    public abstract class ModeBase
    {
        public abstract void Start();

        public virtual void Finish()
        {
            BattleContoller.OnFinish();
        }
    }
}