using MobileMixMashup.HexaSort.Generator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobileMixMashup
{
    public class HexGridManager : MonoBehaviour
    {
        [SerializeField]
        private HexGridGenerator _gridGenerator;
        private HexaSortSettings _settings;

        // Start is called before the first frame update
        void Start()
        {
            GameObject settingsGA = GameObject.Find("HexaSortSettings");
            if (settingsGA == null)
            {
                Debug.LogError("Settings missing");
            }
            else
            {
                _settings = settingsGA.GetComponent<HexaSortSettings>();
            }
            InitGame();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void InitGame()
        {
            if (_gridGenerator == null)
            {
                Debug.LogError("generator missing");
            }

            _gridGenerator.GenerateGrid(_settings.FloorSize);
        }
    }
}
