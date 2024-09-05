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

        /// <summary>
        /// Generate rectangular grid of hex cell
        /// </summary>
        /// <param name="size">the size of the grid, (size x size)</param>
        public void GenerateGrid (int size, bool colorGrid = false)
        {
            float horizontalSpace = (_orientation == HexOrientation.FlatTop)?(3f / 2f) * 0.5f:(Mathf.Sqrt(3f) * 0.5f);
            float verticalSpace = (_orientation == HexOrientation.FlatTop) ? (Mathf.Sqrt(3f) * 0.5f) : (3f/2f) * 0.5f;

            for (int col = 0; col < size; col++) 
            {
                for (int row=0; row < size; row++)
                {
                    Vector3 pos;
                    if (_orientation == HexOrientation.PointyTop)
                    {
                        pos = new Vector3(  horizontalSpace * col + ((row % 2 == 0) ? 0 : horizontalSpace / 2),
                                            0,
                                            verticalSpace * row);
                    }
                    else
                    {
                        pos = new Vector3(  horizontalSpace * col,
                                            0,
                                            verticalSpace * row +((col % 2 != 0) ? 0 : verticalSpace / 2));
                    }
                    GameObject GO = Instantiate(_hexPrefab, pos, (_orientation == HexOrientation.FlatTop)? Quaternion.Euler(0,90f,0) : Quaternion.identity);
                    if (colorGrid) GO.GetComponent<Renderer>().material.color = Random.ColorHSV();
                }
            }
        }
        /// <summary>
        /// Call GenerateGrid with serialized parameter setup in the inspector of this gameobject.
        /// </summary>
        public void GenerateGrid ()
        {
            GenerateGrid(_size, true);
        }
    }
}
