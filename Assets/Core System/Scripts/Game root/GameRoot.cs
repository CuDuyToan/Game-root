using CoreSystem.Configuration;
using CoreSystem.Data;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace CoreSystem
{
    public class GameRoot : MonoBehaviour
    {
        public static GameRoot Instance;
        public GameSetting gameSetting;

        private void Start()
        {
            gameSetting = GameSetting.Instance;
        }
    }

}