using UnityEngine;

namespace CoreSystem.UIPersistent
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }
        private void setSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        [SerializeField] private GameObject MainMenuCanvas;
        [SerializeField] private GameObject GamePlayCanvas;
        [SerializeField] private GameObject PopupCanvas;


        private void Awake()
        {
            setSingleton();
        }

        public void setActiveMainMenuUI(bool active)
        {
            MainMenuCanvas.SetActive(active);
        }

        public void setActiveGamePlayUI(bool active)
        {
            GamePlayCanvas.SetActive(active);
        }

        public void setActivePopupUI(bool active)
        {
            PopupCanvas.SetActive(true);
        }
    }
}
