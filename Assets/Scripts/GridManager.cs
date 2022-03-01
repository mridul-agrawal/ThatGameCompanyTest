using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridManager : MonoBehaviour
{
    public int rows;
    public int cols;
    public int AOI;
    [SerializeField] private GameObject Row;
    private List<GameObject> Rows;
    [SerializeField] private Tile Tile;
    [HideInInspector] public Tile[,] Grid;

    [SerializeField] private GameObject ResetPanel;
    [SerializeField] private Slider rowSlider;
    [SerializeField] private TextMeshProUGUI rowSliderTXT;
    [SerializeField] private Slider colSlider;
    [SerializeField] private TextMeshProUGUI colSliderTXT;
    [SerializeField] private Slider aoiSlider;
    [SerializeField] private TextMeshProUGUI aoiSliderTXT;

    private void Start()
    {
        Rows = new List<GameObject>();
        GenerateGrid();
        AssignListeners();
    }

    public void GenerateGrid()
    {
        Grid = new Tile[rows, cols];
        for (int row=0; row<rows; row++)
        {
            var newRow = Instantiate(Row, transform.position, Quaternion.identity);
            Rows.Add(newRow);
            newRow.transform.SetParent(gameObject.transform);

            for(int col=0; col<cols; col++)
            {
                var newTile = Instantiate(Tile, transform.position, Quaternion.identity);
                newTile.transform.SetParent(newRow.transform);

                newTile.SetPosition(row, col);
                newTile.GenerateTileNo(cols);
                newTile.GenerateTileColor();
                newTile.OnClickTile += OpenTiles;

                Grid[row,col] = newTile.GetComponent<Tile>();
            }
        }
    }

    private void AssignListeners()
    {
        rowSlider.onValueChanged.AddListener((v) => {
            rowSliderTXT.text = v.ToString();
        });

        colSlider.onValueChanged.AddListener((v) => {
            colSliderTXT.text = v.ToString();
        });

        aoiSlider.onValueChanged.AddListener((v) => {
            aoiSliderTXT.text = v.ToString();
        });
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

    public void CreateNewGrid()
    {
        foreach(GameObject row in Rows)
        {
            Destroy(row);
        }

        rows = (int)rowSlider.value;
        cols = (int)colSlider.value;
        AOI = (int)aoiSlider.value;

        GenerateGrid();

        ToggleResetPanel(false);
    }

    public void ToggleResetPanel(bool isActive)
    {
        ResetPanel.SetActive(isActive);
    }

}
