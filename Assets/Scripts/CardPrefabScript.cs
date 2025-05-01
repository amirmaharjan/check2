using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPrefabScript : MonoBehaviour
{
    [SerializeField]
    private int cardId;
    [SerializeField]
    private string cardName;

    [SerializeField]
    private Image image;

    [SerializeField]
    private ImageType imageType;

    public void InitiualizeCard(CardSO cardSO) {
        cardId = cardSO.cardId;
        cardName = cardSO.cardName;
    }
}
