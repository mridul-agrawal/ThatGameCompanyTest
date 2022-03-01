using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

/// <summary>
/// This Class is responsible for handling the data and functionality of a tile in the grid.
/// </summary>
public class Tile : MonoBehaviour
{
    // Tile Data:
    private int rowNo;
    private int colNo;
    private int tileNumber = 1;
    private Color tileColor;

    public bool isOpen;
    public event Action<int, int> OnClickTile;

    // Tile UI:
    [SerializeField]
    private TextMeshProUGUI tileNoText;
    private Button tileButton;


    private void Start()
    {
        tileButton = gameObject.GetComponent<Button>();
        tileButton.onClick.AddListener(OpenTile);
        isOpen = false;
    }

    // Sets the position of this tile in the grid.
    public void SetPosition(int row, int col)
    {
        rowNo = row;
        colNo = col;
    }

    // Generates a tile number according to this tile's position.
    public void GenerateTileNo(int cols)
    {
        tileNumber = rowNo * cols + colNo + 1;
    }

    // This method generates a random color for this tile.
    public void GenerateTileColor()
    {
        tileColor = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
    }

    // This Method Invokes the OnclickTile event.
    public void OnTileClick()
    {
        OnClickTile?.Invoke(rowNo,colNo);
    }

    // This method Opens the tile & displays the tile data (number and color).
    public void OpenTile()
    {
        tileNoText.text = tileNumber.ToString();
        gameObject.GetComponent<Image>().color = tileColor;
        isOpen = true;
    }

}
