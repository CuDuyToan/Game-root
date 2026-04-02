using CoreSystem.Persistent;
using UnityEngine;
using CoreSystem.Data;

namespace CoreSystem.MainMenu
{
    public class NewGameSetup : MonoBehaviour
    {
        public static NewGameSetup Instance;
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

        [SerializeField] public int slot = -1;
        [SerializeField] private string characterName;

        public void SetCharacterName(string name)
        {
            this.characterName = name;
        }

        public void Create()
        {
            if (characterName.Length < 4)
            {
                Debug.LogWarning("Character name must be at least 4 characters long.");
                return;
            }

            slot = GameDataService.Instance.addSlotSave(new MetaData()
            {
                characterName = this.characterName,
            });
        }
    }
}