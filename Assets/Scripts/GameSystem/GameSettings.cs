using System;
using UnityEngine;

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
        public EDifficulty Difficulty { get; protected set; }

        public virtual void SetEasySettings()
        {
            Difficulty = EDifficulty.Easy;
        }

        public virtual void SetMediumSettings()
        {
            Difficulty = EDifficulty.Medium;
        }

        public virtual void SetHardSettings()
        {
            Difficulty = EDifficulty.Hard;
        }
    }
}
