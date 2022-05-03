using System.Collections.Generic;
using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = ConfigName, menuName = "Configurations/Configs", order = 1)]
    public class Configs : ScriptableObject
    {
        private const string ConfigName = "Configs";
        private static Configs _instance;

        public static Config Get<Config>()
            where Config : ConfigBase
        {
            return _instance.GetInternal<Config>();
        }

        public static void Init()
        {
            _instance = Resources.Load<Configs>(ConfigName);
        }

        [SerializeField] private List<ConfigBase> _configRefs;

        private Config GetInternal<Config>()
            where Config : ConfigBase
        {
            for (int i = 0; i < _configRefs.Count; i++)
            {
                if (_configRefs is Config neededConfig)
                {
                    return neededConfig;
                }
            }
            return null;
        }
    }
}