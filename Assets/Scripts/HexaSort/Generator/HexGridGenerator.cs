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
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        /// <summary>
        /// Generate rectangular grid of hex cell
        /// </summary>
        /// <param name="size">the size of the grid, (size x size)</param>
        public void GenerateGrid (int size, bool colorGrid = false)
        {
            float horizontalSpace = (_orientation == HexOrientation.FlatTop)?(3f / 2f) * 0.5f:(Mathf.Sqrt(3f) * 0.5f);
            float verticalSpace = (_orientation == HexOrientation.FlatTop) ? (Mathf.Sqrt(3f) * 0.5f) : (3f/2f) * 0.5f;

            for (int i = 0; i < size; i++) //col
            {
                for (int j=0; j < size; j++) //row
                {
                    Vector3 pos;
                    if (_orientation == HexOrientation.PointyTop)
                    {
                        pos = new Vector3(  horizontalSpace * i + ((j % 2 == 0) ? 0 : horizontalSpace / 2),
                                            0,
                                            verticalSpace * j);
                    }
                    else
                    {
                        pos = new Vector3(  horizontalSpace * i,
                                            0,
                                            verticalSpace * j +((i % 2 != 0) ? 0 : verticalSpace / 2));
                    }
                    GameObject GO = Instantiate(_hexPrefab, pos, (_orientation == HexOrientation.FlatTop)? Quaternion.Euler(0,90f,0) : Quaternion.identity);
                    if (colorGrid) GO.GetComponent<Renderer>().material.color = Random.ColorHSV();
                    
                }
                
                
            }
        }
        /// <summary>
        /// for test in the scene
        /// </summary>
        public void GenerateGrid ()
        {
            GenerateGrid(_size, true);
        }
    }
}
