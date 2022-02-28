using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Tile : MonoBehaviour
{
    public int rowNo;
    public int colNo;
    public int tileNumber = 1;
    private Color tileColor;
    [SerializeField]
    private TextMeshProUGUI tileNoText;
    private Button tileButton;
    public bool isOpen;

    public event Action<int, int> OnClickTile;

    private void Start()
    {
        tileButton = gameObject.GetComponent<Button>();
        tileButton.onClick.AddListener(OpenTile);
        isOpen = false;
    }

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
        tileColor = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
    }

    public void OnTileClick()
    {
        OnClickTile?.Invoke(rowNo,colNo);
    }

    public void OpenTile()
    {
        tileNoText.text = tileNumber.ToString();
        gameObject.GetComponent<Image>().color = tileColor;
        isOpen = true;
    }

}
