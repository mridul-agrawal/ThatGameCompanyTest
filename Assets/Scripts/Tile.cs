using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public int rowNo;
    public int colNo;
    public int tileNumber = 1;
    public Color tileColor;
    public TextMeshProUGUI tileNoText;

    public void SetPosition(int row, int col)
    {
        rowNo = row;
        colNo = col;
    }

    public void GenerateTileNo(int cols)
    {
        tileNumber = rowNo * cols + colNo + 1;
    }

    public void GenerateTileColor()
    {
        tileColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    public void OpenTile()
    {
        tileNoText.text = tileNumber.ToString();
        gameObject.GetComponent<Image>().color = tileColor;
    }

}
