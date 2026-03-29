using UnityEngine;
using System.Collections;

namespace CoreSystem.Data
{

    [System.Serializable]
    public class MetaData
    {
        public int slot = 0;
        public float playedTime = 0;
        public string characterName = "";
        // character image
        // preview map
        public int level = 0;
        public string version = "v0";
    }
}