using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int rows;
    public int cols;
    public int AOI;
    [SerializeField]
    private GameObject Row;
    [SerializeField]
    private Tile Tile;
    [HideInInspector]
    public Tile[,] Grid;

    private void Start()
    {
        Grid = new Tile[rows, cols];
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        for(int row=0; row<rows; row++)
        {
            var newRow = Instantiate(Row, transform.position, Quaternion.identity);
            newRow.transform.SetParent(gameObject.transform);

            for(int col=0; col<cols; col++)
            {
                var newTile = Instantiate(Tile, transform.position, Quaternion.identity);
                newTile.transform.SetParent(newRow.transform);

                newTile.SetPosition(row, col);
                newTile.GenerateTileNo(cols);
                newTile.GenerateTileColor();
                newTile.OnClickTile += OpenTiles;
                //newTile.GetComponent<Tile>().OpenTile();

                Grid[row,col] = newTile.GetComponent<Tile>();
            }
        }
    }

    public void OpenTiles(int row, int col)
    {
        for (int a = -AOI; a <= AOI; a++)
        {
            for (int b = -AOI; b <= AOI; b++)
            {
                if (row + a < 0 || col + b < 0 || row + a > rows - 1 || col + b > cols - 1 || Grid[row + a, col + b].isOpen)
                {
                    continue;
                }
                Grid[row + a, col + b].OpenTile();
                Grid[row + a, col + b].OnClickTile -= OpenTiles;
            }
        }
    }

}
