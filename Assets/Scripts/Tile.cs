using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int rowNo;
    public int colNo;
    public int tileNumber = 1;

    public void SetPosition(int row, int col)
    {
        rowNo = row;
        colNo = col;
    }

    public void GenerateTileNo(int cols)
    {
        tileNumber = rowNo * cols + colNo + 1;
    }

}
