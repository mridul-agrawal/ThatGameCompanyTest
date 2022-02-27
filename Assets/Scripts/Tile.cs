using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int rowNo;
    public int ColNo;
    public int tileNumber = 1;

    public void SetPosition(int row, int col)
    {
        rowNo = row;
        ColNo = col;
    }
}
