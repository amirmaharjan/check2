using System.Collections;
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

    private void OnEnable()
    {
        toggle = false;
        CombinationHandler.onFlipBack += FlipCardBack;
    }

    public void InitiualizeCard(CardSO cardSO) {
        cardId = cardSO.cardId;
        cardName = cardSO.cardName;

        image.sprite = cardSprites[cardId];
        StartCoroutine(FlipCardAtInit());
    }

    private IEnumerator FlipCardAtInit() {
        yield return new WaitForSeconds(1f);
        image.sprite = cardBackSide;
        clickHandler.enabled = true;
    }

    public void FlipCard() {
        AudioHandler.instance.PlayAudio(0);
        toggle = !toggle;

        if (toggle)
        {
            image.sprite = cardSprites[cardId];
            clickHandler.enabled = false;
            CombinationHandler.instance.OnClick(cardId, this.gameObject);
        }
        else image.sprite = cardBackSide;
    }

    private void FlipCardBack() => StartCoroutine(DelayFlip());

    private IEnumerator DelayFlip() {
        yield return new WaitForSeconds(0.2f);
        toggle = false;
        image.sprite = cardBackSide;
        clickHandler.enabled = true;
    }

    private void OnDisable()
    {
        CombinationHandler.onFlipBack -= FlipCardBack;
    }
}
