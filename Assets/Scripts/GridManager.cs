using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int rows;
    public int cols;
    [SerializeField]
    private GameObject Row;
    [SerializeField]
    private GameObject Tile;
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

                newTile.GetComponent<Tile>().SetPosition(row, col);
                newTile.GetComponent<Tile>().GenerateTileNo(cols);
                newTile.GetComponent<Tile>().GenerateTileColor();
                newTile.GetComponent<Tile>().OpenTile();

                Grid[row,col] = newTile.GetComponent<Tile>();
            }
        }
    }
}
