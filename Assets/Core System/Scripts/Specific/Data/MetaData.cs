using UnityEngine;
using System.Collections;

namespace CoreSystem.Data
{

    [System.Serializable]
    public class MetaData
    {
        public float playedTime = 0;
        public string characterName = "";
        public string character = "";
        // character image
        // preview map
        public int level = 0;
        public string version = "v0";
    }
}