using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridHandler : MonoBehaviour
{
    public List<GameObject> cards;
    public RectTransform gridParent;

    public int rows = 2;
    public int columns = 2;

    public Vector2 cellSize = new Vector2(200, 200);
    public Vector2 spacing = new Vector2(10, 10);
    public Vector2 startOffset = new Vector2(0, 0);

    [SerializeField]
    public List<CardSO> cardSOs;

    private List<CardSO> pairedCardList = new List<CardSO>();

    public static GridHandler instance;

    private void OnEnable()
    {
        foreach (Transform child in gridParent)
        {
            cards.Add(child.gameObject);
        }
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    public void CreateGrid(int rowValue, int columnValue)
    {
        if (cards == null || gridParent == null)
        {
            Debug.LogError("Image prefab or grid parent is not assigned.");
            return;
        }

        rows = rowValue;
        columns = columnValue;
        int totalCards = rows * columns;

        if (totalCards % 2 != 0)
        {
            Debug.LogError("Total number of cards must be even to form pairs.");
            return;
        }

        pairedCardList.Clear();

        // Fill pairedCardList with pairs
        int totalPairs = totalCards / 2;

        if (cardSOs.Count < 1)
        {
            Debug.LogError("Not enough cardSOs to create pairs.");
            return;
        }

        List<CardSO> tempPool = new List<CardSO>(cardSOs);
        pairedCardList.Clear();

        for (int i = 0; i < totalPairs; i++)
        {
            // Refill the pool if needed
            if (tempPool.Count == 0)
            {
                tempPool = new List<CardSO>(cardSOs);
            }

            // Pick a random cardSO from the temp pool
            int randIndex = Random.Range(0, tempPool.Count);
            CardSO selected = tempPool[randIndex];
            tempPool.RemoveAt(randIndex);  // Prevent immediate reuse (unless pool resets)

            pairedCardList.Add(selected);
            pairedCardList.Add(selected);  // Add the pair
        }

        for (int i = 0; i < pairedCardList.Count; i++)
        {
            int rand = Random.Range(i, pairedCardList.Count);
            (pairedCardList[i], pairedCardList[rand]) = (pairedCardList[rand], pairedCardList[i]);
        }


        float totalHeight = columns * cellSize.x + (columns - 1) * spacing.x;
        float totalWidth = rows * cellSize.y + (rows - 1) * spacing.y;
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

                imgObj.SetActive(true);
                SetCardData(imgObj, pairedCardList[cardIndex]);
                cardIndex++;
            }
        }

        ScoreHandler.instance.SetTotalScoreForRound(totalPairs);
    }


    public void SetCardData(GameObject card, CardSO cardSO)
    {
        card.GetComponent<CardPrefabScript>().InitiualizeCard(cardSO);
    }

    private void OnDisable()
    {
        cards.Clear();
    }
}
