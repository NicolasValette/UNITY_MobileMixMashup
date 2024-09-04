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

        public int I;
        public int J;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }


        public void GenerateGrid ()
        {
            float horizontalSpace = (_orientation == HexOrientation.FlatTop)?(3f / 2f) * 0.5f:(Mathf.Sqrt(3f) * 0.5f);
            float verticalSpace = (_orientation == HexOrientation.FlatTop) ? (Mathf.Sqrt(3f) * 0.5f) : (3f/2f) * 0.5f;


            for (int i = 0; i < I; i++) //col
            {
                for (int j=0; j < J; j++) //row
                {
                    Vector3 pos = new Vector3(horizontalSpace * i + ((j % 2 == 0) ? 0 : horizontalSpace / 2),
                        0,
                        verticalSpace * j);

                    GameObject GO = Instantiate(_hexPrefab, pos, Quaternion.identity);
                    GO.GetComponent<Renderer>().material.color = Random.ColorHSV();
                    
                }
                
                
            }
        }
    }
}
