using UnityEngine;
using UnityEngine.UI;

namespace MobileMixMashup
{
    public enum EDifficulty
    {
        Custom,
        Easy,
        Medium,
        Hard
    }

    public abstract class GameSettings : MonoBehaviour
    {
        [Header("Presets")]
        [SerializeField] private Color SelectedDifficultyColor = Color.cyan;
        [SerializeField] private Image EasyButton;
        [SerializeField] private Image MediumButton;
        [SerializeField] private Image HardButton;

        public EDifficulty Difficulty => _difficulty;
        private EDifficulty _difficulty = EDifficulty.Custom;

        public virtual void SetEasySettings()
        {
            SetDifficulty(EDifficulty.Easy);
        }

        public virtual void SetMediumSettings()
        {
            SetDifficulty(EDifficulty.Medium);
        }

        public virtual void SetHardSettings()
        {
            SetDifficulty(EDifficulty.Hard);
        }

        protected void SetDifficulty(EDifficulty difficulty)
        {
            _difficulty = difficulty;
            EasyButton.color = _difficulty == EDifficulty.Easy ? SelectedDifficultyColor : Color.white;
            MediumButton.color = _difficulty == EDifficulty.Medium ? SelectedDifficultyColor : Color.white;
            HardButton.color = _difficulty == EDifficulty.Hard ? SelectedDifficultyColor : Color.white;
        }
    }
}
