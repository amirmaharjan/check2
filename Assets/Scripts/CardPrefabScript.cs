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

    [SerializeField]
    private Sprite[] cardSprites;

    [SerializeField]
    private Sprite cardBackSide;

    private bool toggle;

    [SerializeField]
    private ClickHandler clickHandler;

    public void InitiualizeCard(CardSO cardSO) {
        cardId = cardSO.cardId;
        cardName = cardSO.cardName;

        image.sprite = cardSprites[cardId];
        //StartCoroutine(FlipCardAtInit());
    }

    private IEnumerator FlipCardAtInit() {
        yield return new WaitForSeconds(1.5f);
        image.sprite = cardBackSide;
        clickHandler.enabled = true;
    }

    public void FlipCard() {
        toggle = !toggle;

        if(toggle) image.sprite = cardSprites[cardId];
        else image.sprite = cardBackSide;
    }
}
