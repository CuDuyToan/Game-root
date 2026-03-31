using CoreSystem.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CoreSystem.MainMenu
{
    public class SlotUI : MonoBehaviour
    {
        public bool hasData = false;
        private int slotIndex = -1;
        public int SlotIndex => slotIndex;
        [SerializeField] private TextMeshProUGUI characterName;
        [SerializeField] private Image characterImg;
        [SerializeField] private TextMeshProUGUI level;
        [SerializeField] private TextMeshProUGUI playTime;

        public void Setup(MetaData data)
        {
            if (data == null) return;
            hasData = true;
            slotIndex = data.slot;
            this.characterName.text = data.characterName;
            //this.characterImg.sprite = data.image;
            this.level.text = $"Level:{data.level}.";
            //this.playTime.text = TimeManager.convertTotalTimeToString(data.playedTime);
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
