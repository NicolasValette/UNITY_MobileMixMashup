using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobileMixMashup.HexaSort.Generator
{
    public enum HexOrientation
    {
        FlatTop,
        PointyTop
    }
    public class HexGridGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject _hexPrefab;
        [SerializeField]
        private HexOrientation _orientation;
        [SerializeField]
        [Range(0,10)]
        private int _size;

        // Start is called before the first frame update
        void Start()
        {
            GenerateGrid(Vector3.zero, _size);
        }

        // Update is called once per frame
        void Update()
        {
        
        }


        private void GenerateGrid (Vector3 startingPos, int size)
        {
            
            float horizontalSpace = (_orientation == HexOrientation.FlatTop)?(3f / 2f) * 0.5f:(Mathf.Sqrt(3f) * 0.5f);
            float verticalSpace = (_orientation == HexOrientation.FlatTop) ? (Mathf.Sqrt(3f) * 0.5f) : (3f/2f) * 0.5f;


            for (int i = 0; i < size; i++)
            {
                Vector3 tmp1 = new Vector3(horizontalSpace, 0, 0);
                Vector3 tmp2 = new Vector3(0,0, verticalSpace);
                Instantiate(_hexPrefab, tmp1 * i, Quaternion.identity);
                Instantiate(_hexPrefab, tmp2 * i, Quaternion.identity);
            }
        }
    }
}
