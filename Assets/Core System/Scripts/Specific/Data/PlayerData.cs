using System.Collections.Generic;
using UnityEngine;

namespace CoreSystem.Data
{
    public class PlayerData
    {
        public string name;
        public List<ItemData> itemStorage;
        public List<StatsData> stats;
        public List<string> passive;
        public List<EffectData> effects;

        public Vector2Data position;
        public Vector2Data direct;
    }
}
