using TMPro;
using UnityEngine;

namespace MobileMixMashup
{
    public class HexaSortSettings : GameSettings
    {
        [Header("Displays")]
        [SerializeField] private TextMeshProUGUI FloorSizeText;
        [SerializeField] private TextMeshProUGUI ColorCountText;
        [SerializeField] private TextMeshProUGUI ProposedStacksText;

        public int FloorSize => _floorSize;
        public int MinColorCount => _minColorCount;
        public int MaxColorCount => _maxColorCount;
        public int ProposedStackCount => _proposedStackCount;

        private int _floorSize;
        private int _minColorCount;
        private int _maxColorCount;
        private int _proposedStackCount;

        private void Start()
        {
            DontDestroyOnLoad(this);
            SetEasySettings();
        }

        public override void SetEasySettings()
        {
            base.SetEasySettings();

            SetFloorSize(3);
            SetColorCount(3, 5);
            SetProposedStacksCount(3);
        }

        public override void SetMediumSettings()
        {
            base.SetMediumSettings();

            SetFloorSize(4);
            SetColorCount(3, 7);
            SetProposedStacksCount(3);
        }

        public override void SetHardSettings()
        {
            base.SetHardSettings();

            SetFloorSize(5);
            SetColorCount(3, 10);
            SetProposedStacksCount(3);
        }

        private void SetFloorSize(int size)
        {
            _floorSize = size;
            FloorSizeText.text = _floorSize.ToString();
        }

        private void SetColorCount(int min, int max)
        {
            _minColorCount = min;
            _maxColorCount = max;
            ColorCountText.text = $"{_minColorCount} to {_maxColorCount}";
        }

        private void SetProposedStacksCount(int cnt)
        {
            _proposedStackCount = cnt;
            ProposedStacksText.text = _proposedStackCount.ToString();
        }
    }
}
