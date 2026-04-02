using CoreSystem.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CoreSystem.MainMenu
{
    public class SlotUI : MonoBehaviour
    {
        public bool hasData = false;
        [SerializeField] private int slotIndex = -1;
        public int SlotIndex => slotIndex;
        [SerializeField] private TextMeshProUGUI characterName;
        [SerializeField] private Image characterImg;
        [SerializeField] private TextMeshProUGUI level;
        [SerializeField] private TextMeshProUGUI playTime;

        public void Setup(MetaData data)
        {
            if (data == null) return;
            hasData = true;
            this.characterName.text = data.characterName;
            this.level.text = $"Level:{data.level}.";
        }

        public void SetActive(bool value)
        {
            if (this.hasData)
            {
                this.gameObject.SetActive(value);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
