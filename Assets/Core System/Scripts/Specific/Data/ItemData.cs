using System.Collections.Generic;
using UnityEngine;

namespace CoreSystem.Data
{
    public class ItemData
    {
        public string name;
        public List<StatsData> stats;
        public List<string> passive;
        public List<EffectData> effects;
    }
}

