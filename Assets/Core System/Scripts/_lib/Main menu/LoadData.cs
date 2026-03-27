using UnityEngine;

namespace CoreSystem.MainMenu
{
    public class LoadData : MonoBehaviour
    {
        public static LoadData Instance;

        private void setSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Awake()
        {
            setSingleton();
        }

    }
}