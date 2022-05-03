using Config;

namespace Battle
{
    public class Survive : ModeBase
    {
        public override void Start()
        {
            //load mode settings
            var config = Configs.Get<SurviveConfig>();
            //enemy spawner

            //enemy controller(EC)
            //fireTrigger
            //touch input handler(TIH)
            //connect TIH and EC
            //open ui
        }
    }
}