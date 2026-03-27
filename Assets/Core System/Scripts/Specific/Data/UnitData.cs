using CoreSystem.Data;
using System.Collections.Generic;
using UnityEngine;

namespace CoreSystem.Data
{
    public class UnitData
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
