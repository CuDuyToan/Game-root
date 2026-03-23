using UnityEngine;

namespace CoreSystem.MainMenu
{
    public class Manager : MonoBehaviour
    {
        public static Manager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }
    }
}