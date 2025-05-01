using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridHandler : MonoBehaviour
{
    public List<GameObject> cards;         // Assign a UI Image prefab
    public RectTransform gridParent;       // Parent panel to hold images

    public int rows = 2;
    public int columns = 2;

    public Vector2 cellSize = new Vector2(200, 200);
    public Vector2 spacing = new Vector2(10, 10);
    public Vector2 startOffset = new Vector2(0, 0); // Optional offset from center

    private void Awake()
    {
        if (cards.Count != 0) return;
        foreach (Transform child in gridParent) {
            cards.Add(child.gameObject);
        }
    }

    void Start()
    {
        CreateGrid();
    }

    public void CreateGrid() {
        if (cards == null || gridParent == null)
        {
            Debug.LogError("Image prefab or grid parent is not assigned.");
            return;
        }

        float totalWidth = columns * cellSize.x + (columns - 1) * spacing.x;
        float totalHeight = rows * cellSize.y + (rows - 1) * spacing.y;

        Vector2 origin = new Vector2(-totalWidth / 2f, totalHeight / 2f) + startOffset;

        int cardIndex = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                GameObject imgObj = cards[cardIndex];
                RectTransform rt = imgObj.GetComponent<RectTransform>();

                if (rt == null) continue;

                rt.sizeDelta = cellSize;
                rt.anchorMin = rt.anchorMax = rt.pivot = new Vector2(0.5f, 0.5f);

                Vector2 pos = origin + new Vector2(col * (cellSize.x + spacing.x), -row * (cellSize.y + spacing.y));
                rt.anchoredPosition = pos;

                cardIndex++;

                imgObj.SetActive(true);
            }
        }
    }
}
